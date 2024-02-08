using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Models;
using SwitchPlay.Services;
using System.Data;

namespace SwitchPlay.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IConfiguration _configuration;
        private readonly IFileHandleService _fileHandleService;
        public GameController(IGameService gameService, IConfiguration configuration, IFileHandleService fileHandleService)
        {
            _gameService = gameService;
            _configuration = configuration;
            _fileHandleService = fileHandleService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGamesAsync();
            return View(games);
        }

        public async Task<IActionResult> Add()
        {
            var model = new GameForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameForCreation model)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();

            var game = new Game
            {
                Title = model.Title,
                Description = model.Description,
                Image = null,
                Price = model.Price,
                Requirements = model.Requirements,
                Size = model.Size,
                ReleaseDate = DateTime.ParseExact(model.ReleaseDate, "dd/MM/yyyy", null)

        };
            await _gameService.CreateGameAsync(game);

            if (file != null)
            {
                var game2 = await _gameService.GetGameAsync(game.Id);
                var uploadDir = _configuration["Uploads:FotoLoja"];
                var fileName = game2.Id + "_" + game2.Title;
                fileName = await _fileHandleService.UploadAndRenameFileAsync(file, uploadDir, fileName);
                game2.Image = fileName;
                await _gameService.UpdateGameAsync(game2);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameAsync(id);
            var model = new GameForModification();

            model.Id = game.Id;
            model.Title = game.Title;
            model.Description = game.Description;
            model.Image = game.Image;
            model.Price = game.Price;
            model.Requirements = game.Requirements;
            model.Size = game.Size;
            model.ReleaseDate = game.ReleaseDate.ToString("dd/MM/yyyy");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameForModification model)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();
            var game = await _gameService.GetGameAsync(model.Id);

            game.Title = model.Title;
            game.Description = model.Description;
            game.Price = model.Price;
            game.Requirements = model.Requirements;
            game.Size = model.Size;
            game.ReleaseDate = DateTime.ParseExact(model.ReleaseDate, "dd/MM/yyyy", null);

            await _gameService.UpdateGameAsync(game);

            if (file != null)
            {
                var uploadDir = _configuration["Uploads:FotoLoja"];
                var fileName = game.Id + "_" + game.Title;
                fileName = await _fileHandleService.UploadAndRenameFileAsync(file, uploadDir, fileName);
                game.Image = fileName;
                await _gameService.UpdateGameAsync(game);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameAsync(id);
            if (game.Image != null)
            {
                var dir = _configuration["Uploads:FotoLoja"];
                _fileHandleService.RemoveImageFile(dir, game.Image);
            }
            await _gameService.DeleteGameAsync(game.Id);
            return RedirectToAction("Index");
        }
    }
}
