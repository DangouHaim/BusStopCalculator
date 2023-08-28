using CsvHelper.Configuration.Attributes;

namespace BusStopCalculator.DAL.Entities;

public class BusStation
{
    [Name("stop_id")] 
    public long Id { get; set; }

    [Name("stop_name")]
    public string Name { get; set; }

    [Name("stop_desc")]
    public string Desctipyion { get; set; }

    [Name("stop_url")]
    public string StationUrl { get; set; }

    [Name("parent_station")]
    public long? ParentStationId { get; set; }

    public BusStationLocation Location { get; set; }
}