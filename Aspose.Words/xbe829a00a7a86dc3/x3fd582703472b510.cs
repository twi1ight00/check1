using Aspose.Words;
using x0a300997a0b66409;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using xda075892eccab2ad;

namespace xbe829a00a7a86dc3;

internal class x3fd582703472b510
{
	private x3fd582703472b510()
	{
	}

	internal static void xf65c32ef4443c2c5(x4f037d20d40d8390 xbdfb620b7167944b, FootnoteType xd3526c7313d75391, x4c1e058c67948d6a xe9707cb1ec88db49, bool x28ee2f81ab05fedb)
	{
		bool flag = xd3526c7313d75391 == FootnoteType.Endnote;
		int num = (flag ? 100 : 0);
		object obj = xe9707cb1ec88db49.xf7866f89640a29a3(2500 + num);
		object obj2 = xe9707cb1ec88db49.xf7866f89640a29a3(2530 + num);
		object obj3 = xe9707cb1ec88db49.xf7866f89640a29a3(2520 + num);
		object obj4 = xe9707cb1ec88db49.xf7866f89640a29a3(2510 + num);
		if (obj != null || obj2 != null || obj3 != null || obj4 != null || x28ee2f81ab05fedb)
		{
			x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f(flag ? "w:endnotePr" : "w:footnotePr");
			if (obj != null)
			{
				xe1410f585439c7d.x547195bcc386fe66("w:pos", x93625b0e8808b0cc.x54b498efdd18d7e2((FootnoteLocation)obj, x5fbb1a9c98604ef5: false));
			}
			xe1410f585439c7d.x547195bcc386fe66("w:numFmt", x0beb84bbfae8adcf.x2e2d51c1b79b10ca(obj2));
			if (obj3 != null)
			{
				xe1410f585439c7d.x24f8794502b580ff("w:numStart", (int)obj3, 1);
			}
			if (obj4 != null)
			{
				xe1410f585439c7d.x547195bcc386fe66("w:numRestart", x93625b0e8808b0cc.xd0ad27372997d1d3((FootnoteNumberingRule)obj4, x5fbb1a9c98604ef5: false));
			}
			if (x28ee2f81ab05fedb)
			{
				xb1e23291670b6add(xbdfb620b7167944b, flag, flag ? x101cddc73c4f8cc2.x0affbe34bb1f8b8b : x101cddc73c4f8cc2.xa1e2a8ed32a026dd);
				xb1e23291670b6add(xbdfb620b7167944b, flag, (!flag) ? x101cddc73c4f8cc2.xeab6532eb0797a6e : x101cddc73c4f8cc2.x354a2c7b596483f1);
			}
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
	}

	private static void xb1e23291670b6add(x4f037d20d40d8390 xbdfb620b7167944b, bool x26f77e2004716cc6, x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		xa1e2a8ed32a026dd xa1e2a8ed32a026dd = xbdfb620b7167944b.x2c8c6741422a1298.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x781135a02d5b7a22);
		if (xa1e2a8ed32a026dd != null)
		{
			x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f(x26f77e2004716cc6 ? "w:endnote" : "w:footnote");
			xe1410f585439c7d.x25e28424582ee3ac("w:type", x0beb84bbfae8adcf.x5a3c6c08d15de7e4(x781135a02d5b7a22, x26f77e2004716cc6), "normal");
			xa1e2a8ed32a026dd.Accept(xbdfb620b7167944b);
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
	}
}
