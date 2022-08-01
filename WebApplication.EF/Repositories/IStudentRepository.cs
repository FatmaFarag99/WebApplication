namespace WebApplication.EF.Repositories;
public interface IStudentRepository : IBaseRepository<Student>
{
    ApplicationDbContext Context { get; }
}