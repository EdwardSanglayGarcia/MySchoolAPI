using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API_Test.Controllers
{
    using API_Test.Data;
    using API_Test.Models;
    using Microsoft.EntityFrameworkCore;
    using API_Test.Enums;

    /// <summary>
    /// Sample
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MySchoolController : ControllerBase
    {

        private MySchoolDBContext _context;
        public MySchoolController(MySchoolDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Sample asasasasas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Student>> Get()
        {
            var operation = await _context.Students
                .Include(person => person.Person)
                .Include(gradeList => gradeList.GradeList)
                .Include(grade => grade.GradeList.Grades)
                .ToListAsync();
            return operation;
        }

        /// <summary>
        /// Creates a student record that would consume the Student and Person entity.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="Syear"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///         POST
        ///         {
        ///            "id": 0,
        ///            "created": "2022-06-09T18:51:02.024Z",
        ///            "updated": "2022-06-09T18:51:02.024Z",
        ///            "person": {
        ///                         "id": 0,
        ///                         "created": "2022-06-09T18:51:02.024Z",
        ///                         "updated": "2022-06-09T18:51:02.024Z",
        ///                         "firstName": "string",
        ///                         "lastName": "string"
        ///                       }
        ///         }
        /// </remarks>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertStudent(Student student, StudentYear Syear)
        {
            student.StudentYear = Syear;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(InsertStudent), new { id = student.Id }, student);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStudentYear(int studentId, StudentYear studentYearParameter)
        {
            var operation = await _context.Students.FindAsync(studentId);
            if (operation == null)
            {
                return NotFound();
            }
            else
            {
                operation.StudentYear = studentYearParameter;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertStudentGrade(int gradeListId, Grade grade)
        {
            var operation = await _context.Grades.FirstOrDefaultAsync(x => x.GradeListId == gradeListId);

            if (operation == null)
            {
                return NotFound();
            }
            else
            {
                grade.GradeListId = gradeListId;
                _context.Grades.Update(grade);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudentGrade(int id)
        {
            var operation = await _context.Grades.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            else
            {
                _context.Grades.Remove(operation);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }


    }
}