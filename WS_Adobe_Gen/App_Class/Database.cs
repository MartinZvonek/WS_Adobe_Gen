using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WS_Adobe_Gen.App_Class
{
    public class Database
    {
        //NB
        //public static string cnData = "Data Source=127.0.0.1;Initial Catalog=etr_vyvoj_data;MultipleActiveResultSets=true;User ID=sa;Password=cd66";
        //public static string cnSoubory = "Data Source=127.0.0.1;Initial Catalog=etr_vyvoj_soubory;MultipleActiveResultSets=true;User ID=sa;Password=cd66";

        //Prace
        //public static string cnData = "Data Source=x00-etrsql-dev.pcrtest.cz\\ETRDEV;Initial Catalog=etr_vyvoj_data;MultipleActiveResultSets=true;User ID=etr_vyvoj;Password=Cr4ys+een";
        //public static string cnSoubory = "Data Source=x00-etrsql-dev.pcrtest.cz\\ETRDEV;Initial Catalog=etr_vyvoj_soubory;MultipleActiveResultSets=true;User ID=etr_vyvoj;Password=Cr4ys+een";


        //ostre
        public static string cnData = System.Configuration.ConfigurationManager.ConnectionStrings["cnETR_data"].ConnectionString + ";MultipleActiveResultSets=true";
        public static string cnSoubory = System.Configuration.ConfigurationManager.ConnectionStrings["cnETR_soubory"].ConnectionString + ";MultipleActiveResultSets=true";

        public static string strSQL = "";
        public static string out_str = "";
        public static string out_int = "";

        internal static string test_db(string connstring)
        {
            string vysledek = "";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                conn.Open();
                vysledek = conn.Database;
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }

            finally
            {
                conn.Close();
            }

            return vysledek;
        }

        internal static string getSetting(string varname)
        {
            out_str = "";

            strSQL = "";
            strSQL = "SELECT top 1 (varvalue) FROM settings WHERE varname = @varname;";

            SqlConnection conn = new SqlConnection(cnData);
            SqlCommand command = new SqlCommand(strSQL, conn);

            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@varname", varname);

            try
            {
                conn.Open();
                out_str = Convert.ToString(command.ExecuteScalar());
            }

            catch (Exception EX)
            {
                throw (EX);
            }

            finally
            {
                conn.Close();
            }

            return out_str;
        }

        internal static WS602Info getWS602Info()
        {
            WS602Info info = new WS602Info();

            strSQL = "";
            strSQL = "SELECT varvalue,varname FROM settings WHERE varname in ('WS_602LTD','WS_602LTD_User','WS_602LTD_Pass','GIBS_cert_pecet');";

            SqlConnection conn = new SqlConnection(cnData);
            SqlCommand command = new SqlCommand(strSQL, conn);

            command.CommandType = CommandType.Text;
            //command.Parameters.AddWithValue("@varname", "'WS_602LTD','WS_602LTD_User','WS_602LTD_Pass','GIBS_cert_pecet'");

            try
            {
                conn.Open();
                SqlDataReader DataReader = command.ExecuteReader();

                while (DataReader.Read())
                {
                    if (DataReader["varname"].ToString() == "WS_602LTD")
                    {
                        info.URL = DataReader["varvalue"].ToString();
                    }

                    if (DataReader["varname"].ToString() == "WS_602LTD_User")
                    {
                        info.User = DataReader["varvalue"].ToString();
                    }

                    if (DataReader["varname"].ToString() == "WS_602LTD_Pass")
                    {
                        info.Pass = DataReader["varvalue"].ToString();
                    }

                    if (DataReader["varname"].ToString() == "GIBS_cert_pecet")
                    {
                        info.Certifikat = DataReader["varvalue"].ToString();
                    }
                }
            }

            catch (Exception EX)
            {
                throw (EX);
            }

            finally
            {
                conn.Close();
            }

            return info;
        }

    }
}