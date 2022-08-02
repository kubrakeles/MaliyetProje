using MaliyetBusiness.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MaliyetApi.Controllers
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
            var result=_tenderService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

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
