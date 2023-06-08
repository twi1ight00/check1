using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;

namespace xfbd1009a0cbb9842;

internal class xca592a476766b11a : x5dc2b4bc740c9563
{
	private readonly x7c04dbcdccf44713 xbe1b3879b7d92a27;

	private readonly bool x4f93381471cfd5e0;

	internal xca592a476766b11a(Field field, string result)
		: this(field, result, null)
	{
	}

	internal xca592a476766b11a(Field field, string result, x57af31d8c74e631c cleanupAction)
		: this(field, result, cleanupAction, formatResult: true)
	{
	}

	internal xca592a476766b11a(Field field, string result, x57af31d8c74e631c cleanupAction, bool formatResult)
		: this(field, (result != null) ? new xe93eb88030ad2248(new xdfbdf8708b1e8b71(result)) : null, cleanupAction, formatResult)
	{
	}

	internal xca592a476766b11a(Field field, x82e26649b09596bd result)
		: this(field, result, null)
	{
	}

	internal xca592a476766b11a(Field field, x82e26649b09596bd result, x57af31d8c74e631c cleanupAction)
		: this(field, result, cleanupAction, formatResult: true)
	{
	}

	internal xca592a476766b11a(Field field, x82e26649b09596bd result, x57af31d8c74e631c cleanupAction, bool formatResult)
		: this(field, (result != null) ? new xe93eb88030ad2248(result) : null, cleanupAction, formatResult)
	{
	}

	internal xca592a476766b11a(Field field, x7c04dbcdccf44713 result)
		: this(field, result, null, formatResult: true)
	{
	}

	private xca592a476766b11a(Field field, x7c04dbcdccf44713 result, x57af31d8c74e631c cleanupAction, bool formatResult)
		: base(field, cleanupAction)
	{
		xbe1b3879b7d92a27 = result;
		x4f93381471cfd5e0 = formatResult;
	}

	protected override void PerformCore()
	{
		xf83652aff352c801 xf83652aff352c802 = xc7e8ef87526d9280();
		xf83652aff352c802.x7d44c41f397d72e0();
		base.xd1b40af56a8385d4.x6edce55dcd2d335b.xac51c2571643df46();
	}

	private xf83652aff352c801 xc7e8ef87526d9280()
	{
		if (xbe1b3879b7d92a27 != null)
		{
			x82e26649b09596bd x82e26649b09596bd = xbe1b3879b7d92a27.x297a08accbde149a();
			string x7d95d971d8923f4c = x82e26649b09596bd.xf6e2349738d2d14e;
			if (x7d95d971d8923f4c == null)
			{
				return new xe3b2513ab4d5789d(base.xd1b40af56a8385d4, string.Empty);
			}
			bool flag = false;
			if (x4f93381471cfd5e0)
			{
				flag = base.xd1b40af56a8385d4.xa890d2fd18bed2bc.xd4f20c6c3f6afa2f(x82e26649b09596bd, out x7d95d971d8923f4c);
			}
			x7e263f21a73a027a x7e263f21a73a027a = xbe1b3879b7d92a27.x2eb30ee04563e9e4();
			if (x7e263f21a73a027a == null || flag)
			{
				return new xe3b2513ab4d5789d(base.xd1b40af56a8385d4, x7d95d971d8923f4c);
			}
			return new x54b0ce4be209efe2(base.xd1b40af56a8385d4, x7e263f21a73a027a);
		}
		return new xe3b2513ab4d5789d(base.xd1b40af56a8385d4, string.Empty);
	}
}
