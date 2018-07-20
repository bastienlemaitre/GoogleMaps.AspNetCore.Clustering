using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleMaps.AspNetCore.Clustering.Data.Geometry;

namespace GoogleMaps.AspNetCore.Clustering.Data
{
    [Serializable]
    internal class DatasetToSerialize : ISerializable
    {
        private const string Name = "Dataset";
        public List<MapPoint> Dataset { get; set; }
        public DatasetToSerialize()
        {
            Dataset = new List<MapPoint>();
        }

        public DatasetToSerialize(SerializationInfo info, StreamingContext context)
        {
            this.Dataset = (List<MapPoint>)info.GetValue(Name, typeof(List<MapPoint>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Name, this.Dataset);
        }
    }
}
