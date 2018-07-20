using System.Collections.Generic;
using GoogleMaps.AspNetCore.Clustering.Data.Geometry;

namespace GoogleMaps.AspNetCore.Clustering.Data.Responses
{
    public class ClusterMarkersResponse : ResponseBase
    {                 
        public IList<MapPoint> Markers { get; set; } // markers or clusters

        public IList<Line> Polylines { get; set; } // google map draw lines

        public int Count {get { return Markers.Count;} } // returned n markers

        public int Mia { get; set; } // truncated markers due to json restriction (missing in action)

        public ClusterMarkersResponse()
        {
            Markers = new List<MapPoint>();
            Polylines = new List<Line>();
        }
    }
}
