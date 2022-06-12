using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for TrainingsWindow.xaml
    /// </summary>
    public partial class TrainingsWindow : Window
    {
        public TrainingsWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private int updatingTrainingID = 0;

        public void LoadGrid()
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();

            //var docs = from d in db.Trainings
            //               //join s in db.Trainers on d.Id equals s.Id
            //           select new
            //           {
            //               Id = d.Id,
            //               TrainingDate = d.TrainingDate.ToString(),
            //               TrainingTime = d.TrainingTime
            //               //Trainer=s.Name
            //           };

            var docs = from d in db.Trainings
                       select d;
            
            this.TrainingsTable.ItemsSource = docs.ToList();
        }

        public void ClearData()
        {
            Calendar.SelectedDate = null;
            TimePicker.Text = null;//
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        public bool CheckData()
        {
            if (Calendar.SelectedDate == null || TimePicker.Text == null)
            {
                MessageBox.Show("Please select training date and/or hour.", "Failed to add training", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (Calendar.SelectedDate.Value.Date < DateTime.Now.Date)
            {

                MessageBox.Show("Please select a training date in the future.", "Failed to add training", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckData())
            {

                ClubManagementDBEntities db = new ClubManagementDBEntities();
                Training training = new Training();
                {
                    training.Date = Convert.ToDateTime(Calendar.SelectedDate);
                    training.Hour = TimePicker.Text;

                    db.Trainings.Add(training);
                    db.SaveChanges();
                    MessageBox.Show("Training added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)//nie działą
        {
            if (CheckData())
            {
                ClubManagementDBEntities db = new ClubManagementDBEntities();

                var r = from d in db.Trainings
                        where d.Id == updatingTrainingID
                        select d;

                Training obj = r.SingleOrDefault();
                if (obj != null)
                {
                    obj.Date = Convert.ToDateTime(this.Calendar.SelectedDate);
                    obj.Hour = this.TimePicker.Text;

                    db.SaveChanges();
                    MessageBox.Show("Training updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CheckData();
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this training?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ClubManagementDBEntities db = new ClubManagementDBEntities();
                var r = from d in db.Trainings
                        where d.Id == updatingTrainingID
                        select d;

                Training obj = r.SingleOrDefault();
                if (obj != null)
                {
                    db.Trainings.Remove(obj);
                    db.SaveChanges();
                    MessageBox.Show("Training deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadGrid();
                    ClearData();
                }
                else
                    MessageBox.Show("Training not found. Please select training to delete.", "Failed to delete training", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private void TrainingsTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.TrainingsTable.SelectedIndex >= 0)
            {
                if (this.TrainingsTable.SelectedItems.Count >= 0)
                {
                    if (this.TrainingsTable.SelectedItems[0].GetType() == typeof(Training))
                    {
                        Training training = (Training)this.TrainingsTable.SelectedItems[0];
                        this.Calendar.SelectedDate = training.Date;
                        this.TimePicker.Text = training.Hour;
                        this.updatingTrainingID = training.Id;
                    }
                }
            }
        }
    }
}
