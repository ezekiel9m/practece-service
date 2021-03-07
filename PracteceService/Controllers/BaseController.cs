using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PracteceService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace PracteceService.Controllers
{
   
    public class BaseController : Controller
    {
        public IActionResult ResponseByCode(int responseCode, dynamic obj = null) => StatusCode(responseCode, obj);

        public IActionResult ResponseByCode(TecmExceptions.TecmErrorException obj) => StatusCode(obj.ErrorModel.ErrorCode, obj.ErrorModel);

        public IActionResult InternalServerError(dynamic obj = null) => StatusCode((int)HttpStatusCode.InternalServerError, obj);

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Created(object value = null)
        {
            if (value == null)
                return StatusCode((int)HttpStatusCode.Created, value);

            var settings = new JsonSerializerSettings() {  };

            var responseStr = JsonConvert.SerializeObject(value, settings);

            var response = JsonConvert.DeserializeObject(responseStr);

            return StatusCode((int)HttpStatusCode.Created, response);
        }
    }
}
