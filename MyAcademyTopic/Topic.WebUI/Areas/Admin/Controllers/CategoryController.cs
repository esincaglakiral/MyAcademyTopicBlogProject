using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;  //HttpClient fielder aracılığı ile istek atacağız. Http istekleri atabilmesini sağlayan bir sınıftır.
                                                  //Http isteklerimizi Get, Put, Delete veya Post olarak asenkron olarak yapmamızı sağlamaktadır. 

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7061/api/categories"); //Bu url'e _httpClient nesnesi aracılığı ile GET isteği atarız

            if (responseMessage.IsSuccessStatusCode)  //get isteği atıldığında başarılı olura yani 200 durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  //gelen değerleri jsonData formatında okuduk
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //jsondata liste türünde geldiği için List olarak Deserialize edilir. ResultCategoryDto Json formatındadır.
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);  //api tarafına post isteği atacağız(inputa değer gircez) haliyle string formatı json formatına serialize etmemiz gerek
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");  //json formatını string content'e çevirmemiz gerek önce (türkçe karakterlerden dolayı UTF8 seçilir)
            var responseMessage = await _httpClient.PostAsync("https://localhost:7061/api/Categories", str);  //post işlemi olduğu için PostAsync kullanılır 
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:7061/api/Categories/{id}");  //burada serialize veya deserialize dönüştürme işlemine gerek yok
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }



        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"https://localhost:7061/api/Categories/{id}");  //id parametresiyle beraber bir get isteği atıyoruz. id belirtmeyi unutmamaız gerekir

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);  //Get isteği yaparken UpdateCategoryDto deserialize edilerek string formata dönüştürülür, post işleminde ise inputa değer girip post edeceğimiz için string formatın json formata çevrilmesi gerekeir bu durumda da post işleminde de serialize edilcektir.
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
        {

            var jsonData = JsonConvert.SerializeObject(model);   //Post işleminde ise inputa değer girip post edeceğimiz için string formatın json formata çevrilmesi gerekir bu durumda da post işleminde de serialize edilcektir.

            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:7061/api/Categories", str);  //PutAsync güncelleme işlemlerinde kullanılan bir metottur. 
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}





//Serialize kavramı: string formatından json formatına çevirme (inputlarla girdiğimiz değerlerimiz string formatta oluyor. mesela create, update sayfalarında inputa değer giriyoruz.)
//Deserialize kavramı : json formatından string formatına çevirme işlemidir
//https://localhost:7061 ise swaggerdaki yani api katmanındaki url'imiz biz oraya httpClient istekleri atoyoruz. 