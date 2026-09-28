using System.Windows;

namespace cukraszda
{
    /// <summary>
    /// Interaction logic for PriceListWindow.xaml
    /// </summary>
    public partial class PriceListWindow : Window
    {
        private readonly List<Cake> _cakes;
        private List<Cake> _order = new List<Cake>();

        public PriceListWindow(List<Cake> cakes)
        {
            InitializeComponent();
            _cakes = cakes;
            SutemenyLista.ItemsSource = cakes;
        }

        private void Rendel_Click(object sender, RoutedEventArgs e)
        {
            var chosen= _cakes.Where(c => c.Chosen).ToList();

            if (chosen.Count == 0) 
            {
                MessageBox.Show(
                    "Nincs kiválasztott sütemény! Pipálj ki legalább egyet.",
                    "Hiba", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning
                );
                
                return;
            }

            foreach (var c in chosen) 
            {
                if (c.Portion < 1)
                {
                    MessageBox.Show(
                        "1 vagy több adagot tudsz csak megadni!",
                        "Hiba",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );

                    return;
                }
            }

            _order = chosen;
            int finalPrice = chosen.Sum(c => c.Price * c.Portion);
            MessageBox.Show(
                $"Rendelés leadva: {chosen.Count} féle sütemény, összesen {finalPrice} Ft.",
                "Rendelés", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information
            );
        }

        private void Szamla_Click(object sender, RoutedEventArgs e)
        {
            if (_order.Count == 0)
            {
                MessageBox.Show(
                    "Előbb adj le rendelést a Rendel gombbal!",
                    "Nincs rendelés", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information
                );

                return;
            }

            var window = new InvoiceWindow(_order);
            window.Show();
        }
    }
}
