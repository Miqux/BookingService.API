﻿using BookingService.Application.Contracts.Persistance;
using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Infrastructure.Persistence.Repository
{
    public class ServiceRepository : AsyncRepository<Service>, IServiceRepository
    {
        public ServiceRepository(BookingServiceContext bookingServiceContext) : base(bookingServiceContext)
        {
        }

        public async Task<List<Service>> GetAllWithChildren(ServiceType? serviceType = null, string? city = null)
        {
            var services = await bookingServiceContext.Service.Where(x => x.Active).Include(x => x.Company).ThenInclude(x => x.Address).ToListAsync();
            services = serviceType is null ? services : services.Where(x => x.Type == serviceType).ToList();
            services = city is null ? services : services.Where(x => x.Company.Address is null || x.Company.Address.City.Contains(city)).ToList();
            return services;
        }

        public async Task<Service?> GetServiceDetalis(int id)
        {
            return await bookingServiceContext.Service.Include(x => x.Company).ThenInclude(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Service>> GetServicesByCompanyId(int companyId)
        {
            return await bookingServiceContext.Service.Where(x => x.Company != null && x.Company.Id == companyId && x.Active).ToListAsync();
        }

        public async Task<Service?> GetWithChildren(int id, bool withComapnyCalendar = false)
        {
            var service = await bookingServiceContext.Service.Include(x => x.Company).FirstOrDefaultAsync(x => x.Active && x.Id == id);

            if (withComapnyCalendar && service is not null && service.Company is not null)
            {
                service.Company.Calendar = await bookingServiceContext.Calendar.FirstOrDefaultAsync(x => x.Id == service.Company.Id);
            }
            return service;
        }
    }
}
