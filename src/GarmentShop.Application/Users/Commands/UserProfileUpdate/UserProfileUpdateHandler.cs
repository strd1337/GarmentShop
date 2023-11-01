using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Users.Common;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Domain.Events.User;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Users.Commands.UserProfileUpdate
{
    public class UserProfileUpdateHandler :
        ICommandHandler<UserProfileUpdateCommand, UserProfileUpdateResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserProfileUpdateHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserProfileUpdateResult>> Handle(
            UserProfileUpdateCommand command,
            CancellationToken cancellationToken)
        {
            var user = await unitOfWork
                .GetRepository<User, UserId>()
                .GetByIdAsync(
                    UserId.Create(command.UserId), 
                    cancellationToken);

            if (user is null)
            {
                return Errors.User.NotFound;
            }

            var newUserInfo = UserDetailInformation.CreateNew(
                command.FirstName,
                command.LastName,
                command.PhoneNumber,
                command.Address,
                command.City,
                command.ZipCode,
                command.Country);

            if (user.Information == newUserInfo)
            {
                return Errors.User.DataConflict;
            }

            user.UpdateInformation(newUserInfo);

            await unitOfWork
                .GetRepository<User, UserId>()
                .UpdateAsync(user);

            user.RaiseDomainEvent(new UserProfileUpdatedEvent(
                Guid.NewGuid(),
                user.Id.Value,
                command.FirstName,
                command.LastName,
                command.PhoneNumber,
                command.Address,
                command.City,
                command.ZipCode,
                command.Country));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new UserProfileUpdateResult(
                user.Id.Value, user.Information);
        }
    }
}
