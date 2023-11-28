using MediatR;

namespace BookingService.Application.UseCase.Company.Queries.GetCompanyByUserId
{
    public class GetCompanyByUserIdQuery : IRequest<CompanyByUserIdViewModel>
    {
        public int UserId { get; set; }
    }
}
