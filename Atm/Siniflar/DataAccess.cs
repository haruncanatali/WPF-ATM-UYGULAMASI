using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Siniflar
{
    public static class DataAccess
    {
        public static string path = @"E:\derscalismalarim\GitHub Ornek Gelistirme Klasoru\Atm\AtmDatabase.txt";
        public static Account Musteri=null;
        public static List<Account> MusteriListesi;

        public static bool GirisKontrol(string hesapAdi, string hesapSifre)
        {
            if (File.Exists(path))
            {
                StreamReader okuyucu = new StreamReader(path);
                string[] hesap;
                while (!okuyucu.EndOfStream)
                {
                    hesap = (okuyucu.ReadLine()).Split('#');
                    if (hesap[4].ToString() == hesapAdi && hesap[5].ToString() == hesapSifre)
                    {
                        GirisYap(hesap);
                        okuyucu.Close();
                        return true;
                    }
                }
                okuyucu.Close();
                return false;
            }
            else
            {
                return false;
            }
        }
        
        public static bool ParaGonder(string mevcutHesap,string gonderilecekHesap,decimal miktar)
        {
            StringBuilder dosyaDuzenleyici = new StringBuilder();
            string temp = "";
            string[] dosyaIcerik = File.ReadAllLines(path, Encoding.GetEncoding(1254));

            foreach (string satir in dosyaIcerik)
            {
                string[] words = satir.Split('#');
                if (words[4] == mevcutHesap)
                {
                    temp = words[0] + "#" + words[1] + "#" + words[2] + "#" + (decimal.Parse(words[3]) - miktar) + "#" + words[4] + "#" + words[5];
                    dosyaDuzenleyici.Append(temp + "\r\n");
                }
                else if (words[4] == gonderilecekHesap)
                {
                    temp = words[0] + "#" + words[1] + "#" + words[2] + "#" + (decimal.Parse(words[3]) + miktar) + "#" + words[4] + "#" + words[5];
                    dosyaDuzenleyici.Append(temp + "\r\n");
                }
                else
                {
                    dosyaDuzenleyici.Append(satir + "\r\n");
                }
            }

            File.WriteAllText(path, dosyaDuzenleyici.ToString());
            MusteriGuncelle(mevcutHesap);
            return true;
        }

        public static void MusteriGuncelle(string hesapNo)
        {
            StreamReader okuyucu = new StreamReader(path);
            string[] hesap;
            while (true)
            {
                try
                {
                    hesap = (okuyucu.ReadLine()).Split('#');
                    if (hesap[4].ToString() == hesapNo)
                    {
                        okuyucu.Close();
                        GirisYap(hesap);
                        break;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            okuyucu.Close();
        }

        public static bool HesapNoKontrol(string hesapAdi)
        {
            StreamReader okuyucu = new StreamReader(path);
            string[] hesap;
            while (!okuyucu.EndOfStream)
            {
                hesap = (okuyucu.ReadLine()).Split('#');
                if (hesap[4].ToString() == hesapAdi )
                {
                    okuyucu.Close();
                    return true;
                }
            }
            okuyucu.Close();
            return false;
        }

        private static void GirisYap(string[] dizi)
        {
            Musteri = new Account
            {
                Id = int.Parse(dizi[0].ToString()),
                Name = dizi[1].ToString(),
                Surname = dizi[2].ToString(),
                AccountMoney = decimal.Parse(dizi[3].ToString()),
                AccountNumber = dizi[4].ToString(),
                AccountPassword = dizi[5].ToString()
            };
        }

        public static void ParaYatir(decimal miktar)
        {
            MusteriListesiYukle();


            foreach (var item in MusteriListesi)
            {
                if (item.AccountNumber == Musteri.AccountNumber)
                {
                    item.AccountMoney += miktar;
                }
            }

            MusterileriYazdir();
            MusteriGuncelle(Musteri.AccountNumber.ToString());
        }

        private static void MusterileriYazdir()
        {

            TextWriter tw = new StreamWriter(path);
            tw.Write("");
            tw.Close(); 

            if (MusteriListesi.Count()>0)
            {
                StreamWriter yazici = new StreamWriter(path);
                foreach (var account in MusteriListesi)
                {
                    yazici.WriteLine(
                         
                        account.Id.ToString()+"#"+
                        account.Name+"#"+
                        account.Surname+"#"+
                        account.AccountMoney.ToString()+"#"+
                        account.AccountNumber+"#"+
                        account.AccountPassword
                        );
                }
                yazici.Close();
            }
        }

        private static void MusteriListesiYukle()
        {
            MusteriListesi = new List<Account>();
            StreamReader okuyucu = new StreamReader(path);
            string[] satir=new string[MusteriListesi.Count];
            while (!okuyucu.EndOfStream)
            {
                satir = (okuyucu.ReadLine()).Split('#');
                MusteriListesi.Add(new Account
                {
                    Id = int.Parse(satir[0].ToString()),
                    Name = satir[1].ToString(),
                    Surname = satir[2].ToString(),
                    AccountMoney = decimal.Parse(satir[3].ToString()),
                    AccountNumber = satir[4].ToString(),
                    AccountPassword = satir[5].ToString()
                });
            }
            okuyucu.Close();
        }

        public static void HesapEkle(string hesapNo,string hesapSifre,string ad,string soyad)
        {
            MusteriListesiYukle();

            int id = MusteriListesi[MusteriListesi.Count() - 1].Id + 1;

            MusteriListesi.Add(new Account
            {
               Id = id,
               AccountNumber = hesapNo,
               AccountPassword = hesapSifre,
               AccountMoney = 0,
               Name = ad,
               Surname = soyad
            });

            MusterileriYazdir();
        }

        public static void HesapSil(string hesapNo)
        {
            MusteriListesiYukle();
            var entity = new Account();
            foreach (var item in MusteriListesi)
            {
                if (item.AccountNumber == hesapNo)
                {
                    entity = item;
                }
            }

            MusteriListesi.Remove(entity);

            MusterileriYazdir();
        }

        public static void CikisYap()
        {
            Musteri = null;
        }
    }
}
