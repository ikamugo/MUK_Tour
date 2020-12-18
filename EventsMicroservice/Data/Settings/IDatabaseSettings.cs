using System;
using System.Collections.Generic;
using System.Text;

namespace EventsMicroservice.Data.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string CategoriesCollection { get; set; }
        string EventsCollection { get; set; }
        string PostersCollection { get; set; }
        string VenuesCollection { get; set; }
    }
}
