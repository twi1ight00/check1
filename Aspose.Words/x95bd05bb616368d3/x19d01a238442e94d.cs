using System;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using x8b1f7613579e78d0;
using x8bb6b4f09b5230a5;
using xeb326c6285a77ac1;

namespace x95bd05bb616368d3;

internal class x19d01a238442e94d : xaaf059f0543cf507, x407a499f03ae3f1d
{
	private xec86d47cfa7ad297 xf34ef61ecae1eb73;

	public x19d01a238442e94d(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public xec86d47cfa7ad297 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "path")
		{
			return null;
		}
		x4c28ef76f151d171(xe134235b3526fa75);
		xf34ef61ecae1eb73 = new xec86d47cfa7ad297();
		xe6dd7bd4e532d8a6();
		return xf34ef61ecae1eb73;
	}

	private void xe6dd7bd4e532d8a6()
	{
		xf34ef61ecae1eb73.xb0f146032f47c24e = x7450cc1e48712286.x075a63114fe24ce9("h", -1.0);
		xf34ef61ecae1eb73.xdc1bf80853046136 = x7450cc1e48712286.x075a63114fe24ce9("w", -1.0);
		xf34ef61ecae1eb73.x0e397c84d3b79406 = x7450cc1e48712286.x9c1302ecb6c4f3a2("stroke", xc6e85c82d0d89508: true);
		xf34ef61ecae1eb73.x4eada1f74f43bddb = x876dce608ff15d71();
		while (x7450cc1e48712286.x152cbadbfa8061b1("path"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "close":
				xf34ef61ecae1eb73.xcafb944334ef1589(x21ce40f6d5535570());
				break;
			case "lnTo":
				xf34ef61ecae1eb73.xcafb944334ef1589(x86f956b1509c3ac4());
				break;
			case "moveTo":
				xf34ef61ecae1eb73.xcafb944334ef1589(x1d5933887ce3d78a());
				break;
			case "arcTo":
				xf34ef61ecae1eb73.xcafb944334ef1589(x35c97a026c515417());
				break;
			case "cubicBezTo":
				xf34ef61ecae1eb73.xcafb944334ef1589(x5445f34b0279a8a9());
				break;
			case "quadBezTo":
				xf34ef61ecae1eb73.xcafb944334ef1589(xc44cb3ce5e9a0ecf());
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private xccd21a509fce5a08 x876dce608ff15d71()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("fill", string.Empty) switch
		{
			"darken" => xccd21a509fce5a08.x46da58b3de4e2839, 
			"darkenLess" => xccd21a509fce5a08.x552cd0de6020b826, 
			"lighten" => xccd21a509fce5a08.xee31dbe578530a23, 
			"lightenLess" => xccd21a509fce5a08.xcaa78dc1b39a80eb, 
			"norm" => xccd21a509fce5a08.x7bdafb93fe98d0b5, 
			"none" => xccd21a509fce5a08.x4d0b9d4447ba7566, 
			_ => xccd21a509fce5a08.x7bdafb93fe98d0b5, 
		};
	}

	private x87fba3f79fbaf7ab xc44cb3ce5e9a0ecf()
	{
		x1ca435fe7d1dbc75[] array = new x1ca435fe7d1dbc75[2];
		int num = 0;
		while (x7450cc1e48712286.x152cbadbfa8061b1("quadBezTo"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pt")
			{
				if (num < array.Length)
				{
					array[num] = x7e2a3c059f5793af();
					num++;
				}
				else
				{
					xf4732ad4641eec1a();
				}
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return new x4e3724aefd4e199f(array);
	}

	private x87fba3f79fbaf7ab x5445f34b0279a8a9()
	{
		x1ca435fe7d1dbc75[] array = new x1ca435fe7d1dbc75[3];
		int num = 0;
		while (x7450cc1e48712286.x152cbadbfa8061b1("cubicBezTo"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pt")
			{
				if (num < array.Length)
				{
					array[num] = x7e2a3c059f5793af();
					num++;
				}
				else
				{
					xf4732ad4641eec1a();
				}
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return new x12184623a2e428f7(array);
	}

	private x87fba3f79fbaf7ab x35c97a026c515417()
	{
		xbe6a1322275a795f xbe6a1322275a795f = new xbe6a1322275a795f();
		xbe6a1322275a795f.x611a32e0cc2af3c4 = new xb8ea2c3b3cf649a4(x7450cc1e48712286.xd68abcd61e368af9("hR", ""));
		xbe6a1322275a795f.x2a733472cd99828b = new xb8ea2c3b3cf649a4(x7450cc1e48712286.xd68abcd61e368af9("wR", ""));
		xbe6a1322275a795f.xba40a5b113d122a1 = new x4d94e8d9583fbd90(x7450cc1e48712286.xd68abcd61e368af9("stAng", ""));
		xbe6a1322275a795f.xd0e1bc5fa1ad3709 = new x4d94e8d9583fbd90(x7450cc1e48712286.xd68abcd61e368af9("swAng", ""));
		return xbe6a1322275a795f;
	}

	private x87fba3f79fbaf7ab x21ce40f6d5535570()
	{
		return new xf958427a037612b4();
	}

	private x87fba3f79fbaf7ab x86f956b1509c3ac4()
	{
		x70f47dd74bb70d3c x70f47dd74bb70d3c = new x70f47dd74bb70d3c();
		while (x7450cc1e48712286.x152cbadbfa8061b1("lnTo"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pt")
			{
				x70f47dd74bb70d3c.x865739e9b580d3cf = x7e2a3c059f5793af();
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x70f47dd74bb70d3c;
	}

	private x1ca435fe7d1dbc75 x7e2a3c059f5793af()
	{
		if (x7450cc1e48712286.xa66385d80d4d296f != "pt")
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("opijjbakdchkacokobflacmljmcmibkmiabnbainbapnklfoipmoeldpbalpnpbaepiagppajpgbcknbfoecoolciocddojddjaeeohefnoepmffhimflidgmnkgoibhinihphphfhgigmnialejdlljhhckggjkhjalikhlckolkffmofmmekdnfkknffboleiomjpogigpjinppdeafilamicbgdjbfiacfhhcohocphfdahmdghdeggkecgbfjcif", 419010747)));
		}
		string x = x7450cc1e48712286.xd68abcd61e368af9("x", string.Empty);
		string y = x7450cc1e48712286.xd68abcd61e368af9("y", string.Empty);
		return new x1ca435fe7d1dbc75(x, y);
	}

	private x87fba3f79fbaf7ab x1d5933887ce3d78a()
	{
		xcb67af79081bd342 xcb67af79081bd = new xcb67af79081bd342();
		while (x7450cc1e48712286.x152cbadbfa8061b1("moveTo"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pt")
			{
				xcb67af79081bd.x865739e9b580d3cf = x7e2a3c059f5793af();
				return xcb67af79081bd;
			}
			xf4732ad4641eec1a();
		}
		return xcb67af79081bd;
	}
}
