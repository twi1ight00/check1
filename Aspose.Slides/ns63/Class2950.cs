using System;
using System.IO;
using ns60;
using ns62;

namespace ns63;

internal class Class2950
{
	public static Class2623 smethod_0(BinaryReader reader)
	{
		return smethod_1(reader, null);
	}

	public static Class2623 smethod_1(BinaryReader reader, Class2623 parentRecord)
	{
		return smethod_2(reader, null, parentRecord);
	}

	public static Class2623 smethod_2(BinaryReader reader, Class2951 stf, Class2623 parentRecord)
	{
		string text = "NotDefined";
		try
		{
			Class2943 @class = new Class2943(reader);
			Class2623 class2 = smethod_9(@class, stf, parentRecord, reader);
			text = class2.ToString();
			class2.Read(reader, @class);
			return class2;
		}
		catch (Exception innerException)
		{
			throw new Exception("Couldn't read [" + text + "]", innerException);
		}
	}

	public static Class2943 smethod_3(BinaryReader reader)
	{
		return new Class2943(reader);
	}

	public static Class2623 smethod_4(Class2943 header, BinaryReader reader, Class2951 stf, Class2623 parentRecord)
	{
		Class2623 @class = smethod_9(header, stf, parentRecord, reader);
		@class.Read(reader, header);
		return @class;
	}

	public static Class2623 smethod_5(ushort rectype, byte[] bytes, Class2951 stf, Class2623 parentRecord)
	{
		MemoryStream input = new MemoryStream(bytes);
		BinaryReader reader = new BinaryReader(input);
		Class2943 @class = new Class2943();
		@class.Type = rectype;
		@class.Length = bytes.Length;
		Class2623 class2 = smethod_9(@class, stf, parentRecord, reader);
		class2.Read(reader, @class);
		return class2;
	}

	public static Class2623 smethod_6(ushort rectype, byte[] bytes)
	{
		return smethod_5(rectype, bytes, null, null);
	}

	public static Class2623 smethod_7(Class2623 srcRecord)
	{
		return smethod_8(srcRecord, null, null);
	}

	public static Class2623 smethod_8(Class2623 srcRecord, Class2951 stf, Class2623 parentRecord)
	{
		byte[] array = new byte[srcRecord.vmethod_2()];
		MemoryStream output = new MemoryStream(array);
		BinaryWriter writer = new BinaryWriter(output);
		srcRecord.vmethod_1(writer);
		Class2623 @class = smethod_5(srcRecord.Header.Type, array, stf, parentRecord);
		@class.Header.Instance = srcRecord.Header.Instance;
		@class.Header.Version = srcRecord.Header.Version;
		return @class;
	}

	internal static Class2623 smethod_9(Class2943 header, Class2951 stf, Class2623 parentRecord, BinaryReader reader)
	{
		Class2623 @class;
		switch (header.Type)
		{
		case 2000:
			@class = new Class2716();
			break;
		case 1000:
			@class = new Class2688();
			break;
		case 1001:
			@class = new Class2864();
			break;
		case 1002:
			@class = new Class2865();
			break;
		case 1006:
			@class = new Class2719();
			break;
		case 1007:
			@class = new Class2888();
			break;
		case 1008:
			@class = new Class2720();
			break;
		case 1009:
			@class = new Class2884();
			break;
		case 1010:
			@class = new Class2689();
			break;
		case 1011:
			@class = new Class2855(stf);
			break;
		case 1016:
			@class = new Class2718();
			break;
		case 1017:
			@class = new Class2893();
			break;
		case 1018:
			@class = new Class2732();
			break;
		case 1019:
			@class = new Class2903();
			break;
		case 1021:
			@class = new Class2904();
			break;
		case 1022:
			@class = new Class2905();
			break;
		case 1023:
			@class = new Class2736();
			break;
		case 1024:
			@class = new Class2896();
			break;
		case 1025:
			@class = new Class2892();
			break;
		case 1026:
			@class = new Class2830();
			break;
		case 1030:
			@class = new Class2829();
			break;
		case 1031:
			@class = new Class2827();
			break;
		case 1032:
			@class = new Class2826();
			break;
		case 1033:
			@class = new Class2699();
			break;
		case 1034:
			@class = new Class2873();
			break;
		case 1035:
			@class = new Class2715();
			break;
		case 1036:
			@class = new Class2714();
			break;
		case 1037:
			@class = new Class2901();
			break;
		case 1038:
			@class = new Class2779();
			break;
		case 1039:
			@class = new Class2786();
			break;
		case 1040:
			@class = new Class2713();
			break;
		case 1041:
			@class = new Class2712();
			break;
		case 1042:
			@class = new Class2883();
			break;
		case 1043:
			@class = new Class2739();
			break;
		case 1044:
			@class = new Class2740();
			break;
		case 1045:
			@class = new Class2902();
			break;
		case 1052:
			@class = new Class2785();
			break;
		case 1053:
			@class = new Class2781();
			break;
		case 1054:
			@class = new Class2775();
			break;
		case 1055:
			@class = new Class2833();
			break;
		case 1056:
			@class = new Class2783();
			break;
		case 1058:
			@class = new Class2782();
			break;
		case 1059:
			@class = new Class2778();
			break;
		case 1060:
			@class = new Class2788();
			break;
		case 1061:
			@class = new Class2787();
			break;
		case 1062:
			@class = new Class2790();
			break;
		case 1063:
			@class = new Class2777();
			break;
		case 1064:
			@class = new Class2776();
			break;
		case 2032:
			@class = new Class2840();
			break;
		case 2020:
			@class = new Class2734(0);
			break;
		case 2021:
			@class = new Class2890();
			break;
		case 2022:
			@class = new Class2733(0);
			break;
		case 2023:
			@class = new Class2891();
			break;
		case 2005:
			@class = new Class2706();
			break;
		case 2006:
			@class = new Class2707();
			break;
		case 3035:
			@class = new Class2832();
			break;
		case 3036:
			@class = new Class2831();
			break;
		case 3037:
			@class = new Class2784();
			break;
		case 3009:
			@class = new Class2874();
			break;
		case 3011:
			@class = new Class2885();
			break;
		case 2040:
			@class = new Class2701();
			break;
		case 2041:
			@class = new Class2876();
			break;
		case 6000:
			@class = new Class2828();
			break;
		case 6002:
			@class = new Class2887();
			break;
		case 5000:
			if (parentRecord is Class2641)
			{
				@class = new Class2729();
			}
			else if (!(parentRecord is Class2719) && !(parentRecord is Class2718) && !(parentRecord is Class2720) && !(parentRecord is Class2708))
			{
				if (!(parentRecord is Class2716))
				{
					throw new Exception();
				}
				@class = new Class2730();
			}
			else
			{
				@class = new Class2728();
			}
			break;
		case 5001:
			@class = new Class2726();
			break;
		case 5002:
			if (parentRecord is Class2729)
			{
				@class = new Class2724();
				break;
			}
			if (parentRecord is Class2728)
			{
				@class = new Class2723();
				break;
			}
			if (parentRecord is Class2730)
			{
				@class = new Class2725();
				break;
			}
			throw new Exception();
		case 5003:
			if (parentRecord is Class2724)
			{
				@class = ((Class2843)(parentRecord as Class2724).Records[0]).String switch
				{
					"___PPT11" => new Class2677(), 
					"___PPT10" => new Class2678(), 
					"___PPT9" => new Class2679(), 
					_ => new Class2897(), 
				};
				break;
			}
			if (parentRecord is Class2723)
			{
				@class = ((Class2843)(parentRecord as Class2723).Records[0]).String switch
				{
					"___PPT12" => new Class2674(), 
					"___PPT10" => new Class2675(), 
					"___PPT9" => new Class2676(), 
					_ => new Class2897(), 
				};
				break;
			}
			if (!(parentRecord is Class2725))
			{
				throw new Exception();
			}
			@class = ((Class2843)(parentRecord as Class2725).Records[0]).String switch
			{
				"___PPT12" => new Class2681(), 
				"___PPT11" => new Class2680(), 
				"___PPT10" => new Class2682(), 
				"___PPT9" => new Class2683(), 
				_ => new Class2897(), 
			};
			break;
		case 3998:
			@class = new Class2854(stf);
			break;
		case 3999:
			@class = new Class2859(stf);
			break;
		case 4000:
			@class = new Class2858(stf);
			break;
		case 4001:
			@class = new Class2856(stf);
			break;
		case 4002:
			@class = new Class2853(stf);
			break;
		case 4003:
			@class = new Class2894();
			break;
		case 4004:
			@class = new Class2909();
			break;
		case 4005:
			@class = new Class2908();
			break;
		case 4006:
			@class = new Class2860(stf);
			break;
		case 4007:
			@class = new Class2863(stf);
			break;
		case 4008:
			@class = new Class2857(stf);
			break;
		case 4009:
			@class = new Class2907();
			break;
		case 4010:
			@class = new Class2861(stf);
			break;
		case 4011:
			@class = new Class2825();
			break;
		case 4012:
			@class = new Class2898();
			break;
		case 4013:
			@class = new Class2899();
			break;
		case 4014:
			@class = new Class2702();
			break;
		case 4015:
			@class = new Class2877();
			break;
		case 4016:
			@class = new Class2810();
			break;
		case 4017:
			@class = new Class2799();
			break;
		case 4018:
			@class = new Class2816();
			break;
		case 4019:
			@class = new Class2813();
			break;
		case 4020:
			@class = new Class2815();
			break;
		case 4021:
			@class = new Class2798();
			break;
		case 4022:
			@class = new Class2803();
			break;
		case 4023:
			@class = new Class2879();
			break;
		case 4026:
			@class = new Class2843();
			break;
		case 4033:
			@class = new Class2822();
			break;
		case 4035:
			@class = new Class2875();
			break;
		case 4040:
			if (parentRecord is Class2689)
			{
				@class = new Class2735();
				break;
			}
			if (parentRecord is Class2683)
			{
				@class = new Class2802();
				break;
			}
			throw new Exception();
		case 4041:
			@class = new Class2708();
			break;
		case 4044:
			@class = new Class2693(0);
			break;
		case 4045:
			@class = new Class2868();
			break;
		case 4046:
			@class = new Class2696(0);
			break;
		case 4049:
			@class = new Class2871();
			break;
		case 4050:
			@class = new Class2906();
			break;
		case 4051:
			@class = new Class2869();
			break;
		case 4055:
			@class = new Class2694();
			break;
		case 4056:
			@class = new Class2852(stf);
			break;
		case 4057:
			@class = new Class2709();
			break;
		case 4058:
			@class = new Class2881();
			break;
		case 4063:
			@class = new Class2862(stf);
			break;
		case 4068:
			@class = new Class2695();
			break;
		case 4071:
			@class = new Class2792();
			break;
		case 4074:
			@class = new Class2700(0);
			break;
		case 4078:
			@class = new Class2692(0);
			break;
		case 4080:
			@class = new Class2731();
			break;
		case 4081:
			@class = new Class2838();
			break;
		case 4082:
			@class = new Class2711(stf);
			break;
		case 4083:
			@class = new Class2882();
			break;
		case 4085:
			@class = new Class2895();
			break;
		case 4086:
			@class = new Class2844();
			break;
		case 4087:
			@class = new Class2847(stf);
			break;
		case 4088:
			@class = new Class2849(stf);
			break;
		case 4089:
			@class = new Class2850(stf);
			break;
		case 4090:
			@class = new Class2848(stf);
			break;
		case 4091:
			@class = new Class2867();
			break;
		case 4100:
			@class = new Class2872();
			break;
		case 4101:
			@class = new Class2703(0);
			break;
		case 4102:
			@class = new Class2690(0);
			break;
		case 4103:
			@class = new Class2697(0);
			break;
		case 4109:
			@class = new Class2698();
			break;
		case 4110:
			@class = new Class2691();
			break;
		case 4111:
			@class = new Class2704(0);
			break;
		case 4112:
			@class = new Class2705(0);
			break;
		case 4113:
			@class = new Class2771();
			break;
		case 4114:
			@class = new Class2866();
			break;
		case 4115:
			@class = new Class2878();
			break;
		case 4116:
			@class = new Class2672();
			break;
		case 4117:
			@class = new Class2851(stf);
			break;
		case 4120:
			@class = new Class2870();
			break;
		case 6020:
			@class = new Class2795();
			break;
		case 6021:
			@class = new Class2794();
			break;
		case 6010:
			@class = new Class2793();
			break;
		case 6011:
			@class = new Class2796();
			break;
		case 6013:
			@class = new Class2797();
			break;
		case 6014:
			@class = new Class2804();
			break;
		case 12017:
			@class = new Class2811();
			break;
		case 12000:
			@class = new Class2685();
			break;
		case 12001:
			@class = new Class2841();
			break;
		case 12004:
			@class = new Class2686();
			break;
		case 12005:
			@class = new Class2842();
			break;
		case 12006:
			@class = new Class2801();
			break;
		case 12007:
			@class = new Class2800();
			break;
		case 12010:
			@class = new Class2809();
			break;
		case 12012:
			@class = new Class2806();
			break;
		case 11003:
		{
			Enum401 @enum = (Enum401)reader.ReadUInt32();
			switch ((Enum409)reader.ReadUInt32())
			{
			default:
				@class = new Class2767();
				break;
			case Enum409.const_0:
			{
				Enum401 enum2 = @enum;
				@class = ((enum2 != Enum401.const_5) ? ((Class2767)new Class2769()) : ((Class2767)new Class2768()));
				break;
			}
			case Enum409.const_1:
				@class = new Class2770();
				break;
			}
			reader.BaseStream.Seek(-8L, SeekOrigin.Current);
			break;
		}
		case 11008:
			@class = new Class2880();
			break;
		case 11009:
			@class = new Class2766();
			break;
		case 11010:
			@class = new Class2684();
			break;
		case 11011:
			@class = new Class2839();
			break;
		case 11012:
			@class = new Class2647();
			break;
		case 11013:
			@class = new Class2824();
			break;
		case 11014:
			@class = new Class2648();
			break;
		case 11015:
			@class = new Class2823();
			break;
		case 11016:
			@class = new Class2646();
			break;
		case 11017:
			@class = new Class2886();
			break;
		case 11018:
			@class = new Class2821();
			break;
		case 11019:
			@class = new Class2774();
			break;
		case 11021:
			@class = new Class2780();
			break;
		case 14000:
			@class = new Class2814();
			break;
		case 14001:
			@class = new Class2812();
			break;
		case 14002:
			@class = new Class2805();
			break;
		case 14003:
			@class = new Class2807();
			break;
		case 13000:
			@class = new Class2808();
			break;
		case 12052:
			@class = new Class2687();
			break;
		case 61720:
			@class = new Class2819();
			break;
		case 61722:
			@class = new Class2820();
			break;
		case 61725:
			@class = new Class2818();
			break;
		case 61726:
			@class = new Class2900();
			break;
		case 61729:
			@class = new Class2817();
			break;
		case 61730:
			@class = new Class2837();
			break;
		case 61733:
			@class = new Class2657();
			break;
		case 61735:
			@class = new Class2755();
			break;
		case 61736:
			@class = new Class2750();
			break;
		case 61737:
			@class = new Class2753();
			break;
		case 61738:
			@class = new Class2654();
			break;
		case 61739:
			@class = new Class2652();
			break;
		case 61740:
			@class = new Class2655();
			break;
		case 61741:
			@class = new Class2658();
			break;
		case 61742:
			@class = new Class2659();
			break;
		case 61743:
			@class = new Class2663();
			break;
		case 61744:
			@class = new Class2664();
			break;
		case 61745:
			@class = new Class2665();
			break;
		case 61746:
			@class = new Class2656();
			break;
		case 61747:
			@class = new Class2747();
			break;
		case 61748:
			@class = new Class2745();
			break;
		case 61749:
			@class = new Class2748();
			break;
		case 61750:
			@class = new Class2751();
			break;
		case 61751:
			@class = new Class2754();
			break;
		case 61752:
			@class = new Class2756();
			break;
		case 61753:
			@class = new Class2757();
			break;
		case 61754:
			@class = new Class2759();
			break;
		case 61755:
			@class = new Class2749();
			break;
		case 61756:
			@class = new Class2649();
			break;
		case 61757:
			switch (parentRecord.Type)
			{
			default:
				@class = new Class2660();
				break;
			case 61764:
			case 61765:
				@class = new Class2662();
				break;
			case 61738:
				@class = new Class2661();
				break;
			}
			break;
		case 61758:
			@class = new Class2666();
			break;
		case 61759:
			@class = new Class2653();
			break;
		case 61760:
			@class = new Class2752();
			break;
		case 61761:
			@class = new Class2758();
			break;
		case 61762:
		{
			byte b = reader.ReadByte();
			@class = (Enum400)b switch
			{
				Enum400.const_0 => new Class2761(), 
				Enum400.const_1 => new Class2763(), 
				Enum400.const_2 => new Class2762(), 
				Enum400.const_3 => new Class2764(), 
				_ => throw new NotImplementedException($"Unknown TimeVariant type: {b}"), 
			};
			reader.BaseStream.Seek(-1L, SeekOrigin.Current);
			break;
		}
		case 61763:
			@class = new Class2746();
			break;
		case 61764:
			@class = new Class2650();
			break;
		case 61765:
			@class = new Class2651();
			break;
		case 61440:
			@class = new Class2644();
			break;
		case 61441:
			@class = new Class2640();
			break;
		case 61442:
			@class = new Class2643();
			break;
		case 61443:
			@class = new Class2671();
			break;
		case 61444:
			@class = new Class2670();
			break;
		case 61445:
			@class = new Class2668();
			break;
		case 61446:
			@class = new Class2744();
			break;
		case 61447:
			@class = new Class2638();
			break;
		case 61448:
			@class = new Class2743();
			break;
		case 61449:
			@class = new Class2836();
			break;
		case 61450:
			@class = new Class2835();
			break;
		case 61451:
			@class = new Class2834();
			break;
		case 61453:
			@class = new Class2642();
			break;
		case 61455:
			@class = new Class2741();
			break;
		case 61456:
			@class = new Class2742();
			break;
		case 61457:
			@class = new Class2641();
			break;
		case 61458:
			@class = new Class2626();
			break;
		case 61460:
			@class = new Class2625();
			break;
		case 61463:
			@class = new Class2627();
			break;
		default:
			@class = new Class2789();
			break;
		case 61466:
			@class = new Class2636();
			break;
		case 61467:
			@class = new Class2635();
			break;
		case 61468:
			@class = new Class2637();
			break;
		case 61469:
			@class = new Class2633();
			break;
		case 61470:
			@class = new Class2632();
			break;
		case 61471:
			@class = new Class2631();
			break;
		case 14100:
			@class = new Class2667();
			break;
		}
		@class.ParentRecord = parentRecord;
		return @class;
	}
}
