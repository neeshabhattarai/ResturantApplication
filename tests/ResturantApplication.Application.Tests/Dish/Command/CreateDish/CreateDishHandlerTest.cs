using System.Linq.Expressions;
using AutoMapper;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using ResturantApplication.Application.Dishes.Command.CreateDish;
using ResturantApplication.Domain.Exception;
using ResturantApplication.Domain.Repository;

namespace ResturantApplication.Domain.Tests.Dish.Command.CreateDish;

public class CreateDishHandlerTest
{
    public Mock<ILogger<CreateDishHandler>> logger = new();
    public Mock<IRoomRepository> repository;
    public Mock<IDish> dishRepo;
    public Mock<IMapper> mapper;
    
    public CreateDishHandlerTest()
    {

        repository = new Mock<IRoomRepository>();
        mapper = new Mock<IMapper>();
         dishRepo = new Mock<IDish>();
    }
    [Fact()]
    public async void CreateDishHandler_ShouldReturnSuccess()
    {
        var room = new Entities.Room
        {
            Id = 1,
            UserId = "1",
            Name = "Room Name",
            Description = "Room Description",
            Dishes = new List<Entities.Dish>()
        };
        var newDish = new CreateDishCommand
        {
        calories = 10,
        Name = "Dish",
        RoomId =  room.Id
        };
         repository.Setup(x => x.GetById(1)).ReturnsAsync(room);
         mapper.Setup(x => x.Map<Entities.Dish>(newDish)).Returns(new Entities.Dish
         {
             Name = "Dish",
             Id=1,
             calories = 10
         });
        var dishHandler=new CreateDishHandler(repository.Object,logger.Object,dishRepo.Object,mapper.Object);
        var result = await dishHandler.Handle(newDish, CancellationToken.None);
        Assert.Equal(result,1);
        
            // repository.Verify(repository.Setup(x => x.GetById(1)), Times.Once());
    }

    [Fact()]
    public async void CreateDishHandler_ShouldReturnRoomNotFoundException()
    {
        var room = new Entities.Room
        {
            UserId = "1",
            Name = "Room Name",
            Description = "Room Description",
            Dishes = new List<Entities.Dish>()
        };
        var newDish = new CreateDishCommand
        {
            calories = 10,
            Name = "Dish",
            RoomId =  room.Id
        };
        repository.Setup(x => x.GetById(1)).ReturnsAsync(room);
        mapper.Setup(x => x.Map<Entities.Dish>(newDish)).Returns(new Entities.Dish());
        var dishHandler=new CreateDishHandler(repository.Object,logger.Object,dishRepo.Object,mapper.Object);
        // var result = await dishHandler.Handle(newDish, CancellationToken.None);
        Assert.ThrowsAsync<NotFoundException>(async () => await dishHandler.Handle(newDish, CancellationToken.None));
    }
}