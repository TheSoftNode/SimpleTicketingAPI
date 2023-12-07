using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTicketingAPI.Core.Context;
using SimpleTicketingAPI.Core.Entities;
using SimpleTicketingAPI.Core.DTO;

namespace SimpleTicketingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		// We need Database so we inject it using constructor
		// We need AutoMapper so we inject it using constructor

		private readonly ApplicationDBContext _dbContext;
		private readonly IMapper _mapper;
		public TicketsController(ApplicationDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		// Create
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto createTicketDto)
		{
			var newTicket = new Ticket();

			_mapper.Map(createTicketDto, newTicket);

			await _dbContext.Tickets.AddAsync(newTicket);
			await _dbContext.SaveChangesAsync();

			return Ok("Ticket saved successfully");
		}

		// Read all
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetTicketDto>>> GetTickets(string? q)
		{
			// Get Tickets from Context
			IQueryable<Ticket> query = _dbContext.Tickets;

			// Check if we have search parameter or not 
			if (q is not null)
			{
				query = query.Where(t => t.PassengerName.Contains(q));
			}

			var tickets = await query.ToListAsync();

			var convertedTickets = _mapper.Map<IEnumerable<GetTicketDto>>(tickets);

			return Ok(convertedTickets);
		}

		// Read one by Id
		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<GetTicketDto>> GetTicketById([FromRoute] long id)
		{
			// Get ticket from context and check if it exists
			var ticket = await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
			if (ticket is null)
			{
				return NotFound("Ticket Not found");
			}

			var convertedTicket = _mapper.Map<GetTicketDto>(ticket);

			return Ok(convertedTicket);
		}
	}
}
