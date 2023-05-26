namespace BackendApi.Contracts.Product
{
    public class GetProductResponse
    {
        public int PId { get; set; }
        public string PName { get; set; } = null!;
        public int CategotyId { get; set; }
        public decimal Price { get; set; }
    }
}
