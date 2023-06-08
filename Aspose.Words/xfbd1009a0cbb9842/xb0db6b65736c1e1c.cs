using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;

namespace xfbd1009a0cbb9842;

internal class xb0db6b65736c1e1c : xc0f77867ac6b6a92
{
	private readonly Hashtable x7c44f4224ac4d120 = new Hashtable();

	internal xb0db6b65736c1e1c(Document document)
	{
		x425ab73831c5f79e x425ab73831c5f79e2 = new x425ab73831c5f79e(document, this);
		x425ab73831c5f79e2.x295cb4a1df7a5add();
	}

	internal void xa2c03db21671d9cc(x811d4618e5f42dc7 xe01ae93d9fe5a880, int xbcea506a33cf9111)
	{
		x7c44f4224ac4d120[xe01ae93d9fe5a880.Start] = xbcea506a33cf9111;
	}

	private x82e26649b09596bd x01e8e6d18b9b4573(Field xe01ae93d9fe5a880)
	{
		object obj = x7c44f4224ac4d120[xe01ae93d9fe5a880.Start];
		if (obj == null)
		{
			return null;
		}
		return new x35d8d79b119cae44((int)obj);
	}

	x82e26649b09596bd xc0f77867ac6b6a92.x3f88a25febd23896(Field xe01ae93d9fe5a880)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x01e8e6d18b9b4573
		return this.x01e8e6d18b9b4573(xe01ae93d9fe5a880);
	}

	private object xa1e1d850069940af(Field xe01ae93d9fe5a880)
	{
		return null;
	}

	object xc0f77867ac6b6a92.xd378208b5267f7e2(Field xe01ae93d9fe5a880)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa1e1d850069940af
		return this.xa1e1d850069940af(xe01ae93d9fe5a880);
	}
}
