using AutoMapper;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Dtos;

namespace Customers.Infrastructure.Extensions.AutomapperMappingProfiles {
    public class MappingProfiles : Profile {
        public MappingProfiles () {
            CreateMap<Customer, CustomerDto> ().ReverseMap ();
            CreateMap<CustomerAddress, CustomerAddressDto> ().ReverseMap ();
        }
    }
}