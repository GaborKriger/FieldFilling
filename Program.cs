

using FieldFilling.model;
using FieldFilling.util;

class Program
{
    // Ez a lista tartalmazz a számlákat
    static List<Invoice> invoices = new();

    static void Main(string[] args)
    {
        // Adatbázisból kiszelektáljuk a számlákat
        invoices = FillInvoices();

        // Kiiratjuk azt a formát melyünk van
        WriteToConsole();

        // Itt határozzuk meg az oszlopok szélességét
        FormatColumnWidthFifteenCharacterWithoutParameter();

        // Kiiratjuk azt a formát melyünk van
        WriteToConsole();

        // Ne lépjen ki magától a terminal ezért kell egy Enter a végén
        Console.ReadKey();
    }


    static List<Invoice> FillInvoices()
    {
        // Itt beégetett feltötlés van, de ide jönne az SQL connection rész
        return Util.FillInvoces();
    }

    static void WriteToConsole()
    {
        // Végig megyünk a számlák listán
        foreach (var invoice in invoices)
        {
            // Az adott számlát kiírjuk
            Console.WriteLine(invoice.ToString());
        }
    }
    static void FormatColumnWidthFifteenCharacterWithoutParameter()
    {
        // Végig megyünk a számlákon
        foreach (var invoice in invoices)
        {
            // Az adott mező hosszához hozzáadjuk a teljes kívánt cellahosz mínusz mező hosszt szóközökkel feltöltve.
            invoice.ColumnA = invoice.ColumnA.PadRight(invoice.ColumnA.Length + (15 - invoice.ColumnA.Length), ' ');
            invoice.ColumnB = invoice.ColumnB.PadRight(invoice.ColumnB.Length + (15 - invoice.ColumnB.Length), ' ');
            invoice.ColumnC = invoice.ColumnC.PadRight(invoice.ColumnC.Length + (15 - invoice.ColumnC.Length), ' ');
            invoice.ColumnD = invoice.ColumnD.PadRight(invoice.ColumnD.Length + (15 - invoice.ColumnD.Length), ' ');

            // Ha paraméterezni szeretnéd akkor a 15 helyett végig kell olvasni a szótárt és az ottani key - value páros
            // alapján kell meghatározni, hogy megkorára kell kihúzni az adott cellát
        }
    }
}
