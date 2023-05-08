using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopMashtiHasan.Models;

namespace EShopMashtiHasan.Controllers
{
    public class BinaryOperationController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeAdd(Numbers n)
        {
            ViewBag.Sum = n.FirstNumber + n.SecondNumber;
            return View();
        }

        public IActionResult Sub()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeSub(Numbers n)
        {
            n.Result = n.FirstNumber - n.SecondNumber;
            return View(n);
        }

        public IActionResult Mult()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mult(Numbers n)
        {
            n.Result = n.FirstNumber * n.SecondNumber;
            return View(n);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
