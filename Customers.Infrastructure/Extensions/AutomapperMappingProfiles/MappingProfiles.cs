using AutoMapper;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Dtos;

namespace Customers.Infrastructure.Extensions.AutomapperMappingProfiles {
    public class MappingProfiles : Profile {
        public MappingProfiles () {
            CreateMap<CustomerAddress, CustomerAddressDto> ().ReverseMap ();
            CreateMap<Customer, CustomerWithAddressDto> ().ReverseMap ();
            //     CreateMap<CustomerDto, CustomerWithAddressDto> ()
            //         .ForMember (dest => dest.CustomerAddress,
            //             opts => opts.MapFrom (
            //                 src => new CustomerAddressDto {
            //                     BuildingNumber = src.BuildingNumber,
            //                         FlatNumber = src.FlatNumber,
            //                         Street = src.Street,
            //                         City = src.City,
            //                         ZipCode = src.ZipCode
            //                 }));
        }
    }
}