using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;
using InnovaCatalog.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnovaCatalog.Controllers
{
    [Route("api/CatalogAPI")]
    [ApiController]
    public class InnovaCatalogAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private ICatalogRepository _catalogRepository;
        private readonly ILogger<InnovaCatalogAPIController> _logger;
        public InnovaCatalogAPIController(ICatalogRepository catalogRepository, ILogger<InnovaCatalogAPIController> logger)
        {
            _catalogRepository = catalogRepository;
            this._response = new ResponseDto();
            _logger = logger;
        }

        /* https://innovacatalogapi.azurewebsites.net/api/CatalogApi */

        [HttpGet]
        [Authorize]
        

        public async Task<object> Get()
        {
            IEnumerable<CatalogDto> catalogDtos = await _catalogRepository.GetCatalogs();
            _response.Result = catalogDtos;
            _logger.LogInformation("Getting all InnovaCatalogs");

            return Ok(_response);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        
        public async Task<object> Get(int id)
        {

            
                CatalogDto catalogDtos = await _catalogRepository.GetCatalogById(id);
                _response.Result = catalogDtos;
                _logger.LogInformation("Getting the InnovaCatalog with id: " + id);
            
            

            return _response;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]



        public async Task<object> Post([FromBody] CatalogDto catalogDto)
        {

            
                CatalogDto model = await _catalogRepository.CreateUpdateCatalog(catalogDto);
                _response.Result = model;
                _logger.LogInformation("Posted a new  InnovaCatalog");
            

               
            

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<object> Put([FromBody] CatalogDto catalogDto)
        {

           
                CatalogDto model = await _catalogRepository.CreateUpdateCatalog(catalogDto);
                _response.Result = model;
                _logger.LogInformation("Updated the correct InnovaCatalog");
            
           

            return _response;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {

            
            
                bool isSuccess = await _catalogRepository.DeleteCatalog(id);
                _response.Result = isSuccess;
                _logger.LogInformation("Successfully deleted the InnovaCatalog with id: " + id);
            
           

            return _response;
        }

    }
}
