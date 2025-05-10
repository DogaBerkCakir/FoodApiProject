using AutoMapper;
using FoodApiService.Context;
using FoodApiService.Dtos.FeatureDtos;
using FoodApiService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllFeatures()
        {
            var features = _context.Features.ToList();
            if (features == null)
            {
                return NotFound();
            }
            // AutoMapper ile mapleme yapıyoruz bak tek tek yazmadık :D

            var result = _mapper.Map<List<ResultFeatureDto>>(features);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto == null)
            {
                return BadRequest();
            }

            var feature = _mapper.Map<Feature>(createFeatureDto); // mantıgı en iyi anlayacagın kısım

            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Basarılı sekilde veri tabanına kaydedildi....");

        }

        [HttpGet("{id}")]
        public IActionResult GetByIdFeature(int featureId)
        {
            var feature = _context.Features.FirstOrDefault(x => x.FeatureId == featureId);
            if (feature == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetByIdFeatureDto>(feature);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int featureId)
        {
            var feature = _context.Features.FirstOrDefault(x => x.FeatureId == featureId);
            if (feature == null)
            {
                return NotFound();
            }
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok("Basarılı sekilde silindi....");
        }


        [HttpPut]
        public IActionResult PutFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto); //auto mapping mantıgını anla iyice
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Basarılı sekilde güncellendi....");
        }
    }
}
