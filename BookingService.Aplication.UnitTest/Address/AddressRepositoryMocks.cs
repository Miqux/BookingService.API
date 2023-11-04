using BookingService.Aplication.UnitTest.Common;
using BookingService.Application.Contracts.Persistance;
using Moq;

namespace BookingService.Aplication.UnitTest.Address
{
    public class AddressRepositoryMocks
    {
        public static Mock<IAddressRepository> GetCategoryRepository()
        {
            var categories = GetAddreses();

            var mockAddressRepository = new Mock<IAddressRepository>();
            mockAddressRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            mockAddressRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
            (int id) =>
            {
                var cat = categories.FirstOrDefault(c => c.Id == id);
                return cat;
            });
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            mockAddressRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.Address>())).ReturnsAsync(
                (Domain.Entities.Address category) =>
                {
                    categories.Add(category);
                    return category;
                });

            mockAddressRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Domain.Entities.Address>())).Callback
                <Domain.Entities.Address>((entity) => categories.Remove(entity));

            mockAddressRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Domain.Entities.Address>())).Callback
                <Domain.Entities.Address>((entity) => { categories.Remove(entity); categories.Add(entity); });

            return mockAddressRepository;
        }

        private static List<Domain.Entities.Address> GetAddreses()
        {
            var list = new List<Domain.Entities.Address>();

            var address1 = new Domain.Entities.Address()
            {
                Id = 1,
                CreatedBy = "Mark",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
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
                Id = 1,
                CreatedBy = "Admin",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
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
                Id = 1,
                CreatedBy = "Domascz",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
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
                Id = 1,
                CreatedBy = "Tomasz",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
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
                Id = 1,
                CreatedBy = "Ola",
                CreatedDate = GeneratorHelper.GenerateRandomDate(new DateTime(2023, 1, 1), DateTime.Now),
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
