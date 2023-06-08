using System.Text;
using ns122;
using ns157;

namespace ns125;

internal class Class4548 : Class4520
{
	private double double_0;

	private StringBuilder stringBuilder_0;

	public double Number
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

	public Class4548(Class4520 parent, byte[] file)
		: base(parent, file)
	{
		byte_1 = new byte[0][];
		byte_0 = new byte[0][];
		stringBuilder_0 = new StringBuilder();
	}

	public override void vmethod_1()
	{
		double_0 = double.MinValue;
		stringBuilder_0 = new StringBuilder();
		base.vmethod_1();
	}

	protected override bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		bodyStartPosition = -1;
		matchedMarker = null;
		if (Class4729.smethod_0(byte_2, startPosition))
		{
			bodyStartPosition = startPosition;
			matchedMarker = new byte[0];
			return true;
		}
		return false;
	}

	protected override byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		endPosition = -1;
		if (!Class4729.smethod_0(byte_2, currentPosition))
		{
			endPosition = currentPosition - 1;
			return new byte[0];
		}
		return null;
	}

	protected override void vmethod_6(int currentPosition)
	{
		stringBuilder_0.Append(Encoding.ASCII.GetString(new byte[1] { byte_2[currentPosition] }));
		base.vmethod_6(currentPosition);
	}

	protected override void vmethod_5()
	{
		double_0 = Class4729.ToDouble(stringBuilder_0.ToString());
		base.vmethod_5();
	}
}
