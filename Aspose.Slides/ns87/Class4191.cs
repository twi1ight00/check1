using ns73;
using ns84;

namespace ns87;

internal class Class4191 : Class4154
{
	public class Class4335
	{
		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		public float StartPoint => float_0;

		public float Point1 => float_1;

		public float Point2 => float_2;

		public float EndPoint => float_3;

		public Class4335(float startPoint, float point1, float point2, float endPoint)
		{
			float_0 = startPoint;
			float_1 = point1;
			float_2 = point2;
			float_3 = endPoint;
		}
	}

	private Enum561 enum561_0;

	private Class4335 class4335_0;

	public Enum561 Type => enum561_0;

	public Class4335 FunctionParameters => class4335_0;

	internal Class4191(Class3679 cssValue)
		: base(cssValue)
	{
	}
}
