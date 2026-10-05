using MySqlConnector;
using System.Data;
using System.Windows;

namespace Legitarsasagok
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

            var cmd = new MySqlCommand("SELECT * FROM legitarsasagok", connection);
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

            var cmd = new MySqlCommand("SELECT COUNT(*) FROM jaratok WHERE legitarsasag = @param", connection);
            cmd.Parameters.AddWithValue("@param", sor["legitarsasag"].ToString());

            int db = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show($"{sor["legitarsasag"]} járatainak száma: {db}");
        }

        private void LegnagyobbFlottaButton_Click(object sender, RoutedEventArgs e)
        {
            using var connection = new MySqlConnection(ConnectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT legitarsasag FROM legitarsasagok ORDER BY flotta DESC LIMIT 1", connection);
            MessageBox.Show($"A legnagyobb flottával rendelkező légitársaság: {cmd.ExecuteScalar()}");
        }
    }
}
