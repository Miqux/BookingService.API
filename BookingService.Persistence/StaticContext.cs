using BookingService.Domain.Entities;

namespace BookingService.Persistence
{
    public class StaticContext
    {
        public List<Address> Address { get; set; }
        public StaticContext()
        {
            Address = GetAddreses();

        }
        private static List<Address> GetAddreses()
        {
            var list = new List<Domain.Entities.Address>();

#pragma warning disable S6562 // Always set the "DateTimeKind" when creating new "DateTime" instances
            DateTime startDate = new DateTime(2023, 1, 1);
#pragma warning restore S6562 // Always set the "DateTimeKind" when creating new "DateTime" instances
            var address1 = new Domain.Entities.Address()
            {
                Id = 1,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(startDate, DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                City = "Warszawa",
                Street = "Marszałkowska",
                Zipcode = "21-111",
                HouseNumber = 12,
                ApartmentNumber = 0
            };
            list.Add(address1);

            var address2 = new Domain.Entities.Address()
            {
                Id = 2,
                CreatedBy = "Admin",
                CreatedDate = GeneratorHelper.GenerateRandomDate(startDate, DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                City = "Siedlce",
                Street = "Sokołowksa",
                Zipcode = "12-124",
                HouseNumber = 66,
                ApartmentNumber = 4
            };
            list.Add(address2);

            var address3 = new Domain.Entities.Address()
            {
                Id = 3,
                CreatedBy = "Domascz",
                CreatedDate = GeneratorHelper.GenerateRandomDate(startDate, DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                City = "Międzyrzec Podlaski",
                Street = "Warszawska",
                Zipcode = "21-560",
                HouseNumber = 77,
                ApartmentNumber = 0
            };
            list.Add(address3);

            var address4 = new Domain.Entities.Address()
            {
                Id = 4,
                CreatedBy = "Tomasz",
                CreatedDate = GeneratorHelper.GenerateRandomDate(startDate, DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                City = "Warszawa",
                Street = "Marszałkowska",
                Zipcode = "21-111",
                HouseNumber = 52,
                ApartmentNumber = 12
            };
            list.Add(address4);

            var address5 = new Domain.Entities.Address()
            {
                Id = 5,
                CreatedBy = "Ola",
                CreatedDate = GeneratorHelper.GenerateRandomDate(startDate, DateTime.Now),
                LastModifiedBy = string.Empty,
                LastModifiedDate = null,
                City = "Radzyń Podlaski",
                Street = "Prosta",
                Zipcode = "16-153",
                HouseNumber = 11,
                ApartmentNumber = 2
            };
            list.Add(address5);

            return list;
        }
    }
}
