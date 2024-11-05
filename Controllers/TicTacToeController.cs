using _2Övningsuppgifter2.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace _2Övningsuppgifter2.Controllers
{
    public class TicTacToeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Route("TicTacToe/SavePlay1")]
        public async Task<IActionResult> SavePlay1([FromBody] PlayRequest request)
        {
            var game = new Player1
            {
                id = ObjectId.GenerateNewId(),
                CrossOne = request.cellId
            };

            Database db = new Database();
            await db.SavePlay(game);

            return Ok();
        }

        [HttpPost]
        [Route("TicTacToe/SavePlay2")]
        public async Task<IActionResult> SavePlay2([FromBody] PlayRequest request)
        {
            var game = new Player2
            {
                id = ObjectId.GenerateNewId(),
                CircleTwo = request.cellId
            };

            DatabaseTwo db = new DatabaseTwo();
            await db.SavePlay2(game);

            return Ok();
        }
    }
}
