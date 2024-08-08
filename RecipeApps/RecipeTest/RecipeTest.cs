using System;
using System.Data;

namespace RecipeTest
{
    public class RecipeTests
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server =tcp:dev-eschottenstein.database.windows.net,1433; Initial Catalog=HeartyHearthDB;Persist Security Info=False;User ID=cpuadmin-es;Password=EstiS3784!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        [Test]
        public void GetListOfCuisines()
        {
            int cuisinecount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "No cuisines in DB, Can't test");
            TestContext.WriteLine("Num of cuisines in DB = " + cuisinecount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + cuisinecount);

            DataTable dt = Recipe.GetCuisineList();

            Assert.IsTrue(dt.Rows.Count == cuisinecount, "num rows returned by app (" + dt.Rows.Count + ") <> " + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisines returned by app = " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int userscount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from users");
            Assume.That(userscount > 0, "No users in DB, Can't test");
            TestContext.WriteLine("Num of users in DB = " + userscount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + userscount);

            DataTable dt = Recipe.GetUsersList();

            Assert.IsTrue(dt.Rows.Count == userscount, "num rows returned by app (" + dt.Rows.Count + ") <> " + userscount);
            TestContext.WriteLine("Number of rows in Users returned by app = " + dt.Rows.Count);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            TestContext.WriteLine("Existing recipe with id = " + recipeid);
            TestContext.WriteLine("Ensure that app loads recipe " + recipeid);

            DataTable dt = Recipe.Load(recipeid);
            int loadedid = 0;
            if(dt.Rows.Count > 0)
            {
                loadedid = (int)dt.Rows[0]["recipeid"];
            }

            Assert.IsTrue(loadedid == recipeid, loadedid + " <> " + recipeid);
            TestContext.WriteLine("Loaded recipe (" + recipeid + ")");
        }

        [Test]
        public void SearchRecipes()
        {
            string criteria = "a";
            int num = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from recipe where recipename like '%" + criteria + "%'");
            Assume.That(num > 0, "There are no recipes that match the search for " + criteria);
            TestContext.WriteLine(num + " recipes that match " + criteria);
            TestContext.WriteLine("Ensure that recipe search returns " + num + " rows");

            DataTable dt = Recipe.SearchRecipes(criteria);
            int results = dt.Rows.Count;

            Assert.IsTrue(results == num, "Results of recipe search does not match number of recipe, " + results + " <> " + num);
            TestContext.WriteLine("Number of rows returned by recipe search is " + results);
        }

        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable(string.Join(Environment.NewLine, "select top 1 ",
                $"r.recipeid, r.RecipeName ",
                $"from recipe r ",
                $"left join CookbookRecipe cr on cr.recipeid = r.recipeid ",
                $"left join MealCourseRecipe mcr on mcr.recipeid = r.recipeid ",
                $"left join Direction d on d.recipeid = r.recipeid ",
                $"left join RecipeIngredient ri on ri.recipeid = r.recipeid ",
                $"where cr.cookbookrecipeid is null and mcr.mealcourserecipeid is null and d.directionid is null and ri.recipeingredientid is null"));
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipes without related records in DB, can't run test");
            TestContext.WriteLine("Existing recipe without related records with id = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app can delete recipe " + recipeid);
            
            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);
            
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with recipeid " + recipeid + " exists in DB");
            TestContext.WriteLine("Record with recipeid " + recipeid + " does not exist in DB");
        }

        [Test]
        public void DeleteRecipeWithRelatedRecords()
        {
            DataTable dt = SQLUtility.GetDataTable(string.Join(Environment.NewLine, "select top 1 ",
                $"r.recipeid, r.RecipeName ",
                $"from recipe r ",
                $"join CookbookRecipe cr on cr.recipeid = r.recipeid ",
                $"join MealCourseRecipe mcr on mcr.recipeid = r.recipeid ",
                $"join Direction d on d.recipeid = r.recipeid ",
                $"join RecipeIngredient ri on ri.recipeid = r.recipeid"));
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipes without related records in DB, can't run test");
            TestContext.WriteLine("Existing recipe with related records with id = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app cannot delete recipe " + recipeid);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipe in DB, can't run test");
            int calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("Calories for recipeid " + recipeid + " is " + calories);
            calories = calories + 1;
            TestContext.WriteLine("Change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            Recipe.Save(dt);
            int newcalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            
            Assert.IsTrue(newcalories == calories, "Calories for recipe (" + recipeid + ") = " + newcalories);
            TestContext.WriteLine("Calories for recipe (" + recipeid + ") = " + newcalories);
        }

        [Test]
        public void ChangeExistingRecipeToInvalidName()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipe in DB, can't run test");
            string recipename = GetFirstColumnFirstRowValueAsString("select r.RecipeName from recipe r where recipeid = " + recipeid);
            string newrecipename = GetFirstColumnFirstRowValueAsString("select r.RecipeName from recipe r where recipeid <> " + recipeid);
            Assume.That(newrecipename != "", "Cannot run test because there is no other recipe record in the table");
            TestContext.WriteLine("Change recipeid " + recipeid + " recipename from " + recipename + " to " + newrecipename + " which belongs to a different recipe");

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["RecipeName"] = newrecipename;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToBlankName()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipe in DB, can't run test");
            string recipename = GetFirstColumnFirstRowValueAsString("select r.RecipeName from recipe r where recipeid = " + recipeid);
            string newrecipename = "";
            TestContext.WriteLine("Change recipeid " + recipeid + " recipename from " + recipename + " to " + newrecipename + " blank");

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["RecipeName"] = newrecipename;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToInvalidCalories()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipe in DB, can't run test");
            int calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("Calories for recipeid " + recipeid + " is " + calories);
            calories = 0 - calories;
            TestContext.WriteLine("Change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            
            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        [TestCase(300, "2024-1-1")]
        [TestCase(150, "1900-5-10")]
        public void InsertNewRecipe(int calories, DateTime datedraft)
        {
            int recipeid = 0;
            DataTable dtnew = Recipe.Load(recipeid);
            DataRow r = dtnew.Rows.Add();
            Assume.That(dtnew.Rows.Count == 1);
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "Can't run test, no cuisines in DB");
            int usersid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usersid from users");
            Assume.That(usersid > 0, "Can't run test, no users in DB");
            string recipename = GetFirstColumnFirstRowValueAsString("select top 1 r.RecipeName from recipe r");            
            recipename = recipename + " " + DateTime.Now.ToString("HH:mm:ss:fff");

            TestContext.WriteLine("Insert recipe with recipename = " + recipename);
            r["RecipeName"] = recipename;
            r["CuisineId"] = cuisineid;
            r["UsersId"] = usersid;
            r["Calories"] = calories;
            r["DateDraft"] = datedraft;
            Recipe.Save(dtnew);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from Recipe where RecipeName = '" + recipename + "'");

            Assert.IsTrue(newid > 0, "Recipe with recipename = " + recipename + " is not found in DB");
            TestContext.WriteLine("Recipe with recipename = " + recipename + " is found in DB with pk value = " + newid);
        }

        public static string GetFirstColumnFirstRowValueAsString(string sql)
        {
            string s = "";
            DataTable dt = SQLUtility.GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    s = dt.Rows[0][0].ToString();
                }
            }
            return s;
        }

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }
    }
}