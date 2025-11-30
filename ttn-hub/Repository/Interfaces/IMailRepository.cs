using ttn_hub.Models.Payloads;

namespace ttn_hub.Repository.Interfaces
{
	public interface IMailRepository
	{
		public Task SendMail(MailPayload payload);
	}
}

