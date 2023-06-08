using System;
using System.IO;
using System.Text;

namespace xb92b7270f78a4e8d;

internal class xf143ea72badff319
{
	private xf143ea72badff319()
	{
	}

	internal static x022e9ea87bd0a4c7 x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, int x7c935f6a9a4aa6b3, uint x6ef0051a50b36e36, int xe02396b111eb43e6)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[512];
		xcf18e5243f8d5fd3.Position = 76L;
		int count = Math.Min(x7c935f6a9a4aa6b3, 109) * 4;
		xcf18e5243f8d5fd3.Read(array, 0, count);
		memoryStream.Write(array, 0, count);
		uint xb933bead4255f31b = x6ef0051a50b36e36;
		for (int i = 0; i < xe02396b111eb43e6; i++)
		{
			xcf18e5243f8d5fd3.Position = x4952846e23c21e88.x29cc5da3d9d1b58a(xb933bead4255f31b, x0a996d99793b1739: true);
			xcf18e5243f8d5fd3.Read(array, 0, 512);
			int num = 508;
			memoryStream.Write(array, 0, num);
			xb933bead4255f31b = (uint)(array[num] | (array[num + 1] << 8) | (array[num + 2] << 16) | (array[num + 3] << 24));
		}
		return new x022e9ea87bd0a4c7(memoryStream);
	}

	internal static void x6210059f049f0d48(Stream xcf18e5243f8d5fd3, uint x6fef33b4fb431a18, int x7c935f6a9a4aa6b3, x1ea60bde2b5d0d28 x6b0ad9f73c48ad53)
	{
		uint num = x6fef33b4fb431a18;
		BinaryWriter binaryWriter = new BinaryWriter(xcf18e5243f8d5fd3, Encoding.Unicode);
		long position = xcf18e5243f8d5fd3.Position;
		xcf18e5243f8d5fd3.Position = 76L;
		int num2 = Math.Min(x7c935f6a9a4aa6b3, 109);
		for (int i = 0; i < num2; i++)
		{
			binaryWriter.Write(num);
			num++;
		}
		x4952846e23c21e88.xdd43f3d19173b660(binaryWriter);
		xcf18e5243f8d5fd3.Position = position;
		int num3 = x7c935f6a9a4aa6b3 - num2;
		if (num3 > 0)
		{
			x6b0ad9f73c48ad53.xa488c50953a4b64c = x4952846e23c21e88.x2ef840043f42e207(xcf18e5243f8d5fd3.Position, x0a996d99793b1739: true);
			x6b0ad9f73c48ad53.xed20a3f26053569b = 0;
			while (num3 > 0)
			{
				int num4 = Math.Min(num3, 127);
				for (int j = 0; j < num4; j++)
				{
					binaryWriter.Write(num);
					num++;
				}
				x4952846e23c21e88.xdd43f3d19173b660(binaryWriter);
				num3 -= num4;
				x6b0ad9f73c48ad53.xed20a3f26053569b++;
				xcf18e5243f8d5fd3.Position -= 4L;
				if (num3 > 0)
				{
					uint value = x4952846e23c21e88.x2ef840043f42e207(xcf18e5243f8d5fd3.Position, x0a996d99793b1739: true) + 1;
					binaryWriter.Write(value);
				}
				else
				{
					binaryWriter.Write(4294967294u);
				}
			}
		}
		else
		{
			x6b0ad9f73c48ad53.xa488c50953a4b64c = 4294967294u;
			x6b0ad9f73c48ad53.xed20a3f26053569b = 0;
		}
	}
}
