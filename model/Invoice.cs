namespace FieldFilling.model
{
    internal class Invoice
    {
        public string ColumnA { get; set; }
        public string ColumnB { get; set; }
        public string ColumnC { get; set; }
        public string ColumnD { get; set; }

        // Konstrúktor. Ezt használjuk az Util-ban példányosításnál
        public Invoice(string columnA, string columnB, string columnC, string columnD)
        {
            this.ColumnA = columnA;
            this.ColumnB = columnB;
            this.ColumnC = columnC;
            this.ColumnD = columnD;
        }

        // Felül írjuk a ToString() metódust, így ezen osztály kiírása a lenti szerint fog történni
        public override string? ToString()
        {
            return ColumnA + '|' + ColumnB + '|' + ColumnC + '|' + ColumnD + '|';
        }
    }
}
