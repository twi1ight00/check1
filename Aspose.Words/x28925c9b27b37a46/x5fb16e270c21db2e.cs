using System;
using System.ComponentModel;

namespace x28925c9b27b37a46;

internal class x5fb16e270c21db2e : xbe47717e2fd4172a, x11e014059489ae95
{
	private x7f77ea92be0d9042 x1a2104e6abbe298f;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool xc8ea2954a6825f32 => false;

	internal x7f77ea92be0d9042 xdf4bcc85da8f85b2 => x1a2104e6abbe298f;

	internal x5fb16e270c21db2e(x7f77ea92be0d9042 revPr, string author, DateTime dateTime)
		: base(author, dateTime)
	{
		if (revPr == null)
		{
			throw new ArgumentNullException("revPr");
		}
		if (author == null)
		{
			throw new ArgumentNullException("author");
		}
		x1a2104e6abbe298f = revPr;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	private x11e014059489ae95 xa9c9dc40c97ccfd0()
	{
		x5fb16e270c21db2e x5fb16e270c21db2e2 = (x5fb16e270c21db2e)MemberwiseClone();
		x5fb16e270c21db2e2.x1a2104e6abbe298f = (x7f77ea92be0d9042)x1a2104e6abbe298f.x8b61531c8ea35b85();
		return x5fb16e270c21db2e2;
	}

	x11e014059489ae95 x11e014059489ae95.xcc4933610939ad04()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa9c9dc40c97ccfd0
		return this.xa9c9dc40c97ccfd0();
	}
}
