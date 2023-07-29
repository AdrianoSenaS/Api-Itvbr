using System;
using Firebase.Database;
using System.Data.SqlClient;
using System.Data;

namespace Api_Itvbr.Model
{
	public class Db
	{

        public static SqlConnection sql = new SqlConnection("Server=192.168.15.40;Database=itvbr;User Id=SA;Password=Ad2021@i@;");

        public static DataTable GetData(string table)
        {
            sql.Open();
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM {table}";
            SqlCommand command = new SqlCommand(query, sql);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            sql.Close();
            return dt;   
        }



        public static DataTable GetDataId(string table, int id)
        {
            sql.Open();
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM {table} WHERE ID = {id}";
            SqlCommand command = new SqlCommand(query, sql);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            sql.Close();
            return dt;
        }


        public static bool InsertData(string table, string coluns, string values)
		{
             sql.Open();
            string query = $"INSERT INTO {table} ({coluns}) VALUES ({values})";
            SqlCommand command = new SqlCommand(query, sql);
            var result =  command.ExecuteReader();
             sql.Close();
            if (result != null)
            {
                return true;
            }
            return false;

        }

        public static bool UpdateDataId(string table,  string values, int id)
        {
            sql.Open();
            string query = $"UPDATE {table} SET {values} WHERE id={id};";
            SqlCommand command = new SqlCommand(query, sql);
            var result = command.ExecuteReader();
            sql.Close();
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteDataId(string table,int id)
        {
            sql.Open();
            string query = $"DELETE FROM {table} WHERE ID ={id}";
            SqlCommand command = new SqlCommand(query, sql);
            var result = command.ExecuteReader();
            sql.Close();
            if (result!= null)
            {
                return true;
            }
            return false;
        }    
		
	}


}

