using System.Text;
using Aspose.Words;
using Aspose.Words.Math;
using x6c95d9cf46ff5f25;
using xe5b37aee2c2a4d4e;

namespace xa2462df43988ffad;

internal class xd52f4e7d89553b9d
{
	private const char x5eb3b0b91c7bd2d0 = '\u0302';

	private const char x369b41a699a13ead = '∫';

	private const char x148b9b41f7da81c5 = '&';

	private const char x18dc6b2a47a05c44 = '|';

	private const char xe7bc46ff08a597ea = '⏞';

	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private static readonly int[] x3d52ecc827a7ca9f = new int[1073]
	{
		40, 41, 91, 93, 123, 125, 43, 45, 42, 47,
		94, 61, 62, 60, 59, 44, 46, 58, 39, 96,
		95, 126, 37, 64, 63, 33, 124, 92, 8216, 8217,
		8220, 8221, 8214, 8214, 8968, 8969, 8970, 8971, 10098, 10099,
		10214, 10215, 10216, 10217, 10218, 10219, 10220, 10221, 10222, 10223,
		10624, 10624, 10627, 10628, 10629, 10630, 10631, 10632, 10633, 10634,
		10635, 10636, 10637, 10638, 10639, 10640, 10641, 10642, 10643, 10644,
		10645, 10646, 10647, 10648, 10748, 10749, 8291, 8756, 8757, 1014,
		8230, 8942, 8943, 8945, 8715, 8866, 8867, 8868, 8872, 8873,
		8876, 8877, 8878, 8879, 8744, 8743, 8704, 8707, 8708, 8705,
		8712, 8713, 8716, 8834, 8834, 8402, 8835, 8835, 8402, 8836,
		8837, 8838, 8839, 8840, 8841, 8842, 8843, 8804, 8805, 8815,
		8814, 8776, 8764, 8777, 8802, 8800, 8733, 8740, 8741, 8742,
		8769, 8771, 8772, 8773, 8774, 8775, 8781, 8788, 8791, 8793,
		8794, 8796, 8799, 8801, 8808, 8809, 8810, 8810, 824, 8811,
		8811, 824, 8813, 8816, 8817, 8826, 8827, 8828, 8829, 8832,
		8833, 8869, 8884, 8885, 8905, 8906, 8907, 8908, 8916, 8918,
		8919, 8920, 8921, 8938, 8939, 8940, 8941, 9632, 9633, 9642,
		9643, 9645, 9646, 9647, 9648, 9649, 9651, 9652, 9653, 9654,
		9655, 9656, 9657, 9660, 9661, 9662, 9663, 9664, 9665, 9666,
		9667, 9668, 9669, 9670, 9671, 9672, 9673, 9676, 9677, 9678,
		9679, 9686, 9687, 9702, 10688, 10689, 10723, 10724, 10725, 10726,
		10739, 10887, 10888, 10927, 10927, 824, 10928, 10928, 824, 8260,
		8710, 8714, 8717, 8718, 8725, 8727, 8728, 8729, 8735, 8739,
		8758, 8759, 8760, 8761, 8762, 8763, 8765, 8765, 817, 8766,
		8767, 8770, 8770, 824, 8778, 8779, 8780, 8782, 8782, 824,
		8783, 8783, 824, 8784, 8785, 8786, 8787, 8789, 8790, 8792,
		8797, 8798, 8803, 8806, 8806, 824, 8807, 8812, 8818, 8819,
		8820, 8821, 8822, 8823, 8824, 8825, 8830, 8831, 8831, 824,
		8844, 8845, 8846, 8847, 8847, 824, 8848, 8848, 824, 8849,
		8850, 8851, 8852, 8858, 8859, 8860, 8861, 8870, 8871, 8874,
		8875, 8880, 8881, 8882, 8883, 8886, 8887, 8889, 8890, 8891,
		8892, 8893, 8894, 8895, 8900, 8902, 8903, 8904, 8909, 8910,
		8911, 8912, 8913, 8914, 8915, 8917, 8922, 8923, 8924, 8925,
		8926, 8927, 8928, 8929, 8930, 8931, 8932, 8933, 8934, 8935,
		8936, 8937, 8944, 8946, 8947, 8948, 8949, 8950, 8951, 8952,
		8953, 8954, 8955, 8956, 8957, 8958, 8959, 9650, 10072, 10625,
		10626, 10656, 10657, 10658, 10659, 10660, 10661, 10662, 10663, 10664,
		10665, 10666, 10667, 10668, 10669, 10670, 10671, 10672, 10673, 10674,
		10675, 10676, 10677, 10678, 10679, 10680, 10681, 10682, 10683, 10684,
		10685, 10686, 10687, 10690, 10691, 10692, 10693, 10694, 10695, 10696,
		10697, 10698, 10699, 10700, 10701, 10702, 10703, 10703, 824, 10704,
		10704, 824, 10705, 10706, 10707, 10708, 10709, 10710, 10711, 10712,
		10713, 10715, 10716, 10717, 10718, 10720, 10721, 10722, 10727, 10728,
		10729, 10730, 10731, 10732, 10733, 10734, 10736, 10737, 10738, 10741,
		10742, 10743, 10744, 10745, 10746, 10747, 10750, 10751, 10781, 10782,
		10783, 10784, 10785, 10786, 10787, 10788, 10789, 10790, 10791, 10792,
		10793, 10794, 10795, 10796, 10797, 10798, 10800, 10801, 10802, 10803,
		10804, 10805, 10806, 10807, 10808, 10809, 10810, 10811, 10812, 10813,
		10814, 10816, 10817, 10818, 10819, 10820, 10821, 10822, 10823, 10824,
		10825, 10826, 10827, 10828, 10829, 10830, 10831, 10832, 10833, 10834,
		10835, 10836, 10837, 10838, 10839, 10840, 10841, 10842, 10843, 10844,
		10845, 10846, 10847, 10848, 10849, 10850, 10851, 10852, 10853, 10854,
		10855, 10856, 10857, 10858, 10859, 10860, 10861, 10862, 10863, 10864,
		10865, 10866, 10867, 10868, 10869, 10870, 10871, 10872, 10873, 10874,
		10875, 10876, 10877, 10877, 824, 10878, 10878, 824, 10879, 10880,
		10881, 10882, 10883, 10884, 10885, 10886, 10889, 10890, 10891, 10892,
		10893, 10894, 10895, 10896, 10897, 10898, 10899, 10900, 10901, 10902,
		10903, 10904, 10905, 10906, 10907, 10908, 10909, 10910, 10911, 10912,
		10913, 10913, 824, 10914, 10914, 824, 10915, 10916, 10917, 10918,
		10919, 10920, 10921, 10922, 10923, 10924, 10925, 10926, 10929, 10930,
		10931, 10932, 10933, 10934, 10935, 10936, 10937, 10938, 10939, 10940,
		10941, 10942, 10943, 10944, 10945, 10946, 10947, 10948, 10949, 10950,
		10951, 10952, 10953, 10954, 10955, 10956, 10957, 10958, 10959, 10960,
		10961, 10962, 10963, 10964, 10965, 10966, 10967, 10968, 10969, 10970,
		10971, 10972, 10973, 10974, 10975, 10976, 10977, 10978, 10979, 10980,
		10981, 10982, 10983, 10984, 10985, 10986, 10987, 10988, 10989, 10990,
		10991, 10992, 10993, 10994, 10995, 10996, 10997, 10998, 10999, 11000,
		11001, 11002, 11003, 11005, 11006, 8592, 8593, 8594, 8595, 8596,
		8597, 8598, 8599, 8600, 8601, 8602, 8603, 8604, 8605, 8606,
		8607, 8608, 8609, 8610, 8611, 8612, 8613, 8614, 8615, 8616,
		8617, 8618, 8619, 8620, 8621, 8622, 8623, 8624, 8625, 8626,
		8627, 8628, 8629, 8630, 8631, 8632, 8633, 8634, 8635, 8636,
		8637, 8638, 8639, 8640, 8641, 8642, 8643, 8644, 8645, 8646,
		8647, 8648, 8649, 8650, 8651, 8652, 8653, 8654, 8655, 8656,
		8657, 8658, 8659, 8660, 8661, 8662, 8663, 8664, 8665, 8666,
		8667, 8668, 8669, 8670, 8671, 8672, 8673, 8674, 8675, 8676,
		8677, 8678, 8679, 8680, 8681, 8682, 8683, 8684, 8685, 8686,
		8687, 8688, 8689, 8690, 8691, 8692, 8693, 8694, 8695, 8696,
		8697, 8698, 8699, 8700, 8701, 8702, 8703, 8888, 10224, 10225,
		10229, 10230, 10231, 10232, 10233, 10234, 10235, 10236, 10237, 10238,
		10239, 10496, 10497, 10498, 10499, 10500, 10501, 10502, 10503, 10504,
		10505, 10506, 10507, 10508, 10509, 10510, 10511, 10512, 10513, 10514,
		10515, 10516, 10517, 10518, 10519, 10520, 10521, 10522, 10523, 10524,
		10525, 10526, 10527, 10528, 10529, 10530, 10531, 10532, 10533, 10534,
		10535, 10536, 10537, 10538, 10539, 10540, 10541, 10542, 10543, 10544,
		10545, 10546, 10547, 10548, 10549, 10550, 10551, 10552, 10553, 10554,
		10555, 10556, 10557, 10558, 10559, 10560, 10561, 10562, 10563, 10564,
		10565, 10566, 10567, 10568, 10569, 10570, 10571, 10572, 10573, 10574,
		10575, 10576, 10577, 10578, 10579, 10580, 10581, 10582, 10583, 10584,
		10585, 10586, 10587, 10588, 10589, 10590, 10591, 10592, 10593, 10594,
		10595, 10596, 10597, 10598, 10599, 10600, 10601, 10602, 10603, 10604,
		10605, 10606, 10607, 10608, 10609, 10610, 10611, 10612, 10613, 10614,
		10615, 10616, 10617, 10618, 10619, 10620, 10621, 10622, 10623, 10649,
		10650, 10651, 10652, 10653, 10654, 10655, 10719, 10735, 10740, 11077,
		11078, 177, 177, 8722, 8722, 8723, 8723, 8724, 8862, 8863,
		8721, 10762, 10763, 8748, 8749, 8853, 8854, 8856, 10753, 8747,
		8750, 8751, 8752, 8753, 8754, 8755, 10764, 10765, 10766, 10767,
		10768, 10769, 10770, 10771, 10772, 10773, 10774, 10775, 10776, 10777,
		10778, 10779, 10780, 8899, 10755, 10756, 8896, 8897, 8898, 10752,
		10754, 10757, 10758, 10759, 10760, 10761, 11004, 11007, 8768, 8719,
		8720, 8745, 8746, 215, 8226, 8290, 8864, 8865, 8901, 10799,
		10815, 183, 8855, 8726, 247, 8736, 8737, 8738, 172, 8857,
		8706, 8711, 8242, 9837, 9838, 9839, 8517, 8518, 8730, 8731,
		8732, 8289, 168, 175, 176, 180, 184, 710, 711, 713,
		714, 715, 717, 728, 729, 730, 732, 733, 759, 770,
		785, 8254, 8292, 8411, 8412, 9140, 9141, 9180, 9181, 9182,
		9183, 9184, 9185
	};

	internal xd52f4e7d89553b9d(xdb0bf9f81de4b38c writer, OfficeMath officeMath)
	{
		x9b287b671d592594 = writer;
		string arg = officeMath.x5881d3d5b8b306d3();
		x800085dd555f7711 = writer.x082c3925d43afdad($"{arg}/content.xml");
		x9b287b671d592594.xdb9a725c50caafe9.Add(new x03305f81beb3a033("text/xml", $"{arg}/", "content.xml"));
		x800085dd555f7711.x9b9ed0109b743e3b("mml:math");
		x800085dd555f7711.xff520a0047c27122("xmlns:mml", "http://www.w3.org/1998/Math/MathML");
		x800085dd555f7711.xff520a0047c27122("xmlns:m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
	}

	internal VisitorAction xf29854ceb92cf300(OfficeMath x203bd7b4a3be8d02)
	{
		switch (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x0dbbcf3105452f20:
			xd9b8cdf39feb15c1(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x1b1f4712a1a0c38c:
			x901504524a3c48d7(x203bd7b4a3be8d02, "mml:msub", x3e68720d12325f49.x06b102f48629e32f);
			break;
		case x3e68720d12325f49.xe8789867140a072a:
			x901504524a3c48d7(x203bd7b4a3be8d02, "mml:msup", x3e68720d12325f49.x16984029356c96b7);
			break;
		case x3e68720d12325f49.x71c5078172d72420:
			xdb7bae0ae248159c(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.xdb2ade053c60340d:
			xae5a7517227e8a12(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.xf2da195ae719a2a1:
			x45d676570fc1f799(x203bd7b4a3be8d02, "mml:msubsup", xcb8531ad952bc5e8: false);
			break;
		case x3e68720d12325f49.x398384f7454300c1:
			x45d676570fc1f799(x203bd7b4a3be8d02, "mml:mmultiscripts", xcb8531ad952bc5e8: true);
			break;
		case x3e68720d12325f49.x3e270ab1f00c767a:
			xddec2eda43768c4c(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x9b63794dfed849a8:
			x47ed0cd33392ee69(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x2709f18576762ece:
			xaafd39b1532c0947(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x9c1074dced8b2f2e:
			x9b65885c553cc553(x203bd7b4a3be8d02, "mml:munder");
			break;
		case x3e68720d12325f49.x5a25e9abda6210c5:
			x9b65885c553cc553(x203bd7b4a3be8d02, "mml:mover");
			break;
		case x3e68720d12325f49.x30727a59b1643735:
			x69f91951eb100ba5(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x3d0bfd5419916b93:
			x556fd179d3c0d81d(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.xced856c17df679c5:
			x6465f52b011290d3(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.xd4e45a1fccac675d:
			xf5fe5bf90a2f2397(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x82ca8304b1b498f4:
			x98ad8c5485398716(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x2ffb9ed185cafd85:
			x059ee84d01a8658e(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x2ae4473a93ca9b64:
			x58e91b2506b785b3(x203bd7b4a3be8d02);
			break;
		case x3e68720d12325f49.x78451b450fb7d099:
			x7e980761b46e94b7(x203bd7b4a3be8d02);
			break;
		default:
			return VisitorAction.Continue;
		}
		return VisitorAction.SkipThisNode;
	}

	private void x7e980761b46e94b7(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:menclose");
		x800085dd555f7711.x943f6be3acf634db("notation", "box");
		xa79b295b3ca6f97c(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:menclose");
	}

	private void x58e91b2506b785b3(OfficeMath x203bd7b4a3be8d02)
	{
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.ChildNodes)
		{
			childNode.Accept(x9b287b671d592594);
		}
	}

	private void x059ee84d01a8658e(OfficeMath x203bd7b4a3be8d02)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		if (officeMath == null)
		{
			return;
		}
		OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x06b102f48629e32f);
		OfficeMath officeMath3 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x16984029356c96b7);
		if (officeMath2 == null && officeMath3 == null)
		{
			return;
		}
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15045);
		if (obj == null)
		{
			obj = '∫';
		}
		bool flag = x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15520);
		bool flag2 = x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15530);
		if (officeMath2 == null)
		{
			flag = true;
		}
		if (officeMath3 == null)
		{
			flag2 = true;
		}
		string text = x1f8043802402d2f6(x203bd7b4a3be8d02, (char)obj, flag, flag2);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x800085dd555f7711.x2307058321cdb62f(text);
		}
		xf10360854c1d88b5((char)obj);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			if (!flag)
			{
				x75b2de43d867b5c1(officeMath2);
			}
			if (!flag2)
			{
				x75b2de43d867b5c1(officeMath3);
			}
			x800085dd555f7711.x2dfde153f4ef96d0(text);
		}
		x75b2de43d867b5c1(officeMath);
	}

	private static bool x3a3d1a4be250d7bc(OfficeMath x203bd7b4a3be8d02, int xad5ee812e0b28f28)
	{
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(xad5ee812e0b28f28);
		if (obj != null)
		{
			return (bool)obj;
		}
		return false;
	}

	private static string x1f8043802402d2f6(OfficeMath x203bd7b4a3be8d02, char x1d6d25fa094e7304, bool x78484ee3ca592c09, bool xf510706b2c8984f5)
	{
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15510);
		xf47bac63068c8fd6 xf47bac63068c8fd = xf47bac63068c8fd6.x236cb0a4295bc034;
		if (obj != null)
		{
			xf47bac63068c8fd = (xf47bac63068c8fd6)obj;
		}
		switch (xf47bac63068c8fd)
		{
		case xf47bac63068c8fd6.x44da4836b2a87e96:
			return x1f8043802402d2f6(x78484ee3ca592c09, xf510706b2c8984f5, "mml:msup", "mml:msub", "mml:msubsup");
		case xf47bac63068c8fd6.x8e321c5b5aaa4dd5:
			return x1f8043802402d2f6(x78484ee3ca592c09, xf510706b2c8984f5, "mml:mover", "mml:munder", "mml:munderover");
		default:
			if (x1d6d25fa094e7304 == '∫')
			{
				return x1f8043802402d2f6(x78484ee3ca592c09, xf510706b2c8984f5, "mml:msup", "mml:msub", "mml:msubsup");
			}
			return x1f8043802402d2f6(x78484ee3ca592c09, xf510706b2c8984f5, "mml:mover", "mml:munder", "mml:munderover");
		}
	}

	private static string x1f8043802402d2f6(bool x78484ee3ca592c09, bool xf510706b2c8984f5, string x59d520510c99a8cf, string x6c4f89485cd1bee8, string x505f8d3da35ef7ea)
	{
		if (x78484ee3ca592c09 && !xf510706b2c8984f5)
		{
			return x59d520510c99a8cf;
		}
		if (!x78484ee3ca592c09 && xf510706b2c8984f5)
		{
			return x6c4f89485cd1bee8;
		}
		if (!x78484ee3ca592c09)
		{
			return x505f8d3da35ef7ea;
		}
		return null;
	}

	private void x98ad8c5485398716(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mpadded");
		if (x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15450))
		{
			x800085dd555f7711.x943f6be3acf634db("width", "0cm");
		}
		if (x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15330))
		{
			x800085dd555f7711.x943f6be3acf634db("height", "0cm");
		}
		if (x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15340))
		{
			x800085dd555f7711.x943f6be3acf634db("depth", "0cm");
		}
		x800085dd555f7711.x2307058321cdb62f("mml:mrow");
		x3a40412d74b6408a(x203bd7b4a3be8d02);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mpadded");
	}

	private void xf5fe5bf90a2f2397(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mtable");
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.GetChildNodes(NodeType.OfficeMath, isDeep: false))
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				x800085dd555f7711.x2307058321cdb62f("mml:mtr");
				x800085dd555f7711.x2307058321cdb62f("mml:mtd");
				x800085dd555f7711.x2307058321cdb62f("mml:mrow");
				x800085dd555f7711.xf68f9c3818e1f4b1("mml:maligngroup");
				childNode.Accept(x9b287b671d592594);
				x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
				x800085dd555f7711.x2dfde153f4ef96d0("mml:mtd");
				x800085dd555f7711.x2dfde153f4ef96d0("mml:mtr");
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mtable");
	}

	private void x69f91951eb100ba5(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mtable");
		xa79b295b3ca6f97c(x203bd7b4a3be8d02, x3e68720d12325f49.x3d0bfd5419916b93);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mtable");
	}

	private void x556fd179d3c0d81d(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mtr");
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.GetChildNodes(NodeType.OfficeMath, isDeep: false))
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				x800085dd555f7711.x2307058321cdb62f("mml:mtd");
				childNode.Accept(x9b287b671d592594);
				x800085dd555f7711.x2dfde153f4ef96d0("mml:mtd");
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mtr");
	}

	private void x6465f52b011290d3(OfficeMath x203bd7b4a3be8d02)
	{
		string x121383aa = "mml:munder";
		char c = '\u0332';
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15030);
		if (obj != null && (xce8b2ce767b2485c)obj == xce8b2ce767b2485c.xe360b1885d8d4a41)
		{
			x121383aa = "mml:mover";
			c = '\u00af';
		}
		x800085dd555f7711.x2307058321cdb62f(x121383aa);
		OfficeMath x203bd7b4a3be8d3 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		x75b2de43d867b5c1(x203bd7b4a3be8d3);
		xf10360854c1d88b5(c);
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
	}

	private void x47ed0cd33392ee69(OfficeMath x203bd7b4a3be8d02)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		if (officeMath != null)
		{
			object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15040);
			if (obj == null)
			{
				obj = '\u0302';
			}
			x800085dd555f7711.x2307058321cdb62f("mml:mover");
			x800085dd555f7711.x943f6be3acf634db("accent", "true");
			x75b2de43d867b5c1(officeMath);
			xf10360854c1d88b5((char)obj);
			x800085dd555f7711.x2dfde153f4ef96d0("mml:mover");
		}
	}

	private void x9b65885c553cc553(OfficeMath x203bd7b4a3be8d02, string x121383aa64985888)
	{
		x800085dd555f7711.x2307058321cdb62f(x121383aa64985888);
		x800085dd555f7711.x2307058321cdb62f("mml:mrow");
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.ChildNodes)
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 != x3e68720d12325f49.x25d26846c330b189)
			{
				childNode.Accept(x9b287b671d592594);
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
		x800085dd555f7711.x2307058321cdb62f("mml:mrow");
		xa79b295b3ca6f97c(x203bd7b4a3be8d02, x3e68720d12325f49.x25d26846c330b189);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa64985888);
	}

	private void xaafd39b1532c0947(OfficeMath x203bd7b4a3be8d02)
	{
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15300);
		bool flag = obj != null && (x63bdb8b878b040d9)obj == x63bdb8b878b040d9.x9bcb07e204e30218;
		string x121383aa = (flag ? "mml:mover" : "mml:munder");
		string x9e89cc6e6284edf = (flag ? "accent" : "accentunder");
		object obj2 = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15290);
		bool xa165d2a26e54a = obj2 != null && (x63bdb8b878b040d9)obj2 == x63bdb8b878b040d9.xe360b1885d8d4a41;
		object obj3 = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15280);
		if (obj3 == null)
		{
			obj3 = '⏞';
		}
		x800085dd555f7711.x2307058321cdb62f(x121383aa);
		x800085dd555f7711.x943f6be3acf634db(x9e89cc6e6284edf, xbcea506a33cf9111: false);
		x3be038e220398719(x203bd7b4a3be8d02, obj3, xa165d2a26e54a, flag);
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
	}

	private void x3be038e220398719(OfficeMath x203bd7b4a3be8d02, object xf5467570841aab00, bool xa165d2a26e54a348, bool xf604582b21305a5e)
	{
		if ((xa165d2a26e54a348 && xf604582b21305a5e) || (!xa165d2a26e54a348 && !xf604582b21305a5e))
		{
			x3a40412d74b6408a(x203bd7b4a3be8d02);
			xf10360854c1d88b5((char)xf5467570841aab00);
		}
		else
		{
			xf10360854c1d88b5((char)xf5467570841aab00);
			x3a40412d74b6408a(x203bd7b4a3be8d02);
		}
	}

	private void xf10360854c1d88b5(object x3c4da2980d043c95)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mo");
		x800085dd555f7711.x3d1be38abe5723e3(((char)x3c4da2980d043c95).ToString());
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mo");
	}

	private void xd9b8cdf39feb15c1(OfficeMath x203bd7b4a3be8d02)
	{
		object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15180);
		object obj2 = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15190);
		object obj3 = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15200);
		x800085dd555f7711.x2307058321cdb62f("mml:mfenced");
		if (obj != null)
		{
			x800085dd555f7711.x943f6be3acf634db("open", ((char)obj).ToString());
		}
		if (obj2 != null)
		{
			x800085dd555f7711.x943f6be3acf634db("close", ((char)obj2).ToString());
		}
		x800085dd555f7711.x943f6be3acf634db("separators", ((obj3 == null) ? '|' : ((char)obj3)).ToString());
		x3a40412d74b6408a(x203bd7b4a3be8d02);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mfenced");
	}

	private void x901504524a3c48d7(OfficeMath x203bd7b4a3be8d02, string x121383aa64985888, x3e68720d12325f49 x9c4a7bc6ba0a379d)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		if (officeMath != null)
		{
			OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x9c4a7bc6ba0a379d);
			if (officeMath2 != null)
			{
				x800085dd555f7711.x2307058321cdb62f(x121383aa64985888);
				x75b2de43d867b5c1(officeMath);
				x75b2de43d867b5c1(officeMath2);
				x800085dd555f7711.x2dfde153f4ef96d0(x121383aa64985888);
			}
		}
	}

	private void xdb7bae0ae248159c(OfficeMath x203bd7b4a3be8d02)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x194cb0ccf5358fec);
		if (officeMath == null)
		{
			return;
		}
		OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x5ec114ef0df8072b);
		if (officeMath2 != null)
		{
			object obj = x203bd7b4a3be8d02.x52642f91ccdeeb35.xf7866f89640a29a3(15460);
			x890a027c82a36a95 x890a027c82a36a = x890a027c82a36a95.xced856c17df679c5;
			if (obj != null)
			{
				x890a027c82a36a = (x890a027c82a36a95)obj;
			}
			string x121383aa = ((x890a027c82a36a == x890a027c82a36a95.x38d4db9419f3b510) ? "mml:mrow" : "mml:mfrac");
			x800085dd555f7711.x2307058321cdb62f(x121383aa);
			if (x890a027c82a36a == x890a027c82a36a95.xa1886b914486c170)
			{
				x800085dd555f7711.x943f6be3acf634db("linethickness", "0pt");
			}
			if (x890a027c82a36a == x890a027c82a36a95.x7ccdf8314e1f1193)
			{
				x800085dd555f7711.x943f6be3acf634db("bevelled", "true");
			}
			x75b2de43d867b5c1(officeMath2);
			if (x890a027c82a36a == x890a027c82a36a95.x38d4db9419f3b510)
			{
				xf10360854c1d88b5('/');
			}
			x75b2de43d867b5c1(officeMath);
			x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
		}
	}

	private void xddec2eda43768c4c(OfficeMath x203bd7b4a3be8d02)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x8c55fc884c93cb9f);
		if (officeMath != null)
		{
			OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
			x800085dd555f7711.x2307058321cdb62f("mml:mrow");
			x75b2de43d867b5c1(officeMath);
			if (officeMath2 != null)
			{
				xf10360854c1d88b5('\u2061');
				x75b2de43d867b5c1(officeMath2);
			}
			x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
		}
	}

	private void x45d676570fc1f799(OfficeMath x203bd7b4a3be8d02, string x121383aa64985888, bool xcb8531ad952bc5e8)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		if (officeMath == null)
		{
			return;
		}
		OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x06b102f48629e32f);
		if (officeMath2 == null)
		{
			return;
		}
		OfficeMath officeMath3 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x16984029356c96b7);
		if (officeMath3 != null)
		{
			x800085dd555f7711.x2307058321cdb62f(x121383aa64985888);
			x75b2de43d867b5c1(officeMath);
			if (xcb8531ad952bc5e8)
			{
				x800085dd555f7711.xf68f9c3818e1f4b1("mml:mprescripts");
			}
			x75b2de43d867b5c1(officeMath2);
			x75b2de43d867b5c1(officeMath3);
			x800085dd555f7711.x2dfde153f4ef96d0(x121383aa64985888);
		}
	}

	private void x75b2de43d867b5c1(OfficeMath x203bd7b4a3be8d02)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mrow");
		x203bd7b4a3be8d02?.Accept(x9b287b671d592594);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mrow");
	}

	private void xae5a7517227e8a12(OfficeMath x203bd7b4a3be8d02)
	{
		OfficeMath officeMath = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x2b691ff28e877ea4);
		if (officeMath == null)
		{
			return;
		}
		OfficeMath officeMath2 = xb118a12e1e9ea692(x203bd7b4a3be8d02, x3e68720d12325f49.x1745ba6c6d5efbc4);
		if (officeMath2 != null)
		{
			if (x3a3d1a4be250d7bc(x203bd7b4a3be8d02, 15540))
			{
				x19c5b93f76c98294(officeMath2);
			}
			else
			{
				x5605fce24c59a5a7(officeMath, officeMath2);
			}
		}
	}

	private void x3a40412d74b6408a(OfficeMath x203bd7b4a3be8d02)
	{
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.GetChildNodes(NodeType.OfficeMath, isDeep: false))
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				x75b2de43d867b5c1(childNode);
			}
		}
	}

	private static OfficeMath xb118a12e1e9ea692(OfficeMath x203bd7b4a3be8d02, x3e68720d12325f49 xe49fb0a8788bb98e)
	{
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.ChildNodes)
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 == xe49fb0a8788bb98e)
			{
				return childNode;
			}
		}
		return null;
	}

	private void xa79b295b3ca6f97c(OfficeMath x203bd7b4a3be8d02, x3e68720d12325f49 xe49fb0a8788bb98e)
	{
		foreach (OfficeMath childNode in x203bd7b4a3be8d02.ChildNodes)
		{
			if (childNode.x52642f91ccdeeb35.x3e68720d12325f49 == xe49fb0a8788bb98e)
			{
				childNode.Accept(x9b287b671d592594);
			}
		}
	}

	private void x5605fce24c59a5a7(OfficeMath x83735b10b6a3d76d, OfficeMath xf6fec61b61cb58a0)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:mroot");
		x75b2de43d867b5c1(xf6fec61b61cb58a0);
		x75b2de43d867b5c1(x83735b10b6a3d76d);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:mroot");
	}

	private void x19c5b93f76c98294(OfficeMath xf6fec61b61cb58a0)
	{
		x800085dd555f7711.x2307058321cdb62f("mml:msqrt");
		x75b2de43d867b5c1(xf6fec61b61cb58a0);
		x800085dd555f7711.x2dfde153f4ef96d0("mml:msqrt");
	}

	internal void x9d26deb82e84d9e6(Inline x31545d7c306a55e4)
	{
		string text = x31545d7c306a55e4.GetText();
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		string text2 = null;
		while (num < text.Length)
		{
			char c = text[num];
			if (c == '&')
			{
				if (flag)
				{
					x800085dd555f7711.x3d1be38abe5723e3(stringBuilder.ToString());
					x800085dd555f7711.x2dfde153f4ef96d0();
					stringBuilder.Length = 0;
					flag = false;
					text2 = null;
				}
				x800085dd555f7711.xf68f9c3818e1f4b1("mml:malignmark");
				num++;
				continue;
			}
			string text3 = x81a47df2303d02fb(text, num);
			if (text3 != null)
			{
				x800085dd555f7711.x3d1be38abe5723e3(stringBuilder.ToString());
				x800085dd555f7711.x2dfde153f4ef96d0(text3);
				stringBuilder.Length = 0;
				flag = false;
			}
			text2 = x90e27883fa602fda(text, num);
			if (text2 != null)
			{
				x800085dd555f7711.x2307058321cdb62f(text2);
				flag = true;
			}
			stringBuilder.Append(text[num]);
			num++;
		}
		if (!flag)
		{
			x800085dd555f7711.x2307058321cdb62f(text2);
		}
		x800085dd555f7711.x3d1be38abe5723e3(stringBuilder.ToString());
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	internal string x90e27883fa602fda(string xb41faee6912a2313, int x7b28e8a789372508)
	{
		if (x7f9c7f42f46a3504(xb41faee6912a2313, x7b28e8a789372508) && (x7b28e8a789372508 == 0 || !x7f9c7f42f46a3504(xb41faee6912a2313, x7b28e8a789372508 - 1)))
		{
			return "mml:mi";
		}
		if (xa71482ce8810917c(xb41faee6912a2313, x7b28e8a789372508))
		{
			return "mml:mo";
		}
		if (xdebf9db7aad51f59(xb41faee6912a2313, x7b28e8a789372508) && (x7b28e8a789372508 == 0 || !xdebf9db7aad51f59(xb41faee6912a2313, x7b28e8a789372508 - 1)))
		{
			return "mml:mn";
		}
		return null;
	}

	internal string x81a47df2303d02fb(string xb41faee6912a2313, int x7b28e8a789372508)
	{
		if (!x7f9c7f42f46a3504(xb41faee6912a2313, x7b28e8a789372508) && x7b28e8a789372508 != 0 && x7f9c7f42f46a3504(xb41faee6912a2313, x7b28e8a789372508 - 1))
		{
			return "mml:mi";
		}
		if (x7b28e8a789372508 != 0 && xa71482ce8810917c(xb41faee6912a2313, x7b28e8a789372508 - 1))
		{
			return "mml:mo";
		}
		if (!xdebf9db7aad51f59(xb41faee6912a2313, x7b28e8a789372508) && x7b28e8a789372508 != 0 && xdebf9db7aad51f59(xb41faee6912a2313, x7b28e8a789372508 - 1))
		{
			return "mml:mn";
		}
		return null;
	}

	internal bool x7f9c7f42f46a3504(string xb41faee6912a2313, int x7b28e8a789372508)
	{
		char x3c4da2980d043c = xb41faee6912a2313[x7b28e8a789372508];
		if (!xdebf9db7aad51f59(xb41faee6912a2313, x7b28e8a789372508) && !xa71482ce8810917c(xb41faee6912a2313, x7b28e8a789372508))
		{
			return !xc1e5e824d51b3a88(x3c4da2980d043c);
		}
		return false;
	}

	internal bool xdebf9db7aad51f59(string xb41faee6912a2313, int x7b28e8a789372508)
	{
		char c = xb41faee6912a2313[x7b28e8a789372508];
		return char.IsDigit(c);
	}

	internal bool xa71482ce8810917c(string xb41faee6912a2313, int x7b28e8a789372508)
	{
		int[] array = x3d52ecc827a7ca9f;
		foreach (int num in array)
		{
			if (xb41faee6912a2313[x7b28e8a789372508] == num)
			{
				return true;
			}
		}
		return false;
	}

	internal bool xc1e5e824d51b3a88(char x3c4da2980d043c95)
	{
		return x3c4da2980d043c95 == '&';
	}
}
