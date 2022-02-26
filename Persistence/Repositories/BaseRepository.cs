using market.API.Persistence.Contexts;

namespace market.API.Persistence.Repositories
{
  public class BaseRepository
  {
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
      _context = context;
    }
  }
}