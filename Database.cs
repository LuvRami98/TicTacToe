using _2Övningsuppgifter2.Models;
using MongoDB.Driver;

namespace _2Övningsuppgifter2
{
    public class Database
    {
        private IMongoDatabase GetDB()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("PlayerDB");
            return db;
        }

        public async Task SavePlay(Player1 game)
        {
            await GetDB().GetCollection<Player1>("Play").InsertOneAsync(game);
        }
    }
}
