using System;
using System.Collections;
using Aspose.Words.Fields;
using x2a6f63b6650e76c4;

namespace xfbd1009a0cbb9842;

internal class xfedf115fd9c03862
{
	private readonly ArrayList x9a3b89d2367b5e4b = new ArrayList();

	private readonly ArrayList x478afbc35b669ae8 = new ArrayList();

	private readonly Hashtable x9bf53a7fc757a77f = new Hashtable();

	private xcf417e2db4fe9ed3 x2f6384ddc128cdaa;

	internal ArrayList xd0803398bc61def5 => x478afbc35b669ae8;

	internal xfedf115fd9c03862()
	{
	}

	internal xfedf115fd9c03862(Field field)
	{
		xbf9ddf72e1283af9 xbf9ddf72e1283af10 = xe6991fa521939c73(xcf417e2db4fe9ed3.xa370a6f48a445ff9);
		xbf9ddf72e1283af10.x69dc2014b9eea9e3(field);
	}

	internal xfedf115fd9c03862(x6435b7bbb0879a04 fields)
	{
		x9bf53a7fc757a77f[xcf417e2db4fe9ed3.xa370a6f48a445ff9] = new xbf9ddf72e1283af9(this, fields);
	}

	internal void xb7abe6d71d9b4488(x13d974d3119bccb2 xa17608be6f3e3287)
	{
		x9a3b89d2367b5e4b.Add(xa17608be6f3e3287);
	}

	internal void xa0ab61ba0ad5683f(xc0f77867ac6b6a92 x49432508d78271dd)
	{
		x478afbc35b669ae8.Add(x49432508d78271dd);
	}

	internal void x31985aa8d57a7b7e(x13d974d3119bccb2 xa17608be6f3e3287)
	{
		x9a3b89d2367b5e4b.Remove(xa17608be6f3e3287);
	}

	internal void xbf6830df94a05495(xc0f77867ac6b6a92 x49432508d78271dd)
	{
		x478afbc35b669ae8.Remove(x49432508d78271dd);
	}

	internal void x384c03e4298b53bf()
	{
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.xa370a6f48a445ff9);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.xa4eb7166eb7f09b4);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x5a360e1cee7f2c61);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x290a7f421b080483);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x9fd888e65466818c);
	}

	internal void xdf269951086089ce(x6435b7bbb0879a04 xa942970cc8a85fd4)
	{
		x9bf53a7fc757a77f[xcf417e2db4fe9ed3.xa370a6f48a445ff9] = new xbf9ddf72e1283af9(this, xa942970cc8a85fd4);
		x9bf53a7fc757a77f.Remove(xcf417e2db4fe9ed3.xa4eb7166eb7f09b4);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.xa370a6f48a445ff9);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.xa4eb7166eb7f09b4);
	}

	internal void x118a2acc122f2bb3()
	{
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x5a360e1cee7f2c61);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x290a7f421b080483);
		xdd6cf0348a23f220(xcf417e2db4fe9ed3.x9fd888e65466818c);
	}

	private void xdd6cf0348a23f220(xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		x2f6384ddc128cdaa = xe00c282e1a49fcfb;
		foreach (x13d974d3119bccb2 item in x9a3b89d2367b5e4b)
		{
			item.x9d0488f6bfd3c0b3(xe00c282e1a49fcfb);
		}
		((xbf9ddf72e1283af9)x9bf53a7fc757a77f[xe00c282e1a49fcfb])?.x18dfca7c5fd2402f();
	}

	internal void x4e3cfc222c92cda7(Field xe01ae93d9fe5a880)
	{
		x4e3cfc222c92cda7(xe01ae93d9fe5a880, null);
	}

	internal x98c1867b219333bc x4e3cfc222c92cda7(Field xe01ae93d9fe5a880, x5e36356bc92c609b x0f7b23d1c393aed9)
	{
		x7685e6f393e64c44 x7685e6f393e64c45 = null;
		if (x9a3b89d2367b5e4b.Count > 0)
		{
			bool x39b88a192280e4dd = x0f7b23d1c393aed9?.x752cfab9af626fd5 ?? false;
			foreach (x13d974d3119bccb2 item in x9a3b89d2367b5e4b)
			{
				x7685e6f393e64c45 = item.xc18d99c2ffb751c0(xe01ae93d9fe5a880, x39b88a192280e4dd);
				switch (x7685e6f393e64c45.xc9f7f27afb00c0ce)
				{
				case x261cafdff9716109.x1a2ddf6ed77d277c:
					return new x98c1867b219333bc(xcf417e2db4fe9ed3.xa4eb7166eb7f09b4, isUpdated: false);
				case x261cafdff9716109.xcc32d73386110a60:
					return new x98c1867b219333bc(isUpdated: false);
				default:
					throw new ArgumentOutOfRangeException();
				case x261cafdff9716109.x295cb4a1df7a5add:
					break;
				}
			}
		}
		Field field = ((x7685e6f393e64c45 != null) ? x7685e6f393e64c45.xd1b40af56a8385d4 : xe01ae93d9fe5a880);
		if (x0f7b23d1c393aed9 == null || xe01ae93d9fe5a880 != field)
		{
			x0f7b23d1c393aed9 = new x5e36356bc92c609b(field, this);
		}
		return field.x295cb4a1df7a5add(x0f7b23d1c393aed9);
	}

	private xbf9ddf72e1283af9 xe6991fa521939c73(xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		if (x9bf53a7fc757a77f[xe00c282e1a49fcfb] == null)
		{
			x9bf53a7fc757a77f[xe00c282e1a49fcfb] = new xbf9ddf72e1283af9(this);
		}
		return (xbf9ddf72e1283af9)x9bf53a7fc757a77f[xe00c282e1a49fcfb];
	}

	internal void x874035a07982e6e7(xa7114c309aebe17d xab8fe3cd8c5556fb)
	{
		x874035a07982e6e7(xab8fe3cd8c5556fb, x2f6384ddc128cdaa);
	}

	internal void x874035a07982e6e7(xa7114c309aebe17d xab8fe3cd8c5556fb, xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		xbf9ddf72e1283af9 xbf9ddf72e1283af10 = xe6991fa521939c73(xe00c282e1a49fcfb);
		if (xbf9ddf72e1283af10.xe06bf41f3e53680c(xab8fe3cd8c5556fb) && xe00c282e1a49fcfb == x2f6384ddc128cdaa)
		{
			xab8fe3cd8c5556fb.xb333e1e6c01c2be2();
		}
	}

	internal bool xcf4268d5a79e653b(Field xe01ae93d9fe5a880, xcf417e2db4fe9ed3 xe00c282e1a49fcfb)
	{
		if (xe00c282e1a49fcfb == xcf417e2db4fe9ed3.x35cfcea4890f4e7d || xe00c282e1a49fcfb == x2f6384ddc128cdaa)
		{
			return false;
		}
		xbf9ddf72e1283af9 xbf9ddf72e1283af10 = xe6991fa521939c73(xe00c282e1a49fcfb);
		return xbf9ddf72e1283af10.x69dc2014b9eea9e3(xe01ae93d9fe5a880);
	}

	internal x82e26649b09596bd x803fdc6662fa3f31(Field xe01ae93d9fe5a880)
	{
		foreach (xc0f77867ac6b6a92 item in x478afbc35b669ae8)
		{
			x82e26649b09596bd x82e26649b09596bd = item.x3f88a25febd23896(xe01ae93d9fe5a880);
			if (x82e26649b09596bd != null)
			{
				return x82e26649b09596bd;
			}
		}
		return null;
	}

	internal object xc1acbb49fa87a8a3(Field xe01ae93d9fe5a880)
	{
		foreach (xc0f77867ac6b6a92 item in x478afbc35b669ae8)
		{
			object obj = item.xd378208b5267f7e2(xe01ae93d9fe5a880);
			if (obj != null)
			{
				return obj;
			}
		}
		return null;
	}
}
