using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;

        public DashboardController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<CategoryOfResultsWithBlogDto>>("https://localhost:7061/api/Categories/GetActiveCategories");
            return View(values);
        }
    }
}
