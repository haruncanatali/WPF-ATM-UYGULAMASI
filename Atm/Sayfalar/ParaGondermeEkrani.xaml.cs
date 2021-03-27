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

namespace Atm.Sayfalar
{
    /// <summary>
    /// Interaction logic for ParaGondermeEkrani.xaml
    /// </summary>
    public partial class ParaGondermeEkrani : Page
    {
        public ParaGondermeEkrani()
        {
            InitializeComponent();

            mevcutBakiyeTxt.Text = DataAccess.Musteri.AccountMoney.ToString();
        }

        public void Gonder_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataAccess.Musteri.AccountMoney>=decimal.Parse(miktarTxt.Text.ToString()))
                {
                    if (DataAccess.HesapNoKontrol(hesapNoTxt.Text.ToString()))
                    {
                        if (DataAccess.ParaGonder(DataAccess.Musteri.AccountNumber,hesapNoTxt.Text.ToString(),decimal.Parse(miktarTxt.Text.ToString())))
                        {
                            MessageBox.Show("Gönderim başarılı oldu.");
                            mevcutBakiyeTxt.Text = DataAccess.Musteri.AccountMoney.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Gönderim başarısız oldu.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gönderilecek hesap numarası hatalıdır.");
                    }
                }
                else
                {
                    MessageBox.Show("Bakiye yetersiz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata =>" + ex.Message.ToString());
            }
        }
    }
}
