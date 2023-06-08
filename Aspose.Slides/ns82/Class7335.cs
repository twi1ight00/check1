using System;

namespace ns82;

internal class Class7335 : Interface392
{
	protected internal int int_0;

	protected internal int int_1;

	protected internal int int_2 = -1;

	protected internal int int_3;

	[NonSerialized]
	protected internal Interface391 interface391_0;

	protected internal string string_0;

	protected internal int int_4 = -1;

	protected internal int int_5;

	protected internal int int_6;

	public virtual int Type
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public virtual int Line
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public virtual int CharPositionInLine
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

	public virtual int Channel
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

	public virtual int StartIndex
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public virtual int StopIndex
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	public virtual int TokenIndex
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public virtual Interface391 InputStream
	{
		get
		{
			return interface391_0;
		}
		set
		{
			interface391_0 = value;
		}
	}

	public virtual string Text
	{
		get
		{
			if (string_0 != null)
			{
				return string_0;
			}
			if (interface391_0 == null)
			{
				return null;
			}
			string_0 = interface391_0.imethod_9(int_5, int_6);
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class7335(int type)
	{
		int_0 = type;
	}

	public Class7335(Interface391 input, int type, int channel, int start, int stop)
	{
		interface391_0 = input;
		int_0 = type;
		int_3 = channel;
		int_5 = start;
		int_6 = stop;
	}

	public Class7335(int type, string text)
	{
		int_0 = type;
		int_3 = 0;
		string_0 = text;
	}

	public Class7335(Interface392 oldToken)
	{
		string_0 = oldToken.Text;
		int_0 = oldToken.Type;
		int_1 = oldToken.Line;
		int_4 = oldToken.TokenIndex;
		int_2 = oldToken.CharPositionInLine;
		int_3 = oldToken.Channel;
		if (oldToken is Class7335 @class)
		{
			int_5 = @class.int_5;
			int_6 = @class.int_6;
		}
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (int_3 > 0)
		{
			text = ",channel=" + int_3;
		}
		string text2 = Text;
		if (text2 != null)
		{
			text2 = text2.Replace("\n", "\\\\n");
			text2 = text2.Replace("\r", "\\\\r");
			text2 = text2.Replace("\t", "\\\\t");
		}
		else
		{
			text2 = "<no text>";
		}
		return "[@" + TokenIndex + "," + int_5 + ":" + int_6 + "='" + text2 + "',<" + int_0 + ">" + text + "," + int_1 + ":" + CharPositionInLine + "]";
	}
}
