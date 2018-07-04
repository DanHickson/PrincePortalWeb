
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System;

namespace PrincePortalWeb
{

    public class DataConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;
         
         
                    
        ///<constructor>
        /// Initialise connection on use
        /// </constructor>
        public DataConnection()
        {
            myAdapter = new SqlDataAdapter();
          
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        }

        ///<method>
        ///Open connection if closed or broken
        /// </method>
        private SqlConnection openConnection()
        {
            if(conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;


        }



        ///<method>
        ///Select query parameters like
        ///</method>
        public DataTable executeSelectQueryLike(string _query, SqlParameter[] _Parameters,SqlCommand sqlCommand)
        {

            if (_Parameters.Count() == 0)
            {
                throw new ArgumentException("Parameters cannot be empty");
            }

            var myCommand = sqlCommand;
            DataTable dt = new DataTable();
            dt = null;
            DataSet ds = new DataSet();

            myCommand.Connection = openConnection();
            myCommand.CommandText = _query;

            myCommand.Parameters.AddRange(_Parameters);

            myAdapter.SelectCommand = myCommand;
            myCommand.ExecuteNonQuery();
            myAdapter.Fill(ds);
            dt = ds.Tables[0];


            conn.Close();


            return dt;

        }

        ///<method>
        ///Select query parameters
        ///</method>
        public DataTable executeSelectQuery(string _query, SqlParameter[] _Parameters)
        {

            if (_Parameters.Count() == 0)
            {
                throw new ArgumentException("Parameters cannot be empty");
            }

            SqlCommand myCommand = new SqlCommand();
            DataTable dt = new DataTable();
            dt = null;
            DataSet ds = new DataSet();
            
                myCommand.Connection=openConnection();
                myCommand.CommandText=_query;
                
                myCommand.Parameters.AddRange(_Parameters);

                myAdapter.SelectCommand = myCommand;
                myCommand.ExecuteNonQuery();
                myAdapter.Fill(ds);
                dt = ds.Tables[0];

         
                conn.Close();
            

            return dt;
            
        }

        ///<method>
        ///Select query
        ///</method>
        public DataTable executeSelectQueryNoParam(string _query)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dt = new DataTable();
            dt = null;
            DataSet ds = new DataSet();
         
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myAdapter.SelectCommand = myCommand;
                myCommand.ExecuteNonQuery();
                myAdapter.Fill(ds);
                dt = ds.Tables[0];

    

              
            

           
           
                conn.Close();
            

            return dt;

        }


        public DataTable executeSelectQueryCollection(string _query, List<SqlParameter> parameters)
        {

            if (parameters.Count() == 0)
            {
                throw new ArgumentException("Parameters cannot be empty");
            }
            SqlCommand myCommand = new SqlCommand();
            DataTable dt = new DataTable();
            dt = null;
            DataSet ds = new DataSet();
           
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;

                foreach (SqlParameter ole in parameters)
                {

                    myCommand.Parameters.Add(ole);
                }
               

                myAdapter.SelectCommand = myCommand;
                myCommand.ExecuteNonQuery();
                myAdapter.Fill(ds);
                dt = ds.Tables[0];


                conn.Close();
            

            return dt;

        }


        ///<method>
        ///insert query
        ///</method>
        public bool executeInsertQuery(string _query, SqlParameter[] _Parameters)
        {

            if (_Parameters.Count() == 0)
            {
                throw new ArgumentException("Parameters cannot be empty");
            }
            SqlCommand myCommand = new SqlCommand();
          
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(_Parameters);
                
                myAdapter.InsertCommand = myCommand;

                myCommand.ExecuteNonQuery();
            
         

     
        
                conn.Close();
            

            return true;

        }


        ///<method>
        ///Update query
        ///</method>
        public bool executeUpdateQuery(string _query, SqlParameter[] _Parameters)
        {

            if (_Parameters.Count() == 0)
            {
                throw new ArgumentException("Parameters cannot be empty");
            }
           
            
            SqlCommand myCommand = new SqlCommand();
          
       
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(_Parameters);

                myAdapter.UpdateCommand = myCommand;

                myCommand.ExecuteNonQuery();
       

                conn.Close();
            

            return true;
            
        }

       

        


        }





    
}