using System.Drawing;
using ns242;

namespace ns243;

internal class Class6230 : Class6227
{
	public override SizeF Size => new SizeF(float_0, vmethod_8());

	public Class6230(float width, Struct220 margin, Class6239 documentCreator)
		: base(width, margin, documentCreator)
	{
	}

	public virtual Class6228 vmethod_17(float lineSpace, Struct220 margin)
	{
		Class6228 @class = class6239_0.NodesFactory.CreateParagraph(margin, lineSpace, this);
		vmethod_5(@class);
		return @class;
	}

	public virtual Class6234 vmethod_18(Image image, Struct220 margin)
	{
		Class6234 @class = class6239_0.NodesFactory.vmethod_7(image, margin);
		vmethod_5(@class);
		return @class;
	}

	public override Class6227 vmethod_14()
	{
		Class6230 @class = new Class6230(float_0, Margin, class6239_0);
		@class.Location = Location;
		if (base.Style != null)
		{
			@class.method_4(base.Style);
		}
		return @class;
	}
}
