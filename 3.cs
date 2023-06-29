using System;

enum KlasaRzadkosci
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

struct Przedmiot
{
    public float Waga;
    public int Wartosc;
    public KlasaRzadkosci Rzadkosc;
    public TypPrzedmiotu Typ;
    public string NazwaWlasna;

    public void WypelnijPrzedmiot(float waga, int wartosc, KlasaRzadkosci rzadkosc, TypPrzedmiotu typ, string nazwaWlasna)
    {
        Waga = waga;
        Wartosc = wartosc;
        Rzadkosc = rzadkosc;
        Typ = typ;
        NazwaWlasna = nazwaWlasna;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine("Przedmiot: " + NazwaWlasna);
        Console.WriteLine("Typ: " + Typ);
        Console.WriteLine("Rzadkosc: " + Rzadkosc);
        Console.WriteLine("Waga: " + Waga);
        Console.WriteLine("Wartosc: " + Wartosc + " sztuk zlota");
        Console.WriteLine("-------------------------");
    }
}

class Program
{
    static Random random = new Random();

    static Przedmiot LosujPrzedmiot(Przedmiot[] przedmioty)
    {
        int losowaIndeks = random.Next(przedmioty.Length);
        return przedmioty[losowaIndeks];
    }

    static Przedmiot LosujPrzedmiotZRzadkoscia(Przedmiot[] przedmioty)
    {
        int losowaIndeks = random.Next(przedmioty.Length);
        Przedmiot przedmiot = przedmioty[losowaIndeks];

        switch (przedmiot.Rzadkosc)
        {
            case KlasaRzadkosci.Powszechny:
                if (random.NextDouble() < 0.8)
                    return przedmiot;
                break;
            case KlasaRzadkosci.Rzadki:
                if (random.NextDouble() < 0.5)
                    return przedmiot;
                break;
            case KlasaRzadkosci.Unikalny:
                if (random.NextDouble() < 0.2)
                    return przedmiot;
                break;
            case KlasaRzadkosci.Epicki:
                if (random.NextDouble() < 0.1)
                    return przedmiot;
                break;
        }

        return LosujPrzedmiotZRzadkoscia(przedmioty);
    }

    static void Main()
    {
        Przedmiot[] przedmioty = new Przedmiot[4];

        przedmioty[0].WypelnijPrzedmiot(1.5f, 10, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Bron, "Miecz");
        przedmioty[1].WypelnijPrzedmiot(2.0f, 50 , KlasaRzadkosci.Rzadki, TypPrzedmiotu.Zbroja, “Zbroja płytowa”);
przedmioty[2].WypelnijPrzedmiot(0.5f, 100, KlasaRzadkosci.Unikalny, TypPrzedmiotu.Amulet, “Amulet mocy”);
przedmioty[3].WypelnijPrzedmiot(0.8f, 200, KlasaRzadkosci.Epicki, TypPrzedmiotu.Helm, “Helm nieśmiertelności”);

    Przedmiot wylosowanyPrzedmiot = LosujPrzedmiotZRzadkoscia(przedmioty);
    wylosowanyPrzedmiot.WyswietlInformacje();

    Console.ReadKey();
}

}
