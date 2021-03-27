using Atm.Siniflar;
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

namespace Atm.Sayfalar
{
    /// <summary>
    /// HesapEklemeEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class HesapEklemeEkrani : Page
    {
        public HesapEklemeEkrani()
        {
            InitializeComponent();
        }


        public void Ekle_Btn_Click(object sender,RoutedEventArgs e)
        {
            DataAccess.HesapEkle(hesapNoTxt.Text.ToString(), sifreTxt.Password.ToString(), adTxt.Text.ToString(), soyadTxt.Text.ToString());
            MessageBox.Show("Hesap başarıyla eklendi.");
        }
    }
}
