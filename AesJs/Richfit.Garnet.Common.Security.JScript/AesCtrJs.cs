using System;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Richfit.Garnet.Common.Security.JScript;

[Serializable]
public class AesCtrJs : INeedEngine
{
	[NonSerialized]
	private VsaEngine vsa_0020Engine;

	static AesCtrJs()
	{
	}//Error decoding local variables: Signature type sequence must have at least one element.


	public static object encrypt(object plaintext, object password, object nBits)
	{
		Equality equality = new Equality(53);
		Equality equality2 = new Equality(53);
		Equality equality3 = new Equality(53);
		NumericBinary numericBinary = new NumericBinary(65);
		Relational relational = new Relational(58);
		LateBinding lateBinding = new LateBinding("length");
		Relational relational2 = new Relational(58);
		LateBinding lateBinding2 = new LateBinding("charCodeAt");
		LateBinding lateBinding3 = new LateBinding("concat");
		LateBinding lateBinding4 = new LateBinding("slice");
		NumericBinary numericBinary2 = new NumericBinary(47);
		LateBinding lateBinding5 = new LateBinding("getTime");
		NumericBinary numericBinary3 = new NumericBinary(66);
		NumericBinary numericBinary4 = new NumericBinary(65);
		BitwiseBinary bitwiseBinary = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(52);
		BitwiseBinary bitwiseBinary3 = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary4 = new BitwiseBinary(52);
		BitwiseBinary bitwiseBinary5 = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary6 = new BitwiseBinary(52);
		LateBinding lateBinding6 = new LateBinding("length");
		NumericBinary numericBinary5 = new NumericBinary(65);
		BitwiseBinary bitwiseBinary7 = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary8 = new BitwiseBinary(52);
		NumericBinary numericBinary6 = new NumericBinary(65);
		BitwiseBinary bitwiseBinary9 = new BitwiseBinary(63);
		LateBinding lateBinding7 = new LateBinding("length");
		NumericBinary numericBinary7 = new NumericBinary(47);
		NumericBinary numericBinary8 = new NumericBinary(66);
		Plus plus = new Plus();
		Relational relational3 = new Relational(58);
		LateBinding lateBinding8 = new LateBinding("charCodeAt");
		BitwiseBinary bitwiseBinary10 = new BitwiseBinary(51);
		LateBinding lateBinding9 = new LateBinding("join");
		Plus plus2 = new Plus();
		Plus plus3 = new Plus();
		double num = 16.0;
		if (!equality.EvaluateEquality(nBits, 128) && !equality2.EvaluateEquality(nBits, 192) && !equality3.EvaluateEquality(nBits, 256))
		{
			throw Throw.JScriptThrow(GlobalObject.Error.CreateInstance("Key size is not 128 / 192 / 256"));
		}
		plaintext = utf8Encode(GlobalObject.String.Invoke(plaintext));
		password = utf8Encode(GlobalObject.String.Invoke(password));
		object obj = numericBinary.EvaluateNumericBinary(nBits, 8);
		ArrayObject arrayObject = GlobalObject.Array.CreateInstance(obj);
		for (double num2 = 0.0; relational.EvaluateRelational(num2, obj) < 0.0; num2 += 1.0)
		{
			double index = num2;
			object v = num2;
			lateBinding.obj = Microsoft.JScript.Convert.ToObject(password, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			object value;
			if (relational2.EvaluateRelational(v, lateBinding.GetNonMissingValue()) < 0.0)
			{
				lateBinding2.obj = Microsoft.JScript.Convert.ToObject(password, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				value = lateBinding2.Call(new object[1] { num2 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			}
			else
			{
				value = 0;
			}
			arrayObject[index] = value;
		}
		object value2 = AesJs.cipher(arrayObject, AesJs.keyExpansion(arrayObject));
		lateBinding3.obj = Microsoft.JScript.Convert.ToObject(value2, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		object[] array = new object[1];
		lateBinding4.obj = Microsoft.JScript.Convert.ToObject(value2, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		array[0] = lateBinding4.Call(new object[2]
		{
			0,
			numericBinary2.EvaluateNumericBinary(obj, 16)
		}, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		value2 = lateBinding3.Call(array, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		ArrayObject arrayObject2 = GlobalObject.Array.CreateInstance(num);
		DateObject obj2;
		DateObject thisob = (obj2 = GlobalObject.Date.CreateInstance());
		lateBinding5.obj = obj2;
		object v2 = LateBinding.CallValue(thisob, lateBinding5.GetNonMissingValue(), new object[0], construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		object v3 = numericBinary3.EvaluateNumericBinary(v2, 1000);
		double num3 = MathObject.floor(Microsoft.JScript.Convert.ToNumber(numericBinary4.EvaluateNumericBinary(v2, 1000)));
		double num4 = MathObject.floor(MathObject.random() * 65535.0);
		for (double num2 = 0.0; num2 < 2.0; num2 += 1.0)
		{
			arrayObject2[num2] = bitwiseBinary2.EvaluateBitwiseBinary(bitwiseBinary.EvaluateBitwiseBinary(v3, num2 * 8.0), 255);
		}
		for (double num2 = 0.0; num2 < 2.0; num2 += 1.0)
		{
			arrayObject2[num2 + 2.0] = bitwiseBinary4.EvaluateBitwiseBinary(bitwiseBinary3.EvaluateBitwiseBinary(num4, num2 * 8.0), 255);
		}
		for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
		{
			arrayObject2[num2 + 4.0] = bitwiseBinary6.EvaluateBitwiseBinary(bitwiseBinary5.EvaluateBitwiseBinary(num3, num2 * 8.0), 255);
		}
		object obj3 = "";
		for (double num2 = 0.0; num2 < 8.0; num2 += 1.0)
		{
			obj3 = Plus.DoOp(Microsoft.JScript.Convert.ToString(obj3, explicitOK: true), StringConstructor.fromCharCode(arrayObject2[num2]));
		}
		ArrayObject w = AesJs.keyExpansion(value2);
		lateBinding6.obj = Microsoft.JScript.Convert.ToObject(plaintext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		double num5 = MathObject.ceil(Microsoft.JScript.Convert.ToNumber(numericBinary5.EvaluateNumericBinary(lateBinding6.GetNonMissingValue(), num)));
		object obj4 = "";
		for (double num6 = 0.0; num6 < num5; num6 += 1.0)
		{
			for (double num7 = 0.0; num7 < 4.0; num7 += 1.0)
			{
				arrayObject2[15.0 - num7] = bitwiseBinary8.EvaluateBitwiseBinary(bitwiseBinary7.EvaluateBitwiseBinary(num6, num7 * 8.0), 255);
			}
			for (double num7 = 0.0; num7 < 4.0; num7 += 1.0)
			{
				arrayObject2[15.0 - num7 - 4.0] = bitwiseBinary9.EvaluateBitwiseBinary(numericBinary6.EvaluateNumericBinary(num6, 4294967296L), num7 * 8.0);
			}
			ArrayObject arrayObject3 = AesJs.cipher(arrayObject2, w);
			object obj5;
			if (num6 < num5 - 1.0)
			{
				obj5 = num;
			}
			else
			{
				lateBinding7.obj = Microsoft.JScript.Convert.ToObject(plaintext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				obj5 = plus.EvaluatePlus(numericBinary8.EvaluateNumericBinary(numericBinary7.EvaluateNumericBinary(lateBinding7.GetNonMissingValue(), 1), num), 1);
			}
			object obj6 = obj5;
			ArrayObject arrayObject4 = GlobalObject.Array.CreateInstance(obj6);
			for (double num2 = 0.0; relational3.EvaluateRelational(num2, obj6) < 0.0; num2 += 1.0)
			{
				double index2 = num2;
				object v4 = arrayObject3[num2];
				lateBinding8.obj = Microsoft.JScript.Convert.ToObject(plaintext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				arrayObject4[index2] = bitwiseBinary10.EvaluateBitwiseBinary(v4, lateBinding8.Call(new object[1] { num6 * num + num2 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)));
				arrayObject4[num2] = StringConstructor.fromCharCode(arrayObject4[num2]);
			}
			object v5 = obj4;
			ArrayObject obj7;
			ArrayObject thisob2 = (obj7 = arrayObject4);
			lateBinding9.obj = obj7;
			obj4 = plus2.EvaluatePlus(v5, LateBinding.CallValue(thisob2, lateBinding9.GetNonMissingValue(), new object[1] { "" }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)));
		}
		return base64Encode(plus3.EvaluatePlus(obj3, obj4));
	}

	private static string utf8Encode(object s)
	{
		return GlobalObject.unescape(GlobalObject.encodeURIComponent(s));
	}

	private static object base64Encode(object s)
	{
		return Base64Js.btoa(s);
	}

	public static object decrypt(object ciphertext, object password, object nBits)
	{
		Equality equality = new Equality(53);
		Equality equality2 = new Equality(53);
		Equality equality3 = new Equality(53);
		NumericBinary numericBinary = new NumericBinary(65);
		Relational relational = new Relational(58);
		LateBinding lateBinding = new LateBinding("length");
		Relational relational2 = new Relational(58);
		LateBinding lateBinding2 = new LateBinding("charCodeAt");
		LateBinding lateBinding3 = new LateBinding("concat");
		LateBinding lateBinding4 = new LateBinding("slice");
		NumericBinary numericBinary2 = new NumericBinary(47);
		LateBinding lateBinding5 = new LateBinding("slice");
		LateBinding lateBinding6 = new LateBinding("charCodeAt");
		LateBinding lateBinding7 = new LateBinding("length");
		NumericBinary numericBinary3 = new NumericBinary(47);
		NumericBinary numericBinary4 = new NumericBinary(65);
		LateBinding lateBinding8 = new LateBinding("slice");
		BitwiseBinary bitwiseBinary = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(52);
		NumericBinary numericBinary5 = new NumericBinary(65);
		NumericBinary numericBinary6 = new NumericBinary(47);
		BitwiseBinary bitwiseBinary3 = new BitwiseBinary(63);
		BitwiseBinary bitwiseBinary4 = new BitwiseBinary(52);
		LateBinding lateBinding9 = new LateBinding("length");
		LateBinding lateBinding10 = new LateBinding("length");
		Relational relational3 = new Relational(58);
		LateBinding lateBinding11 = new LateBinding("charCodeAt");
		BitwiseBinary bitwiseBinary5 = new BitwiseBinary(51);
		LateBinding lateBinding12 = new LateBinding("join");
		Plus plus = new Plus();
		double num = 16.0;
		if (!equality.EvaluateEquality(nBits, 128) && !equality2.EvaluateEquality(nBits, 192) && !equality3.EvaluateEquality(nBits, 256))
		{
			throw Throw.JScriptThrow(GlobalObject.Error.CreateInstance("Key size is not 128 / 192 / 256"));
		}
		ciphertext = base64Decode(GlobalObject.String.Invoke(ciphertext));
		password = utf8Encode(GlobalObject.String.Invoke(password));
		object obj = numericBinary.EvaluateNumericBinary(nBits, 8);
		ArrayObject arrayObject = GlobalObject.Array.CreateInstance(obj);
		for (double num2 = 0.0; relational.EvaluateRelational(num2, obj) < 0.0; num2 += 1.0)
		{
			double index = num2;
			object v = num2;
			lateBinding.obj = Microsoft.JScript.Convert.ToObject(password, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			object value;
			if (relational2.EvaluateRelational(v, lateBinding.GetNonMissingValue()) < 0.0)
			{
				lateBinding2.obj = Microsoft.JScript.Convert.ToObject(password, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				value = lateBinding2.Call(new object[1] { num2 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			}
			else
			{
				value = 0;
			}
			arrayObject[index] = value;
		}
		object value2 = AesJs.cipher(arrayObject, AesJs.keyExpansion(arrayObject));
		lateBinding3.obj = Microsoft.JScript.Convert.ToObject(value2, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		object[] array = new object[1];
		lateBinding4.obj = Microsoft.JScript.Convert.ToObject(value2, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		array[0] = lateBinding4.Call(new object[2]
		{
			0,
			numericBinary2.EvaluateNumericBinary(obj, 16)
		}, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		value2 = lateBinding3.Call(array, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		ArrayObject arrayObject2 = GlobalObject.Array.CreateInstance(8);
		lateBinding5.obj = Microsoft.JScript.Convert.ToObject(ciphertext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		object value3 = lateBinding5.Call(new object[2] { 0, 8 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		for (double num2 = 0.0; num2 < 8.0; num2 += 1.0)
		{
			double index2 = num2;
			lateBinding6.obj = Microsoft.JScript.Convert.ToObject(value3, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			arrayObject2[index2] = lateBinding6.Call(new object[1] { num2 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		}
		ArrayObject w = AesJs.keyExpansion(value2);
		lateBinding7.obj = Microsoft.JScript.Convert.ToObject(ciphertext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		double num3 = MathObject.ceil(Microsoft.JScript.Convert.ToNumber(numericBinary4.EvaluateNumericBinary(numericBinary3.EvaluateNumericBinary(lateBinding7.GetNonMissingValue(), 8), num)));
		ArrayObject arrayObject3 = GlobalObject.Array.CreateInstance(num3);
		for (double num4 = 0.0; num4 < num3; num4 += 1.0)
		{
			double index3 = num4;
			lateBinding8.obj = Microsoft.JScript.Convert.ToObject(ciphertext, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			arrayObject3[index3] = lateBinding8.Call(new object[2]
			{
				8.0 + num4 * num,
				8.0 + num4 * num + num
			}, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
		}
		ciphertext = arrayObject3;
		object obj2 = "";
		for (double num4 = 0.0; num4 < num3; num4 += 1.0)
		{
			for (double num5 = 0.0; num5 < 4.0; num5 += 1.0)
			{
				arrayObject2[15.0 - num5] = bitwiseBinary2.EvaluateBitwiseBinary(bitwiseBinary.EvaluateBitwiseBinary(num4, num5 * 8.0), 255);
			}
			for (double num5 = 0.0; num5 < 4.0; num5 += 1.0)
			{
				arrayObject2[15.0 - num5 - 4.0] = bitwiseBinary4.EvaluateBitwiseBinary(bitwiseBinary3.EvaluateBitwiseBinary(numericBinary6.EvaluateNumericBinary(numericBinary5.EvaluateNumericBinary(num4 + 1.0, 4294967296L), 1), num5 * 8.0), 255);
			}
			ArrayObject arrayObject4 = AesJs.cipher(arrayObject2, w);
			ArrayConstructor array2 = GlobalObject.Array;
			object[] array3 = new object[1];
			lateBinding9.obj = Microsoft.JScript.Convert.ToObject(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), ciphertext, new object[1] { num4 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)), VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			array3[0] = lateBinding9.GetNonMissingValue();
			ArrayObject arrayObject5 = array2.CreateInstance(array3);
			double num2 = 0.0;
			while (true)
			{
				object v2 = num2;
				lateBinding10.obj = Microsoft.JScript.Convert.ToObject(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), ciphertext, new object[1] { num4 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)), VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				if (!(relational3.EvaluateRelational(v2, lateBinding10.GetNonMissingValue()) < 0.0))
				{
					break;
				}
				double index4 = num2;
				object v3 = arrayObject4[num2];
				lateBinding11.obj = Microsoft.JScript.Convert.ToObject(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), ciphertext, new object[1] { num4 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)), VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
				arrayObject5[index4] = bitwiseBinary5.EvaluateBitwiseBinary(v3, lateBinding11.Call(new object[1] { num2 }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)));
				arrayObject5[num2] = StringConstructor.fromCharCode(arrayObject5[num2]);
				num2 += 1.0;
			}
			object v4 = obj2;
			ArrayObject obj3;
			ArrayObject thisob = (obj3 = arrayObject5);
			lateBinding12.obj = obj3;
			obj2 = plus.EvaluatePlus(v4, LateBinding.CallValue(thisob, lateBinding12.GetNonMissingValue(), new object[1] { "" }, construct: false, brackets: false, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle)));
		}
		return utf8Decode(obj2);
	}

	private static object base64Decode(object s)
	{
		return Base64Js.atob(s);
	}

	private static object utf8Decode(object s)
	{
		//Discarded unreachable code: IL_0011, IL_002d
		try
		{
			return GlobalObject.decodeURIComponent(GlobalObject.escape(s));
		}
		catch (Exception e)
		{
			object obj = Try.JScriptExceptionValue(e, VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle));
			return s;
		}
	}

	private void _002Einit()
	{
	}//Error decoding local variables: Signature type sequence must have at least one element.


	public AesCtrJs()
	{
		_002Einit();
	}

	private virtual VsaEngine GetEngine()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (vsa_0020Engine == null)
		{
			vsa_0020Engine = VsaEngine.CreateEngineWithType(typeof(AesCtrJs).TypeHandle);
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
