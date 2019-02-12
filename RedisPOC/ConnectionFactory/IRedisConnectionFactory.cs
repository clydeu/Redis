using StackExchange.Redis;

namespace RedisPOC.ConnectionFactory
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}