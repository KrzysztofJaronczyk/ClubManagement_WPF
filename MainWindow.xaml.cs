using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        TrainingsWindow subWindow3;
        ClubWindow subWindow4;


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

        private void AddPlayer_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (subWindow3 != null)
            {
                subWindow3.Close();
                subWindow3 = null;
            }
            else
            {
                subWindow3 = new TrainingsWindow();

                subWindow3.Show();
            }
        }

        private void AddPlayer_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (subWindow4 != null)
            {
                subWindow4.Close();
                subWindow4 = null;
            }
            else
            {
                subWindow4 = new ClubWindow();

                subWindow4.Show();
            }
        }

        private void ball_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)//ester egg
        {
            //ball.Margin = new Thickness(ball.Margin.Left + 10, ball.Margin.Top + 10, 0, 0);
            double x = ball.Width;
            ball.Width = x+1;
            ball.Height = x + 1;
        }

        private void ball_Click(object sender, System.Windows.Input.MouseEventArgs e)//reset ester egg
        {
            //ball.Margin = new Thickness(ball.Margin.Left + 10, ball.Margin.Top + 10, 0, 0);
            ball.Width = 50;
            ball.Height = 50;
        }
    }
}