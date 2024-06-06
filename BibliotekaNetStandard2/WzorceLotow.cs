using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekaWspolna;

public class Pasazer
{
    public string? Nazwisko { get; set; }
}

public class PasazerKlasyBiznesowej : Pasazer
{
    public override string ToString()
    {
        return $"{Nazwisko}, Klasa biznesowa";
    }
}

public class PasazerKlasyPierwszej : Pasazer
{
    public int Mile { get; set; }
    public override string ToString()
    {
        return $"{Nazwisko}, Klasa pierwsza i {Mile:N0} mil";
    }
}

public class PasazerKlasyEkonomicznej : Pasazer
{
    public double BagazPodreczny { get; set; }
    public override string ToString()
    {
        return $"{Nazwisko}, Klasa ekonomiczna z bagazem {BagazPodreczny:N2} kg";
    }
}
