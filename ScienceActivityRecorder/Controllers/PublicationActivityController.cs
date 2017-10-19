using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScienceActivityRecorder.Controllers
{
    public class PublicationActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}