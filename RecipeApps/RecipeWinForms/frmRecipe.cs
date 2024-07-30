using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUFramework;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int recipeid)
        {
            string sql = "select r.*, c.CuisineType, u.LastName, u.FirstName from recipe r join cuisine c on r.CuisineId = c.CuisineId join Users u on r.UsersId = u.UsersId where r.RecipeId = " + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            lblCuisine.DataBindings.Add("Text", dt, "CuisineType");
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtUserLastName.DataBindings.Add("Text", dt, "LastName");
            txtUserFirstName.DataBindings.Add("Text", dt, "FirstName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtDateDraft.DataBindings.Add("Text", dt, "DateDraft");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            txtCurrentStatus.DataBindings.Add("Text", dt, "CurrentStatus");
            this.Show();
        }
    }
}
