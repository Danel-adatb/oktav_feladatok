using MySqlConnector;
using System.Data;
using System.Windows;

namespace Studiok
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

            var cmd = new MySqlCommand("SELECT * FROM studiok", connection);
            var dt = new DataTable();
            new MySqlDataAdapter(cmd).Fill(dt);

            adatokDataGrid.ItemsSource = dt.DefaultView;
        }

        private void KilepesButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DarabszamButton_Click(object sender, RoutedEventArgs e)
        {
            if (adatokDataGrid.SelectedItem is not DataRowView sor)
            {
                MessageBox.Show("Válasszon ki egy sort!");
                return;
            }

            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT COUNT(*) FROM filmek WHERE studio = @param", connection);
            cmd.Parameters.AddWithValue("@param", sor["studio"].ToString());

            int db = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show($"{sor["studio"]} stúdió filmjeinek száma: {db}");
        }

        private void LegregebbiButton_Click(object sender, RoutedEventArgs e)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT studio FROM studiok ORDER BY alapitva ASC LIMIT 1", connection);
            MessageBox.Show($"A legrégebbi stúdió: {cmd.ExecuteScalar()}");
        }
    }
}
