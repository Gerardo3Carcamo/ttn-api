using System;
namespace ttn_hub.Models.Payloads
{
	public class MailPayload
	{
		public string to { get; set; }
		public string cc { get; set; }
		public string subject { get; set; }
		public string body { get; set; }
	}
}

