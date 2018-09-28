using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity;

namespace DataAccessLayer
{
    public class DataAccess
    {
        SqlConnection newConnection()
        {
            SqlConnection con = null;
            try
            {
                string connstr = "Data Source=G1C2ML15646;Initial Catalog=Naveen;Integrated Security=True";
                con = new SqlConnection(connstr);
            }
            catch (SqlException)
            {
                throw;
            }
            return con;
        }

      public void retrieveData()
        {
            SqlConnection con = null;
            try
            {
                con = newConnection();
                con.Open();
            }
            catch (SqlException)
            {
                Console.WriteLine("Couldn't establish connection with server!");
            }

            try
            {
                if (con != null)
                {
                    string querystring = "Select * from tblStudent";

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

       public int storeData(Dictionary<int, Student> s)
        {
            SqlConnection con = null;
            try
            {
                con = newConnection();
                con.Open();
            }
            catch (SqlException)
            {
                Console.WriteLine("Couldn't establish connection with server!");
            }
            int status = 0;
            try
            {
                if (con != null)
                {
                    foreach (var ch in s.Values)
                    {
                        String sql = "insert into tblStudent ([ID], [StudentName], [Age], [ClassTeacherId]) values(@id,@name,@age, @tId)";
                        SqlCommand cmd = new SqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("@id", ch.sID);
                        cmd.Parameters.AddWithValue("@name", ch.sName);
                        cmd.Parameters.AddWithValue("@age", ch.age);
                        cmd.Parameters.AddWithValue("@tId", ch.tID);
                        try
                        {
                            status = status + (cmd.ExecuteNonQuery());
                        }
                        catch (SqlException)
                        {
                            Console.WriteLine("Can't have duplicate student ID's");
                        }
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }
}
