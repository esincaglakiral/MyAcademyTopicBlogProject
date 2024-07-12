using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Topic.WebUI.ViewComponents.Default
{
  
    public class _StatisticComponentPartial : ViewComponent
    {
        private readonly HttpClient _client;

        public _StatisticComponentPartial(HttpClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogCountResponseMessage = await _client.GetAsync("https://localhost:7061/api/Blogs/GetBlogCount");
            if (blogCountResponseMessage.IsSuccessStatusCode)
            {
                var result = await blogCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.BlogCount = result;
            }

            var allCategoryCountResponseMessage = await _client.GetAsync("https://localhost:7061/api/Categories/GetAllCategoryCount");
            if (allCategoryCountResponseMessage.IsSuccessStatusCode)
            {
                var result = await allCategoryCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.AllCategoryCount = result;
            }


            var activeCategoryCountResponseMessage = await _client.GetAsync("https://localhost:7061/api/Categories/GetActiveCategoryCount");
            if (activeCategoryCountResponseMessage.IsSuccessStatusCode)
            {
                var result = await activeCategoryCountResponseMessage.Content.ReadAsStringAsync();
                ViewBag.ActiveCategoryCount = result;
            }

            return View();
        }
    }
}
