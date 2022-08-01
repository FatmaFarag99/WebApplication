namespace WebApplication.EF.Repositories;
public class StudentRepositories : IStudentRepository
{
    protected DbSet<Student> _table;
    public StudentRepositories(ApplicationDbContext applicationDbContext)
    {
        Context = applicationDbContext;
        _table = applicationDbContext.Set<Student>();
    }
    public ApplicationDbContext Context { get; }
    public virtual async Task<Student> AddAsync(Student entity)
    {
        int maxDisplayOrder = GetMaxDisplayOrder();
        entity.DisplayOrder = maxDisplayOrder++;
        return (await _table.AddAsync(entity)).Entity;
    }
    public virtual async Task<Student> DeleteAsync(Guid id)
    {
        Student entityFromDb = await GetByIdAsync(id);
        if (entityFromDb is null)
            throw new Exception("Entity dosn't exist in DB");

        _table.Remove(entityFromDb);

        return entityFromDb;
    }
    public virtual async Task<Student> EditAsync(Student entity)
    {
        Student entityFromDb = await GetByIdAsync(entity.Id);
        if (entityFromDb == null)
            return await AddAsync(entity);
        else
            return _table.Update(entity).Entity;
    }
    public virtual async Task<IEnumerable<Student>> GetAllAsync() => await _table.OrderBy(x => x.DisplayOrder).ToListAsync();
    public async Task<IEnumerable<Student>> GetByExprissionAsync(Expression<Func<Student, bool>> expression) =>
        await _table.Where(expression).OrderBy(e => e.DisplayOrder).ToListAsync();
    public virtual async Task<Student> GetByIdAsync(Guid id) => await _table.Where(e => e.Id == id).OrderBy(e => e.DisplayOrder).FirstOrDefaultAsync();
    public virtual int GetMaxDisplayOrder()
    {
        if (((IQueryable<Student>)_table).Any())
        {
            return ((IQueryable<Student>)_table).Max(e => e.DisplayOrder);
        }
        return 0;
    }
}