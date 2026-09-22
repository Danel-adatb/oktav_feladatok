using MySqlConnector;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace gyartok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connection = "Server=127.0.0.1;Port=3306;Database=vizsga;User ID=root;Password=rootpassword;";
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();

                string query = @"SELECT * FROM manufacturers;";

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable manufacturersTable = new DataTable();
                adapter.Fill(manufacturersTable);

                GyartokDataGrid.ItemsSource = manufacturersTable.DefaultView;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(
                    "Database Error\n" + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void exitBtn_Click( object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView? selectedRow = GyartokDataGrid.SelectedItem as DataRowView;

            if(selectedRow == null)
            {
                MessageBox.Show(
                    "Please choose a row!",
                    "There is no selected row.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            string name = selectedRow["name"].ToString() ?? "";

            try
            {
                using MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();

                string query = @"SELECT COUNT(*) FROM tools WHERE manufacturer = @name;";

                using MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", name);

                object? result = cmd.ExecuteScalar();

                int count = Convert.ToInt32(result);

                MessageBox.Show(
                    $"{name} szerszámoknak a száma: {count}!",
                    "Szerszámok száma",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                GyartokDataGrid.SelectedItem = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                   "Database Error\n" + ex.Message,
                   "Error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error
                );
            }
        }

        private void subvirseryCountBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();

                string query = "SELECT name FROM manufacturers ORDER BY subsidiary DESC LIMIT 1;";

                using MySqlCommand cmd = new MySqlCommand(query, conn);

                object? result = cmd.ExecuteScalar();
                string name = result.ToString() ?? "";

                MessageBox.Show(
                    $"A legtöbb leányvállalattal rendelkező cég: {name}!",
                    "Szerszámok száma",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                GyartokDataGrid.SelectedItem = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                   "Database Error\n" + ex.Message,
                   "Error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error
                );
            }
        }
    }
}