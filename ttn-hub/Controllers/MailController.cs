using System;
using ttn_hub.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ttn_hub.Models.Payloads;
using ttn_hub.Shared;
namespace ttn_hub.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class MailController : ControllerBase
	{
		private readonly IMailRepository _mail;
		public MailController(IMailRepository mail)
		{
			_mail = mail;
		}

		[HttpPost]
		public async Task<IActionResult> SendMail([FromBody] MailPayload payload)
		{
			try
			{
				await _mail.SendMail(payload);
				return Ok(new ResponseApi<bool>(true, "Mail send", true));
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}

