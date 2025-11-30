using System;
namespace ttn_hub.Models
{
	public class EmailSettings
	{
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
        public string FromAddress { get; set; } = null!;
    }
}

