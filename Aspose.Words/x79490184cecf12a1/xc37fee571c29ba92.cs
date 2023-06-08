using System.Collections;
using Aspose.Words.Fonts;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x8b1f7613579e78d0;
using x8bb6b4f09b5230a5;
using x95bd05bb616368d3;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;
using xa769c310fbec8a5a;
using xc76255e87e5986c6;
using xda075892eccab2ad;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class xc37fee571c29ba92 : xaaf059f0543cf507
{
	internal xc37fee571c29ba92()
		: base(new x28b4ef62913b051b())
	{
	}

	internal void x06b0e25aa6ad68a9(xa52ef41af20225f0 xe134235b3526fa75)
	{
		((x28b4ef62913b051b)base.xca687bd498227c89).xf69ca7a9bb4a4a51 = new x7c8328a75e9baa2d(xe134235b3526fa75.x1e4394fcb6d34948.WarningCallback);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe134235b3526fa75.x4bfdbcbc6a51d705(xe134235b3526fa75.x2a0bb2f6650f6a43, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");
		if (xa2f1c3dcbd86f20a == null)
		{
			return;
		}
		x3dabda6865ed239d x3dabda6865ed239d = new x3dabda6865ed239d();
		xe134235b3526fa75.x2c8c6741422a1298.x18ee99b6e1fced19(x3dabda6865ed239d);
		x3dabda6865ed239d.xfafa4c90da1436a5 = xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xfafa4c90da1436a5;
		x3dabda6865ed239d.x4b27d9fdab2746ba = xa2f1c3dcbd86f20a;
		foreach (x5b6f1954712b741f item in (IEnumerable)xa2f1c3dcbd86f20a.xadb7000bed559a9a)
		{
			if (!item.x0552da4f5c09bde5)
			{
				xa2f1c3dcbd86f20a value = xe134235b3526fa75.xd4e2719ccf56f4d7(xa2f1c3dcbd86f20a.xa687196d807ab9c0(item));
				x3dabda6865ed239d.x8c7d2c74298d462f[item.xea1e81378298fa81] = value;
			}
		}
		x4c28ef76f151d171(new x3c85359e1389ad43(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe));
		x3dabda6865ed239d.x759aa16c2016a289 = x7450cc1e48712286.xd68abcd61e368af9("name", "");
		while (x7450cc1e48712286.x152cbadbfa8061b1("theme"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "themeElements":
				xd4c5b858945b0ab2(x3dabda6865ed239d);
				break;
			case "custClrLst":
			case "extLst":
			case "extraClrSchemeLst":
			case "objectDefaults":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xd4c5b858945b0ab2(x3dabda6865ed239d x8ad4cdceb54e447f)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("themeElements"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "fontScheme":
				x902b6f807c71becd(x8ad4cdceb54e447f);
				break;
			case "clrScheme":
				x361b184c535e0a4d(x8ad4cdceb54e447f);
				break;
			case "fmtScheme":
				xca573c6bbd9ec6aa(x8ad4cdceb54e447f);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xca573c6bbd9ec6aa(x3dabda6865ed239d x8ad4cdceb54e447f)
	{
		x8ad4cdceb54e447f.x2053f56a9aea777a.x759aa16c2016a289 = x7450cc1e48712286.xd68abcd61e368af9("name", string.Empty);
		xcac04f3919526f00 x7f3072284cb54fd = new x53230d9c3453c662(base.xca687bd498227c89);
		xef3538cc44802939 x0ead821b5a5e = new xf97638a04f95de0d(base.xca687bd498227c89);
		while (x7450cc1e48712286.x152cbadbfa8061b1("fmtScheme"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "bgFillStyleLst":
				xe5eefcd89f02dd0f(x8ad4cdceb54e447f.x2053f56a9aea777a, x7f3072284cb54fd);
				break;
			case "fillStyleLst":
				xe069eac2c47b8047(x8ad4cdceb54e447f.x2053f56a9aea777a, x7f3072284cb54fd);
				break;
			case "lnStyleLst":
				x0050a2c20f09c84d(x8ad4cdceb54e447f.x2053f56a9aea777a, x0ead821b5a5e);
				break;
			case "effectStyleLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xe5eefcd89f02dd0f(x2053f56a9aea777a x6386e53f239472b6, xcac04f3919526f00 x7f3072284cb54fd8)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("bgFillStyleLst"))
		{
			x48d7478d49393961 x48d7478d = x7f3072284cb54fd8.xda09af88ab899a50(x7450cc1e48712286);
			if (x48d7478d != null)
			{
				x6386e53f239472b6.x2c141991a183f50a(x48d7478d);
			}
		}
	}

	private void xe069eac2c47b8047(x2053f56a9aea777a x6386e53f239472b6, xcac04f3919526f00 x7f3072284cb54fd8)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("fillStyleLst"))
		{
			x48d7478d49393961 x48d7478d = x7f3072284cb54fd8.xda09af88ab899a50(x7450cc1e48712286);
			if (x48d7478d != null)
			{
				x6386e53f239472b6.x98901042681367ec(x48d7478d);
			}
		}
	}

	private void x0050a2c20f09c84d(x2053f56a9aea777a x6386e53f239472b6, xef3538cc44802939 x0ead821b5a5e8308)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("lnStyleLst"))
		{
			x064e11d707aed84f x064e11d707aed84f = x0ead821b5a5e8308.xda09af88ab899a50(x7450cc1e48712286);
			if (x064e11d707aed84f != null)
			{
				x6386e53f239472b6.x15311d0220014649(x064e11d707aed84f);
			}
		}
	}

	private void x361b184c535e0a4d(x3dabda6865ed239d x8ad4cdceb54e447f)
	{
		x8ad4cdceb54e447f.x4f15c2ab6fab0941.x759aa16c2016a289 = x7450cc1e48712286.xd68abcd61e368af9("name", string.Empty);
		xaeaeae8d38ef57bb x18cd81b33266e0a = new xd13db1e4c9fb8129(base.xca687bd498227c89);
		while (x7450cc1e48712286.x152cbadbfa8061b1("clrScheme"))
		{
			xd7e8497b32a408b8 xd7e8497b32a408b = null;
			string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "accent1":
			case "accent2":
			case "accent3":
			case "accent4":
			case "accent5":
			case "accent6":
			case "dk1":
			case "dk2":
			case "folHlink":
			case "hlink":
			case "lt1":
			case "lt2":
				xd7e8497b32a408b = xd59d3df9a41d92b1(x18cd81b33266e0a);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
			if (xd7e8497b32a408b != null)
			{
				x8ad4cdceb54e447f.x4f15c2ab6fab0941.xd48bda2de519c530(xd7e8497b32a408b, x9d4a08280e770f8e.xb0c325557cbfd6d3(xa66385d80d4d296f));
			}
		}
	}

	private xd7e8497b32a408b8 xd59d3df9a41d92b1(xaeaeae8d38ef57bb x18cd81b33266e0a1)
	{
		if (!x7450cc1e48712286.x152cbadbfa8061b1(x7450cc1e48712286.xa66385d80d4d296f))
		{
			return null;
		}
		return x18cd81b33266e0a1.xda09af88ab899a50(x7450cc1e48712286);
	}

	private void x902b6f807c71becd(x3dabda6865ed239d x8ad4cdceb54e447f)
	{
		x8ad4cdceb54e447f.xcab9f0a54d8bcea6 = x7450cc1e48712286.xd68abcd61e368af9("name", "");
		while (x7450cc1e48712286.x152cbadbfa8061b1("fontScheme"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "majorFont":
				x8ad4cdceb54e447f.x612ef856b9d29ffd = x2506b757d67702ec();
				break;
			case "minorFont":
				x8ad4cdceb54e447f.x7dd80080464c013f = x2506b757d67702ec();
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private x87415330d9d0754a x2506b757d67702ec()
	{
		x87415330d9d0754a x87415330d9d0754a = new x87415330d9d0754a();
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "cs":
				x87415330d9d0754a.xd4e922ceeed89b74 = xdafccb198ba91439();
				break;
			case "ea":
				x87415330d9d0754a.xad8ea6954e370567 = xdafccb198ba91439();
				break;
			case "font":
				xffd32b08d5608778(x87415330d9d0754a);
				break;
			case "latin":
				x87415330d9d0754a.x94edc0d9bd2a8401 = xdafccb198ba91439();
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x87415330d9d0754a;
	}

	private FontInfo xdafccb198ba91439()
	{
		FontInfo fontInfo = new FontInfo();
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "charset":
				fontInfo.Charset = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "panose":
				fontInfo.Panose = new byte[10];
				xc1b08afa36bf580c.xa9aaee2edd3cd025(x7450cc1e48712286.xd2f68ee6f47e9dfb, fontInfo.Panose, 0);
				break;
			case "pitchFamily":
				fontInfo.Pitch = (FontPitch)x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "typeface":
				fontInfo.x54f99ef1e934e59c(x7450cc1e48712286.xd2f68ee6f47e9dfb);
				break;
			}
		}
		return fontInfo;
	}

	private void xffd32b08d5608778(x87415330d9d0754a x88712fc10ab26a40)
	{
		string text = null;
		string typeface = null;
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "script":
				text = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "typeface":
				typeface = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x080b836c5a387d2e x080b836c5a387d2e = new x080b836c5a387d2e(text, typeface);
			x88712fc10ab26a40.xaebadb979a354f46[x080b836c5a387d2e.x838b2dfd1391264c] = x080b836c5a387d2e;
		}
	}
}
