using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class xe94ea7ebbcdea7d1
{
	internal static x26d9ecb4bdf0456d x71b38f10fe7e82a7(x26d9ecb4bdf0456d x154083d58301ef75, x26d9ecb4bdf0456d x93532ca0ace0c1ae)
	{
		if (x154083d58301ef75.xda71bf6f7c07c3bc == 239)
		{
			int xc613adc4330033f = x154083d58301ef75.xc613adc4330033f3;
			if (xc613adc4330033f == 240)
			{
				switch (x154083d58301ef75.x26463655896fd90a)
				{
				case 1:
				{
					double num2 = x154083d58301ef75.x8e8f6cc6a0756b05;
					num2 = (255.0 - num2) / 255.0;
					x01f74f175f4a1d3d x01f74f175f4a1d3d2 = new x01f74f175f4a1d3d(x93532ca0ace0c1ae);
					x01f74f175f4a1d3d2.x7140fff2ddcc94a1 -= x01f74f175f4a1d3d2.x7140fff2ddcc94a1 * num2;
					x154083d58301ef75 = x01f74f175f4a1d3d2.x1659cb35054965d4();
					break;
				}
				case 2:
				{
					double num = x154083d58301ef75.x8e8f6cc6a0756b05;
					num = (255.0 - num) / 255.0;
					x01f74f175f4a1d3d x01f74f175f4a1d3d = new x01f74f175f4a1d3d(x93532ca0ace0c1ae);
					x01f74f175f4a1d3d.x7140fff2ddcc94a1 += (1.0 - x01f74f175f4a1d3d.x7140fff2ddcc94a1) * num;
					x154083d58301ef75 = x01f74f175f4a1d3d.x1659cb35054965d4();
					break;
				}
				default:
					x154083d58301ef75 = x93532ca0ace0c1ae;
					break;
				}
			}
		}
		return x154083d58301ef75;
	}
}
