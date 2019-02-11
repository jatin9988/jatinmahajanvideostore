using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Movies
    {
        SqlConnection Main_con = new SqlConnection("Data Source=DESKTOP-QULTHGL\\SQLEXPRESS;Initial Catalog=VSR_System;Integrated Security=True");

        SqlCommand cmd_Main = new SqlCommand();

        SqlDataReader Reader_Main;

        String Main;
        String S2;

        public IEnumerable DefaultView { get; internal set; }

       


        public DataTable DisplayMovie()
        {
            DataTable dt = new DataTable();
            try 
            {
                cmd_Main.Connection = Main_con;
                Main = "Select * from Movies";

                cmd_Main.CommandText = Main;
                //connection   opened
                Main_con.Open();

                // get data stream
                Reader_Main = cmd_Main.ExecuteReader();

                if (Reader_Main.HasRows)
                {
                    dt.Load(Reader_Main);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Main != null)
                {
                    Reader_Main.Close();
                }

                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }

        }



        public void InsertVideos(string Rating, string Title, string Year, string Rental_Cost, string Plot, string Genre, int copies)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;



                Main = "Insert into Movies(Rating, Title, Year, Rental_Cost, Plot, Genre, copies) Values( @Rating, @Title, @Year, @Rental_Cost, @Plot, @Genre, @copies)";


                cmd_Main.Parameters.AddWithValue("@Rating", Rating);
                cmd_Main.Parameters.AddWithValue("@Title", Title);
                cmd_Main.Parameters.AddWithValue("@Year", Year);
                cmd_Main.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                cmd_Main.Parameters.AddWithValue("@Plot", Plot);
                cmd_Main.Parameters.AddWithValue("@Genre", Genre);
                cmd_Main.Parameters.AddWithValue("@copies", copies);

                cmd_Main.CommandText = Main;

                //connection opened
                Main_con.Open();

                // Executed query
                cmd_Main.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }

        public void RemoveVideo(int MovieID)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = this.Main_con ;


                //first of the all select the record from the Rented Movie is he already has a movie on rent or not if he has a movie on rent then he can't be able to delete the record from the table
                String check = "";
                check = "select Count(*) from RentedMovies where MovieIDFK= @MovieID and isout ='1' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                cmd_Main.Parameters.Add(parameterArray[0]);

                cmd_Main.CommandText = check;
                Main_con.Open();
                int count = Convert.ToInt32(cmd_Main.ExecuteScalar());
                if (count == 0)
                {
                    check = "Delete from Movies where MovieID like @MovieID";
                    cmd_Main.CommandText = check;
                    cmd_Main.ExecuteNonQuery();
                    MessageBox.Show("Movie Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented This movie");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Main_con != null)
                {
                    this.Main_con.Close();
                }

            }
        }

       

        public void UpdateVideo(int MoviedID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;
                Main = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MovieID like @MoviedID";


                cmd_Main.Parameters.AddWithValue("@MoviedID", MoviedID);
                cmd_Main.Parameters.AddWithValue("@Rating", Rating);
                cmd_Main.Parameters.AddWithValue("@Title", Title);
                cmd_Main.Parameters.AddWithValue("@Year", Year);
                cmd_Main.Parameters.AddWithValue("@Plot", Plot);
                cmd_Main.Parameters.AddWithValue("@Genre", Genre);
                cmd_Main.Parameters.AddWithValue("@copies", copies);


                cmd_Main.CommandText = Main;

                //connection opened
                Main_con.Open();

                // Executed query
                cmd_Main.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }

        public DataTable Displaycustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Main .Connection = Main_con;
                Main = "Select * from Coustmer";

                cmd_Main.CommandText = Main;
                //connection   opened
                Main_con.Open();

                // get data stream
                Reader_Main = cmd_Main.ExecuteReader();

                if (Reader_Main.HasRows)
                {
                    dt.Load(Reader_Main);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Main != null)
                {
                    Reader_Main.Close();
                }

                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }

        }



        public void InsertCoustomer(string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;



                Main = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";


                cmd_Main.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_Main.Parameters.AddWithValue("@LastName", LastName);
                cmd_Main.Parameters.AddWithValue("@Address", Address);
                cmd_Main.Parameters.AddWithValue("@Phone", Phone);

                cmd_Main.CommandText = Main;

                //connection opened
                Main_con.Open();

                // Executed query
                cmd_Main.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }

        public void RemoveCustomer(Int32 CustID)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = this.Main_con;


                String m = "";
                m = "select Count(*) from RentedMovies where CustIDFK= @CustID and isout ='1' ";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                cmd_Main.Parameters.Add(parameterArray[0]);

                cmd_Main.CommandText = m;
                Main_con.Open();
                int count = Convert.ToInt32(cmd_Main.ExecuteScalar());
                if (count == 0)
                {
                    m = "Delete from Coustmer where CustID like @CustID";
                    cmd_Main.CommandText = m;
                    cmd_Main.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    //display the message if he has a movie on rent 
                    MessageBox.Show("Customer has rented this movie");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Main_con != null)
                {
                    this.Main_con.Close();
                }
            }
        }



        public void CustomerUpdate(int CustID, string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;
                Main = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd_Main.Parameters.AddWithValue("@CustID", CustID);
                cmd_Main.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_Main .Parameters.AddWithValue("@LastName", LastName);
                cmd_Main .Parameters.AddWithValue("@Address", Address);
                cmd_Main.Parameters.AddWithValue("@Phone", Phone);

                cmd_Main.CommandText = Main;

                //connection opened
                Main_con.Open();

                // Executed query
                cmd_Main.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }
        public bool Login_check(string username, string password)
        {
            try
            {
                cmd_Main.Connection = Main_con;

                Main = "Select username, password from userdata where UserName =  @UserName  and Password =  @password ";


                cmd_Main.Parameters.AddWithValue("@UserName", username);
                cmd_Main.Parameters.AddWithValue("@password", password);

                cmd_Main.CommandText = Main;
                //connection opened
                Main_con.Open();

                // get data stream
                Reader_Main = cmd_Main.ExecuteReader();

                if (Reader_Main.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return false;
            }
            finally
            {
                // close reader
                if (Reader_Main != null)
                {
                    Reader_Main.Close();
                }

                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }
        public void Login_add(string username, string password)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;

                Main = "Insert into userdata (UserName, Password) Values(@user, @pass)";
                cmd_Main.Parameters.AddWithValue("@user", username);
                cmd_Main.Parameters.AddWithValue("@pass", password);

                cmd_Main.CommandText = Main;
                //connection opened
                Main_con.Open();

                // get data stream
                cmd_Main.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }
        public DataTable DisplayRented()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd_Main.Connection = Main_con;
                Main = "Select * from RentedMovies";

                cmd_Main.CommandText = Main;
                //connection   opened
                Main_con.Open();

                // get data stream
                Reader_Main = cmd_Main.ExecuteReader();

                if (Reader_Main.HasRows)
                {
                    dt.Load(Reader_Main);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                // close reader
                if (Reader_Main != null)
                {
                    Reader_Main.Close();
                }

                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }

        }



        public void InsertedRented(int MovieIDFK, int CustIDFK, DateTime DateRented, int copies, int isout)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;



                Main = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented, isout ) Values( @MovieIDFk, @CustIDFK, @DateRented, @isout)";

                cmd_Main.Parameters.AddWithValue("@MovieIDFK", MovieIDFK);
                cmd_Main.Parameters.AddWithValue("@CustIDFK", CustIDFK);
                cmd_Main.Parameters.AddWithValue("@DateRented", DateRented);
                cmd_Main.Parameters.AddWithValue("@copies", copies);
                cmd_Main.Parameters.AddWithValue("@isout", isout);



                cmd_Main.CommandText = Main;

                //connection opened
                Main_con.Open();

                // Executed query
                cmd_Main.ExecuteNonQuery();

                Main = "Update Movies set copies = copies-1 where MovieID = @MovieIDFK";
                cmd_Main.CommandText = Main;
                cmd_Main.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }
        }


        public void UpdateRented(int RMID, int MovieID, DateTime DateRent, DateTime DateReturned)
        {
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;
                int R = 0, Cost = 0;
                double days = (DateReturned - DateRent).TotalDays;

                string S1 = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                cmd_Main.Parameters.AddWithValue("@MovieIDFK", MovieID);

                cmd_Main.CommandText = S1;
                Main_con.Open();
                Cost = Convert.ToInt32(cmd_Main.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    R = Cost;
                }
                else
                {
                    R = Cost * Convert.ToInt32(days);
                }

                String S2 = "Update RentedMovies Set DateReturned='" + DateReturned + "' where RMID = @RMID";
                cmd_Main.Parameters.AddWithValue("@DateReturned", DateReturned);
                cmd_Main.Parameters.AddWithValue("@RMID", RMID);

                cmd_Main.CommandText = S2;

                cmd_Main.ExecuteNonQuery();


                S2 = "Update Movies set Copies = Copies+1 where MovieID = @MovieIDFK";
                cmd_Main.CommandText = S2;

                cmd_Main.ExecuteNonQuery();

                cmd_Main.CommandText = S2;

                cmd_Main.ExecuteNonQuery();

                MessageBox.Show("your total cost is " + R);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }


        }

        public void TopCusto()
        {
            int ID = 0, number = 0, Customer = 0;
            
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;
                string m = "Select IDENT_CURRENT('Coustmer')";

                cmd_Main.CommandText = m;
                Main_con.Open();
                Customer = Convert.ToInt32(cmd_Main.ExecuteScalar());

                for (int i = 1; i <= Customer; i++)
                {

                    m = "select Count(*) from RentedMovies where CustIDFK= '" + i + "'";


                    cmd_Main.CommandText = m;
                    int count = Convert.ToInt32(cmd_Main.ExecuteScalar());
                    if (count > number)
                    {
                        number = count;
                        ID = i;
                    }
                }
                this.S2 = "Select FirstName from Coustmer where CustID ='" + ID + "'";
                this.cmd_Main.CommandText = this.S2;
                String FirstName = Convert.ToString(cmd_Main.ExecuteScalar());
                MessageBox.Show(FirstName + " (CustID " + ID + " ) is maximum movie buyer with " + number + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }

        }

        // quries to show data for top videos
        public void Topvideo()
        {
            int ID = 0, number = 0, movies = 0;
            string ma = "";
            try
            {
                cmd_Main.Parameters.Clear();
                cmd_Main.Connection = Main_con;

                Main_con.Open();
                movies = Convert.ToInt32(cmd_Main.ExecuteScalar());

                for (int i = 1; i <= movies; i++)
                {

                    ma = "select Count(*) from RentedMovies where MovieIDFK= '" + i + "'";


                    cmd_Main.CommandText = ma;
                    int count = Convert.ToInt32(cmd_Main.ExecuteScalar());
                    if (count > number)
                    {
                        number = count;
                        ID = i;
                    }
                }


                this.S2 = "Select Title from Movies where MovieID ='" + ID + "'";
                this.cmd_Main.CommandText = this.S2;
                String Title = Convert.ToString(cmd_Main.ExecuteScalar());
                MessageBox.Show(Title + " (MovieID " + ID + " ) is maximum rented movie with " + number + " times");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Main_con != null)
                {
                    Main_con.Close();
                }
            }

        }
    }
}
