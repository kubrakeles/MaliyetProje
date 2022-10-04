using MaliyetBusiness.Abstract;
using MaliyetDataAccess.Data;
using MaliyetEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using UI.Models;

namespace UI.Controllers
{

    public class TenderController : Controller
    {
        ITenderService _tenderService;
        ITenderTypeService _tenderTypeService;
        IUnitService _unitService;
        IUserService _userService;

        public TenderController(ITenderService tenderService, ITenderTypeService tenderTypeService, IUnitService unitService, IUserService userService)
        {
            _tenderService = tenderService;
            _tenderTypeService = tenderTypeService;
            _unitService = unitService;
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {

            //var Tenders = _tenderService.GetAllWithSpec().Result;
            CultureInfo culture = CultureInfo.GetCultureInfo("tr");
            return View();

        }

        public JsonResult GetAllTender()
        {
            string deneme = "";
            var Tenders = _tenderService.GetList().ToList();
            List<TenderIndexModel> IndexModel = new List<TenderIndexModel>();
            foreach (var item in Tenders)
            {
                deneme = _unitService.Get(item.UnitId).UnitName.ToString();
                //_tenderTypeService.GetUnit(item.UnitId).UnitName.ToString();
                IndexModel.Add
                    (
                    new TenderIndexModel
                    {
                        //BirimAdi = item.UnitId,
                        Durum = item.TenderState,
                        TenderID = item.Id,
                        BirimAdi = deneme,
                        IhaleGeldigiTarih = item.TenderDateArrived,
                        IhaleTuru = _tenderTypeService.Get(item.TenderTypeId).TypeName.ToString(),
                        IsinAdi = item.JobName
                    }

                    );
                deneme = "";
            }
            return Json(IndexModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddTender()
        {
            BagliVeriler();
            return View();
        }

        public void BagliVeriler()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> units = new List<SelectListItem>();
            //Viewbag e buradan tendertypeları bağlayacağız.
            var TenderTypes = _tenderTypeService.GetList();
            var Units = _unitService.GetList();
            foreach (var tenderType in TenderTypes)
            {

                items.Add(new SelectListItem { Value = tenderType.Id.ToString(), Text = tenderType.TypeName });
            }
            foreach (var unit in Units)
            {
                units.Add(new SelectListItem { Value = unit.id.ToString(), Text = unit.UnitName });
            }

            ViewBag.Units = units;
            ViewBag.TenderTypes = items;
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
                Obj.OpproximateCost = Convert.ToDecimal(model.OpproximateCost);
                Obj.AnalysisRate = model.AnalysisRate;
                Obj.PoseRate = model.PoseRate;
                Obj.MarketResearchRate = model.MarketResearchRate;
                Obj.PreviousOpproximateCoast = Convert.ToDecimal(model.PreviousOpproximateCoast);
                Obj.PreviousOCTotal = Convert.ToDecimal(model.PreviousOCTotal);
                Obj.PreviousConractPrice = Convert.ToDecimal(model.PreviousConractPrice);
                Obj.PreviousCPTotal = Convert.ToDecimal(model.PreviousCPTotal);
                Obj.OtherFoundationContractPrice = Convert.ToDecimal(model.OtherFoundationContractPrice);
                Obj.OpproximateCostAfterTender = Convert.ToDecimal(model.OpproximateCostAfterTender);
                Obj.Contratprice = Convert.ToDecimal(model.Contratprice);
                Obj.KirimRate = model.KirimRate;
                Obj.TendererProposal = model.TendererProposal;
                Obj.EnthusiastFoundation = model.EnthusiastFoundation;
                Obj.City = "Adana";
                Obj.TenderTypeName = "";
                Obj.UpdatedEmail = "";
                Obj.UpdateDate = DateTime.Now;
                Obj.Scor = model.Scor;
                Obj.TenderTypeId = model.TenderTypeId;
                Obj.PriceDifference = model.PriceDifference;
                Obj.OtherExplanation = model.OtherExplanation;
                Obj.TenderDateArrived = model.TenderDateArrived;
                Obj.TenderState = model.TenderState;
                Obj.CreatedDate = DateTime.Now;
                Obj.IsDeleted = 0;
                Obj.CreatedEmail = User.Claims.FirstOrDefault().Value;

                var a = _tenderService.Add(Obj);
                if (a != null)
                {
                    ViewBag.success = true;
                    return RedirectToAction("Index", "Tender");
                }
                else
                {
                    BagliVeriler();
                    ViewBag.success = false;
                    ViewBag.HataMesaji = "İşlem Başarısız Oldu !";
                    return View(model);

                }
            }
            catch (Exception ex)
            {
               
                BagliVeriler();
                ViewBag.success = false;
                ViewBag.HataMesaji = "İşlem Başarısız Oldu !";
                return View(model);
            }
            return View(model); //RedirectToAction("AddTender", "Tender");
        }
        private Decimal Cevir(string a)
        { /*if (a == null) return 0;*/
            return Convert.ToDecimal(string.Format("{0:0.00}", a.Replace(".", "")).ToString().Replace(",", "."));
        }
        [Authorize]
        [HttpGet]
        public IActionResult TenderDetails(int id)
        {
            TenderModel model = new TenderModel();
            var TenderByGet = _tenderService.GetById(id);
            string UnitName = _unitService.Get(TenderByGet.Data.UnitId).UnitName.ToString();
            string TenderTypeName = _tenderTypeService.Get(TenderByGet.Data.TenderTypeId).TypeName.ToString();
            model.TenderID = TenderByGet.Data.Id;
            model.TenderingProcedure = TenderByGet.Data.TenderingProcedure;
            model.TenderDate = TenderByGet.Data.TenderDate;
            model.JobName = TenderByGet.Data.JobName;
            model.TenderRegisterNo = TenderByGet.Data.TenderRegisterNo;
            model.UnitId = TenderByGet.Data.UnitId;
            model.Contratprice = TenderByGet.Data.Contratprice.ToString("C", CultureInfo.CurrentCulture) ;
            model.TenderDateArrived = TenderByGet.Data.TenderDateArrived;
            model.JobTypeWorkLoad = TenderByGet.Data.JobTypeWorkLoad;
            model.OpproximateCost = TenderByGet.Data.OpproximateCost.ToString("C", CultureInfo.CurrentCulture) ;
            model.AnalysisRate = TenderByGet.Data.AnalysisRate;
            model.PoseRate = TenderByGet.Data.PoseRate;
            model.MarketResearchRate = TenderByGet.Data.MarketResearchRate;
            model.PreviousOpproximateCoast = TenderByGet.Data.PreviousOpproximateCoast.ToString("C", CultureInfo.CurrentCulture);
            model.PreviousOCTotal = TenderByGet.Data.PreviousOCTotal.ToString("C", CultureInfo.CurrentCulture);
            model.PreviousCPTotal = TenderByGet.Data.PreviousCPTotal.ToString("C", CultureInfo.CurrentCulture);
            model.OtherFoundationContractPrice = TenderByGet.Data.OtherFoundationContractPrice.ToString("C", CultureInfo.CurrentCulture);
            model.OpproximateCostAfterTender = TenderByGet.Data.OpproximateCostAfterTender.ToString("C", CultureInfo.CurrentCulture);
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
            model.PreviousConractPrice = TenderByGet.Data.PreviousConractPrice.ToString("C", CultureInfo.CurrentCulture);
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TenderPrinter(int id)
        {
            TenderModel model = new TenderModel();
            var TenderByGet = _tenderService.GetById(id);
            string UnitName = _unitService.Get(TenderByGet.Data.UnitId).UnitName.ToString();
            string TenderTypeName = _tenderTypeService.Get(TenderByGet.Data.TenderTypeId).TypeName.ToString();
            model.TenderID = TenderByGet.Data.Id;
            model.TenderingProcedure = TenderByGet.Data.TenderingProcedure;
            model.TenderRegisterNo = TenderByGet.Data.TenderRegisterNo;
            model.TenderDate = TenderByGet.Data.TenderDate;
            model.JobName = TenderByGet.Data.JobName;
            model.UnitId = TenderByGet.Data.UnitId;
            model.Contratprice = TenderByGet.Data.Contratprice.ToString("C", CultureInfo.CurrentCulture) ;
            model.TenderDateArrived = TenderByGet.Data.TenderDateArrived;
            model.JobTypeWorkLoad = TenderByGet.Data.JobTypeWorkLoad;
            model.OpproximateCost = TenderByGet.Data.OpproximateCost.ToString("C", CultureInfo.CurrentCulture) ;
            model.AnalysisRate = TenderByGet.Data.AnalysisRate;
            model.PoseRate = TenderByGet.Data.PoseRate;
            model.MarketResearchRate = TenderByGet.Data.MarketResearchRate;
            model.PreviousOpproximateCoast = TenderByGet.Data.PreviousOpproximateCoast.ToString("C", CultureInfo.CurrentCulture);
            model.PreviousOCTotal = TenderByGet.Data.PreviousOCTotal.ToString("C", CultureInfo.CurrentCulture);
            model.PreviousCPTotal = TenderByGet.Data.PreviousCPTotal.ToString("C", CultureInfo.CurrentCulture);
            model.OtherFoundationContractPrice = TenderByGet.Data.OtherFoundationContractPrice.ToString("C", CultureInfo.CurrentCulture) ;
            model.OpproximateCostAfterTender = TenderByGet.Data.OpproximateCostAfterTender.ToString("C", CultureInfo.CurrentCulture) ;
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
            model.PreviousConractPrice = TenderByGet.Data.PreviousConractPrice.ToString("C", CultureInfo.CurrentCulture);
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TenderEdit(int id)
        {
            BagliVeriler();
            TenderModel model = new TenderModel();
            var TenderByGet = _tenderService.GetById(id);
            string UnitName = _unitService.Get(TenderByGet.Data.UnitId).UnitName.ToString();
            string TenderTypeName = _tenderTypeService.Get(TenderByGet.Data.TenderTypeId).TypeName.ToString();
            model.TenderID = TenderByGet.Data.Id;
            model.TenderingProcedure = TenderByGet.Data.TenderingProcedure;
            model.TenderDate = TenderByGet.Data.TenderDate;
            model.JobName = TenderByGet.Data.JobName;
            model.TenderRegisterNo = TenderByGet.Data.TenderRegisterNo;
            model.UnitId = TenderByGet.Data.UnitId;
            model.Contratprice = TenderByGet.Data.Contratprice.ToString("C", CultureInfo.CurrentCulture) ;
            model.TenderDateArrived = TenderByGet.Data.TenderDateArrived;
            model.JobTypeWorkLoad = TenderByGet.Data.JobTypeWorkLoad;
            model.OpproximateCost = TenderByGet.Data.OpproximateCost.ToString("C", CultureInfo.CurrentCulture) ;
            model.AnalysisRate = TenderByGet.Data.AnalysisRate;
            model.PoseRate = TenderByGet.Data.PoseRate;
            model.MarketResearchRate = TenderByGet.Data.MarketResearchRate;
            model.PreviousOpproximateCoast = TenderByGet.Data.PreviousOpproximateCoast.ToString("C", CultureInfo.CurrentCulture) ;
            model.PreviousOCTotal = TenderByGet.Data.PreviousOCTotal.ToString("C", CultureInfo.CurrentCulture) ;
            model.PreviousCPTotal = TenderByGet.Data.PreviousCPTotal.ToString("C", CultureInfo.CurrentCulture) ;
            model.OtherFoundationContractPrice = TenderByGet.Data.OtherFoundationContractPrice.ToString("C", CultureInfo.CurrentCulture) ;
            model.OpproximateCostAfterTender = TenderByGet.Data.OpproximateCostAfterTender.ToString("C", CultureInfo.CurrentCulture) ;
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
            model.PreviousConractPrice = TenderByGet.Data.PreviousConractPrice.ToString("C", CultureInfo.CurrentCulture) ;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult TenderEdit(TenderModel model)
        {
            var updatedObj = _tenderService.GetById(model.TenderID).Data;
          
                if(updatedObj != null)
                {
                    updatedObj.TenderingProcedure = model.TenderingProcedure;
                    updatedObj.JobName = model.JobName;
                    updatedObj.UnitId = model.UnitId;
                    updatedObj.TenderRegisterNo = model.TenderRegisterNo;
                    updatedObj.TenderDate = model.TenderDate;
                    updatedObj.JobTypeWorkLoad = model.JobTypeWorkLoad;
                    updatedObj.OpproximateCost =Convert.ToDecimal(model.OpproximateCost);
                    updatedObj.AnalysisRate = model.AnalysisRate;
                    updatedObj.PoseRate = model.PoseRate;
                    updatedObj.MarketResearchRate = model.MarketResearchRate;
                    updatedObj.PreviousOpproximateCoast = Convert.ToDecimal(model.PreviousOpproximateCoast);
                    updatedObj.PreviousOCTotal = Convert.ToDecimal(model.PreviousOCTotal);
                    updatedObj.PreviousConractPrice = Convert.ToDecimal(model.PreviousConractPrice);
                    updatedObj.PreviousCPTotal = Convert.ToDecimal(model.PreviousCPTotal);
                    updatedObj.OtherFoundationContractPrice = Convert.ToDecimal(model.OtherFoundationContractPrice);
                    updatedObj.OpproximateCostAfterTender = Convert.ToDecimal(model.OpproximateCostAfterTender);
                    updatedObj.Contratprice = Convert.ToDecimal(model.Contratprice);
                    updatedObj.KirimRate = model.KirimRate;
                    updatedObj.TendererProposal = model.TendererProposal;
                    updatedObj.EnthusiastFoundation = model.EnthusiastFoundation;
                    updatedObj.City = model.City;
                    updatedObj.Scor = model.Scor;
                    updatedObj.TenderTypeId = model.TenderTypeId;
                    updatedObj.PriceDifference = model.PriceDifference;
                    updatedObj.OtherExplanation = model.OtherExplanation;
                    updatedObj.TenderDateArrived = model.TenderDateArrived;
                    updatedObj.TenderState = model.TenderState;
                    updatedObj.UpdateDate = DateTime.Now;
                    updatedObj.UpdatedEmail = User.Claims.FirstOrDefault().Value;
                   var a= _tenderService.Update(updatedObj);


                if (a != null)
                {
                    ViewBag.success = "true";
                    return RedirectToAction("TenderDetails", "Tender", new { id = model.TenderID });

                }
                else
                {
                    BagliVeriler();
                    ViewBag.success = false;
                    ViewBag.HataMesaji = "İşlem Başarısız Oldu !";
                    return View(model);


                }
               
            }
            return View(model); //RedirectToAction("AddTender", "Tender");
        }
    }
}
