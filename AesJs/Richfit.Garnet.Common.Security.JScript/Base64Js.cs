using System;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Richfit.Garnet.Common.Security.JScript;

[Serializable]
public class Base64Js : INeedEngine
{
	public static object chars;

	[NonSerialized]
	private VsaEngine vsa_0020Engine;

	static Base64Js()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
	}

	public static object btoa(object input)
	{
		LateBinding lateBinding = new LateBinding("charAt");
		BitwiseBinary bitwiseBinary = new BitwiseBinary(62);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(52);
		Plus plus = new Plus();
		Relational relational = new Relational(57);
		BitwiseBinary bitwiseBinary3 = new BitwiseBinary(61);
		BitwiseBinary bitwiseBinary4 = new BitwiseBinary(50);
		string thisob = GlobalObject.String.Invoke(input);
		object v = 0;
		object obj = 0;
		double num = 0.0;
		object value = chars;
		object obj2 = "";
		while (true)
		{
			if (!(bool)Microsoft.JScript.Convert.Coerce2(StringPrototype.charAt(thisob, (int)Runtime.DoubleToInt64(num) | 0), TypeCode.Boolean, truncationPermitted: true))
			{
				value = "=";
				if (!Microsoft.JScript.Convert.ToBoolean(num % 1.0))
				{
					break;
				}
			}
			double pos;
			num = (pos = num + 0.75);
			obj = StringPrototype.charCodeAt(thisob, pos);
			if (relational.EvaluateRelational(obj, 255) > 0.0)
			{
				throw Throw.JScriptThrow(GlobalObject.Error.CreateInstance("'btoa' failed: The string to be encoded contains characters outside of the Latin1 range."));
			}
			v = bitwiseBinary4.EvaluateBitwiseBinary(bitwiseBinary3.EvaluateBitwiseBinary(v, 8), obj);
			object v2 = obj2;
			lateBinding.obj = Microsoft.JScript.Convert.ToObject(value, VsaEngine.CreateEngineWithType(typeof(Base64Js).TypeHandle));
			obj2 = plus.EvaluatePlus(v2, lateBinding.Call(new object[1] { bitwiseBinary2.EvaluateBitwiseBinary(63, bitwiseBinary.EvaluateBitwiseBinary(v, 8.0 - num % 1.0 * 8.0)) }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(Base64Js).TypeHandle)));
		}
		return obj2;
	}

	public static object atob(object input)
	{
		NumericUnary numericUnary = new NumericUnary(40);
		NumericBinary numericBinary = new NumericBinary(64);
		Plus plus = new Plus();
		BitwiseBinary bitwiseBinary = new BitwiseBinary(62);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(52);
		LateBinding lateBinding = new LateBinding("indexOf");
		RegExpObject regExp = GlobalObject.RegExp.CreateInstance("=+$");
		string text = StringPrototype.replace(GlobalObject.String.Invoke(input), regExp, "");
		if ((double)text.Length % 4.0 == 1.0)
		{
			throw Throw.JScriptThrow(GlobalObject.Error.CreateInstance("'atob' failed: The string to be decoded is not correctly encoded."));
		}
		double num = 0.0;
		object v = 0;
		object obj = 0;
		double num2 = 0.0;
		object obj2 = "";
		while (true)
		{
			double pos;
			num2 = (pos = num2) + 1.0;
			string value;
			obj = (value = StringPrototype.charAt(text, pos));
			if (!(bool)Microsoft.JScript.Convert.Coerce2(value, TypeCode.Boolean, truncationPermitted: true))
			{
				break;
			}
			lateBinding.obj = Microsoft.JScript.Convert.ToObject(chars, VsaEngine.CreateEngineWithType(typeof(Base64Js).TypeHandle));
			obj = lateBinding.Call(new object[1] { obj }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(Base64Js).TypeHandle));
			if (Microsoft.JScript.Convert.ToBoolean(numericUnary.EvaluateUnary(obj), explicitConversion: true))
			{
				v = ((!Microsoft.JScript.Convert.ToBoolean(num % 4.0)) ? obj : plus.EvaluatePlus(numericBinary.EvaluateNumericBinary(v, 64), obj));
				double num3;
				num = (num3 = num) + 1.0;
				if (Microsoft.JScript.Convert.ToBoolean(num3 % 4.0))
				{
					obj2 = Plus.DoOp(Microsoft.JScript.Convert.ToString(obj2, explicitOK: true), StringConstructor.fromCharCode(bitwiseBinary2.EvaluateBitwiseBinary(255, bitwiseBinary.EvaluateBitwiseBinary(v, (int)Runtime.DoubleToInt64(-2.0 * num) & 6))));
				}
			}
		}
		return obj2;
	}

	private void _002Einit()
	{
	}//Error decoding local variables: Signature type sequence must have at least one element.


	public Base64Js()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		_002Einit();
	}

	private virtual VsaEngine GetEngine()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (vsa_0020Engine == null)
		{
			vsa_0020Engine = VsaEngine.CreateEngineWithType(typeof(Base64Js).TypeHandle);
		}
		return vsa_0020Engine;
	}

	VsaEngine INeedEngine.GetEngine()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEngine
		return this.GetEngine();
	}

	private virtual void SetEngine(VsaEngine P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		vsa_0020Engine = P_0;
	}

	void INeedEngine.SetEngine(VsaEngine P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetEngine
		this.SetEngine(P_0);
	}
}
