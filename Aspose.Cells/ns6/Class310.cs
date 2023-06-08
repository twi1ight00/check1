using System.Collections;
using System.Drawing;

namespace ns6;

internal class Class310 : CollectionBase
{
	public Class311 this[int int_0] => (Class311)base.InnerList[int_0];

	public void Add(Color color_0, float float_0)
	{
		Class311 @class = new Class311();
		@class.Color = color_0;
		@class.Position = float_0;
		base.InnerList.Add(@class);
	}
}
