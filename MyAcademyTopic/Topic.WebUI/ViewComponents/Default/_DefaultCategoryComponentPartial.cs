using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
	public class _DefaultCategoryComponentPartial : ViewComponent
	{
		private readonly HttpClient _client;

		public _DefaultCategoryComponentPartial(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7061/api/");
            _client = client;
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("Categories");
            return View(values);
        }
	}
}
