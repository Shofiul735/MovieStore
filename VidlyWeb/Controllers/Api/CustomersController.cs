using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VidlyWeb.Dtos;
using VidlyWeb.Models;

namespace VidlyWeb.Controllers.Api
{

    [ApiController]
    [Route("api/[controller]")] // we can add action Route("api/[controller]/[action]")
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CustomersController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public JsonResult GetCustomers()
        {
            return new JsonResult(Ok(_db.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>)));
        }
        [HttpGet("{id}")]
        public JsonResult Customer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);  
            if(customer == null)
            {
                return new JsonResult(NotFound(customer));
            }
            return new JsonResult(Ok(_mapper.Map<Customer, CustomerDto>(customer)));
        }
        [HttpPost]
        public JsonResult AddCustomer(CustomerDto customerdto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerdto);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            customerdto.Id = customer.Id;
            return new JsonResult(Ok(customerdto));

        }
        [HttpPut]
        public JsonResult UpdateCustomer(CustomerDto customer)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest(customer));
            var customerInDb = _db.Customers.SingleOrDefault(x => x.Id == customer.Id);
            if(customer == null)
            {
                return new JsonResult(NotFound(customer));
            }
            _mapper.Map<CustomerDto, Customer>(customer, customerInDb);
            _db.Customers.Update(customerInDb);
            _db.SaveChanges();
            return new JsonResult(Ok(customer));
        }
        [HttpDelete]
        [Route("{id}")]
        public JsonResult DeleteCustomer(int id)
        {
            var customer = _db.Customers.SingleOrDefault(x => x.Id == id);
            if(customer == null)
            {
                return new JsonResult(BadRequest(customer));
            }
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return new JsonResult(Ok(customer));
        }
    }
}
