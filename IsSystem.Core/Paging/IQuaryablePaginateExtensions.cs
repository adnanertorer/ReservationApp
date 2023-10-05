using Microsoft.EntityFrameworkCore;

namespace IsSystem.Core.Paging;

public static class IQuaryablePaginateExtensions
{
    public static async Task<Paginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index, int size, CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);
        Paginate<T> list = new()
        {
            Count = count,
            Index = index,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size),
            Size = size
        };
        return list;
    }
    
    public static Paginate<T> ToPaginate<T>(
        this IQueryable<T> source,
        int index, int size)
    {
        var count = source.Count();
        var items = source.Skip(index * size).Take(size).ToList();
        Paginate<T> list = new()
        {
            Count = count,
            Index = index,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size),
            Size = size
        };
        return list;
    }
}