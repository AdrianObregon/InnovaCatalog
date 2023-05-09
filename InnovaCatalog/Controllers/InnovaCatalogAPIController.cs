using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;
using InnovaCatalog.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnovaCatalog.Controllers
{
    [Route("api/CatalogAPI")]
    [ApiController]
    public class InnovaCatalogAPIController:ControllerBase
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
        
        public async Task<object> Get()
        {

            try { 
                IEnumerable<CatalogDto> catalogDtos = await _catalogRepository.GetCatalogs();
                _response.Result = catalogDtos;
                _logger.LogInformation("Getting all InnovaCatalogs");
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages 
                    = new List<string>() { ex.ToString() };
                _logger.LogInformation("Error at getting all InnovaCatalogs");
            }

            return _response;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {

            try { 
                CatalogDto catalogDtos = await _catalogRepository.GetCatalogById(id);
                _response.Result = catalogDtos;
                _logger.LogInformation("Getting the InnovaCatalog with id: " + id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages 
                    = new List<string>() { ex.ToString() };
                _logger.LogInformation("Error at getting the InnovaCatalog");
            }

            return _response;
        }

        [HttpPost]
        

        public async Task<object> Post([FromBody]CatalogDto catalogDto)
        {

            try
            {
                CatalogDto model = await _catalogRepository.CreateUpdateCatalog(catalogDto);
                _response.Result = model;
                _logger.LogInformation("Posted a new  InnovaCatalog");
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
                _logger.LogInformation("Failed to post a new InnovaCatalog");
            }

            return _response;
        }

        [HttpPut]
        

        public async Task<object> Put([FromBody] CatalogDto catalogDto)
        {

            try
            {
                CatalogDto model = await _catalogRepository.CreateUpdateCatalog(catalogDto);
                _response.Result = model;
                _logger.LogInformation("Updated the correct InnovaCatalog");
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
                _logger.LogInformation("Failed at updating the InnovaCatalogs");
            }

            return _response;
        }

        
        [HttpDelete]
        
        public async Task<object> Delete(int id)
        {

            try
            {
                bool isSuccess = await _catalogRepository.DeleteCatalog(id);
                _response.Result = isSuccess;
                _logger.LogInformation("Successfully deleted the InnovaCatalog with id: " + id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
                _logger.LogInformation("Failed at deleting the InnovaCatalog with id: " +id);
            }

            return _response;
        }

    }
}
