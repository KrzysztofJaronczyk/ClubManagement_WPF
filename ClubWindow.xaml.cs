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
using System.Windows.Shapes;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ClubWindow.xaml
    /// </summary>
    public partial class ClubWindow : Window
    {
        public ClubWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private int updatingClubInformationID = 0;

        public void LoadGrid()
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();
            var docs = from d in db.ClubInformations
                       select d;
            this.ClubTable.ItemsSource = docs.ToList();
        }
        public void ClearData()
        {
            Name.Clear();
            Surname.Clear();
            Skill.Clear();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)//clear
        {
            ClearData();
        }

        #region DataValidation
        public bool IsValid()//data validation
        {
            if (Name.Text == String.Empty || Surname.Text == String.Empty || Skill.Text == String.Empty || isInt(Skill.Text) == false)
            {
                return false;
            }
            return true;
        }
        public bool isInt(string x)//int validation
        {
            int ignoreMe;
            bool successfullyParsed = int.TryParse(x, out ignoreMe);
            if (successfullyParsed)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        #endregion
        private void AddButton_Click(object sender, RoutedEventArgs e)//add
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();
            ClubInformation club = new ClubInformation();
            {

                club.ClubName = Name.Text;
                club.City = Surname.Text;
                if (isInt(Skill.Text) == true)
                {
                    club.YearOfCreation = Convert.ToInt32(Skill.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number in Skill_Lv.", "Failed to add ClubInformation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                if (IsValid())
                {
                    db.ClubInformations.Add(club);
                    db.SaveChanges();
                    MessageBox.Show("ClubInformation added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }
                else
                    MessageBox.Show("Please fill all the fields.", "Failed to add ClubInformation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)//any other exceptions
            {
                MessageBox.Show(ex.Message, "Failed to add ClubInformation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)//refresh
        {
            LoadGrid();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)//update
        {

            ClubManagementDBEntities db = new ClubManagementDBEntities();

            var r = from d in db.ClubInformations
                    where d.Id == updatingClubInformationID
                    select d;

            ClubInformation obj = r.SingleOrDefault();

            if (IsValid())
            {
                obj.ClubName = this.Name.Text;
                obj.YearOfCreation = Convert.ToInt32(this.Skill.Text);
                obj.City = this.Surname.Text;
            }
            else
                MessageBox.Show("Please check if all fields are filled correctly and the ClubInformation is selected.", "Failed to update ClubInformation", MessageBoxButton.OK, MessageBoxImage.Error);

            if (IsValid())
            {
                db.SaveChanges();
                MessageBox.Show("ClubInformation updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadGrid();
                ClearData();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)//delete
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this ClubInformation?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ClubManagementDBEntities db = new ClubManagementDBEntities();
                var r = from d in db.ClubInformations
                        where d.Id == updatingClubInformationID
                        select d;

                ClubInformation obj = r.SingleOrDefault();
                if (IsValid())
                {
                    db.ClubInformations.Remove(obj);
                    db.SaveChanges();
                    MessageBox.Show("ClubInformation deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadGrid();
                    ClearData();
                }
                else
                    MessageBox.Show("Please select a ClubInformation to delete!", "Failed to delete ClubInformation", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ClubTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.ClubTable.SelectedIndex >= 0)
            {
                if (this.ClubTable.SelectedItems.Count >= 0)
                {
                    if (this.ClubTable.SelectedItems[0].GetType() == typeof(ClubInformation))
                    {
                        ClubInformation ClubInformation = (ClubInformation)this.ClubTable.SelectedItems[0];
                        this.Name.Text = ClubInformation.ClubName;
                        this.Surname.Text = ClubInformation.City;
                        this.Skill.Text = ClubInformation.YearOfCreation.ToString();

                        this.updatingClubInformationID = ClubInformation.Id;
                    }
                }
            }
        }

        private void ball_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)//ester egg
        {
            //create an random value from 10 to 30
            Random rnd = new Random();
            int randomValue = rnd.Next(-50, 50);
            int randomValue2 = rnd.Next(60, 80);


            Thickness margin = ball.Margin;
            margin.Left = margin.Left - randomValue2;
            margin.Top = margin.Top + randomValue;
            ball.Margin = margin;
            if (ball.Margin.Left < 10)
                margin.Left = Margin.Left + randomValue2;
            else if (ball.Margin.Left > 480)
                margin.Left = 169;
            if (ball.Margin.Top > -187 )
                margin.Top = Margin.Top - randomValue2;
            else if (ball.Margin.Top < -584)
                margin.Top = Margin.Top + randomValue2;
        }
    }
}
