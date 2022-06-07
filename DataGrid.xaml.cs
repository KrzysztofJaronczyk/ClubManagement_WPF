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
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
        }


        public void clearData()
        {
            Name.Clear();
            Surname.Clear();
            Skill.Clear();
            Positon.Clear();
        }
        private void AddPlayer_Copy2_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
    }
}
