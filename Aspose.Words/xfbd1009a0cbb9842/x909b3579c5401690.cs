using System.IO;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x909b3579c5401690 : Field, x6ed66b5cf8da2955
{
	internal bool x08cba3a2a1af3532 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\p");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		string text = x357c90b33d6bb8e6().OriginalFileName;
		if (x0d299f323d241756.x5959bccb67bbf051(text) && !x08cba3a2a1af3532)
		{
			text = Path.GetFileName(text);
		}
		return new xca592a476766b11a(this, text);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		string text;
		if ((text = x724fbd227bfb6eda) != null && text == "\\p")
		{
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		}
		return x9f6b815e19fa8f62.xf6c17f648b65c793;
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}
}
