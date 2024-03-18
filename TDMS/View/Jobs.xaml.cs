using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace TDMS.View
{
    /// <summary>
    /// Interaction logic for Jobs.xaml
    /// </summary>
    public partial class Jobs : UserControl
    {
        public Jobs()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            string connectionString = "Server=localhost;Database=tdms;Uid=root;Pwd=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM jobs", connection);
                connection.Open();

                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());

                dataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
