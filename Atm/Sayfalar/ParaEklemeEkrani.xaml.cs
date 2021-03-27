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
    /// Interaction logic for ParaEklemeEkrani.xaml
    /// </summary>
    public partial class ParaEklemeEkrani : Page
    {
        public ParaEklemeEkrani()
        {
            InitializeComponent();

            mevcutBakiyeTxt.Text = DataAccess.Musteri.AccountMoney.ToString();
        }

        public void Yatir_Btn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata :" + ex.Message.ToString());
            //}
            if (decimal.Parse(yatirilacakTxt.Text.ToString()) > 0)
            {
                DataAccess.ParaYatir(decimal.Parse(yatirilacakTxt.Text.ToString()));
                MessageBox.Show("Para yatırma işlemi başarılı oldu.");
                mevcutBakiyeTxt.Text = DataAccess.Musteri.AccountMoney.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen tanımlı değer giriniz.");
            }
            
        }
    }
}
