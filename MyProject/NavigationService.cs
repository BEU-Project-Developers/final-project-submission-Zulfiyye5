using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyProject
{
    public class NavigationService
    {
        private readonly Frame _mainFrame;

        public NavigationService(Frame mainFrame)
        {
            _mainFrame = mainFrame ?? throw new ArgumentNullException(nameof(mainFrame));
        }

        public void Navigate(Page page)
        {
            if (_mainFrame != null && page != null)
            {
                _mainFrame.Navigate(page);
            }
        }

        public void GoBack()
        {
            if (_mainFrame?.CanGoBack == true)
            {
                _mainFrame.GoBack();
            }
        }

        public void GoForward()
        {
            if (_mainFrame?.CanGoForward == true)
            {
                _mainFrame.GoForward();
            }
        }
    }
}
