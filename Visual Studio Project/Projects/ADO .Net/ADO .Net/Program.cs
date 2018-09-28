using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO.Net
{
    class Program
    {
        SqlConnection newConnection()
        {
            SqlConnection con=null;
            try
            {
                string connstr = "Data Source=G1C2ML15646;Initial Catalog=Naveen;Integrated Security=True";
                con = new SqlConnection(connstr);
            }
            catch(SqlException)
            {
                Console.WriteLine("Couldn't establish connection with server!");
            }
            return con;
        }

        void retrieveData()
        {
            SqlConnection con=null;
            try
            {
                con = newConnection();
                con.Open();
            }
            catch(SqlException)
            {
                Console.WriteLine("Couldn't establish connection with server!");
            }

            try
            {
                if (con != null)
                {
                    string querystring = "Select * from tblStudent";

                    //Disconnected Architecture
                    Console.WriteLine("Using Disconnected Architecture\n\n");
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(querystring, con);
                        DataSet dsData = new DataSet();
                        sda.Fill(dsData, "tblStudent");
                        DataTable dt = dsData.Tables["tblStudent"];
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn col in dt.Columns)
                                Console.Write(row[col]+"\t");
                        }
                    }
                    catch(SqlException) { }

                    //Conected Architecture
                    Console.WriteLine("\n\nUsing Connected Architecture\n\n");
                    try
                 {
                     SqlCommand cmd = new SqlCommand(querystring, con);
                     SqlDataReader reader = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         Console.WriteLine(reader[0].ToString() + "\t" + reader[1].ToString() + "\t" + reader[2].ToString() + "\t" + reader[3].ToString());
                     }
                 }
                 catch (SqlException)
                 {
                     Console.WriteLine("Exception occurred");
                 }
                }
            }

            finally
            {
                con.Close();
            }

        }

        void storeData(int id, string name, int age, int tId)
        {
            SqlConnection con=null;
                try
                {
                    con = newConnection();
                    con.Open();
                }
                catch(SqlException)
                {
                Console.WriteLine();
            }

            try
            {
                if (con != null)
                {
                    String sql = "insert into tblStudent ([ID], [StudentName], [Age], [ClassTeacherId]) values(@id,@name,@age, @tId)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@tId", tId);
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine("{0}  Row inserted !! ", rows);
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Records did not stored!!");
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.storeData(2, "Raj", 15, 3);
            p.retrieveData();

            Console.ReadKey();
        }
    }
}
