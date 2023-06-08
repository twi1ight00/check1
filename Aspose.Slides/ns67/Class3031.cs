using System.Collections;
using System.Collections.Generic;

namespace ns67;

internal sealed class Class3031 : IEnumerable, IEnumerable<Struct159>
{
	private readonly List<Struct159> list_0;

	private readonly Enum492 enum492_0;

	private readonly bool bool_0;

	private bool bool_1;

	public Struct159 this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	public int PointsCount => list_0.Count;

	public bool IsClosed => bool_1;

	public Enum492 FillMode => enum492_0;

	public bool Stroke => bool_0;

	public Class3031(Enum492 fillMode)
		: this(fillMode, stroke: true)
	{
	}

	public Class3031(Enum492 fillMode, bool stroke)
	{
		enum492_0 = fillMode;
		list_0 = new List<Struct159>();
		bool_1 = false;
		bool_0 = stroke;
	}

	public void method_0(Struct159 point)
	{
		list_0.Add(point);
	}

	public void Close()
	{
		bool_1 = true;
		list_0.TrimExcess();
	}

	public Struct160 method_1()
	{
		if (list_0.Count == 0)
		{
			return default(Struct160);
		}
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		int count = list_0.Count;
		for (int i = 0; i < count; i++)
		{
			Struct159 @struct = list_0[i];
			if (@struct.X < num)
			{
				num = @struct.X;
			}
			if (@struct.Y < num3)
			{
				num3 = @struct.Y;
			}
			if (@struct.X > num2)
			{
				num2 = @struct.X;
			}
			if (@struct.Y > num4)
			{
				num4 = @struct.Y;
			}
		}
		return new Struct160(num, num3, num2, num4);
	}

	public IEnumerator<Struct159> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
