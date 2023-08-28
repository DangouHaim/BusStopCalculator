using BusStopCalculator.BLL.Mappers;

namespace BusStopCalculator.BLL.Extensions;

public static class MapExtensions
{
    public static Map<T> Map<T>(this T source) { return new Map<T>(source); }
}