using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cukraszda
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow(List<Cake> order)
        {
            InitializeComponent();
            SzamlaBox.Document = BuildInvoice(order);
        }

        private FlowDocument BuildInvoice(List<Cake> order)
        {
            // Monospace font, hogy az oszlopok szépen egymás alá kerüljenek.
            var doc = new FlowDocument
            {
                FontFamily = new FontFamily("Consolas"),
                FontSize = 14
            };

            // Fejléc
            doc.Blocks.Add(new Paragraph(new Run("SZÁMLA – Cukrászda"))
            {
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 4)
            });

            doc.Blocks.Add(new Paragraph(new Run($"Kelt: {DateTime.Now:yyyy-MM-dd HH:mm}"))
            {
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            });

            // Tételsorok – egy Paragraph az egész lista, sortöréssel (LineBreak)
            var tetelek = new Paragraph { Margin = new Thickness(0) };
            int vegosszeg = 0;
            foreach (var c in order)
            {
                int sorAr = c.Price * c.Portion;
                vegosszeg += sorAr;

                // Igazított oszlopok: név balra 20 karakteren, számok jobbra.
                string sor = $"{c.Name,-20}{c.Portion,3} x {c.Price,4} Ft = {sorAr,6} Ft";
                tetelek.Inlines.Add(new Run(sor));
                tetelek.Inlines.Add(new LineBreak());
            }
            doc.Blocks.Add(tetelek);

            // Végösszeg
            doc.Blocks.Add(new Paragraph(new Run($"Végösszeg: {vegosszeg} Ft"))
            {
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Margin = new Thickness(0, 10, 0, 0)
            });

            return doc;
        }
    }
}
