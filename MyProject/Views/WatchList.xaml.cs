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
    /// Interaction logic for WatchList.xaml
    /// </summary>
    public partial class WatchList : Page
    {
        private readonly MovieService _movieService;
        public WatchList()
        {
            _movieService = new MovieService();
            this.DataContext = new PagesViewModel(_movieService);
            InitializeComponent();
        
        }

    

        private void MovieItem_Click(object sender, MouseButtonEventArgs e)
        {

            var border = sender as Border;
            var movie = border?.DataContext as Movie;

            if (movie != null)
            {
                var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;

                mainFrame?.Navigate(new MovieDetailsPage(movie));
            }
        }
    }
}
