using System.Globalization;
using BusStopCalculator.DAL.Entities;
using CsvHelper;
using CsvHelper.Configuration;

namespace BusStopCalculator.DAL.Repositories;

public interface IBusStationRepository
{
    IAsyncEnumerable<BusStation> GetAll();
}

// Unit of work is optional for single read only repository
public class BusStationRepository : IBusStationRepository
{
    // Replace with IConfigProvider
    private const string SourceFile = "../stops.txt";

    public async IAsyncEnumerable<BusStation> GetAll()
    {
        using var reader = new StreamReader(SourceFile);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        
        await foreach (var station in csv.GetRecordsAsync<BusStation>())
        {
            yield return station;
        }
    }
}