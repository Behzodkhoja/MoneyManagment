using MoneyManagment.Domain.Configurations;

namespace MoneyManagment.Service.Extensions;

public static class CollectionExtension
{
    public static IQueryable<T> ToPageList<T>(this IQueryable<T> source, PaginationParams @params)
    {
        int numberOfItemsToSkip =(@params.PageSize - 1) * @params.PageSize;
        int totalCount = source.Count();

        if (numberOfItemsToSkip >= totalCount && totalCount > 0)
        {
            numberOfItemsToSkip = totalCount - totalCount % @params.PageSize;
        }
        return source.Skip(numberOfItemsToSkip).Take(@params.PageSize);
    }
    public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
    {
        int numberOfItemsToSkip = (@params.PageIndex - 1) * @params.PageSize;
        int totalCount = source.Count();

        if (numberOfItemsToSkip >= totalCount && totalCount > 0)
        {
            numberOfItemsToSkip = totalCount - totalCount % @params.PageSize;
        }

        return source.Skip(numberOfItemsToSkip).Take(@params.PageSize);
    }
}
