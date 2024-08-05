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
        public void DeleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, r.RecipeName from recipe r left join CookbookRecipe cr on cr.recipeid = r.recipeid left join MealCourseRecipe mcr on mcr.recipeid = r.recipeid left join Direction d on d.recipeid = r.recipeid left join RecipeIngredient ri on ri.recipeid = r.recipeid where cr.cookbookrecipeid is null and mcr.mealcourserecipeid is null and d.directionid is null and ri.recipeingredientid is null");
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["recipename"].ToString(); /*dt.Rows[0]["Num"] + " " + dt.Rows[0]["RecipeName"];*/
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
        public void ChangeExistingRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipe in DB, can't run test");
            int calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("Calories for recipeid " + recipeid + " is " + calories);
            calories = calories + 1;
            TestContext.WriteLine("Change calories to " + calories);

            //DateTime datedraft = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            //TestContext.WriteLine("Calories for recipeid " + recipeid + " is " + calories);
            //calories = calories + 1;
            //TestContext.WriteLine("Change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            Recipe.Save(dt);

            int newcalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(newcalories == calories, "Calories for recipe (" + recipeid + ") = " + newcalories);
            TestContext.WriteLine("Calories for recipe (" + recipeid + ") = " + newcalories);
        }

        [Test]
        [TestCase(300, "2024-1-1")]
        [TestCase(150, "2023-5-10")]
        public void InsertNewRecipe(int calories, DateTime datedraft)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "Can't run test, no cuisines in DB");
            int usersid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usersid from users");
            Assume.That(usersid > 0, "Can't run test, no users in DB");

            DataTable dtnew = SQLUtility.GetDataTable("select top 1 r.RecipeName from recipe r");

            string recipe = dtnew.Rows[0]["recipename"].ToString();
            recipe = recipe + " " + DateTime.Now.ToString("HH:mm:ss:fff"/*"HH:mm:ss:fff"*/);

            TestContext.WriteLine("Insert recipe with recipename = " + recipe);
            r["RecipeName"] = recipe;
            r["CuisineId"] = cuisineid;
            r["UsersId"] = usersid;
            r["Calories"] = calories;
            r["DateDraft"] = datedraft;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from Recipe where RecipeName = '" + recipe + "'");

            Assert.IsTrue(newid > 0, "Recipe with recipename = " + recipe + " is not found in DB");
            TestContext.WriteLine("Recipe with " + recipe + " is found in DB with pk value = " + newid);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            TestContext.WriteLine("Existing recipe with id = " + recipeid);
            TestContext.WriteLine("Ensure that app loads recipe " + recipeid);

            DataTable dt = Recipe.Load(recipeid);
            int loadedid = (int)dt.Rows[0]["recipeid"];

            Assert.IsTrue(loadedid == recipeid, loadedid + " <> " + recipeid);

            TestContext.WriteLine("Loaded recipe (" + recipeid + ")");
        }

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }
    }
}