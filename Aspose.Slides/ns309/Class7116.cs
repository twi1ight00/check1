namespace ns309;

internal class Class7116
{
	internal Class7115[] class7115_0;

	internal Class7116(Class7115[] list)
	{
		class7115_0 = list;
	}

	internal virtual float vmethod_0(int glyphCode, int glyphCodeNext, string glyphUnicode, string glyphUnicodeNext)
	{
		int num = 0;
		while (true)
		{
			if (num < class7115_0.Length)
			{
				if (class7115_0[num].vmethod_0(glyphCode, glyphUnicode) && class7115_0[num].vmethod_2(glyphCodeNext, glyphUnicodeNext))
				{
					break;
				}
				num++;
				continue;
			}
			return 0f;
		}
		return class7115_0[num].AdjustSpace;
	}
}
