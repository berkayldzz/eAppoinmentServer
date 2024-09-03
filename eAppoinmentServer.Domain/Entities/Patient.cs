namespace eAppoinmentServer.Domain.Entities
{
    public sealed class Patient
    {
        // nesne oluşturulduğu an değer atansın diye ctor içinde geçtik.
        public Patient()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string IdentityNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
