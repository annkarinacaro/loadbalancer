using Microsoft.EntityFrameworkCore;

namespace loadbalancer.models
{
    public class loadbalancerContext : DbContext
    {


        public loadbalancerContext(DbContextOptions<loadbalancerContext> options)
        : base(options)
        {
        }

        public DbSet<Client> ClientItems { get; set; } = null!;


    }
}
