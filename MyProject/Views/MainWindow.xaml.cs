using System.Windows;

namespace MyProject.Views
{
    public partial class MainWindow : Window
    {
        public static NavigationManager NavigationManager { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            NavigationManager = new NavigationManager(MainFrame);
        }

    }
}
