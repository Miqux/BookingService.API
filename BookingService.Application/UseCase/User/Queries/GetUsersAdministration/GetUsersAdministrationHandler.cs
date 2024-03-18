using BookingService.Application.Contracts.Persistance;

namespace BookingService.Application.UseCase.User.Queries.GetUsersAdministration
{
    public class GetUsersAdministrationHandler : IRequestHandler<GetUsersAdministrationQuery, List<UserAdministrationViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public GetUsersAdministrationHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<List<UserAdministrationViewModel>> Handle(GetUsersAdministrationQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<List<UserAdministrationViewModel>>(users);
        }
    }
}
