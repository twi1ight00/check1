namespace ns305;

internal class Class7053 : Class6976
{
	private string string_0;

	private string string_1;

	public string Target => string_1;

	public string Data
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

	public override string NodeName
	{
		get
		{
			if (string_1 != null)
			{
				return string_1;
			}
			return string.Empty;
		}
	}

	public override string LocalName => NodeName;

	public override Enum969 NodeType => Enum969.const_6;

	protected internal Class7053(string target, string data, Class7046 doc)
		: base(doc)
	{
		string_1 = target;
		string_0 = data;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_24(string_1, string_0);
	}
}
