using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace YogaFrameDeploy
{
    public class Deployment
    {        
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

        public static void DatabaseRestore1()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                string sql = "DROP TABLE IF EXISTS `yogafram_yogaframe`.`tbl_Games`;";
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

        public static void DatabaseRestore2()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);            
            try
            {
                string sql = "CREATE TABLE `tbl_Games` (`idtbl_Games` int(11) NOT NULL,  `colName` varchar(45) DEFAULT NULL,  `colDeveloper` varchar(45) DEFAULT NULL,  `colDeveloperURL` varchar(45) DEFAULT NULL,  `colPublisher` varchar(45) DEFAULT NULL,  `colPublisherURL` varchar(45) DEFAULT NULL,  `colDescription` varchar(45) DEFAULT NULL,  PRIMARY KEY (`idtbl_Games`)) ENGINE=MyISAM DEFAULT CHARSET=latin1;";
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
