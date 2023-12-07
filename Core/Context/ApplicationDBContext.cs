using Microsoft.EntityFrameworkCore;
using SimpleTicketingAPI.Core.Entities;

namespace SimpleTicketingAPI.Core.Context;

public class ApplicationDBContext : DbContext
{
	public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
	{

	}

	// We need to have a DbSet for our Database Table
	public DbSet<Ticket> Tickets { get; set; }
}
