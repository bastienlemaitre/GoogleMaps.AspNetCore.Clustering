using System.Collections.Generic;
using GoogleMaps.AspNetCore.Clustering.Data.Geometry;

namespace GoogleMaps.AspNetCore.Clustering.Algorithm
{
    internal interface IGridCluster
    {
        IList<MapPoint> RunCluster();

        IList<Line> GetPolyLines(); // Google Maps debug lines
    }
}
