using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ILoggerManager _logger;

        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeesController(ILoggerManager logger, IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            _logger.LogInfo("here is an info message from our values controller");
            _logger.LogDebug("here is a debug message from our values controller");
            _logger.LogWarn("here is a warn message from our values controller");
            _logger.LogError("here is an error message from our values controller");
            
            IEnumerable<Employee> employees = _employeeRepository.GetAll();
            return employees;
        }

        // GET api/values/5
        [HttpGet("{employeeId}")]
        public ActionResult<string> Get(int id)
        {
            return "fake value";
        }
    }
}
