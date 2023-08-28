using BusStopCalculator.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusStopCalculator.BLL.Services;

public interface IBusStationCalculationService
{
    double GetDistanceBetweenStation(BusStation stationFrom, BusStation stationTo);
}

public class BusStationCalculationService : IBusStationCalculationService
{
    private const double PiOverHundred = Math.PI / 100;

    // Radius of the earth in km
    private const int EarthRadius = 6371;

    public double GetDistanceBetweenStation(BusStation stationFrom, BusStation stationTo)
    {
        var locationDelta = stationTo.Location - stationFrom.Location;
        var latitudeFromInRadians = stationFrom.Location.Latitude * PiOverHundred;
        var latitudeToInRadians = stationTo.Location.Latitude * PiOverHundred;

        return CalculateDistance(locationDelta.Latitude, locationDelta.Longitude, latitudeFromInRadians,
            latitudeToInRadians);
    }

    private double CalculateDistance(double latitudeDelta, double longitudeDelta, double latitudeFromInRadians,
        double latitudeToInRadians)
    {
        // The formula is equivalent to calculation below - h = sin²(Δlat/2) + cos(lat1) * cos(lat2) * sin²(Δlon/2)
        var haversine = Math.Pow(Math.Sin(latitudeDelta / 2), 2) + Math.Cos(latitudeFromInRadians)
            * Math.Cos(latitudeToInRadians) * Math.Pow(Math.Sin(longitudeDelta / 2), 2);

        var distance = 2 * Math.Atan2(Math.Sqrt(haversine), Math.Sqrt(1 - haversine));

        var distanceInKilometers = EarthRadius * distance; // Distance in km

        return distanceInKilometers;
    }
}