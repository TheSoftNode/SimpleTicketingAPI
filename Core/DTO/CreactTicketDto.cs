﻿namespace SimpleTicketingAPI.Core.DTO
{
	public class CreactTicketDto
	{

		public DateTime Time { get; set; }
		public string PassengerName { get; set; }
		public long PassengerSSN { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public int Price { get; set; }
	}
}
