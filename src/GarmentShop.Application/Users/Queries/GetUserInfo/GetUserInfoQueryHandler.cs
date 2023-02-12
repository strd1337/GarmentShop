using ErrorOr;
using MediatR;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Application.Common.Interfaces.Persistance;

namespace GarmentShop.Application.Users.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler :
        IRequestHandler<GetUserInfoQuery, ErrorOr<User>>
    {
        private readonly IUserRepository userRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(
            GetUserInfoQuery query,
            CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByIdAsync(query.Id);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }
    }
}
