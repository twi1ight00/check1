using System;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;

namespace Richfit.Garnet.Common.Security.JScript;

[Serializable]
public class AesJs : INeedEngine
{
	private static int[] sBox;

	private static int[][] rCon;

	[NonSerialized]
	private VsaEngine vsa_0020Engine;

	static AesJs()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		sBox = new int[256]
		{
			99, 124, 119, 123, 242, 107, 111, 197, 48, 1,
			103, 43, 254, 215, 171, 118, 202, 130, 201, 125,
			250, 89, 71, 240, 173, 212, 162, 175, 156, 164,
			114, 192, 183, 253, 147, 38, 54, 63, 247, 204,
			52, 165, 229, 241, 113, 216, 49, 21, 4, 199,
			35, 195, 24, 150, 5, 154, 7, 18, 128, 226,
			235, 39, 178, 117, 9, 131, 44, 26, 27, 110,
			90, 160, 82, 59, 214, 179, 41, 227, 47, 132,
			83, 209, 0, 237, 32, 252, 177, 91, 106, 203,
			190, 57, 74, 76, 88, 207, 208, 239, 170, 251,
			67, 77, 51, 133, 69, 249, 2, 127, 80, 60,
			159, 168, 81, 163, 64, 143, 146, 157, 56, 245,
			188, 182, 218, 33, 16, 255, 243, 210, 205, 12,
			19, 236, 95, 151, 68, 23, 196, 167, 126, 61,
			100, 93, 25, 115, 96, 129, 79, 220, 34, 42,
			144, 136, 70, 238, 184, 20, 222, 94, 11, 219,
			224, 50, 58, 10, 73, 6, 36, 92, 194, 211,
			172, 98, 145, 149, 228, 121, 231, 200, 55, 109,
			141, 213, 78, 169, 108, 86, 244, 234, 101, 122,
			174, 8, 186, 120, 37, 46, 28, 166, 180, 198,
			232, 221, 116, 31, 75, 189, 139, 138, 112, 62,
			181, 102, 72, 3, 246, 14, 97, 53, 87, 185,
			134, 193, 29, 158, 225, 248, 152, 17, 105, 217,
			142, 148, 155, 30, 135, 233, 206, 85, 40, 223,
			140, 161, 137, 13, 191, 230, 66, 104, 65, 153,
			45, 15, 176, 84, 187, 22
		};
		rCon = new int[11][]
		{
			new int[4] { 0, 0, 0, 0 },
			new int[4] { 1, 0, 0, 0 },
			new int[4] { 2, 0, 0, 0 },
			new int[4] { 4, 0, 0, 0 },
			new int[4] { 8, 0, 0, 0 },
			new int[4] { 16, 0, 0, 0 },
			new int[4] { 32, 0, 0, 0 },
			new int[4] { 64, 0, 0, 0 },
			new int[4] { 128, 0, 0, 0 },
			new int[4] { 27, 0, 0, 0 },
			new int[4] { 54, 0, 0, 0 }
		};
	}

	public static ArrayObject cipher(object input, object w)
	{
		LateBinding lateBinding = new LateBinding("length");
		NumericBinary numericBinary = new NumericBinary(65);
		NumericBinary numericBinary2 = new NumericBinary(47);
		Relational relational = new Relational(58);
		double num = 4.0;
		lateBinding.obj = Microsoft.JScript.Convert.ToObject(w, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
		object obj = numericBinary2.EvaluateNumericBinary(numericBinary.EvaluateNumericBinary(lateBinding.GetNonMissingValue(), num), 1);
		object obj2 = Globals.ConstructArrayLiteral(new object[4]
		{
			Globals.ConstructArrayLiteral(new object[0]),
			Globals.ConstructArrayLiteral(new object[0]),
			Globals.ConstructArrayLiteral(new object[0]),
			Globals.ConstructArrayLiteral(new object[0])
		});
		for (double num2 = 0.0; num2 < 4.0 * num; num2 += 1.0)
		{
			LateBinding.SetIndexedPropertyValueStatic(((ArrayObject)Microsoft.JScript.Convert.ToObject2(obj2, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)))[num2 % 4.0], new object[1] { MathObject.floor(num2 / 4.0) }, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), input, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)));
		}
		obj2 = addRoundKey(obj2, w, 0, num);
		for (double num3 = 1.0; relational.EvaluateRelational(num3, obj) < 0.0; num3 += 1.0)
		{
			obj2 = subBytes(obj2, num);
			obj2 = shiftRows(obj2, num);
			obj2 = mixColumns(obj2, num);
			obj2 = addRoundKey(obj2, w, num3, num);
		}
		obj2 = subBytes(obj2, num);
		obj2 = shiftRows(obj2, num);
		obj2 = addRoundKey(obj2, w, obj, num);
		ArrayObject arrayObject = GlobalObject.Array.CreateInstance(4.0 * num);
		for (double num2 = 0.0; num2 < 4.0 * num; num2 += 1.0)
		{
			arrayObject[num2] = LateBinding.CallValue(obj2, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), obj2, new object[1] { num2 % 4.0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { MathObject.floor(num2 / 4.0) }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
		}
		return arrayObject;
	}

	public static object addRoundKey(object state, object w, object rnd, object Nb)
	{
		Relational relational = new Relational(58);
		NumericBinary numericBinary = new NumericBinary(64);
		Plus plus = new Plus();
		BitwiseBinary bitwiseBinary = new BitwiseBinary(51);
		for (double num = 0.0; num < 4.0; num += 1.0)
		{
			for (double num2 = 0.0; relational.EvaluateRelational(num2, Nb) < 0.0; num2 += 1.0)
			{
				object obj;
				object[] arguments;
				object obj2 = LateBinding.CallValue(null, obj = LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), state, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), arguments = new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
				object v = obj2;
				LateBinding.SetIndexedPropertyValueStatic(obj, arguments, bitwiseBinary.EvaluateBitwiseBinary(v, LateBinding.CallValue(w, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), w, new object[1] { plus.EvaluatePlus(numericBinary.EvaluateNumericBinary(rnd, 4), num2) }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle))));
			}
		}
		return state;
	}

	public static object subBytes(object s, object Nb)
	{
		Relational relational = new Relational(58);
		for (double num = 0.0; num < 4.0; num += 1.0)
		{
			for (double num2 = 0.0; relational.EvaluateRelational(num2, Nb) < 0.0; num2 += 1.0)
			{
				LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num2 }, sBox[(int)Microsoft.JScript.Convert.Coerce2(LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), TypeCode.Int32, truncationPermitted: false)]);
			}
		}
		return s;
	}

	public static object shiftRows(object s, object Nb)
	{
		NumericBinary numericBinary = new NumericBinary(66);
		ArrayObject arrayObject = GlobalObject.Array.CreateInstance(4);
		for (double num = 1.0; num < 4.0; num += 1.0)
		{
			for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
			{
				arrayObject[num2] = LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { numericBinary.EvaluateNumericBinary(num2 + num, Nb) }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
			}
			for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
			{
				LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num2 }, arrayObject[num2]);
			}
		}
		return s;
	}

	public static object mixColumns(object s, object Nb)
	{
		BitwiseBinary bitwiseBinary = new BitwiseBinary(52);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(61);
		BitwiseBinary bitwiseBinary3 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary4 = new BitwiseBinary(61);
		BitwiseBinary bitwiseBinary5 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary6 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary7 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary8 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary9 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary10 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary11 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary12 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary13 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary14 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary15 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary16 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary17 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary18 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary19 = new BitwiseBinary(51);
		BitwiseBinary bitwiseBinary20 = new BitwiseBinary(51);
		for (double num = 0.0; num < 4.0; num += 1.0)
		{
			ArrayObject arrayObject = GlobalObject.Array.CreateInstance(4);
			ArrayObject arrayObject2 = GlobalObject.Array.CreateInstance(4);
			for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
			{
				arrayObject[num2] = LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
				arrayObject2[num2] = ((!Microsoft.JScript.Convert.ToBoolean(bitwiseBinary.EvaluateBitwiseBinary(LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), 128), explicitConversion: true)) ? bitwiseBinary4.EvaluateBitwiseBinary(LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), 1) : bitwiseBinary3.EvaluateBitwiseBinary(bitwiseBinary2.EvaluateBitwiseBinary(LateBinding.CallValue(s, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), 1), 283));
			}
			LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { 0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, bitwiseBinary8.EvaluateBitwiseBinary(bitwiseBinary7.EvaluateBitwiseBinary(bitwiseBinary6.EvaluateBitwiseBinary(bitwiseBinary5.EvaluateBitwiseBinary(arrayObject2[0], arrayObject[1]), arrayObject2[1]), arrayObject[2]), arrayObject[3]));
			LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { 1 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, bitwiseBinary12.EvaluateBitwiseBinary(bitwiseBinary11.EvaluateBitwiseBinary(bitwiseBinary10.EvaluateBitwiseBinary(bitwiseBinary9.EvaluateBitwiseBinary(arrayObject[0], arrayObject2[1]), arrayObject[2]), arrayObject2[2]), arrayObject[3]));
			LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { 2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, bitwiseBinary16.EvaluateBitwiseBinary(bitwiseBinary15.EvaluateBitwiseBinary(bitwiseBinary14.EvaluateBitwiseBinary(bitwiseBinary13.EvaluateBitwiseBinary(arrayObject[0], arrayObject[1]), arrayObject2[2]), arrayObject[3]), arrayObject2[3]));
			LateBinding.SetIndexedPropertyValueStatic(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), s, new object[1] { 3 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), new object[1] { num }, bitwiseBinary20.EvaluateBitwiseBinary(bitwiseBinary19.EvaluateBitwiseBinary(bitwiseBinary18.EvaluateBitwiseBinary(bitwiseBinary17.EvaluateBitwiseBinary(arrayObject[0], arrayObject2[0]), arrayObject[1]), arrayObject[2]), arrayObject2[3]));
		}
		return s;
	}

	public static ArrayObject keyExpansion(object key)
	{
		LateBinding lateBinding = new LateBinding("length");
		NumericBinary numericBinary = new NumericBinary(65);
		Plus plus = new Plus();
		Plus plus2 = new Plus();
		NumericBinary numericBinary2 = new NumericBinary(64);
		Relational relational = new Relational(58);
		Plus plus3 = new Plus();
		NumericBinary numericBinary3 = new NumericBinary(64);
		Relational relational2 = new Relational(58);
		PostOrPrefixOperator postOrPrefixOperator = new PostOrPrefixOperator(1);
		NumericBinary numericBinary4 = new NumericBinary(47);
		NumericBinary numericBinary5 = new NumericBinary(66);
		Equality equality = new Equality(53);
		NumericBinary numericBinary6 = new NumericBinary(65);
		BitwiseBinary bitwiseBinary = new BitwiseBinary(51);
		Relational relational3 = new Relational(57);
		NumericBinary numericBinary7 = new NumericBinary(66);
		Equality equality2 = new Equality(53);
		NumericBinary numericBinary8 = new NumericBinary(47);
		BitwiseBinary bitwiseBinary2 = new BitwiseBinary(51);
		double num = 4.0;
		lateBinding.obj = Microsoft.JScript.Convert.ToObject(key, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
		object obj = numericBinary.EvaluateNumericBinary(lateBinding.GetNonMissingValue(), 4);
		object v = plus.EvaluatePlus(obj, 6);
		ArrayObject arrayObject = GlobalObject.Array.CreateInstance(numericBinary2.EvaluateNumericBinary(num, plus2.EvaluatePlus(v, 1)));
		object obj2 = GlobalObject.Array.CreateInstance(4);
		object obj3 = 0;
		while (relational.EvaluateRelational(obj3, obj) < 0.0)
		{
			ArrayObject value = Globals.ConstructArrayLiteral(new object[4]
			{
				LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), key, new object[1] { 4.0 * Microsoft.JScript.Convert.ToNumber(obj3) }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)),
				LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), key, new object[1] { 4.0 * Microsoft.JScript.Convert.ToNumber(obj3) + 1.0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)),
				LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), key, new object[1] { 4.0 * Microsoft.JScript.Convert.ToNumber(obj3) + 2.0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)),
				LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), key, new object[1] { 4.0 * Microsoft.JScript.Convert.ToNumber(obj3) + 3.0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle))
			});
			arrayObject[Microsoft.JScript.Convert.ToNumber(obj3)] = value;
			obj3 = Microsoft.JScript.Convert.ToNumber(obj3) + 1.0;
		}
		obj3 = obj;
		while (relational2.EvaluateRelational(obj3, numericBinary3.EvaluateNumericBinary(num, plus3.EvaluatePlus(v, 1))) < 0.0)
		{
			arrayObject[new object[1] { obj3 }] = GlobalObject.Array.CreateInstance(4);
			for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
			{
				((ArrayObject)Microsoft.JScript.Convert.ToObject2(obj2, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)))[num2] = LateBinding.CallValue(null, arrayObject[new object[1] { numericBinary4.EvaluateNumericBinary(obj3, 1) }], new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
			}
			if (equality.EvaluateEquality(numericBinary5.EvaluateNumericBinary(obj3, obj), 0))
			{
				obj2 = subWord(rotWord(obj2));
				for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
				{
					object obj4;
					object[] arguments;
					object obj5 = LateBinding.CallValue(null, obj4 = obj2, arguments = new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
					object v2 = obj5;
					LateBinding.SetIndexedPropertyValueStatic(obj4, arguments, bitwiseBinary.EvaluateBitwiseBinary(v2, LateBinding.CallValue(rCon, rCon[(int)Microsoft.JScript.Convert.Coerce2(numericBinary6.EvaluateNumericBinary(obj3, obj), TypeCode.Int32, truncationPermitted: false)], new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle))));
				}
			}
			else if (relational3.EvaluateRelational(obj, 6) > 0.0 && equality2.EvaluateEquality(numericBinary7.EvaluateNumericBinary(obj3, obj), 4))
			{
				obj2 = subWord(obj2);
			}
			for (double num2 = 0.0; num2 < 4.0; num2 += 1.0)
			{
				LateBinding.SetIndexedPropertyValueStatic(arrayObject[new object[1] { obj3 }], new object[1] { num2 }, bitwiseBinary2.EvaluateBitwiseBinary(LateBinding.CallValue(null, arrayObject[new object[1] { numericBinary8.EvaluateNumericBinary(obj3, obj) }], new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), obj2, new object[1] { num2 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle))));
			}
			object v3 = obj3;
			obj3 = postOrPrefixOperator.EvaluatePostOrPrefix(ref v3);
		}
		return arrayObject;
	}

	public static object rotWord(object w)
	{
		object value = LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), w, new object[1] { 0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle));
		for (double num = 0.0; num < 3.0; num += 1.0)
		{
			LateBinding.SetIndexedPropertyValueStatic(w, new object[1] { num }, LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), w, new object[1] { num + 1.0 }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)));
		}
		LateBinding.SetIndexedPropertyValueStatic(w, new object[1] { 3 }, value);
		return w;
	}

	public static object subWord(object w)
	{
		for (double num = 0.0; num < 4.0; num += 1.0)
		{
			LateBinding.SetIndexedPropertyValueStatic(w, new object[1] { num }, sBox[(int)Microsoft.JScript.Convert.Coerce2(LateBinding.CallValue(((IActivationObject)VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle).ScriptObjectStackTop()).GetDefaultThisObject(), w, new object[1] { num }, construct: false, brackets: true, VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle)), TypeCode.Int32, truncationPermitted: false)]);
		}
		return w;
	}

	private void _002Einit()
	{
	}//Error decoding local variables: Signature type sequence must have at least one element.


	public AesJs()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		_002Einit();
	}

	private virtual VsaEngine GetEngine()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (vsa_0020Engine == null)
		{
			vsa_0020Engine = VsaEngine.CreateEngineWithType(typeof(AesJs).TypeHandle);
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
