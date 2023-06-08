using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1a3e96f4b89a7a77;

internal class x51364ccbfdb889a8
{
	internal readonly string x1bd44401d685915c;

	internal readonly string x56cde9dc3f6c8838;

	internal readonly string xd0f3d9065ec530b6;

	internal readonly string xd386d6e78a8f86bb;

	internal readonly string x26095d7564fc96e5;

	internal readonly string xfe68f6bb38fb6f71;

	internal readonly string xad88d3dd46749878;

	internal readonly string xf8e05ede78514093;

	internal readonly string x094bb50702ffc46a;

	internal readonly string xb27a93f6225b838b;

	internal readonly string xb99af2eea9de631f;

	internal readonly string x56f7e07d3eb9e917;

	internal readonly string x8e6813d1269b38e0;

	internal readonly bool x297c4b9799408e4a = true;

	internal readonly bool xe68c5a6af2ad99fe;

	internal readonly PreferredWidth xa655e905c2c23d43;

	internal readonly string xdb7d175cb29503bf;

	internal readonly string x5e90d05988677502;

	internal readonly string x3ee36906f79c4fae;

	internal readonly Border xadf6945de3f17a6a;

	internal readonly Border x6d77c656b879ca53;

	internal readonly Border xcb0c5e0ca87ddd7c;

	internal readonly Border x120beac34b17159b;

	internal readonly Border x6188bb17d3fa6122;

	internal readonly Border x3aec10d81a685e0b;

	internal readonly Shading xbc9c2127d2bbf18f;

	internal readonly string x60e3d97b97bb8c4b;

	internal readonly string xc790aa4ad151a9a1;

	internal readonly string xbec4ce2ebab55739;

	internal readonly string x9d14ae04d4852341;

	internal readonly string x79a6be1d1f13a42b;

	internal readonly string x36845bc9dc2cf9c6;

	internal readonly string x8663ce8a3c4af300;

	internal readonly bool x17caeb7723171c51;

	internal readonly bool x59255fe095c130d7 = true;

	internal readonly object x292ab95da92a6344;

	internal readonly bool x96e55b5d052d1279;

	internal readonly string xcef3e13053354501;

	internal readonly string x16ee896df46bcefa;

	internal readonly string x95a824575f7410c3;

	internal readonly string x4a02d6e0c76b8da8;

	internal readonly int xe404f0479f85cd43;

	internal readonly int xf68b6aed44939b9a;

	internal readonly int x71e5b802707a5021;

	internal readonly int x90aab2cbd2f48623;

	internal readonly int x7390fcf53e1bd984;

	internal readonly int xd29e69906712391d;

	internal readonly bool x325f1926b78ae5cd;

	internal x51364ccbfdb889a8(xedb0eb766e25e0c9 tablePr, bool isStyle, xfe11bbc13ba649c3 context)
	{
		x325f1926b78ae5cd = context.x325f1926b78ae5cd;
		for (int i = 0; i < tablePr.xd44988f225497f3a; i++)
		{
			int num = tablePr.xf15263674eb297bb(i);
			object obj = tablePr.x6d3720b962bd3112(i);
			switch (num)
			{
			case 4005:
				if ((int)obj != 0)
				{
					x1bd44401d685915c = context.x7af082eaf8e0caa4((int)obj);
				}
				break;
			case 4500:
				x56cde9dc3f6c8838 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4510:
				xd0f3d9065ec530b6 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4220:
				xd386d6e78a8f86bb = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4210:
				x26095d7564fc96e5 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4280:
				xfe68f6bb38fb6f71 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4270:
				xad88d3dd46749878 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4150:
			{
				RelativeHorizontalPosition relativeHorizontalPosition = (RelativeHorizontalPosition)obj;
				if (relativeHorizontalPosition != RelativeHorizontalPosition.Column)
				{
					x094bb50702ffc46a = x72a0c846678ecaf9.x14e082375ba0c07c(relativeHorizontalPosition);
				}
				break;
			}
			case 4160:
			{
				RelativeVerticalPosition relativeVerticalPosition = (RelativeVerticalPosition)obj;
				if (relativeVerticalPosition != 0)
				{
					xf8e05ede78514093 = x72a0c846678ecaf9.xd28acd82ad3fd5e3(relativeVerticalPosition);
				}
				break;
			}
			case 4180:
			{
				HorizontalAlignment horizontalAlignment = (HorizontalAlignment)obj;
				if (horizontalAlignment != 0)
				{
					xb27a93f6225b838b = x72a0c846678ecaf9.x9617344359c63dd2(horizontalAlignment);
				}
				break;
			}
			case 4200:
			{
				VerticalAlignment verticalAlignment = (VerticalAlignment)obj;
				if (verticalAlignment != 0)
				{
					x56f7e07d3eb9e917 = x72a0c846678ecaf9.xf7b3d51063ad99cc(verticalAlignment);
				}
				break;
			}
			case 4170:
				xb99af2eea9de631f = xca004f56614e2431.x754c3a5f03a2ce84((int)obj + 1);
				break;
			case 4190:
				x8e6813d1269b38e0 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj + 1);
				break;
			case 4350:
				x297c4b9799408e4a = (bool)obj;
				break;
			case 4380:
				xe68c5a6af2ad99fe = (bool)obj;
				break;
			case 4230:
				xa655e905c2c23d43 = (PreferredWidth)obj;
				if (x325f1926b78ae5cd)
				{
					xf68b6aed44939b9a++;
				}
				break;
			case 4010:
				xdb7d175cb29503bf = xd106566a5d9f6f46.x0e594440b71cd978((TableAlignment)obj);
				xe404f0479f85cd43++;
				xf68b6aed44939b9a++;
				break;
			case 4290:
				x5e90d05988677502 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xe404f0479f85cd43++;
				xf68b6aed44939b9a++;
				break;
			case 4340:
				x3ee36906f79c4fae = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xf68b6aed44939b9a++;
				break;
			case 4050:
				x6188bb17d3fa6122 = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4060:
				xcb0c5e0ca87ddd7c = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4070:
				xadf6945de3f17a6a = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4080:
				x120beac34b17159b = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4090:
				x6d77c656b879ca53 = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4100:
				x3aec10d81a685e0b = (Border)obj;
				xf68b6aed44939b9a++;
				break;
			case 4240:
				if (!isStyle)
				{
					x292ab95da92a6344 = obj;
					xf68b6aed44939b9a++;
				}
				break;
			case 4300:
				x60e3d97b97bb8c4b = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xf68b6aed44939b9a++;
				break;
			case 4020:
				xc790aa4ad151a9a1 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xf68b6aed44939b9a++;
				break;
			case 4310:
				xbec4ce2ebab55739 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xf68b6aed44939b9a++;
				break;
			case 4320:
				x9d14ae04d4852341 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xf68b6aed44939b9a++;
				break;
			case 4330:
				xbc9c2127d2bbf18f = (Shading)obj;
				xf68b6aed44939b9a++;
				break;
			case 4140:
				x79a6be1d1f13a42b = xca004f56614e2431.x7c1a0f9da8274fe8(x4cf3b47199c96529.x48bdf8f97244c548((TableStyleOptions)obj));
				xf68b6aed44939b9a++;
				break;
			case 4120:
				x36845bc9dc2cf9c6 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				xe404f0479f85cd43++;
				break;
			case 4110:
			{
				HeightRule heightRule = (HeightRule)obj;
				if (heightRule != 0)
				{
					x8663ce8a3c4af300 = xd106566a5d9f6f46.xe450fbc63c45b368(heightRule, x325f1926b78ae5cd);
					xe404f0479f85cd43++;
				}
				if (x325f1926b78ae5cd && heightRule == HeightRule.Auto && x36845bc9dc2cf9c6 == null)
				{
					x36845bc9dc2cf9c6 = "0";
				}
				break;
			}
			case 4040:
				if ((bool)obj)
				{
					x17caeb7723171c51 = (bool)obj;
					xe404f0479f85cd43++;
				}
				break;
			case 4360:
				if (!(bool)obj)
				{
					x59255fe095c130d7 = (bool)obj;
					xe404f0479f85cd43++;
				}
				break;
			case 4400:
				x95a824575f7410c3 = xc1b08afa36bf580c.x0d28bf60e577f9e5((int)obj);
				break;
			case 5000:
				xcef3e13053354501 = (string)obj;
				break;
			case 5010:
				x16ee896df46bcefa = (string)obj;
				break;
			case 4520:
				if (context.x325f1926b78ae5cd)
				{
					x96e55b5d052d1279 = true;
					xe404f0479f85cd43++;
				}
				break;
			case 5104:
				x71e5b802707a5021 = (int)obj;
				break;
			case 5105:
				x7390fcf53e1bd984 = (int)obj;
				break;
			case 4250:
				x90aab2cbd2f48623 = (int)obj;
				if (x90aab2cbd2f48623 > 0)
				{
					xe404f0479f85cd43++;
				}
				break;
			case 4260:
				xd29e69906712391d = (int)obj;
				if (xd29e69906712391d > 0)
				{
					xe404f0479f85cd43++;
				}
				break;
			}
		}
		if (!isStyle)
		{
			if (x292ab95da92a6344 == null)
			{
				x292ab95da92a6344 = tablePr.x292ab95da92a6344;
				xf68b6aed44939b9a++;
			}
			if ((bool)x292ab95da92a6344)
			{
				xf68b6aed44939b9a--;
			}
		}
	}
}
