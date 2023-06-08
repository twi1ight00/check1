using System.Collections;
using System.Drawing;
using ns284;
using ns290;
using ns301;

namespace ns277;

internal abstract class Class6839 : Interface332
{
	protected readonly Interface353 interface353_0;

	protected readonly Class6759 class6759_0;

	private Interface356 interface356_0;

	protected Class6839(Class6759 drawer, Interface353 positionCalculator)
	{
		Class6892.smethod_0(drawer, "drawer");
		Class6892.smethod_0(positionCalculator, "positionCalculator");
		class6759_0 = drawer;
		interface353_0 = positionCalculator;
	}

	public abstract void vmethod_0(Class6844 boxTree);

	public abstract void vmethod_1(Class6844 boxTree, ref Hashtable pageSet);

	public abstract Interface329 vmethod_2();

	public abstract float vmethod_3();

	public abstract float vmethod_4();

	public abstract object vmethod_5();

	public virtual void imethod_0(Class6844 container, bool isAps, ref Hashtable pageSet)
	{
		Class6892.smethod_0(container, "container");
		if (container.Link != null)
		{
			interface356_0 = container.Link;
		}
		interface353_0.imethod_0(container);
		PointF boxLocation = interface353_0.imethod_3();
		class6759_0.vmethod_0(container, boxLocation, isAps, ref pageSet);
		interface353_0.imethod_1(container);
	}

	public virtual void imethod_1(Class6844 container, bool boxType, ref Hashtable pageSet)
	{
		if (container.Link != null && container.Link == interface356_0)
		{
			interface356_0 = null;
		}
		interface353_0.imethod_4();
		interface353_0.imethod_4();
	}

	public virtual void imethod_2(Class6844 box, bool boxType, ref Hashtable pageSet)
	{
		Class6892.smethod_0(box, "box");
		if (box is Class6855 box2)
		{
			interface353_0.imethod_2(box);
			PointF pos = interface353_0.imethod_3();
			class6759_0.vmethod_1(box2, pos, interface356_0, boxType, ref pageSet);
		}
		if (box is Class6847 @class)
		{
			interface353_0.imethod_2(box);
			PointF pointF = interface353_0.imethod_3();
			class6759_0.vmethod_2(@class.Src, pointF.X, pointF.Y, @class.Size.Width, @class.Size.Height, boxType, ref pageSet);
			class6759_0.vmethod_0(box, new PointF(pointF.X, pointF.Y), boxType: true, ref pageSet);
		}
		interface353_0.imethod_4();
	}
}
