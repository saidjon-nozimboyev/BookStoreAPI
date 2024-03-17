namespace Infrastructure.Interfaces;

public interface IUnitOfWork
{
    IJanrInterface Janrs { get; }
    IAuthorInterface Authors { get; }
    IBookInterface Books { get; }
}
