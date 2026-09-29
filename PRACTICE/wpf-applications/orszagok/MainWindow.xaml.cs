using Microsoft.Win32;
using System.IO;
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

namespace orszagok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Country> _countries = new();

        private List<Country> readData(string path)
        {
            var list = new List<Country>();
            var file = File.ReadAllLines(path, Encoding.UTF8);

            for (int i = 0; i + 2 < file.Length; i += 3)
            {
                list.Add(new Country
                (
                    file[i].ToString().Trim(),
                    Int32.Parse(file[i + 1].Trim())*1000,
                    file[i + 2].ToString().Trim()
                ));
            }

            if (list.Count == 0) throw new Exception("A fájl nem tartalmaz érvényes sorokat.");

            return list;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Kérem nyissa meg az adatokat!",
                Filter = "Szövegfájl (*.txt)|*.txt|Minden fájl (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) return;

            try
            {
                _countries = readData(dialog.FileName);
                List<string> list = new List<string>();

                foreach (Country c in _countries) {
                    list.Add($"{c.Name} - {c.Population} - {c.Continent}");
                }
                CountriesListBox.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nem tudtuk beolvasni a file tartalmát: "+ex.Message,
                    "Hiba!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            if ((MoreCheck.IsChecked == false && LessCheck.IsChecked == false) || (MoreCheck.IsChecked == true && LessCheck.IsChecked == true))
            {
                MessageBox.Show(
                    "Kérlek jelöld be az egyik checkbox lehetőséget!",
                    "Figyelmeztetés!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            } else if (MoreCheck.IsChecked == true && LessCheck.IsChecked == false)
            {
                List<Country> results = _countries.Where(c => c.Population > 10000000).ToList();
                int count = results.Count();
                countTextBox.Clear();
                countTextBox.Text = count.ToString();
            } else if (MoreCheck.IsChecked == false && LessCheck.IsChecked == true)
            {
                List<Country> results = _countries.Where(c => c.Population < 10000000).ToList();
                int count = results.Count();
                countTextBox.Clear();
                countTextBox.Text = count.ToString();
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxBiggest.IsSelected == true)
            {
                Country result = _countries.OrderByDescending(c => c.Population).First();
                MessageBox.Show(
                    $"A legnagyobb populációjú ország: {result.Name} - {result.Population}.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            } else
            {
                Country result = _countries.OrderByDescending(c => c.Population).Last();
                MessageBox.Show(
                    $"A legkisebb populációjú ország: {result.Name} - {result.Population}.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
        }

        private void Average_Click(object sender, RoutedEventArgs e)
        {
            if(_countries.Count == 0) { return; }
            double avg = _countries.Average(c => c.Population);

            MessageBox.Show(
                    $"Az átlag populáció: {avg:F2}.",
                    "Információ",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
        }

        private void European_Click(object sender, RoutedEventArgs e)
        {
            if (_countries.Count == 0) return;
            var window = new EuropeanWindow(_countries);
            window.Show();
        }

        private void PrintToFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}