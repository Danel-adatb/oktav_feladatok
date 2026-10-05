using MySqlConnector;
using System.Data;
using System.Windows;

namespace Markak
{
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "server=localhost;user=root;password=;database=vizsga;";

        public MainWindow()
        {
            InitializeComponent();
            AdatokBetoltese();
        }

        private void AdatokBetoltese()
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT * FROM markak", connection);
            var dt = new DataTable();
            new MySqlDataAdapter(cmd).Fill(dt);

            markakDataGrid.ItemsSource = dt.DefaultView;
        }

        private void KilepesButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DarabszamButton_Click(object sender, RoutedEventArgs e)
        {
            if (markakDataGrid.SelectedItem is not DataRowView sor)
            {
                MessageBox.Show("Válasszon ki egy márkát!");
                return;
            }

            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT COUNT(*) FROM kerekparok WHERE gyarto = @gyarto", connection);
            cmd.Parameters.AddWithValue("@gyarto", sor["gyarto"].ToString());

            int db = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show($"{sor["gyarto"]} kerékpárjainak száma: {db}");
        }

        private void LegtobbUzemButton_Click(object sender, RoutedEventArgs e)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT gyarto FROM markak ORDER BY uzemek DESC LIMIT 1", connection);
            MessageBox.Show($"A legtöbb üzeme ennek a márkának van: {cmd.ExecuteScalar()}");
        }
    }
}
