﻿namespace BookingService.Application.Contracts.Persistance
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
        public Task<List<Reservation>> GetIncomingWithChildrenByUserId(int userId);
        public Task<List<Reservation>> GetCompletedWithChildrenByUserId(int userId);
        public Task<Reservation?> GetByIdWithChildren(int id);
    }
}
