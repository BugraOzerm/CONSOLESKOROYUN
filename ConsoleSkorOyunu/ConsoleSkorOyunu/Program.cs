using System;
using System.IO;
using System.Threading;

namespace ConsoleSkorOyunu
{
    class Program
    {
      
        static int genislik = 30;
        static int yukseklik = 20;

       
        static int oyuncuX, oyuncuY;
        static int objeX, objeY;
        static string objeSembolu = "*";

        static int skor = 0;
        static bool oyunBitti = false;
        static int maksimumSkor = 50;
        static int kalanSure = 30; 

       
        static string logDosyaYolu = "oyun_loglari.txt";
        static Random rastgele = new Random();

        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;
            Console.WindowWidth = genislik + 2;
            Console.WindowHeight = yukseklik + 5;

            
            oyuncuX = genislik / 2;
            oyuncuY = yukseklik - 2;
            YeniObjeOlustur();

          
            File.WriteAllText(logDosyaYolu, " OYUN BASLADI \n");

            
            DateTime baslangicZamani = DateTime.Now;

            
            while (!oyunBitti)
            {
                
                int gecenSure = (int)(DateTime.Now - baslangicZamani).TotalSeconds;
                kalanSure = 30 - gecenSure;

                if (kalanSure <= 0)
                {
                    OyunBitir("Zaman Doldu");
                    break;
                }

                EkraniCiz();
                GirdiAl();
                OyunMantigi();

                
                Thread.Sleep(100);
            }

            Console.Clear();
            Console.WriteLine(" OYUN BITTI ");
            Console.WriteLine("Toplam Skor: " + skor);
            Console.WriteLine("Cikmak icin bir tusa basin...");
            Console.ReadKey();
        }

        static void EkraniCiz()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Skor: {skor} / {maksimumSkor}   Sure: {kalanSure} sn    ");
            Console.WriteLine(new string('-', genislik));

            for (int y = 0; y < yukseklik; y++)
            {
                for (int x = 0; x < genislik; x++)
                {
                    if (x == oyuncuX && y == oyuncuY)
                    {
                        Console.Write("@");
                    }
                    else if (x == objeX && y == objeY)
                    {
                        Console.Write(objeSembolu);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|"); 
            }
            Console.WriteLine(new string('-', genislik)); 
        }

        static void GirdiAl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tus = Console.ReadKey(true);

                int eskiX = oyuncuX;
                int eskiY = oyuncuY;

                if (tus.Key == ConsoleKey.LeftArrow && oyuncuX > 0) oyuncuX--;
                else if (tus.Key == ConsoleKey.RightArrow && oyuncuX < genislik - 1) oyuncuX++;
                else if (tus.Key == ConsoleKey.UpArrow && oyuncuY > 0) oyuncuY--;
                else if (tus.Key == ConsoleKey.DownArrow && oyuncuY < yukseklik - 1) oyuncuY++;

                
                if (eskiX != oyuncuX || eskiY != oyuncuY)
                {
                    LogYaz($"INPUT -> key={tus.Key} playerX={oyuncuX} playerY={oyuncuY}");
                    LogYaz($"UPDATE -> playerMoved oldX={eskiX} oldY={eskiY} newX={oyuncuX} newY={oyuncuY}");
                }
            }
        }

        static void OyunMantigi()
        {
            objeY++;
            LogYaz($"UPDATE -> itemMoved x={objeX} y={objeY}");

            LogYaz($"COLLISION_CHECK -> player(x:{oyuncuX},y:{oyuncuY}) item(x:{objeX},y:{objeY})");

            if (oyuncuX == objeX && oyuncuY == objeY)
            {
                skor += 10;
                LogYaz($"COLLISION -> score={skor}");
                YeniObjeOlustur();

                if (skor >= maksimumSkor)
                {
                    OyunBitir("Maksimum Skora Ulasildi");
                }
            }
            else if (objeY >= yukseklik)
            {
                YeniObjeOlustur();
            }
        }

        static void YeniObjeOlustur()
        {
            objeX = rastgele.Next(0, genislik);
            objeY = 0;

            objeSembolu = rastgele.Next(0, 2) == 0 ? "*" : "O";

            LogYaz($"UPDATE -> itemSpawned symbol={objeSembolu} x={objeX} y={objeY}");
        }

        static void OyunBitir(string sebep)
        {
            oyunBitti = true;
            LogYaz($"GAME_OVER -> finalScore={skor} reason={sebep}");
        }

        static void LogYaz(string mesaj)
        {
            using (StreamWriter sw = File.AppendText(logDosyaYolu))
            {
                sw.WriteLine(mesaj);
            }
        }
    }
}