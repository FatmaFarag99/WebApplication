namespace WebApplication.EF.Repositories.UnitOfWork;
public class StudentUnitOfWork : IStudentUnitOfWork
{
    private readonly IStudentRepository _repository;
    protected readonly ApplicationDbContext _context;

    public StudentUnitOfWork(IStudentRepository repository)
    {
        _repository = repository;
        _context = repository.Context;
    }
    
    public virtual async Task<IEnumerable<Student>> ReadAllAsync()
    {
        IEnumerable<Student> entities = await _repository.GetAllAsync();
        return entities;
    }
    public virtual async Task<Student> ReadByIdAsync(Guid id)
    {
        Student entity = await _repository.GetByIdAsync(id);
        return entity;
    }

    public virtual async Task<IEnumerable<Student>> ReadByExpressionAsync(Expression<Func<Student, bool>> expression)
    {
        IEnumerable<Student> entities = await _repository.GetByExprissionAsync(expression);
        return entities;
    }
    public virtual async Task<Student> CreateAsync(Student entity)
    {
        Student entityFromDb = await _repository.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entityFromDb;
    }
    public virtual async Task<Student> UpdateAsync(Student entity)
    {
        Student entityFromDb = await _repository.EditAsync(entity);
        await _context.SaveChangesAsync();

        return entityFromDb;
    }
    public virtual async Task<Student> DeleteByIdAsync(Guid id)
    {
        Student entityFromDb = await _repository.DeleteAsync(id);
        await _context.SaveChangesAsync();

        return entityFromDb;
    } 
}