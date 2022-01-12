﻿using Inventory_Management_System_A_.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System_A_.Presentation_Layer
{
    public partial class CategoryManagement : Form
    {
        public CategoryManagement()
        {
            InitializeComponent();
            
        }

        private void CategoryManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CategoryManagement_Load(object sender, EventArgs e)
        {
            UpdateCategoryList();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            categoryWiseProductListComboBox.DataSource = productDataAccess.GetAllCategoryNames();
            categoryWiseProductListComboBox.SelectedIndex = -1;
        }

        void UpdateCategoryList()
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            categoryListDataGridView.DataSource = categoryDataAccess.GetAllCategories();
        }
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            if(categoryDataAccess.AddNewCategory(addCategoryNameTextBox.Text))
            {
                MessageBox.Show("Category added");
                UpdateCategoryList();
            }
            else
            {
                MessageBox.Show("Error in adding");
            }
        }

        private void deleteCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            if (categoryDataAccess.DeleteCategory(Convert.ToInt32(deleteCategoryIdTextBox.Text)))
            {
                MessageBox.Show("Category deleted");
                UpdateCategoryList();
            }
            else
            {
                MessageBox.Show("Error in deleting");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            string value = categoryDataAccess.GetCategoryNameById(Convert.ToInt32(searchCategoryIdTextBox.Text));
            if(value==null)
            {
                MessageBox.Show("Category not found");
            }
            else
            {
                updateCategoryNameTextBox.Text = value;
            }
        }

        private void updateCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            if (categoryDataAccess.UpdateCategory(Convert.ToInt32(searchCategoryIdTextBox.Text),updateCategoryNameTextBox.Text))
            {
                MessageBox.Show("Category updated");
                UpdateCategoryList();
            }
            else
            {
                MessageBox.Show("Error in updating");
            }
        }

        private void categoryWiseProductListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            int catId = productDataAccess.GetCategoryIdByName(categoryWiseProductListComboBox.Text);
            productDataAccess = new ProductDataAccess();
            categoryWiseProductListDataGridView.DataSource = productDataAccess.GetProductsByCateGoryId(catId);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
