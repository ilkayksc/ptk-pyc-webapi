using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PycApi.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Cashe;

[ApiController]
[Route("api/nhb/[controller]")]
public class RedisCasheController : ControllerBase
{
    private readonly IDistributedCache distributedCache;


    public RedisCasheController(IDistributedCache distributedCache)
    {
        this.distributedCache = distributedCache;
    }



    [HttpGet("GetCashe")]
    public async Task<IEnumerable<Catalog>> GetWithRedis(string key)
    {
        IEnumerable<Catalog> cities;
        string json;

        var citiesFromCache = await distributedCache.GetAsync(key);
        if (citiesFromCache != null)
        {
            json = Encoding.UTF8.GetString(citiesFromCache);
            cities = JsonConvert.DeserializeObject<List<Catalog>>(json);
            return cities;
        }
        else
        {
            List<Catalog> tempList = new List<Catalog> { new Catalog { Name = "Prod 1 ", Published = true }, new Catalog { Name = "Prod 2", Published = true }, new Catalog { Name = "Prod 3", Published = true } };

            json = JsonConvert.SerializeObject(tempList);
            citiesFromCache = Encoding.UTF8.GetBytes(json);

            var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder
                    .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.

            await distributedCache.SetAsync(key, citiesFromCache, options);
            return tempList;
        }
    }


    [HttpPost("DeleteCashe")]
    public ActionResult DeleteCache(string cacheKey)
    {
        // remove cashe
        distributedCache.Remove(cacheKey);
        return Ok();
    }



    [HttpPost("RedisGet")]
    public string InitRedis(string key)
    {
        IServer Server = null;
        IDatabase Database = null;

        var configurationOptions = new ConfigurationOptions();
        configurationOptions.EndPoints.Add("192.168.18.167", Convert.ToInt32("6379"));
        var redisConnection = ConnectionMultiplexer.Connect(configurationOptions);
        Server = redisConnection.GetServer("192.168.18.167", Convert.ToInt32("6379"));
        Database = redisConnection.GetDatabase(0);



        var redisValue = Database.StringGet(key);
        return redisValue.ToString();
    }


}
