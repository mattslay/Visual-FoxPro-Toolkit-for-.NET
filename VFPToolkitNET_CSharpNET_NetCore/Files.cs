using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{

	/// <summary>
	/// <b>Visual FoxPro File/Directory Functions</b><br/>
	/// This class contains all the functions that work on files and directories such as  CurDir(), Home(), JustPath(), FullPath(), DisplayPath(), AGetFileVersion() etc.
	/// This class also contains low level file manipulation functions such as FOpen(), FWrite() FRead(), FFlush() etc.
	/// </summary>
	public class files
	{
		
		/// <summary>
		/// Creates an array containing detailed information  for a file
		/// Note: Params 13 and 15 are not implemented. Param 13 specifies if file can self register and param 15 specified the translation code.
		///<p/><pre>		/// //Create an array of type string and pass it by reference to the AGetFileVersion() along with the name of the file 
		/// //Fills MyArray with detailed information about the file
		/// string[] MyArray = new string[0];
		/// int i = VFPToolkit.arrays.AGetFileVersion(ref MyArray, "c:\\visio10\\gdiplus.dll");
		/// 
		/// Tip: Note the use of double backslash \\ as a separator. In C# the backslash is used to specify escape sequence so you need to specify the \\ as a separator or specify the path using the @"c:\MyPath\MyFile". 
		///</pre>		/// </summary>
		/// <param name="aFileInfoArray"></param>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static int AGetFileVersion(ref string[] aFileInfoArray, string cFileName)
		{
			//Create the FileVersionInfo object from System.Diagnostics and pass the FileName for which we want to get information
			System.Diagnostics.FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(cFileName);
			
			//Specify the right dimensions for the array
			aFileInfoArray = new string[15];
			
			//Fill the array the right values
			aFileInfoArray[0] = fvi.Comments;
			aFileInfoArray[1] = fvi.CompanyName;
			aFileInfoArray[2] = fvi.FileDescription;
			aFileInfoArray[3] = fvi.FileVersion;
			aFileInfoArray[4] = fvi.InternalName;
			aFileInfoArray[5] = fvi.LegalCopyright;
			aFileInfoArray[6] = fvi.LegalTrademarks;
			aFileInfoArray[7] = fvi.OriginalFilename;
			aFileInfoArray[8] = fvi.PrivateBuild;
			aFileInfoArray[9] = fvi.ProductName;
			aFileInfoArray[10] = fvi.ProductVersion;
			aFileInfoArray[11] = fvi.SpecialBuild;
			aFileInfoArray[12] = "";
			aFileInfoArray[13] = fvi.Language;
			aFileInfoArray[14] = "";

			//Return the number of items back
			return aFileInfoArray.Length ;
		}		

		/// <summary>
		/// Receives a path as a parameter and checks if the last character is a backslash. If not then adds one and returns the path otherwise returns the string
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string AddBS(string cPath)
		{
			if (cPath.Trim().EndsWith("\\"))
			{
				return cPath.Trim();
			}
			else
			{
				return cPath.Trim() + "\\";
			}
		}

		/// <summary>
		/// Returns the current directory. (In VFP, CurDir() receives a parameter for the volume/drive. This has not been implemented.)
		///<p/><pre>		/// Example: MyLabel.Text = VFPToolkit.files.CurDir()		//returns c:\VisualFoxProCommands\bin\debug
		/// Tip: In order to change the current directory use: System.IO.Directory.SetCurrentDirectory(cPathName)
		///</pre>		/// </summary>
		/// <returns></returns>
		public static string CurDir()
		{
			return System.IO.Directory.GetCurrentDirectory();	
		}

		/// <summary>
		/// Receives a file name and extension as parameters. If the file name does not have an extension then adds the extension. If the file has a different extension then changes that extension to the new extension.
		///<p/><pre>		/// Example: VFPToolkit.files.DefaultExt("MyFile.txt","txt");	//Returns MyFile.txt
		/// Example: VFPToolkit.files.DefaultExt("MyFile","txt");		//Returns MyFile.txt
		/// </pre>
		/// </summary>
		/// <param name="cFileName"></param>
		/// <param name="cExtension"></param>
		/// <returns></returns>
		public static string DefaultExt(string cFileName, string cExtension)
		{

			int nLastDot, nLastBackSlash, nLength;
			nLength = cFileName.Length;
				
			//In this case we check if the file has an extension and if it does not then we simply supply one
			nLastDot = cFileName.LastIndexOf('.') + 1;

			if (nLastDot < 1)
			{
				//We did not find an extension so specify one
				return cFileName + "." + cExtension;
			}
			else
			{
				//If we do not find an extension then specify one
				nLastBackSlash = cFileName.LastIndexOf('\\') + 1;
				if (nLastDot > nLastBackSlash)
				{
					return cFileName ;
				}
				else
				{
					return cFileName + "." + cExtension ;
				}
			}

		}

		/// <summary>
		/// Receives a path as a parameter and returns true if a directory exists otherwise returns false
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static bool Directory(string cPath)
		{
			return System.IO.Directory.Exists(cPath);
		}

		/// <summary>
		/// Receives a filename with path and maxlength as parameters and returns a truncated version of the path for display purposes
		///<p/><pre>		/// Example: 
		/// string lcFile = @"c:\My Folders\My Custom Folders\My Files\ResultFile.txt"
		/// DisplayPath(lcFile, 10)		//returns ResultFile
		/// DisplayPath(lcFile, 15)		//returns \ResultFile.txt
		/// DisplayPath(lcFile, 20)		//returns c:\...\ResultFile.txt
		/// DisplayPath(lcFile, 30)		//returns c:\...\My Files\ResultFile.txt
		///</pre>		/// </summary>
		/// <param name="cFileNameWithPath"></param>
		/// <param name="nMaxLength"></param>
		/// <returns></returns>
		public static string DisplayPath(string cFileNameWithPath, int nMaxLength)
		{
			//We will begin by taking the string and splitting it apart into an array
			
			//Check if we are within the max length then return the whole string
			if (cFileNameWithPath.Length <= nMaxLength)
			{
				return cFileNameWithPath;
			}

			//Split the string into an array using the \ as a delimiter
			char[] cSeparator = {'\\'};
			string[] aStr;
			aStr = cFileNameWithPath.Split(cSeparator);
			
			//The first value of the array is taken in case we need to create the string
			string lcBegin = aStr[0] + "\\...";
			int lnBeginLength = aStr[0].Length + 3;
			string lcRetVal = "";
			int lnLength = lcRetVal.Length ;
			bool lAddHeader = false;

			string s = "";
			int n = 0;

			//Now we loop backwards through the string
			int i = 0;
			for (i = aStr.Length - 1 ; i > 0; i--)
			{
				s = '\\' + aStr[i];
				n = s.Length;

				//Check if adding the current item does not increase the length of the max string
				if (lnLength + n <= nMaxLength)
				{
					//In this case we can afford to add the item
					lcRetVal = s + lcRetVal;
					lnLength += n;
				}
				else
				{
					break;
				}

				//Check if there is room to add the header and if so then reserve it by incrementing the length
				if ((lAddHeader == false) && (lnLength + lnBeginLength <= nMaxLength))
				{
					lAddHeader = true;
					lnLength += lnBeginLength;
				}
			}

			//Add the header if the bool is true
			if (lAddHeader == true)
			{
				lcRetVal = lcBegin + lcRetVal;  
			}
			
			//It is possible that the last value in the array itself was long. In such case simply use the substring of the last value
			if (lcRetVal.Length == 0)
			{
				lcRetVal = aStr[aStr.Length-1].Substring(0,nMaxLength);
			}
			
			return lcRetVal;
		}

		/// <summary>
		/// Receives a FileStream and new size as parameters and changes the size of the FileStream
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <param name="nNewSize"></param>
		/// <returns></returns>
		public static long FChSize(FileStream oFileStream, int nNewSize)
		{
			oFileStream.SetLength(nNewSize);
			return oFileStream.Length;
		}

		/// <summary>
		/// Closes the FileStream
		/// </summary>
		/// <param name="oFileStream"></param>
		public static void FClose(ref System.IO.FileStream oFileStream)
		{
			oFileStream.Close();
		}

		/// <summary>
		/// Creates a new file and returns a FileStream object back
		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static System.IO.FileStream FCreate(string cFileName)
		{
			return new FileStream(cFileName, System.IO.FileMode.CreateNew);
		}

		/// <summary>
		/// Returns a string containing the last modification date for a file
		///<pre>		/// Example:
		/// FDate("c:\\My Folders\\MyFile.txt");	//returns "04/29/2001"
		///</pre>		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static string FDate(string cFileName)
		{
			//Create the FileInfo object
			FileInfo fi = new FileInfo(cFileName);

			//Return the LastWriteTime in the right format. 
			//The LastWriteTime is a DateTime object which is more easier to work with than dates
			//and manipulations could be applied on the DateTime object
			return fi.LastWriteTime.ToShortDateString();
		}

		/// <summary>
		/// Returns a bool value indicating if we have reached the end of the FileStream
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <returns></returns>
		public static bool FEOF(System.IO.FileStream oFileStream)
		{
			return oFileStream.Length == oFileStream.Position;
		}

		/// <summary>
		/// Flushes the contents of the FileStream object
		/// </summary>
		/// <param name="oFileStream"></param>
		public static void FFlush(System.IO.FileStream oFileStream)
		{
			oFileStream.Flush();
		}

		/// <summary>
		/// Receives a file name with path as a parameter and returns true if the file exists otherwise false
		///<p/><pre>		/// Example:
		/// File(@"c:\My Folders\MyFile.txt");	//or
		/// File("c:\\My Folders\\MyFile.txt");		/// </pre>		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static bool File(string cFileName)
		{
			return System.IO.File.Exists(cFileName);
		}
		
		/// <summary>
		/// Receives a file name as a parameter and returns a FileStream back after opening the file
		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static System.IO.FileStream FOpen(string cFileName)
		{
			return new FileStream(cFileName, System.IO.FileMode.Open);
		}

		/// <summary>
		/// Receives a file name and extension as parameters. If the file name does not have an extension then adds the extension. If the file has a different extension then changes that extension to the new extension. (Forces the file to have then new extension)
		///<p/><pre>		/// Example: VFPToolkit.files.ForceExt("MyFile.txt","txt");	//Returns MyFile.txt
		/// Example: VFPToolkit.files.ForceExt("MyFile","txt");		//Returns MyFile.txt
		/// Example: VFPToolkit.files.ForceExt("MyFile.kpp","txt");	//Returns MyFile.txt        ///</pre>		/// </pre>
		/// </summary>
		/// <param name="cFileName"></param>
		/// <param name="cExtension"></param>
		/// <returns></returns>
		public static string ForceExt(string cFileName, string cExtension)
		{
			cFileName = cFileName.Trim();

			int nLastDot, nLastBackSlash, nLength;
			nLength = cFileName.Length;
				
			//In this case we check if the file has an extension and if it does not then we simply supply one
			nLastDot = cFileName.LastIndexOf('.') + 1;

			if (nLastDot < 1)
			{
				//File does not have an extension. Specify an extension and leave
				return cFileName + "." + cExtension;
			}
			else
			{
				nLastBackSlash = cFileName.LastIndexOf('\\') + 1;
				if (nLastDot > nLastBackSlash)
				{
					// In this case we actually have to remove the last few characters and force the new extension
					return cFileName.Substring(0,nLastDot-1) + "." + cExtension;
				}
				else
				{
					return cFileName + "." + cExtension ;
				}
			}

		}

		/// <summary>
		/// Receives a file name and path as parameters and returns a file name 
		/// with a new path name substituted for the old one
		/// </summary>
		/// <param name="cFileName"></param>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string ForcePath(string cFileName, string cPath)
		{
			cPath = cPath.Trim();
			cFileName = JustFName(cFileName.Trim());

			if(cPath.Length == 0)
				return cFileName;
			else if(cPath[cPath.Length-1] == '\\')
				return cPath + cFileName;
			else 
				return cPath + "\\" + cFileName;
		}
		
		/// <summary>
		/// Receives a FileStream and a string as parameters and adds the string to
		/// the FileStream and then appends a carriage return followed by a line feed 
		/// </summary>
		/// <example>
		/// System.IO.FileStream goErrFile ;
		/// if(VFPToolkit.files.File("errors.txt")) 
		///		goErrFile = VFPToolkit.files.FOpen("errors.txt");
		/// else
		///		goErrFile = VFPToolkit.files.FCreate("errors.txt");
		/// if(goErrFile.Handle.ToInt32() < 0)
		///     //No errors. If so handle them here
		/// else
		///		VFPToolkit.files.FPuts(goErrFile, "Kamal  Patel");
		/// VFPToolkit.files.FClose(goErrFile)  // Close file
		/// </example>
		/// <param name="oFileStream"></param>
		/// <param name="cString"></param>
		/// <returns></returns>
		public static int FPuts(ref FileStream oFileStream, string cString)
		{
			//Add a carriage return and line feed then write the string
			//cString = cString + "\r\n";
			return FWrite(ref oFileStream, cString) + FWrite(ref oFileStream, "\r\n");
		}
		public static int FPuts(ref FileStream oFileStream, string cString, int nCharactersWritten)
		{
			//Add a carriage return and line feed then write the string
			return FWrite(ref oFileStream, cString, nCharactersWritten) + FWrite(ref oFileStream, "\r\n");
		}

		/// <summary>
		/// Receives a FileStream and Bytes as parameters. The function reads the FileStream
		/// starting from the current position until the number of specified bytes and returns a string 
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <param name="nBytes"></param>
		/// <returns></returns>
		public static string FRead(ref FileStream oFileStream, int nBytes)
		{
			byte[] aBytes = new byte[nBytes];
			int n = oFileStream.Read(aBytes,0,nBytes);
			StringBuilder sb = new StringBuilder();

			for (int i=0; i<nBytes; i++)
			{
				sb.Append((char)aBytes[i]);
			}
			
			return sb.ToString();
		}

		/// <summary>
		/// Positions the position of the pointer to a specific location in the FileStream
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <param name="nBytesMoved"></param>
		/// <returns></returns>
		public static long FSeek(ref FileStream oFileStream, int nBytesMoved)
		{
			return oFileStream.Seek(nBytesMoved,0);
		}
		
		/// <summary>
		/// Positions the position of the pointer to a specific location in the FileStream. 
		/// This one receives a relative position as a third parameter
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <param name="nBytesMoved"></param>
		/// <param name="nRelativePosition"></param>
		/// <returns></returns>
		public static long FSeek(ref FileStream oFileStream, int nBytesMoved, int nRelativePosition)
		{
			if (nRelativePosition == 2)
			{
				return oFileStream.Seek(nBytesMoved, System.IO.SeekOrigin.End);
			}
			else if (nRelativePosition == 0)
			{
				return oFileStream.Seek(nBytesMoved, System.IO.SeekOrigin.Begin);
			}
			else
			{
				return oFileStream.Seek(nBytesMoved, System.IO.SeekOrigin.Current);
			}
		}

		/// <summary>
		/// Returns a string containing the last modification time for a file
		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static string FTime(string cFileName)
		{
			//Check if it exists
			if(!System.IO.File.Exists(cFileName))
				return "";

			//Create the FileInfo object
			FileInfo fi = new FileInfo(cFileName);

			//Return the LastWriteTime farmatted as a string. 
			//Call the LastAccessTime to get the last read/write/copy time
			return fi.LastWriteTime.ToShortTimeString();
		}
		

		/// <summary>
		/// Receives a filename as a parameter and returns a fully qualified path for the filename/path. 
		/// (Please note that the last two parameters nMsDosPath and cFileName2 are not implemented.)
		/// <pre>
		/// Example:
		/// FullPath("files.cs");	//returns "c:\projects\VisualFoxProCommands\bin\Debug\files.cs"
		/// </pre>
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string FullPath(string cFileName)
		{
			//Create the FileInfo object
			FileInfo fi = new FileInfo(cFileName);

			//Return the FullName property
			return fi.FullName;
		}

		/// <summary>
		/// Receives a FileStream and string as parameters and writes a string to a FileStream
		/// </summary>
		/// <param name="oFileStream"></param>
		/// <param name="cString"></param>
		/// <returns></returns>
		public static int FWrite(ref FileStream oFileStream, string cString)
		{
			return VFPToolkit.files.FWrite(ref oFileStream, cString, cString.Length);
		}
		public static int FWrite(ref FileStream oFileStream, string cString, int nCharactersWritten)
		{
			int i;
			//Move the position to the end of the file
			//oFileStream.Position = oFileStream.Length;

			if(cString.Length < nCharactersWritten)
				nCharactersWritten = cString.Length;

			//Convert the string into an array of bytes
			byte[] aBytes = new byte[nCharactersWritten];
			for (i= 0; i < nCharactersWritten ; i++)
			{
				aBytes[i] = (byte)cString[i];
			}

			//Call the write method of the FileStream
			oFileStream.Write(aBytes, 0, nCharactersWritten);
			return cString.Length;
		}

		/// <summary>
		/// Returns the startup directory
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static string Home()
		{
			return Application.StartupPath;
		}
		
		
		/// <summary>
		/// Receives a path as a parameter and returns only the drive part 
		/// <pre>
		/// Example:
		/// JustPath("c:\\My Folders\\MyFile.txt");		//returns "c:"
		/// </pre>
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string JustDrive(string cPath)
		{
			if(cPath.Trim().Length == 0)
				return cPath.Trim();

			string lcJustDrive = System.IO.Directory.GetDirectoryRoot(cPath);
			lcJustDrive = strings.StrTran(lcJustDrive, "\\", "");
			return lcJustDrive;
		}
		
		/// <summary>
		/// Receives a FileName as a parameter and returns the extension of that file
		/// <pre>
		/// JustExt("c:\\My Folders\\MyFile.txt");		//returns ".txt"
		/// </pre>
		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public static string JustExt(string cFileName)
		{
			//Create the FileInfo object
			FileInfo fi = new FileInfo(cFileName);
			
			//Return the extension of the file
			return fi.Extension;
		}
		
		/// <summary>
		/// Returns the only the file name with extension from a fully qualified path
		/// <pre>
		/// JustFName("c:\\My Folders\\MyFile.txt");		//returns "MyFile.txt"
		/// </pre>
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string JustFName(string cFileName)
		{
			//Create the FileInfo object
			FileInfo fi = new FileInfo(cFileName);

			//Return the file name
			return fi.Name;
		}
		
		/// <summary>
		/// Receives a path as a parameter and returns only the path part without the file name.
		/// <pre>
		/// Example:
		/// JustPath("c:\\My Folders\\MyFile.txt");		//returns "c:\My Folders"
		/// </pre>
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string JustPath(string cPath)
		{
			//Get the full path of this path
			string lcPath = cPath.Trim();

			//If the file contains a backslash then remove it and return the path onlyfile name get rid of it
			if(lcPath.IndexOf('\\') == -1)
				return "";
			else
				return lcPath.Substring(0, lcPath.LastIndexOf('\\'));
		}

		/// <summary>
		/// Returns the file name part without extension from a Path\FileName.ext string
		/// <pre>
		/// JustStem("c:\\My Folders\\MyFile.txt");		//returns "MyFile"
		/// </pre>
		/// </summary>
		/// <param name="cPath"></param>
		/// <returns></returns>
		public static string JustStem(string cPath)
		{
			//Get the name of the file
			string lcFileName = JustFName(cPath.Trim());
			
			//Remove the extension and return the string
			if(lcFileName.IndexOf(".") == -1)
				return lcFileName;
			else
				return lcFileName.Substring(0, lcFileName.LastIndexOf('.'));
		}
		

		///<summary>
		///</summary>


		//End of File Class
	}

}
