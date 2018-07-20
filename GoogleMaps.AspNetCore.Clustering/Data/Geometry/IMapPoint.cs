namespace GoogleMaps.AspNetCore.Clustering.Data.Geometry
{
    public interface IMapPoint
    {
        double X { get ; }

        double Y { get; }

        int Count { get; }

        int MarkerId { get; }

        int MarkerType { get; }
    }
}
