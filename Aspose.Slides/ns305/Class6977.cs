using System.Text;

namespace ns305;

internal abstract class Class6977 : Class6976
{
	private string string_0;

	public virtual string Data
	{
		get
		{
			if (string_0 != null)
			{
				return string_0;
			}
			return string.Empty;
		}
		set
		{
			string_0 = value;
		}
	}

	public int Length
	{
		get
		{
			if (string_0 != null)
			{
				return string_0.Length;
			}
			return 0;
		}
	}

	protected internal Class6977(string data, Class7046 doc)
		: base(doc)
	{
		string_0 = data;
	}

	public virtual string vmethod_5(int offset, int count)
	{
		_ = Length;
		if (Length == 0)
		{
			return string.Empty;
		}
		return string_0.Substring(offset, count);
	}

	public virtual void vmethod_6(string arg)
	{
		string_0 = new StringBuilder(string_0).Append(arg).ToString();
	}

	public virtual void vmethod_7(int offset, string arg)
	{
		string_0 = new StringBuilder(string_0).Insert(offset, arg).ToString();
	}

	public virtual void vmethod_8(int offset, int count)
	{
		string_0 = new StringBuilder(string_0).Remove(offset, count).ToString();
	}

	public virtual void vmethod_9(int offset, int count, string arg)
	{
		string_0 = new StringBuilder(string_0).Remove(offset, count).Insert(offset, arg).ToString();
	}
}
