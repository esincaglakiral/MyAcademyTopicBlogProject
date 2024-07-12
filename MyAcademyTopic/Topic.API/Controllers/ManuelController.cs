using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.ManuelDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManuelController : ControllerBase
    {
        private readonly IManuelService _manuelService;
        private readonly IMapper _mapper;

        public ManuelController(IManuelService manuelService, IMapper mapper)
        {
            _manuelService = manuelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ManuelList()
        {
            var values = _manuelService.TGetList();
            var manuels = _mapper.Map<List<ResultManuelDto>>(values);
            return Ok(manuels);
        }

   

        [HttpGet("{id}")]
        public IActionResult GetBYId(int id)
        {
            var values = _manuelService.TGetById(id);
            var manuels = _mapper.Map<ResultManuelDto>(values);

            return Ok(manuels);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteManuel(int id)
        {
            _manuelService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }
    


        [HttpPost]
        public IActionResult CreateManuel(CreateManuelDto createManuelDto)
        {
            var newManuel = _mapper.Map<Manuel>(createManuelDto);
            _manuelService.TCreate(newManuel);
            return Ok(newManuel);
        }

        [HttpPut]
        public IActionResult UpdateManuel(UpdateManuelDto updateManuelDto)
        {
            var updateManuel = _mapper.Map<Manuel>(updateManuelDto);
            _manuelService.TUpdate(updateManuel);
            return Ok("Manuel Başarıyla Güncellendi.");
        }
    }
}
