namespace BookingService.Application.UseCase.Company.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int UserId { get; set; }
        public string Private_key { get; set; } = string.Empty;
        public string Client_email { get; set; } = string.Empty;
        public string CalendaryName { get; set; } = string.Empty;
    }
}
