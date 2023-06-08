using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xc206f53556ce93af : Field
{
	internal override Section xe8d4351bdfdbf28a()
	{
		int num = base.x6edce55dcd2d335b.xefabd160dd587f64.x39cb3bc7700d4896(base.Start);
		NodeCollection childNodes = x357c90b33d6bb8e6().GetChildNodes(NodeType.Section, isDeep: false);
		if (0 > num || num >= childNodes.Count)
		{
			return null;
		}
		return (Section)childNodes[num];
	}
}
