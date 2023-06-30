using System;

enum Plec
{
    Meszczyzna,
    Kobieta
}

struct Student
{
    public string Nazwisko;
    public int NumerAlbumu;
    public float Ocena;
    public Plec Plec;
}

class Program
{
    static void Main()
    {
        Student[] studenci = new Student[5];

        for (int i = 0; i < studenci.Length; i++)
        {
            Console.WriteLine($"Student {i + 1}:");
            WypelnijDaneStudenta(ref studenci[i]);
            Console.WriteLine();
        }

        Console.WriteLine("Studenci:");
        foreach (var student in studenci)
        {
            WyswietlInformacjeOStudencie(student);
        }

        float sredniaOcena = ObliczSredniaOcene(studenci);
        Console.WriteLine($"\nŚrednia ocena: {sredniaOcena}");

        Console.ReadLine();
    }

    static void WypelnijDaneStudenta(ref Student student)
    {
        Console.Write("Nazwisko: ");
        student.Nazwisko = Console.ReadLine();

        Console.Write("Numer albumu: ");
        student.NumerAlbumu = int.Parse(Console.ReadLine());

        Console.Write("Ocena: ");
        float ocena = float.Parse(Console.ReadLine());
        student.Ocena = Math.Max(2.0f, Math.Min(5.0f, ocena));

        Console.Write("Płeć (Meszczyzna/Kobieta): ");
        string plecInput = Console.ReadLine();
        student.Plec = Enum.Parse<Plec>(plecInput, ignoreCase: true);
    }

    static float ObliczSredniaOcene(Student[] studenci)
    {
        float suma = 0;
        foreach (var student in studenci)
        {
            suma += student.Ocena;
        }

        return suma / studenci.Length;
    }

    static void WyswietlInformacjeOStudencie(Student student)
    {
        Console.WriteLine($"Nazwisko: {student.Nazwisko}, " +
                          $"Numer albumu: {student.NumerAlbumu}, " +
                          $"Ocena: {student.Ocena}, " +
                          $"Płeć: {student.Plec}");
    }
}
