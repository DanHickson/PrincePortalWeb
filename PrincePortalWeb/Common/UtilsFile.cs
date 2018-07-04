using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;

namespace PrincePortalWeb.Common
{
    public class UtilsFile
    {
        public static string GetTextFromFile(string fullPath)
        {
            //check file exists
            if (!File.Exists(fullPath))
            {
                throw new Exception(string.Format("The file '{0}' could not be found.", fullPath));
            }

            StreamReader sr = File.OpenText(fullPath);
            string s = sr.ReadToEnd();

            sr.Close();

            return s;
        }

        public static string RemoveDuplicatedDirSlashes(string s)
        {
            s = s.Replace(@"\\", @"\");
            s = s.Replace(@"//", @"/");

            return s;
        }

        public static string ConvertPathToWindowsFileFormat(string path)
        {
            return path.Replace('/', '\\');
        }

        public static string ConvertPathToURLFileFormat(string path)
        {
            return path.Replace('\\', '/');
        }

        public static bool IsFileType(string MIMEType)
        {
            bool isAllowedType = false;

            string[] allowedTypesArray = new string[2];

            allowedTypesArray[0] = "application/zip";
            allowedTypesArray[1] = "application/x-zip-compressed";
     
            for (int i = 0; i < allowedTypesArray.Length; i++)
            {
                if (MIMEType == allowedTypesArray[i])
                {
                    isAllowedType = true;
                    break;
                }
            }
            return isAllowedType;
        }

        public static string Upload(FileUpload uploadedFile, string savePath)
        {
            string filename = null;

            if (uploadedFile.PostedFile != null)
            {
                HttpPostedFile myfile = uploadedFile.PostedFile;
                int filelen = myfile.ContentLength;
                if (filelen == 0)
                {
                    filename = "No file was uploaded";
                    return filename;
                }

                byte[] myData = new Byte[filelen];
                myfile.InputStream.Read(myData, 0, filelen);

                string sFilename = Path.GetFileName(myfile.FileName);
                string sFileExtention = Path.GetExtension(myfile.FileName);
                int file_append = 0;

                while (File.Exists(HttpContext.Current.Server.MapPath(savePath + sFilename)))
                {
                    file_append++;
                    sFilename = Path.GetFileNameWithoutExtension(myfile.FileName) + file_append + sFileExtention;
                }

                try
                {
                    FileStream newFile = new FileStream(HttpContext.Current.Server.MapPath(savePath + sFilename), FileMode.Create);
                    newFile.Write(myData, 0, myData.Length);
                    newFile.Close();

                    filename = savePath + sFilename;
                }
                catch
                {

                }
            }

            return filename;
        }

        public static DataSet LoadCVS(string dir, string fileName)
        {
            DataSet ds = new DataSet();
            try
            {
                // Creates and opens an ODBC connection  
                string strConnString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + dir.Trim() + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";

                OdbcConnection conn = new OdbcConnection(strConnString.Trim());
                conn.Open();

                string sql_select = "select * from [" + fileName.Trim() + "]";

                //Creates the data adapter  
                OdbcDataAdapter obj_oledb_da = new OdbcDataAdapter(sql_select, conn);

                //Fills dataset with the records from CSV file  
                obj_oledb_da.Fill(ds, "csv");

                //closes the connection  
                conn.Close();
            }
            catch (Exception ex) //Error  
            {
                throw new Exception("An error occured: " + ex.ToString());
            }

            return ds;

        }


        public static void WriteFile(string path, string filename, byte[] byteArray, bool makeDirHidden)
        {
            FileStream fileStream = null;

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    if (makeDirHidden)
                    {
                        File.SetAttributes(path, FileAttributes.Hidden);
                    }
                }

                FileIOPermission filePerm = new FileIOPermission(FileIOPermissionAccess.AllAccess, path);
                filePerm.Assert();

                fileStream = new FileStream(path + "\\" + filename, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(byteArray, 0, byteArray.Length);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        public static DataTable ConvertCSVToDataTable(string filePathAndName)
        {
            DataTable csvDataTable = new DataTable();

            string[] csvData = File.ReadAllLines(filePathAndName);

            if (csvData.Length == 0)
            {
                throw new Exception("CSV File Appears to be Empty");
            }

            string[] headings = csvData[0].Split(',');
            foreach (var heading in headings)
            {
                csvDataTable.Columns.Add(heading, typeof(string));
            }

            //populate the DataTable
            for (var i = 1; i < csvData.Length; i++)
            {
                //create new rows
                DataRow row = csvDataTable.NewRow();
                
                for (int j = 0; j < headings.Length; j++)
                {
                    string str = csvData[i].Split(',')[j];
                    str = str.Replace("\"", "");

                    row[j] = str;
                }

                //add rows to over DataTable
                csvDataTable.Rows.Add(row);
            }

            return csvDataTable;
        }

        public static DataTable ConvertCSVToDataTable(string[] csvData)
        {
            DataTable csvDataTable = new DataTable();

            if (csvData.Length == 0)
            {
                throw new Exception("CSV File Appears to be Empty");
            }

            string[] headings = csvData[0].Split(',');
            foreach (var heading in headings)
            {
                csvDataTable.Columns.Add(heading, typeof(string));
            }

            //populate the DataTable
            for (var i = 1; i < csvData.Length; i++)
            {
                //create new rows
                DataRow row = csvDataTable.NewRow();

                for (int j = 0; j < headings.Length; j++)
                {
                    string str = csvData[i].Split(',')[j];
                    str = str.Replace("\"", "");

                    row[j] = str;
                }

                //add rows to over DataTable
                csvDataTable.Rows.Add(row);
            }

            return csvDataTable;
        }

        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
