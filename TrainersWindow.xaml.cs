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
    /// Interaction logic for TrainersWindow.xaml
    /// </summary>
    public partial class TrainersWindow : Window
    {
        public TrainersWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private int updatingtrainerID = 0;

        public void LoadGrid()
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();
            var docs = from d in db.Trainers
                       select d;

            foreach (var item in docs)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Surname);
                Console.WriteLine(item.Rank);
                Console.WriteLine(item.Description);
            }
            this.TrainersTable.ItemsSource = docs.ToList();
        }
        public void ClearData()
        {
            Name.Clear();
            Surname.Clear();
            Skill.Clear();
            Positon.Clear();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)//clear
        {
            ClearData();
        }

        #region DataValidation
        public bool IsValid()//data validation
        {
            if (Name.Text == String.Empty || Surname.Text == String.Empty || Positon.Text == String.Empty || Skill.Text == String.Empty)
            {
                return false;
            }
            return true;
        }
      
        #endregion
        private void AddButton_Click(object sender, RoutedEventArgs e)//add
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();
            Trainer trainer = new Trainer();
            {

                trainer.Name = Name.Text;
                trainer.Surname = Surname.Text;
                trainer.Rank = Positon.Text;
                trainer.Description = Skill.Text;
            }
            try
            {
                if (IsValid())
                {
                    db.Trainers.Add(trainer);
                    db.SaveChanges();
                    MessageBox.Show("trainer added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }
                else
                    MessageBox.Show("Please fill all the fields.", "Failed to add trainer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)//any other exceptions
            {
                MessageBox.Show(ex.Message, "Failed to add trainer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)//refresh
        {
            LoadGrid();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)//update
        {

            ClubManagementDBEntities db = new ClubManagementDBEntities();

            var r = from d in db.Trainers
                    where d.Id == updatingtrainerID
                    select d;

           Trainer obj = r.SingleOrDefault();

            if (IsValid())
            {
                obj.Name = this.Name.Text;
                obj.Surname = this.Surname.Text;
                obj.Rank = this.Positon.Text;
                obj.Description = this.Skill.Text;
            }
            else
                MessageBox.Show("Please check if all fields are filled correctly and the trainer is selected.", "Failed to update trainer", MessageBoxButton.OK, MessageBoxImage.Error);

            if (IsValid())
            {
                db.SaveChanges();
                MessageBox.Show("trainer updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadGrid();
                ClearData();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)//delete
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ClubManagementDBEntities db = new ClubManagementDBEntities();
                var r = from d in db.Trainers
                        where d.Id == updatingtrainerID
                        select d;

                Trainer obj = r.SingleOrDefault();
                if (IsValid())
                {
                    db.Trainers.Remove(obj);
                    db.SaveChanges();
                    MessageBox.Show("trainer deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadGrid();
                    ClearData();
                }
                else
                    MessageBox.Show("Please select a trainer to delete!", "Failed to delete trainer", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void TrainersTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.TrainersTable.SelectedIndex >= 0)
            {
                if (this.TrainersTable.SelectedItems.Count >= 0)
                {
                    if (this.TrainersTable.SelectedItems[0].GetType() == typeof(Trainer))
                    {
                        Trainer trainer = (Trainer)this.TrainersTable.SelectedItems[0];
                        this.Name.Text = trainer.Name;
                        this.Surname.Text = trainer.Surname;
                        this.Positon.Text = trainer.Rank;
                        //isInt(Skill.Text);
                        //if (successfullyParsed)
                        this.Skill.Text = trainer.Description;

                        this.updatingtrainerID = trainer.Id;
                    }
                }
            }
        }
    }
}