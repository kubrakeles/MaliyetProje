using MaliyetBusiness.Abstract;
using MaliyetEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Models;

namespace UI.Controllers
{
    
    public class TenderController : Controller
    {
        ITenderService _tenderService;
        ITenderTypeService _tenderTypeService;

        public TenderController(ITenderService tenderService,ITenderTypeService tenderTypeService)
        {
            _tenderService = tenderService;
            _tenderTypeService = tenderTypeService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddTender()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> units = new List<SelectListItem>();
            //Viewbag e buradan tendertypeları bağlayacağız.
            var TenderTypes = _tenderTypeService.GetList();
            var Units = _tenderTypeService.GetUnits();
            foreach(var tenderType in TenderTypes)
            {

                items.Add(new SelectListItem { Value = tenderType.Id.ToString(),Text=tenderType.TypeName }) ;
            }
            foreach(var unit in Units)
            {
                units.Add(new SelectListItem { Value = unit.id.ToString(), Text = unit.UnitName });
            }

            ViewBag.Units = units;
            ViewBag.TenderTypes = items;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddTender(Tender tender)
        {
           if (ModelState.IsValid)
            {
                _tenderService.Add(tender);

            }
            return View();
        }
        [HttpGet]
        public IActionResult TenderDetails()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TenderEdit()
        {
            return View();
        }
        //public async Task<IActionResult> JuryAdd(TenderModel juryModel)
        //{
        //    string sKapak = string.Empty;
        //    if (ModelState.IsValid)
        //    {
        //        Juries juries = new Juries();
        //        if (userPicture != null)
        //        {
        //            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);

        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/YarismaResimleri", fileName);

        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                await userPicture.CopyToAsync(stream);
        //                sKapak = "/YarismaResimleri/" + fileName;
        //            }
        //        }

        //        juries.fullName = juryModel.fullName;
        //        juries.duty = juryModel.duty;
        //        juries.job = juryModel.job;
        //        juries.status = true;
        //        juries.resume = juryModel.resume;
        //        juries.picture = sKapak;
        //        await _juriesRepository.Add(juries);
        //        return RedirectToAction("Index", "Jury");
        //    }
        //    return View(juryModel);
        //}

    }
}
