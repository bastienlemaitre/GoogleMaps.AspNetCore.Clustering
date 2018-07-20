using GoogleMaps.AspNetCore.Clustering.Data.Params;
using GoogleMaps.AspNetCore.Clustering.Data.Responses;

namespace GoogleMaps.AspNetCore.Clustering.Services
{
    public interface IClusterService
    {        
        ClusterMarkersResponse GetClusterMarkers(GetMarkersParams getParams);

        MarkerInfoResponse GetMarkerInfo(int uid, string pointType = null);
    }
}
