using Biblioteka;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaWspolna;

public class Osoba
{
    public string Nazwisko;
    public DateTime DataUrodzenia;
    public AntyczneCudaSwiata UlubionyAntycznyCud;
    public List<Osoba> Dzieci = new();
    public const string Gatunek = "Homo sapiens";
    public readonly string Planeta = "Ziemia";
    public readonly DateTime Utworzono;

    //konstruktor

    public Osoba()
    {
        Nazwisko = "Nieznane";
        Utworzono = DateTime.Now;
    }

    public Osoba(string wstepneNazwisko, string wstepnaPlanetaPochodzenia)
    {
        Nazwisko = wstepneNazwisko;
        Planeta = wstepnaPlanetaPochodzenia;
        Utworzono = DateTime.Now;
    }

    public void WypiszWKonsoli()
    {
        WriteLine($"{Nazwisko} urodzil(a) sie w {DataUrodzenia:dddd}");
    }

    public string PodajPochodzenie()
    {
        return $"{Nazwisko} pochodzi z planety {Planeta}";
    }

    public (string, int) WezOwoce()
    {
        return ("Jablka", 5);
    }

    public (string Nazwa, int Liczba) WezNazwaneOwoce()
    {
        return (Nazwa: "Jablka", Liczba: 5);
    }

    //de
}
