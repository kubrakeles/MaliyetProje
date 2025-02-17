using BelediyeBusiness.Abstract;
using BelediyeDataAccess.Data;
using BelediyeEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using NotificationProject.Models;

namespace NotificationProject.Controllers
{

    public class NotificationController : Controller
    {
        INotificationService _notificationService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IUserService _userService;

        public NotificationController(INotificationService notificationService,IWebHostEnvironment webHostEnvironment ,IUserService userService,IHttpClientFactory httpClientFactory)
        {
           _notificationService=notificationService;
            _userService = userService;
            _httpClientFactory=httpClientFactory;
            _webHostEnvironment=webHostEnvironment;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("tr");
            return View();
        }

        public JsonResult GetAllNotification()
        {
            string deneme = "";
            var NotificationList = _notificationService.GetList().ToList();
            List<NotificationIndexModel> IndexModel = new List<NotificationIndexModel>();
            foreach (var item in NotificationList)
            {
                
                //_tenderTypeService.GetUnit(item.UnitId).UnitName.ToString();
                IndexModel.Add
                    (
                    new NotificationIndexModel
                    {
                        //BirimAdi = item.UnitId,
                        Title = item.title,
                        NotificationID = item.Id,
                        Message = item.Text,
                        NotificationDate = item.CreatedDate,
                        UserName=User.Claims.FirstOrDefault().ToString()
                        
                    }

                    );
                deneme = "";
            }
            return Json(IndexModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult NotificationAdd()
        {
            return View();
        }

      
        [Authorize]
        [HttpPost]
        public IActionResult NotificationAdd(NotificationModel model,IFormFile photo)
        {
            try
            {
                Notification Obj = new Notification();
               
                Obj.Text=model.Text;
                Obj.title=model.title;
                
                Obj.CreatedDate = DateTime.Now;
                Obj.email = User.Claims.FirstOrDefault().Value;
                

                var a = _notificationService.Add(Obj);
                if (a != null)
                {
                    ViewBag.success = true;
                    return RedirectToAction("Index", "Notification");
                }
                else
                {
                  
                    ViewBag.success = false;
                    ViewBag.HataMesaji = "İşlem Başarısız Oldu !";
                    return View(model);

                }
            }
            catch (Exception ex)
            {

                ViewBag.success = false;
                ViewBag.HataMesaji = "İşlem Başarısız Oldu !";
                return View(model);
            }
            return View(model); //RedirectToAction("AddTender", "Tender");
        }

    private void SendNotification(NotificationModel model){
        var url ="https://onesignal.com/api/v1/notifications";
        var appId="";
    }

        private Decimal Cevir(string a)
        { /*if (a == null) return 0;*/
            return Convert.ToDecimal(string.Format("{0:0.00}", a.Replace(".", "")).ToString().Replace(",", "."));
        }

        [Authorize]
        [HttpGet]
        public IActionResult NotificationPrinter(int id)
        {   
            return View();
        }


    }
}
