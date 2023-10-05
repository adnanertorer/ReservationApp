using IsSystem.Core.Paging;

namespace IsSystem.Application.Responses;

public class GetListResponse<T> : BasePageableModule
{
    private IList<T> _items;
    public IList<T> Items
    {
        get => _items ??= new List<T>();
        set => _items = value;
    }
}