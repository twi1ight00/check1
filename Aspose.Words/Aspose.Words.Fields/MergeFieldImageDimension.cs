using System;
using System.Collections;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace Aspose.Words.Fields;

public class MergeFieldImageDimension
{
	private double x4574aea041dd835f = -1.0;

	private MergeFieldImageDimensionUnit x6458c57b53228224;

	private static readonly IDictionary x0c9fdc0cb2c353ad;

	public double Value
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	public MergeFieldImageDimensionUnit Unit
	{
		get
		{
			return x6458c57b53228224;
		}
		set
		{
			switch (value)
			{
			case MergeFieldImageDimensionUnit.Point:
			case MergeFieldImageDimensionUnit.Percent:
				x6458c57b53228224 = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("value");
			}
		}
	}

	static MergeFieldImageDimension()
	{
		x0c9fdc0cb2c353ad = xd51c34d05311eee3.xdb04a310bbb29cff();
		x0c9fdc0cb2c353ad.Add("pt", MergeFieldImageDimensionUnit.Point);
		x0c9fdc0cb2c353ad.Add("%", MergeFieldImageDimensionUnit.Percent);
	}

	public MergeFieldImageDimension(double value)
	{
		Value = value;
	}

	public MergeFieldImageDimension(double value, MergeFieldImageDimensionUnit unit)
	{
		Value = value;
		Unit = unit;
	}

	internal MergeFieldImageDimension()
	{
	}

	internal static MergeFieldImageDimension x19890931227f0f56(string xcbf1e52a6a1000f9, string x828f48644fcf1ad3)
	{
		double d = xca004f56614e2431.xf5ece46c5d72e3b9(xcbf1e52a6a1000f9);
		if (double.IsNaN(d))
		{
			return null;
		}
		MergeFieldImageDimensionUnit mergeFieldImageDimensionUnit = MergeFieldImageDimensionUnit.Point;
		if (x0d299f323d241756.x5959bccb67bbf051(x828f48644fcf1ad3))
		{
			object obj = x0c9fdc0cb2c353ad[x828f48644fcf1ad3];
			if (obj == null)
			{
				return null;
			}
			mergeFieldImageDimensionUnit = (MergeFieldImageDimensionUnit)obj;
		}
		MergeFieldImageDimension mergeFieldImageDimension = new MergeFieldImageDimension();
		mergeFieldImageDimension.x4574aea041dd835f = d;
		mergeFieldImageDimension.x6458c57b53228224 = mergeFieldImageDimensionUnit;
		return mergeFieldImageDimension;
	}

	internal MergeFieldImageDimension x8b61531c8ea35b85()
	{
		return (MergeFieldImageDimension)MemberwiseClone();
	}

	internal static double x3ae2efb7fb57cc6a(MergeFieldImageDimension xb53aaa6b3b74c84f, double x1245dab499940cd9)
	{
		if (!x2d5c1249b31d3c86(xb53aaa6b3b74c84f))
		{
			return x1245dab499940cd9;
		}
		return xb53aaa6b3b74c84f.x6458c57b53228224 switch
		{
			MergeFieldImageDimensionUnit.Point => xb53aaa6b3b74c84f.x4574aea041dd835f, 
			MergeFieldImageDimensionUnit.Percent => x1245dab499940cd9 * xb53aaa6b3b74c84f.x4574aea041dd835f / 100.0, 
			_ => throw new InvalidOperationException("Undefined MergeFieldImageDimensionUnit has been encountered."), 
		};
	}

	internal static bool x2d5c1249b31d3c86(MergeFieldImageDimension xb53aaa6b3b74c84f)
	{
		if (xb53aaa6b3b74c84f != null)
		{
			return xb53aaa6b3b74c84f.x4574aea041dd835f >= 0.0;
		}
		return false;
	}
}
