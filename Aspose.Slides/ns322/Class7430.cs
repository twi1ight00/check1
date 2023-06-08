namespace ns322;

internal class Class7430 : Class7399
{
	private Interface401 interface401_0;

	private string message
	{
		get
		{
			return this["message"].ToString();
		}
		set
		{
			this["message"] = interface401_0.StringClass.method_5(value);
		}
	}

	public override object Value => message;

	public override string _Class => "Error";

	public override string ToString()
	{
		return Value.ToString();
	}

	public Class7430(Interface401 global)
		: this(global, string.Empty)
	{
	}

	public Class7430(Interface401 global, string message)
		: base(global.ErrorClass.PrototypeProperty)
	{
		interface401_0 = global;
		this.message = message;
	}
}
