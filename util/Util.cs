using FieldFilling.model;

namespace FieldFilling.util
{
    static class Util
    {

        internal static List<Invoice> FillInvoices()
        {
            // Ez a lista tartalmazz a számlákat (átmenetileg, míg visszaküldjük a Main-be)
            List<Invoice> invoices = new List<Invoice>();

            // Létrehozzunk egy számlát (ez jöhetne adatbázisból is)
            invoices.Add(new Invoice("12", "1234", "123456", "12345678"));
            invoices.Add(new Invoice("12345678", "123456", "1234", "12"));
            invoices.Add(new Invoice("12", "12", "12", "12"));
            invoices.Add(new Invoice("123456", "123456", "123456", "123456"));
            invoices.Add(new Invoice("12", "12345678", "12345678", "12"));

            return invoices;
        }
    }
}
