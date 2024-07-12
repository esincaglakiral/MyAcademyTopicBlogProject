using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.ManuelDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultManuelComponentPartial : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultManuelComponentPartial(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7061/api/");

            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultManuelDto>>("https://localhost:7061/api/manuel");  
            //unutmamalıyızki burada istek atacağımız "manuel" api katmanındaki controller adına göre yazılmalı, büyük küçük harf farketmiyor. örneğin controller adı manuelse manuel manuels ise manuels olarak yazılmalı.

            return View(values);
        }
    }
}
