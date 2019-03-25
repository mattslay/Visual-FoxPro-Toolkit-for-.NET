using System;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// <b>Visual FoxPro Math Functions</b><br/>
	/// This class contains all the math functions such as Cos(), Sin(), Tan(), Abs(), Mod(), Sqrt(), 
	/// Int(), Log(), Max(), Min() etc. 
	/// (Most of the math functions are decoraters that call the System.Math methods.)
	/// </summary>
	public class math
	{

		/// <summary>
		/// Returns an absolute value from a number (Use Math.Abs() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static decimal Abs(decimal nNumber)
		{
			return System.Math.Abs(nNumber);
		}
		/// <summary>
		/// Returns an absolute value from a number (Use Math.Abs() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Abs(double nNumber)
		{
			return System.Math.Abs(nNumber);
		}		
		/// <summary>
		/// Returns an absolute value from a number (Use Math.Abs() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Abs(int nNumber)
		{
			return System.Math.Abs(nNumber);
		}
		/// <summary>
		/// Returns an angle from a Cosine (Use Math.ACos() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ACos(double nNumber)
		{
			return System.Math.Acos(nNumber);
		}
		/// <summary>
		/// Returns an angle from a Cosine (Use Math.ACos() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ACos(int nNumber)
		{
			return System.Math.Acos((double)nNumber);
		}
		/// <summary>
		/// Returns an angle from a Sin (Use Math.ASin() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ASin(double nNumber)
		{
			return System.Math.Asin(nNumber);
		}
		/// <summary>
		/// Returns an angle from a Sin (Use Math.ASin() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ASin(int nNumber)
		{
			return System.Math.Asin((double)nNumber);
		}
		/// <summary>
		/// Returns an angle from a Tangent (Use Math.ATan() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ATan(double nNumber)
		{
			return System.Math.Atan(nNumber);
		}
		/// <summary>
		/// Returns an angle from a Tangent (Use Math.ATan() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double ATan(int nNumber)
		{
			return System.Math.Atan((double)nNumber);
		}
		/// <summary>
		/// Returns an Atn2() from two coordinates (Use Math.Atn2() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Atn2(double nYCoordinate, double nXCoordinate)
		{
			return System.Math.Atan2(nYCoordinate, nXCoordinate);
		}
		/// <summary>
		/// Returns an ceiling value from a number (Use Math.Celing() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Ceiling(double nNumber)
		{
			return System.Math.Ceiling(nNumber);
		}
		/// <summary>
		/// Returns the Cosine of an angle(Use Math.Cos() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Cos(double nNumber)
		{
			return System.Math.Cos(nNumber);
		}
		/// <summary>
		/// Returns the Cosine of an angle (Use Math.Cos() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Cos(int nNumber)
		{
			return System.Math.Cos((double)nNumber);
		}
		/// <summary>
		/// Receives degrees as a parameter and converts it to radiants
		/// </summary>
		/// <param name="nDegrees"></param>
		/// <returns></returns>
		public static double DTOR(double nDegrees)
		{
			return ((nDegrees * System.Math.PI)/180);
		}
		/// <summary>
		/// Returns a number raised to the specified power (Use Math.Exp() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Exp(double nNumber)
		{
			return System.Math.Exp(nNumber);
		}
		/// <summary>
		/// Returns an Floor value from a number (Use Math.Floor() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Floor(double nNumber)
		{
			return System.Math.Floor(nNumber);
		}
		/// <summary>
		/// Converts a double to an integer (Use (int)MyNumber instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Int(double nNumber)
		{
			return (int)nNumber;
		}
		/// <summary>
		/// Converts a float to an integer (Use (int)MyNumber instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Int(float nNumber)
		{
			return (int)nNumber;
		}

		/// <summary>
		/// Returns the Log of a specified number (Use Math.Log() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log(double nNumber)
		{
			return System.Math.Log(nNumber);
		}
		/// <summary>
		/// Returns the Log of a specified number (Use Math.Log() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log(int nNumber)
		{
			return System.Math.Log((double)nNumber);
		}		
		/// <summary>
		/// Returns the Log of a specified number (Use Math.Log() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log(decimal nNumber)
		{
			return System.Math.Log((double)nNumber);
		}
		/// <summary>
		/// Returns the base 10 Log of a specified number (Use Math.Log10() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log10(double nNumber)
		{
			return System.Math.Log10(nNumber);
		}
		/// <summary>
		/// Returns the base 10 Log of a specified number (Use Math.Log10() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log10(int nNumber)
		{
			return System.Math.Log10((double)nNumber);
		}		
		/// <summary>
		/// Returns the base 10 Log of a specified number (Use Math.Log10() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Log10(decimal nNumber)
		{
			return System.Math.Log10((double)nNumber);
		}
		/// <summary>
		/// Receives two numbers as parameters and returns the Max number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static double Max(double nVal1, double nVal2)
		{
			return System.Math.Max(nVal1,nVal2);
		}
		/// <summary>
		/// Receives two numbers as parameters and returns the Max number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static decimal Max(decimal nVal1, decimal nVal2)
		{
			return System.Math.Max(nVal1,nVal2);
		}		
		/// <summary>
		/// Receives two numbers as parameters and returns the Max number
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Max(int nVal1, int nVal2)
		{
			return System.Math.Max(nVal1,nVal2);
		}		
		/// <summary>
		/// Receives two numbers as parameters and returns the Max number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static float Max(float nVal1, float nVal2)
		{
			return System.Math.Max(nVal1,nVal2);
		}
		/// <summary>
		/// Receives two numbers as parameters and returns the Lower number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static double Min(double nVal1, double nVal2)
		{
			return System.Math.Min(nVal1,nVal2);
		}
		/// <summary>
		/// Receives two numbers as parameters and returns the Lower number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static decimal Min(decimal nVal1, decimal nVal2)
		{
			return System.Math.Min(nVal1,nVal2);
		}		
		/// <summary>
		/// Receives two numbers as parameters and returns the Lower number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static int Min(int nVal1, int nVal2)
		{
			return System.Math.Min(nVal1,nVal2);
		}		
		/// <summary>
		/// Receives two numbers as parameters and returns the Lower number
		/// </summary>
		/// <param name="nVal1"></param>
		/// <param name="nVal2"></param>
		/// <returns></returns>
		public static float Min(float nVal1, float nVal2)
		{
			return System.Math.Min(nVal1,nVal2);
		}
		/// <summary>
		/// Returns the Mod of two numbers. 
		/// </summary>
		/// <param name="nDividend"></param>
		/// <param name="nDivisor"></param>
		/// <returns></returns>
		public static double Mod(double nDividend, double nDivisor)
		{
			return nDividend % nDivisor ;
		}		
		/// <summary>
		/// Converts a decimal value to double (use (double)MyDecimalValue instead)
		/// </summary>
		/// <param name="nMoney"></param>
		/// <returns></returns>
		public static double MTON(decimal nMoney)
		{
			return (double)nMoney;
		}
		/// <summary>
		/// Converts a double value to decimal (use (decimal)MyValue instead)
		/// </summary>
		/// <param name="nMoney"></param>
		/// <returns></returns>
		public static decimal NTOM(double nMoney)
		{
			return (decimal)nMoney;
		}
		/// <summary>
		/// Converts a integer value to decimal (use (decimal)MyValue instead)
		/// </summary>
		/// <param name="nMoney"></param>
		/// <returns></returns>
		public static decimal NTOM(int nMoney)
		{
			return (decimal)nMoney;
		}
		/// <summary>
		/// Converts a float value to decimal (use (decimal)MyValue instead)
		/// </summary>
		/// <param name="nMoney"></param>
		/// <returns></returns>
		public static decimal NTOM(float nMoney)
		{
			return (decimal)nMoney;
		}
		/// <summary>
		/// Returns the value of PI (Use Math.PI instead)
		/// </summary>
		/// <returns></returns>
		public static double PI()
		{
			return System.Math.PI;
		}
		/// <summary>
		/// Receives a seed as a parameter and returns a random number.
		/// </summary>
		/// <param name="nSeed"></param>
		/// <returns></returns>
		public static double Random(int nSeed)
		{
			System.Random r = new System.Random(nSeed);
			return r.Next();
		}		public static double Random()
		{
			System.Random r = new System.Random();
			return r.Next();
		}
		/// <summary>
		/// Rounds a number and returns it back. (Use Math.Round() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static decimal Round(decimal nNumber)
		{
			return System.Math.Round(nNumber);
		}
		/// <summary>
		/// Rounds a number and returns it back. (Use Math.Round() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <param name="nDigits"></param>
		/// <returns></returns>
		public static double Round(double nNumber, int nDigits)
		{
			return System.Math.Round(nNumber, nDigits);
		}
		/// <summary>
		/// Receives radiants as a parameter and converts it to degrees
		/// </summary>
		/// <param name="nRadians"></param>
		/// <returns></returns>
		public static double RTOD(double nRadians)
		{
			return ((nRadians * 180)/System.Math.PI);
		}
		/// <summary>
		/// Returns an integer sign (0,1 or 2) based on if the number is negative, zero or positive.
		/// (Use Math.Sign() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Sign(decimal nNumber)
		{
			return System.Math.Sign(nNumber);
		}
		/// <summary>
		/// Returns an integer sign (0,1 or 2) based on if the number is negative, zero or positive.
		/// (Use Math.Sign() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Sign(double nNumber)
		{
			return System.Math.Sign(nNumber);
		}		
		/// <summary>
		/// Returns an integer sign (0,1 or 2) based on if the number is negative, zero or positive.
		/// (Use Math.Sign() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Sign(int nNumber)
		{
			return System.Math.Sign(nNumber);
		}		
		/// <summary>
		/// Returns an integer sign (0,1 or 2) based on if the number is negative, zero or positive.
		/// (Use Math.Sign() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static int Sign(float nNumber)
		{
			return System.Math.Sign(nNumber);
		}
		/// <summary>
		/// Returns the Sin of an angle (Use Math.Sin() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Sin(double nNumber)
		{
			return System.Math.Sin(nNumber);
		}		
		/// <summary>
		/// Returns the Sin of an angle (Use Math.Sin() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Sin(int nNumber)
		{
			return System.Math.Sin((double)nNumber);
		}
		/// <summary>
		/// Returns a square root of a number. (Use Math.Sqrt() instead)
		/// </summary>
		/// <example>
		/// Console.WriteLine(Sqrt(4));  //Returns 2
		/// Console.WriteLine(Sqrt(2 * Sqrt(2)));    //Returns 1.6817928
		/// </example>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Sqrt(double nNumber)
		{
			return System.Math.Sqrt(nNumber);
		}
		/// <summary>
		/// Returns a square root of a number. (Use Math.Sqrt() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Sqrt(decimal nNumber)
		{
			return System.Math.Sqrt((double)nNumber);
		}
		/// <summary>
		/// Returns a square root of a number. (Use Math.Sqrt() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Sqrt(int nNumber)
		{
			return System.Math.Sqrt((double)nNumber);
		}
		/// <summary>
		/// Returns the Tangent of an angle (Use Math.Tan() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Tan(double nNumber)
		{
			return System.Math.Tan(nNumber);
		}
		/// <summary>
		/// Returns the Tangent of an angle (Use Math.Tan() instead)
		/// </summary>
		/// <param name="nNumber"></param>
		/// <returns></returns>
		public static double Tan(int nNumber)
		{
			return System.Math.Tan((double)nNumber);
		}


		/// <summary>
		/// Receives and integer expression and position as parameter and returns the 
		/// result of shifting the bits to the left for the specified number of positions
		/// </summary>
		/// <param name="tnExpression"></param>
		/// <param name="tnPositions"></param>
		/// <returns></returns>
		public static int BitLShift(int tnExpression, int tnPositions)
		{
			return tnExpression << tnPositions;
		}

		/// <summary>
		/// Receives and integer expression and position as parameter and returns the 
		/// result of shifting the bits to the left for the specified number of positions
		/// </summary>
		/// <param name="tnExpression"></param>
		/// <param name="tnPositions"></param>
		/// <returns></returns>
		public static int BitRShift(int tnExpression, int tnPositions)
		{
			return tnExpression >> tnPositions;
		}

		/// <summary>
		/// Receives two integers and returns the result of a bitwise and operation
		/// </summary>
		/// <param name="tnExpression1"></param>
		/// <param name="tnExpression2"></param>
		/// <returns></returns>
		public static int BitAnd(int tnExpression1, int tnExpression2)
		{
			return tnExpression1 & tnExpression2;
		}

		/// <summary>
		/// Receives two integers and returns the result of a bitwise or operation
		/// </summary>
		/// <param name="tnExpression1"></param>
		/// <param name="tnExpression2"></param>
		/// <returns></returns>
		public static int BitOr(int tnExpression1, int tnExpression2)
		{
			return tnExpression1 | tnExpression2;
		}

		/// <summary>
		/// Receives and integer and returns the negation
		/// </summary>
		/// <param name="tnExpression"></param>
		/// <returns></returns>
		public static int BitNot(int tnExpression)
		{
			return ~tnExpression;
		}

		
		/// <summary>
		/// Receives an integer value and position as parameter and returns the 
		/// specified bit in that position.
		/// </summary>
		/// <param name="tnExpression"></param>
		/// <param name="tnPosition"></param>
		/// <returns></returns>
		public static bool BitTest(int tnExpression, int tnPosition)
		{
			//Create an array of integer
			int[] aInt = {5};

			//Create the BitArray so the bits are populated
			System.Collections.BitArray ba = new System.Collections.BitArray(aInt);

			//Return the appropriate position
			return ba[0];
		}


		///<summary>
		///</summary>
	
		//public static void FV(decimal nPayment, decimal nInterestRate, int nPeriods)
		//{
			//return nPayment/(1+nInterestRate)^nPeriods;
			//Microsoft.VisualBasic.VBCodeProvider.
			
		//}

		//The following three functions used for calculations are not implemented
		//public static decimal FV(decimal nPayment, decimal nInterestRate, int nPeriods)
		//public static decimal PV(decimal nPayment, decimal nInterestRate, int nTotalPayments)
		//public static decimal Payment(decimal nPrincipal, decimal nInterestRate, int nPayments)
		
		//End of Math class	
	}
}
