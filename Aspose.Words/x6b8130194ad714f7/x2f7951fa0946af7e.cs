using System.Text.RegularExpressions;
using xf9a9481c3f63a419;

namespace x6b8130194ad714f7;

internal class x2f7951fa0946af7e
{
	private static readonly Regex x94ce347db2b1357a = new Regex("-?[0-9]+(\\.[0-9]+)?%", RegexOptions.Compiled);

	private readonly string x4574aea041dd835f;

	private double xd1a45b92325cb09f;

	public double x71c5078172d72420 => xd1a45b92325cb09f;

	public string xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public x2f7951fa0946af7e(double value)
	{
		x4574aea041dd835f = xca004f56614e2431.xcadee4aea45827c2(value * 100.0) + "%";
		xd1a45b92325cb09f = value;
	}

	public x2f7951fa0946af7e(string value)
	{
		string input = ((value != null) ? value : string.Empty);
		if (!x94ce347db2b1357a.IsMatch(input))
		{
			input = string.Empty;
		}
		x4574aea041dd835f = input;
		xd1a45b92325cb09f = 0.0;
		xb38e989bceed6f14();
	}

	public bool Equals(x2f7951fa0946af7e other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.x4574aea041dd835f, x4574aea041dd835f))
		{
			return other.xd1a45b92325cb09f.Equals(xd1a45b92325cb09f);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(x2f7951fa0946af7e))
		{
			return false;
		}
		return Equals((x2f7951fa0946af7e)obj);
	}

	public override int GetHashCode()
	{
		return (((x4574aea041dd835f != null) ? x4574aea041dd835f.GetHashCode() : 0) * 397) ^ xd1a45b92325cb09f.GetHashCode();
	}

	private void xb38e989bceed6f14()
	{
		if (xd2f68ee6f47e9dfb.Length == 0)
		{
			xd1a45b92325cb09f = 0.0;
			return;
		}
		string x37cf7043760b312e = xd2f68ee6f47e9dfb.Substring(0, xd2f68ee6f47e9dfb.Length - 1);
		double num = xca004f56614e2431.xec25d08a2af152f0(x37cf7043760b312e);
		xd1a45b92325cb09f = num / 100.0;
	}
}
