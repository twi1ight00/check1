namespace ns305;

internal sealed class Class7045 : Class6976
{
	private Class7096 class7096_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	public string Name => class7096_0.Name;

	public bool Specified
	{
		get
		{
			return bool_0;
		}
		internal set
		{
			bool_0 = value;
		}
	}

	public string Value
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			bool_0 = false;
		}
	}

	public Class6981 OwnerElement => base.ParentNode as Class6981;

	public Class7095 SchemaTypeInfo => new Class7095(this);

	public bool IsId
	{
		get
		{
			return bool_1;
		}
		internal set
		{
			bool_1 = value;
		}
	}

	public override string NodeName => Name;

	public override string NodeValue
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value;
		}
	}

	public override string LocalName => class7096_0.LocalName;

	public override string NamespaceURI => class7096_0.NamespaceURI;

	public override string Prefix
	{
		get
		{
			return class7096_0.Prefix;
		}
		set
		{
			class7096_0.Prefix = class7096_0.OwnerDocument.NameTable.Add(value);
		}
	}

	public override Enum969 NodeType => Enum969.const_1;

	internal Class7045(Class7096 name, Class7046 doc)
		: base(doc)
	{
		class7096_0 = name;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_27(Prefix, LocalName, NamespaceURI);
	}
}
