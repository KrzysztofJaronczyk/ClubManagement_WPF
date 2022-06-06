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
using System.IO;
namespace ClubManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Visibility = Visibility.Hidden;
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            mediaElement.Visibility = Visibility.Visible;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // the list of items in the combobox are: edit player,edit trainer, edit training



        }

        private void AddPlayer_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}