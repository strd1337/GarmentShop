using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Application.Users.Common;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Events.User;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Users.Queries
{
    public class UserProfileHandler :
       IQueryHandler<UserProfileQuery, UserProfileResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public UserProfileHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserProfileResult>> Handle(
            UserProfileQuery query,
            CancellationToken cancellationToken)
        {
            var authUser = await unitOfWork
                .GetRepository<Authentication, AuthenticationId>()
                .FirstOrDefaultAsync(
                    x => x.UserName.Equals(query.UserName),
                    cancellationToken);

            if (authUser is null)
            {
                return Errors.User.NotFound;
            }

            var userRepository = unitOfWork.GetRepository<User, UserId>(true)
                as IUserRepository;

            var user = await userRepository!
                .FindByIdAsync(authUser.UserId, cancellationToken);

            if (user is null)
            {
                return Errors.User.NotFound;
            }

            user.RaiseDomainEvent(
                new UserProfileViewedEvent(
                    Guid.NewGuid(),
                    authUser.Id.Value,
                    authUser.UserId.Value));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new UserProfileResult(authUser, user);
        }
    }
}