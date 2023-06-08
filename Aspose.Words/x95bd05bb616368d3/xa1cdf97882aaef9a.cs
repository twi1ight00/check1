using System;
using x32a884d842a34446;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace x95bd05bb616368d3;

internal class xa1cdf97882aaef9a : xaaf059f0543cf507
{
	private x7f84d4dc848984c4 xbf75d3b5a3503112;

	private x7f84d4dc848984c4 xa838333cf20f52ea
	{
		get
		{
			if (xbf75d3b5a3503112 == null)
			{
				xbf75d3b5a3503112 = new x7f84d4dc848984c4(base.xca687bd498227c89);
			}
			return xbf75d3b5a3503112;
		}
	}

	public xa1cdf97882aaef9a(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public xf6f80e59810bad00 xda09af88ab899a50(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f;
		x7f5d21c69e6fc0b2 axisType = x9e59067ab85cc94a(xa66385d80d4d296f);
		xf6f80e59810bad00 xf6f80e59810bad = new xf6f80e59810bad00(axisType);
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "axId":
				xf6f80e59810bad.xb1cd0e7571a46f8e = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "scaling":
				xf6f80e59810bad.x5e7a899338a3ee20 = xa838333cf20f52ea.x87e3c40d67cf7919(x7450cc1e48712286);
				break;
			case "delete":
				xf6f80e59810bad.xddae736767606eb7 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "axPos":
				xf6f80e59810bad.x81597796c74b4b6b = xa74237a39984bb17.x0bbfb02a128903df(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "majorGridlines":
				xf6f80e59810bad.x3d64cd96ed6b6560 = x20fe7c4c03fa08d1("majorGridlines");
				break;
			case "minorGridlines":
				xf6f80e59810bad.xea05d1e07dc79104 = x20fe7c4c03fa08d1("minorGridlines");
				break;
			case "title":
				xf6f80e59810bad.x238bf167ccfdd282 = xa838333cf20f52ea.xbcea82b01777a36c(x7450cc1e48712286);
				break;
			case "numFmt":
				xf6f80e59810bad.x681e77d00e298fba = xa838333cf20f52ea.xb701216be6c44a7c(x7450cc1e48712286);
				break;
			case "majorTickMark":
				xf6f80e59810bad.xcfae2c98e0648e49 = xa74237a39984bb17.x188bd49a20049289(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "minorTickMark":
				xf6f80e59810bad.x5075a0312663bf11 = xa74237a39984bb17.x188bd49a20049289(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "tickLblPos":
				xf6f80e59810bad.xa0e36606edf7b5ff = xa74237a39984bb17.x3e905e37401f6551(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "spPr":
				xa838333cf20f52ea.xdb3e183f8621de35(x7450cc1e48712286, xf6f80e59810bad.xff13b489d81606b6);
				break;
			case "txPr":
				xa838333cf20f52ea.x10a86a9a76e8d159(x7450cc1e48712286, xf6f80e59810bad.x68955bfadd010132);
				break;
			case "crossAx":
				xf6f80e59810bad.x456aa8157ebf3510 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "crosses":
				xf6f80e59810bad.xd39f61969d3b123a = xa74237a39984bb17.x29c7326e701e7f74(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "crossesAt":
				xf6f80e59810bad.xc9462fcea63eb739 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "crossBetween":
				xf6f80e59810bad.x04597362da04ff8e = xa74237a39984bb17.xbef6caffe704a43e(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "majorUnit":
				xf6f80e59810bad.x9b9b92fa65560fec = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "minorUnit":
				xf6f80e59810bad.xb6533e8a4b581ffe = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "dispUnits":
				xf6f80e59810bad.x21ffddc693b7c826 = xa838333cf20f52ea.x031e0e5ffb5cf948(x7450cc1e48712286);
				break;
			case "auto":
				xf6f80e59810bad.x2bca50d746ec73b2 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "lblAlgn":
				xf6f80e59810bad.x51d365d9c81baea3 = xa74237a39984bb17.x617f790e38378ced(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "lblOffset":
				xf6f80e59810bad.xda3b208c694708c9 = x7450cc1e48712286.xe8602379c60acf13("val", 100);
				break;
			case "tickLblSkip":
				xf6f80e59810bad.xb9b399cea19c7469 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "tickMarkSkip":
				xf6f80e59810bad.x4934123ef40c05ee = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "noMultiLvlLbl":
				xf6f80e59810bad.x2bca50d746ec73b2 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "baseTimeUnit":
				xf6f80e59810bad.x32c98d5392e5cd3d = xa74237a39984bb17.xb17fa4cb7616c8fd(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "majorTimeUnit":
				xf6f80e59810bad.xe3cef1ba55d91799 = xa74237a39984bb17.xb17fa4cb7616c8fd(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "minorTimeUnit":
				xf6f80e59810bad.x119a350f3939ff30 = xa74237a39984bb17.xb17fa4cb7616c8fd(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xf6f80e59810bad;
	}

	private xbc46977eebea4733 x20fe7c4c03fa08d1(string x91ef5ae2997ab6c4)
	{
		xbc46977eebea4733 xbc46977eebea = new xbc46977eebea4733();
		while (x7450cc1e48712286.x152cbadbfa8061b1(x91ef5ae2997ab6c4))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "spPr")
			{
				xa838333cf20f52ea.xdb3e183f8621de35(x7450cc1e48712286, xbc46977eebea);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return xbc46977eebea;
	}

	private static x7f5d21c69e6fc0b2 x9e59067ab85cc94a(string x91ef5ae2997ab6c4)
	{
		return x91ef5ae2997ab6c4 switch
		{
			"catAx" => x7f5d21c69e6fc0b2.x9ee8adcec1e2f351, 
			"dateAx" => x7f5d21c69e6fc0b2.x197c47a24c81f695, 
			"serAx" => x7f5d21c69e6fc0b2.xc869533ad93d98d3, 
			"valAx" => x7f5d21c69e6fc0b2.xd2f68ee6f47e9dfb, 
			_ => throw new ArgumentException("Unexpected axis type."), 
		};
	}
}
