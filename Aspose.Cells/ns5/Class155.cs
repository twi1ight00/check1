using System.Collections;
using System.Drawing;

namespace ns5;

internal class Class155 : CollectionBase
{
	public Class157 this[int int_0] => (Class157)base.InnerList[int_0];

	public void Add(Color color_0, float float_0)
	{
		Class157 @class = new Class157();
		@class.Color = color_0;
		@class.Position = float_0;
		base.InnerList.Add(@class);
	}
}
