namespace ns82;

internal class Class7334 : Interface392
{
	protected internal string string_0;

	protected internal int int_0;

	protected internal int int_1;

	protected internal int int_2;

	protected internal int int_3;

	protected internal int int_4;

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

	public virtual string Text
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

	public virtual Interface391 InputStream
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Class7334(int type)
	{
		int_0 = type;
	}

	public Class7334(Interface392 oldToken)
	{
		string_0 = oldToken.Text;
		int_0 = oldToken.Type;
		int_1 = oldToken.Line;
		int_2 = oldToken.CharPositionInLine;
		int_3 = oldToken.Channel;
	}

	public Class7334(int type, string text)
	{
		int_0 = type;
		string_0 = text;
	}

	public Class7334(int type, string text, int channel)
	{
		int_0 = type;
		string_0 = text;
		int_3 = channel;
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
		return "[@" + TokenIndex + ",'" + text2 + "',<" + int_0 + ">" + text + "," + int_1 + ":" + CharPositionInLine + "]";
	}
}
