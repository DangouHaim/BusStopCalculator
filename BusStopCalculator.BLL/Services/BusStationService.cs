using BusStopCalculator.BLL.Mappers;
using BusStopCalculator.DAL.Repositories;
using BusStopCalculator.DTO.Models;

namespace BusStopCalculator.BLL.Services;

public interface IBusStationService
{
    Task<IEnumerable<BusStation>> GetAll();
    Task<BusStation> GetById(long id);
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

    public async Task<BusStation> GetById(long id)
    {
        var busStations = _busStationRepository.GetAll()
            .Where(x => x.Id == id);
        
        var busStation = await busStations.FirstAsync();

        return _busStationMapper.MapToDto(busStation);
    }
}