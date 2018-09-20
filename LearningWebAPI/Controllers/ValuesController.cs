using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LearningWebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningWebAPI.Model
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://reqres.in/");
                    var response = await client.GetAsync("/api/users?page=2");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawData = JsonConvert.DeserializeObject<GetUserModel>(stringResult);
                    return Ok(new
                    {
                        Page = rawData.page,
                        PerPage = rawData.per_page,
                        Total = rawData.total,
                        TotalPages = rawData.total_pages,
                        Data = rawData.data
                    });
                }
                catch (HttpRequestException exception)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {exception.Message}");
                }
            }
        }

        // POST: api/values
        [HttpPost]
        public async Task<IActionResult> Post(string name, string job)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Job: {job}");
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://reqres.in/");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("name",name),
                        new KeyValuePair<string, string>("job",job)
                    });
                    var response = await client.PostAsync("/api/users",content);
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawData = JsonConvert.DeserializeObject<CreateUserModel>(stringResult);
                    return Ok(new
                    {
                        name = rawData.name,
                        job = rawData.job,
                        id = rawData.id,
                        createdAt = rawData.createdAt.ToString()
                    });
                }
                catch (HttpRequestException exception)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {exception.Message}");
                }
            }
        }
    }
}
