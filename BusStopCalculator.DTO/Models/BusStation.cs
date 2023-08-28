
namespace BusStopCalculator.DTO.Models;

public class BusStation
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Desctipyion { get; set; }
    public string StationUrl { get; set; }
    public long? ParentStationId { get; set; }
    public BusStationLocation Location { get; set; }
}