
namespace BusStopCalculator.DTO.Models;

public class BusStationLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long? ZoneId { get; set; }
    public LocationType LocationType { get; set; }

    public static BusStationLocation operator -(BusStationLocation left, BusStationLocation right)
    {
        return new BusStationLocation
        {
            Latitude = left.Latitude - right.Latitude,
            Longitude = left.Longitude - right.Longitude,
        };
    }

    public static BusStationLocation operator +(BusStationLocation left, BusStationLocation right)
    {
        return new BusStationLocation
        {
            Latitude = left.Latitude + right.Latitude,
            Longitude = left.Longitude + right.Longitude,
        };
    }
}