using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreDb
{
    class Program
    {
        public string BookSP(string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@Title";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Value = title;
            //cmd.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter();
            //p2.ParameterName = "@AuthorID";
            //p2.SqlDbType = SqlDbType.Int;
            //p2.Value = aid;
            //cmd.Parameters.Add(p2);
            //SqlParameter p3 = new SqlParameter();
            //p3.ParameterName = "@Price";
            //p3.SqlDbType = SqlDbType.Money;
            //p3.Value = price;
            //cmd.Parameters.Add(p3);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string UpdateBookSP( int bid,string title, int aid, double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_UpdBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = bid;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public void GetallBooksSP()
        {

            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_Getall", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["BookID"] + " " + rdr["Title"] + " " + rdr["AuthorID"] + " " + rdr["Price"].ToString());
            con.Close();
            Console.ReadLine();
        }
        public string DeleteBookSP(int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_DeleteBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public void AllBooks()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("Select * from tbl_Books", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["BookID"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());
            con.Close();
            Console.ReadLine();

        }
        
        public void InsertBook()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('HarryPotter',7,950)", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into tbl_books values('revenge',1,650)";
            cmd.Connection = con;
            //string qry = "insert into tbl_Books values(@Title,@authorID,@Price)";
            //SqlCommand cmd = new SqlCommand(qry, con);
            //cmd.Parameters.AddWithValue("@Title", "Davinci Code");
            //cmd.Parameters.AddWithValue("@AuthorID", 7 );
            //cmd.Parameters.AddWithValue("@Price", 400);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server Error");
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateBook()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            // SqlCommand cmd = new SqlCommand("update tbl_books set Title='Girl in room no 105' where BookId=1009", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update tbl_books set Title='No mercy' where BookId=1008";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBook()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE From tbl_books where BookID=1008";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
         //Authors
        public void GetAuthors()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("select * from tbl_author", con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["AuthorID"] + " " + rdr["AuthorName"] .ToString());
            con.Close();
            Console.ReadLine();

        }
        public void InsertAuthor()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Books values('HarryPotter',7,950)", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into tbl_author values('dawn brown')";
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Server Error");
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateAuthor()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            // SqlCommand cmd = new SqlCommand("update tbl_books set Title='Girl in room no 105' where BookId=1009", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update  tbl_author set AuthorName='Napoleon hill' where AuthorID = 2";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAuthor()
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE From tbl_author where AuthorID=4";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string InsertAuthorSP(string name)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_Ins_Author", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = name;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public string UpdateAuthorSP(int bid,string name)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_UpdAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = bid;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = name;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public void GetallAuthorsSP()
        {

            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_Getall_authors", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["AuthorID"] + " " + rdr["AuthorName"].ToString());
            con.Close();
            Console.ReadLine();
        }
        public string DeleteAuthorSP(int bid)
        {
            string res = null;
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("sp_DeleteAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = bid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.AllBooks();
            //obj.InsertBook();
            //obj.UpdateBook();
            //obj.DeleteBook();

            //obj.BookSP("revenge", 1, 450);
            //obj.UpdateBookSP(1007, "Fears", 2, 555);
            //obj.DeleteBookSP(1008);
            //obj.GetallBooksSP();

            //obj.GetAuthors();
            //obj.InsertAuthor();
            //obj.UpdateAuthor();
            //obj.DeleteAuthor();

            //obj.InsertAuthorSP("James Lee burke");
            //obj.UpdateAuthorSP(5, "jk Rowling");
            obj.DeleteAuthorSP(5);
            obj.GetallAuthorsSP();

            //SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            //SqlCommand cmd = new SqlCommand("Select * from tbl_Books", con);

            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //    Console.WriteLine(rdr["BookID"] + " " + rdr["Title"] + " " + rdr["Price"].ToString());
            //con.Close();
            //Console.ReadLine();
        }
    }
}