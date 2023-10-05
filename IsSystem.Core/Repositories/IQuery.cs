namespace IsSystem.Core.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
