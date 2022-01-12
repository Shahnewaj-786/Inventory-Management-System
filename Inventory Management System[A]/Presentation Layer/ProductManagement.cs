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
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            productListDataGridView.DataSource = productDataAccess.GetAllProducts();
            productDataAccess = new ProductDataAccess();
            addCategoryComboBox.DataSource = productDataAccess.GetAllCategoryNames();
            productDataAccess = new ProductDataAccess();
            updateCategoryComboBox.DataSource = productDataAccess.GetAllCategoryNames();
        }

        private void ProductManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void UpdateProductList()
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            productListDataGridView.DataSource = productDataAccess.GetAllProducts();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            int catId = productDataAccess.GetCategoryIdByName(addCategoryComboBox.Text);
            productDataAccess = new ProductDataAccess();
            if(productDataAccess.AddNewProduct(addProductNameTextBox.Text,Convert.ToDouble(addProductPriceTextBox.Text),catId))
            {
                MessageBox.Show("Product added");
                UpdateProductList();
            }
            else
            {
                MessageBox.Show("Error in adding");
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            Product product = productDataAccess.GetProductById(Convert.ToInt32(deleteProductIdTextBox.Text));
            if(product==null)
            {
                MessageBox.Show("Product not found");
            }
            else
            {
                productDataAccess = new ProductDataAccess();
                if (productDataAccess.DeleteProduct(product.ProductId))
                {
                    MessageBox.Show("Product deleted");
                    UpdateProductList();
                }
                else
                {
                    MessageBox.Show("Error in deleting");
                }
            }
        }

        private void productListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            updateProductIdTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateProductNameTextBox.Text= productListDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateProductPriceTextBox.Text= productListDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            int catId=(int) productListDataGridView.Rows[e.RowIndex].Cells[3].Value;
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            updateCategoryComboBox.Text = categoryDataAccess.GetCategoryNameById(catId);
        }

        private void updateProductButton_Click(object sender, EventArgs e)
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            Product product = productDataAccess.GetProductById(Convert.ToInt32(updateProductIdTextBox.Text));
            if (product == null)
            {
                MessageBox.Show("Product not found");
            }
            else
            {
                productDataAccess = new ProductDataAccess();
                int catId = productDataAccess.GetCategoryIdByName(updateCategoryComboBox.Text);
                productDataAccess = new ProductDataAccess();
                if (productDataAccess.UpdateProduct(Convert.ToInt32(updateProductIdTextBox.Text),updateProductNameTextBox.Text,Convert.ToDouble(updateProductPriceTextBox.Text),catId))
                {
                    MessageBox.Show("Product updated");
                    UpdateProductList();
                }
                else
                {
                    MessageBox.Show("Error in updating");
                }
            }
        }

        private void searchProductNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProductDataAccess productDataAccess = new ProductDataAccess();
            searchProductDataGridView.DataSource = productDataAccess.GetProductsByName(searchProductNameTextBox.Text);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
