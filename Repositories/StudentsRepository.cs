namespace BlazorAppServer;

public class StudentsRepository : Repository<Student>, IStudentsRepository
{
    public StudentsRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Student?> GetByScholarShipType(string scholarShipType)
    {
        Student? entityFromDb = await _dbSet.FirstOrDefaultAsync(e => e.ScholarShipType != null &&
                                                                            e.ScholarShipType.Contains(scholarShipType));

        return entityFromDb;
    }
}