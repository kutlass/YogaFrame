using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

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
                scriptLineSingle = scriptLineMulti.Replace(Environment.NewLine, "");                
            }
            catch (Exception ex)
            {
                Console.WriteLine("System.IO.File.ReadAllText() exception: {0}", ex.Message);
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
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
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
                Console.WriteLine("Executing query: {0}", sql);
                conn.Open();                
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
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
                Console.WriteLine("Executing query: {0}", sql);
                conn.Open();

                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
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
                Console.WriteLine("Executing query: {0}", sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
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
                Console.WriteLine("Executing query: {0}", sql);
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
