using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace YogaFrameDeploy
{
    public class Deployment
    {
        //
        // GenerateQueryString - Takes MySQL <script>.txt 
        //
        public static string GenerateQueryString(string sourceTextFile)
        {
            string scriptLineSingle = null;
            try
            {
                string scriptLineMulti = System.IO.File.ReadAllText(sourceTextFile);
                scriptLineSingle = scriptLineMulti.Replace(Environment.NewLine, " ");                
            }
            catch (Exception ex)
            {
                Trace.WriteLine("System.IO.File.ReadAllText() exception: " + ex.Message);
            }

            return scriptLineSingle;
        }

        public static string LocalGetConnectionString()
        {
            return Properties.Settings.Default.ConnectionString;
        }

        public static void LocalSetConnectionString(string connectionString)
        {
            Properties.Settings.Default.ConnectionString = connectionString;
            Properties.Settings.Default.Save();
        }

        public void DatabaseConnect()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                Trace.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            conn.Close();
            Trace.WriteLine("Done.");
        }

        public void DatabaseCommand()
        {
            //
            // PLACEHOLDER TUTORIAL CODE - Constructing a MySQL command
            //        
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = "SELECT * FROM tbl_Characters";
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();                
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Trace.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }
        
        public static void DatabaseDeploy()
        {
            
        }

        public static void DatabaseBackup()
        {

        }
        
        public static void DatabaseRestore()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = "INSERT INTO tbl_Characters (colName, colDescription) VALUES ('Blanka', 'Shocker')";
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();

                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }        

        //
        // tbl_Games_drop.txt
        //
        public static void DatabaseRestore1()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_drop.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }
        
        //
        // tbl_Games_create.txt
        //
        public static void DatabaseRestore2()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);            
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\tbl_Games_create.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // procedure_GetCharacters_drop.txt
        //
        public static void procedure_GetCharacters_drop()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_drop.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // procedure_GetCharacters_create.txt
        //
        public static void procedure_GetCharacters_create()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = Deployment.GenerateQueryString(@".\Scripts.MySQL\procedure_GetCharacters_create.txt");
                Trace.WriteLine("Executing query: " + sql);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }

        //
        // Call GetCharacters stored procedure
        //
        public static void procedure_GetCharacters_call()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetCharacters";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    Trace.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            conn.Close();
            Trace.WriteLine("Done.");
        }
        
        //
        // Upload GetCharacters.php to web host via ftp
        //
        public static void FtpUploadFile()
        {
            //
            // Grab ftp connection info from local settings file
            //
            string ftpUri = Properties.Settings.Default.FtpUri;
            string ftpUserName = Properties.Settings.Default.FtpUserName;
            string ftpPassword = Properties.Settings.Default.FtpPassword;

            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri + @"/" + "//public_html//YogaFrame//GetCharacters.php");

                request.Method = WebRequestMethods.Ftp.UploadFile;

                // fpt user credentials
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

                // Copy the contents of the file to the request stream.
                StreamReader sourceStream = new StreamReader(".\\Scripts.PHP\\home3.yogafram\\public_html\\YogaFrame\\GetCharacters.php");
                byte[] fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Trace.WriteLine("Upload File Complete, status " + response.StatusDescription);

                response.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("FTP code stuff failed: " + ex.Message);
            }
            
        }
    }
}
