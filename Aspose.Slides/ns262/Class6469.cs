using System.Collections;
using System.Drawing;
using ns219;
using ns224;
using ns253;

namespace ns262;

internal class Class6469 : Interface313
{
	private readonly Interface293 interface293_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class6469(Interface293 dataProvider)
	{
		interface293_0 = dataProvider;
	}

	public Class5999 imethod_0(Class6445 properties)
	{
		Class5999 @class = (Class5999)hashtable_0[properties];
		if (@class == null)
		{
			Class6428 latinFont = properties.LatinFont;
			string textTypeface = latinFont.TextTypeface;
			double valueInPoints = properties.FontSize.ValueInPoints;
			FontStyle style = properties.method_2();
			@class = interface293_0.imethod_3(textTypeface, (float)valueInPoints, style);
			hashtable_0[properties] = @class;
		}
		return @class;
	}
}
