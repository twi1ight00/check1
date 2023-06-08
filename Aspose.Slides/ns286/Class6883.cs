using ns284;

namespace ns286;

internal class Class6883
{
	private Class6983 class6983_0;

	public bool HasBeforeContent
	{
		get
		{
			if (class6983_0.StyleDeclarationInternal.Before != null && !class6983_0.StyleDeclarationInternal.Before.Content.IsNone)
			{
				return !class6983_0.StyleDeclarationInternal.Before.Content.IsNormal;
			}
			return false;
		}
	}

	public bool HasAfterContent
	{
		get
		{
			if (class6983_0.StyleDeclarationInternal.After != null && !class6983_0.StyleDeclarationInternal.After.Content.IsNone)
			{
				return !class6983_0.StyleDeclarationInternal.After.Content.IsNormal;
			}
			return false;
		}
	}

	public Class6883(Class6983 element)
	{
		class6983_0 = element;
	}

	public string method_0()
	{
		if (!class6983_0.StyleDeclarationInternal.Before.Content.IsNone && !class6983_0.StyleDeclarationInternal.Before.Content.IsNormal)
		{
			return class6983_0.StyleDeclarationInternal.Before.Content.method_3();
		}
		return string.Empty;
	}

	public string method_1()
	{
		if (!class6983_0.StyleDeclarationInternal.After.Content.IsNone && !class6983_0.StyleDeclarationInternal.After.Content.IsNormal)
		{
			return class6983_0.StyleDeclarationInternal.After.Content.method_3();
		}
		return string.Empty;
	}
}
