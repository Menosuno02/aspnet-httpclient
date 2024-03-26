using Microsoft.EntityFrameworkCore;

namespace aspnet_httpclient.Models
{
    [Keyless]
    public class DistanceMatrixInfo
    {
        public string Distancia { get; set; }
        public int TiempoEstimado { get; set; }
    }
}
