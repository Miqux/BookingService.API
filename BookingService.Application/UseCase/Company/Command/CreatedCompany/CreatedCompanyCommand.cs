using MediatR;

namespace BookingService.Application.UseCase.Company.Command.CreatedCompany
{
    public class CreatedCompanyCommand : IRequest<CreatedCompanyCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Project_id { get; set; } = string.Empty;
        public string Private_key_id { get; set; } = string.Empty;
        public string Private_key { get; set; } = string.Empty;
        public string Client_email { get; set; } = string.Empty;
        public string Client_id { get; set; } = string.Empty;
        public string Auth_uri { get; set; } = string.Empty;
        public string Token_uri { get; set; } = string.Empty;
        public string Auth_provider_x509_cert_url { get; set; } = string.Empty;
        public string Client_x509_cert_url { get; set; } = string.Empty;
        public string Universe_domain { get; set; } = string.Empty;
        public string CalendaryName { get; set; } = string.Empty;
    }
}
