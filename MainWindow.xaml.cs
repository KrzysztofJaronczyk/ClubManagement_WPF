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
        PlayerWindow subWindow;
        TrainersWindow subWindow2;


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

        private void WallpaperBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (WallpaperBox.SelectedIndex)
            {
                case 0:
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image1.Visibility = Visibility.Visible;
                    break;
                case 1:
                    image1.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Visible;
                    break;
                case 2:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (subWindow != null)
            {
                subWindow.Close();
                subWindow = null;
            }
            else
            {
                subWindow = new PlayerWindow();

                subWindow.Show();
            }
        }

        private void AddPlayer_Copy7_Click(object sender, RoutedEventArgs e)//trainers
        {
            if (subWindow2 != null)
            {
                subWindow2.Close();
                subWindow2 = null;
            }
            else
            {
                subWindow2 = new TrainersWindow();

                subWindow2.Show();
            }
        }
    }
}