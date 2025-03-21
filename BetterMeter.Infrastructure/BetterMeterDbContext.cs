using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetterMeter.Infrastructure;

public class BetterMeterDbContext : IdentityDbContext
{
    public BetterMeterDbContext(DbContextOptions<BetterMeterDbContext> options) : base(options)
    {
    }
}
