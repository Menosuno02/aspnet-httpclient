using aspnet_httpclient.Data;
using aspnet_httpclient.Helpers;
using aspnet_httpclient.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_httpclient.Repositories
{
    public class RepositoryRestaurantes
    {
        private RestaurantesContext context;
        private HelperGoogleApiDirections helperGoogleApi;

        public RepositoryRestaurantes
            (RestaurantesContext context,
            HelperGoogleApiDirections helperGoogleApi)
        {
            this.context = context;
            this.helperGoogleApi = helperGoogleApi;
        }

        public async Task<List<RestauranteView>> GetRestaurantesViewAsync()
        {
            List<RestauranteView> restaurantes = await this.context.RestaurantesView
                .OrderByDescending(r => r.Valoracion)
                .ToListAsync();
            return restaurantes;
        }
    }
}
