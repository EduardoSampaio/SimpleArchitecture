using Microsoft.EntityFrameworkCore;
using SimpleArchiteture.Data.Interfaces;
using SimpleArchiteture.Domain.Entities;

namespace SimpleArchiteture.Data.Repository;

public class RentCarRepository : BaseRepository<RentCar, Guid>, IRentCarRepository
{
    public RentCarRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
