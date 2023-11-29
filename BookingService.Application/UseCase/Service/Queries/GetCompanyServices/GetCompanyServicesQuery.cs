using MediatR;

namespace BookingService.Application.UseCase.Service.Queries.GetCompanyServices
{
    public class GetCompanyServicesQuery : IRequest<List<CompanyServiceViewModel>>
    {
        public int CompanyId { get; set; }
    }
}
