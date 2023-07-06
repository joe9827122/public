using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataTableTest.Controllers
{
    public class HomeController : Controller
    {
        readonly IConfiguration? _configuration;

        public HomeController(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewOpera()
        {
            string connectionString = _configuration.GetConnectionString("OperaContext");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "select * from Opera",
                    connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
            }

            return View();
        }
    }
}
