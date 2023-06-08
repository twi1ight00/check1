using System.Collections;
using System.Drawing;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the gradient stop collection.
///       </summary>
public class GradientStopCollection : CollectionBase
{
	private GradientFill gradientFill_0;

	/// <summary>
	///       Gets the gradient stop by the index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>The gradient stop.</returns>
	public GradientStop this[int index]
	{
		get
		{
			return (GradientStop)base.InnerList[index];
		}
		set
		{
			base.InnerList[index] = value;
		}
	}

	internal GradientFill GradientFill => gradientFill_0;

	internal GradientStopCollection(GradientFill gradientFill_1)
	{
		gradientFill_0 = gradientFill_1;
	}

	/// <summary>
	///       Add a gradient stop.
	///       </summary>
	/// <param name="position">The position of the stop,in unit of percentage.</param>
	/// <param name="color">The color of the stop.</param>
	/// <param name="alpha">The alpha of the color.</param>
	public void Add(double position, CellsColor color, int alpha)
	{
		GradientStop gradientStop = new GradientStop(this);
		gradientStop.Position = position;
		gradientStop.internalColor_0 = color.internalColor_0;
		gradientStop.method_3(alpha);
		Add(gradientStop);
	}

	public void Add(double position, Color color, int alpha)
	{
		GradientStop gradientStop = new GradientStop(this);
		gradientStop.Position = position;
		gradientStop.internalColor_0 = new InternalColor(bool_0: true);
		gradientStop.internalColor_0.SetColor(ColorType.RGB, color.ToArgb());
		gradientStop.method_3(alpha);
		Add(gradientStop);
	}

	/// <summary>
	/// </summary>
	/// <param name="stop">
	/// </param>
	internal void Add(GradientStop gradientStop_0)
	{
		base.InnerList.Add(gradientStop_0);
	}

	internal void Insert(int int_0, GradientStop gradientStop_0)
	{
		base.InnerList.Insert(int_0, gradientStop_0);
	}

	internal void Copy(GradientStopCollection gradientStopCollection_0)
	{
		base.InnerList.Clear();
		for (int i = 0; i < gradientStopCollection_0.Count; i++)
		{
			GradientStop gradientStop = new GradientStop(this);
			gradientStop.Copy(gradientStopCollection_0[i]);
			base.InnerList.Add(gradientStop);
		}
	}
}
