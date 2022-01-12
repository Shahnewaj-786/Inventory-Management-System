﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_A_.Data_Access_Layer
{
    class DataAccess:IDisposable
    {
        protected SqlConnection connection;
        protected SqlCommand command;
        public DataAccess()
        {
            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["IMS[A]"].ConnectionString);
            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql,connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }

        //~DataAccess()
        //{
        //    this.connection.Close();
        //}
    }
}