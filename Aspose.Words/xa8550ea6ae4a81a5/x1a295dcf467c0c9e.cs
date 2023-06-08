using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace xa8550ea6ae4a81a5;

internal class x1a295dcf467c0c9e
{
	private readonly FootnoteType x569868da696e4454;

	private readonly xaf66e8c590b2b553 x9b287b671d592594;

	private readonly x8f3af96aa56f1e32 x800085dd555f7711;

	private int x60adf410a9cceab0;

	private bool xb70432a39dd30653 => x569868da696e4454 == FootnoteType.Endnote;

	internal x1a295dcf467c0c9e(FootnoteType footnoteType, xaf66e8c590b2b553 writer)
	{
		x569868da696e4454 = footnoteType;
		x9b287b671d592594 = writer;
		string x69cb5ff2e6c23f;
		string xe1d3286d17e44a;
		string x061610664b4c984f;
		string x766ce0458c;
		switch (footnoteType)
		{
		case FootnoteType.Footnote:
			x69cb5ff2e6c23f = "footnotes.xml";
			xe1d3286d17e44a = "application/vnd.openxmlformats-officedocument.wordprocessingml.footnotes+xml";
			x061610664b4c984f = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/footnotes";
			x766ce0458c = "w:footnotes";
			break;
		case FootnoteType.Endnote:
			x69cb5ff2e6c23f = "endnotes.xml";
			xe1d3286d17e44a = "application/vnd.openxmlformats-officedocument.wordprocessingml.endnotes+xml";
			x061610664b4c984f = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/endnotes";
			x766ce0458c = "w:endnotes";
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nlbmdnimnmpmnmgnlmnnaneoemlodhcpgljpmlaajlhalloaclfbalmbcldcakkcifbdjkidlkpdpjgebjnehfef", 1837547880)));
		}
		x800085dd555f7711 = x9b287b671d592594.xa24813b526772a3b(x69cb5ff2e6c23f, xe1d3286d17e44a, x061610664b4c984f);
		x800085dd555f7711.x454da6e050647673(x766ce0458c);
	}

	internal void x8ffe90e7fbccfccd()
	{
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	internal void x1b12ad7e0ad0df34(x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		x800085dd555f7711.x2307058321cdb62f(xb70432a39dd30653 ? "w:endnote" : "w:footnote");
		x800085dd555f7711.x25e28424582ee3ac("w:type", xc62574be95c1c918.xfdc927dd4cdefa18(x781135a02d5b7a22, xb70432a39dd30653), "normal");
		x800085dd555f7711.x943f6be3acf634db("w:id", x60adf410a9cceab0);
		x9b287b671d592594.xefc309b2831366cb(x800085dd555f7711);
	}

	internal int x29a51827c03d354b()
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		x9b287b671d592594.xa493f0b03338ab7a();
		return x60adf410a9cceab0++;
	}

	internal void xf65c32ef4443c2c5(x4c1e058c67948d6a xe9707cb1ec88db49, bool x28ee2f81ab05fedb)
	{
		int num = (xb70432a39dd30653 ? 100 : 0);
		object obj = xe9707cb1ec88db49.xf7866f89640a29a3(2500 + num);
		object obj2 = xe9707cb1ec88db49.xf7866f89640a29a3(2530 + num);
		object obj3 = xe9707cb1ec88db49.xf7866f89640a29a3(2520 + num);
		object obj4 = xe9707cb1ec88db49.xf7866f89640a29a3(2510 + num);
		if (obj != null || obj2 != null || obj3 != null || obj4 != null || x28ee2f81ab05fedb)
		{
			x8f3af96aa56f1e32 xca93abf9292cd4f = x9b287b671d592594.xca93abf9292cd4f1;
			xca93abf9292cd4f.x2307058321cdb62f(xb70432a39dd30653 ? "w:endnotePr" : "w:footnotePr");
			if (obj != null)
			{
				xca93abf9292cd4f.x547195bcc386fe66("w:pos", x93625b0e8808b0cc.x54b498efdd18d7e2((FootnoteLocation)obj, x5fbb1a9c98604ef5: true));
			}
			xca93abf9292cd4f.x547195bcc386fe66("w:numFmt", xc62574be95c1c918.x235742abf07b06ea(obj2));
			if (obj3 != null)
			{
				xca93abf9292cd4f.x24f8794502b580ff("w:numStart", (int)obj3, 1);
			}
			if (obj4 != null)
			{
				xca93abf9292cd4f.x547195bcc386fe66("w:numRestart", x93625b0e8808b0cc.xd0ad27372997d1d3((FootnoteNumberingRule)obj4, x5fbb1a9c98604ef5: true));
			}
			if (x28ee2f81ab05fedb)
			{
				xb1e23291670b6add(xb70432a39dd30653 ? x101cddc73c4f8cc2.x0affbe34bb1f8b8b : x101cddc73c4f8cc2.xa1e2a8ed32a026dd);
				xb1e23291670b6add((!xb70432a39dd30653) ? x101cddc73c4f8cc2.xeab6532eb0797a6e : x101cddc73c4f8cc2.x354a2c7b596483f1);
			}
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private void xb1e23291670b6add(x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		xa1e2a8ed32a026dd xa1e2a8ed32a026dd = x9b287b671d592594.x2c8c6741422a1298.x245aa7750b4a8072.get_xe6d4b1b411ed94b5(x781135a02d5b7a22);
		if (xa1e2a8ed32a026dd != null)
		{
			x1b12ad7e0ad0df34(x781135a02d5b7a22);
			xa1e2a8ed32a026dd.Accept(x9b287b671d592594);
			int xeaf1b27180c0557b = x29a51827c03d354b();
			x9b287b671d592594.x35c80635ff7a735b(xb70432a39dd30653 ? "w:endnote" : "w:footnote", xeaf1b27180c0557b);
		}
	}
}
