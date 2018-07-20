# GoogleMaps.AspNetCore.Clustering
C# library for clustering map points for AspNetCore 2.1

![Clustering Img](https://raw.githubusercontent.com/bastienlemaitre/GoogleMaps.AspNetCore.Clustering/master/cluster-map.png "clustering image")

**Original Lib**  
This is a fork of [GoogleMaps.Net.Clustering
](https://github.com/pootzko/GoogleMaps.Net.Clustering) repo. The project was no longer powered since December 8, 2016 and incompatible with dotnetcore.

**Installation**  

You can download the [GoogleMaps.AspNetCore.Clustering](https://www.nuget.org/packages/GoogleMaps.AspNetCore.Clustering/) package to install the latest version of GoogleMaps.AspNetCore.Clustering Lib.

## Usage

First, configure `Startup.cs` class:
```cs
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseGmc(Configuration.GetSection("GoogleMapsNetClustering"));
        ...
    }
}

```
You will also need to add the following section to your `appsettings.json` file.

```json
"GoogleMapsNetClustering": {
    "DoShowGridLinesInGoogleMap": false,
    "OuterGridExtend": 0,
    "DoUpdateAllCentroidsToNearestContainingPoint": false,
    "DoMergeGridIfCentroidsAreCloseToEachOther": true,
    "CacheServices": true,
    "MergeWithin": 2.9,
    "MinClusterSize": 2,
    "MaxMarkersReturned": 500,
    "AlwaysClusteringEnabledWhenZoomLevelLess": 2,
    "ZoomlevelClusterStop": 15,
    "GridX": 6,
    "GridY": 5,
    "MarkerTypes": [1,2,3],
    "MaxPointsInCache": 100000000
  },
```

Next, this is an example of how to used cached clustering.
```cs
public IList<MapPoint> GetClusters(YourFilterObj filter)
{
    string clusterPointsCacheKey = "somecachekey";
    PointCollection points = GetClusterPointCollection(clusterPointsCacheKey);

    ClusterService mapService = new ClusterService(points);
    GetMarkersParams markersParams = new GetMarkersParams()
    {
        NorthEastLatitude = filter.NorthEastLatitude,
        NorthEastLongitude = filter.NorthEastLongitude,
        SouthWestLatitude = filter.SouthWestLatitude,
        SouthWestLongitude = filter.SouthWestLongitude,
        ZoomLevel = filter.ZoomLevel,
        PointType = clusterPointsCacheKey
    };

    ClusterMarkersResponse markers = mapService.GetClusterMarkers(input);

    return markers.Markers;
}

private PointCollection GetClusterPointCollection(string clusterPointsCacheKey)
{
    PointCollection points = new PointCollection();
    if (points.Exists(clusterPointsCacheKey))
        return points;

    var dbPoints = GetPoints(); // Get your points here
    List<MapPoint> points = dbPoints.Select(p => new MapPoint() { X = p.X, Y = p.Y }).ToList();
    TimeSpan cacheDuration = TimeSpan.FromHours(6);
    points.Set(points, cacheDuration, clusterPointsCacheKey);

    return points;
}
```
