using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
            {
            return View( await _leaveTypeService.GetLeaveTypes());
        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _leaveTypeService.GetLeaveTypeDetails(id));
        }
        
        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeViewModel model)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(model);
                if (response.Success)
                {
                    return RedirectToAction("Index", "LeaveType");
                }
                ModelState.AddModelError("",response.ValidationErrors);
                return View();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("",exception.Message);
                return View();
            }
        }

        // GET: LeaveTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,LeaveTypeViewModel model)
        {
            try
            {
                await _leaveTypeService.UpdateLeaveType(id,model);
                return RedirectToAction("Index", "LeaveType");
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _leaveTypeService.DeleteLeaveType(id);
            return RedirectToAction("Index");
        }
    }
}
