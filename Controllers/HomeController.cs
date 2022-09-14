using lab1_var5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1_var5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext db;
        DBConnector dbConnector;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
            dbConnector = new DBConnector(db);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FindPlayer findPlayer)
        {
            String invalidParameter;
            if (!checkInput(findPlayer, out invalidParameter))
            {
                return View("Invalid input", invalidParameter);
            }

            List<Player> playerByRequest = dbConnector.getPlayerByQuery(findPlayer);
            return View(playerByRequest);
        }

        private bool checkInput(FindPlayer findPlayer, out String invalidParameter)
        {
            if (findPlayer.minWeight < 0)
            {
                invalidParameter = "minWeight";
                return false;
            }
            if (findPlayer.minWeight > findPlayer.maxWeight)
            {
                invalidParameter = "maxWeight";
                return false;
            }

            if (findPlayer.minHeight < 0)
            {
                invalidParameter = "minHeight";
                return false;
            }
            if (findPlayer.minHeight > findPlayer.maxHeight)
            {
                invalidParameter = "maxWeight";
                return false;
            }

            invalidParameter = "";
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}