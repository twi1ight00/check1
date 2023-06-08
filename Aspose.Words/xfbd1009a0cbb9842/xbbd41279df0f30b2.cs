using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xbbd41279df0f30b2 : Field
{
	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		string text = base.xb452e2ee706d7a67.x642e37025c67edab(0);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return new xd5801a931e010963(this, "Error! Document Variable not defined.");
		}
		Document document = x357c90b33d6bb8e6();
		string text2 = document.Variables[text];
		string result = ((text2 != null) ? text2 : string.Empty);
		return new xca592a476766b11a(this, result);
	}
}
