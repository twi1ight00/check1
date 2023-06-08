using System;

namespace ns67;

internal sealed class Class3435 : ICloneable
{
	private double double_0;

	private double double_1;

	private Class3458 class3458_0;

	private Enum481 enum481_0;

	public double FieldOfView
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Zoom
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public Class3458 Rotation
	{
		get
		{
			return class3458_0;
		}
		set
		{
			if (class3458_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3458_0 = value.method_0();
			}
		}
	}

	public Class3435()
		: this(Enum481.const_0)
	{
	}

	public Class3435(Enum481 prst)
	{
		enum481_0 = prst;
		double_0 = 0.0;
		double_1 = 100.0;
		switch (enum481_0)
		{
		case Enum481.const_1:
			class3458_0 = new Class3458(18882000.0, 2124000.0, 17988000.0);
			break;
		case Enum481.const_2:
			class3458_0 = new Class3458(2718000.0, 2124000.0, 3612000.0);
			break;
		case Enum481.const_3:
			class3458_0 = new Class3458(2700000.0, 2100000.0, 0.0);
			break;
		case Enum481.const_4:
			class3458_0 = new Class3458(2700000.0, 2100000.0, 0.0);
			break;
		case Enum481.const_5:
			class3458_0 = new Class3458(3840000.0, 1080000.0, 0.0);
			break;
		case Enum481.const_6:
			class3458_0 = new Class3458(20040000.0, 1080000.0, 0.0);
			break;
		case Enum481.const_7:
			class3458_0 = new Class3458(18390000.0, 18078000.0, 3456000.0);
			break;
		case Enum481.const_8:
			class3458_0 = new Class3458(1560000.0, 1080000.0, 0.0);
			break;
		case Enum481.const_9:
			class3458_0 = new Class3458(17760000.0, 1080000.0, 0.0);
			break;
		case Enum481.const_10:
			class3458_0 = new Class3458(3210000.0, 18078000.0, 18144000.0);
			break;
		case Enum481.const_11:
			class3458_0 = new Class3458(18390000.0, 3522000.0, 18144000.0);
			break;
		case Enum481.const_12:
			class3458_0 = new Class3458(3840000.0, 20520000.0, 0.0);
			break;
		case Enum481.const_13:
			class3458_0 = new Class3458(20040000.0, 20520000.0, 0.0);
			break;
		case Enum481.const_14:
			class3458_0 = new Class3458(3210000.0, 3522000.0, 3456000.0);
			break;
		case Enum481.const_15:
			class3458_0 = new Class3458(1560000.0, 20520000.0, 0.0);
			break;
		case Enum481.const_16:
			class3458_0 = new Class3458(18900000.0, 19500000.0, 0.0);
			break;
		case Enum481.const_18:
			class3458_0 = new Class3458(18900000.0, 2100000.0, 0.0);
			break;
		case Enum481.const_19:
			class3458_0 = new Class3458(2718000.0, 19476000.0, 17988000.0);
			break;
		case Enum481.const_20:
			class3458_0 = new Class3458(18882000.0, 19476000.0, 3612000.0);
			break;
		case Enum481.const_30:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_31:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_32:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_33:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_34:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_35:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_36:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_37:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_38:
			double_0 = 65.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		default:
			throw new NotImplementedException();
		case Enum481.const_0:
		case Enum481.const_47:
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_48:
			double_0 = 45.0;
			class3458_0 = new Class3458(0.0, 20400000.0, 0.0);
			break;
		case Enum481.const_49:
			double_0 = 45.0;
			class3458_0 = new Class3458(858000.0, 2358000.0, 20466000.0);
			break;
		case Enum481.const_50:
			double_0 = 45.0;
			class3458_0 = new Class3458(20742000.0, 2358000.0, 1134000.0);
			break;
		case Enum481.const_51:
			double_0 = 45.0;
			class3458_0 = new Class3458(0.0, 1200000.0, 0.0);
			break;
		case Enum481.const_52:
			double_0 = 45.0;
			class3458_0 = new Class3458(2634000.0, 624000.0, 21384000.0);
			break;
		case Enum481.const_53:
			double_0 = 45.0;
			class3458_0 = new Class3458(18966000.0, 624000.0, 216000.0);
			break;
		case Enum481.const_54:
			double_0 = 45.0;
			class3458_0 = new Class3458(0.0, 0.0, 0.0);
			break;
		case Enum481.const_55:
			double_0 = 45.0;
			class3458_0 = new Class3458(2070000.0, 486000.0, 21426000.0);
			break;
		case Enum481.const_56:
			double_0 = 45.0;
			class3458_0 = new Class3458(19530000.0, 486000.0, 174000.0);
			break;
		case Enum481.const_57:
			double_0 = 45.0;
			class3458_0 = new Class3458(858000.0, 20940000.0, 156000.0);
			break;
		case Enum481.const_58:
			double_0 = 45.0;
			class3458_0 = new Class3458(20742000.0, 20940000.0, 21444000.0);
			break;
		case Enum481.const_59:
			double_0 = 45.0;
			class3458_0 = new Class3458(1200000.0, 0.0, 0.0);
			break;
		case Enum481.const_60:
			double_0 = 45.0;
			class3458_0 = new Class3458(0.0, 18576000.0, 0.0);
			break;
		case Enum481.const_61:
			double_0 = 45.0;
			class3458_0 = new Class3458(0.0, 19488000.0, 0.0);
			break;
		case Enum481.const_62:
			double_0 = 45.0;
			class3458_0 = new Class3458(20400000.0, 0.0, 0.0);
			break;
		}
	}

	public Class3435(double fieldOfView, double zoom, Class3458 rotation)
	{
		FieldOfView = fieldOfView;
		Zoom = zoom;
		Rotation = rotation;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3435 method_0()
	{
		Class3435 @class = new Class3435(enum481_0);
		@class.FieldOfView = double_0;
		@class.Rotation = new Class3458(class3458_0.Latitude, class3458_0.Longitude, class3458_0.Revolution);
		@class.Zoom = double_1;
		return @class;
	}

	public static Enum481 smethod_0(string param)
	{
		return param switch
		{
			"isometricBottomDown" => Enum481.const_1, 
			"isometricBottomUp" => Enum481.const_2, 
			"isometricLeftDown" => Enum481.const_3, 
			"isometricLeftUp" => Enum481.const_4, 
			"isometricOffAxis1Left" => Enum481.const_5, 
			"isometricOffAxis1Right" => Enum481.const_6, 
			"isometricOffAxis1Top" => Enum481.const_7, 
			"isometricOffAxis2Left" => Enum481.const_8, 
			"isometricOffAxis2Right" => Enum481.const_9, 
			"isometricOffAxis2Top" => Enum481.const_10, 
			"isometricOffAxis3Bottom" => Enum481.const_11, 
			"isometricOffAxis3Left" => Enum481.const_12, 
			"isometricOffAxis3Right" => Enum481.const_13, 
			"isometricOffAxis4Bottom" => Enum481.const_14, 
			"isometricOffAxis4Left" => Enum481.const_15, 
			"isometricOffAxis4Right" => Enum481.const_16, 
			"isometricRightDown" => Enum481.const_17, 
			"isometricRightUp" => Enum481.const_18, 
			"isometricTopDown" => Enum481.const_19, 
			"isometricTopUp" => Enum481.const_20, 
			"legacyObliqueBottom" => Enum481.const_21, 
			"legacyObliqueBottomLeft" => Enum481.const_22, 
			"legacyObliqueBottomRight" => Enum481.const_23, 
			"legacyObliqueFront" => Enum481.const_24, 
			"legacyObliqueLeft" => Enum481.const_25, 
			"legacyObliqueRight" => Enum481.const_26, 
			"legacyObliqueTop" => Enum481.const_27, 
			"legacyObliqueTopLeft" => Enum481.const_28, 
			"legacyObliqueTopRight" => Enum481.const_29, 
			"legacyPerspectiveBottom" => Enum481.const_30, 
			"legacyPerspectiveBottomLeft" => Enum481.const_31, 
			"legacyPerspectiveBottomRight" => Enum481.const_32, 
			"legacyPerspectiveFront" => Enum481.const_33, 
			"legacyPerspectiveLeft" => Enum481.const_34, 
			"legacyPerspectiveRight" => Enum481.const_35, 
			"legacyPerspectiveTop" => Enum481.const_36, 
			"legacyPerspectiveTopLeft" => Enum481.const_37, 
			"legacyPerspectiveTopRight" => Enum481.const_38, 
			"obliqueBottom" => Enum481.const_39, 
			"obliqueBottomLeft" => Enum481.const_40, 
			"obliqueBottomRight" => Enum481.const_41, 
			"obliqueLeft" => Enum481.const_42, 
			"obliqueRight" => Enum481.const_43, 
			"obliqueTop" => Enum481.const_44, 
			"obliqueTopLeft" => Enum481.const_45, 
			"obliqueTopRight" => Enum481.const_46, 
			"orthographicFront" => Enum481.const_47, 
			"perspectiveAbove" => Enum481.const_48, 
			"perspectiveAboveLeftFacing" => Enum481.const_49, 
			"perspectiveAboveRightFacing" => Enum481.const_50, 
			"perspectiveBelow" => Enum481.const_51, 
			"perspectiveContrastingLeftFacing" => Enum481.const_52, 
			"perspectiveContrastingRightFacing" => Enum481.const_53, 
			"perspectiveFront" => Enum481.const_54, 
			"perspectiveHeroicExtremeLeftFacing" => Enum481.const_55, 
			"perspectiveHeroicExtremeRightFacing" => Enum481.const_56, 
			"perspectiveHeroicLeftFacing" => Enum481.const_57, 
			"perspectiveHeroicRightFacing" => Enum481.const_58, 
			"perspectiveLeft" => Enum481.const_59, 
			"perspectiveRelaxed" => Enum481.const_60, 
			"perspectiveRelaxedModerately" => Enum481.const_61, 
			"perspectiveRight" => Enum481.const_62, 
			_ => throw new ArgumentOutOfRangeException("param"), 
		};
	}

	internal void method_1(Interface53 device)
	{
		class3458_0.method_1(device);
		device.imethod_13(double_1 / 100.0);
	}

	public void method_2(Interface53 device)
	{
		switch (enum481_0)
		{
		default:
			throw new NotImplementedException("Unknown CameraPresetType.");
		case Enum481.const_21:
		case Enum481.const_22:
		case Enum481.const_23:
		case Enum481.const_24:
		case Enum481.const_25:
		case Enum481.const_26:
		case Enum481.const_27:
		case Enum481.const_28:
		case Enum481.const_29:
		case Enum481.const_39:
		case Enum481.const_40:
		case Enum481.const_41:
		case Enum481.const_42:
		case Enum481.const_43:
		case Enum481.const_44:
		case Enum481.const_45:
		case Enum481.const_46:
			throw new NotImplementedException();
		case Enum481.const_0:
		case Enum481.const_1:
		case Enum481.const_2:
		case Enum481.const_3:
		case Enum481.const_4:
		case Enum481.const_5:
		case Enum481.const_6:
		case Enum481.const_7:
		case Enum481.const_8:
		case Enum481.const_9:
		case Enum481.const_10:
		case Enum481.const_11:
		case Enum481.const_12:
		case Enum481.const_13:
		case Enum481.const_14:
		case Enum481.const_15:
		case Enum481.const_16:
		case Enum481.const_17:
		case Enum481.const_18:
		case Enum481.const_19:
		case Enum481.const_20:
		case Enum481.const_47:
			device.imethod_16();
			break;
		case Enum481.const_30:
		case Enum481.const_31:
		case Enum481.const_32:
		case Enum481.const_33:
		case Enum481.const_34:
		case Enum481.const_35:
		case Enum481.const_36:
		case Enum481.const_37:
		case Enum481.const_38:
		case Enum481.const_48:
		case Enum481.const_49:
		case Enum481.const_50:
		case Enum481.const_51:
		case Enum481.const_52:
		case Enum481.const_53:
		case Enum481.const_54:
		case Enum481.const_55:
		case Enum481.const_56:
		case Enum481.const_57:
		case Enum481.const_58:
		case Enum481.const_59:
		case Enum481.const_60:
		case Enum481.const_61:
		case Enum481.const_62:
			device.imethod_17(double_0);
			break;
		}
	}
}
