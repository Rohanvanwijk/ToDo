using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Schaakstuk[,] schaakbord = new Schaakstuk[8, 8];

            InitSchaakbord(schaakbord);
            ToonSchaakbord(schaakbord);
            VerplaatsStukken(schaakbord);

            Console.ReadKey();
        }

        static void InitSchaakbord(Schaakstuk[,] schaakbord)
        {
            // maak schaakbord leeg
            for (int r = 0; r < schaakbord.GetLength(0); r++)
            {
                for (int k = 0; k < schaakbord.GetLength(1); k++)
                {
                    schaakbord[r, k] = null;
                }
            }

            //plaats witte schaakstukken ('bovenaan')
            schaakbord[0, 0] = new Schaakstuk(SchaakstukType.toren, SchaakstukKleur.wit);
            schaakbord[0, 1] = new Schaakstuk(SchaakstukType.paard, SchaakstukKleur.wit);
            schaakbord[0, 2] = new Schaakstuk(SchaakstukType.loper, SchaakstukKleur.wit);
            schaakbord[0, 3] = new Schaakstuk(SchaakstukType.koning, SchaakstukKleur.wit);
            schaakbord[0, 4] = new Schaakstuk(SchaakstukType.koningin, SchaakstukKleur.wit);
            schaakbord[0, 5] = new Schaakstuk(SchaakstukType.loper, SchaakstukKleur.wit);
            schaakbord[0, 6] = new Schaakstuk(SchaakstukType.paard, SchaakstukKleur.wit);
            schaakbord[0, 7] = new Schaakstuk(SchaakstukType.toren, SchaakstukKleur.wit);

            schaakbord[1, 0] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 1] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 2] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 3] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 4] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 5] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 6] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);
            schaakbord[1, 7] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.wit);

            //plaats zwarte schaakstukken ('onderaan')
            schaakbord[7, 0] = new Schaakstuk(SchaakstukType.toren, SchaakstukKleur.zwart);
            schaakbord[7, 1] = new Schaakstuk(SchaakstukType.paard, SchaakstukKleur.zwart);
            schaakbord[7, 2] = new Schaakstuk(SchaakstukType.loper, SchaakstukKleur.zwart);
            schaakbord[7, 3] = new Schaakstuk(SchaakstukType.koning, SchaakstukKleur.zwart);
            schaakbord[7, 4] = new Schaakstuk(SchaakstukType.koningin, SchaakstukKleur.zwart);
            schaakbord[7, 5] = new Schaakstuk(SchaakstukType.loper, SchaakstukKleur.zwart);
            schaakbord[7, 6] = new Schaakstuk(SchaakstukType.paard, SchaakstukKleur.zwart);
            schaakbord[7, 7] = new Schaakstuk(SchaakstukType.toren, SchaakstukKleur.zwart);

            schaakbord[6, 0] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 1] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 2] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 3] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 4] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 5] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 6] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
            schaakbord[6, 7] = new Schaakstuk(SchaakstukType.pion, SchaakstukKleur.zwart);
        }

        static void ToonSchaakbord(Schaakstuk[,] schaakbord)
        {
            // print letter bovenaanschaakbord
            Console.WriteLine("   A  B  C  D  E  F  G  H ");

            // verwerk alle rijen
            for (int r = 0; r < schaakbord.GetLength(0); r++)
            {
                Console.Write("{0} ", r + 1);

                // verwerk alle kolommen
                for (int k = 0; k < schaakbord.GetLength(1); k++)
                {
                    // toggle background color
                    if ((r + k) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Schaakstuk schaakstuk = schaakbord[r, k];
                    if (schaakstuk == null)
                    {
                        Console.Write("   ");
                        continue;
                    }

                    // stel de fontkleur in, afhankelijk van de kleur van het schaakstuk
                    if (schaakstuk.kleur == SchaakstukKleur.wit)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (schaakstuk.kleur == SchaakstukKleur.zwart)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    //print het schaakstuk
                    switch (schaakstuk.type)
                    {
                        case SchaakstukType.pion: Console.Write(" p ");
                            break;
                        case SchaakstukType.toren: Console.Write(" T ");
                            break;
                        case SchaakstukType.paard: Console.Write(" P ");
                            break;
                        case SchaakstukType.loper: Console.Write(" L ");
                            break;
                        case SchaakstukType.koning: Console.Write(" K ");
                            break;
                        case SchaakstukType.koningin: Console.Write(" Q ");
                            break;
                        default: Console.Write("*");
                            break;
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        static void VerplaatsStukken(Schaakstuk[,] schaakbord)
        {
            Positie van;
            Positie naar;
            bool vertaalvan, vertaalnaar;
            while (true)
            {

                Console.WriteLine();
                Console.Write("Verplaats van: ");
                string positie_van = Console.ReadLine();
                vertaalvan = StringToPositie(positie_van, out van);
                

                Console.Write("Verplaats naar: ");
                string positie_naar = Console.ReadLine();
                vertaalnaar = StringToPositie(positie_naar, out naar);

                if (vertaalvan)
                {
                    Schaakstuk schaakstuk = schaakbord[van.rij, van.kolom];
                    try
                    {
                        Console.WriteLine("Er staat een schaakstuk van-positie: " + schaakstuk.type);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Er staat geen schaakstuk op de van-positie.");
                        
                    }
                }

                if ((vertaalvan) && (vertaalnaar))
                {
                    MaakSprong(schaakbord, van, naar);
                    ToonSchaakbord(schaakbord);
                }
                
                
            }
        }

        static bool StringToPositie(string txt, out Positie pos)
        {
            try
            {
                // "A2": A = k0, 2 = r1
                pos.kolom = txt.ToLower()[0] - 'a';
                pos.rij = Int32.Parse(txt[1].ToString()) - 1;
                return true;
            }
            catch (Exception e)
            {
                pos.rij = 0;
                pos.kolom = 0;
                Console.WriteLine("Ongeldige invoer! gebruik A6 ofzo. Error code: " + e.Message);
                return false;
            }
            
        }

        static void MaakSprong(Schaakstuk[,] schaakbord, Positie van, Positie naar)
        {
            
            if (schaakbord[van.rij, van.kolom] != null)
            {
                Schaakstuk schaakstuk = schaakbord[van.rij, van.kolom];
                if (schaakstuk.type == SchaakstukType.paard)
                {
                    Console.WriteLine("ik ben een paard");
                    
                }
                schaakbord[naar.rij, naar.kolom] = schaakbord[van.rij, van.kolom];
                schaakbord[van.rij, van.kolom] = null;
            }
            else
            {
                Console.WriteLine();
            }
           
            
        }

        static bool GeldigePaardZet(Positie van, Positie naar)
        {
            if ()
	        {
                return true;
		 
	        }
           
        }
    }
}
