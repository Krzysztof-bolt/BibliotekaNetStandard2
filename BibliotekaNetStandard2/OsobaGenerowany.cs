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

}
