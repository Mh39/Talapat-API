using Microsoft.AspNetCore.Mvc;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specifications;

namespace TalabatG02.APIs.Controllers
{

    public class EmployeeController : ApiBaseController
    {
        private readonly IGenericRepository<Employee> empRepo;

        public EmployeeController(IGenericRepository<Employee> empRepo)
        {
            this.empRepo = empRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetEmployees()
        {
            var spec = new EmployeeSpecification();
            var employees = await empRepo.GetAllWithSpecAsync(spec);

            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetEmployeeById(int id)
        {

            var spec = new EmployeeSpecification(id);

            var Employee = await empRepo.GetByIdWithSpecAsync(spec);
            return Ok(Employee);

        }
    }
}
