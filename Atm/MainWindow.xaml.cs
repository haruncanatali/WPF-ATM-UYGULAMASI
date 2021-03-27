using Atm.Sayfalar;
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
using Atm.Siniflar;

namespace Atm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GirisEkrani e1 = new GirisEkrani();
            frame1.Navigate(e1);
        }

        public void Btns_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "Giriş":
                    GirisEkrani e1 = new GirisEkrani();
                    frame1.Navigate(e1);
                    break;
                case "Para Gönder":
                    if (DataAccess.Musteri!=null)
                    {
                        ParaGondermeEkrani e2 = new ParaGondermeEkrani();
                        frame1.Navigate(e2);
                    }
                    else
                    {
                        MessageBox.Show("Önce giriş yapınız.");
                    }
                    break;
                case "Para Yatır":
                    if (DataAccess.Musteri != null)
                    {
                        ParaEklemeEkrani e3 = new ParaEklemeEkrani();
                        frame1.Navigate(e3);
                    }
                    else
                    {
                        MessageBox.Show("Önce giriş yapınız.");
                    }
                    break;
                case "Hesap Ekle":
                    HesapEklemeEkrani e4 = new HesapEklemeEkrani();
                    frame1.Navigate(e4);
                    break;
                case "Hesap Sil":
                    HesapSilmeEkrani e5 = new HesapSilmeEkrani();
                    frame1.Navigate(e5);
                    break;
                case "Çıkış":
                    if (DataAccess.Musteri != null)
                    {
                        DataAccess.CikisYap();
                        MessageBox.Show("Başarıyla çıkış yapıldı");
                    }
                    else
                    {
                        MessageBox.Show("Önce giriş yapınız.");
                    }
                    break;
            }
        }
    }
}
