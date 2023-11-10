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
        
        CreateMap<TrailerDto, Trailer>();
        CreateMap<Trailer, TrailerDto>();
        
        CreateMap<TripDto, Trip>();
        CreateMap<Trip, TripDto>();
        
        CreateMap<DriverDto, Driver>();
        CreateMap<Driver, DriverDto>();
        

        //CreateMap<DeliveryLogDto, DeliveryLog>();
        //CreateMap<DeliveryLog, DeliveryLogDto>();
        
        CreateMap<AgentDto, Agent>();
        CreateMap<Agent, AgentDto>();
        
        CreateMap<DriverLicenseDto, DriverLicense>();
        CreateMap<DriverLicense, DriverLicenseDto>();

        CreateMap<LicenceCategoryDto, LicenseCategory>();
        CreateMap<LicenseCategory, LicenceCategoryDto>();
        
        CreateMap<DriverContractDto, DriverContract>();
        CreateMap<DriverContract, DriverContractDto>();
        
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();

    }
}