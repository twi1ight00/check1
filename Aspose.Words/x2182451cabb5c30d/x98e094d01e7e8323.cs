using System.Text.RegularExpressions;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a62aaf14e3c5909;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class x98e094d01e7e8323 : x77fb5b1d5c73757b
{
	private static readonly char[] xc8631722a06390e3 = new char[2] { '(', ')' };

	private readonly ShapeBase x317be79405176667;

	private string x38385f1e5a2e9b38;

	private string xb028d7caf00bc546;

	private bool x131fd6d4f5493c89;

	private bool xb3cb903c09e41fe8;

	private int xac6bde3fd314beb5;

	private int x3852bb6ca7ddc465;

	private int xa60f044a428a210d;

	private int xe125879721b4f24b;

	private int xd5ee62329c90d234;

	private int xb9ff5f240866a3ad;

	private int x92ae72a61c6f4a39;

	private int x8170bb6f7d06f761;

	private int x75c525cfe6e341ed;

	private string x6804183603e2e345;

	private bool xdce75473dc96eeb0;

	private static readonly Regex x582a063c786b0d3c = new Regex("\\d+;\\d+;(\\w+)");

	internal int x322b9608237bbe85 => xac6bde3fd314beb5;

	internal int x9ffbaf9f6bbd17a6 => xa60f044a428a210d;

	internal int x638f80cf1be349b4 => x3852bb6ca7ddc465 - xac6bde3fd314beb5;

	internal int xef90ff597efa30e4 => xe125879721b4f24b - xa60f044a428a210d;

	internal int x0654b5354ff47810 => xd5ee62329c90d234;

	internal int x8d139c8691518897 => x92ae72a61c6f4a39;

	internal int x91e9d99c90d99869 => xb9ff5f240866a3ad - xd5ee62329c90d234;

	internal int x4143970b8a1ffb81 => x8170bb6f7d06f761 - x92ae72a61c6f4a39;

	internal bool x3ad5ef377b8a9d01 => x75c525cfe6e341ed != 0;

	internal string x1cdb46ecf83a213d => x6804183603e2e345;

	internal bool xac9731dd322f2036 => xdce75473dc96eeb0;

	private xf7125312c7ee115c xf7125312c7ee115c => x317be79405176667.xf7125312c7ee115c;

	internal x98e094d01e7e8323(xe5e546ef5f0503b2 context, ShapeBase shape)
		: base(context)
	{
		x317be79405176667 = shape;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.x8fa87c02bfc6a890();
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xe16353313317d8a8)
		{
			return;
		}
		switch (x38385f1e5a2e9b38)
		{
		case "shapetype":
			if (!x317be79405176667.xa170cce2bc40bdf5 && !x317be79405176667.IsGroup)
			{
				x317be79405176667.x88d1b78392d1a0ab((ShapeType)x95ea7d23cc8ee04d());
			}
			break;
		case "borderleftcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(924, x07d1b52af8293592());
			break;
		case "borderrightcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(926, x07d1b52af8293592());
			break;
		case "bordertopcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(923, x07d1b52af8293592());
			break;
		case "borderbottomcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(925, x07d1b52af8293592());
			break;
		case "posrelh":
			xf7125312c7ee115c.xae20093bed1e48a8(912, (RelativeHorizontalPosition)x95ea7d23cc8ee04d());
			break;
		case "posrelv":
			xf7125312c7ee115c.xae20093bed1e48a8(914, (RelativeVerticalPosition)x95ea7d23cc8ee04d());
			break;
		case "posh":
			xf7125312c7ee115c.xae20093bed1e48a8(911, (HorizontalAlignment)x95ea7d23cc8ee04d());
			break;
		case "posv":
			xf7125312c7ee115c.xae20093bed1e48a8(913, (VerticalAlignment)x95ea7d23cc8ee04d());
			break;
		case "fallowoverlap":
			xf7125312c7ee115c.xae20093bed1e48a8(950, xbf06959672bf5f5b());
			break;
		case "pcthoriz":
			xf7125312c7ee115c.xae20093bed1e48a8(1984, x95ea7d23cc8ee04d());
			break;
		case "pctvert":
			xf7125312c7ee115c.xae20093bed1e48a8(1985, x95ea7d23cc8ee04d());
			break;
		case "pcthorizpos":
			xf7125312c7ee115c.xae20093bed1e48a8(1986, x95ea7d23cc8ee04d());
			break;
		case "pctvertpos":
			xf7125312c7ee115c.xae20093bed1e48a8(1987, x95ea7d23cc8ee04d());
			break;
		case "sizerelh":
			xf7125312c7ee115c.xae20093bed1e48a8(1988, (x8307b3d797c38a81)x95ea7d23cc8ee04d());
			break;
		case "sizerelv":
			xf7125312c7ee115c.xae20093bed1e48a8(1989, (xc51d0ca9388f31bd)x95ea7d23cc8ee04d());
			break;
		case "fisbullet":
		{
			bool flag = xbf06959672bf5f5b();
			if (x28fcdc775a1d069c.xb778e4a87af27d7a && flag)
			{
				xf7125312c7ee115c.xae20093bed1e48a8(945, flag);
			}
			break;
		}
		case "rotation":
			xf7125312c7ee115c.xae20093bed1e48a8(4, x95ea7d23cc8ee04d());
			break;
		case "ffliph":
		case "frelfliph":
			x131fd6d4f5493c89 = xbf06959672bf5f5b();
			break;
		case "fflipv":
		case "frelflipv":
			xb3cb903c09e41fe8 = xbf06959672bf5f5b();
			break;
		case "wzname":
			xf7125312c7ee115c.xae20093bed1e48a8(896, xb028d7caf00bc546);
			break;
		case "wzdescription":
			xf7125312c7ee115c.xae20093bed1e48a8(897, xb028d7caf00bc546);
			break;
		case "dxwrapdistleft":
			xf7125312c7ee115c.xae20093bed1e48a8(900, x95ea7d23cc8ee04d());
			break;
		case "dxwrapdistright":
			xf7125312c7ee115c.xae20093bed1e48a8(902, x95ea7d23cc8ee04d());
			break;
		case "dywrapdisttop":
			xf7125312c7ee115c.xae20093bed1e48a8(901, x95ea7d23cc8ee04d());
			break;
		case "dywrapdistbottom":
			xf7125312c7ee115c.xae20093bed1e48a8(903, x95ea7d23cc8ee04d());
			break;
		case "fbehinddocument":
			xf7125312c7ee115c.xae20093bed1e48a8(954, xbf06959672bf5f5b());
			break;
		case "fisbutton":
			xf7125312c7ee115c.xae20093bed1e48a8(956, xbf06959672bf5f5b());
			break;
		case "fhidden":
			xf7125312c7ee115c.xae20093bed1e48a8(958, xbf06959672bf5f5b());
			break;
		case "farrowheadsok":
			xf7125312c7ee115c.xae20093bed1e48a8(507, xbf06959672bf5f5b());
			break;
		case "fdeleteattachedobject":
			xf7125312c7ee115c.xae20093bed1e48a8(830, xbf06959672bf5f5b());
			break;
		case "feditedwrap":
			xf7125312c7ee115c.xae20093bed1e48a8(953, xbf06959672bf5f5b());
			break;
		case "fhittestfill":
			xf7125312c7ee115c.xae20093bed1e48a8(444, xbf06959672bf5f5b());
			break;
		case "fhittestline":
			xf7125312c7ee115c.xae20093bed1e48a8(509, xbf06959672bf5f5b());
			break;
		case "fnofillhittest":
			xf7125312c7ee115c.xae20093bed1e48a8(447, xbf06959672bf5f5b());
			break;
		case "fnolinedrawdash":
			xf7125312c7ee115c.xae20093bed1e48a8(511, xbf06959672bf5f5b());
			break;
		case "foleicon":
			xf7125312c7ee115c.xae20093bed1e48a8(826, xbf06959672bf5f5b());
			break;
		case "fondblclicknotify":
			xf7125312c7ee115c.xae20093bed1e48a8(955, xbf06959672bf5f5b());
			break;
		case "foned":
			xf7125312c7ee115c.xae20093bed1e48a8(957, xbf06959672bf5f5b());
			break;
		case "fpreferrelativeresize":
			xf7125312c7ee115c.xae20093bed1e48a8(827, xbf06959672bf5f5b());
			break;
		case "fprint":
			xf7125312c7ee115c.xae20093bed1e48a8(959, xbf06959672bf5f5b());
			break;
		case "hspnext":
			xf7125312c7ee115c.xae20093bed1e48a8(138, x95ea7d23cc8ee04d());
			break;
		case "fscriptanchor":
			xf7125312c7ee115c.xae20093bed1e48a8(952, xbf06959672bf5f5b());
			break;
		case "wzscript":
			xf7125312c7ee115c.xae20093bed1e48a8(910, xb028d7caf00bc546);
			break;
		case "wzscriptextattr":
			xf7125312c7ee115c.xae20093bed1e48a8(919, xb028d7caf00bc546);
			break;
		case "scriptlang":
			xf7125312c7ee115c.xae20093bed1e48a8(920, x95ea7d23cc8ee04d());
			break;
		case "wzscriptlangattr":
			xf7125312c7ee115c.xae20093bed1e48a8(922, xb028d7caf00bc546);
			break;
		case "flockrotation":
			xf7125312c7ee115c.xae20093bed1e48a8(119, xbf06959672bf5f5b());
			break;
		case "flockposition":
			xf7125312c7ee115c.xae20093bed1e48a8(121, xbf06959672bf5f5b());
			break;
		case "flockaspectratio":
			xf7125312c7ee115c.xae20093bed1e48a8(120, xbf06959672bf5f5b());
			break;
		case "flockagainstselect":
			xf7125312c7ee115c.xae20093bed1e48a8(122, xbf06959672bf5f5b());
			break;
		case "flockcropping":
			xf7125312c7ee115c.xae20093bed1e48a8(123, xbf06959672bf5f5b());
			break;
		case "flockverticies":
			xf7125312c7ee115c.xae20093bed1e48a8(124, xbf06959672bf5f5b());
			break;
		case "flocktext":
			xf7125312c7ee115c.xae20093bed1e48a8(125, xbf06959672bf5f5b());
			break;
		case "flockadjusthandles":
			xf7125312c7ee115c.xae20093bed1e48a8(126, xbf06959672bf5f5b());
			break;
		case "flockagainstgrouping":
			xf7125312c7ee115c.xae20093bed1e48a8(127, xbf06959672bf5f5b());
			break;
		case "flockshapetype":
			xf7125312c7ee115c.xae20093bed1e48a8(828, xbf06959672bf5f5b());
			break;
		case "dxtextleft":
			xf7125312c7ee115c.xae20093bed1e48a8(129, x95ea7d23cc8ee04d());
			break;
		case "dxtextright":
			xf7125312c7ee115c.xae20093bed1e48a8(131, x95ea7d23cc8ee04d());
			break;
		case "dytexttop":
			xf7125312c7ee115c.xae20093bed1e48a8(130, x95ea7d23cc8ee04d());
			break;
		case "dytextbottom":
			xf7125312c7ee115c.xae20093bed1e48a8(132, x95ea7d23cc8ee04d());
			break;
		case "wraptext":
			xf7125312c7ee115c.xae20093bed1e48a8(133, (TextBoxWrapMode)x95ea7d23cc8ee04d());
			break;
		case "anchortext":
			xf7125312c7ee115c.xae20093bed1e48a8(135, (x69aaa2975337eae6)x95ea7d23cc8ee04d());
			break;
		case "txfltextflow":
			xf7125312c7ee115c.xae20093bed1e48a8(136, (LayoutFlow)x95ea7d23cc8ee04d());
			break;
		case "cdirfont":
			xf7125312c7ee115c.xae20093bed1e48a8(137, (x05e2bbe26ab31299)x95ea7d23cc8ee04d());
			break;
		case "fautotextmargin":
			xf7125312c7ee115c.xae20093bed1e48a8(188, xbf06959672bf5f5b());
			break;
		case "scaletext":
			xf7125312c7ee115c.xae20093bed1e48a8(134, x95ea7d23cc8ee04d());
			break;
		case "ltxid":
			xf7125312c7ee115c.xae20093bed1e48a8(128, x95ea7d23cc8ee04d());
			break;
		case "frotatetext":
			xf7125312c7ee115c.xae20093bed1e48a8(189, xbf06959672bf5f5b());
			break;
		case "fselecttext":
			xf7125312c7ee115c.xae20093bed1e48a8(187, xbf06959672bf5f5b());
			break;
		case "ffitshapetotext":
			xf7125312c7ee115c.xae20093bed1e48a8(190, xbf06959672bf5f5b());
			break;
		case "ffittexttoshape":
			xf7125312c7ee115c.xae20093bed1e48a8(191, xbf06959672bf5f5b());
			break;
		case "gtextunicode":
			xf7125312c7ee115c.xae20093bed1e48a8(192, xb028d7caf00bc546);
			break;
		case "gtextsize":
			xf7125312c7ee115c.xae20093bed1e48a8(195, x95ea7d23cc8ee04d());
			break;
		case "gtextspacing":
			xf7125312c7ee115c.xae20093bed1e48a8(196, x95ea7d23cc8ee04d());
			break;
		case "gtextfont":
			xf7125312c7ee115c.xae20093bed1e48a8(197, xb028d7caf00bc546);
			break;
		case "fgtext":
			xf7125312c7ee115c.xae20093bed1e48a8(241, xbf06959672bf5f5b());
			break;
		case "gtextfvertical":
			xf7125312c7ee115c.xae20093bed1e48a8(242, xbf06959672bf5f5b());
			break;
		case "gtextfkern":
			xf7125312c7ee115c.xae20093bed1e48a8(243, xbf06959672bf5f5b());
			break;
		case "gtextftight":
			xf7125312c7ee115c.xae20093bed1e48a8(244, xbf06959672bf5f5b());
			break;
		case "gtextfstretch":
			xf7125312c7ee115c.xae20093bed1e48a8(245, xbf06959672bf5f5b());
			break;
		case "gtextfshrinkfit":
			xf7125312c7ee115c.xae20093bed1e48a8(246, xbf06959672bf5f5b());
			break;
		case "gtextfbestfit":
			xf7125312c7ee115c.xae20093bed1e48a8(247, xbf06959672bf5f5b());
			break;
		case "gtextfnormalize":
			xf7125312c7ee115c.xae20093bed1e48a8(248, xbf06959672bf5f5b());
			break;
		case "gtextfdxmeasure":
			xf7125312c7ee115c.xae20093bed1e48a8(249, xbf06959672bf5f5b());
			break;
		case "gtextfbold":
			xf7125312c7ee115c.xae20093bed1e48a8(250, xbf06959672bf5f5b());
			break;
		case "gtextfitalic":
			xf7125312c7ee115c.xae20093bed1e48a8(251, xbf06959672bf5f5b());
			break;
		case "gtextfunderline":
			xf7125312c7ee115c.xae20093bed1e48a8(252, xbf06959672bf5f5b());
			break;
		case "gtextfshadow":
			xf7125312c7ee115c.xae20093bed1e48a8(253, xbf06959672bf5f5b());
			break;
		case "gtextfsmallcaps":
			xf7125312c7ee115c.xae20093bed1e48a8(254, xbf06959672bf5f5b());
			break;
		case "gtextfstrikethrough":
			xf7125312c7ee115c.xae20093bed1e48a8(255, xbf06959672bf5f5b());
			break;
		case "gtextfreverserows":
			xf7125312c7ee115c.xae20093bed1e48a8(240, xbf06959672bf5f5b());
			break;
		case "gtextrtf":
			xf7125312c7ee115c.xae20093bed1e48a8(193, xbf06959672bf5f5b());
			break;
		case "geoleft":
			x317be79405176667.x06c65daad0c0656c = x95ea7d23cc8ee04d();
			if (xf7125312c7ee115c.xbc5dc59d0d9b620d(4127))
			{
				x317be79405176667.xfe47e26e3b236632(x317be79405176667.x133d653c1b9b01f2 - x317be79405176667.x06c65daad0c0656c);
			}
			break;
		case "geotop":
			x317be79405176667.x399bb78ac51a4081 = x95ea7d23cc8ee04d();
			if (xf7125312c7ee115c.xbc5dc59d0d9b620d(4128))
			{
				x317be79405176667.x27bd4aa4cf0ce1aa(x317be79405176667.xc97e136f0019c237 - x317be79405176667.x399bb78ac51a4081);
			}
			break;
		case "georight":
			x317be79405176667.xfe47e26e3b236632(x95ea7d23cc8ee04d() - x317be79405176667.x06c65daad0c0656c);
			break;
		case "geobottom":
			x317be79405176667.x27bd4aa4cf0ce1aa(x95ea7d23cc8ee04d() - x317be79405176667.x399bb78ac51a4081);
			break;
		case "pverticies":
			xf7125312c7ee115c.xae20093bed1e48a8(325, x9d29d259552709ac());
			break;
		case "psegmentinfo":
			xf7125312c7ee115c.xae20093bed1e48a8(326, xf133eb4dc4764d67());
			break;
		case "cxk":
			xf7125312c7ee115c.xae20093bed1e48a8(344, (x3b504d8c866583dc)x95ea7d23cc8ee04d());
			break;
		case "pconnectionsites":
			xf7125312c7ee115c.xae20093bed1e48a8(337, x9d29d259552709ac());
			break;
		case "shapepath":
			xf7125312c7ee115c.xae20093bed1e48a8(324, (x449c0af4c304c651)x95ea7d23cc8ee04d());
			break;
		case "padjusthandles":
			xf7125312c7ee115c.xae20093bed1e48a8(341, xb9c49f121be47dc1());
			break;
		case "pguides":
			xf7125312c7ee115c.xae20093bed1e48a8(342, xfaeb87e15cbaa328());
			break;
		case "pinscribe":
			xf7125312c7ee115c.xae20093bed1e48a8(343, x4f710c21b816d100());
			break;
		case "adjustvalue":
			xf7125312c7ee115c.xae20093bed1e48a8(327, x95ea7d23cc8ee04d());
			break;
		case "adjust2value":
			xf7125312c7ee115c.xae20093bed1e48a8(328, x95ea7d23cc8ee04d());
			break;
		case "adjust3value":
			xf7125312c7ee115c.xae20093bed1e48a8(329, x95ea7d23cc8ee04d());
			break;
		case "adjust4value":
			xf7125312c7ee115c.xae20093bed1e48a8(330, x95ea7d23cc8ee04d());
			break;
		case "adjust5value":
			xf7125312c7ee115c.xae20093bed1e48a8(331, x95ea7d23cc8ee04d());
			break;
		case "adjust6value":
			xf7125312c7ee115c.xae20093bed1e48a8(332, x95ea7d23cc8ee04d());
			break;
		case "adjust7value":
			xf7125312c7ee115c.xae20093bed1e48a8(333, x95ea7d23cc8ee04d());
			break;
		case "adjust8value":
			xf7125312c7ee115c.xae20093bed1e48a8(334, x95ea7d23cc8ee04d());
			break;
		case "adjust9value":
			xf7125312c7ee115c.xae20093bed1e48a8(335, x95ea7d23cc8ee04d());
			break;
		case "adjust10value":
			xf7125312c7ee115c.xae20093bed1e48a8(336, x95ea7d23cc8ee04d());
			break;
		case "fgtextok":
			xf7125312c7ee115c.xae20093bed1e48a8(381, xbf06959672bf5f5b());
			break;
		case "ffillok":
			xf7125312c7ee115c.xae20093bed1e48a8(383, xbf06959672bf5f5b());
			break;
		case "ffillshadeshapeok":
			xf7125312c7ee115c.xae20093bed1e48a8(382, xbf06959672bf5f5b());
			break;
		case "flineok":
			xf7125312c7ee115c.xae20093bed1e48a8(380, xbf06959672bf5f5b());
			break;
		case "fshadowok":
			xf7125312c7ee115c.xae20093bed1e48a8(378, xbf06959672bf5f5b());
			break;
		case "f3dok":
			xf7125312c7ee115c.xae20093bed1e48a8(379, xbf06959672bf5f5b());
			break;
		case "xlimo":
			xf7125312c7ee115c.xae20093bed1e48a8(339, x95ea7d23cc8ee04d());
			break;
		case "ylimo":
			xf7125312c7ee115c.xae20093bed1e48a8(340, x95ea7d23cc8ee04d());
			break;
		case "lidregroup":
			xf7125312c7ee115c.xae20093bed1e48a8(904, x95ea7d23cc8ee04d());
			break;
		case "cropfromleft":
			xf7125312c7ee115c.xae20093bed1e48a8(258, x95ea7d23cc8ee04d());
			break;
		case "cropfromright":
			xf7125312c7ee115c.xae20093bed1e48a8(259, x95ea7d23cc8ee04d());
			break;
		case "cropfromtop":
			xf7125312c7ee115c.xae20093bed1e48a8(256, x95ea7d23cc8ee04d());
			break;
		case "cropfrombottom":
			xf7125312c7ee115c.xae20093bed1e48a8(257, x95ea7d23cc8ee04d());
			break;
		case "picturetransparent":
			xf7125312c7ee115c.xae20093bed1e48a8(263, x07d1b52af8293592());
			break;
		case "picturecontrast":
			xf7125312c7ee115c.xae20093bed1e48a8(264, x95ea7d23cc8ee04d());
			break;
		case "picturebrightness":
			xf7125312c7ee115c.xae20093bed1e48a8(265, x95ea7d23cc8ee04d());
			break;
		case "picturegamma":
			xf7125312c7ee115c.xae20093bed1e48a8(266, x95ea7d23cc8ee04d());
			break;
		case "picturegray":
			xf7125312c7ee115c.xae20093bed1e48a8(317, xbf06959672bf5f5b());
			break;
		case "picturebilevel":
			xf7125312c7ee115c.xae20093bed1e48a8(318, xbf06959672bf5f5b());
			break;
		case "pictureactive":
			xf7125312c7ee115c.xae20093bed1e48a8(319, xbf06959672bf5f5b());
			break;
		case "picturedblcrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(268, x95ea7d23cc8ee04d());
			break;
		case "picturefillcrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(269, x95ea7d23cc8ee04d());
			break;
		case "picturelinecrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(270, x95ea7d23cc8ee04d());
			break;
		case "pictureid":
			xf7125312c7ee115c.xae20093bed1e48a8(267, x95ea7d23cc8ee04d());
			break;
		case "filltype":
			xf7125312c7ee115c.xae20093bed1e48a8(384, (xeba92971120d3e5a)x95ea7d23cc8ee04d());
			break;
		case "fillcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(385, x07d1b52af8293592());
			break;
		case "fillopacity":
			xf7125312c7ee115c.xae20093bed1e48a8(386, x95ea7d23cc8ee04d());
			break;
		case "fillbackcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(387, x07d1b52af8293592());
			break;
		case "fillbackopacity":
			xf7125312c7ee115c.xae20093bed1e48a8(388, x95ea7d23cc8ee04d());
			break;
		case "fillblipname":
			xf7125312c7ee115c.xae20093bed1e48a8(391, xb028d7caf00bc546);
			break;
		case "fillangle":
			xf7125312c7ee115c.xae20093bed1e48a8(395, x95ea7d23cc8ee04d());
			break;
		case "fillfocus":
			xf7125312c7ee115c.xae20093bed1e48a8(396, x95ea7d23cc8ee04d());
			break;
		case "filltoleft":
			xf7125312c7ee115c.xae20093bed1e48a8(397, x95ea7d23cc8ee04d());
			break;
		case "filltoright":
			xf7125312c7ee115c.xae20093bed1e48a8(399, x95ea7d23cc8ee04d());
			break;
		case "filltotop":
			xf7125312c7ee115c.xae20093bed1e48a8(398, x95ea7d23cc8ee04d());
			break;
		case "filltobottom":
			xf7125312c7ee115c.xae20093bed1e48a8(400, x95ea7d23cc8ee04d());
			break;
		case "fillshadecolors":
			xf7125312c7ee115c.xae20093bed1e48a8(407, x7b0f38d9be6e0978());
			break;
		case "fillshadetype":
			xf7125312c7ee115c.xae20093bed1e48a8(412, (xda3162397283dd69)x95ea7d23cc8ee04d());
			break;
		case "filloriginx":
			xf7125312c7ee115c.xae20093bed1e48a8(408, x95ea7d23cc8ee04d());
			break;
		case "filloriginy":
			xf7125312c7ee115c.xae20093bed1e48a8(409, x95ea7d23cc8ee04d());
			break;
		case "fillshapeoriginx":
			xf7125312c7ee115c.xae20093bed1e48a8(410, x95ea7d23cc8ee04d());
			break;
		case "fillshapeoriginy":
			xf7125312c7ee115c.xae20093bed1e48a8(411, x95ea7d23cc8ee04d());
			break;
		case "ffilled":
			xf7125312c7ee115c.xae20093bed1e48a8(443, xbf06959672bf5f5b());
			break;
		case "fillcrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(389, x95ea7d23cc8ee04d());
			break;
		case "filldztype":
			xf7125312c7ee115c.xae20093bed1e48a8(405, (xd56eb9f05f589be5)x95ea7d23cc8ee04d());
			break;
		case "fillshape":
			xf7125312c7ee115c.xae20093bed1e48a8(445, xbf06959672bf5f5b());
			break;
		case "filluserect":
			xf7125312c7ee115c.xae20093bed1e48a8(446, xbf06959672bf5f5b());
			break;
		case "frecolorfillaspicture":
			xf7125312c7ee115c.xae20093bed1e48a8(441, xbf06959672bf5f5b());
			break;
		case "fuseshapeanchor":
			xf7125312c7ee115c.xae20093bed1e48a8(442, xbf06959672bf5f5b());
			break;
		case "linecolor":
			xf7125312c7ee115c.xae20093bed1e48a8(448, x07d1b52af8293592());
			break;
		case "lineopacity":
			xf7125312c7ee115c.xae20093bed1e48a8(449, x95ea7d23cc8ee04d());
			break;
		case "linebackcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(450, x07d1b52af8293592());
			break;
		case "linetype":
			xf7125312c7ee115c.xae20093bed1e48a8(452, (x6d4b101fe08bc376)x95ea7d23cc8ee04d());
			break;
		case "linefilldztype":
			xf7125312c7ee115c.xae20093bed1e48a8(458, (xd56eb9f05f589be5)x95ea7d23cc8ee04d());
			break;
		case "linewidth":
			xf7125312c7ee115c.xae20093bed1e48a8(459, x95ea7d23cc8ee04d());
			break;
		case "linestyle":
			xf7125312c7ee115c.xae20093bed1e48a8(461, (ShapeLineStyle)x95ea7d23cc8ee04d());
			break;
		case "linedashing":
			xf7125312c7ee115c.xae20093bed1e48a8(462, (DashStyle)x95ea7d23cc8ee04d());
			break;
		case "lineendcapstyle":
			xf7125312c7ee115c.xae20093bed1e48a8(471, (EndCap)x95ea7d23cc8ee04d());
			break;
		case "linejoinstyle":
			xf7125312c7ee115c.xae20093bed1e48a8(470, (JoinStyle)x95ea7d23cc8ee04d());
			break;
		case "linemiterlimit":
			xf7125312c7ee115c.xae20093bed1e48a8(460, x95ea7d23cc8ee04d());
			break;
		case "linefillblipname":
			xf7125312c7ee115c.xae20093bed1e48a8(454, xb028d7caf00bc546);
			break;
		case "linefillwidth":
			xf7125312c7ee115c.xae20093bed1e48a8(456, x95ea7d23cc8ee04d());
			break;
		case "linefillheight":
			xf7125312c7ee115c.xae20093bed1e48a8(457, x95ea7d23cc8ee04d());
			break;
		case "fline":
			xf7125312c7ee115c.xae20093bed1e48a8(508, xbf06959672bf5f5b());
			break;
		case "linestartarrowhead":
			xf7125312c7ee115c.xae20093bed1e48a8(464, (ArrowType)x95ea7d23cc8ee04d());
			break;
		case "lineendarrowhead":
			xf7125312c7ee115c.xae20093bed1e48a8(465, (ArrowType)x95ea7d23cc8ee04d());
			break;
		case "linestartarrowwidth":
			xf7125312c7ee115c.xae20093bed1e48a8(466, (ArrowWidth)x95ea7d23cc8ee04d());
			break;
		case "lineendarrowwidth":
			xf7125312c7ee115c.xae20093bed1e48a8(468, (ArrowWidth)x95ea7d23cc8ee04d());
			break;
		case "linestartarrowlength":
			xf7125312c7ee115c.xae20093bed1e48a8(467, (ArrowLength)x95ea7d23cc8ee04d());
			break;
		case "lineendarrowlength":
			xf7125312c7ee115c.xae20093bed1e48a8(469, (ArrowLength)x95ea7d23cc8ee04d());
			break;
		case "shadowtype":
			xf7125312c7ee115c.xae20093bed1e48a8(512, (x9a91f1235b1d8cac)x95ea7d23cc8ee04d());
			break;
		case "shadowcolor":
			xf7125312c7ee115c.xae20093bed1e48a8(513, x07d1b52af8293592());
			break;
		case "shadowhighlight":
			xf7125312c7ee115c.xae20093bed1e48a8(514, x07d1b52af8293592());
			break;
		case "shadowopacity":
			xf7125312c7ee115c.xae20093bed1e48a8(516, x95ea7d23cc8ee04d());
			break;
		case "shadowoffsetx":
			xf7125312c7ee115c.xae20093bed1e48a8(517, x95ea7d23cc8ee04d());
			break;
		case "shadowoffsety":
			xf7125312c7ee115c.xae20093bed1e48a8(518, x95ea7d23cc8ee04d());
			break;
		case "shadowsecondoffsetx":
			xf7125312c7ee115c.xae20093bed1e48a8(519, x95ea7d23cc8ee04d());
			break;
		case "shadowsecondoffsety":
			xf7125312c7ee115c.xae20093bed1e48a8(520, x95ea7d23cc8ee04d());
			break;
		case "shadowscalextox":
			xf7125312c7ee115c.xae20093bed1e48a8(521, x95ea7d23cc8ee04d());
			break;
		case "shadowscaleytox":
			xf7125312c7ee115c.xae20093bed1e48a8(522, x95ea7d23cc8ee04d());
			break;
		case "shadowscalextoy":
			xf7125312c7ee115c.xae20093bed1e48a8(523, x95ea7d23cc8ee04d());
			break;
		case "shadowscaleytoy":
			xf7125312c7ee115c.xae20093bed1e48a8(524, x95ea7d23cc8ee04d());
			break;
		case "shadowperspectivex":
			xf7125312c7ee115c.xae20093bed1e48a8(525, x95ea7d23cc8ee04d());
			break;
		case "shadowperspectivey":
			xf7125312c7ee115c.xae20093bed1e48a8(526, x95ea7d23cc8ee04d());
			break;
		case "shadowweight":
			xf7125312c7ee115c.xae20093bed1e48a8(527, x95ea7d23cc8ee04d());
			break;
		case "shadoworiginx":
			xf7125312c7ee115c.xae20093bed1e48a8(528, x95ea7d23cc8ee04d());
			break;
		case "shadoworiginy":
			xf7125312c7ee115c.xae20093bed1e48a8(529, x95ea7d23cc8ee04d());
			break;
		case "fshadow":
			xf7125312c7ee115c.xae20093bed1e48a8(574, xbf06959672bf5f5b());
			break;
		case "shadowcrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(515, x95ea7d23cc8ee04d());
			break;
		case "fshadowobscured":
			xf7125312c7ee115c.xae20093bed1e48a8(575, xbf06959672bf5f5b());
			break;
		case "c3dspecularamt":
			xf7125312c7ee115c.xae20093bed1e48a8(640, x95ea7d23cc8ee04d());
			break;
		case "c3ddiffuseamt":
			xf7125312c7ee115c.xae20093bed1e48a8(641, x95ea7d23cc8ee04d());
			break;
		case "c3dshininess":
			xf7125312c7ee115c.xae20093bed1e48a8(642, x95ea7d23cc8ee04d());
			break;
		case "c3dedgethickness":
			xf7125312c7ee115c.xae20093bed1e48a8(643, x95ea7d23cc8ee04d());
			break;
		case "c3dextrudeforward":
			xf7125312c7ee115c.xae20093bed1e48a8(644, x95ea7d23cc8ee04d());
			break;
		case "c3dextrudebackward":
			xf7125312c7ee115c.xae20093bed1e48a8(645, x95ea7d23cc8ee04d());
			break;
		case "c3dextrusioncolor":
			xf7125312c7ee115c.xae20093bed1e48a8(647, x07d1b52af8293592());
			break;
		case "f3d":
			xf7125312c7ee115c.xae20093bed1e48a8(700, xbf06959672bf5f5b());
			break;
		case "fc3dmetallic":
			xf7125312c7ee115c.xae20093bed1e48a8(701, xbf06959672bf5f5b());
			break;
		case "c3dextrudeplane":
			xf7125312c7ee115c.xae20093bed1e48a8(646, (x8755a9e2fca0996e)x95ea7d23cc8ee04d());
			break;
		case "fc3duseextrusioncolor":
			xf7125312c7ee115c.xae20093bed1e48a8(702, xbf06959672bf5f5b());
			break;
		case "fc3dlightface":
			xf7125312c7ee115c.xae20093bed1e48a8(703, xbf06959672bf5f5b());
			break;
		case "c3dxrotationangle":
			xf7125312c7ee115c.xae20093bed1e48a8(705, x95ea7d23cc8ee04d());
			break;
		case "c3dyrotationangle":
			xf7125312c7ee115c.xae20093bed1e48a8(704, x95ea7d23cc8ee04d());
			break;
		case "c3drotationaxisx":
			xf7125312c7ee115c.xae20093bed1e48a8(706, x95ea7d23cc8ee04d());
			break;
		case "c3drotationaxisy":
			xf7125312c7ee115c.xae20093bed1e48a8(707, x95ea7d23cc8ee04d());
			break;
		case "c3drotationaxisz":
			xf7125312c7ee115c.xae20093bed1e48a8(708, x95ea7d23cc8ee04d());
			break;
		case "c3drotationangle":
			xf7125312c7ee115c.xae20093bed1e48a8(709, x95ea7d23cc8ee04d());
			break;
		case "fc3drotationcenterauto":
			xf7125312c7ee115c.xae20093bed1e48a8(764, xbf06959672bf5f5b());
			break;
		case "c3drotationcenterx":
			xf7125312c7ee115c.xae20093bed1e48a8(710, x95ea7d23cc8ee04d());
			break;
		case "c3drotationcentery":
			xf7125312c7ee115c.xae20093bed1e48a8(711, x95ea7d23cc8ee04d());
			break;
		case "c3drotationcenterz":
			xf7125312c7ee115c.xae20093bed1e48a8(712, x95ea7d23cc8ee04d());
			break;
		case "c3drendermode":
			xf7125312c7ee115c.xae20093bed1e48a8(713, (xb156f8ae92094cbb)x95ea7d23cc8ee04d());
			break;
		case "c3dxviewpoint":
			xf7125312c7ee115c.xae20093bed1e48a8(715, x95ea7d23cc8ee04d());
			break;
		case "c3dyviewpoint":
			xf7125312c7ee115c.xae20093bed1e48a8(716, x95ea7d23cc8ee04d());
			break;
		case "c3dzviewpoint":
			xf7125312c7ee115c.xae20093bed1e48a8(717, x95ea7d23cc8ee04d());
			break;
		case "c3doriginx":
			xf7125312c7ee115c.xae20093bed1e48a8(718, x95ea7d23cc8ee04d());
			break;
		case "c3doriginy":
			xf7125312c7ee115c.xae20093bed1e48a8(719, x95ea7d23cc8ee04d());
			break;
		case "c3dskewangle":
			xf7125312c7ee115c.xae20093bed1e48a8(720, x95ea7d23cc8ee04d());
			break;
		case "c3dskewamount":
			xf7125312c7ee115c.xae20093bed1e48a8(721, x95ea7d23cc8ee04d());
			break;
		case "c3dambientintensity":
			xf7125312c7ee115c.xae20093bed1e48a8(722, x95ea7d23cc8ee04d());
			break;
		case "c3dkeyx":
			xf7125312c7ee115c.xae20093bed1e48a8(723, x95ea7d23cc8ee04d());
			break;
		case "c3dkeyy":
			xf7125312c7ee115c.xae20093bed1e48a8(724, x95ea7d23cc8ee04d());
			break;
		case "c3dkeyz":
			xf7125312c7ee115c.xae20093bed1e48a8(725, x95ea7d23cc8ee04d());
			break;
		case "c3dkeyintensity":
			xf7125312c7ee115c.xae20093bed1e48a8(726, x95ea7d23cc8ee04d());
			break;
		case "c3dfillx":
			xf7125312c7ee115c.xae20093bed1e48a8(727, x95ea7d23cc8ee04d());
			break;
		case "c3dfilly":
			xf7125312c7ee115c.xae20093bed1e48a8(728, x95ea7d23cc8ee04d());
			break;
		case "c3dfillz":
			xf7125312c7ee115c.xae20093bed1e48a8(729, x95ea7d23cc8ee04d());
			break;
		case "c3dfillintensity":
			xf7125312c7ee115c.xae20093bed1e48a8(730, x95ea7d23cc8ee04d());
			break;
		case "fc3dparallel":
			xf7125312c7ee115c.xae20093bed1e48a8(765, xbf06959672bf5f5b());
			break;
		case "fc3dkeyharsh":
			xf7125312c7ee115c.xae20093bed1e48a8(766, xbf06959672bf5f5b());
			break;
		case "fc3dfillharsh":
			xf7125312c7ee115c.xae20093bed1e48a8(767, xbf06959672bf5f5b());
			break;
		case "c3dcrmod":
			xf7125312c7ee115c.xae20093bed1e48a8(648, x95ea7d23cc8ee04d());
			break;
		case "c3dtolerance":
			xf7125312c7ee115c.xae20093bed1e48a8(714, x95ea7d23cc8ee04d());
			break;
		case "fc3dconstrainrotation":
			xf7125312c7ee115c.xae20093bed1e48a8(763, xbf06959672bf5f5b());
			break;
		case "perspectiveoffsetx":
			xf7125312c7ee115c.xae20093bed1e48a8(577, x95ea7d23cc8ee04d());
			break;
		case "perspectiveoffsety":
			xf7125312c7ee115c.xae20093bed1e48a8(578, x95ea7d23cc8ee04d());
			break;
		case "perspectiveoriginx":
			xf7125312c7ee115c.xae20093bed1e48a8(586, x95ea7d23cc8ee04d());
			break;
		case "perspectiveoriginy":
			xf7125312c7ee115c.xae20093bed1e48a8(587, x95ea7d23cc8ee04d());
			break;
		case "perspectiveperspectivex":
			xf7125312c7ee115c.xae20093bed1e48a8(583, x95ea7d23cc8ee04d());
			break;
		case "perspectiveperspectivey":
			xf7125312c7ee115c.xae20093bed1e48a8(584, x95ea7d23cc8ee04d());
			break;
		case "perspectivescalextox":
			xf7125312c7ee115c.xae20093bed1e48a8(579, x95ea7d23cc8ee04d());
			break;
		case "perspectivescalextoy":
			xf7125312c7ee115c.xae20093bed1e48a8(581, x95ea7d23cc8ee04d());
			break;
		case "perspectivescaleytox":
			xf7125312c7ee115c.xae20093bed1e48a8(580, x95ea7d23cc8ee04d());
			break;
		case "perspectivescaleytoy":
			xf7125312c7ee115c.xae20093bed1e48a8(582, x95ea7d23cc8ee04d());
			break;
		case "perspectivetype":
			xf7125312c7ee115c.xae20093bed1e48a8(576, (x38c4fdd995570edc)x95ea7d23cc8ee04d());
			break;
		case "perspectiveweight":
			xf7125312c7ee115c.xae20093bed1e48a8(585, x95ea7d23cc8ee04d());
			break;
		case "fperspective":
			xf7125312c7ee115c.xae20093bed1e48a8(639, xbf06959672bf5f5b());
			break;
		case "spcot":
			xf7125312c7ee115c.xae20093bed1e48a8(832, (x9cda3ea77eff6f0d)x95ea7d23cc8ee04d());
			break;
		case "dxycalloutgap":
			xf7125312c7ee115c.xae20093bed1e48a8(833, x95ea7d23cc8ee04d());
			break;
		case "spcoa":
			xf7125312c7ee115c.xae20093bed1e48a8(834, (x637e6856119e5fb2)x95ea7d23cc8ee04d());
			break;
		case "spcod":
			xf7125312c7ee115c.xae20093bed1e48a8(835, (xceb84165dedc0c2d)x95ea7d23cc8ee04d());
			break;
		case "dxycalloutdropspecified":
			xf7125312c7ee115c.xae20093bed1e48a8(836, x95ea7d23cc8ee04d());
			break;
		case "dxycalloutlengthspecified":
			xf7125312c7ee115c.xae20093bed1e48a8(837, x95ea7d23cc8ee04d());
			break;
		case "fcallout":
			xf7125312c7ee115c.xae20093bed1e48a8(889, xbf06959672bf5f5b());
			break;
		case "fcalloutaccentbar":
			xf7125312c7ee115c.xae20093bed1e48a8(890, xbf06959672bf5f5b());
			break;
		case "fcallouttextborder":
			xf7125312c7ee115c.xae20093bed1e48a8(891, xbf06959672bf5f5b());
			break;
		case "fcalloutdropauto":
			xf7125312c7ee115c.xae20093bed1e48a8(894, xbf06959672bf5f5b());
			break;
		case "fcalloutlengthspecified":
			xf7125312c7ee115c.xae20093bed1e48a8(895, xbf06959672bf5f5b());
			break;
		case "fcalloutminusx":
			xf7125312c7ee115c.xae20093bed1e48a8(892, xbf06959672bf5f5b());
			break;
		case "fcalloutminusy":
			xf7125312c7ee115c.xae20093bed1e48a8(893, xbf06959672bf5f5b());
			break;
		case "cxstyle":
			xf7125312c7ee115c.xae20093bed1e48a8(771, (x5b865d49b2c8440d)x95ea7d23cc8ee04d());
			break;
		case "dgmt":
			xf7125312c7ee115c.xae20093bed1e48a8(1280, (x5e63bd35f6835a06)x95ea7d23cc8ee04d());
			break;
		case "dgmtstyle":
			xf7125312c7ee115c.xae20093bed1e48a8(1281, x95ea7d23cc8ee04d());
			break;
		case "prelationtbl":
			xf7125312c7ee115c.xae20093bed1e48a8(1284, x71029269932efabe());
			break;
		case "dgmscalex":
			xf7125312c7ee115c.xae20093bed1e48a8(1285, x95ea7d23cc8ee04d());
			break;
		case "dgmscaley":
			xf7125312c7ee115c.xae20093bed1e48a8(1286, x95ea7d23cc8ee04d());
			break;
		case "dgmdefaultfontsize":
			xf7125312c7ee115c.xae20093bed1e48a8(1287, x95ea7d23cc8ee04d());
			break;
		case "dgmconstrainbounds":
			xf7125312c7ee115c.xae20093bed1e48a8(1288, xdba4185013f2ac84());
			break;
		case "fdolayout":
			xf7125312c7ee115c.xae20093bed1e48a8(1342, xbf06959672bf5f5b());
			break;
		case "fdoformat":
			xf7125312c7ee115c.xae20093bed1e48a8(1340, xbf06959672bf5f5b());
			break;
		case "dgmlayout":
			xf7125312c7ee115c.xae20093bed1e48a8(777, (xc586cb26186123d4)x95ea7d23cc8ee04d());
			break;
		case "dgmnodekind":
			xf7125312c7ee115c.xae20093bed1e48a8(778, (x76b42e09224005a0)x95ea7d23cc8ee04d());
			break;
		case "freverse":
			xf7125312c7ee115c.xae20093bed1e48a8(1341, xbf06959672bf5f5b());
			break;
		case "bwmode":
			xf7125312c7ee115c.xae20093bed1e48a8(772, (x17abde5b32777816)x95ea7d23cc8ee04d());
			break;
		case "bwmodebw":
			xf7125312c7ee115c.xae20093bed1e48a8(774, (x17abde5b32777816)x95ea7d23cc8ee04d());
			break;
		case "bwmodepurebw":
			xf7125312c7ee115c.xae20093bed1e48a8(773, (x17abde5b32777816)x95ea7d23cc8ee04d());
			break;
		case "fhorizrule":
			xf7125312c7ee115c.xae20093bed1e48a8(948, xbf06959672bf5f5b());
			break;
		case "dxwidthhr":
			x317be79405176667.xf524ccc95fe8e714(x4574ea26106f0edb.x0e1fdb362561ddb2(x95ea7d23cc8ee04d()));
			break;
		case "dxheighthr":
			xf7125312c7ee115c.xae20093bed1e48a8(917, x95ea7d23cc8ee04d());
			break;
		case "alignhr":
			xf7125312c7ee115c.xae20093bed1e48a8(916, (x206d87dc07f8c9e2)x95ea7d23cc8ee04d());
			break;
		case "fnoshadehr":
			xf7125312c7ee115c.xae20093bed1e48a8(947, xbf06959672bf5f5b());
			break;
		case "fstandardhr":
			xf7125312c7ee115c.xae20093bed1e48a8(946, xbf06959672bf5f5b());
			break;
		case "pcthr":
			xf7125312c7ee115c.xae20093bed1e48a8(915, x95ea7d23cc8ee04d());
			break;
		case "wztooltip":
			xf7125312c7ee115c.xae20093bed1e48a8(909, xb028d7caf00bc546);
			break;
		case "flayoutincell":
			xf7125312c7ee115c.xae20093bed1e48a8(944, xbf06959672bf5f5b());
			break;
		case "groupleft":
			xac6bde3fd314beb5 = x95ea7d23cc8ee04d();
			break;
		case "groupright":
			x3852bb6ca7ddc465 = x95ea7d23cc8ee04d();
			break;
		case "grouptop":
			xa60f044a428a210d = x95ea7d23cc8ee04d();
			break;
		case "groupbottom":
			xe125879721b4f24b = x95ea7d23cc8ee04d();
			break;
		case "relleft":
			xd5ee62329c90d234 = x95ea7d23cc8ee04d();
			break;
		case "relright":
			xb9ff5f240866a3ad = x95ea7d23cc8ee04d();
			break;
		case "reltop":
			x92ae72a61c6f4a39 = x95ea7d23cc8ee04d();
			break;
		case "relbottom":
			x8170bb6f7d06f761 = x95ea7d23cc8ee04d();
			break;
		case "pibflags":
			x75c525cfe6e341ed = x95ea7d23cc8ee04d();
			break;
		case "pibname":
			x6804183603e2e345 = xb028d7caf00bc546;
			break;
		case "fpseudoinline":
			xdce75473dc96eeb0 = true;
			break;
		case "pinkdata":
		{
			x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(xb028d7caf00bc546);
			xf7125312c7ee115c.xae20093bed1e48a8(1792, x2dce569e9052de2d2.x0f6807cca84a8e5b());
			break;
		}
		case "finkannotation":
			xf7125312c7ee115c.xae20093bed1e48a8(1855, xbf06959672bf5f5b());
			break;
		case "wzsigsetupaddlxml":
			xf7125312c7ee115c.xae20093bed1e48a8(1927, xb028d7caf00bc546);
			break;
		case "fsigsetupallowcomments":
			xf7125312c7ee115c.xae20093bed1e48a8(1981, xbf06959672bf5f5b());
			break;
		case "wzsigsetupid":
			xf7125312c7ee115c.xae20093bed1e48a8(1921, xb028d7caf00bc546);
			break;
		case "fissignatureline":
			xf7125312c7ee115c.xae20093bed1e48a8(1983, xbf06959672bf5f5b());
			break;
		case "wzsigsetupprovid":
			xf7125312c7ee115c.xae20093bed1e48a8(1922, xb028d7caf00bc546);
			break;
		case "fsigsetupshowsigndate":
			xf7125312c7ee115c.xae20093bed1e48a8(1980, xbf06959672bf5f5b());
			break;
		case "wzsigsetupsigninst":
			xf7125312c7ee115c.xae20093bed1e48a8(1926, xb028d7caf00bc546);
			break;
		case "wzsigsetupprovurl":
			xf7125312c7ee115c.xae20093bed1e48a8(1928, xb028d7caf00bc546);
			break;
		case "wzsigsetupsuggsigner":
			xf7125312c7ee115c.xae20093bed1e48a8(1923, xb028d7caf00bc546);
			break;
		case "wzsigsetupsuggsigner2":
			xf7125312c7ee115c.xae20093bed1e48a8(1924, xb028d7caf00bc546);
			break;
		case "wzsigsetupsuggsigneremail":
			xf7125312c7ee115c.xae20093bed1e48a8(1925, xb028d7caf00bc546);
			break;
		case "fsigsetupsigninstset":
			xf7125312c7ee115c.xae20093bed1e48a8(1982, xbf06959672bf5f5b());
			break;
		case "fchangepage":
		case "colstart":
		case "colspan":
		case "wzequationxml":
		case "metroblob":
		case "pwrappolygonvertices":
		case "fbottomhittestline":
		case "flefthittestline":
		case "frighthittestline":
		case "ftophittestline":
		case "finitiator":
		case "fnohittestpicture":
		case "fbottomnolinedrawdash":
		case "fleftnolinedrawdash":
		case "ftopnolinedrawdash":
		case "frightnolinedrawdash":
		case "hspmaster":
		case "fpolicylabel":
		case "fpolicybarcode":
		case "txdir":
		case "ccol":
		case "dzcolmargin":
		case "finsetpen":
		case "fleftinsetpen":
		case "frightinsetpen":
		case "ftopinsetpen":
		case "fbottominsetpen":
		case "finsetpenok":
		case "fleftinsetpenok":
		case "frightinsetpenok":
		case "ftopinsetpenok":
		case "fbottominsetpenok":
		case "fcolumninsetpenok":
		case "fbottomarrowheadsok":
		case "fleftarrowheadsok":
		case "frightarrowheadsok":
		case "ftoparrowheadsok":
		case "fborderlesscanvas":
		case "fcolumnhittestline":
		case "fnonstickyinkcanvas":
		case "gtextalign":
		case "pibprint":
		case "pibprintflags":
		case "pibprintname":
		case "picturepreservegrays":
		case "picturerecolor":
		case "picturerecolorext":
		case "picturerecolorextcmy":
		case "picturerecolorextk":
		case "picturerecolorextmod":
		case "picturerecolorextwzname":
		case "pconnectionsitesdir":
		case "pfragments":
		case "dhgt":
		case "fcliptowrap":
		case "flockagainstungrouping":
		case "freallyhidden":
		case "frelchangepage":
		case "fuserdrawn":
		case "tableproperties":
		case "tablerowproperties":
		case "wzapplet":
		case "wzappletarg":
		case "wzscriptidattr":
		case "wzwebbot":
		case "fillcolorext":
		case "fillcolorextcmy":
		case "fillcolorextk":
		case "fillcolorextmod":
		case "fillcolorextwzname":
		case "fillbackcolorext":
		case "fillbackcolorextcmy":
		case "fillbackcolorextk":
		case "lfillbackcolorextmod":
		case "fillbackcolorextwzname":
		case "fillblipflags":
		case "fillrectbottom":
		case "fillrectleft":
		case "fillrectright":
		case "fillrecttop":
		case "flinerecolorfillaspicture":
		case "flineuseshapeanchor":
		case "fcolumnline":
		case "fcolumnlineok":
		case "fbottomline":
		case "fleftline":
		case "frightline":
		case "ftopline":
		case "linecolorext":
		case "linecolorextcmy":
		case "linecolorextk":
		case "linecolorextmod":
		case "linebackcolorext":
		case "linebackcolorextcmy":
		case "linebackcolorextk":
		case "linebackcolorextmod":
		case "linefillblipflags":
		case "linefillshape":
		case "linecrmod":
		case "linedashstyle":
		case "linebottom":
		case "linecolumn":
		case "lineleft":
		case "lineright":
		case "linetop":
		case "shadowcolorext":
		case "shadowcolorextcmy":
		case "shadowcolorextk":
		case "shadowcolorextmod":
		case "shadowhighlightext":
		case "shadowhighlightextcmy":
		case "shadowhighlightextk":
		case "shadowhighlightextmod":
		case "c3dextrusioncolorext":
		case "c3dextrusioncolorextcmy":
		case "c3dextrusioncolorextk":
		case "c3dextrusioncolorextmod":
		case "dgmlayoutmru":
			x28fcdc775a1d069c.xbd5e5733680bbfc8(x38385f1e5a2e9b38);
			break;
		case "fillshadepreset":
		case "frenderink":
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x973264be7f63e178:
			x38385f1e5a2e9b38 = x153c99a852375422.x9f1a6a3451a38d10().ToLower();
			break;
		case x25099a8bbbd55d1c.x644c2172d2f4dc61:
		case x25099a8bbbd55d1c.xaa0945c39e7e59d8:
			xb028d7caf00bc546 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x1372023e0d72dcba:
			x28fcdc775a1d069c.xbd5e5733680bbfc8("hsv");
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x973264be7f63e178:
		case x25099a8bbbd55d1c.x644c2172d2f4dc61:
		case x25099a8bbbd55d1c.xaa0945c39e7e59d8:
		case x25099a8bbbd55d1c.x1372023e0d72dcba:
			return this;
		case x25099a8bbbd55d1c.x1a78cae632d91b5e:
			if (!(x38385f1e5a2e9b38 == "pihlshape"))
			{
				return null;
			}
			return new x8a1f117e84a01d40(x28fcdc775a1d069c, x317be79405176667);
		case x25099a8bbbd55d1c.x7f4d496937f8c24c:
			return xdd2349a185c515fa();
		default:
			return null;
		}
	}

	private xc71a5c7f64b2230d xdd2349a185c515fa()
	{
		switch (x38385f1e5a2e9b38)
		{
		case "pib":
			if (!x317be79405176667.xa170cce2bc40bdf5)
			{
				x317be79405176667.x88d1b78392d1a0ab(ShapeType.Image);
			}
			return new xc71a5c7f64b2230d(x28fcdc775a1d069c, (Shape)x317be79405176667);
		case "fillblip":
			return new xc71a5c7f64b2230d(x28fcdc775a1d069c, (Shape)x317be79405176667, 4111);
		case "linefillblip":
			return new xc71a5c7f64b2230d(x28fcdc775a1d069c, (Shape)x317be79405176667, 4110);
		default:
			return null;
		}
	}

	internal void x9c4f08d3e576056e()
	{
		FlipOrientation flipOrientation = FlipOrientation.None;
		if (x131fd6d4f5493c89 && xb3cb903c09e41fe8)
		{
			flipOrientation = FlipOrientation.Both;
		}
		else if (x131fd6d4f5493c89)
		{
			flipOrientation = FlipOrientation.Horizontal;
		}
		else if (xb3cb903c09e41fe8)
		{
			flipOrientation = FlipOrientation.Vertical;
		}
		xf7125312c7ee115c.xae20093bed1e48a8(4096, flipOrientation);
	}

	private int x95ea7d23cc8ee04d()
	{
		int num = xca004f56614e2431.x912616ee70b2d94d(xb028d7caf00bc546);
		if (num == int.MinValue)
		{
			num = 0;
		}
		return num;
	}

	private bool xbf06959672bf5f5b()
	{
		return x95ea7d23cc8ee04d() != 0;
	}

	private x26d9ecb4bdf0456d x07d1b52af8293592()
	{
		return x195cb055715b526e.xfa7086ee0c6b6330(x95ea7d23cc8ee04d());
	}

	private x44f2b8bf33b16275[] xf133eb4dc4764d67()
	{
		string[] array = xb028d7caf00bc546.Trim().Split(';');
		int num = xca004f56614e2431.xa93402510be8434e(array[1]);
		x44f2b8bf33b16275[] array2 = new x44f2b8bf33b16275[num];
		for (int i = 0; i < num; i++)
		{
			int xebf45bdcaa1fd1e = xca004f56614e2431.xa93402510be8434e(array[2 + i]);
			array2[i] = x30145fee5dd2eb06.x475eb9088d78b9cf(xebf45bdcaa1fd1e);
		}
		return array2;
	}

	private int[] xdba4185013f2ac84()
	{
		string[] array = xb028d7caf00bc546.Trim().Split(';');
		int num = xca004f56614e2431.xa93402510be8434e(array[1]);
		int[] array2 = new int[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = xca004f56614e2431.xa93402510be8434e(array[2 + i]);
		}
		return array2;
	}

	private int[] x34863c4920e083ff()
	{
		string[] array = xb028d7caf00bc546.Trim().Split(';');
		int num = xca004f56614e2431.xa93402510be8434e(array[1]);
		int[] array2 = new int[num * 2];
		for (int i = 0; i < num; i++)
		{
			string[] array3 = array[2 + i].Trim(xc8631722a06390e3).Split(',');
			array2[i * 2] = xca004f56614e2431.xa93402510be8434e(array3[0]);
			array2[i * 2 + 1] = xca004f56614e2431.xa93402510be8434e(array3[1]);
		}
		return array2;
	}

	private static int x62184402351cc37a(x2dce569e9052de2d xe134235b3526fa75)
	{
		int result = xe134235b3526fa75.x2e6b89ad8001e18f();
		xe134235b3526fa75.x2e6b89ad8001e18f();
		xe134235b3526fa75.x2e6b89ad8001e18f();
		return result;
	}

	private x08d932077485c285[] x9d29d259552709ac()
	{
		int[] array = x34863c4920e083ff();
		x08d932077485c285[] array2 = new x08d932077485c285[array.Length / 2];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = new x08d932077485c285(xf7d2bc4cd6535591.x783efc6c84a26fe0(array[i * 2]), xf7d2bc4cd6535591.x783efc6c84a26fe0(array[i * 2 + 1]));
		}
		return array2;
	}

	private void x5ad509ecdb99ecdd()
	{
		Match match = x582a063c786b0d3c.Match(xb028d7caf00bc546);
		xb028d7caf00bc546 = match.Groups[1].Value;
	}

	private x7efbe0a2dc0d335f[] xb9c49f121be47dc1()
	{
		x5ad509ecdb99ecdd();
		x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(xb028d7caf00bc546);
		int num = x62184402351cc37a(x2dce569e9052de2d2);
		x7efbe0a2dc0d335f[] array = new x7efbe0a2dc0d335f[num];
		for (int i = 0; i < num; i++)
		{
			x7efbe0a2dc0d335f x7efbe0a2dc0d335f = new x7efbe0a2dc0d335f();
			int num2 = x2dce569e9052de2d2.x95ea7d23cc8ee04d();
			x7efbe0a2dc0d335f.x7ab55132a5c2e47e = (num2 & 0x2000) != 0;
			x7efbe0a2dc0d335f.x22dfdc5e2d91486e = (num2 & 0x20) != 0;
			x7efbe0a2dc0d335f.x9183a138a4fced5c = (num2 & 0x10) != 0;
			x7efbe0a2dc0d335f.x7937f9e8f355e258 = (num2 & 8) != 0;
			x7efbe0a2dc0d335f.xcc2d426b867d703d = (num2 & 4) != 0;
			x7efbe0a2dc0d335f.x916221819f469b19 = (num2 & 2) != 0;
			x7efbe0a2dc0d335f.x2f612cdfb1f62c32 = (num2 & 1) != 0;
			x7efbe0a2dc0d335f.x3b1bddb38a858693 = new x98655ffe05324a50(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			x7efbe0a2dc0d335f.x97a3447730c7ceb9 = new x98655ffe05324a50(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			x7efbe0a2dc0d335f.xb6af3939c9fabf06 = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x800) != 0);
			x7efbe0a2dc0d335f.x8d8e3bafebd1a122 = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x1000) != 0);
			x7efbe0a2dc0d335f.x9462c8df936efa39 = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x80) != 0);
			x7efbe0a2dc0d335f.x11f73230b9b436a7 = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x100) != 0);
			x7efbe0a2dc0d335f.x5b051452efe1bbe3 = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x200) != 0);
			x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = new x06e4f09a90ca939a(x2dce569e9052de2d2.x95ea7d23cc8ee04d(), (num2 & 0x400) != 0);
			array[i] = x7efbe0a2dc0d335f;
		}
		return array;
	}

	private x40937ad35b1cf5f7[] xfaeb87e15cbaa328()
	{
		int[] array = x34863c4920e083ff();
		x40937ad35b1cf5f7[] array2 = new x40937ad35b1cf5f7[array.Length / 2];
		for (int i = 0; i < array2.Length; i++)
		{
			int num = array[i * 2];
			int num2 = array[i * 2 + 1];
			x40937ad35b1cf5f7 x40937ad35b1cf5f = new x40937ad35b1cf5f7();
			x40937ad35b1cf5f.xca0517fe66f52202 = (xca0517fe66f52202)(num & 0xFF);
			x40937ad35b1cf5f.x586b7652ac7cefe0 = (num >> 8) & 0xFF;
			x40937ad35b1cf5f.xf63e76e85f8fbc50 = (num >> 16) & 0xFFFF;
			x40937ad35b1cf5f.xe7e30aeba78bbcd2 = num2 & 0xFFFF;
			x40937ad35b1cf5f.x7cc7f538a3b98861 = (num2 >> 16) & 0xFFFF;
			array2[i] = x40937ad35b1cf5f;
		}
		return array2;
	}

	private xbc9979937c838d75[] x4f710c21b816d100()
	{
		x5ad509ecdb99ecdd();
		x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(xb028d7caf00bc546);
		int num = x62184402351cc37a(x2dce569e9052de2d2);
		xbc9979937c838d75[] array = new xbc9979937c838d75[num];
		for (int i = 0; i < num; i++)
		{
			xbc9979937c838d75 xbc9979937c838d = new xbc9979937c838d75();
			xbc9979937c838d.x72d92bd1aff02e37 = xf7d2bc4cd6535591.x783efc6c84a26fe0(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			xbc9979937c838d.xe360b1885d8d4a41 = xf7d2bc4cd6535591.x783efc6c84a26fe0(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			xbc9979937c838d.x419ba17a5322627b = xf7d2bc4cd6535591.x783efc6c84a26fe0(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			xbc9979937c838d.x9bcb07e204e30218 = xf7d2bc4cd6535591.x783efc6c84a26fe0(x2dce569e9052de2d2.x95ea7d23cc8ee04d());
			array[i] = xbc9979937c838d;
		}
		return array;
	}

	private x9fb6ff04f20b10d0[] x7b0f38d9be6e0978()
	{
		int[] array = x34863c4920e083ff();
		x9fb6ff04f20b10d0[] array2 = new x9fb6ff04f20b10d0[array.Length / 2];
		for (int i = 0; i < array2.Length; i++)
		{
			x9fb6ff04f20b10d0 x9fb6ff04f20b10d = new x9fb6ff04f20b10d0();
			x9fb6ff04f20b10d.x9b41425268471380 = x195cb055715b526e.xfa7086ee0c6b6330(array[i * 2]);
			x9fb6ff04f20b10d.x12cb12b5d2cad53d = array[i * 2 + 1];
			array2[i] = x9fb6ff04f20b10d;
		}
		return array2;
	}

	private x580ae020787e37f2[] x71029269932efabe()
	{
		x5ad509ecdb99ecdd();
		x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(xb028d7caf00bc546);
		int num = x62184402351cc37a(x2dce569e9052de2d2);
		x580ae020787e37f2[] array = new x580ae020787e37f2[num];
		for (int i = 0; i < num; i++)
		{
			x580ae020787e37f2 x580ae020787e37f = new x580ae020787e37f2();
			x580ae020787e37f.xda71bf6f7c07c3bc = x2dce569e9052de2d2.x95ea7d23cc8ee04d();
			x580ae020787e37f.x8e8f6cc6a0756b05 = x2dce569e9052de2d2.x95ea7d23cc8ee04d();
			x580ae020787e37f.x857912840ffd015f = x2dce569e9052de2d2.x95ea7d23cc8ee04d();
			array[i] = x580ae020787e37f;
		}
		return array;
	}
}
