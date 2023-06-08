using ns235;

namespace ns267;

internal class Class6615 : Class6598
{
	protected override string RootNodeName => "Image";

	public Class6615(Class6616 context)
		: base(context)
	{
	}

	public override bool vmethod_0(Class6204 node)
	{
		return node is Class6220;
	}

	public override void vmethod_1(Class6204 node)
	{
		Class6220 @class = node as Class6220;
		base.Context.Writer.method_0(RootNodeName);
		base.vmethod_1(node);
		int value = base.Context.Resources.Write(@class.ImageBytes);
		base.Context.Writer.method_23("ResourceId", value);
		base.Context.Writer.method_14("Origin", @class.Origin);
		base.Context.Writer.method_15("Size", @class.Size);
		if (@class.Hyperlink != null)
		{
			base.Context.Writer.method_12("Hyperlink", @class.Hyperlink);
		}
		if (@class.Crop != null)
		{
			base.Context.Writer.method_7("Crop", @class.Crop);
		}
		if (@class.ChromaKey != null)
		{
			base.Context.Writer.method_6("ChromaKey", @class.ChromaKey);
		}
	}

	protected override Class6204 vmethod_2()
	{
		if (base.Context.Reader.method_14("Origin", out var value) && base.Context.Reader.method_15("Size", out var value2) && base.Context.Reader.method_5("ResourceId", out var value3))
		{
			base.Context.Reader.method_20("Crop", out var value4);
			base.Context.Reader.method_21("ChromaKey", out var value5);
			byte[] imageBytes = base.Context.Resources.Read(value3);
			Class6220 @class = new Class6220(value, value2, imageBytes, value4, value5);
			if (base.Context.Reader.method_19("Hyperlink", out var value6))
			{
				@class.Hyperlink = value6;
			}
			return @class;
		}
		return null;
	}
}
