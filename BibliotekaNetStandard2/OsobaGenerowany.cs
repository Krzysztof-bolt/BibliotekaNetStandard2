using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaWspolna;

public partial class Osoba
{
    //właściowści definiowane przy użyciu składni C# 1-5
    public string Pochodzenie
    {
        get
        {
            return $"{Nazwisko} pochodzi z planety {Planeta}";
        }
    }

    //dwie właściwości zdefiniowane przy użyciu wyrażeń lambda z C# 6+

    public string Pozdrowienie => $"{Nazwisko} mowi 'Czesc!'";
    public int Wiek => System.DateTime.Today.Year - DataUrodzenia.Year;

    //wlasciwosci z mozliwoscia przypisania

    public string UlubioneLody { get; set; }
    private string? ulubionyKolorPodstawowy;
    public string? UlubionyKolorPodstawowy
    {
        get
        {
            return ulubionyKolorPodstawowy;
        }

        set
        {
            switch (value.ToLower())
            {
                case "czerwony":
                case "zielony":
                case "niebieski":
                    ulubionyKolorPodstawowy = value;
                    break;
                default:
                    throw new System.ArgumentException($"{value} nie jest kolorem podstawowym. Wybieraj spośród wartości: czerwony, zielony, niebieski.");
            }
        }
    }

    //indeksery
    public Osoba this[int indeks]
    {
        get
        {
            return Dzieci[indeks];
        }
        set
        {
            Dzieci[indeks] = value;
        }
    }

    public Osoba this[string nazwisko] 
    {
        get
        {
            return Dzieci.Find(o => o.Nazwisko == nazwisko);
        }
        set
        {
            Osoba znalezione = Dzieci.Find(p => p.Nazwisko == nazwisko);
            if (znalezione is not null) znalezione = value;
        }
    }

    //Implementownie dzialan w metodzie

    private bool poSlubie = false;
    public bool PoSlubie => poSlubie;

    private Osoba? malzonek = null;
    public Osoba? Malzonek => malzonek;

    //statyczna metoda zawarcia malzenstwa

    public static void Poslub(Osoba o1, Osoba o2)
    {
        o1.Poslub(o2);
    }

    //metoda zawarcia malzenstwa dla obiektu

    public void Poslub(Osoba partner) 
    {
        if (poSlubie) return;
        malzonek = partner;
        poSlubie = true;
        partner.Poslub(this); //this oznacza aktualny obiekt
    }

    //statyczna metoda "rozmnazania"
    public static Osoba Prokreacja(Osoba o1, Osoba o2)
    {
        /*if(o1.Malzonek != o2)
        {
            throw new ArgumentException("Tylko malzonkowie moga sie rozmanzac");
        }*/

        Osoba dziecko = new()
        {
            Nazwisko = $"Dziecko osob {o1.Nazwisko} i {o2.Nazwisko}",
            DataUrodzenia = DateTime.Now,
        };

        o1.Dzieci.Add(dziecko);
        o2.Dzieci.Add(dziecko);

        return dziecko;
    }

    //rozmanzanie metoda obiektu
    public Osoba ProkreacjaZ(Osoba partner)
    {
        return Prokreacja(this, partner);
    }

    //opertaor zaslubin

    public static bool operator +(Osoba o1 , Osoba o2)
    {
        Poslub(o1 , o2);
        return o1.PoSlubie && o2.PoSlubie; // potwoerdz aze dwie osoby sa zaslubione
    }

    //opretor rozmanzania

    public static Osoba operator *(Osoba o1, Osoba o2)
    {
        return Osoba.Prokreacja(o1 , o2);
    }

    //metoda z funkcja lolakna

    public static int Silnia(int liczba)
    {
        if (liczba < 0) 
        {
            throw new ArgumentException($"{nameof(liczba)} nie moze byc mniejsza od zera.");

        }
        return lokalnaSilnia(liczba);
    

    int lokalnaSilnia(int lokalnaLiczba) //funkcja lokalna 
    {
        if (lokalnaLiczba == 0) return 1;
        return lokalnaLiczba * lokalnaSilnia(lokalnaLiczba - 1);
    }
    }

}
