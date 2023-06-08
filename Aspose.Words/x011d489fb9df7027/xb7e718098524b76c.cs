using System;
using System.IO;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;

namespace x011d489fb9df7027;

internal class xb7e718098524b76c : xd142dcacd7ddc9dd
{
	private readonly string xc61ff88f1f98652d;

	private readonly Guid x31394132931742a3;

	private Stream xa49cef274042e702;

	private readonly string x98e285df741c9d32;

	internal string x759aa16c2016a289 => xc61ff88f1f98652d;

	internal Guid x933ed8cf24f04c67 => x31394132931742a3;

	internal Stream xb8a774e0111d0fbe => xa49cef274042e702;

	internal string x0b93856f95be30d0 => x98e285df741c9d32;

	internal xb7e718098524b76c(Stream stream, string contentType)
	{
		xa49cef274042e702 = stream;
		x98e285df741c9d32 = contentType;
	}

	internal xb7e718098524b76c(Stream stream, string contentType, string name, Guid clsid)
	{
		xa49cef274042e702 = stream;
		x98e285df741c9d32 = contentType;
		xc61ff88f1f98652d = name;
		x31394132931742a3 = clsid;
	}

	internal override string x1dcf998e2740773a(string x1fd8f5e5bbfdb602)
	{
		return x98e285df741c9d32;
	}

	internal override string x42fe3274236becd5(string x1fd8f5e5bbfdb602)
	{
		return xc62574be95c1c918.x7cfd9d683a359925(x98e285df741c9d32);
	}

	internal override void x2961bf88b232b7a8(Stream xedc894794186020d, string x1fd8f5e5bbfdb602)
	{
		if (x98e285df741c9d32 == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || x98e285df741c9d32 == "application/vnd.ms-excel.sheet.macroEnabled.12" || x98e285df741c9d32 == "application/vnd.openxmlformats-officedocument.spreadsheetml.template" || x98e285df741c9d32 == "application/vnd.ms-excel.template.macroEnabled.12")
		{
			x9ac0da7388ceac43.x8ba9ac9a5f4440e2(xa49cef274042e702, xedc894794186020d);
			return;
		}
		xa49cef274042e702.Position = 0L;
		x0d299f323d241756.x3ad8e53785c39acd(xa49cef274042e702, xedc894794186020d);
	}
}
