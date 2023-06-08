using System;

namespace ns305;

internal class Class7044 : Class6976
{
	internal const string string_0 = "no";

	internal const string string_1 = "yes";

	private string string_2;

	private string string_3;

	private string string_4;

	public string Encoding
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value ?? string.Empty;
		}
	}

	public override string LocalName => NodeName;

	public override string NodeName => "xml";

	public override Enum969 NodeType => Enum969.const_12;

	public string Standalone
	{
		get
		{
			return string_3;
		}
		set
		{
			if (value == null)
			{
				string_3 = string.Empty;
				return;
			}
			if (value.Length != 0 && value != "yes" && value != "no")
			{
				throw new ArgumentException();
			}
			string_3 = value;
		}
	}

	public string Version
	{
		get
		{
			return string_4;
		}
		internal set
		{
			string_4 = value;
		}
	}

	protected internal Class7044(string version, string encoding, string standalone, Class7046 doc)
		: base(doc)
	{
		Encoding = encoding;
		Standalone = standalone;
		Version = version;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_29(Version, Encoding, Standalone);
	}
}
