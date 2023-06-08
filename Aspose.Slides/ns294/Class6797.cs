using System.Diagnostics;
using System.Drawing;
using ns235;
using ns305;
using ns306;

namespace ns294;

internal sealed class Class6797
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class6982 class6982_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class6204[] class6204_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class6800 class6800_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class6797 class6797_0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RectangleF rectangleF_0;

	public Class6797 ParentNode
	{
		get
		{
			if (class6797_0 == null)
			{
				Class6982 @class = class6982_0;
				while (@class.ParentNode != null && @class.ParentNode.NodeType == Enum969.const_0)
				{
					@class = (Class6982)@class.ParentNode;
					RectangleF rectangle = RectangleF.Empty;
					if (class6800_0.method_7(@class, ref rectangle))
					{
						class6797_0 = new Class6797(@class, rectangle, class6800_0);
						break;
					}
				}
			}
			return class6797_0;
		}
	}

	public Class6204[] ApsElements
	{
		get
		{
			if (class6204_0 == null)
			{
				class6204_0 = class6800_0.imethod_0(class6982_0);
			}
			return class6204_0;
		}
	}

	public Class6982 HtmlElement => class6982_0;

	public RectangleF Bounds => rectangleF_0;

	internal Class6797(Class6982 element, RectangleF bounds, Class6800 binder)
	{
		class6982_0 = element;
		class6800_0 = binder;
		rectangleF_0 = bounds;
	}
}
