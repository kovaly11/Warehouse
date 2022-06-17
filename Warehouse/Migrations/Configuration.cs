namespace Warehouse.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Warehouse.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Warehouse.DAL.MagazynContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Warehouse.DAL.MagazynContext context)
        {
            var pracowniks = new List<Pracownik>
            {
                new Pracownik{Imie="Ewa",Nazwisko="Bączek", Telefon="+48 888 999 111"},
                new Pracownik{Imie="Aleksandr",Nazwisko="Lis", Telefon="+48 999 888 777"},
                new Pracownik{Imie="Marcin",Nazwisko="Zając", Telefon="+48 111 222 333"},
                new Pracownik{Imie="Szymon",Nazwisko="Kaminski", Telefon="+48 111 222 444"},
                new Pracownik{Imie="Leon",Nazwisko="Zielinski", Telefon="+48 111 222 555"}

            };
            pracowniks.ForEach(s => context.Pracownik.Add(s));
            context.SaveChanges();

            var adreses = new List<Adres>
            {
                new Adres{Ulica="Krakowska", NrBudynku="20", KodPocztowy="35-210", Miasto="Rzeszow", Kraj="Polska"},
                new Adres{Ulica="Broniewskiego", NrBudynku="1", KodPocztowy="31-801", Miasto="Krakow", Kraj="Polska"},
                new Adres{Ulica="Cinhe-midle street", NrBudynku="68", KodPocztowy="100005", Miasto="Pekin", Kraj="Chiny"},
                new Adres{Ulica="prospekt Nauki", NrBudynku="1", KodPocztowy="03039", Miasto="Kijow", Kraj="Ukraina"},
                new Adres{Ulica="Infinite Loop", NrBudynku="95014", KodPocztowy="10600", Miasto="Cupertino", Kraj="Stany Zjednoczone"},
                new Adres{Ulica="Ofiar Katynia", NrBudynku="15", KodPocztowy="35-959", Miasto="Rzeszow", Kraj="Polska"},
                new Adres{Ulica="1-7-1 Konan", NrBudynku="108", KodPocztowy="0075", Miasto="Tokio", Kraj="Japan"},
                new Adres{Ulica="avenue Nestle", NrBudynku="55", KodPocztowy="1800", Miasto="Vevey", Kraj="Switzerland"},
                new Adres{Ulica="Rejtana", NrBudynku="36", KodPocztowy="35-959", Miasto="Rzeszow", Kraj="Polska"},
                new Adres{Ulica="Jozefa Chelmonskiego", NrBudynku="1", KodPocztowy="35-111", Miasto="Rzeszow", Kraj="Polska"}

            };
            adreses.ForEach(s => context.Adres.Add(s));
            context.SaveChanges();

            var firms = new List<Firma>
            {
                new Firma{ Nazwa ="Mediaexpert", NIP="767-10-04-218", OsobaKontaktowa="Jan Kowalski", Telefon="+48 111 111 111", StonaInternetowa="www.mediaexpert.pl", AdresId=1},
                new Firma{ Nazwa ="Rossmann", NIP="727-00-19-183", OsobaKontaktowa="Michal Nowak", Telefon="+48 111 111 112", StonaInternetowa="www.rossmann.pl", AdresId=2},
                new Firma{ Nazwa ="Biedronka", NIP="779-10-11-327", OsobaKontaktowa="Kacper Wozniak", Telefon="+48 111 111 113", StonaInternetowa="www.biedronka.pl", AdresId=6},
                new Firma{ Nazwa ="MediaMarkt", NIP="113-24-70-708", OsobaKontaktowa="Daniel Mazur", Telefon="48 111 111 114", StonaInternetowa="mediamarkt.pl", AdresId=9},
                new Firma{ Nazwa ="FRAC", NIP="684-00-09-118", OsobaKontaktowa="Rafal Grabowska", Telefon="48 111 111 115", StonaInternetowa="www.frac.pl", AdresId=10},
             };

            firms.ForEach(s => context.Firma.Add(s));
            context.SaveChanges();


            var towars = new List<Towar>
            {
                new Towar{Nazwa="Czekolada mleczna Roshen", NrSerijny="0146286", Wymiary="15x5x0.5 cm", Producent="Roshen"},
                new Towar{Nazwa="Cukierky Wieczerni Kijow", NrSerijny="0146683", Wymiary="20x10x2 cm", Producent="Roshen"},
                new Towar{Nazwa="ROSHEN COMPLIMENT CANDIES", NrSerijny="0148810", Wymiary="20x10x2 cm", Producent="Roshen"},
                new Towar{Nazwa="Telewizor Mi TV 4S 55", NrSerijny="0000001", Wymiary="73x131x7 cm", Producent="Xiaomi"},
                new Towar{Nazwa="Smartfon Mi 10T", NrSerijny="0000001", Wymiary="18X10X5 cm", Producent="Xiaomi"},
                new Towar{Nazwa="Sluchawki Mi True Wireless", NrSerijny="0000003", Wymiary="10x10x5 cm", Producent="Xiaomi"},
                new Towar{Nazwa="Laptop MacBook Air i5-5350U", NrSerijny="873695", Wymiary="40x25x10 cm", Producent="Apple"},
                new Towar{Nazwa="Smartfon iPhone 11 64GB", NrSerijny="366471", Wymiary="18x10x5 cm", Producent="Apple"},
                new Towar{Nazwa="Zegarki Watch 6 44mm", NrSerijny="348521", Wymiary="20x7x4 cm", Producent="Apple"},
                new Towar{Nazwa="Konsola PlayStation 4 Slim", NrSerijny="882061", Wymiary="50x40x15 cm", Producent="Sony"},
                new Towar{Nazwa="Smartfon Xperia 5 II", NrSerijny="343594", Wymiary="18x10x5 cm", Producent="Sony"},
                new Towar{Nazwa="Telewizor LED KD-55XH9505BAEP", NrSerijny="307419", Wymiary="120x70x15 cm", Producent="Sony"},
                new Towar{Nazwa="Kulki czekoladowe Nesquik DUO", NrSerijny="12156089", Wymiary="5х19х27 cm", Producent="Nestle"},
                new Towar{Nazwa="Tabliczka czekolady KitKat", NrSerijny="12236295", Wymiary="9x10x3 cm", Producent="Nestle"},
                new Towar{Nazwa="Tabliczka czekolady Nuts", NrSerijny="12266035", Wymiary="9x3x3 cm", Producent="Nestle"},

            };

            towars.ForEach(s => context.Towar.Add(s));
            context.SaveChanges();

            var dokuments = new List<Dokument>
            {
                new Dokument{ PracownikId =3, FirmaId=5, DokumentDate = DateTime.Parse("2021-05-28"), Typ = "PT"},
                new Dokument{ PracownikId =1, FirmaId=3, DokumentDate = DateTime.Parse("2021-05-28"), Typ = "PT"},
                new Dokument{ PracownikId =4, FirmaId=4, DokumentDate = DateTime.Parse("2021-05-28"), Typ = "PT"},
                new Dokument{ PracownikId =5, FirmaId=5, DokumentDate = DateTime.Parse("2021-05-28"), Typ = "RT"},
                new Dokument{ PracownikId =2, FirmaId=1, DokumentDate = DateTime.Parse("2021-05-28"), Typ = "RT"}
            };
            dokuments.ForEach(s => context.Dokument.Add(s));
            context.SaveChanges();

            var pozycji = new List<Pozycja>
            {
                new Pozycja { DokumentId=1, NrPozycji=1, TowarId=1, Ilosc=10 },
                new Pozycja { DokumentId=1, NrPozycji=2, TowarId=14, Ilosc=40 },
                new Pozycja { DokumentId=1, NrPozycji=3, TowarId=15, Ilosc=20 },
                new Pozycja { DokumentId=1, NrPozycji=4, TowarId=3, Ilosc=25 },
                new Pozycja { DokumentId=2, NrPozycji=1, TowarId=2, Ilosc=15 },
                new Pozycja { DokumentId=2, NrPozycji=2, TowarId=13, Ilosc=60 },
                new Pozycja { DokumentId=3, NrPozycji=1, TowarId=4, Ilosc=5 },
                new Pozycja { DokumentId=3, NrPozycji=2, TowarId=5, Ilosc=18 },
                new Pozycja { DokumentId=3, NrPozycji=3, TowarId=6, Ilosc=35 },
                new Pozycja { DokumentId=3, NrPozycji=4, TowarId=7, Ilosc=15 },
                new Pozycja { DokumentId=3, NrPozycji=5, TowarId=8, Ilosc=32 },
                new Pozycja { DokumentId=3, NrPozycji=6, TowarId=9, Ilosc=46 },
                new Pozycja { DokumentId=3, NrPozycji=7, TowarId=10, Ilosc=10 },
                new Pozycja { DokumentId=3, NrPozycji=8, TowarId=11, Ilosc=16 },
                new Pozycja { DokumentId=3, NrPozycji=9, TowarId=12, Ilosc=7 },
                new Pozycja { DokumentId=4, NrPozycji=1, TowarId=2, Ilosc=5 },
                new Pozycja { DokumentId=4, NrPozycji=2, TowarId=3, Ilosc=6 },
                new Pozycja { DokumentId=4, NrPozycji=3, TowarId=15, Ilosc=12 },
                new Pozycja { DokumentId=4, NrPozycji=4, TowarId=13, Ilosc=17 },
                new Pozycja { DokumentId=5, NrPozycji=1, TowarId=4, Ilosc=4 },
                new Pozycja { DokumentId=5, NrPozycji=2, TowarId=6, Ilosc=20 },
                new Pozycja { DokumentId=5, NrPozycji=3, TowarId=7, Ilosc=11 },
                new Pozycja { DokumentId=5, NrPozycji=4, TowarId=10, Ilosc=7 },
                new Pozycja { DokumentId=5, NrPozycji=5, TowarId=12, Ilosc=7 }
            };

            pozycji.ForEach(s => context.Pozycja.Add(s));
            context.SaveChanges();

        }
    }
}