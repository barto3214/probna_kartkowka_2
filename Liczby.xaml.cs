using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace probna_kartkowka_2
{
    /// <summary>
    /// Logika interakcji dla klasy Liczby.xaml
    /// </summary>
    public partial class Liczby : Window
    {
        public List<int> liczby_losowe = new List<int>();
        public Liczby()
        {
            InitializeComponent();
        }

        private void losowanie(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int ile_zakres, od_zakres, do_zakres;
            if (int.TryParse(ile.Text.ToString(), out ile_zakres) && int.TryParse(od_ile.Text.ToString(), out od_zakres) && int.TryParse(do_ile.Text.ToString(), out do_zakres))
            {
                for (int i = 0; i < ile_zakres; i++){
                    int wartosc = random.Next(od_zakres,do_zakres + 1);
                    liczby_losowe.Add(wartosc);
                }
            }
            Close();

        }
    }
}
