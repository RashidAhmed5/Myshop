using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mystore.Web.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Services;
using MyStore.Services.DBModels;
using MyStore.Web.Help;
using AspNetCoreHero.ToastNotification.Abstractions;
using MyStore.Services.Repository.Interfaces;

namespace MyStore.Web.Controllers
{
    public class CategoryController : BaseController
    {
 
        private readonly ICategory _categoryService;
        private readonly IRazorRenderService _renderService;
        private readonly INotyfService _notifyService;

        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, ICategory categoryService, IRazorRenderService renderService, INotyfService notifyService)
        {
          //  _currentUser = scopedUser;
            _logger = logger;
            _categoryService = categoryService;
            _renderService = renderService;
            _notifyService = notifyService;
        }
     
        public IActionResult Index()
        {
            return View();
        }

       
        public async Task<IActionResult> getCategories(IDataTablesRequest request)
        {
            try
            {
                var searchValue = HttpContext.Request.Query["search[value]"].FirstOrDefault();
                  var result = await _categoryService.GetCategories(searchValue, request.Start, request.Length);
                  var response = DataTablesResponse.Create(request, result.Count, result.Count, result);
                 return new DataTablesJsonResult(response, true);
               /// return View();
            }
            catch (Exception ex)
            {
                _notifyService.Error("Internal server error.");
                _logger.LogError(ex.Message);
                throw;
            }
        }

       
        public async Task<ActionResult> CreateOrEdit(int id = 0)
        {
            try
            {
                if (id == 0)
                    return PartialView("_CreateOrEdit", new ProductCategory());
                else
                {
                    var result = await _categoryService.Get(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return PartialView("_CreateOrEdit", result);
                }
                return View();
            }
            catch (Exception ex)
            {
                _notifyService.Error("Internal server error.");
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrEdit(int id, ProductCategory categoryvm)
        {
           // ErrorCode error = ErrorCodes.SUCCESS;
            string alertMessage = "";
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", categoryvm) });

                //Insert
                if (id == 0)
                {
                    //divisionVM.CreatedAt = DateTime.Now;
                    //divisionVM.CreatedBy = _currentUser.GetId();
                    //divisionVM.IsActive = true;
                   var error = await _categoryService.Add(categoryvm);
                    alertMessage = "Product Category added Successfully";
                }
                //Update
                else
                {

                    //divisionVM.ModifiedAt = DateTime.Now;
                    //divisionVM.ModifiedBy = _currentUser.GetId();
                    //divisionVM.IsActive = true;
                    //error = await _divisionService.UpdateDivision(divisionVM);
                    var error = await _categoryService.Update(categoryvm);
                    alertMessage = "Product Category update successfully";
                }

                //if (error != ErrorCodes.SUCCESS)
                //{
                //    _notifyService.Error(error.Message);
                //    return RedirectToAction("Index");
                //}

                //if (error == ErrorCodes.SUCCESS)
                //{
                //    _notifyService.Success(alertMessage);
                    return RedirectToAction("Index");
                //}
                //else
                //    return View(divisionVM);
            }

            catch (Exception ex)
            {
                _notifyService.Error("Internal server error.");
                _logger.LogError(ex.Message);
                // throw ex;
            }

            return RedirectToAction("Index", this);
        }

    }
}