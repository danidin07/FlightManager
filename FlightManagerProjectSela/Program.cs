

using FlightManagerProjectSela.Models;
using System.Net.Http.Json;
using System.Text;



HttpClient client = new() { BaseAddress = new Uri("http://localhost:5219") };

System.Timers.Timer timer = new System.Timers.Timer(7000);
timer.Elapsed += (s, e) => CreateFlight();
timer.Start();


Console.ReadLine();

//create and send the flight to the api post request
async void CreateFlight()
{
    var flight = new FlightDTO {
        Code = Guid.NewGuid().ToString(),
        Brand = CreateBrand(),
        IsAirReady = false,
    };
    var response = await client.PostAsJsonAsync("api/Flight", flight);
    if (response.IsSuccessStatusCode)
        Console.WriteLine(flight);
}


string CreateBrand()
{
    Random rand = new Random();
    string[] brands = { "Emirates", "Qatar Airways", "Japan Airlines", "EVA Air", "British Airways" };
   int index = rand.Next(brands.Length);
    return brands[index];
}
