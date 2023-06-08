namespace ns322;

internal class Class7356 : Class7353
{
	public Class7356(Interface401 global, Class7398 owner, string name)
		: base(global, owner, name)
	{
		Class7399 prototype = owner as Class7399;
		base.GetFunction = new Class7401(global, "get_length", prototype);
		base.SetFunction = new Class7401(global, "set_length", prototype);
	}
}
