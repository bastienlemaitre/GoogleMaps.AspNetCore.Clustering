using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using GoogleMaps.AspNetCore.Clustering.Contract;

namespace GoogleMaps.AspNetCore.Clustering.Data.Configuration
{
    /// <summary>
    /// Configurations data
    /// Readonly fields
    /// Data are parsed from a config file
    /// </summary>
    public class GmcSettings : IGmcSettings
    {
        // Use debug data
        public bool DoShowGridLinesInGoogleMap { get; set; } // generate draw grid lines info to google map

        // How much data that is send to client
        // EDIT to extend to widen or shorten gridview for outside view, must be minimum 0
        // default value is 1 which returns same data as illustrated in the picture from my blog
        // (see googlemaps-clustering-viewport_ver1.png inside the Docements/Design folder)
        public int OuterGridExtend { get; set; }

        // Move centroid point to nearest existing point?
        public bool DoUpdateAllCentroidsToNearestContainingPoint { get; set; } 
        
        // Merge clusterpoints if close to each other?
        public bool DoMergeGridIfCentroidsAreCloseToEachOther { get; set; } 
        
        // Cache get markers and get markers info services
        public bool CacheServices { get; set; }

        // If neighbor cluster is within 1/n dist then merge, heuristic, higher value gives less merging
        public double MergeWithin { get; set; }

        // Only cluster if minimum this number of points
        public int MinClusterSize { get; set; }

        // If clustering is disabled, restrict number of markers returned
        public int MaxMarkersReturned { get; set; }

        // Always cluster if equal or below this zoom level
        // to disable this effect set the value to -1
        public int AlwaysClusteringEnabledWhenZoomLevelLess { get; set; }

        // Stop clustering from this zoom level and larger
        public int ZoomlevelClusterStop { get; set; }

        // Grid array
        public int GridX { get; set; }
        public int GridY { get; set; }

        // Array of existing marker types
        public HashSet<int> MarkerTypes { get; set; }

        // Max allowed points in memory cache
        public int MaxPointsInCache { get; set; }
    
        public string Environment { get; set; }     
    }
}