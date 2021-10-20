using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text;
using System.ComponentModel;
using System.Collections;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// <b>Visual FoxPro Common Functions</b><br/>
	/// This class contains implementions of those functions that are common. Functions such as Between(),
	/// InList() receive any datatype and return values are included here. Also functions
	/// such as VarType(), Empty() that check for any data type are also included in this class.
	/// </summary>
	public class common
	{
		/// <summary>
		/// Receives an object (string, int etc.) as a parameter and returns the datatype of that object.
		/// Unlike VFP, this method returns the .NET type. So, for a string object it
		/// will return "System.String" and not "C". This will allow you to get the type
		/// of any object including custom classes you develop. For a string object, 
		/// this method will return "System.String" instead of a "C" in VFP.
		/// <pre>
		/// Example:
		/// VFPToolkit.common.VarType(MyObject);	//returns the type of object
		/// </pre>
		/// </summary>
		/// <param name="oObj"></param>
		/// <returns></returns>
		public static string VarType(object oObj)
		{
			//Return a string that specifies the type of the object
			if(oObj == null)
				return "null";
			else
				return oObj.GetType().ToString();
		}

		/// <summary>
		/// Returns the type of the object. (Please note that currently this method does not receive 
		/// a string and then evaluates the type of object. It simply forwards the call to VarType(oObj).
		/// <pre>
		/// Example:
		/// VFPToolkit.common.Type(MyObject);	//returns the type of object
		/// </pre>
		/// </summary>
		/// <param name="oObj"></param>
		/// <returns></returns>
		public static string Type(object oObj)
		{
			return VarType(oObj);
		}
		/// <summary>
		/// Returns a bool indicating if the object is null or not
		/// <pre>
		/// Example:
		/// VFPToolkit.common.IsNull(MyObject);
		/// </pre>
		/// </summary>
		/// <param name="oObj"></param>
		/// <returns></returns>
		public static bool IsNull(object oObj)
		{
			return (oObj == null);	
		}
		/// <summary>
		/// Receives two objects as parameters and returns the one which is not null. If both of them are null
		/// then returns a null, if the first one is not null then returns the first object.
		/// <pre>
		/// Example:
		/// string myNullObj;	//The string is not initialized yet
		/// VFPToolkit.common.NVL("mystring", myNullObj);	//returns mystring object
		/// Note: All strings, int, long etc. all of them are objects
		/// </summary>
		/// <param name="oExp1"></param>
		/// <param name="oExp2"></param>
		/// <returns></returns>
		public static object NVL(object oExp1, object oExp2)
		{
			//if oExp1 is not null then return oExp1
			if (oExp1 != null)
			{
				return oExp1;
			}
			else if ((oExp1 == null) && (oExp2 != null))
			{
				//If oExp1 is null return oExp2
				return oExp2;
			}
			else
				//If both of them are null return nothing
				return null;
		}
		/// <summary>
		/// Receives a key (string format) as a parameter and sends the key to the currently active form.
		/// <pre>
		/// Example:
		/// VFPToolkit.common.KeyBoard("Kamal");	//If we are in a textbox this code will add "Kamal" to the textbox
		/// 
		/// Tip: In order to get a listing of all the keys and their formats look for System.Windows.Forms.SendKeys class
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cKey"></param>
		public static void KeyBoard(string cKey)
		{
			try 
			{
				//Call the Send() method passing the key as a parameter
				System.Windows.Forms.SendKeys.Send(cKey);
			}
			catch
			{
				//Do not throw an exception simply return a false
				MessageBox.Show("An error occured while sending the key: " + cKey, "KeyPress Error", MessageBoxButtons.OK);
			}
		}


		/// <summary>
		/// Returns a logical value indicating if an integer is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(int nValue)
		{
			return (nValue == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a long is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(long nValue)
		{
			return (nValue == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a double is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(double nValue)
		{
			return (nValue == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a decimal is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(decimal nValue)
		{
			return (nValue == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a string is blank or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(string tcString)
		{
			string lcString = tcString.Trim();
			return (lcString.Length == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a character is a blank space or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(char lcChar)
		{
			return (lcChar == ' ');
		}
		/// <summary>
		/// Returns a logical value indicating if a logical value is a true or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool Empty(bool lValue)
		{
			return (lValue == false);
		}
		/// <summary>
		/// Returns a logical value indicating if an integer is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(int nValue)
		{
			return Empty(nValue);
		}
		/// <summary>
		/// Returns a logical value indicating if a long is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(long nValue)
		{
			return Empty(nValue);
		}		
		/// <summary>
		/// Returns a logical value indicating if a double is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(double nValue)
		{
			return Empty(nValue);
		}		
		/// <summary>
		/// Returns a logical value indicating if a decimal is 0 or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(decimal nValue)
		{
			return Empty(nValue);
		}
		/// <summary>
		/// Returns a logical value indicating if a string is blank or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(string tcString)
		{
			//Does not check for string with blank spaces
			return (tcString.Length == 0);
		}
		/// <summary>
		/// Returns a logical value indicating if a character is a blank space or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(char lcChar)
		{
			return Empty(lcChar);
		}
		/// <summary>
		/// Returns a logical value indicating if a character is a blank space or not
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static bool IsBlank(bool lValue)
		{
			return Empty(lValue);
		}


		/// <summary>
		/// Returns the default CodePage being used. 
		/// (Currently, the optional parameter that returns Application or OS codepage is not implemented.)
		/// <pre>
		/// Example:
		/// VFPToolkit.common.CPCurrent();	//returns an integer with the CodePage being used
		/// </pre>
		/// </summary>
		/// <returns></returns>
		public static int CPCurrent()
		{
			return System.Text.Encoding.Default.CodePage ;
		}

		/// <summary>
		/// Converts a string in one CodePage to another. This method receives three parameters; a string which is to
		/// be converted, the current code page number and the new code page number.
		/// <pre>
		/// Example:
		/// string MyString = "ההה";
		/// VFPToolkit.others.CPConvert(1252, 10000, MyString);	//Converts the string from Windows CP to Mac CP
		/// </pre>
		/// </summary>
		/// <param name="nCurrentCodePage"></param>
		/// <param name="nNewCodePage"></param>
		/// <param name="cExpression"></param>
		/// <returns></returns>
		public static string CPConvert(int nCurrentCodePage, int nNewCodePage, string cExpression)
		{
			int i=0;
			int nLength = cExpression.Length;

			//Create a current and new array of bytes with the length of the string
			byte[] aCurr = new byte[nLength];
			byte[] aNew = new byte[nLength];
			
			//Fill the current array from the string
			for (i=0; i< cExpression.Length; i++)
			{
				aCurr[i] = Convert.ToByte(cExpression[i]);
			}

			//Get the encoding objects for the current and new Code Pages
			Encoding CurCP = Encoding.GetEncoding(nCurrentCodePage);
			Encoding NewCP = Encoding.GetEncoding(nNewCodePage);
			
			//Fill the new array after converting current code page to new code page
			aNew = Encoding.Convert(CurCP, NewCP, aCurr);
			
			//We still have bytes so we convert each byte to a char and add it to a string builder
			StringBuilder sb = new StringBuilder();
			for (i=0; i< cExpression.Length; i++)
			{
				sb.Append(Convert.ToChar(aNew[i]));
			}

			//Return a string back 
			return sb.ToString();
			
		}


		/// <summary>
		/// Returns a bool specifying whether a property/method/event exists in an object. 
		/// (Currently this method does not implement all the parameters.)
		/// </summary>
		/// <param name="oObject"></param>
		/// <param name="cPropertyEventMethodName"></param>
		/// <returns></returns>
		/// <pre>
		/// //Create a new listbox
		/// ListBox lstMyListBox;
		/// lstMyListBox = new ListBox();
		/// 
		/// //Check if the listbox has a ForeColor or MyColor property
		/// VFPToolkit.common.GetPem(lstMyListBox,"ForeColor");  //return true
		/// VFPToolkit.common.GetPem(lstMyListBox,"MyColor");  //return false
		/// </pre>
		public static bool GetPem(object oObject, string cPropertyEventMethodName)
		{
			//Get a list of all the properties in this object
			PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(oObject);

			//Beta 1 code
			//PropertyDescriptor[] pda = TypeDescriptor.GetProperties(oObject).All;

			//Loop through the properties an check if our property exists
			foreach (MemberDescriptor md in pdc)
			{
				if (md.Name.ToLower() == cPropertyEventMethodName.ToLower())
				{
					//This means that we found our property
					return true;
				}
			}

			//Now we check for event name in this object
			//Get a list of all the events/methods in this object
			EventDescriptorCollection edc= TypeDescriptor.GetEvents(oObject);

			//Loop through the events/methods an check if our event/method exists
			foreach (EventDescriptor ed in edc)
			{
				if (ed.Name.ToLower() == cPropertyEventMethodName.ToLower())
				{
					//This means that we found our event/method
					return true;
				}
			}

			//If we reached here this means that we did not find our event/method/property
			return false;
		}
		
	
		/// <summary>
		/// This method receives three parameters and returns a color object from those values.
		/// In VFP, this method returned a value whereas, in this case we are actually returning
		/// a System.Drawing.Color object.
		/// <p/><pre>
		/// Example:
		/// Color o = VFPToolkit.common.RGB(255,255,255);
		/// </pre>
		/// </summary>
		/// <param name="R"></param>
		/// <param name="G"></param>
		/// <param name="B"></param>
		/// <returns></returns>
		public static System.Drawing.Color RGB(int R, int G, int B)
		{
			return System.Drawing.Color.FromArgb(R,G,B);
		}

		/// <summary>
		/// Receives an expression, low and high values and return a bool specifying 
		/// if the value was between the low and high values. This contains overloads 
		/// for int, float, decimal, char, date and string data types.
		/// <p/><pre>
		/// Example:
		/// if(VFPToolkit.common.Between(5,7,29))....
		/// </pre>
		/// </summary>
		/// <param name="tnExpression"></param>
		/// <param name="tnLowValue"></param>
		/// <param name="tnHighValue"></param>
		/// <returns></returns>
		public static bool Between(int tnExpression, int tnLowValue, int tnHighValue)
		{
			return ((tnExpression >= tnLowValue) && (tnExpression <= tnHighValue));
		}
		public static bool Between(double tnExpression, double tnLowValue, double tnHighValue)
		{
			return ((tnExpression >= tnLowValue) && (tnExpression <= tnHighValue));
		}
		public static bool Between(decimal tnExpression, decimal tnLowValue, decimal tnHighValue)
		{
			return ((tnExpression >= tnLowValue) && (tnExpression <= tnHighValue));
		}

		// Compares between for date range
		public static bool Between(System.DateTime tdDateTime, System.DateTime tdStartDate, System.DateTime tdEndDate)
		{
			return ((tdDateTime >= tdStartDate) && (tdDateTime <= tdEndDate));
		}

		// Compares between for char
		public static bool Between(char tcChar, char tcLowChar, char tcHighChar)
		{
			return (((int)tcChar >= (int)tcLowChar) && ((int)tcChar <= (int)tcHighChar));
		}

		// Compares between for strings
		// The way strings are compared in VFP is interesting
		public static bool Between(string tcExpression, string tcStart, string tcEnd)
		{
			bool llRetVal = true;

			// We start with the start string, tcStart, and compare each character in this
			// with tcExpression. If we fail at anytime we return a false
			for(int i = 0; i< tcStart.Length; i++)
			{
				if(tcStart[i] < tcExpression[i] )
				{
					llRetVal = false;
					break;
				}

				//if we have reached the end of tcExpression break
				if(i == tcExpression.Length)
					break;
			}


			// The way strings are compared in VFP is interesting
			// We start with the start string, tcStart, and compare each character in this
			// with tcExpression. If we fail at anytime we return a false
			for(int i = 0; i< tcEnd.Length; i++)
			{
				if(tcEnd[i] > tcExpression[i] )
				{
					llRetVal = false;
					break;
				}

				//if we have reached the end of tcExpression break
				if(i == tcExpression.Length)
					break;
			}

			return llRetVal;

		}


		/// <summary>
		/// Receives a MethodInfo as a parameter and returns the number of parameters for
		/// that method. Instead of calling this method by passing the MethodInfo you can also use
		/// 	System.Reflection.MethodBase.GetCurrentMethod().GetParameters().Length;
		/// right from your method to get the parameter count.
		/// </summary>
		/// <example>
		/// private string GetStatus(string tcCustomer)
		/// {
		///		//Gets the number of parameters for this method. In this case 1
		///		int lnPCount = VFPToolkit.common.PCount(System.Reflection.MethodBase.GetCurrentMethod());
		/// }
		/// </example>
		/// <param name="ms"></param>
		/// <returns></returns>
		public static int PCount(System.Reflection.MethodBase mb)
		{
			return mb.GetParameters().Length;
		}

		/// <summary>
		/// Receives a MethodInfo as a parameter and forwards the call to PCount to get 
		/// the number of parameters for that method
		/// </summary>
		/// <example>
		/// private string GetStatus(string tcCustomer)
		/// {
		///		//Gets the number of parameters for this method. In this case 1
		///		int lnPCount = VFPToolkit.common.Parameters(System.Reflection.MethodBase.GetCurrentMethod());
		/// }
		/// </example>
		/// <param name="ms"></param>
		/// <returns></returns>
		public static int Parameters(System.Reflection.MethodBase ms)
		{
			return PCount(ms);
		}

		/// <summary>
		/// Receives an expression and a list of values as parameter and returns a true
		/// if the expression exists in the list. Please note that the Visual FoxPro's
		/// InList() function has a limitation of 23 items whereas this one does not have
		/// a limitation on the number of items passed.
		/// </summary>
		/// <example>
		/// Console.WriteLine(InList("Kamal", "Pat", "abc", "Kamal"));	//returns true
		/// Console.WriteLine(InList("Kamal", "Pat", "abc", "xyz"));	//returns false
		/// Console.WriteLine(InList(123, 12, 13, 16, 1717, 123));	//returns true
		/// </example>
		/// <param name="tcExpression"></param>
		/// <param name="toVar"></param>
		/// <returns></returns>
		public static bool InList(object toExpression, params object[] toItems)
		{
			return Array.IndexOf(toItems,  toExpression) > -1;
		}

		///<summary>
		///</summary>

		//End of class
	}

}
