// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApplication.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentUnitOfWork _unitOfWork;
    public StudentsController(IStudentUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<Student> students = await _unitOfWork.ReadAllAsync();
        return Ok(students);
    }
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetByIdAsync(Guid id)
    {
        Student student = await _unitOfWork.ReadByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post(Student student)
    {
        if (student == null)
            return BadRequest("Student can not be null");

        student = await _unitOfWork.CreateAsync(student);
        return Ok(student);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put(Student student)
    {

        if (student == null)
            return BadRequest("Student can not be null");

        student = await _unitOfWork.UpdateAsync(student);
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        Student student = await _unitOfWork.DeleteByIdAsync(id);
        return Ok(student);
    }
}