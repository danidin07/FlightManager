using FlightManagerApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using FlightManagerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightManagerApi.Logic
{
    public class LogicLegs
    {
        private readonly FlightDbContext _db;
        public LogicLegs(FlightDbContext db)
        {
            _db = db;
        }

        public async Task AddFLight(Flight flight)
        {
            var leg1 = await _db.Legs.FirstAsync(l => l.Number == 1 );
            if (leg1.Flight != null)
                await AddFLight(flight);
            leg1.Flight = flight;
            await NextTerminal(flight, leg1);
        }
            
        public async Task NextTerminal(Flight flight, Leg leg)
        {
            var log = new Logger { Flight = flight, Leg = leg, In = DateTime.Now };
            await _db.Loggers.AddAsync(log);
            Console.WriteLine($" flight code: {flight.Code} leg number: {leg.Number} date of entery: ({DateTime.Now})");
            var nextLeg =await _db.Legs.FirstOrDefaultAsync(l => l.CurrentLeg == leg.Next);

            Thread.Sleep(leg.WaitTime * 1000);

            
            if (leg.Number == 4)
            {
                if (leg?.Flight?.IsAirReady == false)
                {
                    nextLeg = await _db.Legs.FirstOrDefaultAsync(l => l.CurrentLeg == LegType.Fiv);
                    
                }
                else//departure
                {
                    leg!.Flight = null;
                    Console.WriteLine($"flight code: {flight.Code} diparted !!!!!");
                    return;
                }
            }
            else if (leg.Number == 5)
            {
                
                var leg6 = await _db.Legs.FirstOrDefaultAsync(l => l.CurrentLeg == LegType.Six);
                var leg7 = await _db.Legs.FirstOrDefaultAsync(l => l.CurrentLeg == LegType.Sev);
                
                //leg6.Flight = flight 
                //cheack if leg6/7 is empty
                if(leg6?.Flight == null) 
                {
                    nextLeg = leg6;
                    flight.IsAirReady = true;
                    Console.WriteLine("flight reached leg six");
                 
                }
                else if(leg7?.Flight == null)
                {
                    nextLeg = leg7;
                    flight.IsAirReady = true;
                    
                    Console.WriteLine("flight reached leg sev");
                }
                else
                {
                    await NextTerminal(flight, leg);
                }
            }
            
            if(nextLeg == null) { throw new Exception("next is null why?"); }
            leg.Flight = null;
            log.Out = DateTime.Now;
            nextLeg!.Flight = flight;
            await _db.SaveChangesAsync();
            await NextTerminal(flight, nextLeg);
            
        }


    }
}

