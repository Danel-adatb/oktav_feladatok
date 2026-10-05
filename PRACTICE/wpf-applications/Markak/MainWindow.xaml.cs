using MySqlConnector;
using System.Data;
using System.Printing;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Linq;

namespace Markak
{
    public partial class MainWindow : Window
    {
        private const string Connection = "Server=127.0.0.1;Port=3306;Database=vizsga;User ID=root;Password=rootpassword;";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(Connection);
                conn.Open();

                string query = @"SELECT * from markak;";

                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable markakTable = new DataTable();
                adapter.Fill(markakTable);

                dataGrid.ItemsSource = markakTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void CountBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView? selectedRow = dataGrid.SelectedItem as DataRowView;

            if (selectedRow == null)
            {
                MessageBox.Show(
                    "Kérlek válassz egy sort!",
                    "Nincs sor kiválasztva.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            string manufacturer = selectedRow["gyarto"].ToString() ?? "";

            try
            {
                using MySqlConnection conn = new MySqlConnection(Connection);
                conn.Open();

                string query = @"SELECT COUNT(*) FROM kerekparok WHERE gyarto = @manufacturer";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manufacturer", manufacturer);

                object? result = cmd.ExecuteScalar();
                int count = Convert.ToInt32(result);

                MessageBox.Show(
                    $"{manufacturer} gyartoonak a szama: {count}!",
                    "Szerszámok száma",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                dataGrid.SelectedItem = null;
            } catch (Exception ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void MostBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();

                string query = @"SELECT gyarto FROM markak ORDER BY gyarto DESC LIMIT 1;";
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                object? result = cmd.ExecuteScalar();
                string manufacturer = result?.ToString() ?? "";

                MessageBox.Show(
                    $"A legtöbb üzemmel rendelkező márka: {manufacturer}",
                    "Legtöbb üzem",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

            } catch (Exception ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}