using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskMVC.Models;

namespace TestTaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkerService _workerService;

        public HomeController(IWorkerService service)
        {
            _workerService = service;
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            await _workerService.ReadFromCSV(upload.OpenReadStream());
            return RedirectToAction("Workers");
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Workers()
        {
            var workers = _workerService.GetAll();
            var model = new WorkersViewModel(workers);
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Workers([FromBody]WorkerModel model)
        {
            try
            {
                await _workerService.UpdateAsync(model);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Workers([FromQuery]int id)
        {
            await _workerService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}