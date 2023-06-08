using System;
using System.Collections;
using System.Drawing;
using ns242;

namespace ns243;

internal class Class6233 : Class6227, ICloneable
{
	private readonly SizeF sizeF_1;

	public override SizeF Size => sizeF_1;

	public Class6233(SizeF size, Struct220 margin, Class6239 documentCreator)
		: base(size.Width, margin, documentCreator)
	{
		sizeF_1 = size;
	}

	public object Clone()
	{
		Class6233 @class = new Class6233(Size, Margin, class6239_0);
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 node = (Class6225)enumerator.Current;
				@class.vmethod_5(node);
			}
			return @class;
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
