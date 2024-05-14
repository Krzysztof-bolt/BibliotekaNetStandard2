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

    //dekonstrukotry
    public void Deconstruct(out string? nazwisko, out DateTime dataUrodzenia)
    {
        nazwisko = Nazwisko;
        dataUrodzenia = DataUrodzenia;
    }

    public void Deconstruct(out string? nazwisko, out DateTime dataUrodzenia, out AntyczneCudaSwiata ulubiony)
    {
        nazwisko = Nazwisko;
        dataUrodzenia = DataUrodzenia;
        ulubiony = UlubionyAntycznyCud;
    }
    //Metody przeciazone
    public string PowiedzCzesc()
    {
        return $"{Nazwisko} mowi 'Czesc!'";
    }

    public string PowiedzCzesc(string imie)
    {
        return $"{Nazwisko} mowi 'Czesc, {imie}!'";
    }
    //Metoda z parametrami opcjonalnymi
    public string ParametryOpcjonalne(
        string polecenie = "Biegnij!",
        double liczba = 0.0,
        bool aktywne = true)
    {
        return string.Format(
            format: "polecenie to {0}, liczba to {1}, aktywne to {2}",
            arg0: polecenie,
            arg1: liczba,
            arg2: aktywne);
    }
}
