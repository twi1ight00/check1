using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x4bcc2af79ea00fbb : x16dabaa37d19a5ec
{
	internal override xc63cc34daaa2e2d9 x8b61531c8ea35b85()
	{
		return new x4bcc2af79ea00fbb();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x1bb348fb537231fc(this);
	}

	internal static x53cb1139c5c64ee6 x38a4dfa0549b295c(x398b3bd0acd94b61 xd7e5673853e47af4, x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (xd7e5673853e47af4 == null)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = x16dabaa37d19a5ec.x5658a0bfd852524d(xe3e287548b3d01f5, StoryType.Endnotes);
			if (x852fe8bb5ac31099 == null)
			{
				x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)xe3e287548b3d01f5.x2c8c6741422a1298.xe427d253f517c8ee.xa51d8d9790431b2b;
				if (x16dabaa37d19a5ec2 == null)
				{
					return null;
				}
				return x16dabaa37d19a5ec2.xa51d8d9790431b2b.x5a5e07e9fa12451a switch
				{
					x5a5e07e9fa12451a.xfdc1a17f479acc42 => (x53cb1139c5c64ee6)x16dabaa37d19a5ec2.xa51d8d9790431b2b.x8b8a0a04b3aeaf3a, 
					x5a5e07e9fa12451a.x25af49e7b49ea0bc => (x53cb1139c5c64ee6)((x7c1e2b821e8b8220)x16dabaa37d19a5ec2.xa51d8d9790431b2b).x5d6d04c35215bc51.x8b8a0a04b3aeaf3a, 
					_ => throw new InvalidOperationException("Unexpected layout type."), 
				};
			}
			xd7e5673853e47af4 = x852fe8bb5ac31099.xd90ac7fcbe961761.x7e2e5dd40daabc3b;
		}
		x53cb1139c5c64ee6 x53cb1139c5c64ee7 = xd7e5673853e47af4.xf34a54c031e96d83();
		if (x53cb1139c5c64ee7 == null)
		{
			return null;
		}
		x398b3bd0acd94b61 x398b3bd0acd94b62 = x16dabaa37d19a5ec.x22e642b5dff41b56(x53cb1139c5c64ee7).xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad);
		if (!x398b3bd0acd94b62.xe5764fe5359a6d91 && x398b3bd0acd94b62 != xe3e287548b3d01f5)
		{
			return null;
		}
		return x53cb1139c5c64ee7;
	}
}
