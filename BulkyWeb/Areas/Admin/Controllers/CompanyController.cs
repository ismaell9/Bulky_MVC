using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Company> objectCompanyList = _UnitOfWork.Company.GetAll().ToList();
            
            return View(objectCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            
            if(id==null || id == 0)
            {
                // create
                return View(new Company());
            }
            else
            {
                
                Company Company = _UnitOfWork.Company.Get(u=>u.Id==id);
                return View(Company);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company Company, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                
                if(Company.Id==0)
                {
                    _UnitOfWork.Company.Add(Company);

                }
                else
                {
                    _UnitOfWork.Company.Update(Company);
                }
                _UnitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            else
            { 
                return View(Company);
            }
            

        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _UnitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _UnitOfWork.Company.Get(u=>u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
                
            _UnitOfWork.Company.Remove(CompanyToBeDeleted);
            _UnitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
