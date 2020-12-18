using System;
using System.Collections.Generic;
using System.Text;

namespace EventsMicroservice.Data.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string CategoriesCollection { get; set; }
        public string EventsCollection { get; set; }
        public string PostersCollection { get; set; }
        public string VenuesCollection { get; set; }
    }
}
