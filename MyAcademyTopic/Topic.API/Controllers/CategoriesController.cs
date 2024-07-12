using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories() 
        {
            var values = _categoryService.TGetList();
            var categories = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(categories);  //Status 200 durum kodu (işlem başarılı)
        }

   

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _categoryService.TGetActiveCategoriesWithBlogs();
            List<CategoryOfResultsWithBlogDto> result = new List<CategoryOfResultsWithBlogDto>();
            foreach (var item in values)
            {
                result.Add(new CategoryOfResultsWithBlogDto
                {
                    BlogCount = item.Blogs.Count,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    Status = item.Status,
                });
            }
            return Ok(result);
        }


        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var values = _categoryService.TGetList();
            return Ok(values);
        }


        [HttpGet("GetAllCategoryCount")]
        public IActionResult GetAllCategoryCount()
        {
            var values = _categoryService.TGetAllCategoryCount();
            return Ok(values);
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            var values = _categoryService.TGetActiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)   //id ye göre getirme
        {
            var value = _categoryService.TGetById(id);
            var category = _mapper.Map<ResultCategoryDto>(value);
            return Ok(category);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TCreate(category);
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
