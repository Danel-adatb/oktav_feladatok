using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace cukraszda
{
    public partial class MainWindow : Window
    {
        private List<Cake> _cakes = new List<Cake>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Cake> ReadFile(string path)
        {
            var lista = new List<Cake>();

            foreach (var row in File.ReadAllLines(path, System.Text.Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(row)) continue;

                var parts = row.Split(';');

                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int price))
                    lista.Add(new Cake(parts[0].Trim(), price, false, 1));
            }

            if (lista.Count == 0)
                throw new Exception("A fájl nem tartalmaz érvényes 'Név;Ár' sorokat.");

            return lista;
        }

        private void Megnyitas_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Árlista fájl megnyitása",
                Filter = "Szövegfájl (*.txt)|*.txt|Minden fájl (*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) return;

            try
            {
                _cakes = ReadFile(dialog.FileName);
                SutemenyekMenu.IsEnabled = true;
                Allapotszoveg.Text =
                     $"Betöltve: {_cakes.Count} sütemény. " +
                    "Kattints a Sütemények menüre az árlistához.";

                Sutemenyek_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nem sikerült betölteni a fájlt:\n" + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sutemenyek_Click(object sender, RoutedEventArgs e)
        {
            var window = new PriceListWindow(_cakes);
            window.Show();
        }

        private void Nevjegy_Click(object sender, RoutedEventArgs e)
        {
            var window = new BusinessCardWindow();
            window.Show();
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}