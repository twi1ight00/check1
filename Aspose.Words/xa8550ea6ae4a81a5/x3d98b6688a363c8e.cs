using Aspose.Words;

namespace xa8550ea6ae4a81a5;

internal class x3d98b6688a363c8e
{
	private readonly xaf66e8c590b2b553 x9b287b671d592594;

	private readonly x8f3af96aa56f1e32 x800085dd555f7711;

	internal x3d98b6688a363c8e(xaf66e8c590b2b553 writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = x9b287b671d592594.xa24813b526772a3b("comments.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.comments+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/comments");
		x800085dd555f7711.x454da6e050647673("w:comments");
	}

	internal void xd29409f2ba9889e2(Comment x77c5a31ec0891f38, int xe06efeff60ba61e5)
	{
		x800085dd555f7711.x2307058321cdb62f("w:comment");
		x800085dd555f7711.x943f6be3acf634db("w:id", xe06efeff60ba61e5);
		x800085dd555f7711.x943f6be3acf634db("w:author", x77c5a31ec0891f38.Author);
		x800085dd555f7711.x943f6be3acf634db("w:date", x77c5a31ec0891f38.DateTime);
		x800085dd555f7711.x943f6be3acf634db("w:initials", x77c5a31ec0891f38.Initial);
		x9b287b671d592594.xefc309b2831366cb(x800085dd555f7711);
	}

	internal void x685b1e5a342b26d7()
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		x9b287b671d592594.xa493f0b03338ab7a();
	}

	internal void x8ffe90e7fbccfccd()
	{
		x800085dd555f7711.xa0dfc102c691b11f();
	}
}
