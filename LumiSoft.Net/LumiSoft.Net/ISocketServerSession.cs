using System;

namespace LumiSoft.Net;

public interface ISocketServerSession
{
	DateTime SessionLastDataTime { get; }

	void OnSessionTimeout();
}
