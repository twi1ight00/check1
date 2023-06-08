namespace ns322;

internal class Class7374 : Class7361
{
	private string string_1;

	private Class7361 class7361_0;

	private Enum985 enum985_0;

	private Class7361 class7361_1;

	private Class7361 class7361_2;

	public string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class7361 Expression
	{
		get
		{
			return class7361_0;
		}
		set
		{
			class7361_0 = value;
		}
	}

	public Enum985 Mode
	{
		get
		{
			return enum985_0;
		}
		set
		{
			enum985_0 = value;
		}
	}

	public Class7361 GetExpression => class7361_1;

	public Class7361 SetExpression => class7361_2;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_26(this);
	}

	internal void method_0(Class7374 propertyExpression)
	{
		class7361_2 = propertyExpression.Expression;
	}

	internal void method_1(Class7374 propertyExpression)
	{
		class7361_1 = propertyExpression.Expression;
	}
}
