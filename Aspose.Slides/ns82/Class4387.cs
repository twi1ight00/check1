using System.Collections;

namespace ns82;

internal class Class4387 : Interface107, Interface110
{
	protected internal char[] char_0;

	protected int int_0;

	protected internal int int_1;

	protected internal int int_2 = 1;

	protected internal int int_3;

	protected internal int int_4;

	protected internal IList ilist_0;

	protected int int_5;

	protected string string_0;

	public virtual int Line
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public virtual int CharPositionInLine
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public virtual string SourceName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	protected Class4387()
	{
	}

	public Class4387(string input)
	{
		char_0 = input.ToCharArray();
		int_0 = input.Length;
	}

	public Class4387(char[] data, int numberOfActualCharsInArray)
	{
		char_0 = data;
		int_0 = numberOfActualCharsInArray;
	}

	public virtual void Reset()
	{
		int_1 = 0;
		int_2 = 1;
		int_3 = 0;
		int_4 = 0;
	}

	public virtual void imethod_0()
	{
		if (int_1 < int_0)
		{
			int_3++;
			if (char_0[int_1] == '\n')
			{
				int_2++;
				int_3 = 0;
			}
			int_1++;
		}
	}

	public virtual int imethod_1(int i)
	{
		if (i == 0)
		{
			return 0;
		}
		if (i < 0)
		{
			i++;
			if (int_1 + i - 1 < 0)
			{
				return -1;
			}
		}
		if (int_1 + i - 1 >= int_0)
		{
			return -1;
		}
		return char_0[int_1 + i - 1];
	}

	public virtual int imethod_8(int i)
	{
		return imethod_1(i);
	}

	public virtual int imethod_3()
	{
		return int_1;
	}

	public virtual int imethod_7()
	{
		return int_0;
	}

	public virtual int imethod_2()
	{
		if (ilist_0 == null)
		{
			ilist_0 = new ArrayList();
			ilist_0.Add(null);
		}
		int_4++;
		Class4392 @class = null;
		if (int_4 >= ilist_0.Count)
		{
			@class = new Class4392();
			ilist_0.Add(@class);
		}
		else
		{
			@class = (Class4392)ilist_0[int_4];
		}
		@class.int_0 = int_1;
		@class.int_1 = int_2;
		@class.int_2 = int_3;
		int_5 = int_4;
		return int_4;
	}

	public virtual void imethod_4(int m)
	{
		Class4392 @class = (Class4392)ilist_0[m];
		Seek(@class.int_0);
		int_2 = @class.int_1;
		int_3 = @class.int_2;
		imethod_6(m);
	}

	public virtual void imethod_5()
	{
		imethod_4(int_5);
	}

	public virtual void imethod_6(int marker)
	{
		int_4 = marker;
		int_4--;
	}

	public virtual void Seek(int index)
	{
		if (index <= int_1)
		{
			int_1 = index;
			return;
		}
		while (int_1 < index)
		{
			imethod_0();
		}
	}

	public virtual string imethod_9(int start, int stop)
	{
		return new string(char_0, start, stop - start + 1);
	}
}
