using AutoMapper;
using Moq;
using ResturantApplication.Application.Room.Command.CreateRoom;
using ResturantApplication.Application.User;
using ResturantApplication.Domain.Repository;
using ResturantApplication.Infastructure.Service;

namespace ResturantApplication.Domain.Tests.Room.Command.CreateRoom;

public class CreateRoomHandlerTests
{
    [Fact()]
    public async void CreateRoomHandler_ShouldCreateRoomAndReturnId()
    {
        //arrange
        var repository=new Mock<IRoomRepository>();
        repository.Setup(x => x.CreateRoom(It.IsAny<Entities.Room>())).ReturnsAsync(new Entities.Room()
        {
            Id = 1
        });
        var mapper = new Mock<IMapper>();
        var room = new CreateRoomCommand();
        mapper.Setup(x=>x.Map<Entities.Room>(room)).Returns(new Entities.Room());
        var userContext = new Mock<IUserContext>();
        userContext.Setup(x => x.GetCurrentUser())
            .Returns(new Application.User.CurrentUser("test12@gmail.com", "test12@gmail.com", ["Admin"]));
        var requirementAuthroization = new Mock<IRequirementAuthorization>();
        requirementAuthroization.Setup(x => x.Authorize(ResourcesOperation.Create,It.IsAny<Entities.Room>())).Returns(true);
        var createRoomHandler = new CreateRoomHandler(repository.Object, mapper.Object, userContext.Object, requirementAuthroization.Object);
       //act
        var result=await createRoomHandler.Handle(room, CancellationToken.None);
            //assert
            Assert.NotNull(result);
            Assert.Equal(result,1);
        
        
        

    }
}