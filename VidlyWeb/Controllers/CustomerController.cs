using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VidlyWeb.Models;
using VidlyWeb.ViewModels;

namespace VidlyWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Customers = _db.Customers.Include(c => c.MembershipType).ToList();
            return View(Customers);
        }

        public IActionResult UserDetails(int id)
        {
            Customer? customer = _db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult NewCustomer()
        {
            var MembershipTypes = _db.MembershipTypes.ToList();
            var ViewModel = new AddCustomerViewModel()
            {
                MembershipTypes = new List<SelectListItem>(),
            };
            foreach (var type in MembershipTypes)
            {
                ViewModel.MembershipTypes.Add(new SelectListItem() { Text = type.MembershipTypeName, Value = Convert.ToString(type.Id) });
            }
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewCustomer(AddCustomerViewModel ViewModel)
        {
            Debug.WriteLine(ModelState.IsValid); // Why it's false?!
            
            if (ViewModel.Customer != null)
            {
                _db.Customers.Add(ViewModel.Customer);
                _db.SaveChanges();
                TempData["CustomerAdded"] = "Customer added successfully!";
            }else
            {
                TempData["CustomerAddFailed"] = "Customer add operation failed!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            var membershipTypes = _db.MembershipTypes.ToList();
            var viewModel = new AddCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = new List<SelectListItem>()
            };
            foreach(var i in membershipTypes){
                viewModel.MembershipTypes.Add(new SelectListItem() { Value = Convert.ToString(i.Id),Text = i.MembershipTypeName });
            }
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if(customer != null)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                TempData["CustomerAdded"] = "Customer Updated successfully!";
            }
            else
            {
                TempData["CustomerAddFailed"] = "Customer add operation failed!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return BadRequest();
            }
            _db.Customers.Remove(customer);
            _db.SaveChanges(true);
            TempData["CustomerDeleted"] = $"Customer:- {customer.Name} Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
