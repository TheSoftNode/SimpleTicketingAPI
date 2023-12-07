using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTicketingAPI.Core.Context;

namespace SimpleTicketingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		// We need Database so we inject it using constructor
		// We need AutoMapper so we inject it using constructor

		private readonly ApplicationDBContext _dbContext;
		public TicketsController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
