using AutoMapper;
using SimpleTicketingAPI.Core.DTO;
using SimpleTicketingAPI.Core.Entities;

namespace SimpleTicketingAPI.Core.AutoMapperConfig
{
	public class AutoMapperConfigProfile : Profile
	{
		public AutoMapperConfigProfile()
		{
			// Tickets
			CreateMap<CreateTicketDto, Ticket>();
			CreateMap<Ticket, GetTicketDto>();
			CreateMap<UpdateTicketDto, Ticket>();
		}
	}
}
