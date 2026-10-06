using MySqlConnector;
using System.Data;
using System.Windows;

namespace Studiok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Connection = "SERVER=localhost;Port=3306;Database=vizsga;User ID=root;Password=rootpassword";

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

                string query = @"SELECT * FROM studiok;";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGrid.ItemsSource = dt.DefaultView;

            } catch (MySqlException e)
            {
                MessageBox.Show(
                    "Hiba: "+ e.Message,
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void CountBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView? selected = dataGrid.SelectedItem as DataRowView;

            if (selected == null)
            {
                MessageBox.Show(
                    "Please choose a row!",
                    "There is no selected row.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            string studio = selected["studio"].ToString() ?? "";

            try
            {
                using MySqlConnection conn = new MySqlConnection(Connection);
                conn.Open();

                string query = @"SELECT COUNT(*) FROM filmek WHERE studio = @studio;";
                using MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studio", studio);

                object? result = cmd.ExecuteScalar();

                int count = Convert.ToInt32(result);

                MessageBox.Show(
                    $"{count} darab film van a {studio} stúdióhoz.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                dataGrid.SelectedItem = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Hiba: " + ex.Message,
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void MostStudioBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(Connection);
                connection.Open();

                string query = @"SELECT studio FROM studiok ORDER BY alapitva ASC limit 1;";
                using MySqlCommand cmd = new MySqlCommand(query, connection);

                object? result = cmd.ExecuteScalar();

                MessageBox.Show(
                    $"A legrégebbi stúdió: {result}",
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
                    MessageBoxImage.Error
                );
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}