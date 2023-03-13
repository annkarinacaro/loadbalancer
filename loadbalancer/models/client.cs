namespace loadbalancer.models
{
    public class Client
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool IsComplete { get; set; }
    }
}
