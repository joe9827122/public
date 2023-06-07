using Microsoft.AspNetCore.Mvc;
using StarterM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarterM.Controllers
{
    //API使用的是 ControllerBase
    //MVC使用的是 Controller
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly List<Customer> _customers;

        public CustomersController(List<Customer> customers)
        {
            _customers = customers;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }


        //一般型別 ex: Customer
        //IActionResult Return: Helper   ex: NotFound()     MVC只使用這種
        //ActionResult<T> Return: Helper or T  ex: NotFound() or item
        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            var item = _customers.Find(c => c.CustomerID == id);

            //如果失敗，會回傳Json的404資料
            if (item == null) return NotFound();

            return item;
        }

        //FromForm 接收FormData 表單資料
        //FromBody 接收Json資料類型
        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromForm] Customer customer)
        {
            _customers.Add(customer);
            return CreatedAtAction(nameof(Get), new
            {
                id = customer.CustomerID 
            }, customer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromForm] Customer customer)
        {
            var item = _customers.Find(c => c.CustomerID == id);
            if (item == null) return NotFound();
            item.CompanyName = customer.CompanyName;
            item.Country = customer.Country;

            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _customers.Find(c => c.CustomerID == id);
            if (item == null) return NotFound();

            _customers.Remove(item);   
            return NoContent();
        }
    }
}
