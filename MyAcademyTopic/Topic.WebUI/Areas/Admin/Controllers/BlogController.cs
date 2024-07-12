using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;  //httpclient field'i türetirirz (istekler için)

        public BlogController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7061/api/"); //Bizim istek attığımız adresin temel url'i aslında. Yani https://localhost:7061/api/ kısmı bizim base adresimiz olmaktadır. /api/ den sonra gelen yerler değişebilir.
                                                                             //O nedenle base adresimizi her seferinde yazmamak için constructor olarak burada tanımlarız.
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            //GetFromJsonAsync metodu url'e istek atar, istek attıktan sonra json formatında alıyor veriyi.
            //blogs api katmanındaki blogs controllerdan gelir
            //Aslında burdaki işlem özetle şöyle: blogs'a get isteği atıp atılan istek doğrultusunda gelen veriyi Json formatında okur. Daha sonra Liste türünde ResultBlogDto'dan verilerimizi deserialize ederiz.
            //Deserialize neydi;  json formatından string formatına çevirme işlemidir

            return View(values);
        }



        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }


        public ActionResult GetBlogsByCategory(string category)
        {
            var blogs = // Blog verilerinizi çektiğimiz yer
            ViewBag.CategoryName = category; // Kategori adını ViewBag ile view'a geçiyoruz
            return View(blogs);
        }



        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("Categories");  // categorilerimizi çekeceğimiz için categorielre get istği atıyoruz

            List<SelectListItem> categories = (from x in categoryList  // kategorileri liste halinde alıyoruz 
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();
            ViewBag.Categories = categories;  //kategorilerimizi viewbag'e atadık dropdown'da listelicez
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _httpClient.PostAsJsonAsync("blogs", createBlogDto);  //PostAsJsonAsync güncellemede kullanılır, GetFromJsonAsync metodunun tam tersiniz yapar yani serialize eder(string => json'a çevirir)
            return RedirectToAction("Index");
        }




        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);

            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("Categories"); 

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();
            ViewBag.Categories = categories;

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto model)
        {

            await _httpClient.PutAsJsonAsync("blogs", model);
            return RedirectToAction("Index");
        }
    }
}
