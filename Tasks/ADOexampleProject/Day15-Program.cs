using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOexampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"Server = DESKTOP-8DSBI98\SQLEXPRESS;Integrated security= true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }

        //void FetchAuthorsFromDatabase()
        //{
        //    string strCmd = " select * from authors";
        //    cmd = new SqlCommand(strCmd, con);
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader drAuthors = cmd.ExecuteReader();
        //        while (drAuthors.Read())
        //        {
        //            Console.WriteLine("Author Id :" + drAuthors[0]);
        //            Console.WriteLine("Author First Name :" + drAuthors[1]);
        //            Console.WriteLine("Author Last Name:" + drAuthors[2]);
        //            Console.WriteLine("Author Phone:" + drAuthors[3]);
        //            Console.WriteLine("-------------------------------");

        //}

        //}
        void FetchmoviesFromDatabase()
        {
            string strCmd = " select * from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MovieId:" + drMovies[0].ToString());
                    Console.WriteLine("Moviename:" + drMovies[1]);
                    Console.WriteLine("Duration:" + drMovies[2].ToString());

                    Console.WriteLine("-------------------------------");

                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void FetchOnemovieFromDatabase()
        {
            string strCmd = " select * from tblMovie where movie_id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("please enter the movie id to select");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MovieId:" + drMovies[0].ToString());
                    Console.WriteLine("Moviename:" + drMovies[1]);
                    Console.WriteLine("Duration:" + drMovies[2].ToString());

                    Console.WriteLine("-------------------------------");

                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void AddMovie()
        {
            Console.WriteLine("please enter the movie name");
            String mname = Console.ReadLine();
            Console.WriteLine("please enter the movie duration");
            float mduration = (float)Math.Round(float.Parse(Console.ReadLine()));
            string strCmd = "insert into tblMovie(movie_name,movie_duration) values(@mname,@mdura)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mname);
            cmd.Parameters.AddWithValue("@mdura", mduration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("movie inserted");
                else
                    Console.WriteLine("no no ");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

        }
        void UpdateMoviebyChoice()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("1. Update movie name");
                Console.WriteLine("2. update movie duration");
                Console.WriteLine("3. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("please enter the movie id ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the movie name for updation");
                        String mname = Console.ReadLine();
                        string strCmd = "Update tblMovie set movie_name = @mname where movie_id =@mid";
                        cmd = new SqlCommand(strCmd, con);
                        cmd.Parameters.AddWithValue("@mid", id);
                        cmd.Parameters.AddWithValue("@mname", mname);
                        try
                        {
                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                                Console.WriteLine("movie updated");
                            else
                                Console.WriteLine("no no ");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;

                    case 2:
                        Console.WriteLine("please enter the movie id");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("please enter the movie duration for updation");
                        float mduration = (float)Math.Round(float.Parse(Console.ReadLine()));
                        string strCmmd = "Update tblMovie set movie_duration = @mdura where movie_id =@mid";
                        cmd = new SqlCommand(strCmmd, con);
                        cmd.Parameters.AddWithValue("@mid", id2);
                        cmd.Parameters.AddWithValue("@mdura", mduration);
                        try
                        {
                            con.Open();
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                                Console.WriteLine("movie updated");
                            else
                                Console.WriteLine("no no ");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 3);


        }

        void DeleteMovie()
        {
            Console.WriteLine("please enter the movie id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("please enter the movie duration");
            //float mduration = (float)Math.Round(float.Parse(Console.ReadLine()));
            string strCmd = "DELETE From tblMovie where movie_id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("movie deleted");
                else
                    Console.WriteLine("no no ");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

        }
        void SortMovies()
        {
            string strCmd = " select * from tblMovie ORDER BY movie_name";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("MovieId:" + drMovies[0].ToString());
                    Console.WriteLine("Moviename:" + drMovies[1]);
                    Console.WriteLine("Duration:" + drMovies[2].ToString());

                    Console.WriteLine("-------------------------------");

                }

            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {

                Console.WriteLine("1. Printall the movies");
                Console.WriteLine("2. Print selected movies");
                Console.WriteLine("3  Add a movie");
                Console.WriteLine("4  Update movie");
                Console.WriteLine("5. Delete movie");
                Console.WriteLine("6. Sort movies");
                Console.WriteLine("7. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        FetchmoviesFromDatabase();
                        break;

                    case 2:
                        FetchOnemovieFromDatabase();
                        break;
                    case 3:
                        AddMovie();
                        break;
                    case 4:
                        UpdateMoviebyChoice();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    case 6:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 7);
            
        }
  

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program pr = new Program();
            //pr.AddMovie();
            //pr.FetchmoviesFromDatabase();
            //pr.FetchOnemoviesFromDatabase();
            //pr.UpdateMovie();
            pr.PrintMenu();
            Console.ReadKey();
        }
    }
}
