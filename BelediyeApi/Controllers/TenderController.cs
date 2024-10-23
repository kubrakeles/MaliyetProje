using BelediyeBusiness.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BelediyeApi.Controllers
{
    [Route(template: "api/[controller]")]
    public class TenderController : Controller
    {
        private ITenderService _tenderService;
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpGet(template:"GetAllTender")]
        public IActionResult GetList()
        {
            var result = _tenderService.GetAllWithSpec();
            if (result is not null)
            {
                return Ok(result);
            }
            else
                return BadRequest("veriler yüklenemedi");

        }
        [HttpGet(template: "GetWithType")]
        public IActionResult GetTenderById(int id)
        {
            var result = _tenderService.GetById(id);
            if(result.Success)
            {
                return Ok(result.Data);

            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "GetWithUnit")]
        public IActionResult GetByUnitId(int id)
        {
            var result = _tenderService.GetListByUnitType(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);   

        }
        
    }
}
