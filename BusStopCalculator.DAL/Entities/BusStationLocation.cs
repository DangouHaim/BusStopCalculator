using CsvHelper.Configuration.Attributes;

namespace BusStopCalculator.DAL.Entities;

public class BusStationLocation
{
    [Name("stop_lat")]
    public double Latitude { get; set; }

    [Name("stop_lon")]
    public double Longitude { get; set; }

    [Name("zone_id")]
    public long? ZoneId { get; set; }

    [Name("location_type")]
    public LocationType LocationType { get; set; }
}