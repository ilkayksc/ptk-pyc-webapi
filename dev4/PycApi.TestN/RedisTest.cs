using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace PycApi.Test
{

    public class RedisTest
    {
        public static IServer Server = null;
        public static IDatabase Database { get; private set; }
        

        public RedisTest()
        {
            InitRedis();
        }

        
        [Test]
        public void Test_1_Ping()
        {
            var res1 = Ping();
            Assert.Greater(res1,0);
        }

        [Test]
        public void Test_2_PingAsync()
        {
            var res1 = PingAsync();
            Assert.Greater(res1, 0);
        }

        [Test]
        public void Test_3_SetString()
        {
            string key = "TestKey1";
            string value = "ValueOxc";

            var res1 = SetString(key,value);
            Assert.True(res1);
        }

        [Test]
        public void Test_4_GetString()
        {
            string key = "TestKey1";
            string value = "ValueOxc";

            var res1 = GetString(key);
            Assert.AreEqual(value,res1);
        }


        [Test]
        public void Test_5_Exists()
        {
            string key = "TestKey1";

            var res1 = Exists(key);
            Assert.True(res1);
        }

        [Test]
        public void Test_6_Delete()
        {
            string key = "TestKey1";

            var res1 = Delete(key);
            Assert.True(res1);
        }


        [Test]
        public void Test_7_GetString_Again()
        {
            string key = "TestKey1";
            string value = "ValueOxc";

            var res1 = GetString(key);
            Assert.AreEqual(value, res1);
        }


        [Test]
        public void Test_8_Exists_Again()
        {
            string key = "TestKey1";

            var res1 = Exists(key);
            Assert.True(res1);
        }


        private void InitRedis()
        {
            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add("192.168.18.167", Convert.ToInt32("6379"));
            var redisConnection = ConnectionMultiplexer.Connect(configurationOptions);
            Server = redisConnection.GetServer("192.168.18.167", Convert.ToInt32("6379"));
            Database = redisConnection.GetDatabase(0);
        }


        public static int Ping()
        {
            var redisValue = Database.Ping();
            return redisValue.Milliseconds;
        }

        public static int PingAsync()
        {
            var redisValue = Database.PingAsync().GetAwaiter().GetResult();
            return redisValue.Milliseconds;
        }

        public static async Task<int> PingAsync2()
        {
            var redisValue = await Database.PingAsync();
            return redisValue.Milliseconds;
        }

        public static async Task<string> GetKeyAsync(string key)
        {
            var redisValue = await Database.StringGetAsync(key);
            return redisValue.ToString();
        }
        public static string GetString(string key)
        {
            var redisValue = Database.StringGet(key);
            return redisValue.ToString();
        }
        public static bool SetString(string key, string value)
        {
            var redisValue = Database.StringSet(key, value);
            return redisValue;
        }
        public static Task<bool> SetStringAsync(string key, string value)
        {
            var redisValue = Database.SetAddAsync(key, value);
            return redisValue;
        }
        public static bool Exists(string key)
        {
            return Database.KeyExists(key);
        }
        public static bool Delete(string key)
        {
            var redisValue = Database.KeyDelete(key);
            return redisValue;
        }

        public static Task<bool> DeleteAsync(string key)
        {
            var redisValue = Database.KeyDeleteAsync(key);
            return redisValue;
        }
        public static void FlushAllDatabases()
        {
            Server.FlushAllDatabases();
        }
        public static void FlushDatabase()
        {
            // by default 0
            Server.FlushDatabase();
        }
        public static void FlushDatabase(int databaseIndex)
        {
            Server.FlushDatabase(databaseIndex);
        }

        public static ClientInfo[] ClientList()
        {
            var list = Server.ClientList();
            return list;
        }
        public static Task<ClientInfo[]> ClientListAsync()
        {
            var list = Server.ClientListAsync();
            return list;
        } 
    }
}
