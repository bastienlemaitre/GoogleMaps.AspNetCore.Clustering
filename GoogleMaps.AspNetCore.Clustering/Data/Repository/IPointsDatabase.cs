using System.Collections.Generic;
using GoogleMaps.AspNetCore.Clustering.Data.Geometry;

namespace GoogleMaps.AspNetCore.Clustering.Contract
{
    public interface IPointsDatabase
    {
        IList<MapPoint> GetPoints();
    }
}
