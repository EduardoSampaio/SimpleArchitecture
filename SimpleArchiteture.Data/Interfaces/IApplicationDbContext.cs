using Microsoft.EntityFrameworkCore;
using SimpleArchiteture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArchiteture.Data.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<RentCar> RentCars { get; set; }
    }
}
