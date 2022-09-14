using NLayerApp.Core.UnitOfWorks;

namespace NLayerApp.Repository;

public class UnitOfWorks : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWorks(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CommitAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Commit()
    {
        _appDbContext.SaveChanges();
    }
}