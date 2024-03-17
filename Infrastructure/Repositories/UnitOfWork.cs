using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWork(AppDbContext dbContext): IUnitOfWork
{
    private readonly AppDbContext dbContext = dbContext;

    public IJanrInterface Janrs => new JanrRepository(dbContext);

    public IAuthorInterface Authors => new AuthorRepository(dbContext);

    public IBookInterface Books => new BookRepository(dbContext);
}
