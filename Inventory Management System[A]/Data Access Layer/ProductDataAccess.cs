﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_A_.Data_Access_Layer
{
    class ProductDataAccess:DataAccess
    {
        public List<Product> GetAllProducts()
        {
            string sql = "SELECT * FROM Products";
            List<Product> products = new List<Product>();
            SqlDataReader reader = this.GetData(sql);
            while(reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                products.Add(product);
            }
            return products;
        }

        public bool AddNewProduct(string productName,double price,int categoryId)
        {
            string sql = "INSERT INTO Products(ProductName,Price,CategoryId) VALUES('"+productName+"',"+price+","+categoryId+")";
            int result = this.ExecuteQuery(sql);
            if(result>0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteProduct(int productId)
        {
            string sql = "DELETE FROM Products WHERE ProductId="+productId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateProduct(int productId,string productName, double price, int categoryId)
        {
            string sql = "UPDATE Products SET ProductName='"+productName+"',Price="+price+",CategoryId="+categoryId+" WHERE ProductId="+productId;
            int result = this.ExecuteQuery(sql);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public List<string> GetAllCategoryNames()
        {
            string sql = "SELECT * FROM Categories";
            List<string> categoryNames = new List<string>();
            SqlDataReader reader = this.GetData(sql);
            while (reader.Read())
            {
                categoryNames.Add(reader["CategoryName"].ToString());
            }
            return categoryNames;
        }
        public int GetCategoryIdByName(string categoryName)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryName='"+categoryName+"'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return (int)reader["CategoryId"];
            }
            return -1;
        }

        public Product GetProductById(int productId)
        {
            string sql = "SELECT * FROM Products WHERE ProductID="+productId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                return product;
            }
            return null;
        }
        public List<Product> GetProductsByCateGoryId(int categoryId)
        {
            string sql = "SELECT * FROM Products WHERE CategoryId="+categoryId;
            List<Product> products = new List<Product>();
            SqlDataReader reader = this.GetData(sql);
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                products.Add(product);
            }
            return products;
        }

        public List<Product> GetProductsByName(string productName)
        {
            string sql = "SELECT * FROM Products WHERE ProductName LIKE '"+productName+"%'";
            List<Product> products = new List<Product>();
            SqlDataReader reader = this.GetData(sql);
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                products.Add(product);
            }
            return products;
        }
    }
}
