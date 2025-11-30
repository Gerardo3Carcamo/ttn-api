using System;
namespace ttn_hub.Shared
{
	public class ResponseApi<T>
	{
		private T _data { get; set; }
		private string _message { get; set; }
		private bool _status { get; set; }

		public ResponseApi(T data, string message, bool status)
		{
			_data = data;
			_message = message;
			_status = status;
		}
	}
}

