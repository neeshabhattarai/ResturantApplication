using ResturantApplication.Domain.Entities;

namespace ResturantApplication.Infastructure.Service;

public interface IRequirementAuthorization
{ bool Authorize(ResourcesOperation resourcesOperation, Room romm);
}