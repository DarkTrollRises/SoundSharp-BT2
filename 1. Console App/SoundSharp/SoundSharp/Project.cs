using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Soundsharp
{
    class LSystem
    {
        public static ArrayList mp3lijst1 = new ArrayList();
        public struct Producten
        {
            public int id;
            public string make;
            public string model;
            public double mbsize;
            public double price;
            public int voorraad;

        }
        public static List<Producten> mp3lijst = new List<Producten>
        {
                        new Producten {id = 1, make = "GET technologies .inc", model = "HF 410", mbsize = 4096, price = 129.95, voorraad = 500}, // product 1
                        new Producten {id = 2, make = "Far & Loud", model = "XM 600", mbsize = 8192, price = 224.95, voorraad = 500}, // product 2
                        new Producten {id = 3, make = "Innotivative", model = "Z3", mbsize = 512, price = 79.95, voorraad = 500}, // product 3
                        new Producten {id = 4, make = "Resistance S.A.", model = "3001", mbsize = 4096, price = 124.95, voorraad = 500}, // product 4
                        new Producten {id = 5, make = "CBA", model = "NXT volume", mbsize = 2048, price = 159.05, voorraad = 500}  //product 5
        };




        //
        // Login menu
        //
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i + " " + args[i]);
                if (args[0] == "TEST" && args[1] == "SHARPSOUND")
                {
                    Console.Clear();

                    Console.WriteLine("Ik haat jouw {0}.", args[0]);
                    adminmenu();
                }
                else
                {
                    i = args.Length + 1;
                }
             }
            

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**************************** Welkom bij SoundSharp ****************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int j = 1; j < 4; j++)
            {
                Console.Write("Voer uw gebruikersnaam in: ");
                string username = Console.ReadLine();
                string usernameT = "TEST";
                if (username == usernameT || username == "s")
                {
                    for (int i = 1; i < 4; i++)
                    {
                        Console.Write("Voer uw wachtwoord in: ");
                        string password = Console.ReadLine();
                        string passwordT = "SHARPSOUND";
                        j = 5;
                        if (password == passwordT || password == "s")
                        {
                            i = 5;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Inlog succesvol! Welkom " + username + "! Druk op ENTER om verder te gaan.");
                            Console.ReadLine();

                            hoofdmenu();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wachtwoord klopt niet. Poging " + i + "/3 mislukt.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deze gebruikersnaam bestaat niet. Poging " + j + "/3 mislukt.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        //
        //Hoofdmenu
        //

        static void hoofdmenu()
        {
            Console.Clear();
            bool inMenu = true;
            int nummer = 1;
            while (inMenu == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("**************************** SoundSharp Hoofdmenu ****************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("Gebruik de pijltjestoetsen om door het menu te navigeren.");
                Console.WriteLine();

                if (nummer == 1) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[1] Overzicht MP3-Spelers");
                if (nummer == 2) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[2] Overzicht Voorraad");
                if (nummer == 3) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[3] Muteer Voorraad");
                if (nummer == 4) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[4] Statistieken");
                if (nummer == 5) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[5] Toevoegen MP3-speler");
                if (nummer == 6) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[6] _____________");
                if (nummer == 7) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[7] _____________");
                if (nummer == 8) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[8] _____________");
                if (nummer == 9) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[9] Programma afsluiten");

              

                ConsoleKeyInfo keuze = Console.ReadKey();
                if (keuze.Key == ConsoleKey.Escape) { afsluiten(); }
                if (keuze.Key == ConsoleKey.Enter)
                {
                    switch (nummer)
                    {
                        case (1):
                            overzicht();
                            break;
                        case (2):
                            voorraad();
                            break;
                        case (3):
                            muteer();
                            break;
                        case (4):
                            statistieken();
                            break;
                        case (5):
                            toevoegen();
                            break;
                        case (9):
                            afsluiten();
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hier is nog niks! Druk op ENTER om terug te gaan naar het hoofdmenu.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.ReadLine();
                            hoofdmenu();
                            break;
                    }
                }
                else if (nummer == 1)
                {
                    if (keuze.Key == ConsoleKey.DownArrow) { nummer++; }
                    else if (keuze.Key == ConsoleKey.UpArrow && nummer == 1) { nummer = 9; }
                    else { }
                }
                else if (nummer == 9)
                {
                    if (keuze.Key == ConsoleKey.UpArrow) { nummer--; }
                    else if (keuze.Key == ConsoleKey.DownArrow && nummer == 9) { nummer = 1; }
                    else { }
                }
                else if (keuze.Key == ConsoleKey.UpArrow) { nummer--; }
                else if (keuze.Key == ConsoleKey.DownArrow) { nummer++; }
                else { }
            }
        }

        //
        // OPTIE 1: Overzicht MP3-Spelers
        //


        public static void overzicht()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("************************** [1] Overzicht MP3-Spelers **************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            for (int i = 0; i < mp3lijst.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].id);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Merk:      "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].make);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Model:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].model);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("MBsize:    "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].mbsize + "MB");
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Prijs:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("$" + mp3lijst[i].price);
                Console.WriteLine();
            }
            Console.WriteLine("Druk op ESC om terug te gaan naar het hoofdmenu.");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.Escape) { hoofdmenu(); }
            else { overzicht(); }


        }
        //
        // OPTIE 2: Overzicht Voorraad
        //
        public static void voorraad()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("************************** [2] Voorraad MP3-Spelers **************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            for (int i = 0; i < mp3lijst.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].id);
                Console.ForegroundColor = ConsoleColor.White; Console.Write("Voorraad:  "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].voorraad + " stuks");
                Console.WriteLine();


            }
         
            Console.WriteLine();
            Console.WriteLine("Druk op ESC om terug te gaan naar het hoofmenu.");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.Escape) { hoofdmenu(); }
            else { voorraad(); }
        }
        //
        // OPTIE 3: Muteer Voorraad
        // AANGEPAST
        //

        public static void muteer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***************************** [3] Muteer Voorraad *****************************");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.Write("Voer ID van aan te passen product in: ");
            String idvragen = Console.ReadLine();

            int mutatie_id = 0;
            bool bij_mutatie = false;
            try
            {
                for (int i = 0; i < mp3lijst.Count; i++)
                {
                    if (mp3lijst[i].id == Convert.ToInt32(idvragen))
                    {
                        bij_mutatie = true;
                        muteer_vraag(i);
                        mutatie_id = i;
                    }
                }
                if (mutatie_id == mp3lijst.Count)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dit ID bestaat niet. Probeer het opnieuw.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    muteer();
                }
            }
            catch
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Foutmelding. Probeer het opnieuw.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                if (bij_mutatie)
                {
                    muteer_vraag(mutatie_id);
                }
                else
                {
                    muteer();
                }
            }
        }

        private static void muteer_vraag(int i)
        {
            try
            {
                Console.Write("Voer de mutatie aan de voorraad in: ");
                int mp3_voor = Convert.ToInt32(Console.ReadLine());
                int mp3_voor_nieuw = mp3lijst[i].voorraad + mp3_voor;
                if (mp3_voor_nieuw >= 0)
                {
                    Producten id_verander = new Producten();
                    id_verander.id = mp3lijst[i].id;
                    id_verander.make = mp3lijst[i].make;
                    id_verander.model = mp3lijst[i].model;
                    id_verander.mbsize = mp3lijst[i].mbsize;
                    id_verander.price = mp3lijst[i].price;
                    id_verander.voorraad = mp3_voor_nieuw;
                    mp3lijst[i] = id_verander;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("De voorraad van ID " + mp3lijst[i].id +
                                      " is succesvol veranderd naar " + mp3_voor_nieuw);
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    i = mp3lijst.Count + 1;
                }
                else
                {
                    //i = mp3lijst.Count + 1;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("De voorraad kan niet negatief zijn. Probeer het opnieuw.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    muteer_vraag(i);
                    //muteer();
                }
            }
            catch
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Foutmelding. Probeer het opnieuw.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                muteer_vraag(i);
            }
        }
        //
        // OPTIE 4: Statistieken
        //
        public static void statistieken()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************* [4] Statistieken *******************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();


            int totaalmp3 = 0; 

            foreach (Producten var in mp3lijst) 
            {
                totaalmp3 += var.voorraad;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Totale voorraad MP3-Spelers:             ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(totaalmp3 + " stuks");

            double totaalwaarde = 0;

            foreach (Producten var in mp3lijst)
            {
                totaalwaarde += var.voorraad * var.price;
            }



            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Totale waarde MP3-Spelers:               ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("$ " + totaalwaarde);

            double gemiddeldeprijs = 0;

            foreach (Producten var in mp3lijst)
            {
                gemiddeldeprijs += var.price / mp3lijst.Count; 
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Gemiddelde Prijs:                        ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("$ " + gemiddeldeprijs);

            double prijspermb = 0;

            foreach (Producten var in mp3lijst)
            {
                prijspermb += var.price / var.mbsize;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Prijs per MB:                            ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("$ " + prijspermb);
            Console.WriteLine();
            Console.WriteLine("Druk op ESC om terug te gaan naar het hoofmenu.");
            ConsoleKeyInfo keuze = Console.ReadKey();
            if (keuze.Key == ConsoleKey.Escape) { hoofdmenu(); }
            else { statistieken(); }
        }
        //
        // OPTIE 5: Product Toevoegen
        // AANGEPAST
        //
        public static void toevoegen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************** [5] Toevoegen MP3-speler ***************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            int nieuwid = 0;
            string nieuwmake = "";
            string nieuwmodel = "";
            double nieuwmbsize = 0;
            double nieuwprice = 0;
          
            nieuwid = mp3lijst.Count + 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Geef merk nieuwe MP3:        ");
            Console.ForegroundColor = ConsoleColor.Gray;
            nieuwmake = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Geef model nieuwe MP3:       ");
            Console.ForegroundColor = ConsoleColor.Gray;
            nieuwmodel = Console.ReadLine();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Geef MBsize nieuwe MP3:      ");
                Console.ForegroundColor = ConsoleColor.Gray;
                try
                {
                    //prod.mbsize = Convert.ToDouble(Console.ReadLine());
                    nieuwmbsize = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er kunnen alleen cijfers ingevoerd worden. Probeer het opnieuw");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    //hoofdmenu();
                }

                if (nieuwmbsize != 0)
                    break;
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Geef Prijs nieuwe MP3:       ");
                Console.ForegroundColor = ConsoleColor.Gray;
                try
                {
                    nieuwprice = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er kunnen alleen cijfers ingevoerd worden. Probeer het opnieuw");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    //hoofdmenu();
                }

                if (nieuwprice != 0)
                    break;
            }

            mp3lijst.Add( new Producten { id = nieuwid, make = nieuwmake, model = nieuwmodel, mbsize = nieuwmbsize, price = nieuwprice, voorraad = 0 });

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nieuw product succesvol toegevoegd.");
            Console.WriteLine("U kunt het product bekijken of de voorraad aanpassen in de andere opties.");
            Console.WriteLine("Druk op een toets om terug te gaan naar het hoofdmenu.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }

        //
        // OPTIE 9: Afsluiten
        //
        static void afsluiten()
        {
            Console.Clear();
            bool inMenu = true;
            int nummer = 1;
            while (inMenu == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*************************** [9] Programma afsluiten ***************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("Weet u zeker dat u wilt afsluiten?");
                Console.WriteLine();

                if (nummer == 1) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[Ja]");
                if (nummer == 2) { Console.ForegroundColor = ConsoleColor.Green; } else { Console.ForegroundColor = ConsoleColor.Gray; } Console.WriteLine("[Nee]");

                ConsoleKeyInfo keuze = Console.ReadKey();
                if (keuze.Key == ConsoleKey.Escape) { Environment.Exit(0); }
                if (keuze.Key == ConsoleKey.Enter)
                {
                    switch (nummer)
                    {
                        case (1):
                            Environment.Exit(0);
                            break;
                        case (2):
                            hoofdmenu();
                            break;
                    }
                }
                else if (nummer == 1)
                {
                    if (keuze.Key == ConsoleKey.DownArrow) { nummer++; }
                    else if (keuze.Key == ConsoleKey.UpArrow && nummer == 1) { nummer = 2; }
                    else { }
                }
                else if (nummer == 2)
                {
                    if (keuze.Key == ConsoleKey.UpArrow) { nummer--; }
                    else if (keuze.Key == ConsoleKey.DownArrow && nummer == 2) { nummer = 1; }
                    else { }
                }
                else if (keuze.Key == ConsoleKey.UpArrow) { nummer--; }
                else if (keuze.Key == ConsoleKey.DownArrow) { nummer++; }
                else { }
            }
        }
        public static void adminmenu()
        {
            for (int z = 0; z == 0; )
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("**************************** Welkom in Admin modus ****************************");
                Console.WriteLine("*******************************************************************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("************************** [1] Overzicht MP3-Spelers **************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();

                for (int i = 0; i < mp3lijst.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].id);
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Merk:      "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].make);
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Model:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].model);
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("MBsize:    "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].mbsize + "MB");
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Prijs:     "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("$" + mp3lijst[i].price);
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("************************** [2] Voorraad MP3-Spelers **************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();

                for (int i = 0; i < mp3lijst.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("ID:        "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].id);
                    Console.ForegroundColor = ConsoleColor.White; Console.Write("Voorraad:  "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(mp3lijst[i].voorraad + " stuks");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("******************************* [4] Statistieken *******************************");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();


                int totaalmp3 = 0;

                foreach (Producten var in mp3lijst)
                {
                    totaalmp3 += var.voorraad;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Totale voorraad MP3-Spelers:             ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(totaalmp3 + " stuks");

                double totaalwaarde = 0;

                foreach (Producten var in mp3lijst)
                {
                    totaalwaarde += var.voorraad * var.price;
                }



                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Totale waarde MP3-Spelers:               ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("$ " + totaalwaarde);

                double gemiddeldeprijs = 0;

                foreach (Producten var in mp3lijst)
                {
                    gemiddeldeprijs += var.price / mp3lijst.Count;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Gemiddelde Prijs:                        ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("$ " + gemiddeldeprijs);

                double prijspermb = 0;

                foreach (Producten var in mp3lijst)
                {
                    prijspermb += var.price / var.mbsize;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Prijs per MB:                            ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("$ " + prijspermb);
                Console.WriteLine();

                Console.WriteLine("Druk op ESC om af te sluiten.");
                ConsoleKeyInfo keuze = Console.ReadKey();
                if (keuze.Key == ConsoleKey.Escape) { Environment.Exit(0); }
                else { adminmenu(); }
            }

        }
    }
}
