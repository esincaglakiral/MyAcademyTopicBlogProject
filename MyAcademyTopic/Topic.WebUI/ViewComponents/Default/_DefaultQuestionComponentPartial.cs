using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.QuestionDto;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultQuestionComponentPartial : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultQuestionComponentPartial(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7061/api/");
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var questions = await _client.GetFromJsonAsync<List<ResultQuestionDto>>("https://localhost:7061/api/questions");
            return View(questions);
        }
    }
}
