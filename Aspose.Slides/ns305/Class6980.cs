namespace ns305;

internal class Class6980 : Class6977
{
	public bool IsElementContentWhitespace
	{
		get
		{
			string data = Data;
			int num = 0;
			while (true)
			{
				if (num < data.Length)
				{
					char c = data[num];
					if (!char.IsWhiteSpace(c))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public string WholeText => TextContent;

	public override string NodeName => base.OwnerDocument.string_6;

	public override Enum969 NodeType => Enum969.const_2;

	public override string NodeValue => Data;

	public override string TextContent
	{
		get
		{
			return NodeValue;
		}
		set
		{
			method_21(value);
		}
	}

	public override string LocalName => NodeName;

	internal Class6980(string strData)
		: this(strData, null)
	{
	}

	protected internal Class6980(string strData, Class7046 doc)
		: base(strData, doc)
	{
	}

	public Class6980 method_20(int offset)
	{
		int count = base.Length - offset;
		string data = vmethod_5(offset, count);
		vmethod_8(offset, count);
		Class6980 @class = base.OwnerDocument.method_21(data);
		base.ParentNode.vmethod_0(@class, this);
		return @class;
	}

	public Class6980 method_21(string content)
	{
		method_16();
		Class6976 parentNode = base.ParentNode;
		Class6976 previousSibling = base.PreviousSibling;
		base.ParentNode.method_2(this);
		if (string.IsNullOrEmpty(content))
		{
			return null;
		}
		Class6980 @class = parentNode.OwnerDocument.method_21(content);
		if (previousSibling != null)
		{
			parentNode.vmethod_0(@class, previousSibling);
		}
		else
		{
			parentNode.vmethod_1(@class);
		}
		return @class;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_21(Data);
	}

	public override string ToString()
	{
		return base.ToString();
	}
}
