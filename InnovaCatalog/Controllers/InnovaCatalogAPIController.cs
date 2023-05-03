using InnovaCatalog.Models;
using InnovaCatalog.Models.Dto;
using InnovaCatalog.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InnovaCatalog.Controllers
{
    [Route("api/CatalogAPI")]
    [ApiController]
    public class InnovaCatalogAPIController:ControllerBase
    {
        protected ResponseDto _response;
        private ICatalogRepository _catalogRepository;
        public InnovaCatalogAPIController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
            this._response = new ResponseDto(); 
        }

        [HttpGet]
        public async Task<object> Get()
        {

            try { 
                IEnumerable<CatalogDto> catalogDtos = await _catalogRepository.GetCatalogs();
                _response.Result = catalogDtos; 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages 
                    = new List<string>() { ex.ToString() };
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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages 
                    = new List<string>() { ex.ToString() };
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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
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
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _response;
        }

    }
}
