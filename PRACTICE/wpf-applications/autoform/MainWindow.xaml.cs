using Microsoft.Win32;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace autoform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Auto> cars = new List<Auto>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Biztosan ki szeretnél lépni?",
                "Kilépés",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void loadBtn_Click(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "CSV fájl megnyitása",
                Filter = "CSV fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*",
                DefaultExt = ".csv"
            };

            if(ofd.ShowDialog() == true )
            {
                string filePath = ofd.FileName;
                List<Auto> datas = Auto.readData(filePath);
                AutokDataGrid.ItemsSource = datas;
                foreach( Auto data in datas )
                {
                    cars.Add( data );
                }
            }
            
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ListBox törlése
            resultListBox.Items.Clear();

            // Ha nincs még adat betöltve
            if (cars.Count == 0)
            {
                return;
            }

            // Ha nem érvényes év
            if (!int.TryParse(inputTextBox.Text, out int year))
            {
                return;
            }

            // Év alapján szűrés
            var result = cars
                .Where(car => car.Year == year)
                .Select(car => $"{car.Brand} {car.Model}")
                .ToList();

            // ListBox feltöltése
            foreach (string car in result)
            {
                resultListBox.Items.Add(car);
            }
        }
    }
}