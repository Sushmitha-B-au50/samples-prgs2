using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithADO.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("select BookID,Title,AuthorID,Price from tbl_Books", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewBook(string Title, int aid, Double Price)
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@AuthorID", aid);
            cmd.Parameters.AddWithValue("@Price", Price);
            return cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable DisplayAuthor()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            SqlCommand cmd = new SqlCommand("select AuthorID,AuthorName from tbl_author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewAuthor(string name)
        {
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = Books");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Ins_Author", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", name);
            return cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}
