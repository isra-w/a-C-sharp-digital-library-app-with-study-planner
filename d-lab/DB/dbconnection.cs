using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace d.labdemo.DB
{
    static class DBConnection
    {
        static string connectionString = @"Data Source=HP-ELITE;Initial Catalog=d_lab;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection checkConnection = new SqlConnection(connectionString);
        private static string query;
        private static object dbconnection;

        public static void intiate()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, connectionString);



                checkConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"unable to connect to database: \n{ex.Message}", "db error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static int ExecuteNonQuery(string query) //query add lemareg yemitekm keza how many raw affected yemilewn yeminager
        {
            SqlConnection queryConnection = new SqlConnection(connectionString);
            queryConnection.Open();

            SqlCommand cmd = new SqlCommand(query, queryConnection);
            queryConnection.Close();
            return cmd.ExecuteNonQuery();

        }

        public static object ExecuteScalar(string query)//yhe return yemiyadergew and value bicha nw lemsale no of employees
        {
            using (SqlConnection queryConnection = new SqlConnection(connectionString))
            {
                queryConnection.Open();

                SqlCommand cmd = new SqlCommand(query, queryConnection);


                return cmd.ExecuteScalar();

            }


        }

        public static DataTable ExecuteReader(string query) //yhe demo select all endemnelew aynet nw multiple raw return yadergal
        {
            SqlConnection queryConnection = new SqlConnection(connectionString);
            queryConnection.Open();

            SqlCommand cmd = new SqlCommand(query, queryConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            queryConnection.Close();

            return dt;

        }
    }
}
