using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Midterm
{
    public class Game
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public int ReleaseYear { get; set; }
        public int SteamAppId { get; set; }
    }
    
    public static class Secrets
    {
        public const string API_HEADER = "Key";
        public const string API_KEY = "Insert Your Key Here";
    }

    public static class GamesController
    {
        static Dictionary<int, Game> games = new Dictionary<int, Game>();

        private static bool CheckKey(HttpRequest req)
        {
            return req.Headers[Secrets.API_HEADER] == Secrets.API_KEY;
        }

        [Function("CreateGame")]
        public static async Task<IActionResult> CreateGame(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "games")] HttpRequest req, FunctionContext executionContext)
        {
            if (!CheckKey(req))
            {
                return new UnauthorizedResult();
            }

            var logger = executionContext.GetLogger("CreateGame");
            logger.LogInformation("Creating a new game.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var requestData = JsonConvert.DeserializeObject<Game>(requestBody);

            if (requestData == null || string.IsNullOrEmpty(requestData.Title) || requestData.SteamAppId <= 0)
            {
                return new BadRequestObjectResult("Title and unique non-zero ID are required.");
            }

            if (games.ContainsKey(requestData.SteamAppId))
            {
                return new BadRequestObjectResult("A game with this ID already exists.");
            }

            var game = new Game()
            {
                Title = requestData.Title,
                Genre = requestData.Genre,
                Developer = requestData.Developer,
                ReleaseYear = requestData.ReleaseYear,
                SteamAppId = requestData.SteamAppId
            };

            games.Add(requestData.SteamAppId, game);
            return new OkObjectResult(game);
        }

        [Function("GetGames")]
        public static async Task<IActionResult> GetGames(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "games")] HttpRequest req, FunctionContext executionContext)
        {
            if (!CheckKey(req))
            {
                return new UnauthorizedResult();
            }
            
            var logger = executionContext.GetLogger("GetGames");
            logger.LogInformation("Getting all games.");

            return new OkObjectResult(games);
        }

        [Function("UpdateGame")]
        public static async Task<IActionResult> UpdateGame(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "games/{steamAppId:int}")] HttpRequest req,
            int SteamAppId, FunctionContext executionContext)
        {
            if (!CheckKey(req))
            {
                return new UnauthorizedResult();
            }

            var logger = executionContext.GetLogger("UpdateGame");
            logger.LogInformation($"Updating game with SteamAppId={SteamAppId}.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var requestData = JsonConvert.DeserializeObject<Game>(requestBody);

            if (requestData == null || requestData.SteamAppId != SteamAppId)
            {
                return new BadRequestObjectResult("Invalid game data or SteamAppId mismatch.");
            }

            if (!games.ContainsKey(SteamAppId))
            {
                return new NotFoundObjectResult("Game not found. Input valid ID.");
            }

            Game selectedGame = games[SteamAppId];

            selectedGame.Title = requestData.Title;
            selectedGame.Genre = requestData.Genre;
            selectedGame.Developer = requestData.Developer;
            selectedGame.ReleaseYear = requestData.ReleaseYear;

            return new OkObjectResult($"Game with SteamAppId={SteamAppId} updated.");
        }

        [Function("DeleteGame")]
        public static async Task<IActionResult> DeleteGame(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "games/{steamAppId:int}")] HttpRequest req,
            int SteamAppId, FunctionContext executionContext)
        {
            if (!CheckKey(req))
            {
                return new UnauthorizedResult();
            }

            var logger = executionContext.GetLogger("DeleteGame");
            logger.LogInformation($"Deleting game with SteamAppId={SteamAppId}.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var requestData = JsonConvert.DeserializeObject<Game>(requestBody);

            if (!games.ContainsKey(SteamAppId))
            {
                return new NotFoundObjectResult("Game not found. Input valid ID.");
            }

            games.Remove(SteamAppId);

            return new OkObjectResult(games);
        }
    }
}

