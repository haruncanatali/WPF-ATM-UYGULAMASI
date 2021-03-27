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
    /// Interaction logic for GirisEkrani.xaml
    /// </summary>
    public partial class GirisEkrani : Page
    {

        public GirisEkrani()
        {
            InitializeComponent();
        }

        public void Giris_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.GirisKontrol(hesapNumarasiTxt.Text.ToString(), hesapSifresiPasswordBox.Password.ToString()))
            {
                MessageBox.Show("Giriş Başarılı Oldu! İşlemlerinizi gerçekleştirebilirsiniz.");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Oldu! ");
            }
        }

    }
}
