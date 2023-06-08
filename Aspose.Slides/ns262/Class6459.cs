using System.Collections.Generic;
using System.Text;
using ns224;
using ns235;

namespace ns262;

internal abstract class Class6459 : Interface305
{
	private readonly Interface304 interface304_0;

	private readonly Class6471 class6471_0 = new Class6471();

	private double double_0;

	private double double_1;

	private List<Interface301> list_0 = new List<Interface301>();

	private double double_2;

	public double X
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double OriginalWidth => double_1;

	public List<Interface301> RunParts => list_0;

	public abstract Enum835 Type { get; }

	public Interface300 VerticalMeasurement => class6471_0;

	public double ActualWidth
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	protected Class6459(Interface304 serviceLocator)
	{
		interface304_0 = serviceLocator;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Interface301 runPart in RunParts)
		{
			stringBuilder.Append(runPart);
		}
		return stringBuilder.ToString();
	}

	public Class6213 imethod_0()
	{
		Class6213 @class = new Class6213();
		foreach (Interface301 item in list_0)
		{
			Class6219 class2 = item.imethod_0();
			if (class2 != null)
			{
				@class.Add(class2);
			}
		}
		@class.RenderTransform = new Class6002();
		@class.RenderTransform.method_8((float)X, 0f);
		return @class;
	}

	public void method_0(Interface301 runPart)
	{
		runPart.X = OriginalWidth;
		double_1 += runPart.Width;
		double_0 = double_1;
		class6471_0.Add(runPart);
		list_0.Add(runPart);
	}
}
