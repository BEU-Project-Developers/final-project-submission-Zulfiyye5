using System.Windows;

namespace MyProject.Views
{
    public partial class MainWindow : Window
    {
        public static NavigationService NavigationService { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            NavigationService = new NavigationService(MainFrame);
        }

    }
}
