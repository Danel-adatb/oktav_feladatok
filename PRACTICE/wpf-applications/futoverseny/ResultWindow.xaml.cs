using System.IO;
using System.Windows;

namespace futoverseny
{
    public partial class ResultWindow : Window
    {
        private List<string> _results = new List<string>();

        public ResultWindow(List<Racer> racers)
        {
            InitializeComponent();
            FillListBox(racers);
        }
        private void FillListBox(List<Racer> racers)
        {
            _results = racers
                .OrderBy(r => r.TimeResult)
                .Select(r => $"{r.TimeResult}  {r.Name}")
                .OrderDescending()
                .ToList();

            ResultListBox.ItemsSource = _results;
        }

        private void PrintResults_Click( object sender, RoutedEventArgs e )
        {
            string path = "EREDMENY.txt";

            try
            {
                File.WriteAllLines(path, _results, System.Text.Encoding.UTF8);
                MessageBox.Show(
                    $"Elmentve ide:\n{System.IO.Path.GetFullPath(path)}",
                   "Kész", 
                   MessageBoxButton.OK, 
                   MessageBoxImage.Information
                );
            }
            catch ( Exception ex )
            {
                MessageBox.Show(
                    "Nem tudtuk kiírani az eredményeket egy fájlba!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }
    }
}