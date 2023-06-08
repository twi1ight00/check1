using System.Collections;
using ns328;

namespace ns322;

internal class Class7370 : Class7361
{
	private Hashtable hashtable_0;

	public Hashtable Values => hashtable_0;

	public void method_0(Class7374 propertyExpression)
	{
		if (propertyExpression.Name == null)
		{
			propertyExpression.Name = Class7691.smethod_0(typeof(Enum985)).vmethod_0(propertyExpression.Mode).ToLower();
			propertyExpression.Mode = Enum985.const_0;
		}
		if (Values.ContainsKey(propertyExpression.Name))
		{
			if (!(Values[propertyExpression.Name] is Class7374 @class))
			{
				throw new Exception89("A property cannot be both an accessor and data");
			}
			switch (propertyExpression.Mode)
			{
			case Enum985.const_0:
				if (propertyExpression.Mode == Enum985.const_0)
				{
					Values[propertyExpression.Name] = propertyExpression.Expression;
					break;
				}
				throw new Exception89("A property cannot be both an accessor and data");
			case Enum985.const_1:
				@class.method_1(propertyExpression);
				break;
			case Enum985.const_2:
				@class.method_0(propertyExpression);
				break;
			}
		}
		else
		{
			hashtable_0.Add(propertyExpression.Name, propertyExpression);
			switch (propertyExpression.Mode)
			{
			case Enum985.const_0:
				Values[propertyExpression.Name] = propertyExpression;
				break;
			case Enum985.const_1:
				propertyExpression.method_1(propertyExpression);
				break;
			case Enum985.const_2:
				propertyExpression.method_0(propertyExpression);
				break;
			}
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_28(this);
	}

	public Class7370()
	{
		hashtable_0 = new Hashtable();
	}
}
