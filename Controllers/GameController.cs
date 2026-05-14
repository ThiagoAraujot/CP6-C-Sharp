using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;

namespace GameStoreMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: /Game
        public async Task<IActionResult> Index()
        {
            var games = await _gameRepository.GetAllAsync();
            return View(games);
        }

        // GET: /Game/Criar
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST: /Game/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Game game)
        {
            if (!ModelState.IsValid)
                return View(game);

            await _gameRepository.AddAsync(game);
            TempData["Sucesso"] = "Game cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        // GET: /Game/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                return NotFound();

            return View(game);
        }

        // POST: /Game/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Game game)
        {
            if (id != game.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(game);

            await _gameRepository.UpdateAsync(game);
            TempData["Sucesso"] = "Game atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        // POST: /Game/Excluir/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            await _gameRepository.DeleteAsync(id);
            TempData["Sucesso"] = "Game excluído com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
