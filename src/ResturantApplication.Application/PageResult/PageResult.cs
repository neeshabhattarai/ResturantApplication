using ResturantApplication.Infastructure.Service;

namespace ResturantApplication.Application.PageResult;
public class PageResult<T>
{
    public PageResult(List<T> items, int totalItems, int pageSize, int pageNumber, string? sortBy,
        string sortDirection)
    {
        this.items = items;
        this.sortDirection = sortDirection==SortDirection.Ascending ? "Ascending" : "Descending";
        this.sortBy = sortBy;
        totalPage = (int)Math.Ceiling(totalItems / (double)pageSize);
        ItemsFrom = (pageNumber-1) * pageSize + 1;
        ItemsTo = ItemsFrom+pageSize-1;
        

    }

    public List<T> items{get;set;}
    public int? totalPage{get;set;}
    public int ItemsFrom{get;set;}
    public int ItemsTo{get;set;}
    public string? sortBy{get;set;}
    public string sortDirection{get;set;}
    
}