using System;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
using System.Diagnostics;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// <b>Visual FoxPro Array Functions</b><br/>
	/// This class contains all the functions that allow us to work with arrays such as ALen(), ASort(), ACopy(), AScan() etc.
	/// It also contains functions that return arrays such as ADir(), APrinter() and AFonts().
	/// </summary>
	public class arrays
	{
		/// <summary>
		/// Inserts an element into a one-dimensional array, or a row or column into a two-dimensional array
		/// </summary>
		public static void AIns(ref Array aArray, int nElementNumber)
		{
			//In this case we add a row to the array
			Array retarr = Array.CreateInstance(typeof(String),aArray.Length + 1);
			
			int i,j = 0 ;
			for (i = 0;  i < aArray.Length ; i++)
			{
				if (i == nElementNumber)
				{
					retarr.SetValue("",j);
						j++;
				}
				retarr.SetValue(aArray.GetValue(i),j);
				j++;
			}

			aArray = retarr;
		}

		/// <summary>
		/// Returns the number of elements, rows, or columns in an array.
		/// <pre>
		/// Example:
		/// //Create an array and fill it up with data
		/// Array MyArr = Array.CreateInstance(typeof(String), 4);
		/// MyArr.SetValue("YAG", 0);		//Note that this is zero based
		/// MyArr.SetValue("Kamal", 1);		
		/// MyArr.SetValue("Rick", 2);	
		/// MyArr.SetValue("Matt", 3);
		/// 
		/// //Now Get the Length
		/// VFPToolkit.arrays.ALen(MyArr);		//returns 4	
		/// </pre>
		/// </summary>
		public static int ALen(System.Array aArray)
		{
			return aArray.Length;
		}
		/// <summary>
		/// Returns the number of elements, rows, or columns in an array. Implements the optional
		/// parameter for number of rows for columns
		/// <pre>
		/// Example:
		/// VFPToolkit.arrays.ALen(MyArr, 1);	
		/// </pre>
		/// </summary>
		public static int ALen(System.Array aArray, int nArrayAttribute)
		{
			//switch based on the value of nArrayAttribute
			switch (nArrayAttribute)
			{
				case 1:
				{
					//Return the number of rows in the array
					//return (aArray.Length / aArray.Rank);
					return aArray.GetUpperBound(0) + 1;
				}
				case 2:
				{
					//Return the number of columns
					return aArray.Rank;
				}
				default:
				{
					return aArray.Length;
				}
			}
		}

		/// <summary>
		/// Sorts elements in an array in ascending or descending order
		/// <pre>
		/// Example:
		/// //Pass the array by reference and the method sorts the contents of the array
		/// VFPToolkit.arrays.ASort(ref MyArr);
		/// </pre>
		/// </summary>
		public static void ASort(ref Array aArray)
		{
			Array.Sort(aArray);
		}

		/// <summary>
		/// Receives two arrays as parameters by reference and copies the contents from one array to another array.
		/// <pre>
		/// Example:
		/// VFPToolkit.arrays.Acopy(ref MySourceArr, ref MyDestinationArr);
		/// </pre>
		/// </summary>
		public static int ACopy(ref Array aSource, ref Array aDestination)
		{
			//Check if the destination array is null and if so then initialize it
			if(aDestination == null)
				aDestination = Array.CreateInstance(typeof(System.Object), 1);

			//Check the length of the destination and if the source length is
			//greater than the destination then ititialize it
			if(aSource.Length > aDestination.Length)
				aDestination = Array.CreateInstance(typeof(System.Object), aSource.Length);

			//Now copy the array
			Array.Copy(aSource, aDestination, aSource.GetUpperBound(0) + 1);
			
			//Return the length
			return aDestination.Length;
		}
		/// <summary>
		/// Receives two arrays as parameters by reference and copies the contents from one array to another array.
		/// The nFirstElement specifies which should be the first element in the source array to begin the copying process.
		/// <pre>
		/// Example:
		/// VFPToolkit.arrays.Acopy(ref MySourceArr, ref MyDestinationArr, 2);		//Begins copying from 2nd position in source array
		/// </pre>
		/// </summary>
		public static int ACopy(ref Array aSource, ref Array aDestination, int nFirstSourceElement)
		{
			//Check if the destination array is null and if so then initialize it
			if(aDestination == null)
				aDestination = Array.CreateInstance(typeof(System.Object), 1);

			//Check the length of the destination and if the source length is
			//greater than the destination then ititialize it
			if(aSource.Length - nFirstSourceElement > aDestination.Length)
				aDestination = Array.CreateInstance(typeof(System.Object), aSource.Length - (nFirstSourceElement-1));

			Array.Copy(aSource,nFirstSourceElement - 1,aDestination,0,aSource.GetUpperBound(0) + 2 - nFirstSourceElement);
			return aDestination.Length;
		}
		/// <summary>
		/// Receives two arrays as parameters by reference and copies the contents from one array to another array.
		/// The nFirstElement specifies which should be the first element in the source array to begin the copying process.
		/// The nNumbeOfSourceElement specifies how many items from the source array should be copied.
		/// <pre>
		/// Example:
		/// //Begins copying from 2nd position in source array and copies on 3 items from that position onwards
		/// VFPToolkit.arrays.Acopy(ref MySourceArr, ref MyDestinationArr, 2, 3);		
		/// </pre>
		/// </summary>
		/// <param name="aSource"></param>
		/// <param name="aDestination"></param>
		/// <param name="nFirstSourceElement"></param>
		/// <param name="nNumberOfSourceElements"></param>
		/// <returns></returns>
		public static int ACopy(ref Array aSource, ref Array aDestination, int nFirstSourceElement, int nNumberOfSourceElements)
		{
			//Check if the destination array is null and if so then initialize it
			if(aDestination == null)
				aDestination = Array.CreateInstance(typeof(System.Object), 1);

			//Check the length of the destination and if the source length is
			//greater than the destination then ititialize it
			if(nNumberOfSourceElements > aDestination.Length)
				aDestination = Array.CreateInstance(typeof(System.Object), nNumberOfSourceElements);

			Array.Copy(aSource,nFirstSourceElement - 1,aDestination, 0, nNumberOfSourceElements);
			return aDestination.Length;
		}
		/// <summary>
		/// Receives two arrays as parameters by reference and copies the contents from one array to another array.
		/// The nFirstElement specifies which should be the first element in the source array to begin the copying process.
		/// The nNumbeOfSourceElement specifies how many items from the source array should be copied.
		/// The nFirstDestElement specifies the position in the destination array to begin the updating process.
		/// <pre>
		/// Example:
		/// //Begins copying from 2nd position in source array and copies on 3 items from that position onwards. 
		/// //Does not touch the 1st items in the destination array and starts from 2nd position
		/// VFPToolkit.arrays.Acopy(ref MySourceArr, ref MyDestinationArr, 2, 3, 2);		
		/// </pre>
		/// </summary>
		/// <param name="aSource"></param>
		/// <param name="aDestination"></param>
		/// <param name="nFirstSourceElement"></param>
		/// <param name="nNumberOfSourceElements"></param>
		/// <param name="nFirstDestElement"></param>
		/// <returns></returns>
		public static int ACopy(ref Array aSource, ref Array aDestination, int nFirstSourceElement, int nNumberOfSourceElements, int nFirstDestElement)
		{
			//Check if the destination array is null and if so then initialize it
			if(aDestination == null)
				aDestination = Array.CreateInstance(typeof(System.Object), 1);

			//Check the length of the destination and if the source length is
			//greater than the destination then ititialize it
			if(nNumberOfSourceElements + nFirstDestElement + 1> aDestination.Length)
				aDestination = Array.CreateInstance(typeof(System.Object), nNumberOfSourceElements + nFirstDestElement);

			Array.Copy(aSource,nFirstSourceElement - 1,aDestination,nFirstDestElement - 1,nNumberOfSourceElements);
			return aDestination.Length;
		}
		
		/// <summary>
		/// Deletes an element from a one-dimensional array, or a row or column from a two-dimensional array.
		/// (Currently this does not implement the third parameter to remove an entire column.)
		/// <pre>
		/// Example:
		/// VFPToolkit.arrays.ADel(ref myArr, 2);
		/// </pre>
		/// </summary>
		public static bool ADel(ref Array aArray, int nElementNumber)
		{
			//Forward the call passing the default parameter
			return ADel(ref aArray, nElementNumber, 1);
		}

		public static bool ADel(ref Array aArray, int nElementNumber, int nRemoveColumn)
		{
			bool llRetVal = false;
			try
			{
				//Check if we have to delete a column or a row
				//VFP has the third parameter as 2. It does not makes sense, 
				//should have been a binary value
				if(nRemoveColumn != 2)
				{
					//Delete the item from the array and update the content of that element with bool false
					Array.Clear(aArray,nElementNumber,1);
					aArray.SetValue(llRetVal, nElementNumber);
					llRetVal = true;
				}
				else
				{
					//Delete a column
					int nColumn = nElementNumber - 1;
					// We actually don't change the length of the array
					int nTotalColumns = aArray.Rank;

					//Begin the move
					for(int i=nColumn; i<= nTotalColumns ; i++)
					{
						for(int j=0; j< aArray.GetLength(0)-1; j++)
						{
							aArray.SetValue(aArray.GetValue(i+1, j), i, j);
							aArray.SetValue("", i+1, j);
						}
					}
				}
			}
			catch
			{
				//Something went wrong
				llRetVal = false;
			}

			return llRetVal;
		}

		/// <summary>
		/// Searches for an item in the array and returns the position of that item
		/// Please note that AScan() returns a zero based value
		/// <pre>
		/// Example:
		/// VFPToolkit.arrays.Ascan(ref MyArr, "Rick");
		/// </pre>
		/// </summary>
		/// <param name="aArray"></param>
		/// <param name="cString"></param>
		/// <returns></returns>
		public static int AScan(ref Array aArray, object toObject)
		{
			return Array.IndexOf(aArray, toObject);
		}

		public static int AScan(ref Array aArray, object toObject, int nStartElement)
		{
			return Array.IndexOf(aArray, toObject, nStartElement);
		}

		public static int AScan(ref Array aArray, object toObject, int nStartElement, int nElementSearched)
		{
			int i;
			bool llFound = false;

			//Compare the items manually
			for (i=nStartElement; i < nStartElement + nElementSearched ; i++) //Length is 1 based so only < sign
			{
				if(aArray.GetValue(i) == toObject)
				{
					llFound = true;
					break;
				}
			}
			return llFound == true ? i : -1;
		}

		/// <summary>
		/// Copies each line in a character expression or memo field to a corresponding row in an array.
		/// ALines() also returns a zero based length of the array.
		/// <pre>
		/// Example:
		/// //Get the contents of a file into a string
		/// string cString = VFPToolkit.strings.FileToStr("c:\\MyFile.txt");
		/// 
		/// string[] myArr;		//Declare an array
		/// int nCount = 0 ;
		/// 
		/// //Call Alines() and fill each line in the text file as an item in the array
		/// nCount = VFPToolkit.arrays.ALines(out myArr, cString, VFPToolkit.strings.Chr(13));
		/// </pre>
		/// </summary>
		public static int ALines(out string[] aArray, string cExpression, string cParseString)
		{
			//Initialize a blank array
			int i = 0;
			aArray = new string[0];
			char[] aParseChar = new char[cParseString.Length];
			for ( i=0 ; i<cParseString.Length ; i++)
			{
				aParseChar[i] = cParseString[i];
			}

			//Create the array here
			aArray = cExpression.Split(aParseChar);			

			//Return the number of lines
			return aArray.Length;
		}
		public static int ALines(out string[] aArray, string cExpression)
		{
			//Remove all new line characters from the string
			cExpression = VFPToolkit.strings.StrTran(cExpression, "\n", "");

			//If the third parameter is not specified then forward the call
			return ALines(out aArray, cExpression, "\r");
		}


		/// <summary>
		/// Receives a file skeleton as a parameter and returns an array of files that match the skeleton.
		/// <pre>
		/// Example:
		/// string[] myArr;
		/// myArr = VFPToolkit.arrays.ADir("c:\\*.*");
		/// </pre>
		/// </summary>
		/// <param name="cFileSkeleton"></param>
		/// <returns></returns>
		public static string[] ADir(string cFileSkeleton)
		{
			string[] aFiles;
			string lcDrive = VFPToolkit.strings.SubStr(cFileSkeleton, 1,VFPToolkit.strings.RAt("\\", cFileSkeleton));
			string lcStem = VFPToolkit.strings.SubStr(cFileSkeleton, strings.RAt("\\", cFileSkeleton) + 1);
			aFiles = System.IO.Directory.GetFiles(lcDrive, lcStem);
			return aFiles;
		}		
		
		/// <summary>
		/// Returns a array containing a list of all the fonts installed in the system.
		/// <pre>
		/// Example:
		/// string[] MyFontsArr;
		/// int nTotalFonts = VFPToolkit.arrays.AFonts(out MyFontsArr);
		/// </pre>
		/// </summary>
		/// <param name="aArray"></param>
		/// <returns></returns>
		public static int AFont(out string[] aArray)
		{
			//
			//Note: You could return the FontFamily array and use the font objects directy and it would make things easier

			//Initialize the InstalledFontCollection object
			InstalledFontCollection fc = new InstalledFontCollection();

			//Create an empty FontFamily array and fill it up
			FontFamily[] afm;
			afm = fc.Families;

			//RE Initialize a string array
			aArray = new string[afm.Length];
			
			//loop through the array of fonts and fill the font names
			int i = 0;
			for (i=0; i< afm.Length; i++)
			{
				aArray.SetValue(afm[i].Name, i);
			}

			//Return the number of fonts
			return i + 1;
		}	

		/// <summary>
		/// Fills an array with all the printers that can be accessed by this machine. 
		/// <pre>
		/// Example:
		/// string[] MyPrinters;
		/// int nCount = VFPToolkit.arrays.APrinters(out MyPrinters);
		/// </pre>
		/// </summary>
		/// <param name="aArray"></param>
		/// <returns></returns>
		public static int APrinters(out string[] aArray)
		{
			//Initialize the PrinterSettings object
			PrinterSettings oPrtSettings = new PrinterSettings();
			
			IEnumerator se = System.Drawing.Printing.PrinterSettings.InstalledPrinters.GetEnumerator();
			int i = 0;

			//simply count in the first round
			while (se.MoveNext())
				i++;

			//update the array now
			aArray = new string[i];
			i = 0;
			se.Reset();
			while (se.MoveNext())
			{
				aArray[i] = se.Current.ToString();
				i++;
			}


			//Return a 1 based length
			return aArray.Length;
		}
		///<summary>
		///</summary>
		//End of arrays class

	}

	//End of vfp Namespace
}
