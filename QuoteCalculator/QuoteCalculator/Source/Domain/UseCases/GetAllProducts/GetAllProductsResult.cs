namespace QuoteCalculator.Source.Domain.UseCases.GetAllProducts
{
    public class GetAllProductsResult
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool HasInterest { get; set; }
        public string Duration { get; set; }
    }
}
