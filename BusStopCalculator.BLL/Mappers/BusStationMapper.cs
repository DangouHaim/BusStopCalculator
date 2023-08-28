using BusStopCalculator.DTO.Models;
using BusStation = BusStopCalculator.DAL.Entities.BusStation;
using BusStationDto = BusStopCalculator.DTO.Models.BusStation;

namespace BusStopCalculator.BLL.Mappers;

public interface IBusStationMapper
{
    BusStationDto MapToDto(BusStation source);
    IAsyncEnumerable<BusStationDto> MapCollectionToDto(IAsyncEnumerable<BusStation> sourceList);
}

public class BusStationMapper : IBusStationMapper
{
    public BusStationDto MapToDto(BusStation source)
    {
        return new BusStationDto
        {
            Id = source.Id,
            Name = source.Name,
            Desctipyion = source.Desctipyion,
            StationUrl = source.StationUrl,
            ParentStationId = source.ParentStationId,

            Location = new BusStationLocation
            {
                Latitude = source.Location.Latitude,
                Longitude = source.Location.Longitude,
                ZoneId = source.Location.ZoneId,
                LocationType = (LocationType)source.Location.LocationType
            }
        };
    }

    public async IAsyncEnumerable<BusStationDto> MapCollectionToDto(IAsyncEnumerable<BusStation> sourceList)
    {
        var mappedResults = from x in sourceList
            select MapToDto(x);

        await foreach (var station in mappedResults)
        {
            yield return station;
        }
    }
}