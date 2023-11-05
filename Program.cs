using FieldFilling.model;
using FieldFilling.util;

class Program
{
    // Ez a lista tartalmazz a számlákat, itt lehetne akár a dataset. Util-ban kerül töltésre
    static List<Invoice> invoices = new();

    // Paraméterezés. Itt adod meg, hogy mely cella milyen hosszú legyen
    const int COLUMN_A_WIDTH = 25;
    const int COLUMN_B_WIDTH = 20;
    const int COLUMN_C_WIDTH = 15;
    const int COLUMN_D_WIDTH = 10;

    // Hiba ág teszteléséhez a fenti D oszlop konstans kommentezd ki és a lenti 2-es unkommentezd
    //const int COLUMN_D_WIDTH = 2;

    static void Main(string[] args)
    {
        // Feltöltjük a számlákat
        invoices = Util.FillInvoices();

        // Kiiratjuk azt a formát melyünk van
        WriteToConsoleOutInvoices();

        // Hibakezelésbe tesszük, mert a FormatColumn-ban hibás paraméterezésre hibát dobunk vissza
        try
        {
            // Itt határozzuk meg az oszlopok szélességét
            FormatColumn();
        }
        catch (Exception ex)
        {
            // Ha a FormatColumn hibát dob, akkor itt írjuk ki (cserélehető message box-ra)
            Console.WriteLine(ex.ToString());
            // Felhasználó értesítése. Itt szokás logolni is valahova, mert nem tudják elmondani, hogy mi történt
            Console.WriteLine("Program futása a fenti hiba miatt megszakadt! Értesítse az IT területett róla!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        // Kiiratjuk azt a formát melyünk van
        WriteToConsoleOutInvoices();

        // Ne lépjen ki magától a terminal ezért kell egy Enter a végén
        Console.ReadKey();
    }

    /// <summary>
    /// Számlákat kiíratjuk
    /// </summary>
    static void WriteToConsoleOutInvoices()
    {
        // Végig megyünk a számlák listán
        foreach (var invoice in invoices)
        {
            // Az adott számlát kiírjuk
            Console.WriteLine(invoice.ToString());
        }
    }

    /// <summary>
    /// Formázzuk mezőket. Cellákhoz itt kerül hozzáfűzésre a szóköz
    /// </summary>
    /// <exception cref="Exception"></exception>
    static void FormatColumn()
    {
        // Végig megyünk a számlákon
        foreach (var invoice in invoices)
        {

            // Ha a kitöltendő mező hossza nagyobb, mint a mező hossza,
            // akkor hibát kell dobni, mert túl fog lógni a megengedett rendelkezésre álló terület mennyiségen
            if ((invoice.ColumnA.Length > COLUMN_A_WIDTH) || (invoice.ColumnB.Length > COLUMN_B_WIDTH) ||
                (invoice.ColumnC.Length > COLUMN_C_WIDTH) || (invoice.ColumnD.Length > COLUMN_D_WIDTH))
            {
                // ERROR HANDLING
                throw new Exception("Field length is greater than the parameterized value");
            }

            // Paraméterben van megadva, hogy egy cella megkorára legyen
            // Paraméterből kivonjuk a mező hosszát, így megkapjuk, hogy mennyi szóközzel tölse fel után a string-et.
            invoice.ColumnA = invoice.ColumnA
                .PadRight(invoice.ColumnA.Length + (COLUMN_A_WIDTH - invoice.ColumnA.Length), ' ');
            invoice.ColumnB = invoice.ColumnB
                .PadRight(invoice.ColumnB.Length + (COLUMN_B_WIDTH - invoice.ColumnB.Length), ' ');
            invoice.ColumnC = invoice.ColumnC
                .PadRight(invoice.ColumnC.Length + (COLUMN_C_WIDTH - invoice.ColumnC.Length), ' ');
            invoice.ColumnD = invoice.ColumnD
                .PadRight(invoice.ColumnD.Length + (COLUMN_D_WIDTH - invoice.ColumnD.Length), ' ');
        }
    }
}
