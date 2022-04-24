namespace OAuthOidc.Data.PersistedGrants
{
    public class PersistedGrant
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string ClientId { get; set; }
        public DateTime Expiration { get; set; }
        public string Data { get; set; }
    }
}
