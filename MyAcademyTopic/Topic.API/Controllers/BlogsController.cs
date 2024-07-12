using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.BlogDtos;
using Topic.DTOLayer.DTOs.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);  //Status 200 durum kodu (işlem başarılı)
        }


        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var count = _blogService.TGetBlogCount();
            return Ok(count);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)   //id ye göre getirme
        {
            //var value = _blogService.TGetById(id);
            //var blog = _mapper.Map<ResultBlogDto>(value);
            //return Ok(blog);

            var value = _blogService.TGetBlogWithCategoryById(id);
            if (value == null)
            {
                return NotFound();
            }
            var blog = _mapper.Map<ResultBlogDto>(value);
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Başarıyla Silindi");
        }


        [HttpPost]
        public IActionResult CreateBlog(CreateBlogDto createBlogDto)
        {
            var blog = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(blog);
            return Ok("Blog Başarıyla Eklendi");
        }



        [HttpPut]
        public IActionResult UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var blog = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(blog);
            return Ok("Blog Başarıyla Güncellendi");
        }

    }
}
