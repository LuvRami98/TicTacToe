using _2Övningsuppgifter2.Models;
using MongoDB.Driver;

namespace _2Övningsuppgifter2
{
    public class DatabaseTwo
    {
        private IMongoDatabase GetDB()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("PlayerDB");
            return db;
        }

        public async Task SavePlay2(Player2 gamePlay)
        {
            await GetDB().GetCollection<Player2>("PlayGame").InsertOneAsync(gamePlay);
        }
    }
}
