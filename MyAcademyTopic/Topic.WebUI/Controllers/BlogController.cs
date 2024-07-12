using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7061/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }


        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("https://localhost:7061/api/blogs");
            var blogsByCategory = values.Where(blog => blog.CategoryId == id).ToList();
            return View(blogsByCategory);
        }



        public async Task<IActionResult> GetBlogDetails(int id)  //blog detay sayfası
        {
            var value = await _client.GetFromJsonAsync<ResultBlogDto>("https://localhost:7061/api/blogs/" + id);
            return View(value);
        }
    }
}
