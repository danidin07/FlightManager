using FlightManagerApi.Data;
using FlightManagerApi.Logic;
using FlightManagerApi.Models;
using FlightManagerProjectSela.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FlightManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightDbContext _db;
        private readonly LogicLegs logic;
        public FlightController(FlightDbContext db, LogicLegs logic)
        {
            _db = db;
            this.logic = logic;
        }
        
        


        [HttpGet]
        public async Task<List<Logger>> Get() => await _db.Loggers.Include(x => x.Leg).Include(x => x.Flight).ToListAsync();


        [HttpPost]
        public async Task AddFlight(Flight flight)
        {
            try
            {
                await _db.Flights.AddAsync(flight);
                await _db.SaveChangesAsync();
                await logic.AddFLight(flight);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
