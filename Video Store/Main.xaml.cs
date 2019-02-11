using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
        Movies Obj_Movies = new Movies();
        

        public int CustID;
        public int MoviedID;

        public Main()
        {
            InitializeComponent();
            dateissue.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        // Update quries
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = Firsttext.Text;
            string LastName = Lasttext.Text;
            string Address = Addresstext.Text;
            string Phones = Phonettext.Text;
            int CustID = Convert.ToInt32(Custid.Text);
            Obj_Movies.CustomerUpdate(  CustID , FirstName, LastName, Address, Phones);
            
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
            Firsttext.Text = "";
            Lasttext.Text = "";
            Phonettext.Text = "";
            Addresstext.Text = "";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //Add data qurie
            if (Firsttext.Text != "" && Lasttext.Text != "" && Addresstext.Text != "" && Phonettext.Text != "")
            {
                Obj_Movies .InsertCoustomer( Firsttext.Text, Lasttext.Text, Addresstext.Text, Phonettext.Text);
                Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
                Addresstext.Text = "";
                Phonettext.Text = "";
                Firsttext.Text = "";
                Lasttext.Text = "";
                

            }
        }
        // delete customer button quries
        private void DeletecustomerClick(object sender, RoutedEventArgs e)
        {
            
                Obj_Movies.RemoveCustomer(Convert.ToInt32(Custid.Text));
                Customer_data.ItemsSource = Obj_Movies .Displaycustomer().DefaultView;
                Firsttext.Text = "";
                Addresstext.Text = "";
                Lasttext.Text = "";
               
                Phonettext.Text = "";
            
        }
        // customer load from datagrid to text boxes
        private void Customer_load(object sender, RoutedEventArgs e)
        {
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }
   
        private void Select(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Customer_data.SelectedItems[0];
            Custid.Text = Convert.ToString(row["CustID"]);
            Firsttext.Text = Convert.ToString(row["FirstName"]);
            Lasttext.Text = Convert.ToString(row["Lastname"]);
            Addresstext.Text = Convert.ToString(row["Address"]);
            Phonettext.Text = Convert.ToString(row["Phone"]);

            Customer_data.ItemsSource = Obj_Movies .Displaycustomer() .DefaultView;
        }

        private void AddMovies_Click(object sender, RoutedEventArgs e)
        {
            
            if (Rating_text.Text != "" && Titletext.Text != "" && Yeartext.Text != "" &&  Plottext.Text != "" && Genretext.Text != "" && Copiestext.Text != "")
            {
                int Mov = Convert.ToInt32(Yeartext.Text);
                int copie = Convert.ToInt32(Copiestext.Text);
                string r;
                if (2018 - Mov > 5)
                {
                    r = "2";
                        
                }
                else
                {
                    r = "5";
                }

                Obj_Movies.InsertVideos(Rating_text.Text, Titletext.Text, Yeartext.Text, r, Plottext.Text, Genretext.Text, copie);
                Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
                Titletext.Text = ""; 
                Rating_text.Text = "";
                Plottext.Text = "";
                Yeartext.Text = "";
                Genretext.Text = "";
                Copiestext.Text = "";

            }
        }
        // update quries
        private void UpdateMovies(object sender, RoutedEventArgs e)
        {
            int MoviedID = Convert.ToInt32(Movieidtext.Text);
            int copies = Convert.ToInt32(Copiestext.Text);
            string Title = Titletext.Text;
            string Rating = Rating_text.Text;
            string Plot = Plottext.Text;
            string Genre = Genretext.Text;
            int Year = Convert.ToInt32(Yeartext.Text);
            Obj_Movies.UpdateVideo(MoviedID, Rating, Title, Year, Plot, Genre, copies);
            MessageBox.Show("Video Updated");
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Titletext.Text = "";
            Rating_text.Text = "";
            Plottext.Text = "";
            Yeartext.Text = "";
            Genretext.Text = "";
            Copiestext.Text = "";
        }
        // delete movies quries
        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            



                Obj_Movies .RemoveVideo(Convert.ToInt32(Movieidtext.Text));
                Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
                Titletext.Text = "";
                Rating_text.Text = "";
                Plottext.Text = "";
                Yeartext.Text = "";
                Genretext.Text = "";
                Movieidtext.Text = "";


            
            


        }
        // video load from data grid to textboxes
        private void Videoloaded(object sender, RoutedEventArgs e)
        {
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }
        private void Issue_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Copiestext.Text != "0")

            {
                if (Movieidtext.Text != "" && Custid.Text != "" && dateissue.Text != "")
                {
                   


                    Obj_Movies.InsertedRented(Convert.ToInt32(Movieidtext.Text), Convert.ToInt32(Custid.Text), DateTime.Now, Convert.ToInt32(Copiestext.Text),1);
                    Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
                    Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
                    Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
                    Movieidtext.Text = "";
                    Custid.Text = "";
                    Yeartext.Text = "";
                    Rating_text.Text = "";
                    Movieidtext.Text = "";
                    Copiestext.Text = "";
                    Firsttext.Text = "";
                    Titletext.Text = "";
                    Plottext.Text = "";
                    Genretext.Text = "";

                    Lasttext.Text = "";
                    Addresstext.Text = "";
                    Phonettext.Text = "";

                }

            }
            else
            {
                MessageBox.Show("All Copies Are Out Rented");
            }

        }


        private void SelectMovie(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Video_data.SelectedItems[0];
            Titletext.Text = Convert.ToString(row["Title"]);
            Plottext.Text = Convert.ToString(row["Plot"]);
            Genretext.Text = Convert.ToString(row["Genre"]);
            Yeartext.Text = Convert.ToString(row["Year"]);
            Rating_text.Text = Convert.ToString(row["Rating"]);
            Movieidtext.Text = Convert.ToString(row["MovieID"]);
            Copiestext.Text = Convert.ToString(row["copies"]);

            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }

        private void TabControl_SelectionChanged()
        {

        }

        private void Movieid_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Movieid_txt_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ReturnedClick(object sender, RoutedEventArgs e)
        {
           

            // update quries
            Obj_Movies .UpdateRented(Convert.ToInt32(Rmidtext.Text), Convert.ToInt32(Movieidtext.Text), Convert.ToDateTime(dateissue.Text), DateTime.Now);

            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Customer_data.ItemsSource = Obj_Movies .Displaycustomer().DefaultView;
            Movieidtext.Text = "";
            Custid.Text = "";
            Titletext.Text = "";
            Plottext.Text = "";
            Genretext.Text = "";
            Yeartext.Text = "";
            Rating_text.Text = "";
            Movieidtext.Text = "";
            Copiestext.Text = "";
            Firsttext.Text = "";
            Lasttext.Text = "";
            Addresstext.Text = "";
            Phonettext.Text = "";


        }

        private void Video_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Customer_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        private void Rental_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // rented videos load
        private void Rented(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Rental_data.SelectedItems[0];
            Movieidtext.Text = Convert.ToString(row["MovieIDFK"]);
            Custid.Text = Convert.ToString(row["CustIDFK"]);
            Rmidtext.Text = Convert.ToString(row["RMID"]);
            dateissue.Text = Convert.ToString(row["DateRented"]);
            dateretuned.Text = DateTime.Now.ToString("dd-MM-yyyy");



            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }
        private void Topcust_btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_Movies.TopCusto();
        }

        private void Topmovie_Click(object sender, RoutedEventArgs e)
        {
            Obj_Movies.Topvideo();
        }
        private void video_load(object sender, RoutedEventArgs e)
        {
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }

        private void rented(object sender, RoutedEventArgs e)
        {
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
        }
        // return quries
        private void Return_Click(object sender, RoutedEventArgs e)
        {

            dateretuned.Text = DateTime.Today.ToString("dd-MM-yyyy");



            Obj_Movies .UpdateRented(Convert.ToInt32(Rmidtext.Text), Convert.ToInt32(Movieidtext.Text), Convert.ToDateTime(dateissue.Text), DateTime.Now);

        
            Video_data.ItemsSource = Obj_Movies.DisplayMovie().DefaultView;
            Rental_data.ItemsSource = Obj_Movies.DisplayRented().DefaultView;
            Customer_data.ItemsSource = Obj_Movies.Displaycustomer().DefaultView;
            Movieidtext.Text = "";
            Custid.Text = "";
            Genretext.Text = "";
            Yeartext.Text = "";
            Rating_text.Text = "";
            Movieidtext.Text = "";
            Copiestext.Text = "";
            Firsttext.Text = "";
            Titletext.Text = "";
            Plottext.Text = "";
            
            Lasttext.Text = "";
            Addresstext.Text = "";
            Phonettext.Text = "";


        }

        
    }
}
