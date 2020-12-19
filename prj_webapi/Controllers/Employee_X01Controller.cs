using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prj_webapi.Models;
using Microsoft.AspNetCore.Hosting;

namespace prj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_X01Controller : ControllerBase
    {
        private readonly Employee_X01DbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Employee_X01Controller(Employee_X01DbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
             this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Employee_X01
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee_X01>>> Gettbl_employees_x01()
        {
            return await _context.tbl_employees_x01
                .Select(x => new Employee_X01(){
                    EmployeeID = x.EmployeeID,
                    EmployeeName = x.EmployeeName,
                    Occupation = x.Occupation,
                    ImageName=x.ImageName,
                    ImageSrc= String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)
                })
                .ToListAsync();
        }

        // GET: api/Employee_X01/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee_X01>> GetEmployee_X01(int id)
        {
            var employee_X01 = await _context.tbl_employees_x01.FindAsync(id);

            if (employee_X01 == null)
            {
                return NotFound();
            }

            return employee_X01;
        }

        // PUT: api/Employee_X01/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee_X01(int id, [FromForm]Employee_X01 employee_X01)
        {
            if (id != employee_X01.EmployeeID)
            {
                return BadRequest();
            }

            if(employee_X01.ImageFile != null)
            {
                DeleteImage(employee_X01.ImageName);
                employee_X01.ImageName =await SaveImage(employee_X01.ImageFile);
            }

            _context.Entry(employee_X01).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_X01Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee_X01
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee_X01>> PostEmployee_X01([FromForm]Employee_X01 employee_X01)
        {
            employee_X01.ImageName = await SaveImage(employee_X01.ImageFile);
            _context.tbl_employees_x01.Add(employee_X01);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetEmployee_X01", new { id = employee_X01.EmployeeID }, employee_X01);
            return StatusCode(201);
        }

        // DELETE: api/Employee_X01/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee_X01>> DeleteEmployee_X01(int id)
        {
            var employee_X01 = await _context.tbl_employees_x01.FindAsync(id);
            if (employee_X01 == null)
            {
                return NotFound();
            }

            DeleteImage(employee_X01.ImageName);

            _context.tbl_employees_x01.Remove(employee_X01);
            await _context.SaveChangesAsync();

            //return NoContent();
            return employee_X01;
        }

        private bool Employee_X01Exists(int id)
        {
            return _context.tbl_employees_x01.Any(e => e.EmployeeID == id);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + "_" + DateTime.Now.ToString("yyyyMMddssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        //
    }

}
