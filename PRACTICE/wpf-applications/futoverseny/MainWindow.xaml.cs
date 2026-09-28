using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace futoverseny
{
    public partial class MainWindow : Window
    {
        private List<Racer> _racers = new List<Racer>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Racer> ReadFile(string path) 
        { 
            var list = new List<Racer>();

            foreach (var row in File.ReadAllLines(path, System.Text.Encoding.UTF8)) {
                if(string.IsNullOrEmpty(row)) continue;

                var parts = row.Split(';');

                list.Add(
                    new Racer(Int32.Parse(parts[0]), parts[1], DateTime.Parse(parts[2]), parts[3], parts[4])
                );
            }

            if (list.Count == 0) throw new Exception("A fájl nem tartalmaz érvényes sorokat.");

            return list; 
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Futók megnyitása!",
                Filter = "Szövegfájl (*.txt)|*.txt|Minden fájl (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) return;

            try
            {
                _racers = ReadFile(dialog.FileName);
                ParticipantsListBox.ItemsSource = _racers;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    "Nem sikerült betölteni a fájlt:\n" + ex.Message, 
                    "Hiba", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error
                );
            }
        }

        private void DataIn_Click(object sender, RoutedEventArgs e)
        {
            RaceIdTextBox.Clear();
            CountryTextBox.Clear();
            TimeResultTextBox.Clear();
            AgeTextBox.Clear();

            if (ParticipantsListBox.SelectedItem is not Racer racer)
            {
                MessageBox.Show(
                    "Kérlek válassz egy sort!",
                    "Nincs kiválasztva sor",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            RaceIdTextBox.Text = racer.RaceId.ToString();
            CountryTextBox.Text = racer.Country;
            TimeResultTextBox.Text = racer.TimeResult;
            AgeTextBox.Text = racer.Age.ToString();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            var window = new ResultWindow(_racers);
            window.Show();
        }
    }
}