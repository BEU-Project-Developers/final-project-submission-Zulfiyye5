using MyProject.Models;
using MyProject.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for AddReviewPage.xaml
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        Movie Movie { get; set; }
   
        private readonly MovieManager _movieManager;
        public AddReviewWindow(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
            _movieManager = new MovieManager();
            DataContext = new MoviesDetailViewModel(movie, _movieManager);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _movieManager.AddReview(Movie.dbId,UserManager.Instance.UserId,ReviewTextBox.Text);
            this.Close();
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            ReviewTextBox.Text = string.Empty;
        }
    }
}
