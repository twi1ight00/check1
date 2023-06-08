using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides;
using ns24;

namespace ns4;

internal class Class146 : IEnumerable
{
	private Dictionary<Guid, Class144> dictionary_0 = new Dictionary<Guid, Class144>();

	private Presentation presentation_0;

	private Class354 class354_0 = new Class354();

	private static readonly Dictionary<Guid, TableStylePreset> dictionary_1;

	private static readonly Dictionary<TableStylePreset, Guid> dictionary_2;

	internal Class354 PPTXUnsupportedProps => class354_0;

	public IPresentationComponent Parent => presentation_0;

	internal Class144 DefaultStyle => method_0(PPTXUnsupportedProps.DefaultStyleId);

	internal Class146(Presentation parent)
		: this()
	{
		presentation_0 = parent;
	}

	internal Class146()
	{
		PPTXUnsupportedProps.DefaultStyleId = new Guid("5C22544A-7EE6-4342-B048-85BDC9FD1C3A");
	}

	internal Class144 method_0(Guid guid)
	{
		Class144 @class = null;
		if (dictionary_0.ContainsKey(guid))
		{
			@class = dictionary_0[guid];
		}
		if (@class != null)
		{
			return @class;
		}
		TableStylePreset tableStylePreset = method_1(guid);
		if (tableStylePreset == TableStylePreset.Custom)
		{
			return null;
		}
		return Class1076.smethod_0(this, tableStylePreset);
	}

	public TableStylePreset method_1(Guid guid)
	{
		object obj = null;
		if (dictionary_1.ContainsKey(guid))
		{
			obj = dictionary_1[guid];
		}
		if (obj == null)
		{
			return TableStylePreset.Custom;
		}
		return (TableStylePreset)obj;
	}

	public Guid method_2(TableStylePreset preset)
	{
		object obj = null;
		if (dictionary_2.ContainsKey(preset))
		{
			obj = dictionary_2[preset];
		}
		if (obj == null)
		{
			return Guid.Empty;
		}
		return (Guid)obj;
	}

	static Class146()
	{
		dictionary_1 = new Dictionary<Guid, TableStylePreset>();
		dictionary_2 = new Dictionary<TableStylePreset, Guid>();
		smethod_0(TableStylePreset.MediumStyle2Accent1, new Guid(1545753674, 32486, 17218, 176, 72, 133, 189, 201, 253, 28, 58), "Medium Style 2 - Accent 1");
		smethod_0(TableStylePreset.MediumStyle2, new Guid(121245098, 27379, 17323, 133, 136, 206, 193, 208, 108, 114, 185), "Medium Style 2");
		smethod_0(TableStylePreset.NoStyleNoGrid, new Guid(760920870, 1415, 19504, 137, 153, 146, 248, 31, 208, 48, 124), "No Style, No Grid");
		smethod_0(TableStylePreset.ThemedStyle1Accent1, new Guid(1009777245u, 34740, 17770, 152, 33, 29, 80, 36, 104, 207, 15), "Themed Style 1 - Accent 1");
		smethod_0(TableStylePreset.ThemedStyle1Accent2, new Guid(676217466, 15701, 17155, 191, 128, 100, 85, 3, 110, 29, 231), "Themed Style 1 - Accent 2");
		smethod_0(TableStylePreset.ThemedStyle1Accent3, new Guid(1774683452, 21357, 19062, 160, 174, 221, 34, 18, 77, 85, 165), "Themed Style 1 - Accent 3");
		smethod_0(TableStylePreset.ThemedStyle1Accent4, new Guid(2002635522u, 39864, 18429, 137, 7, 133, 199, 148, 247, 147, 186), "Themed Style 1 - Accent 4");
		smethod_0(TableStylePreset.ThemedStyle1Accent5, new Guid(896896951u, 39621, 17746, 138, 83, 201, 24, 5, 229, 71, 250), "Themed Style 1 - Accent 5");
		smethod_0(TableStylePreset.ThemedStyle1Accent6, new Guid(150700925u, 51239, 20218, 160, 87, 77, 5, 128, 126, 15, 124), "Themed Style 1 - Accent 6");
		smethod_0(TableStylePreset.NoStyleTableGrid, new Guid(1497392986u, 46457, 17934, 148, 209, 84, 34, 44, 99, 245, 218), "No Style, Table Grid");
		smethod_0(TableStylePreset.ThemedStyle2Accent1, new Guid(3507726802u, 40299, 18729, 170, 45, 242, 59, 94, 232, 203, 231), "Themed Style 2 - Accent 1");
		smethod_0(TableStylePreset.ThemedStyle2Accent2, new Guid(408960988u, 58154, 19125, 152, 156, 8, 100, 195, 234, 210, 184), "Themed Style 2 - Accent 2");
		smethod_0(TableStylePreset.ThemedStyle2Accent3, new Guid(812095992, 1886, 19002, 167, 246, 127, 188, 101, 118, 241, 164), "Themed Style 2 - Accent 3");
		smethod_0(TableStylePreset.ThemedStyle2Accent4, new Guid(3798585374u, 48178, 16457, 180, 99, 92, 96, 215, 176, 204, 210), "Themed Style 2 - Accent 4");
		smethod_0(TableStylePreset.ThemedStyle2Accent5, new Guid(847222715u, 51251, 20407, 189, 229, 63, 112, 117, 3, 70, 144), "Themed Style 2 - Accent 5");
		smethod_0(TableStylePreset.ThemedStyle2Accent6, new Guid(1670060117, 7029, 20414, 147, 12, 57, 139, 168, 194, 83, 198), "Themed Style 2 - Accent 6");
		smethod_0(TableStylePreset.LightStyle1, new Guid(2642093765u, 16647, 20460, 174, 220, 23, 22, 178, 80, 161, 239), "Light Style 1");
		smethod_0(TableStylePreset.LightStyle1Accent1, new Guid(994810032, 24748, 17090, 175, 165, 181, 140, 215, 127, 161, 229), "Light Style 1 - Accent 1");
		smethod_0(TableStylePreset.LightStyle1Accent2, new Guid(239066693u, 44919, 19292, 151, 21, 73, 213, 148, 189, 240, 94), "Light Style 1 - Accent 2");
		smethod_0(TableStylePreset.LightStyle1Accent3, new Guid(3229869795u, 64125, 19835, 165, 149, 239, 146, 37, 175, 234, 130), "Light Style 1 - Accent 3");
		smethod_0(TableStylePreset.LightStyle1Accent4, new Guid(3530621609u, 33552, 18277, 169, 53, 161, 145, 27, 0, 202, 85), "Light Style 1 - Accent 4");
		smethod_0(TableStylePreset.LightStyle2Accent5, new Guid(1511069973u, 48694, 19969, 167, 229, 4, 177, 103, 46, 173, 50), "Light Style 2 - Accent 5");
		smethod_0(TableStylePreset.LightStyle1Accent6, new Guid(1758605555u, 53120, 18521, 140, 231, 164, 62, 232, 25, 147, 181), "Light Style 1 - Accent 6");
		smethod_0(TableStylePreset.LightStyle2, new Guid(2123774420u, 58338, 19764, 146, 132, 90, 33, 149, 179, 208, 215), "Light Style 2");
		smethod_0(TableStylePreset.LightStyle2Accent1, new Guid(1761685197, 20988, 16881, 170, 141, 27, 36, 131, 205, 102, 62), "Light Style 2 - Accent 1");
		smethod_0(TableStylePreset.LightStyle2Accent2, new Guid(1921202178u, 65265, 19577, 141, 93, 20, 207, 30, 175, 152, 217), "Light Style 2 - Accent 2");
		smethod_0(TableStylePreset.LightStyle2Accent3, new Guid(4074660821u, 39290, 17990, 163, 119, 71, 2, 103, 58, 114, 141), "Light Style 2 - Accent 3");
		smethod_0(TableStylePreset.MediumStyle2Accent3, new Guid(4121631849u, 28379, 20468, 152, 63, 24, 189, 33, 158, 243, 34), "Medium Style 2 - Accent 3");
		smethod_0(TableStylePreset.MediumStyle2Accent4, new Guid(10574933u, 34071, 17066, 182, 20, 233, 185, 73, 16, 227, 147), "Medium Style 2 - Accent 4");
		smethod_0(TableStylePreset.MediumStyle2Accent5, new Guid(2112980608u, 57428, 16813, 139, 193, 209, 174, 247, 114, 68, 13), "Medium Style 2 - Accent 5");
		smethod_0(TableStylePreset.LightStyle2Accent6, new Guid(2435615877u, 20976, 18718, 151, 116, 57, 0, 175, 239, 15, 215), "Light Style 2 - Accent 6");
		smethod_0(TableStylePreset.LightStyle2Accent4, new Guid(388573742u, 62259, 17403, 150, 33, 92, 187, 231, 253, 205, 203), "Light Style 2 - Accent 4");
		smethod_0(TableStylePreset.LightStyle3, new Guid(1634574864u, 64347, 16728, 181, 224, 254, 183, 51, 244, 25, 186), "Light Style 3");
		smethod_0(TableStylePreset.LightStyle3Accent1, new Guid(3163156374u, 36074, 18175, 134, 196, 76, 224, 231, 96, 152, 2), "Light Style 3 - Accent 1");
		smethod_0(TableStylePreset.MediumStyle2Accent2, new Guid(568635044u, 36346, 19081, 135, 235, 73, 195, 38, 98, 175, 224), "Medium Style 2 - Accent 2");
		smethod_0(TableStylePreset.LightStyle3Accent2, new Guid(1570995584, 25652, 17616, 160, 40, 27, 34, 166, 150, 0, 111), "Light Style 3 - Accent 2");
		smethod_0(TableStylePreset.LightStyle3Accent3, new Guid(2274996795u, 60547, 18054, 179, 10, 81, 36, 19, 181, 230, 122), "Light Style 3 - Accent 3");
		smethod_0(TableStylePreset.LightStyle3Accent4, new Guid(3976739558u, 18170, 19033, 143, 176, 159, 151, 235, 16, 113, 159), "Light Style 3 - Accent 4");
		smethod_0(TableStylePreset.LightStyle3Accent5, new Guid(3183400297u, 18327, 19953, 160, 244, 106, 171, 60, 217, 130, 216), "Light Style 3 - Accent 5");
		smethod_0(TableStylePreset.LightStyle3Accent6, new Guid(3903914796u, 59960, 20229, 186, 13, 56, 175, byte.MaxValue, 199, 190, 211), "Light Style 3 - Accent 6");
		smethod_0(TableStylePreset.MediumStyle1, new Guid(2034074063u, 38130, 16410, 186, 87, 146, 245, 167, 178, 208, 197), "Medium Style 1");
		smethod_0(TableStylePreset.MediumStyle1Accent1, new Guid(3003234337u, 41471, 16759, 174, 231, 118, 210, 18, 25, 26, 9), "Medium Style 1 - Accent 1");
		smethod_0(TableStylePreset.MediumStyle1Accent2, new Guid(2647325165u, 2012, 18961, 141, 127, 87, 179, 92, 37, 104, 46), "Medium Style 1 - Accent 2");
		smethod_0(TableStylePreset.MediumStyle1Accent3, new Guid(535606488u, 56066, 19910, 160, 162, 79, 46, 186, 225, 220, 144), "Medium Style 1 - Accent 3");
		smethod_0(TableStylePreset.MediumStyle1Accent4, new Guid(504830259, 17945, 19985, 154, 63, 247, 96, 141, 247, 95, 128), "Medium Style 1 - Accent 4");
		smethod_0(TableStylePreset.MediumStyle1Accent5, new Guid(4206874403u, 15209, 18063, 182, 159, 136, 246, 222, 106, 114, 242), "Medium Style 1 - Accent 5");
		smethod_0(TableStylePreset.MediumStyle1Accent6, new Guid(279033301u, 39833, 19509, 164, 34, 41, 146, 116, 200, 118, 99), "Medium Style 1 - Accent 6");
		smethod_0(TableStylePreset.MediumStyle2Accent6, new Guid(2468964368u, 43141, 19427, 163, 231, 109, 91, 238, 165, 143, 53), "Medium Style 2 - Accent 6");
		smethod_0(TableStylePreset.MediumStyle3, new Guid(2395082293u, 41334, 16402, 188, 94, 147, 92, byte.MaxValue, 248, 112, 142), "Medium Style 3");
		smethod_0(TableStylePreset.MediumStyle3Accent1, new Guid(1847977545, 16150, 19970, 167, 51, 25, 210, 205, 191, 72, 240), "Medium Style 3 - Accent 1");
		smethod_0(TableStylePreset.MediumStyle3Accent2, new Guid(2243831356u, 56279, 18976, 187, 89, 170, 179, 10, 202, 166, 90), "Medium Style 3 - Accent 2");
		smethod_0(TableStylePreset.MediumStyle3Accent3, new Guid(3946073476u, 39675, 18814, 163, 147, 220, 51, 107, 161, 157, 46), "Medium Style 3 - Accent 3");
		smethod_0(TableStylePreset.MediumStyle3Accent4, new Guid(3952488885u, 30962, 16841, 134, 155, 159, 57, 6, 111, 129, 4), "Medium Style 3 - Accent 4");
		smethod_0(TableStylePreset.MediumStyle3Accent5, new Guid(1958848675, 12394, 20151, 166, 177, 79, 126, 14, 185, 197, 214), "Medium Style 3 - Accent 5");
		smethod_0(TableStylePreset.MediumStyle3Accent6, new Guid(709395234u, 62138, 19291, 151, 72, 13, 71, 66, 113, 128, 143), "Medium Style 3 - Accent 6");
		smethod_0(TableStylePreset.MediumStyle4, new Guid(3618389194u, 51095, 18577, 190, 2, 217, 78, 67, 66, 91, 120), "Medium Style 4");
		smethod_0(TableStylePreset.MediumStyle4Accent1, new Guid(1775180466, 6518, 17666, 191, 54, 63, 245, 234, 33, 136, 97), "Medium Style 4 - Accent 1");
		smethod_0(TableStylePreset.MediumStyle4Accent2, new Guid(2316335190u, 21844, 17147, 176, 62, 57, 245, 219, 195, 112, 186), "Medium Style 4 - Accent 2");
		smethod_0(TableStylePreset.MediumStyle4Accent3, new Guid(84272111, 26602, 17259, 151, 178, 1, 36, 192, 110, 189, 36), "Medium Style 4 - Accent 3");
		smethod_0(TableStylePreset.MediumStyle4Accent4, new Guid(3299939690u, 14350, 20344, 189, 245, 166, 6, 168, 8, 59, 249), "Medium Style 4 - Accent 4");
		smethod_0(TableStylePreset.MediumStyle4Accent5, new Guid(579046383u, 35762, 17560, 132, 167, 197, 133, 31, 89, 61, 241), "Medium Style 4 - Accent 5");
		smethod_0(TableStylePreset.MediumStyle4Accent6, new Guid(383383150, 24249, 18562, 134, 251, 220, 191, 53, 227, 195, 228), "Medium Style 4 - Accent 6");
		smethod_0(TableStylePreset.DarkStyle1, new Guid(3892530808u, 32605, 19502, 179, 117, 252, 100, 178, 123, 201, 23), "Dark Style 1");
		smethod_0(TableStylePreset.DarkStyle1Accent1, new Guid(308170870, 14352, 18397, 183, 159, 103, 77, 122, 212, 12, 1), "Dark Style 1 - Accent 1");
		smethod_0(TableStylePreset.DarkStyle1Accent2, new Guid(936281331, 10435, 17470, 158, 150, 153, 207, 130, 81, 43, 120), "Dark Style 1 - Accent 2");
		smethod_0(TableStylePreset.DarkStyle1Accent3, new Guid(3493087163u, 23911, 18795, 142, 135, 229, 97, 7, 90, 213, 92), "Dark Style 1 - Accent 3");
		smethod_0(TableStylePreset.DarkStyle1Accent4, new Guid(3911842292u, 19087, 17190, 161, 180, 34, 132, 151, 19, 221, 171), "Dark Style 1 - Accent 4");
		smethod_0(TableStylePreset.DarkStyle1Accent5, new Guid(2413052990u, 63881, 20420, 160, 200, 213, 162, 175, 31, 57, 11), "Dark Style 1 - Accent 5");
		smethod_0(TableStylePreset.DarkStyle1Accent6, new Guid(2942330963u, 30321, 18794, 142, 79, 223, 113, 248, 236, 145, 139), "Dark Style 1 - Accent 6");
		smethod_0(TableStylePreset.DarkStyle2, new Guid(1375908042u, 64596, 17558, 139, 202, 94, 246, 106, 129, 141, 41), "Dark Style 2");
		smethod_0(TableStylePreset.DarkStyle2Accent1Accent2, new Guid(107000840u, 46031, 19092, 133, 252, 43, 30, 10, 69, 244, 162), "Dark Style 2 - Accent 1/Accent 2");
		smethod_0(TableStylePreset.DarkStyle2Accent3Accent4, new Guid(2448145356u, 56018, 17820, 190, 46, 246, 222, 53, 207, 154, 40), "Dark Style 2 - Accent 3/Accent 4");
		smethod_0(TableStylePreset.DarkStyle2Accent5Accent6, new Guid(1190695081, 10247, 20155, 184, 29, 178, 170, 120, 236, 127, 57), "Dark Style 2 - Accent 5/Accent 6");
	}

	private static void smethod_0(TableStylePreset id, Guid guid, string desc)
	{
		dictionary_1.Add(guid, id);
		dictionary_2.Add(id, guid);
	}

	public IEnumerator GetEnumerator()
	{
		return PPTXUnsupportedProps.Styles.GetEnumerator();
	}

	internal void method_3(Class144 style)
	{
		dictionary_0.Add(style.PPTXUnsupportedProps.Id, style);
		PPTXUnsupportedProps.Styles.Add(style);
	}

	public Class144 method_4(Guid id, string name)
	{
		Class144 @class = new Class144(Parent, id, name);
		method_3(@class);
		return @class;
	}
}
