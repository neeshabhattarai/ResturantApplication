using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Infastructure.Service;

public interface IRequirementAuthorization
{
    Task<bool> Authorize(ResourcesOperation resourcesOperation, Room romm);
}