namespace DbOpeationsWithEFCore.Data
{
    public class Currencies
    {
        public int Id { get; set; }
        public string Title { get; set; }


        public ICollection<BookPrices> BookPrices { get; set; }
    }
}
