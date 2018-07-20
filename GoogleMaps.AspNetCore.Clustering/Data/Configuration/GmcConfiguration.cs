using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace GoogleMaps.AspNetCore.Clustering.Data.Configuration
{
    public static class GmcConfiguration
    {
        public static void UseGmc(this IApplicationBuilder app, IConfigurationSection settingsSection)
        {
            Settings = settingsSection.Get<GmcSettings>();
        }

        private static GmcSettings Settings { get; set; }

        public static GmcSettings Get {
            get {
                return Settings ?? new GmcSettings();
            }
        }
    }
}
