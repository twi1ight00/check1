using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xcc8a79815d76af85;

internal class x8feaf55aff422186 : x86270791cf6a92b9
{
	private double x4574aea041dd835f;

	private string x9a825beeeb75071e;

	public override string StringValue
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x9a825beeeb75071e))
			{
				return xca004f56614e2431.xcadee4aea45827c2(x4574aea041dd835f);
			}
			return x4574aea041dd835f.ToString(x9a825beeeb75071e);
		}
	}

	public override float FloatValue => (float)x4574aea041dd835f;

	public double xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public string xfc954f23e7c18656
	{
		get
		{
			return x9a825beeeb75071e;
		}
		set
		{
			if (value != null && value.ToLower() != "general")
			{
				x9a825beeeb75071e = value;
			}
		}
	}

	public x8feaf55aff422186(int index, double value, string formatCode)
		: base(index, xd620087af5172910.xdad37f621665da16)
	{
		x4574aea041dd835f = value;
		xfc954f23e7c18656 = formatCode;
	}
}
