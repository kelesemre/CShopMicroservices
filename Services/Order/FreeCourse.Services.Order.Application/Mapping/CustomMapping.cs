using AutoMapper;
using FreeCourse.Services.Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Mapping
{
    public class CustomMapping: Profile
    {
        public CustomMapping()
        {
            CreateMap<Order.Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<Order.Domain.OrderAggregate.OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Order.Domain.OrderAggregate.Address, AddressDto>().ReverseMap();
        }
    }
}
