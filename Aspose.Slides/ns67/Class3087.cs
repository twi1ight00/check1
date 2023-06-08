using System;

namespace ns67;

internal sealed class Class3087
{
	private static Class3087 class3087_0;

	private static readonly object object_0 = new object();

	public static Class3087 Instance
	{
		get
		{
			if (class3087_0 == null)
			{
				lock (object_0)
				{
					if (class3087_0 == null)
					{
						class3087_0 = new Class3087();
					}
				}
			}
			return class3087_0;
		}
	}

	public Class3075 method_0(Class3401 bullet, Class3391 color, Class3394 size, Class3398 typeface, Class3406 characterProperties, Class3455 textBodyExtents)
	{
		if (bullet is Class3402 bullet2)
		{
			return new Class3076(bullet2, color, size, typeface, characterProperties, textBodyExtents);
		}
		if (bullet is Class3403 bullet3)
		{
			return new Class3077(bullet3, color, size, typeface, characterProperties, textBodyExtents);
		}
		if (bullet is Class3404 bullet4)
		{
			return new Class3078(bullet4, color, size, typeface, characterProperties, textBodyExtents);
		}
		if (bullet is Class3405 bullet5)
		{
			return new Class3079(bullet5, color, size, typeface, characterProperties, textBodyExtents);
		}
		throw new NotImplementedException();
	}
}
