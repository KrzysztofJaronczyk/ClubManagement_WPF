using System;
using System.Linq;
using System.Windows;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private int updatingPlayerID = 0;

        public void LoadGrid()
        {
            ClubManagementDBEntities db = new ClubManagementDBEntities();
            var docs = from d in db.Players
                       select d;

            foreach (var item in docs)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Surname);
                Console.WriteLine(item.Position);
                Console.WriteLine(item.Skill_Lv);
            }
            this.PlayersTable.ItemsSource = docs.ToList();
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
            if (Name.Text == String.Empty || Surname.Text == String.Empty || Positon.Text == String.Empty || isInt(Skill.Text) == false)
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
            Player player = new Player();
            {

                player.Name = Name.Text;
                player.Surname = Surname.Text;
                player.Position = Positon.Text;
                if (isInt(Skill.Text) == true)
                {
                    player.Skill_Lv = Convert.ToInt32(Skill.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number in Skill_Lv.", "Failed to add player", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            try
            {
                if (IsValid())
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                    MessageBox.Show("Player added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                    LoadGrid();
                }
                else
                    MessageBox.Show("Please fill all the fields.", "Failed to add player", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)//any other exceptions
            {
                MessageBox.Show(ex.Message, "Failed to add player", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)//refresh
        {
            LoadGrid();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)//update
        {

            ClubManagementDBEntities db = new ClubManagementDBEntities();

            var r = from d in db.Players
                    where d.Id == updatingPlayerID
                    select d;

            Player obj = r.SingleOrDefault();

            if (IsValid())
            {
                obj.Name = this.Name.Text;
                obj.Surname = this.Surname.Text;
                obj.Position = this.Positon.Text;
                obj.Skill_Lv = Convert.ToInt32(this.Skill.Text);
            }
            else
                MessageBox.Show("Please check if all fields are filled correctly and the player is selected.", "Failed to update player", MessageBoxButton.OK, MessageBoxImage.Error);
            
            if (IsValid())
            {
                db.SaveChanges();
                MessageBox.Show("Player updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadGrid();
                ClearData();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)//delete
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this player?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                ClubManagementDBEntities db = new ClubManagementDBEntities();
                var r = from d in db.Players
                        where d.Id == updatingPlayerID
                        select d;

                Player obj = r.SingleOrDefault();
                if (IsValid())
                {
                    db.Players.Remove(obj);
                    db.SaveChanges();
                    MessageBox.Show("Player deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadGrid();
                    ClearData();
                }
                else
                    MessageBox.Show("Please select a player to delete!", "Failed to delete player", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void PlayersTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.PlayersTable.SelectedIndex >= 0)
            {
                if (this.PlayersTable.SelectedItems.Count >= 0)
                {
                    if (this.PlayersTable.SelectedItems[0].GetType() == typeof(Player))
                    {
                        Player player = (Player)this.PlayersTable.SelectedItems[0];
                        this.Name.Text = player.Name;
                        this.Surname.Text = player.Surname;
                        this.Positon.Text = player.Position;
                        //isInt(Skill.Text);
                        //if (successfullyParsed)
                        this.Skill.Text = player.Skill_Lv.ToString();

                        this.updatingPlayerID = player.Id;
                    }
                }
            }
        }
    }
}
