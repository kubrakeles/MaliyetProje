using MaliyetBusiness.Abstract;
using MaliyetEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
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
            CultureInfo culture = CultureInfo.GetCultureInfo("tr");
            return View();
           
        }

        public JsonResult GetAllTender()
        {
            var Tenders = _tenderService.GetList();
            List<TenderIndexModel> IndexModel = new List<TenderIndexModel>();
            foreach (var item in Tenders)
            {
                IndexModel.Add
                    (
                    new TenderIndexModel
                    {
                        BirimAdi = _tenderTypeService.GetUnits().FirstOrDefault(x => x.id == item.UnitId).UnitName.ToString(),
                        Durum = item.TenderState,
                        TenderID = item.Id,
                        IhaleGeldigiTarih = item.TenderDateArrived,
                        IhaleTuru = _tenderTypeService.GetList().FirstOrDefault(x => x.Id == item.TenderTypeId).TypeName.ToString(),
                        IsinAdi = item.JobName
                    }

                    );

            }
            return Json(IndexModel);
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
        public IActionResult AddTender(TenderModel model)
        {
            try
            {
                    Tender Obj = new Tender();
                    Obj.TenderingProcedure = model.TenderingProcedure;
                    Obj.JobName = model.JobName;
                    Obj.UnitId = model.UnitId;
                    Obj.TenderRegisterNo = model.TenderRegisterNo;
                    Obj.TenderDate = model.TenderDate;
                    Obj.JobTypeWorkLoad = model.JobTypeWorkLoad;
                    Obj.OpproximateCost = model.OpproximateCost;
                    Obj.AnalysisRate = model.AnalysisRate;
                    Obj.PoseRate = model.PoseRate;
                    Obj.MarketResearchRate = model.MarketResearchRate;
                    Obj.PreviousOpproximateCoast = model.PreviousOpproximateCoast;
                    Obj.PreviousOCTotal = model.PreviousOCTotal;
                    Obj.PreviousConractPrice = model.PreviousConractPrice;
                    Obj.PreviousCPTotal = model.PreviousCPTotal;
                    Obj.OtherFoundationContractPrice = model.OtherFoundationContractPrice;
                    Obj.OpproximateCostAfterTender = model.OpproximateCostAfterTender;
                    Obj.Contratprice = model.Contratprice;
                    Obj.KirimRate = model.KirimRate;
                    Obj.TendererProposal = model.TendererProposal;
                    Obj.EnthusiastFoundation = model.EnthusiastFoundation;
                    Obj.City = model.City;
                    Obj.Scor = model.Scor;
                    Obj.TenderTypeId = model.TenderTypeId;
                    Obj.PriceDifference = model.PriceDifference;
                    Obj.OtherExplanation = model.OtherExplanation;
                    Obj.TenderDateArrived = model.TenderDateArrived;
                    Obj.TenderState = model.TenderState;
                    _tenderService.Add(Obj);
                    return RedirectToAction("AddTender", "Tender");
            }
            catch (Exception ex)
            {
                
            }
            return View(model); //RedirectToAction("AddTender", "Tender");
        }
        [Authorize]
        [HttpGet]
        public IActionResult TenderDetails(int id)
        {
            TenderModel model = new TenderModel();
            
            var TenderByGet=_tenderService.GetById(id);
            string UnitName = _tenderTypeService.GetUnit(TenderByGet.Data.UnitId).UnitName.ToString();
            string TenderTypeName=_tenderTypeService.Get(TenderByGet.Data.TenderTypeId).TypeName.ToString();
            model.TenderID = TenderByGet.Data.Id;
            model.TenderingProcedure = TenderByGet.Data.TenderingProcedure;
            model.TenderDate = TenderByGet.Data.TenderDate;
            model.JobName = TenderByGet.Data.JobName;
            model.UnitId = TenderByGet.Data.UnitId;
            model.Contratprice = TenderByGet.Data.Contratprice;
            model.TenderDateArrived = TenderByGet.Data.TenderDateArrived;
            model.JobTypeWorkLoad= TenderByGet.Data.JobTypeWorkLoad;
            model.OpproximateCost = TenderByGet.Data.OpproximateCost;
            model.AnalysisRate = TenderByGet.Data.AnalysisRate;
            model.PoseRate = TenderByGet.Data.PoseRate;
            model.MarketResearchRate = TenderByGet.Data.MarketResearchRate;
            model.PreviousOpproximateCoast = TenderByGet.Data.PreviousOpproximateCoast;
            model.PreviousOCTotal = TenderByGet.Data.PreviousOCTotal;
            model.PreviousCPTotal = TenderByGet.Data.PreviousCPTotal;
            model.OtherFoundationContractPrice = TenderByGet.Data.OtherFoundationContractPrice;
            model.OpproximateCostAfterTender = TenderByGet.Data.OpproximateCostAfterTender;
            model.KirimRate = TenderByGet.Data.KirimRate;
            model.TendererProposal = TenderByGet.Data.TendererProposal;
            model.EnthusiastFoundation = TenderByGet.Data.EnthusiastFoundation;
            model.City = TenderByGet.Data.City;
            model.Scor = TenderByGet.Data.Scor;
            model.PriceDifference = TenderByGet.Data.PriceDifference;
            model.OtherExplanation = TenderByGet.Data.OtherExplanation;
            model.TenderDateArrived = TenderByGet.Data.TenderDateArrived;
            model.TenderState = TenderByGet.Data.TenderState;
            model.UnitName = UnitName;
            model.TenderTypeName = TenderTypeName;
            model.PreviousConractPrice= TenderByGet.Data.PreviousConractPrice;
            return View(model);
        }
        [Authorize]
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
