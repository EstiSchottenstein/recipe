using System.Data;
using System.Diagnostics;
using CPUFramework;
using CPUWindowsFormsFramework;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public void ShowForm(int recipeid)
        {
            string sql = "select r.*, c.CuisineType, u.UserName from recipe r join cuisine c on r.CuisineId = c.CuisineId join Users u on r.UsersId = u.UsersId where r.RecipeId = " + recipeid.ToString();
            dtrecipe = SQLUtility.GetDataTable(sql);
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = SQLUtility.GetDataTable("select c.CuisineId, c.CuisineType from Cuisine c");
            DataTable dtusers = SQLUtility.GetDataTable("select u.UsersId, u.UserName from Users u");
            WindowsFormsUtility.SetListBinding(lstCuisineType, dtcuisine, dtrecipe, "Cuisine");
            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "Users");
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(dtpDateDraft, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCurrentStatus, dtrecipe);
            this.Show();
        }

        private void Save()
        {
            //SQLUtility.DebugPrintDataTable(dtpresident);
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
            Debug.Print("---------------");

            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            string sql = "delete recipe where RecipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
    }
}
