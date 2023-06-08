using System;
using System.Collections;
using ns224;
using ns235;
using ns243;

namespace ns242;

internal class Class6228 : Class6227
{
	protected float float_1;

	public Class6228(float width, Struct220 margin, float lineSpace, Class6239 documentCreator)
		: base(width, margin, documentCreator)
	{
		float_1 = lineSpace;
	}

	public virtual void AddText(string text)
	{
		Class6235[] array = class6239_0.NodesFactory.vmethod_0(text, this);
		Class6235[] array2 = array;
		foreach (Class6235 node in array2)
		{
			vmethod_5(node);
		}
	}

	public override float vmethod_8()
	{
		if (Count <= 0)
		{
			return 0f;
		}
		return base.vmethod_8() + (float)(Count - 1) * float_1;
	}

	public override Class6225 vmethod_5(Class6225 node)
	{
		Class6225 @class = base.vmethod_5(node);
		@class.method_1(@class.Size.Height);
		return @class;
	}

	public override Class6227 vmethod_14()
	{
		Class6228 @class = new Class6228(float_0, Margin, float_1, class6239_0);
		@class.Location = Location;
		@class.method_4(base.Style);
		return @class;
	}

	protected override float vmethod_15(Class6225 node)
	{
		return node.Size.Height + float_1;
	}

	public void method_5(Class5998 fgColor)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6235 @class = (Class6235)enumerator.Current;
				@class.ForeColor = fgColor;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public override Class6204[] vmethod_2()
	{
		if (base.Style != null && base.Style.class5998_0 != Class5998.class5998_141)
		{
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Class6235 @class = (Class6235)enumerator.Current;
						@class.ForeColor = base.Style.class5998_0;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		return base.vmethod_2();
	}
}
