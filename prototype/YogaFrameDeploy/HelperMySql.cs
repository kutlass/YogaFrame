using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace YogaFrameDeploy
{
    class HelperMySql
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

        #region DatabaseConnect method
        public void DatabaseConnect()
        {
            string connectionString = LocalGetConnectionString();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                Trace.WriteLine("DatabaseConnect: Connecting to MySQL. MySqlConnection()...");
                conn.Open();

                //
                // Perform database operations
                //
                Trace.WriteLine("DatabaseConnect: MySqlConnection() succeeded.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            conn.Close();
            Trace.WriteLine("Done.");
        }
        #endregion

        public static void ExecuteQuery(string strMySqlConnection, string strMySqlCommand)
        {
            Trace.WriteLine("ExecuteQuery: Query string to execute = " + strMySqlCommand);
            MySqlConnection mySqlConnection = new MySqlConnection(strMySqlConnection);
            try
            {
                Trace.WriteLine("ExecuteQuery: Calling mySqlConnection.Open()...");
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = new MySqlCommand(strMySqlConnection, mySqlConnection);
                Trace.WriteLine("ExecuteQuery: Calling mySqlCommand.ExecuteReader()...");
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Trace.WriteLine("ExecuteQuery: " + mySqlDataReader[0] + " -- " + mySqlDataReader[1] + " -- " + mySqlDataReader[2]);
                }
                mySqlDataReader.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            mySqlConnection.Close();
            Trace.WriteLine("ExecuteQuery: Done.");
        }

        public static void ExecuteNonQuery(string strMySqlConnection, string strMySqlCommand)
        {
            Trace.WriteLine("ExecuteNonQuery: Nonquery string to execute = " + strMySqlCommand);
            MySqlConnection mySqlConnection = new MySqlConnection(strMySqlConnection);
            try
            {
                Trace.WriteLine("ExecuteNonQuery: Calling mySqlConnection.Open()...");
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = new MySqlCommand(strMySqlCommand, mySqlConnection);
                Trace.WriteLine("ExecuteNonQuery: Calling mySqlCommand.ExecuteNonQuery()...");
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            mySqlConnection.Close();
            Trace.WriteLine("ExecuteNonQuery: Done.");
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
                //cmd.CommandType = CommandType.StoredProcedure;

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
    }
}
