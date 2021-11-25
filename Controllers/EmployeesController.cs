using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AdvanceCashesDBContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(AdvanceCashesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    // GET: api/Employees
    [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetDbEmployee()
        {
            var employeelist = await _context.DbEmployee.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeViewModel>>(employeelist));
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.DbEmployee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeViewModel>(employee));
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] EmployeeViewModel model)
        {
            var employee = _mapper.Map<Employee>(model);
            var empl = _context.DbEmployee.FindAsync(employee.Id);
            if (empl == null)
            {
                return BadRequest();
            }
            _context.Entry(empl).State = EntityState.Modified;

          
                await _context.SaveChangesAsync();
            return Ok(empl);

        }
    

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody]EmployeeViewModel model)
        {
            var employee = _mapper.Map<Employee>(model);
            _context.DbEmployee.Add(employee);

           int count = await _context.SaveChangesAsync();
            if (count < 1 )
            {
                return BadRequest();
            }

            return Ok(employee);


            //return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.DbEmployee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.DbEmployee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.DbEmployee.Any(e => e.Id == id);
        }
    }
}
