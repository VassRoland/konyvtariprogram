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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Nyilvantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Adatok> l = new List<Adatok>();
        List<adat2> l2 = new List<adat2>();
        List<Feladat> l3 = new List<Feladat>();
        public MainWindow()
        {
            InitializeComponent();
        }

        class Adatok
        {
            public int konyvid { get; set; }
            public string szerzoneve { get; set; }
            public string cim { get; set; }
            public string evszam { get; set; }
            public string kiado { get; set; }
            public bool ig { get; set; }
            public Adatok(string sor)
            {
                string[] resz = sor.Split(';');
                konyvid = Convert.ToInt32(resz[0]);
                szerzoneve = resz[1];
                cim = resz[2];
                evszam = resz[3];
                kiado = resz[4];
                ig = Convert.ToBoolean(resz[5]);

            }
        }

        class adat2
        {
            public int olvasoid { get; set; }
            public string nev { get; set; }
            public DateTime szuletes { get; set; }
            public int szama { get; set; }
            public string telepulesnev { get; set; }
            public string utca { get; set; }
            public adat2(string sor)
            {
                string[] resz = sor.Split(';');
                olvasoid = Convert.ToInt32(resz[0]);
                nev = resz[1];
                szuletes = Convert.ToDateTime(resz[2]);
                szama = Convert.ToInt32(resz[3]);
                telepulesnev = resz[4];
                utca = resz[5];


            }
        }

        class Feladat
        {
            public int kolcsonzoid { get; set; }
            public int olvasoid { get; set; }
            public int konyvid { get; set; }
            public DateTime koldatum { get; set; }
            public DateTime visszadasdatum { get; set; }
            public Feladat(string sor)
            {
                string[] resz = sor.Split(';');
                kolcsonzoid = Convert.ToInt32(resz[0]);
                olvasoid = Convert.ToInt32(resz[1]);
                konyvid = Convert.ToInt32(resz[2]);
                koldatum = Convert.ToDateTime(resz[3]);
                visszadasdatum = Convert.ToDateTime(resz[3]);
            }
        }

        private void Konyvek_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("konyvek.txt"))
            {
                l.Add(new Adatok(item));
            }
            Konyv.ItemsSource = l;

            Konyv.AutoGenerateColumns = false;
        }

        private void Tagok_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("tagok.txt"))
            {
                l2.Add(new adat2(item));


            }
            Tag.ItemsSource = l2;
            Tag.AutoGenerateColumns = false;
        }

        private void Kolcsonzes_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in File.ReadAllLines("kolcsonzesek.txt"))
            {
                l3.Add(new Feladat(item));
            }
            Kolcson.ItemsSource = l3;
            Kolcson.AutoGenerateColumns = false;
        }

        private void Konyv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}