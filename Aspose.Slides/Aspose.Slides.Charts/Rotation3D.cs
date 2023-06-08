using System;
using ns25;

namespace Aspose.Slides.Charts;

public class Rotation3D : IRotation3D
{
	internal sbyte sbyte_0;

	internal ushort ushort_0;

	private byte byte_0 = 30;

	private bool bool_0;

	private ushort ushort_1 = 100;

	private ushort ushort_2 = 100;

	private Class326 class326_0 = new Class326();

	internal Class326 PPTXUnsupportedProps => class326_0;

	public sbyte RotationX
	{
		get
		{
			return sbyte_0;
		}
		set
		{
			if (value < -90 || value > 90)
			{
				throw new ArgumentOutOfRangeException("Out of range [-90; 90] for new RotationX property value.");
			}
			sbyte_0 = value;
		}
	}

	public ushort RotationY
	{
		get
		{
			return ushort_0;
		}
		set
		{
			if (value < 0 || value > 360)
			{
				throw new ArgumentOutOfRangeException("Out of range [0; 360] for new property value.");
			}
			ushort_0 = value;
		}
	}

	public byte Perspective
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("Out of range [0; 100] for new property value.");
			}
			byte_0 = value;
		}
	}

	public bool RightAngleAxes
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ushort DepthPercents
	{
		get
		{
			return ushort_1;
		}
		set
		{
			if (value < 20 || value > 2000)
			{
				throw new ArgumentOutOfRangeException("Out of range [20; 2000] for new property value.");
			}
			ushort_1 = value;
		}
	}

	public ushort HeightPercents
	{
		get
		{
			return ushort_2;
		}
		set
		{
			if (value < 5 || value > 500)
			{
				throw new ArgumentOutOfRangeException("Out of range [5; 500] for new property value.");
			}
			ushort_2 = value;
		}
	}

	internal Rotation3D()
	{
	}
}
