using System;
using System.Text.RegularExpressions;
using Aspose.Words;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xe9fa6af9e1184312;

internal class xf7e2753b1f50fb2b
{
	private const int xf6875e0ab2f8d3b5 = 1;

	private const int xb8c83ada7a429f35 = 2;

	private const int x51175354bb9fb297 = 1;

	private const int x6b5b41480eeda74a = 3;

	private static readonly Regex x4478fc9addb766c6 = new Regex("(matrix|translate|scale|rotate|skewX|skewY)\\(([^\\(\\)]+)\\)", RegexOptions.Compiled);

	private static readonly Regex x8da49c1695f39073 = new Regex("-?\\d+(\\.\\d+)?", RegexOptions.Compiled);

	private static readonly Regex xf0fcb7b937f0d521 = new Regex("(-?\\d+(\\.\\d+)?)(em|ex|px|in|cm|mm|pt|pc|%)?", RegexOptions.Compiled);

	private xf7e2753b1f50fb2b()
	{
	}

	internal static x54366fa5f75a02f7 xb3da63d0517cf3c6(string xbcea506a33cf9111, x1fdc4491fb4c3ee8 x0f7b23d1c393aed9)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		MatchCollection matchCollection = x4478fc9addb766c6.Matches(xbcea506a33cf9111);
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[1].Value;
			float[] array = x18509d4eed26e020(item.Groups[2].Value);
			switch (value)
			{
			case "matrix":
				x54366fa5f75a02f.x490e30087768649f(new x54366fa5f75a02f7(array[0], array[1], array[2], array[3], array[4], array[5]));
				break;
			case "translate":
				x54366fa5f75a02f.xce92de628aa023cf(array[0], (array.Length > 1) ? array[1] : 0f);
				break;
			case "scale":
				x54366fa5f75a02f.x5152a5707921c783(array[0], (array.Length > 1) ? array[1] : array[0]);
				break;
			case "rotate":
				if (array.Length == 1)
				{
					x54366fa5f75a02f.xa77087bb05d9ef76(array[0]);
				}
				else if (array.Length == 3)
				{
					x54366fa5f75a02f.xce92de628aa023cf(array[1], array[2]);
					x54366fa5f75a02f.xa77087bb05d9ef76(array[0]);
					x54366fa5f75a02f.xce92de628aa023cf(0f - array[1], 0f - array[2]);
				}
				break;
			case "skewX":
				x54366fa5f75a02f.x490e30087768649f(new x54366fa5f75a02f7(1f, 0f, (float)Math.Tan(x15e971129fd80714.xcdc7b29a812dd7df(array[0])), 1f, 0f, 0f));
				break;
			case "skewY":
				x54366fa5f75a02f.x490e30087768649f(new x54366fa5f75a02f7(1f, (float)Math.Tan(x15e971129fd80714.xcdc7b29a812dd7df(array[0])), 0f, 1f, 0f, 0f));
				break;
			default:
				x0f7b23d1c393aed9.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"'{value}' is unexpected matrix command and will be ignored");
				break;
			}
		}
		return x54366fa5f75a02f;
	}

	internal static float[] x18509d4eed26e020(string x9d5750eb2d6373bc)
	{
		MatchCollection matchCollection = x8da49c1695f39073.Matches(x9d5750eb2d6373bc);
		float[] array = new float[matchCollection.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (float)xca004f56614e2431.xec25d08a2af152f0(matchCollection[i].Value);
		}
		return array;
	}

	internal static float xfd3c39adee96110c(string x41a4ba6d899b7c75, x1fdc4491fb4c3ee8 x0f7b23d1c393aed9)
	{
		if (x41a4ba6d899b7c75 == null)
		{
			return 0f;
		}
		Match match = xf0fcb7b937f0d521.Match(x41a4ba6d899b7c75);
		if (!match.Success)
		{
			return 0f;
		}
		double num = xca004f56614e2431.xf5ece46c5d72e3b9(match.Groups[1].Value);
		string value = match.Groups[3].Value;
		if (double.IsNaN(num))
		{
			num = 0.0;
		}
		switch (value)
		{
		case "in":
			num = x4574ea26106f0edb.xb0e438d6d798d50b(num);
			break;
		case "cm":
			num = x4574ea26106f0edb.x2dec7440ed5bb457(num * 10.0);
			break;
		case "mm":
			num = x4574ea26106f0edb.x2dec7440ed5bb457(num);
			break;
		case "pt":
			num = x4574ea26106f0edb.x1f1488a9109eace7(num);
			break;
		case "pc":
			num = x4574ea26106f0edb.x1f1488a9109eace7(num * 12.0);
			break;
		case "em":
		case "ex":
			x0f7b23d1c393aed9?.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Relative length units are not supported upon reading SVG.");
			break;
		case "%":
			x0f7b23d1c393aed9?.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, "Percentage length is not supported upon reading SVG.");
			break;
		}
		return (float)num;
	}

	internal static x9189d7a3c7720a79 x1308f09f2a749a06(string x9e89cc6e6284edf4)
	{
		return x9e89cc6e6284edf4 switch
		{
			"font" => x9189d7a3c7720a79.xc2d4efc42998d87b, 
			"font-family" => x9189d7a3c7720a79.x097db4a59326bcb1, 
			"font-size" => x9189d7a3c7720a79.x70c328f6f2e77d76, 
			"font-size-adjust" => x9189d7a3c7720a79.xc2d4efc42998d87b, 
			"font-stretch" => x9189d7a3c7720a79.x4085f5c80256c978, 
			"font-style" => x9189d7a3c7720a79.xfa47517dba72fd20, 
			"font-variant" => x9189d7a3c7720a79.x75fcbe9ccf3f3f7b, 
			"font-weight" => x9189d7a3c7720a79.xc94c0a5afee41a0c, 
			"direction" => x9189d7a3c7720a79.xdbfa333b4cd503e0, 
			"letter-spacing" => x9189d7a3c7720a79.xddb2b524659a1c73, 
			"text-decoration" => x9189d7a3c7720a79.xf7851b7866425dca, 
			"unicode-bidi" => x9189d7a3c7720a79.x3b42e30ac7581a31, 
			"word-spacing" => x9189d7a3c7720a79.x7ef8ce87303a2100, 
			"clip" => x9189d7a3c7720a79.x0e1bf8242ad10272, 
			"color" => x9189d7a3c7720a79.x9b41425268471380, 
			"cursor" => x9189d7a3c7720a79.x2f05ec1decb4f496, 
			"display" => x9189d7a3c7720a79.x2c6cfc461f9dd5e2, 
			"overflow" => x9189d7a3c7720a79.x2ee548a6adbe2c27, 
			"visibility" => x9189d7a3c7720a79.x27a8d08d15edb975, 
			"clip-path" => x9189d7a3c7720a79.x385638247aa8a54b, 
			"clip-rule" => x9189d7a3c7720a79.x37781fd7fe5c8163, 
			"mask" => x9189d7a3c7720a79.x2c8724332a4788a6, 
			"opacity" => x9189d7a3c7720a79.xd163a712710650fc, 
			"enable-background" => x9189d7a3c7720a79.x7edf34a3d4af5c79, 
			"filter" => x9189d7a3c7720a79.xcd5d15a1f9661947, 
			"flood-color" => x9189d7a3c7720a79.xfd34a70ab3af6328, 
			"flood-opacity" => x9189d7a3c7720a79.xd57e4fef464dca4b, 
			"lighting-color" => x9189d7a3c7720a79.x9d61b2338d71da2e, 
			"stop-color" => x9189d7a3c7720a79.xeafcd1c90c663fcd, 
			"stop-opacity" => x9189d7a3c7720a79.x37e129dd9bfcc331, 
			"pointer-events" => x9189d7a3c7720a79.x1e629b085addb92d, 
			"color-interpolation" => x9189d7a3c7720a79.xc7f3b010045f3c16, 
			"color-interpolation-filters" => x9189d7a3c7720a79.x4333faf93cd14dda, 
			"color-profile" => x9189d7a3c7720a79.xe0ced1196df92679, 
			"color-rendering" => x9189d7a3c7720a79.xcdb99adc7a36639c, 
			"fill" => x9189d7a3c7720a79.x6a81a30bcaf20a97, 
			"fill-opacity" => x9189d7a3c7720a79.x398d39e7bcc2ca22, 
			"fill-rule" => x9189d7a3c7720a79.xc0f47c9cc53456af, 
			"image-rendering" => x9189d7a3c7720a79.x9d4e3a1d1773d361, 
			"marker" => x9189d7a3c7720a79.x94e4690631260a6c, 
			"marker-end" => x9189d7a3c7720a79.x4d1185bee629d8db, 
			"marker-mid" => x9189d7a3c7720a79.xe034ceca04a79c93, 
			"marker-start" => x9189d7a3c7720a79.xea5391e1154f335c, 
			"shape-rendering" => x9189d7a3c7720a79.xdefc7cc0e8b6959a, 
			"stroke" => x9189d7a3c7720a79.x0e397c84d3b79406, 
			"stroke-dasharray" => x9189d7a3c7720a79.x272458cc3d0685a3, 
			"stroke-dashoffset" => x9189d7a3c7720a79.xb875057f3a460017, 
			"stroke-linecap" => x9189d7a3c7720a79.x9e5d3debe020631d, 
			"stroke-linejoin" => x9189d7a3c7720a79.x4c16f908723e263d, 
			"stroke-miterlimit" => x9189d7a3c7720a79.x270281ebfbfb6da9, 
			"stroke-opacity" => x9189d7a3c7720a79.xaeddb2c9d22e1e9b, 
			"stroke-width" => x9189d7a3c7720a79.x302cb8ba350a61da, 
			"text-rendering" => x9189d7a3c7720a79.x4ae1d99feb90ba8b, 
			"alignment-baseline" => x9189d7a3c7720a79.x2371839a3eda57b7, 
			"baseline-shift" => x9189d7a3c7720a79.xf0e52e7a2cede3de, 
			"dominant-baseline" => x9189d7a3c7720a79.x756f48529c55543d, 
			"glyph-orientation-horizontal" => x9189d7a3c7720a79.x4028f54d35357ef4, 
			"glyph-orientation-vertical" => x9189d7a3c7720a79.x7372f0e77c5f3454, 
			"kerning" => x9189d7a3c7720a79.x5d307c4bc30bdc4b, 
			"text-anchor" => x9189d7a3c7720a79.xc9c2f7ed072cf9bf, 
			"writing-mode" => x9189d7a3c7720a79.x28e5011224ac892b, 
			_ => x9189d7a3c7720a79.xf6c17f648b65c793, 
		};
	}
}
