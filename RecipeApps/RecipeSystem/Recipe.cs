﻿namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipename);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtrecipe)
        {
            //SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["RecipeId"];
            string sql = "";

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"CuisineId = '{r["CuisineId"]}',",
                    $"UsersId = '{r["UsersId"]}',",
                    $"Calories = '{r["Calories"]}',",
                    $"DateDraft = '{r["DateDraft"]}'",
                    $"where RecipeId = {r["RecipeId"]}");
            }
            else
            {
                sql = "insert recipe(RecipeName, CuisineId, UsersId, Calories, DateDraft)";
                sql += $"select '{r["RecipeName"]}', {r["CuisineId"]}, '{r["UsersId"]}', '{r["Calories"]}', '{r["DateDraft"]}'";
            }

            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}