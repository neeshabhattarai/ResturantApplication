
namespace ResturantApplication.Domain.Exception;

public class NotFoundException:System.Exception
{
    public NotFoundException(string identifier,int id):base($"{identifier} with {id}: Not Found")
    {
    }
}