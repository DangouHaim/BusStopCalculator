using BusStopCalculator.DTO.Models;
using BusStation = BusStopCalculator.DAL.Entities.BusStation;
using BusStationDto = BusStopCalculator.DTO.Models.BusStation;

namespace BusStopCalculator.BLL.Mappers;

public interface IBusStationMapper
{
    IAsyncEnumerable<BusStationDto> MapCollectionToDto(IAsyncEnumerable<BusStation> sourceList);
}

public class BusStationMapper : IBusStationMapper
{
    public async IAsyncEnumerable<BusStationDto> MapCollectionToDto(IAsyncEnumerable<BusStation> sourceList)
    {
        var mappedResults = from x in sourceList
            select new BusStationDto
            {
                Id = x.Id,
                Name = x.Name,
                Desctipyion = x.Desctipyion,
                StationUrl = x.StationUrl,
                ParentStationId = x.ParentStationId,

                Location = new BusStationLocation
                {
                    Latitude = x.Location.Latitude,
                    Longitude = x.Location.Longitude,
                    ZoneId = x.Location.ZoneId,
                    LocationType = (LocationType)x.Location.LocationType
                }
            };

        await foreach (var station in mappedResults)
        {
            yield return station;
        }
    }
}