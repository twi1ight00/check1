using System.Collections;
using System.Text;
using ns82;

namespace ns83;

internal class Class4367 : Class4362
{
	public object object_0;

	public IList ilist_1;

	public override int Type => 0;

	public override string Text => ToString();

	public override int TokenStartIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override int TokenStopIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Class4367(object label)
	{
		object_0 = label;
	}

	public override Interface105 imethod_6()
	{
		return null;
	}

	public override string ToString()
	{
		if (object_0 is Interface86)
		{
			Interface86 @interface = (Interface86)object_0;
			if (@interface.Type == Class4398.int_7)
			{
				return "<EOF>";
			}
			return @interface.Text;
		}
		return object_0.ToString();
	}

	public string method_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (ilist_1 != null)
		{
			for (int i = 0; i < ilist_1.Count; i++)
			{
				Interface86 @interface = (Interface86)ilist_1[i];
				stringBuilder.Append(@interface.Text);
			}
		}
		string text = ToString();
		if (text != "<EOF>")
		{
			stringBuilder.Append(text);
		}
		return stringBuilder.ToString();
	}

	public string method_2()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_3(stringBuilder);
		return stringBuilder.ToString();
	}

	public void method_3(StringBuilder buf)
	{
		if (object_0 is Interface86)
		{
			buf.Append(method_1());
			return;
		}
		int num = 0;
		while (ilist_0 != null && num < ilist_0.Count)
		{
			Class4367 @class = (Class4367)ilist_0[num];
			@class.method_3(buf);
			num++;
		}
	}
}
