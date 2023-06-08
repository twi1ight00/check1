using System.Drawing;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xe9fa6af9e1184312;

internal class x61655d0d58254c8b
{
	private x61655d0d58254c8b()
	{
	}

	internal static void x06b0e25aa6ad68a9(x95792ebebfd0979f x52608227a52a6472)
	{
		float x = 0f;
		float y = 0f;
		float width = 0f;
		float height = 0f;
		byte[] array = null;
		x54366fa5f75a02f7 x54366fa5f75a02f = null;
		string text = null;
		string xeaf1b27180c0557b = null;
		xab391c46ff9a0a38 xab391c46ff9a0a = null;
		x1fdc4491fb4c3ee8 x28fcdc775a1d069c = x52608227a52a6472.x28fcdc775a1d069c;
		while (x52608227a52a6472.x1ac1960adc8c4c39())
		{
			switch (x52608227a52a6472.xa66385d80d4d296f)
			{
			case "transform":
				x54366fa5f75a02f = xf7e2753b1f50fb2b.xb3da63d0517cf3c6(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "x":
				x = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "y":
				y = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "width":
				width = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "height":
				height = xf7e2753b1f50fb2b.xfd3c39adee96110c(x52608227a52a6472.xd2f68ee6f47e9dfb, x28fcdc775a1d069c);
				break;
			case "href":
				text = x52608227a52a6472.xd2f68ee6f47e9dfb;
				array = x28fcdc775a1d069c.x184a537960bc4865(text);
				break;
			case "id":
				xeaf1b27180c0557b = x52608227a52a6472.xd2f68ee6f47e9dfb;
				break;
			case "clip-path":
				xab391c46ff9a0a = x28fcdc775a1d069c.x9ab4402f4f72ff94(x52608227a52a6472.xd2f68ee6f47e9dfb) as xab391c46ff9a0a38;
				break;
			default:
				x28fcdc775a1d069c.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"Attribute '{x52608227a52a6472.xa66385d80d4d296f}' is unexpected and will be ignored");
				break;
			}
		}
		if (array == null)
		{
			x28fcdc775a1d069c.xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Cannot load image \"{text}\"");
			array = x0d299f323d241756.xcd6c2a9742c9220a();
		}
		x72c34b8dbaec3734 xde860fba55c41d = new x72c34b8dbaec3734(new PointF(x, y), new SizeF(width, height), array);
		if (x54366fa5f75a02f != null || xab391c46ff9a0a != null)
		{
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xb8e7e788f6d.x52dde376accdec7d = x54366fa5f75a02f;
			xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a;
			x28fcdc775a1d069c.x1fa9148f6731ff24(xb8e7e788f6d, xeaf1b27180c0557b);
			x28fcdc775a1d069c.xffdeeab52bfac6bd(xb8e7e788f6d);
			x28fcdc775a1d069c.x1fa9148f6731ff24(xde860fba55c41d, null);
			x28fcdc775a1d069c.xf5b0b9b6ff7ac462();
		}
		else
		{
			x28fcdc775a1d069c.x1fa9148f6731ff24(xde860fba55c41d, xeaf1b27180c0557b);
		}
	}
}
