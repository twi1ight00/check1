using System.Collections;

namespace x6f978ba1e7522832;

internal class xbac664ebc33878a7 : IComparer
{
	private int x91c86e0de828cc9f(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
	{
		xc86c21c356e363c0 xc86c21c356e363c = (xc86c21c356e363c0)x08db3aeabb253cb1;
		xc86c21c356e363c0 xc86c21c356e363c2 = (xc86c21c356e363c0)x1e218ceaee1bb583;
		int num = (int)(xc86c21c356e363c.x2569902fd5a858dc * 1000 + xc86c21c356e363c.x38ced5a01a389303 * 100 + xc86c21c356e363c2.x0f99c8963adcf9a2);
		int num2 = (int)(xc86c21c356e363c2.x2569902fd5a858dc * 1000 + xc86c21c356e363c2.x38ced5a01a389303 * 100 + xc86c21c356e363c.x0f99c8963adcf9a2);
		return num - num2;
	}

	int IComparer.Compare(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x91c86e0de828cc9f
		return this.x91c86e0de828cc9f(x08db3aeabb253cb1, x1e218ceaee1bb583);
	}
}
