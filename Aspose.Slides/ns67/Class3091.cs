using System;

namespace ns67;

internal abstract class Class3091 : Class3090
{
	public abstract Enum493 Kind { get; }

	public static Enum493 smethod_12(string param)
	{
		return param switch
		{
			"accentBorderCallout1" => Enum493.const_113, 
			"accentBorderCallout2" => Enum493.const_114, 
			"accentBorderCallout3" => Enum493.const_115, 
			"accentCallout1" => Enum493.const_107, 
			"accentCallout2" => Enum493.const_108, 
			"accentCallout3" => Enum493.const_109, 
			"actionButtonBackPrevious" => Enum493.const_165, 
			"actionButtonBeginning" => Enum493.const_167, 
			"actionButtonBlank" => Enum493.const_160, 
			"actionButtonDocument" => Enum493.const_169, 
			"actionButtonEnd" => Enum493.const_166, 
			"actionButtonForwardNext" => Enum493.const_164, 
			"actionButtonHelp" => Enum493.const_162, 
			"actionButtonHome" => Enum493.const_161, 
			"actionButtonInformation" => Enum493.const_163, 
			"actionButtonMovie" => Enum493.const_171, 
			"actionButtonReturn" => Enum493.const_168, 
			"actionButtonSound" => Enum493.const_170, 
			"arc" => Enum493.const_88, 
			"bentArrow" => Enum493.const_62, 
			"bentConnector2" => Enum493.const_96, 
			"bentConnector3" => Enum493.const_97, 
			"bentConnector4" => Enum493.const_98, 
			"bentConnector5" => Enum493.const_99, 
			"bentUpArrow" => Enum493.const_49, 
			"bevel" => Enum493.const_82, 
			"blockArc" => Enum493.const_40, 
			"borderCallout1" => Enum493.const_110, 
			"borderCallout2" => Enum493.const_111, 
			"borderCallout3" => Enum493.const_112, 
			"bracePair" => Enum493.const_94, 
			"bracketPair" => Enum493.const_93, 
			"callout1" => Enum493.const_104, 
			"callout2" => Enum493.const_105, 
			"callout3" => Enum493.const_106, 
			"can" => Enum493.const_73, 
			"chartPlus" => Enum493.const_186, 
			"chartStar" => Enum493.const_185, 
			"chartX" => Enum493.const_184, 
			"chevron" => Enum493.const_37, 
			"chord" => Enum493.const_87, 
			"circularArrow" => Enum493.const_64, 
			"cloud" => Enum493.const_120, 
			"cloudCallout" => Enum493.const_119, 
			"corner" => Enum493.const_85, 
			"cornerTabs" => Enum493.const_181, 
			"cube" => Enum493.const_72, 
			"curvedConnector2" => Enum493.const_100, 
			"curvedConnector3" => Enum493.const_101, 
			"curvedConnector4" => Enum493.const_102, 
			"curvedConnector5" => Enum493.const_103, 
			"curvedDownArrow" => Enum493.const_70, 
			"curvedLeftArrow" => Enum493.const_68, 
			"curvedRightArrow" => Enum493.const_67, 
			"curvedUpArrow" => Enum493.const_69, 
			"decagon" => Enum493.const_13, 
			"diagStripe" => Enum493.const_86, 
			"diamond" => Enum493.const_5, 
			"dodecagon" => Enum493.const_14, 
			"donut" => Enum493.const_41, 
			"doubleWave" => Enum493.const_129, 
			"downArrow" => Enum493.const_46, 
			"downArrowCallout" => Enum493.const_58, 
			"ellipse" => Enum493.const_34, 
			"ellipseRibbon" => Enum493.const_123, 
			"ellipseRibbon2" => Enum493.const_124, 
			"flowChartAlternateProcess" => Enum493.const_158, 
			"flowChartCollate" => Enum493.const_147, 
			"flowChartConnector" => Enum493.const_142, 
			"flowChartDecision" => Enum493.const_132, 
			"flowChartDelay" => Enum493.const_157, 
			"flowChartDisplay" => Enum493.const_156, 
			"flowChartDocument" => Enum493.const_136, 
			"flowChartExtract" => Enum493.const_149, 
			"flowChartInputOutput" => Enum493.const_133, 
			"flowChartInternalStorage" => Enum493.const_135, 
			"flowChartMagneticDisk" => Enum493.const_154, 
			"flowChartMagneticDrum" => Enum493.const_155, 
			"flowChartMagneticTape" => Enum493.const_153, 
			"flowChartManualInput" => Enum493.const_140, 
			"flowChartManualOperation" => Enum493.const_141, 
			"flowChartMerge" => Enum493.const_150, 
			"flowChartMultidocument" => Enum493.const_137, 
			"flowChartOfflineStorage" => Enum493.const_151, 
			"flowChartOffpageConnector" => Enum493.const_159, 
			"flowChartOnlineStorage" => Enum493.const_152, 
			"flowChartOr" => Enum493.const_146, 
			"flowChartPredefinedProcess" => Enum493.const_134, 
			"flowChartPreparation" => Enum493.const_139, 
			"flowChartProcess" => Enum493.const_131, 
			"flowChartPunchedCard" => Enum493.const_143, 
			"flowChartPunchedTape" => Enum493.const_144, 
			"flowChartSort" => Enum493.const_148, 
			"flowChartSummingJunction" => Enum493.const_145, 
			"flowChartTerminator" => Enum493.const_138, 
			"foldedCorner" => Enum493.const_81, 
			"frame" => Enum493.const_83, 
			"funnel" => Enum493.const_174, 
			"gear6" => Enum493.const_172, 
			"gear9" => Enum493.const_173, 
			"halfFrame" => Enum493.const_84, 
			"heart" => Enum493.const_75, 
			"heptagon" => Enum493.const_11, 
			"hexagon" => Enum493.const_10, 
			"homePlate" => Enum493.const_36, 
			"horizontalScroll" => Enum493.const_127, 
			"irregularSeal1" => Enum493.const_79, 
			"irregularSeal2" => Enum493.const_80, 
			"leftArrow" => Enum493.const_44, 
			"leftArrowCallout" => Enum493.const_55, 
			"leftBrace" => Enum493.const_91, 
			"leftBracket" => Enum493.const_89, 
			"leftCircularArrow" => Enum493.const_65, 
			"leftRightArrow" => Enum493.const_50, 
			"leftRightArrowCallout" => Enum493.const_59, 
			"leftRightCircularArrow" => Enum493.const_66, 
			"leftRightRibbon" => Enum493.const_125, 
			"leftRightUpArrow" => Enum493.const_53, 
			"leftUpArrow" => Enum493.const_52, 
			"lightningBolt" => Enum493.const_74, 
			"line" => Enum493.const_0, 
			"lineInv" => Enum493.const_1, 
			"mathDivide" => Enum493.const_178, 
			"mathEqual" => Enum493.const_179, 
			"mathMinus" => Enum493.const_176, 
			"mathMultiply" => Enum493.const_177, 
			"mathNotEqual" => Enum493.const_180, 
			"mathPlus" => Enum493.const_175, 
			"moon" => Enum493.const_77, 
			"nonIsoscelesTrapezoid" => Enum493.const_8, 
			"noSmoking" => Enum493.const_42, 
			"notchedRightArrow" => Enum493.const_48, 
			"octagon" => Enum493.const_12, 
			"parallelogram" => Enum493.const_6, 
			"pentagon" => Enum493.const_9, 
			"pie" => Enum493.const_39, 
			"pieWedge" => Enum493.const_38, 
			"plaque" => Enum493.const_33, 
			"plaqueTabs" => Enum493.const_183, 
			"plus" => Enum493.const_130, 
			"quadArrow" => Enum493.const_54, 
			"quadArrowCallout" => Enum493.const_61, 
			"rect" => Enum493.const_4, 
			"ribbon" => Enum493.const_121, 
			"ribbon2" => Enum493.const_122, 
			"rightArrow" => Enum493.const_43, 
			"rightArrowCallout" => Enum493.const_56, 
			"rightBrace" => Enum493.const_92, 
			"rightBracket" => Enum493.const_90, 
			"round1Rect" => Enum493.const_26, 
			"round2DiagRect" => Enum493.const_28, 
			"round2SameRect" => Enum493.const_27, 
			"roundRect" => Enum493.const_25, 
			"rtTriangle" => Enum493.const_3, 
			"smileyFace" => Enum493.const_78, 
			"snip1Rect" => Enum493.const_30, 
			"snip2DiagRect" => Enum493.const_32, 
			"snip2SameRect" => Enum493.const_31, 
			"snipRoundRect" => Enum493.const_29, 
			"squareTabs" => Enum493.const_182, 
			"star10" => Enum493.const_20, 
			"star12" => Enum493.const_21, 
			"star16" => Enum493.const_22, 
			"star24" => Enum493.const_23, 
			"star32" => Enum493.const_24, 
			"star4" => Enum493.const_15, 
			"star5" => Enum493.const_16, 
			"star6" => Enum493.const_17, 
			"star7" => Enum493.const_18, 
			"star8" => Enum493.const_19, 
			"straightConnector1" => Enum493.const_95, 
			"stripedRightArrow" => Enum493.const_47, 
			"sun" => Enum493.const_76, 
			"swooshArrow" => Enum493.const_71, 
			"teardrop" => Enum493.const_35, 
			"trapezoid" => Enum493.const_7, 
			"triangle" => Enum493.const_2, 
			"upArrow" => Enum493.const_45, 
			"upArrowCallout" => Enum493.const_57, 
			"upDownArrow" => Enum493.const_51, 
			"upDownArrowCallout" => Enum493.const_60, 
			"uturnArrow" => Enum493.const_63, 
			"verticalScroll" => Enum493.const_126, 
			"wave" => Enum493.const_128, 
			"wedgeEllipseCallout" => Enum493.const_118, 
			"wedgeRectCallout" => Enum493.const_116, 
			"wedgeRoundRectCallout" => Enum493.const_117, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}

	public static Class3091 smethod_13(Enum493 kind, Class3448 xfrm)
	{
		return kind switch
		{
			Enum493.const_0 => new Class3213(xfrm), 
			Enum493.const_1 => new Class3214(xfrm), 
			Enum493.const_2 => new Class3269(xfrm), 
			Enum493.const_3 => new Class3242(xfrm), 
			Enum493.const_4 => new Class3235(xfrm), 
			Enum493.const_5 => new Class3150(xfrm), 
			Enum493.const_6 => new Class3226(xfrm), 
			Enum493.const_7 => new Class3268(xfrm), 
			Enum493.const_8 => new Class3222(xfrm), 
			Enum493.const_9 => new Class3227(xfrm), 
			Enum493.const_10 => new Class3196(xfrm), 
			Enum493.const_11 => new Class3195(xfrm), 
			Enum493.const_12 => new Class3225(xfrm), 
			Enum493.const_13 => new Class3148(xfrm), 
			Enum493.const_14 => new Class3151(xfrm), 
			Enum493.const_15 => new Class3258(xfrm), 
			Enum493.const_16 => new Class3259(xfrm), 
			Enum493.const_17 => new Class3260(xfrm), 
			Enum493.const_18 => new Class3261(xfrm), 
			Enum493.const_19 => new Class3262(xfrm), 
			Enum493.const_20 => new Class3253(xfrm), 
			Enum493.const_21 => new Class3254(xfrm), 
			Enum493.const_22 => new Class3255(xfrm), 
			Enum493.const_23 => new Class3256(xfrm), 
			Enum493.const_24 => new Class3257(xfrm), 
			Enum493.const_25 => new Class3246(xfrm), 
			Enum493.const_26 => new Class3243(xfrm), 
			Enum493.const_27 => new Class3245(xfrm), 
			Enum493.const_28 => new Class3244(xfrm), 
			Enum493.const_29 => new Class3251(xfrm), 
			Enum493.const_30 => new Class3248(xfrm), 
			Enum493.const_31 => new Class3250(xfrm), 
			Enum493.const_32 => new Class3249(xfrm), 
			Enum493.const_33 => new Class3230(xfrm), 
			Enum493.const_34 => new Class3156(xfrm), 
			Enum493.const_35 => new Class3267(xfrm), 
			Enum493.const_36 => new Class3197(xfrm), 
			Enum493.const_37 => new Class3132(xfrm), 
			Enum493.const_38 => new Class3229(xfrm), 
			Enum493.const_39 => new Class3228(xfrm), 
			Enum493.const_40 => new Class3119(xfrm), 
			Enum493.const_41 => new Class3152(xfrm), 
			Enum493.const_42 => new Class3223(xfrm), 
			Enum493.const_43 => new Class3239(xfrm), 
			Enum493.const_44 => new Class3202(xfrm), 
			Enum493.const_45 => throw new NotImplementedException("PresetGeometryKind.UpArrow has not been found in XML template file."), 
			Enum493.const_46 => new Class3155(xfrm), 
			Enum493.const_47 => new Class3264(xfrm), 
			Enum493.const_48 => new Class3224(xfrm), 
			Enum493.const_49 => new Class3117(xfrm), 
			Enum493.const_50 => new Class3207(xfrm), 
			Enum493.const_51 => new Class3272(xfrm), 
			Enum493.const_52 => new Class3211(xfrm), 
			Enum493.const_53 => new Class3210(xfrm), 
			Enum493.const_54 => new Class3234(xfrm), 
			Enum493.const_55 => new Class3201(xfrm), 
			Enum493.const_56 => new Class3238(xfrm), 
			Enum493.const_57 => new Class3270(xfrm), 
			Enum493.const_58 => new Class3154(xfrm), 
			Enum493.const_59 => new Class3206(xfrm), 
			Enum493.const_60 => new Class3271(xfrm), 
			Enum493.const_61 => new Class3233(xfrm), 
			Enum493.const_62 => new Class3112(xfrm), 
			Enum493.const_63 => new Class3273(xfrm), 
			Enum493.const_64 => new Class3134(xfrm), 
			Enum493.const_65 => new Class3205(xfrm), 
			Enum493.const_66 => new Class3208(xfrm), 
			Enum493.const_67 => new Class3146(xfrm), 
			Enum493.const_68 => new Class3145(xfrm), 
			Enum493.const_69 => new Class3147(xfrm), 
			Enum493.const_70 => new Class3144(xfrm), 
			Enum493.const_71 => new Class3266(xfrm), 
			Enum493.const_72 => new Class3139(xfrm), 
			Enum493.const_73 => new Class3128(xfrm), 
			Enum493.const_74 => new Class3212(xfrm), 
			Enum493.const_75 => new Class3194(xfrm), 
			Enum493.const_76 => new Class3265(xfrm), 
			Enum493.const_77 => new Class3221(xfrm), 
			Enum493.const_78 => new Class3247(xfrm), 
			Enum493.const_79 => new Class3199(xfrm), 
			Enum493.const_80 => new Class3200(xfrm), 
			Enum493.const_81 => new Class3188(xfrm), 
			Enum493.const_82 => new Class3118(xfrm), 
			Enum493.const_83 => new Class3189(xfrm), 
			Enum493.const_84 => new Class3193(xfrm), 
			Enum493.const_85 => new Class3137(xfrm), 
			Enum493.const_86 => new Class3149(xfrm), 
			Enum493.const_87 => new Class3133(xfrm), 
			Enum493.const_88 => new Class3111(xfrm), 
			Enum493.const_89 => new Class3204(xfrm), 
			Enum493.const_90 => new Class3241(xfrm), 
			Enum493.const_91 => new Class3203(xfrm), 
			Enum493.const_92 => new Class3240(xfrm), 
			Enum493.const_93 => new Class3124(xfrm), 
			Enum493.const_94 => new Class3123(xfrm), 
			Enum493.const_95 => new Class3263(xfrm), 
			Enum493.const_96 => new Class3113(xfrm), 
			Enum493.const_97 => new Class3114(xfrm), 
			Enum493.const_98 => new Class3115(xfrm), 
			Enum493.const_99 => new Class3116(xfrm), 
			Enum493.const_100 => new Class3140(xfrm), 
			Enum493.const_101 => new Class3141(xfrm), 
			Enum493.const_102 => new Class3142(xfrm), 
			Enum493.const_103 => new Class3143(xfrm), 
			Enum493.const_104 => new Class3125(xfrm), 
			Enum493.const_105 => new Class3126(xfrm), 
			Enum493.const_106 => new Class3127(xfrm), 
			Enum493.const_107 => new Class3096(xfrm), 
			Enum493.const_108 => new Class3097(xfrm), 
			Enum493.const_109 => new Class3098(xfrm), 
			Enum493.const_110 => new Class3120(xfrm), 
			Enum493.const_111 => new Class3121(xfrm), 
			Enum493.const_112 => new Class3122(xfrm), 
			Enum493.const_113 => new Class3093(xfrm), 
			Enum493.const_114 => new Class3094(xfrm), 
			Enum493.const_115 => new Class3095(xfrm), 
			Enum493.const_116 => new Class3277(xfrm), 
			Enum493.const_117 => new Class3278(xfrm), 
			Enum493.const_118 => new Class3276(xfrm), 
			Enum493.const_119 => new Class3135(xfrm), 
			Enum493.const_120 => new Class3136(xfrm), 
			Enum493.const_121 => new Class3237(xfrm), 
			Enum493.const_122 => new Class3236(xfrm), 
			Enum493.const_123 => new Class3158(xfrm), 
			Enum493.const_124 => new Class3157(xfrm), 
			Enum493.const_125 => new Class3209(xfrm), 
			Enum493.const_126 => new Class3274(xfrm), 
			Enum493.const_127 => new Class3198(xfrm), 
			Enum493.const_128 => new Class3275(xfrm), 
			Enum493.const_129 => new Class3153(xfrm), 
			Enum493.const_130 => new Class3232(xfrm), 
			Enum493.const_131 => new Class3182(xfrm), 
			Enum493.const_132 => new Class3162(xfrm), 
			Enum493.const_133 => new Class3167(xfrm), 
			Enum493.const_134 => new Class3180(xfrm), 
			Enum493.const_135 => new Class3168(xfrm), 
			Enum493.const_136 => new Class3165(xfrm), 
			Enum493.const_137 => new Class3175(xfrm), 
			Enum493.const_138 => new Class3187(xfrm), 
			Enum493.const_139 => new Class3181(xfrm), 
			Enum493.const_140 => new Class3172(xfrm), 
			Enum493.const_141 => new Class3173(xfrm), 
			Enum493.const_142 => new Class3161(xfrm), 
			Enum493.const_143 => new Class3183(xfrm), 
			Enum493.const_144 => new Class3184(xfrm), 
			Enum493.const_145 => new Class3186(xfrm), 
			Enum493.const_146 => new Class3179(xfrm), 
			Enum493.const_147 => new Class3160(xfrm), 
			Enum493.const_148 => new Class3185(xfrm), 
			Enum493.const_149 => new Class3166(xfrm), 
			Enum493.const_150 => new Class3174(xfrm), 
			Enum493.const_151 => new Class3176(xfrm), 
			Enum493.const_152 => new Class3178(xfrm), 
			Enum493.const_153 => new Class3171(xfrm), 
			Enum493.const_154 => new Class3169(xfrm), 
			Enum493.const_155 => new Class3170(xfrm), 
			Enum493.const_156 => new Class3164(xfrm), 
			Enum493.const_157 => new Class3163(xfrm), 
			Enum493.const_158 => new Class3159(xfrm), 
			Enum493.const_159 => new Class3177(xfrm), 
			Enum493.const_160 => new Class3101(xfrm), 
			Enum493.const_161 => new Class3106(xfrm), 
			Enum493.const_162 => new Class3105(xfrm), 
			Enum493.const_163 => new Class3107(xfrm), 
			Enum493.const_164 => new Class3104(xfrm), 
			Enum493.const_165 => new Class3099(xfrm), 
			Enum493.const_166 => new Class3103(xfrm), 
			Enum493.const_167 => new Class3100(xfrm), 
			Enum493.const_168 => new Class3109(xfrm), 
			Enum493.const_169 => new Class3102(xfrm), 
			Enum493.const_170 => new Class3110(xfrm), 
			Enum493.const_171 => new Class3108(xfrm), 
			Enum493.const_172 => new Class3191(xfrm), 
			Enum493.const_173 => new Class3192(xfrm), 
			Enum493.const_174 => new Class3190(xfrm), 
			Enum493.const_175 => new Class3220(xfrm), 
			Enum493.const_176 => new Class3217(xfrm), 
			Enum493.const_177 => new Class3218(xfrm), 
			Enum493.const_178 => new Class3215(xfrm), 
			Enum493.const_179 => new Class3216(xfrm), 
			Enum493.const_180 => new Class3219(xfrm), 
			Enum493.const_181 => new Class3138(xfrm), 
			Enum493.const_182 => new Class3252(xfrm), 
			Enum493.const_183 => new Class3231(xfrm), 
			Enum493.const_184 => new Class3131(xfrm), 
			Enum493.const_185 => new Class3130(xfrm), 
			Enum493.const_186 => new Class3129(xfrm), 
			_ => throw new ArgumentOutOfRangeException("kind"), 
		};
	}

	public abstract Class3279 vmethod_1();

	protected Class3091(Class3448 transform2D)
		: base(transform2D)
	{
	}
}
