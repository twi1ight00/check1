using System.Collections;
using x24ed092a62874e86;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;

namespace x95bd05bb616368d3;

internal class xd13db1e4c9fb8129 : xaaf059f0543cf507, xaeaeae8d38ef57bb
{
	public xd13db1e4c9fb8129(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public xd7e8497b32a408b8 x07d1b52af8293592(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		xd7e8497b32a408b8 result = null;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "hslClr":
			case "prstClr":
			case "schemeClr":
			case "scrgbClr":
			case "srgbClr":
			case "sysClr":
			{
				xd7e8497b32a408b8 xd7e8497b32a408b = xda09af88ab899a50(x7450cc1e48712286);
				if (xd7e8497b32a408b != null)
				{
					result = xd7e8497b32a408b;
				}
				break;
			}
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return result;
	}

	public xd7e8497b32a408b8 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x7450cc1e48712286 = xe134235b3526fa75;
		switch (xe134235b3526fa75.xa66385d80d4d296f)
		{
		case "hslClr":
			return x47221aab6bd62430();
		case "prstClr":
			return x650553853b146483();
		case "schemeClr":
			return x78f622d07782ebcc();
		case "scrgbClr":
			return xb6794daa98afbff3();
		case "srgbClr":
			return x1615df8d563577dd();
		case "sysClr":
			return x3359c6383e32debc();
		default:
			xf4732ad4641eec1a();
			return null;
		}
	}

	private x8af6aafe8486541b x3359c6383e32debc()
	{
		x84984d61907ac93b x84984d61907ac93b = new x84984d61907ac93b();
		x84984d61907ac93b.xd2f68ee6f47e9dfb = x7450cc1e48712286.xd68abcd61e368af9("val", string.Empty);
		x84984d61907ac93b.x30f7758261c05307 = x7450cc1e48712286.xd68abcd61e368af9("lastClr", string.Empty);
		x84984d61907ac93b.x30f0af038def5996 = x50be341bb458b0c6();
		return x84984d61907ac93b;
	}

	private ArrayList x50be341bb458b0c6()
	{
		ArrayList arrayList = new ArrayList();
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "alpha":
				arrayList.Add(x940e6d17f718210c(new x86a4db3e9a089c0a()));
				break;
			case "alphaMod":
				arrayList.Add(x940e6d17f718210c(new xb64e015649896bed()));
				break;
			case "alphaOff":
				arrayList.Add(x940e6d17f718210c(new xe8f6cba8e89af24e()));
				break;
			case "blue":
				arrayList.Add(x940e6d17f718210c(new x5fa03a583ae2ff47()));
				break;
			case "blueMod":
				arrayList.Add(x940e6d17f718210c(new x8c18ec10b870e15e()));
				break;
			case "blueOff":
				arrayList.Add(x940e6d17f718210c(new x903accb2ce96425e()));
				break;
			case "comp":
				arrayList.Add(new xd9f536f2549e163f());
				break;
			case "gamma":
				arrayList.Add(new x88e96b64b6c7d03e());
				break;
			case "gray":
				arrayList.Add(new x5931cdced4e5b9fc());
				break;
			case "green":
				arrayList.Add(x940e6d17f718210c(new x545b3772412853b6()));
				break;
			case "greenMod":
				arrayList.Add(x940e6d17f718210c(new x9888b46e76882a2e()));
				break;
			case "greenOff":
				arrayList.Add(x940e6d17f718210c(new x8013931155ba44e0()));
				break;
			case "hue":
				xf413544a9c6d7fa3(arrayList);
				break;
			case "hueMod":
				arrayList.Add(x940e6d17f718210c(new x049e12a7ccbcb2a8()));
				break;
			case "hueOff":
				x9f2b0691e586a8aa(arrayList);
				break;
			case "inv":
				arrayList.Add(new xb2b66b389ec6d0b0());
				break;
			case "invGamma":
				arrayList.Add(new x15f83e5fe13bd1b6());
				break;
			case "lum":
				arrayList.Add(x940e6d17f718210c(new x5b299acd5d7d70c7()));
				break;
			case "lumMod":
				arrayList.Add(x940e6d17f718210c(new xf0b0c0d28cb0daa5()));
				break;
			case "lumOff":
				arrayList.Add(x940e6d17f718210c(new x6393a0cf0b7b6431()));
				break;
			case "red":
				arrayList.Add(x940e6d17f718210c(new x4a74b2a3de6ddd7b()));
				break;
			case "redMod":
				arrayList.Add(x940e6d17f718210c(new xf8c6b3095f9f1f0e()));
				break;
			case "redOff":
				arrayList.Add(x940e6d17f718210c(new xfa29fad4331cc993()));
				break;
			case "sat":
				arrayList.Add(x940e6d17f718210c(new xeabc4e6733ca7393()));
				break;
			case "satMod":
				arrayList.Add(x940e6d17f718210c(new xb454e9af12fa5b78()));
				break;
			case "satOff":
				arrayList.Add(x940e6d17f718210c(new xc57907f8278f6864()));
				break;
			case "shade":
				arrayList.Add(x940e6d17f718210c(new xc11f878785193b2d()));
				break;
			case "tint":
				arrayList.Add(x940e6d17f718210c(new x3e6f71e8c6a41a90()));
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return arrayList;
	}

	private x94368fc8535b3ca3 x940e6d17f718210c(x94368fc8535b3ca3 xcbf24c118ac8aa0b)
	{
		xcbf24c118ac8aa0b.xd2f68ee6f47e9dfb = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("val", 0.0));
		return xcbf24c118ac8aa0b;
	}

	private void x9f2b0691e586a8aa(ArrayList xba940936c4175a5d)
	{
		x7e9c4414aba19bfb x7e9c4414aba19bfb = new x7e9c4414aba19bfb();
		x7e9c4414aba19bfb.xd2f68ee6f47e9dfb = new xd4583a58cd9d2194(x7450cc1e48712286.x075a63114fe24ce9("val", 0.0));
		xba940936c4175a5d.Add(x7e9c4414aba19bfb);
	}

	private void xf413544a9c6d7fa3(ArrayList xba940936c4175a5d)
	{
		x62fed6c85da141d9 x62fed6c85da141d = new x62fed6c85da141d9();
		x62fed6c85da141d.xd2f68ee6f47e9dfb = new xd4583a58cd9d2194(x7450cc1e48712286.x075a63114fe24ce9("val", 0.0));
		xba940936c4175a5d.Add(x62fed6c85da141d);
	}

	private x8af6aafe8486541b x1615df8d563577dd()
	{
		x43287db0aa155c99 x43287db0aa155c = new x43287db0aa155c99();
		x43287db0aa155c.xd2f68ee6f47e9dfb = x7450cc1e48712286.xd68abcd61e368af9("val", string.Empty);
		x43287db0aa155c.x30f0af038def5996 = x50be341bb458b0c6();
		return x43287db0aa155c;
	}

	private x8af6aafe8486541b xb6794daa98afbff3()
	{
		xc91d0185e1aca5ef xc91d0185e1aca5ef = new xc91d0185e1aca5ef();
		xc91d0185e1aca5ef.xc613adc4330033f3 = new x2f7951fa0946af7e(x7450cc1e48712286.xd68abcd61e368af9("r", string.Empty));
		xc91d0185e1aca5ef.x26463655896fd90a = new x2f7951fa0946af7e(x7450cc1e48712286.xd68abcd61e368af9("g", string.Empty));
		xc91d0185e1aca5ef.x8e8f6cc6a0756b05 = new x2f7951fa0946af7e(x7450cc1e48712286.xd68abcd61e368af9("b", string.Empty));
		xc91d0185e1aca5ef.x30f0af038def5996 = x50be341bb458b0c6();
		return xc91d0185e1aca5ef;
	}

	private xd7e8497b32a408b8 x78f622d07782ebcc()
	{
		string text = x7450cc1e48712286.xd68abcd61e368af9("val", string.Empty);
		if (text == "phClr")
		{
			x18eebb9e98608d0f x18eebb9e98608d0f = new x18eebb9e98608d0f();
			x18eebb9e98608d0f.x30f0af038def5996 = x50be341bb458b0c6();
			return x18eebb9e98608d0f;
		}
		xe9514243265b8af5 xe9514243265b8af = new xe9514243265b8af5();
		xe9514243265b8af.xd2f68ee6f47e9dfb = x9d4a08280e770f8e.xb0c325557cbfd6d3(text);
		xe9514243265b8af.x30f0af038def5996 = x50be341bb458b0c6();
		return xe9514243265b8af;
	}

	private x8af6aafe8486541b x650553853b146483()
	{
		xc462a5f128c04d43 xc462a5f128c04d = new xc462a5f128c04d43();
		xc462a5f128c04d.xd2f68ee6f47e9dfb = x7450cc1e48712286.xd68abcd61e368af9("val", string.Empty);
		xc462a5f128c04d.x30f0af038def5996 = x50be341bb458b0c6();
		return xc462a5f128c04d;
	}

	private x8af6aafe8486541b x47221aab6bd62430()
	{
		x6cb7226b3d1f6744 x6cb7226b3d1f = new x6cb7226b3d1f6744();
		x6cb7226b3d1f.x771e11bd2ca66cba = new xd4583a58cd9d2194(x7450cc1e48712286.xe8602379c60acf13("hue", 0));
		x6cb7226b3d1f.x5977e61981871b60 = new x2f7951fa0946af7e(x7450cc1e48712286.xd68abcd61e368af9("lum", string.Empty));
		x6cb7226b3d1f.xa93394e415277432 = new x2f7951fa0946af7e(x7450cc1e48712286.xd68abcd61e368af9("sat", string.Empty));
		x6cb7226b3d1f.x30f0af038def5996 = x50be341bb458b0c6();
		return x6cb7226b3d1f;
	}
}
