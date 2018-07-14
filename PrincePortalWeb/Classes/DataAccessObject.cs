
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Sql;
using System;

namespace PrincePortalWeb
{

    public class DataAccessObject
    {
        private DataConnection conn;

        public DataAccessObject()
        {
            //construct here
            conn = new DataConnection();
        }

        public DataTable ValidateUser(string username, string password)
        {

            DataTable dt = new DataTable();

            string query = "select * from aspnetusers where username=@Username and password=@Password COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Username", username.Trim());
            sqlParameters[1] = new SqlParameter("@Password", password.Trim());
            return conn.executeSelectQuery(query, sqlParameters);


        }

        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string query = "select * from aspnetusers";      
            return conn.executeSelectQueryNoParam(query);
        }

        public DataTable GetAllUsersByWebStatus(string webstatus)
        {
            DataTable dt = new DataTable();
            string query = "select * from aspnetusers where webstatus=@Param";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Param", webstatus.Trim());

            return conn.executeSelectQuery(query,sqlParameters);
     

        }

        public DataTable GetAllUsersByWebStatusandSupplierID(string webstatus,int supplierid)
        {
            DataTable dt = new DataTable();
            string query = "select * from aspnetusers where webstatus=@Param and supplierid=@Param2";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Param", webstatus.Trim());
            sqlParameters[1] = new SqlParameter("@Param2", supplierid);

            return conn.executeSelectQuery(query, sqlParameters);


        }

        public DataTable GetSuppliers()
        {


            DataTable dt = new DataTable();

            string query = "select * from suppliers order by suppliername";


            return conn.executeSelectQueryNoParam(query);

        }
        public DataTable GetSupplierByID(int id)
        {


            DataTable dt = new DataTable();

            string query = "select * from suppliers where supplierid=@supplierid";


            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@supplierid", id);


            return conn.executeSelectQuery(query,sqlParameters);

        }

        public DataTable GetSuppliersWithFilter(string supplierName)
        {
          
            DataTable dt = new DataTable();

            string query = "select * from suppliers where suppliername LIKE @Param";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Param","%"+supplierName.Trim().ToUpper()+"%");


            return conn.executeSelectQuery(query,sqlParameters);



        }

        public DataTable GetSuppliersWithFilterByWebStatus(string webstatus)
        {

            DataTable dt = new DataTable();

            string query = "select * from suppliers where webstatus=@Paramstatus";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Paramstatus", webstatus.Trim());


            return conn.executeSelectQuery(query, sqlParameters);



        }



        public void UpdateUserWebSatus(string userID,string status)
        {


            string query = "update aspnetusers set webstatus=@Param where id=@Param2";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Param",status);
            sqlParameters[1] = new SqlParameter("@Param2", userID);
            ;

             conn.executeUpdateQuery(query, sqlParameters);



        }

        public void UpdateUserLastSeen(string userID)       {

            string query = "update aspnetusers set lastlogdatetime=@Param where id=@Param2";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Param", DateTime.Now);
            sqlParameters[1] = new SqlParameter("@Param2", userID);
            ;

            conn.executeUpdateQuery(query, sqlParameters);
        }


        public void UpdateSupplierrWebSatus(int supplierID, string status)
        {
            string query = "update suppliers set webstatus=@Param where supplierid=@Param2";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Param", status);
            sqlParameters[1] = new SqlParameter("@Param2", supplierID);           ;

            conn.executeUpdateQuery(query, sqlParameters);

        }
    }
}