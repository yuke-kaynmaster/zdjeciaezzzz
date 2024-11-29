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
using System.Xml.Serialization;

namespace zdjecia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Obraz> obrazy = new List<Obraz>();
        int aktualnyObraz = 0;
        public MainWindow()
        {
            InitializeComponent();
            obrazy.Add(new Obraz("kotel.jpg"));
            obrazy.Add(new Obraz("doskotelos.jpg"));
            obrazy.Add(new Obraz("treskotelos.jpg"));
        }

        private void lewaczek_Click(object sender, RoutedEventArgs e)
        {
            aktualnyObraz--;
            if(aktualnyObraz < 0)
            {
                aktualnyObraz = obrazy.Count - 1;
            }
            wyswietlObraz(aktualnyObraz);
        }

        private void prawaczek_Click(object sender, RoutedEventArgs e)
        {
            aktualnyObraz++;
            if(aktualnyObraz == obrazy.Count)
            {
                aktualnyObraz = 0;
            }
            wyswietlObraz(aktualnyObraz);   
        }
        private void wyswietlObraz(int i)
        {
            obrazeczek.Source = new BitmapImage(new Uri(obrazy[i].UrlObrazka, UriKind.Relative));
            liczbaPolubienBloczek.Text = obrazy[i].licznikPolubien.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obrazy[aktualnyObraz].licznikPolubien++;
            wyswietlObraz(aktualnyObraz);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            obrazy[aktualnyObraz].licznikPolubien = 0;
            wyswietlObraz(aktualnyObraz);
        }
    }
}