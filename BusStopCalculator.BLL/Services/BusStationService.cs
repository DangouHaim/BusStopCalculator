using BusStopCalculator.BLL.Mappers;
using BusStopCalculator.DAL.Repositories;
using BusStopCalculator.DTO.Models;

namespace BusStopCalculator.BLL.Services;

public interface IBusStationService
{
    
}

public class BusStationService : IBusStationService
{
    private readonly IBusStationRepository _busStationRepository;
    private readonly IBusStationMapper _busStationMapper;

    public BusStationService(IBusStationRepository busStationRepository,
        IBusStationMapper busStationMapper)
    {
        _busStationRepository = busStationRepository;
        _busStationMapper = busStationMapper;
    }

    public async Task<IEnumerable<BusStation>> GetAll()
    {
        var busStations = _busStationRepository.GetAll();

        return await _busStationMapper.MapCollectionToDto(busStations).ToListAsync();
    }
}