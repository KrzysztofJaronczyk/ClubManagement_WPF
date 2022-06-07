﻿using System.Collections.Generic;
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
            //if (PlayerName.Text == "" || PlayerAge.Text == "" || PlayerHeight.Text == "" || PlayerWeight.Text == "" || PlayerPosition.Text == "" || PlayerNumber.Text == "")
            //{
            //    MessageBox.Show("Please fill all the fields");
            //}
            //else
            //{
            //    string name = PlayerName.Text;
            //    int age = Convert.ToInt32(PlayerAge.Text);
            //    int height = Convert.ToInt32(PlayerHeight.Text);
            //    int weight = Convert.ToInt32(PlayerWeight.Text);
            //    string position = PlayerPosition.Text;
            //    int number = Convert.ToInt32(PlayerNumber.Text);
            //    Player player = new Player(name, age, height, weight, position, number);
            //    player.Save();
            //    MessageBox.Show("Player added successfully");
            //}


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
    }
}