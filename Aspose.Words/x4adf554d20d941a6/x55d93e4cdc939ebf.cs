using System;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x4adf554d20d941a6;

internal class x55d93e4cdc939ebf : xc0e747af79894e12
{
	private readonly TabAlignment xd576bc6491ccc0f5;

	private readonly x932d11b236987c0e x5d6e1fc3d9067a89;

	internal override bool xd685b0558e5e035b => true;

	internal TabAlignment x9ba359ff37a3a63b => xd576bc6491ccc0f5;

	internal x932d11b236987c0e x7073c129de8d5e65 => x5d6e1fc3d9067a89;

	internal static x55d93e4cdc939ebf xa7195540a6abf044(AbsolutePositionTab xdbad0d793277cfda)
	{
		x55d93e4cdc939ebf x55d93e4cdc939ebf2 = new x55d93e4cdc939ebf(x609f02056c47ef45(xdbad0d793277cfda.x9ba359ff37a3a63b), xdbad0d793277cfda.x7073c129de8d5e65);
		x55d93e4cdc939ebf2.x902d63c74e3c13c4 = x27fad8c7984b8feb(xdbad0d793277cfda.x312ff11290b951a5);
		return x55d93e4cdc939ebf2;
	}

	private x55d93e4cdc939ebf(TabAlignment tabAlignment, x932d11b236987c0e positioningBase)
	{
		xd576bc6491ccc0f5 = tabAlignment;
		x5d6e1fc3d9067a89 = positioningBase;
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x55d93e4cdc939ebf(xd576bc6491ccc0f5, x5d6e1fc3d9067a89);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	private static TabLeader x27fad8c7984b8feb(x84d41ac121232475 x01d1693fa395ce60)
	{
		return x01d1693fa395ce60 switch
		{
			x84d41ac121232475.x4d0b9d4447ba7566 => TabLeader.None, 
			x84d41ac121232475.x3cb6807e93737c2d => TabLeader.Dots, 
			x84d41ac121232475.x05249333ba886290 => TabLeader.Line, 
			x84d41ac121232475.xf15c6e29f02316fc => TabLeader.MiddleDot, 
			x84d41ac121232475.x8e836880cbe4ad3d => TabLeader.Dashes, 
			_ => throw new InvalidOperationException("Unexpected leader character value."), 
		};
	}

	private static TabAlignment x609f02056c47ef45(x55477ca1c0c8419f xda65ce9fa6b0e027)
	{
		return xda65ce9fa6b0e027 switch
		{
			x55477ca1c0c8419f.x72d92bd1aff02e37 => TabAlignment.Left, 
			x55477ca1c0c8419f.x419ba17a5322627b => TabAlignment.Right, 
			x55477ca1c0c8419f.x58d2ccae3c5cfd08 => TabAlignment.Center, 
			_ => throw new InvalidOperationException("Unexpected alignment value."), 
		};
	}
}
