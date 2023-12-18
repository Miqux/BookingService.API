﻿using MediatR;
using static BookingService.Domain.Entities.Enums;

namespace BookingService.Application.UseCase.Service.Queries.GetServicesLightModel
{
    public class GetServicesLightModelQuery : IRequest<List<ServiceLightModel>>
    {
        public ServiceType Type { get; set; } = new();
        public string? City { get; set; }
    }
}
