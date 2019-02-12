using Microsoft.AspNetCore.Mvc;
using RedisPOC.ConnectionFactory;
using System;

namespace RedisPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRedisConnectionFactory redisConnectionFactory;

        public ValuesController(IRedisConnectionFactory redisConnectionFactory)
        {
            this.redisConnectionFactory = redisConnectionFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var db = redisConnectionFactory.Connection().GetDatabase();
            var tomorrow = DateTime.UtcNow.AddDays(1).Date;
            var expiry = tomorrow.Subtract(DateTime.UtcNow.AddSeconds(-3));

            db.StringSet("TestRedisCache", "Testing for Redis Cache", expiry);

            var result = db.StringGet("TestRedisCache").ToString();
            return Ok(result);
        }
    }
}