
namespace BusStopCalculator.DTO.Models;

public class BusStationLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long? ZoneId { get; set; }
    public LocationType LocationType { get; set; }
}