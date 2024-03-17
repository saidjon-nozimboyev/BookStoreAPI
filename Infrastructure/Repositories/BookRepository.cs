using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext dbContext) 
    : Repository<Book>(dbContext), IBookInterface
{
    
}
