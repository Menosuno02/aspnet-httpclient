using aspnet_httpclient.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_httpclient.Data
{
    public class RestaurantesContext : DbContext
    {
        public RestaurantesContext(DbContextOptions<RestaurantesContext> options) : base(options) { }

        public DbSet<RestauranteView> RestaurantesView { get; set; }
    }
}
