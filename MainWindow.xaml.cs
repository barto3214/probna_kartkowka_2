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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace probna_kartkowka_2
{
    public partial class MainWindow : Window
    {
        public string nazwa_pliku { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void wpisywany_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Title.Contains("*") == false)
            {
                Title = "* " + Title;
            }
        }

        private void otworz_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            MessageBoxResult result = MessageBox.Show("Czy chcesz wcześniej to zapisać?", "Zapisz", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                zapisz_click(sender, e);
            }
            else
            {

            }
            if (openFileDialog.ShowDialog() == true)
            {
                nazwa_pliku = openFileDialog.FileName;
                wpisywany_text.Text = File.ReadAllText(openFileDialog.FileName);
                Title = openFileDialog.FileName;
            }
        }

        private void zapisz_click(object sender, RoutedEventArgs e)
        {
            if (nazwa_pliku == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "pliki tekstowe | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    nazwa_pliku = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, wpisywany_text.Text);
                }
            }
        }

        private void zamknij_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz wcześniej to zapisać?", "Zapisz", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                zapisz_click(sender, e);
            }
            else if (result == MessageBoxResult.No)
            {
                Close();
            }
            else
            {

            }
        }

        private void liczby_Click(object sender, RoutedEventArgs e)
        {
            Liczby liczby = new Liczby();
            liczby.ShowDialog();
            List<int> liczby_losowe = liczby.liczby_losowe;
            wpisywany_text.Text = string.Join(", ", liczby_losowe);      // możnaby też użyć split, wtedy to by wyglądało tak:
                                                                         //string dane = "1,2,3,4,5";
                                                                         //string[] liczby = dane.Split(',');


        }

        private void suma_click(object sender, RoutedEventArgs e){
            string dane_poczatkowe = wpisywany_text.Text;
            int dane_koncowe,suma = 0;
            string[] srednie_dane = dane_poczatkowe.Split(',');
            for (int i=0;i< srednie_dane.Length;i++) {
                if (int.TryParse(srednie_dane[i].Trim(), out dane_koncowe)) {
                    suma += dane_koncowe;
                }
                dane_koncowe = 0;
            }
            MessageBox.Show("Oto suma: " + suma.ToString(),"Suma",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void max_click(object sender, RoutedEventArgs e){
            int dane_koncowe, max = 0;
            string dane_poczatkowe = wpisywany_text.Text;
            string[] srednie_dane = dane_poczatkowe.Split(',');

            for (int i = 0; i < srednie_dane.Length; i++) {
                if (int.TryParse(srednie_dane[i].Trim(), out dane_koncowe)){
                    if (dane_koncowe > max)
                    {
                        max = dane_koncowe;
                    }
                }  
            }
            MessageBox.Show("Oto największa liczba: " + max.ToString(), "Max", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void min_click(object sender, RoutedEventArgs e)
        {
            int dane_koncowe, min = int.MaxValue; 
            string dane_poczatkowe = wpisywany_text.Text;
            string[] srednie_dane = dane_poczatkowe.Split(',');

            for (int i = 0; i < srednie_dane.Length; i++)
            {
                if (int.TryParse(srednie_dane[i].Trim(), out dane_koncowe))
                {
                    
                    if (dane_koncowe < min)
                    {
                        min = dane_koncowe;
                    }
                }
            }

            
            MessageBox.Show("Oto najmniejsza liczba: " + min.ToString(), "Min", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
