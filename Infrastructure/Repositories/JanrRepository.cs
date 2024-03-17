using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class JanrRepository(AppDbContext dbContext) 
    : Repository<Janr>(dbContext), IJanrInterface
{

}
