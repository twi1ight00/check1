namespace ns322;

internal class Class7355 : Class7353
{
	public Class7355(Interface401 global, Class7398 owner, string name)
		: base(global, owner, name)
	{
		Class7399 prototype = owner as Class7399;
		base.GetFunction = new Class7417(global, null, "get_length", prototype);
		base.SetFunction = new Class7417(global, null, "set_length", prototype);
	}
}
