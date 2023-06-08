using Aspose.Words;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x5fd7668931539042 : Field, x6ed66b5cf8da2955
{
	internal bool x2f0e2d7e98b9f257 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\h");

	internal bool xe5979bc62324b657 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\s");

	internal bool xc165654f6f754872 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\u");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		Document document = x357c90b33d6bb8e6();
		x91fe491cf90c262f result = new x91fe491cf90c262f(x7546e38fbb25d738.x7d1987e3dfb4c2fb(document.BuiltInDocumentProperties.LastPrinted));
		return new xca592a476766b11a(this, result);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\h":
		case "\\s":
		case "\\u":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		default:
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
