using SimpleArchiteture.Data.EfConfig;
using SimpleArchiteture.Data.Interfaces;

namespace SimpleArchiteture.Data.Repository;

public class UnitOfWork : IUnitofWork, IDisposable
{

    private readonly ApplicationDbContext _context;

    private IRentCarRepository _carRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRentCarRepository CarRepository => _carRepository ??= new RentCarRepository(_context);
    public async Task CompleteAsync() => await _context.SaveChangesAsync();

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
