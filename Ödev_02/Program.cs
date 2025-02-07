using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class Program
{
    private static void Main(string[] args)
    {
        /*
          Screen Numbers ( goto lokasyonları )
         _100 : ana menü
         _300 : masa açma ekranı
         _400 : Menüden yemek seçme ekranı  
        _600: Şifre Ekranı
         */



        #region Variables
        ConsoleKeyInfo cki;
        int secim = 0, masaCount = 5, counter = 1,
            counter2 = 7, urunSayisi = 0, secim2, eklenecekMasa = 0, personelpassword, cost = 0, tempCost = 0;
        int[] masaTutarlar = new int[masaCount * 10];

        bool orderExitStatus = true, isStartedOrderProcessBefore = true;
        bool[] masaDurumu = new bool[masaCount * 10];


        string masaAdisyonu = "", tempMasaAdisyonu = "";
        string errorMessage = "";
        string border = "--------------------";
        string[] masaAdisyonları = new string[masaCount * 10];

        string[] cook = { "Et Döner", "Et Sote ", "İskender" };
        int[] cookPrice = { 450, 600, 550 };

        string[] pizza = { "Margarita Pizza", "Marinara Pizza ", "Kavurmalı Pizza" };
        int[] pizzaPrice = { 350, 450, 500 };

        string[] hotDrink = { "Çay", "Türk Kahvesi", "Sıcak Çikolata" };
        int[] hotDrinkPrice = { 30, 75, 95 };

        string[] cldDrink = { "Su", "Kola", "Fanta" };
        int[] cldDrinkPrice = { 20, 75, 75 };
    #endregion

    _600:
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("              ------------ DARA PLUS YAZILIM ------------");
        Console.WriteLine();
        Console.WriteLine("Dara Plus Adisyona Hoşgeldiniz.");
        Console.WriteLine();

        while (true)
        {

            Console.Write("Lütfen Personel Şifrenizi Giriniz:");
            personelpassword = int.Parse(Console.ReadLine());
            if (personelpassword == 727234)
            {
                Console.WriteLine("Başarıyla Giriş Yapıldı.");
                break;
            }
            else
            {
                Console.WriteLine("Hatalı Şifre Girildi.Lütfen Tekrar Deneyiniz.");
            }

        }



        while (true)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        #region MenuList
        _100:
            Console.Clear();
            Console.WriteLine("ForFixConsoleProblem");
            Console.Clear();

            Console.WriteLine($"{border} ANA MENÜ {border}");

            Console.WriteLine("--------------------------------------------------- ");

            Console.WriteLine("Masa Aç        [1]");
            Console.WriteLine("Masa İşlem     [2]");
            Console.WriteLine("Masa Hesap     [3]");
            Console.WriteLine("Kasa İşlemleri [4]");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("ÇIKIŞ YAP      [0]");
            Console.WriteLine("-----------------------------------------------------");
            #endregion

            #region MenuPanelChoose
            while (true)
            {
                try
                {

                    Console.Write("Lütfen Seçiminizi Yapınız: ");
                    secim = int.Parse(Console.ReadLine());

                    if (secim < 0 || secim > 4)
                    {
                        Console.WriteLine("Geçersiz seçim! Lütfen 0-4 arasında bir değer giriniz.");
                        continue;
                    }

                    Console.Clear();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen Geçerli Bir Rakam Giriniz.");
                }
            }
            #endregion

            switch (secim)
            {

                case 1:
                _300:
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("                 MASA AÇ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine();

                    for (int i = 0; i < masaCount; i++)
                    {
                        string durum = masaDurumu[i] ? "[Dolu]" : "[Boş]";
                        Console.WriteLine($"{i + 1}. Masa {durum}");

                    }

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("ANA MENÜ [ESC] DEVAM [ANYKEY]");
                    Console.WriteLine("-----------------------------------");



                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        continue;
                    }

                    Console.Write($"Masa Açmak İçin Masa Numarasını Giriniz:");
                    int secilenMasa = int.Parse(Console.ReadLine());

                    masaDurumu[secilenMasa - 1] = true;

                    if (secilenMasa >= 1 && secilenMasa <= masaCount)
                    {

                        Console.Clear();

                    _400:
                        masaAdisyonu = "";

                        while (true)

                        {
                            try
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine("               MASA AÇ   ");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("                   * MENÜ *");
                                Console.WriteLine("  ---YEMEKLER---                    ---İÇECEKLER--- ");
                                Console.WriteLine();
                                Console.Write("   -ET YEMEKLERİ-                     -SICAK İÇECEKLER-");
                                Console.WriteLine();

                                counter = 1;
                                counter2 = 7;
                                for (int i = 0; i < cook.Length; i++)
                                {
                                    Console.WriteLine($"  {counter}.{cook[i]}:{cookPrice[i]}TL                   {counter2}.{hotDrink[i]}:{hotDrinkPrice[i]}TL");
                                    counter++;
                                    counter2++;

                                }
                                Console.WriteLine();
                                Console.Write("   -PİZZALAR-                          -SOĞUK İÇECEKLER-");
                                Console.WriteLine();

                                for (int i = 0; i < pizza.Length; i++)
                                {
                                    Console.WriteLine($" {counter}.{pizza[i]}:{pizzaPrice[i]}TL             {counter2}.{cldDrink[i]}:{cldDrinkPrice[i]}TL");
                                    counter++;
                                    counter2++;
                                }

                                //MENÜ FİYAT LİSTESİ
                                string[] urunler = new string[cook.Length + pizza.Length + hotDrink.Length + cldDrink.Length];



                                Console.WriteLine($"--------------- {secilenMasa}. MASA ADİSYONU ---------------");
                                Console.WriteLine(masaAdisyonları[secilenMasa - 1] + masaAdisyonu);
                                Console.WriteLine("------------------------------------------------------------");
                                Console.WriteLine("ONAYLA   [SPACE]");
                                Console.WriteLine("ANA MENÜ   [ESC]");
                                Console.WriteLine("GERİ GİT  [LEFT ARROW]");
                                Console.WriteLine("DEVAM  [OTHER KEYS]");
                                Console.WriteLine("------------------------------------------------------------");

                                cki = Console.ReadKey(true);
                                switch (cki.Key)
                                {
                                    case ConsoleKey.Spacebar:
                                        masaAdisyonları[secilenMasa - 1] += masaAdisyonu;
                                        masaTutarlar[secilenMasa - 1] += cost;
                                        masaAdisyonu = "";
                                        cost = 0;
                                        goto _300;
                                    case ConsoleKey.Escape:
                                        masaAdisyonu = "";
                                        tempCost = 0;
                                        goto _100;
                                    case ConsoleKey.A:
                                        masaAdisyonu = "";
                                        tempCost = 0;
                                        goto _300;
                                }

                                // Ürün seçme




                                Console.WriteLine();
                                Console.WriteLine("Ürün Eklemek İçin Ürün ID Giriniz (Çıkmak İçin 0 Giriniz)");
                                Console.Write("Seçiminizi yapınız: ");
                                secim2 = int.Parse(Console.ReadLine());
                                if (secim2 == 0)
                                {
                                    Console.Clear();
                                    goto _400;
                                }


                                if (secim2 <= cook.Length)
                                {
                                    tempMasaAdisyonu += $"{cook[secim2 - 1]} - {cookPrice[secim2 - 1]} TL";
                                    tempCost += cookPrice[secim2 - 1];

                                }
                                else if (secim2 <= pizza.Length + cook.Length)
                                {
                                    if (secim2 % pizza.Length != 0) secim2 = secim2 % pizza.Length;
                                    if (secim2 != 0) secim2 -= 1;
                                    if (secim2 > pizza.Length) secim2 = pizza.Length - 1;

                                    tempMasaAdisyonu += $"{pizza[secim2]} - {pizzaPrice[secim2]} TL";
                                    tempCost += pizzaPrice[secim2];
                                }
                                else if (secim2 <= hotDrink.Length + pizza.Length + cook.Length)
                                {
                                    if (secim2 % hotDrink.Length != 0) secim2 = secim2 % hotDrink.Length;
                                    if (secim2 != 0) secim2 -= 1;
                                    if (secim2 > hotDrink.Length) secim2 = hotDrink.Length - 1;

                                    tempMasaAdisyonu += $"{hotDrink[secim2]} - {hotDrinkPrice[secim2]} TL";
                                    tempCost += hotDrinkPrice[secim2];
                                }
                                else if (secim2 <= cldDrink.Length + hotDrink.Length + pizza.Length + cook.Length)
                                {

                                    if (secim2 % cldDrink.Length != 0) secim2 = secim2 % cldDrink.Length;
                                    if (secim2 != 0) secim2 -= 1;
                                    if (secim2 > cldDrink.Length) secim2 = cldDrink.Length - 1;


                                    tempMasaAdisyonu += $"{cldDrink[secim2]} - {cldDrinkPrice[secim2]} TL";
                                    tempCost += cldDrinkPrice[secim2];
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz seçim,lütfen tekrar deneyin.");
                                    continue;
                                }

                                masaAdisyonu += "\n";
                                masaAdisyonu += tempMasaAdisyonu;
                                cost += tempCost;
                                tempMasaAdisyonu = "";
                                tempCost = 0;
                                urunSayisi++;
                            }

                            catch (FormatException)
                            {
                                Console.WriteLine("Lütfen Geçerli Bir Sayı Değeri Giriniz!!!");
                                continue;
                            }

                        }



                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz Masa Numarası Geçersiz.Lütfen Tekrar Deneyiniz.");
                        goto _300;
                    }
                case 2:
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("                 MASA İŞLEM");
                        Console.WriteLine("--------------------------------------");

                        if (errorMessage != "")
                        {
                            Console.WriteLine(errorMessage);
                        }


                        Console.Write("Kaç Masa Açmak İstiyorsunuz:");
                        eklenecekMasa = int.Parse(Console.ReadLine());

                        if (masaCount + eklenecekMasa > 50)
                        {
                            errorMessage = "Hata : Maksimum Masa Sayısı 49`dur. Açılabilecek masa sayısı : " + (50 - masaCount);
                        }
                        else
                        {
                            bool[] yeniMasaDurumu = new bool[masaCount + eklenecekMasa];
                            for (int i = 0; i < masaCount; i++)
                            {
                                yeniMasaDurumu[i] = masaDurumu[i];

                            }
                            masaCount += eklenecekMasa;
                            masaDurumu = yeniMasaDurumu;

                            Console.WriteLine($"{eklenecekMasa} Masa Eklendi.Toplam Masa Sayınız:{masaCount}");
                            Console.WriteLine("------------------------------------------------------------");
                            Console.Write("ANA MENÜ [ESC] DEVAM [ANYKEY]");
                            cki = Console.ReadKey(true);
                            if (cki.Key == ConsoleKey.Escape)
                            {
                                goto _100;
                            }
                        }

                    }

                case 3:
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("                 MASA HESAP");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("\nDOLU MASALAR VE ADİSYONLARI:\n");

                    for (int i = 0; i < masaCount; i++)
                    {
                        if (masaDurumu[i])
                        {
                            Console.WriteLine($"\n {i + 1}. Masa [Dolu]");
                            Console.WriteLine("--------------------");

                        }
                    }

                    Console.Write("Adisyonunu Görmek İstediğiniz Masayı Seçiniz:");
                    int additionselection = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("                 MASA HESAP");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();


                    Console.WriteLine(
                        $"--------------- {additionselection}. MASA ADİSYONU ---------------");
                    Console.WriteLine(masaAdisyonları[additionselection - 1]);
                    Console.WriteLine("Toplam:" + masaTutarlar[additionselection - 1] + "tl");
                    Console.WriteLine("------------------------------------------------------------");
                    Thread.Sleep(5000);
                    goto _100;
                case 4:

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("                 KASA İŞLEMLERİ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("\nÖDEME YAPILACAK MASAYI SEÇİNİZ:\n");

                    for (int i = 0; i < masaCount; i++)
                    {
                        if (masaDurumu[i])
                        {
                            Console.WriteLine($"\n {i + 1}. Masa [Dolu] - Adisyon : {masaTutarlar[i]} TL");
                            Console.WriteLine("--------------------");

                        }
                    }

                    try
                    {
                        if (masaDurumu.Where(x => x == true).FirstOrDefault())
                        {
                            Console.Write("Ödeme Yapılacak Masa Numarası : ");
                            int tableId = int.Parse(Console.ReadLine());

                            if (!(masaTutarlar[tableId - 1] == null || masaTutarlar[tableId - 1] == 0))
                            {
                                Console.Write("Ödeme Yapılacak Tutar : ");
                                int paidAmount = int.Parse(Console.ReadLine());
                                masaTutarlar[tableId - 1] = masaTutarlar[tableId - 1] - paidAmount;
                                

                                if (masaTutarlar[tableId - 1] == 0)
                                {
                                    Console.WriteLine("Masa Hesabı Ödendi.");
                                    Console.Clear();
                                    Console.WriteLine("Ödeme Yapıldı ...");

                                    Thread.Sleep(5000);
                                }

                                if (masaTutarlar[tableId - 1] <= 0)
                                {
                                    masaDurumu[tableId - 1] = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hata Böyle Bir Masa Yok Ana Menüye Dönülüyor  ...");

                                Thread.Sleep(3500);
                            }

                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Hata Böyle Bir Masa Yok Ana Menüye Dönülüyor  ...");

                        Thread.Sleep(3500);

                    }
                   

                    goto _100;

                case 0:

                    goto _600;
            }
        }

    }
}