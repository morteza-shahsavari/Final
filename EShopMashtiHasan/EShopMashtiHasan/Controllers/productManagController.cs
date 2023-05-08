
using EShopMashtiHasan.Helper;
using EShopMashtiHasan.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.Domain.DTO.RoleAction;
using Security.Framework;

using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.Models;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using ZarinpalSandbox;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class productManagController : Controller
    {
        private readonly IProductBuss probuss;
        private readonly ICatBuss catbuss;
        private readonly ISupplierBuss supbuss;
        private readonly IHostingEnvironment env;
        public productManagController(IProductBuss probuss, ICatBuss catbuss, ISupplierBuss supbuss, IHostingEnvironment env)
        {
            this.probuss = probuss;
            this.catbuss = catbuss;
            this.supbuss = supbuss;
            this.env = env;
        }
        private void setPager(ProductSearchModel sm)
        {
            if (sm.RecordCount % sm.PageSize == 0)
            {
                sm.pageCount = sm.RecordCount / sm.PageSize;
            }
            else
            {
                sm.pageCount = sm.RecordCount / sm.PageSize + 1;
            }
            ViewBag.sm = sm;

        }
        private void InflatedrpSearchCategory()
        {
            var drpCat = catbuss.GetAll();
            drpCat.Insert(0, new Category { CategoryID = -1, CategoryName = "...دسته بندی..." });
            SelectList drCat = new SelectList(drpCat, "CategoryID", "CategoryName");
            ViewBag.DrpCategory = drCat;
        }
        private void InflatedrpSearchSupplier()
        {
            var drpsup = supbuss.GetAll();
            drpsup.Insert(0, new Supplier { SupplierID = -1, SupplierName = "...سازنده..." });
            SelectList drSup = new SelectList(drpsup, "SupplierID", "SupplierName");
            ViewBag.DrpSupplier = drSup;
        }
        public IActionResult Index(ProductSearchModel sm)
        {
            if (sm.CategoryID == -1)
            {
                sm.CategoryID = null;
            }
            int rc = 0;
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }

            var PC = probuss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);

            return View(PC.MainResults);
        }

        public IActionResult Delete(int Id)
        {
            var op = probuss.Delete(Id);
            if (!op.Success)
            {
                TempData["ErrorDelete"] = op.Message;

            }
            return RedirectToAction("Index", "ProductManag");
        }


        public IActionResult AddNew()
        {
            Preparefunctions();
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(ProductAddViewModel prod)
        {
            if (!ModelState.IsValid)
            {
                Preparefunctions();
                return View(prod);
            }
            if (prod.CategoryID == -1 || prod.SupplierID == -1)
            {
                TempData["ErrorMessage"] = "دسته بندی یا سازنده محصول را وارد کنید";
                Preparefunctions();
                return View(prod);
            }


            var fn = System.IO.Path.GetFileName(prod.Picture1.FileName);
            if (!fn.IsValidFileName())
            {
                TempData["ErrorMesssage"] = "نام فایل صحیح نمیباشد";
                Preparefunctions();
                return View(prod);
            }

            if (prod.Picture1.Length < 5000 || prod.Picture1.Length > 480000)
            {
                TempData["ErrorMessage"] = "حجم فایل صحیح نمیباشد";
                Preparefunctions();
                return View(prod);
            }
            if (!fn.ToLower().EndsWith(".jpg") && !fn.ToLower().EndsWith(".png"))
            {
                TempData["ErrorMesssage"] = "پسوند فایل صحیح نمیباشد";
                Preparefunctions();
                return View(prod);
            }


            fn = fn.ToUniqueFileName();
            var path = $"{env.WebRootPath}/ProductImages/{fn}";
            var dbName = $"~/ProductImages/{fn}";

           



            Product p = new Product
            {
                CategoryID = prod.CategoryID
                ,
                Description = prod.Description
                ,
                Picture1 = dbName
                ,
                
                ProductName = prod.ProductName
                ,
                SmallDescription = prod.SmallDescription
                ,
                SupplierID = prod.SupplierID
                ,
                UnitPrice = prod.UnitPrice
                ,
                ShowInAmazingOffer = prod.ShowInAmazingOffer
                ,
                ShowInInstantOffer = prod.ShowInInstantOffer
                ,
                IsNew = prod.IsNew,
                ExpireDateSpecialOffer = prod.ExpireDateSpecialOffer
            };

            FileStream fs = new FileStream(path, FileMode.Create);
            prod.Picture1.CopyTo(fs);



            if (prod.Picture2 != null)
            {
                var fn1 = System.IO.Path.GetFileName(prod.Picture2.FileName);

                if (!fn1.IsValidFileName())
                {
                    TempData["ErrorMessage"] = "نام فایل صحیح نمیباشد";
                    Preparefunctions();
                    return View(prod);
                }

                if (prod.Picture2.Length < 5000 || prod.Picture2.Length > 480000)
                {
                    TempData["ErrorMessage"] = "حجم فایل صحیح نمیباشد";
                    Preparefunctions();
                    return View(prod);
                }
                if (!fn1.ToLower().EndsWith(".jpg") && !fn1.ToLower().EndsWith(".png"))
                {
                    TempData["ErrorMessage"] = "پسوند فایل صحیح نمیباشد";
                    Preparefunctions();
                    return View(prod);
                }
                fn1 = fn1.ToUniqueFileName();
                var path1 = $"{env.WebRootPath}/ProductImages/{fn1}";
                var dbName1 = $"~/ProductImages/{fn1}";

                p.Picture2 = dbName1;

                FileStream fs1 = new FileStream(path1, FileMode.Create);
                prod.Picture1.CopyTo(fs1);
            }

            


            var op = probuss.AddNew(p);
            if (!op.Success)
            {
                TempData["ErrorMessage"] = op.Message;
                Preparefunctions();

                return View(prod);
            }
            return RedirectToAction("Index", "ProductManag");
        }


        public IActionResult Update(int id)
        {
            var p = probuss.Get(id);
            ViewBag.pic1=
                p.Picture1;
            ViewBag.pic2 =
               p.Picture2;
            ProductUpdateViewModel prod = new ProductUpdateViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                SmallDescription = p.SmallDescription,
                SupplierID = p.SupplierID,
                UnitPrice = p.UnitPrice,
                CategoryID = p.CategoryID,
                Description = p.Description

            };
            Preparefunctions();
            return View(prod);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductUpdateViewModel prod)
        {
            var p = probuss.Get(prod.ProductID);
            p.CategoryID = prod.CategoryID;
            p.SupplierID = prod.SupplierID;
            p.UnitPrice = prod.UnitPrice;
            p.Description = prod.Description;
            p.ProductName = prod.ProductName;
            p.SmallDescription = p.SmallDescription;


            if (!ModelState.IsValid)
            {
                Preparefunctions(prod.ProductID);
                return View(prod);
            }
            if (prod.CategoryID == -1 || prod.SupplierID == -1)
            {
                TempData["ErrorMessage"] = "دسته بندی یا سازنده محصول را وارد کنید";
                Preparefunctions(prod.ProductID);
                return View(prod);
            }
            


            
           
           
            if (prod.Picture1!= null) {
                var fn = System.IO.Path.GetFileName(prod.Picture1.FileName);
                if (!fn.IsValidFileName())
                {
                    TempData["ErrorMessage"] = "نام فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }

                if (prod.Picture1.Length < 5000 || prod.Picture1.Length > 480000)
                {
                    TempData["ErrorMessage"] = "حجم فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }
                if (!fn.ToLower().EndsWith(".jpg") && !fn.ToLower().EndsWith(".png"))
                {
                    TempData["ErrorMessage"] = "پسوند فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }


                fn = fn.ToUniqueFileName();
                var path = $"{env.WebRootPath}/ProductImages/{fn}";
                var dbName = $"~/ProductImages/{fn}";
                p.Picture1 = dbName;

                FileStream fs = new FileStream(path, FileMode.Create);
                prod.Picture1.CopyTo(fs);
            }
          
             if (prod.Picture2 != null)
                {
                    var fn1 = System.IO.Path.GetFileName(prod.Picture2.FileName);
                    if (!fn1.IsValidFileName())
                {
                    TempData["ErrorMessage"] = "نام فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }

                if (prod.Picture2.Length < 5000 || prod.Picture2.Length > 480000)
                {
                    TempData["ErrorMessage"] = "حجم فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }
                if (!fn1.ToLower().EndsWith(".jpg") && !fn1.ToLower().EndsWith(".png"))
                {
                    TempData["ErrorMessage"] = "پسوند فایل صحیح نمیباشد";
                    Preparefunctions(prod.ProductID);
                    return View(prod);
                }


                fn1 = fn1.ToUniqueFileName();
                var path2 = $"{env.WebRootPath}/ProductImages/{fn1}";
                var dbName = $"~/ProductImages/{fn1}";
                p.Picture2 = dbName;

                FileStream fs = new FileStream(path2, FileMode.Create);
                prod.Picture2.CopyTo(fs);
            }


            var op = probuss.Update(p);
            if (!op.Success)
            {
                TempData["ErrorMessage"] = op.Message;
                Preparefunctions(prod.ProductID);
                return View(prod);
            }

            return RedirectToAction("Index", "ProductManag");
        }

        private void  Preparefunctions(int id)
        {
            var p = probuss.Get(id);
            InflatedrpSearchCategory();
            InflatedrpSearchSupplier();
            ViewBag.pic1 = p.Picture1;
            ViewBag.pic2 = p.Picture2;
        }
        private void Preparefunctions()
        {
            InflatedrpSearchCategory();
            InflatedrpSearchSupplier();
        }





        public IActionResult ProductSearchBox(ProductSearchModel sm)
        {
            return ViewComponent("ProductSearchBox", sm);
        }

    }
}