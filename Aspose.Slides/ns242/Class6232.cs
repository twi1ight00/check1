using System;
using System.Collections;
using System.Drawing;
using ns243;

namespace ns242;

internal class Class6232 : Class6227
{
	private readonly int int_1;

	public int CellCount => int_1;

	public Class6232(float width, Struct220 margin, int cellCount, Class6239 documentCreator)
		: base(width, margin, documentCreator)
	{
		int_1 = cellCount;
	}

	public virtual Class6231 vmethod_17()
	{
		Class6231 @class = class6239_0.NodesFactory.vmethod_4(this);
		vmethod_5(@class);
		return @class;
	}

	public override Class6225 vmethod_5(Class6225 node)
	{
		float x = vmethod_0().X + vmethod_10();
		Class6225 @class = base.vmethod_5(node);
		PointF location = new PointF(x, vmethod_0().Y + @class.Size.Height);
		@class.Location = location;
		return @class;
	}

	public override float vmethod_8()
	{
		float num = 0f;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Class6225 @class = (Class6225)enumerator.Current;
				num = ((@class.Size.Height > num) ? @class.Size.Height : num);
			}
			return num;
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
