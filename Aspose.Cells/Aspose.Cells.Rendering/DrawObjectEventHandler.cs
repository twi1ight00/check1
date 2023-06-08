using System.Drawing;
using System.IO;
using ns17;
using ns22;

namespace Aspose.Cells.Rendering;

/// <summary>    
///       Interface to get DrawObject and Bound when rendering.
///       </summary>
public abstract class DrawObjectEventHandler
{
	private float float_0;

	private float float_1;

	private int int_0;

	private int int_1;

	private int int_2;

	/// <summary>       
	///       Implements this interface to get DrawObject and Bound when rendering.
	///       </summary>
	/// <param name="drawObject"> DrawObject will be initalized and returned when rendering</param>
	/// <param name="x">Left of DrawObject</param>
	/// <param name="y">Top of DrawObject</param>
	/// <param name="width">Width of DrawObject</param>
	/// <param name="height">Height of DrawObject</param>
	public virtual void Draw(DrawObject drawObject, float x, float y, float width, float height)
	{
	}

	internal void method_0(float float_2, float float_3)
	{
		float_0 = float_2;
		float_1 = float_3;
	}

	internal void method_1(int int_3, int int_4, int int_5)
	{
		int_0 = int_3;
		int_1 = int_4;
		int_2 = int_5;
	}

	internal void Draw(Class1624 class1624_0)
	{
		DrawObject drawObject = new DrawObject(class1624_0.class1620_0.Cell, int_0, int_1, int_2);
		Draw(drawObject, float_0 + class1624_0.float_2, float_1 + class1624_0.float_3, class1624_0.float_1, class1624_0.float_0);
	}

	[Attribute0(true)]
	internal void method_2(MemoryStream memoryStream_0, RectangleF rectangleF_0)
	{
		DrawObject drawObject = new DrawObject(Image.FromStream(memoryStream_0), int_0, int_1, int_2);
		Draw(drawObject, float_0 + rectangleF_0.Left, float_1 + rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
	}
}
