namespace GraphQL.DataAccess.DAO
{
    public class AuthorHonorarium
    {
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public decimal TotalHonorarium { get; set; }
    }
}
