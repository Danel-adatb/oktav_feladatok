using MySqlConnector;
using System.Data;
using System.Data.Common;
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

namespace konyvek
{
    public partial class MainWindow : Window
    {
        private const string Conn = "Server=127.0.0.1;Port=3306;User ID=root;Password=rootpassword;Database=vizsga;";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ReadData()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(Conn);
                conn.Open();

                string query = @"SELECT * FROM kiadok;";
                using MySqlCommand cmd = new MySqlCommand(query, conn);

                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                using DataTable dt = new DataTable();

                adapter.Fill(dt);

                dataGrid.ItemsSource = dt.DefaultView;

            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    "Hiba: " + e.Message,
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReadData();
        }

        private void countBtnClick(object sender, RoutedEventArgs e)
        {
            DataRowView? selected = dataGrid.SelectedItem as DataRowView;

            if (selected == null)
            {
               MessageBox.Show(
                    "Válassz egy sort!",
                    "Figyelmeztetés!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            string kiado = selected["kiado"].ToString() ?? "";

            try
            {
                using MySqlConnection conn = new MySqlConnection(Conn);
                conn.Open();

                string query = @"SELECT COUNT(*) FROM konyvek WHERE kiado = @kiado;";
                using MySqlCommand cmd = new MySqlCommand(@query, conn);
                cmd.Parameters.AddWithValue("@kiado", kiado);

                object? result = cmd.ExecuteScalar();

                int count = Convert.ToInt32(result);

                MessageBox.Show(
                    $"Kiadó: {kiado} - {count} darab könyv.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

            } catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }

        }

        private void mostBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(Conn);
                conn.Open();

                string query = @"SELECT kiado FROM kiadok ORDER BY szerzok DESC LIMIT 1;";
                using MySqlCommand cmd = new MySqlCommand(query, conn);

                object? result = cmd.ExecuteScalar();

                MessageBox.Show(
                    $"Legtöbb szerzovel rendelkezo kiado: {result}.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void closeBtnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}