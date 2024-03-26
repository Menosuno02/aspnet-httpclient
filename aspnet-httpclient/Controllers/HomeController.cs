using aspnet_httpclient.Helpers;
using aspnet_httpclient.Models;
using aspnet_httpclient.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_httpclient.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryRestaurantes repo;
        private HelperGoogleApiDirections helperGoogleApi;

        public HomeController(RepositoryRestaurantes repo, HelperGoogleApiDirections helperGoogleApi)
        {
            this.repo = repo;
            this.helperGoogleApi = helperGoogleApi;
        }

        public async Task<IActionResult> Index(string? nuevaDireccion)
        {
            List<RestauranteView> restaurantes = await this.repo.GetRestaurantesViewAsync();
            string direccion = "Calle Mayor 12, Madrid";
            if (nuevaDireccion != null)
                direccion = await this.helperGoogleApi.GetValidatedDireccionAsync(nuevaDireccion);
            ViewData["DIRECCION"] = direccion;
            var tasks = restaurantes
                .Select(async r => r.InfoEntrega = await this.helperGoogleApi
                    .GetDistanceMatrixInfoAsync(r.Direccion, direccion));
            await Task.WhenAll(tasks);
            return View(restaurantes);
        }
    }
}
