using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns312;

namespace ns315;

internal class Class7135 : Class7132
{
	private bool bool_0 = true;

	private GraphicsPath graphicsPath_1;

	private Enum976 enum976_1;

	private GraphicsPath graphicsPath_2 = new GraphicsPath();

	public override Enum976 ClipRule => enum976_1;

	public override GraphicsPath Path => graphicsPath_2;

	private void method_2(Class7132 svgElement, GraphicsPath elementPath)
	{
		if (svgElement != null && svgElement.Path != null)
		{
			elementPath.FillMode = ((svgElement.ClipRule == Enum976.const_0) ? FillMode.Winding : FillMode.Alternate);
			GraphicsPath path = svgElement.Path;
			if (svgElement.hashtable_5 != null)
			{
				foreach (DictionaryEntry item in svgElement.hashtable_5)
				{
					path.Transform((Matrix)item.Value);
				}
			}
			elementPath.AddPath(path, connect: false);
		}
		foreach (Class7132 item2 in svgElement.hashtable_4)
		{
			method_2(item2, elementPath);
		}
	}

	public Region method_3(Class7132 svgNode)
	{
		if (graphicsPath_1 == null || bool_0)
		{
			graphicsPath_1 = new GraphicsPath();
			foreach (Class7132 item in hashtable_4)
			{
				method_2(item, graphicsPath_1);
			}
			bool_0 = false;
		}
		return new Region(graphicsPath_1);
	}
}
