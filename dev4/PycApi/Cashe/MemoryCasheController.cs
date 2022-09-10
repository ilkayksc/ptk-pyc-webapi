using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PycApi.Service;
using System;
using System.Collections.Generic;

namespace PycApi.Cashe;

public class Catalog
{
    public string Name { get; set; }
    public bool Published { get; set; }
}



[ApiController]
[Route("api/nhb/[controller]")]
public class MemoryCasheController : ControllerBase
{
    private readonly IMemoryCache memoryCache;


    public MemoryCasheController(IMemoryCache memoryCache)
    {
        this.memoryCache = memoryCache;
    }



    [HttpPost]
    public List<Catalog> Get(string cacheKey)
    {

        if (!memoryCache.TryGetValue(cacheKey, out List<Catalog> casheList))
        {
            List<Catalog> catList = new List<Catalog> { new Catalog { Name = "Prod 1 ", Published = true }, new Catalog { Name = "Prod 2", Published = true }, new Catalog { Name = "Prod 3", Published = true } };

            var cacheExpOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                Priority = CacheItemPriority.Normal,
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            // set cashe
            memoryCache.Set(cacheKey, catList, cacheExpOptions);
            return catList;
        }

        return casheList;
    }

    [HttpPost]
    [Route("DeleteMemoryCashe")]
    public ActionResult DeleteCache(string cacheKey)
    {
        // remove cashe
        memoryCache.Remove(cacheKey);
        return Ok();
    }


    [ResponseCache(CacheProfileName ="Profile45")]
    [HttpGet("ResponseCashe")]
    public List<Catalog> ResponseCashe()
    {
        List<Catalog> catList = new List<Catalog> { new Catalog { Name = "Prod 1 ", Published = true }, new Catalog { Name = "Prod 2", Published = true }, new Catalog { Name = "Prod 3", Published = true } };
        return catList;
    }



}