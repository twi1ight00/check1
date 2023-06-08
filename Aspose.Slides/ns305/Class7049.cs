using System.Text;

namespace ns305;

internal class Class7049 : Class6976
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Class7062 class7062_0;

	private Class7062 class7062_1;

	public string Name => string_0;

	public Class7062 Entities
	{
		get
		{
			if (class7062_0 == null)
			{
				class7062_0 = new Class7062(this);
			}
			return class7062_0;
		}
	}

	public Class7062 Notations
	{
		get
		{
			if (class7062_1 == null)
			{
				class7062_1 = new Class7062(this);
			}
			return class7062_1;
		}
	}

	public string PublicId => string_1;

	public string SystemId => string_2;

	public string InternalSubset => string_3;

	public override string NodeName => Name;

	public override Enum969 NodeType => Enum969.const_9;

	protected internal Class7049(string name, string publicId, string systemId, string internalSubset, Class7046 doc)
	{
		string_0 = name;
		string_1 = publicId;
		string_2 = systemId;
		string_3 = internalSubset;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_30(string_0, string_1, string_2, string_3);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("<!DOCTYPE {0}", string_0);
		if (!string.IsNullOrEmpty(string_1))
		{
			stringBuilder.AppendFormat(" PUBLIC \"{0}\"", string_1);
		}
		if (!string.IsNullOrEmpty(string_2))
		{
			stringBuilder.AppendFormat(" SYSTEM \"{0}\"", string_2);
		}
		stringBuilder.Append(">");
		return stringBuilder.ToString();
	}
}
