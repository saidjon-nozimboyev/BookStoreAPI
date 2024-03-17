using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext dbContext)
    : Repository<Author>(dbContext), IAuthorInterface
{
}
