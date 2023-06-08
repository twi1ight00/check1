using System.Text;
using ns305;
using ns73;

namespace ns74;

internal class Class3694 : Class3679
{
	private string string_0;

	private Class3679[] class3679_0;

	public override string CSSText
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string_0).Append('(');
			if (class3679_0.Length != 0)
			{
				stringBuilder.Append(class3679_0[0].CSSText);
				for (int i = 1; i < class3679_0.Length; i++)
				{
					stringBuilder.Append(", ").Append(class3679_0[1].CSSText);
				}
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}
		set
		{
			throw new Exception73(Enum968.const_8);
		}
	}

	public Class3694(string functionName, params Class3679[] parameters)
		: base(3)
	{
		string_0 = functionName;
		class3679_0 = parameters;
	}

	public string method_0()
	{
		return string_0;
	}

	public Class3679[] method_1()
	{
		return class3679_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3694 @class = obj as Class3694;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		return string_0.Equals(@class.string_0);
	}
}
