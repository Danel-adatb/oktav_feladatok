using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace orszagok
{
    /// <summary>
    /// Interaction logic for EuropeanWindow.xaml
    /// </summary>
    public partial class EuropeanWindow : Window
    {
        private List<string> _countries = new();

        public EuropeanWindow(List<Country> countries)
        {
            InitializeComponent();
            List<string> list = new List<string>();
            foreach (Country country in countries)
            {
                if(country.Continent == "Európa") list.Add(country.Name);
            }
            EuropeanListBox.ItemsSource = list;
            _countries = list;
        }

        private void PrintResults_Click(object sender, RoutedEventArgs e)
        {
            string path = "Europaiak.txt";

            try
            {
                File.WriteAllLines(path, _countries, Encoding.UTF8);
                MessageBox.Show(
                    $"Elmentve ide:\n{System.IO.Path.GetFullPath(path)}",
                   "Kész",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
                );
            }
            catch (Exception ex)
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
