namespace BackendApi.Contracts.User
{
    public class CreateProductRequest
    {
        public int PId { get; set; } //Поле оставлено, так как в базе данных без автоинкремента
        public string PName { get; set; } = null!;
        public int CategotyId { get; set; }
        public decimal Price { get; set; }
       
    }
}
