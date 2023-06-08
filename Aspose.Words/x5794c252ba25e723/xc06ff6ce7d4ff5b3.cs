using System;
using x24ed092a62874e86;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;

namespace x5794c252ba25e723;

internal class xc06ff6ce7d4ff5b3
{
	private static x1f2ba9b7cb678190 xd02b7aeb4a48ef5b;

	internal static x1f2ba9b7cb678190 xd2ad080e85a27b04(float x6eebe5873d5613d0, float x7245ca8139eba392)
	{
		float num = ((x6eebe5873d5613d0 < 0.5f) ? (2f * x6eebe5873d5613d0) : ((!(x6eebe5873d5613d0 > 0.99f)) ? Math.Min(1.1f * (float)Math.Tan(Math.PI * (double)(x6eebe5873d5613d0 - 0.5f)) + 1f, 500f) : 500f));
		float num2 = num * (x7245ca8139eba392 - 1f) + x7245ca8139eba392;
		float[][] colorMatrix = new float[5][]
		{
			new float[5] { num, 0f, 0f, 0f, 0f },
			new float[5] { 0f, num, 0f, 0f, 0f },
			new float[5] { 0f, 0f, num, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { num2, num2, num2, 0f, 1f }
		};
		return new x1f2ba9b7cb678190(colorMatrix);
	}

	internal static x1f2ba9b7cb678190 x4e37abf1fefccbb0()
	{
		if (xd02b7aeb4a48ef5b == null)
		{
			float[][] colorMatrix = new float[5][]
			{
				new float[5] { 0.2125f, 0.2125f, 0.2125f, 0f, 0f },
				new float[5] { 0.7154f, 0.7154f, 0.7154f, 0f, 0f },
				new float[5] { 0.0721f, 0.0721f, 0.0721f, 0f, 0f },
				new float[5] { 0f, 0f, 0f, 1f, 0f },
				new float[5] { 1E-07f, 1E-07f, 1E-07f, 0f, 1f }
			};
			xd02b7aeb4a48ef5b = new x1f2ba9b7cb678190(colorMatrix);
		}
		return xd02b7aeb4a48ef5b;
	}

	internal static x1f2ba9b7cb678190 xe7b2641dc5375bea(xda4dde4038ab80db x908dde28884ab446, x6ecdfaec63740001 xaeae22d502c36c76, xd7e8497b32a408b8 x6d9a095d183b6b50, xd7e8497b32a408b8 x60a2487f840b534c)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = x6d9a095d183b6b50.x9f7ccd52de411b4f(xaeae22d502c36c76, x908dde28884ab446);
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d3 = x60a2487f840b534c.x9f7ccd52de411b4f(xaeae22d502c36c76, x908dde28884ab446);
		float[][] colorMatrix = new float[5][]
		{
			new float[5]
			{
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d3.xc613adc4330033f3 - x26d9ecb4bdf0456d2.xc613adc4330033f3),
				0f,
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d3.x26463655896fd90a - x26d9ecb4bdf0456d2.x26463655896fd90a),
				0f,
				0f,
				0f
			},
			new float[5]
			{
				0f,
				0f,
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d3.x8e8f6cc6a0756b05 - x26d9ecb4bdf0456d2.x8e8f6cc6a0756b05),
				0f,
				0f
			},
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5]
			{
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d2.xc613adc4330033f3),
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d2.x26463655896fd90a),
				xa52a449dbc76fcc2(x26d9ecb4bdf0456d2.x8e8f6cc6a0756b05),
				0f,
				1f
			}
		};
		return new x1f2ba9b7cb678190(colorMatrix);
	}

	private static float xa52a449dbc76fcc2(int x2819ac37ce9513c7)
	{
		return (float)x2819ac37ce9513c7 / 255f;
	}
}
