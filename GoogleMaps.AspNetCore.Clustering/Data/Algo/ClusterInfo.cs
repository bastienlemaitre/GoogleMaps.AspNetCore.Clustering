﻿namespace GoogleMaps.AspNetCore.Clustering.Data.Algo
{
    internal static class ClusterInfo
    {
        // Don't filter when zoomed far out, because user json receive swlon and nelon values "jumps" to next overlapping lon point
        // and the program can't know from what to filter. 
        // e.g. Is it from 160 to -160 or 160 to -160+360  ??  lon value 10 is filtered out in first case but should be included in 2nd case
        // heuristic and is based on html width value

        // Set a higher zoomlevel value if you increase the html window size. This works with width 800px, height 600px
        public static bool DoFilterData(int zoomlevel)
        {
            return zoomlevel >= 3;
        }
    }
}
