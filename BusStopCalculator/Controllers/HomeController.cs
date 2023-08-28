using BusStopCalculator.BLL.Services;
using BusStopCalculator.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusStopCalculator.Controllers;

public class HomeController : Controller
{
    private readonly IBusStationService _busStationService;
    private readonly IBusStationCalculationService _busStationCalculationService;

    public HomeController(IBusStationService busStationService,
        IBusStationCalculationService busStationCalculationService)
    {
        _busStationService = busStationService;
        _busStationCalculationService = busStationCalculationService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _busStationService.GetAll();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CalculateDistance(long fromStationId, long toStationId)
    {
        // Could be optimized by converting into GetByIds instead of GetById
        var fromStation = _busStationService.GetById(fromStationId);
        var toStation = _busStationService.GetById(toStationId);

        await Task.WhenAll(fromStation, toStation);

        var distanceBetweenStations = _busStationCalculationService.GetDistanceBetweenStation(fromStation.Result,
            toStation.Result);

        ViewBag.DistanceBetweenStations = distanceBetweenStations;

        return View();
    }
}