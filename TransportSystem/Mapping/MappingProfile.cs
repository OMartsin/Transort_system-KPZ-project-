namespace TransportSystem; 
using AutoMapper;
using TransportSystem.DTO;
using TransportSystem.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TruckDto, Truck>();
        CreateMap<TransportInsuranceDto, TransportInsurance>();
        CreateMap<Truck, TruckDto>();
        CreateMap<TransportInsurance, TransportInsuranceDto>();
    }
}