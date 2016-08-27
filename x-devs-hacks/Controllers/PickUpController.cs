using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using x_devs_hacks.Models;

namespace x_devs_hacks.Controllers
{
    public class PickUpController : Controller
    {
        //
        // GET: /PickUpRequest/
        PickUpModel pickUpM = new PickUpModel();

        public ActionResult Index()
        {
            return View();
        }

        public string getAllPickUps() {

            JavaScriptSerializer jSS = new JavaScriptSerializer();

            List<PickUpModel> lstPickUps = pickUpM.getAllPickUps();

            return jSS.Serialize(lstPickUps);
        
        }

   


    }
}
