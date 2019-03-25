using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using System.Management;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{

	/// <summary>
	/// <b>Visual FoxPro Environment Variables & Functions</b>
	/// This class contains functions that return environment settings such as ID(), OS(), 
	/// IsMouse(), SysMetric() and the Sys() functions.
	/// It also exposes environment properties such as _ClipText and _DblClick. 
	/// </summary>
	public class environment
	{
		/// <summary>
		/// Receives a window title as a parameter and determines if the form is the
		/// currently active form in the application
		/// <p/><pre>
		/// Example:
		/// bool llIsCurrentlyActive = VFPToolkit.common.WVisible("MyForm");
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="tcWindowCaption"></param>
		/// <returns></returns>
		public static bool WVisible(string tcWindowCaption)
		{
			string lcCurrent = "";
			try
			{
				lcCurrent = System.Windows.Forms.Form.ActiveForm.Text;
			}
			catch
			{
				//Ignore the exception
			}

			return tcWindowCaption.ToLower().Trim() == lcCurrent.ToLower().Trim();
		}

		/// <summary>
		/// Returns the title of the currently active form.
		/// The VFP function receives an option window name as a string and returns the 
		/// caption of the window. In our case the caption will be the same as a window name
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static string WTitle()
		{
			string lcString ;
			try
			{
				lcString = System.Windows.Forms.Form.ActiveForm.Text;
			}
			catch
			{	
				lcString = "";
			}
			return lcString;
		}

		/// <summary>
		/// Returns true if the printer is online, otherwise it returns a false.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static bool PrintStatus()
		{
			//If no printers are installed on this machine return false
			string[] myarr = new string[0];
			int nCount = VFPToolkit.arrays.APrinters(out myarr);
			return (nCount >= 1) ;
		}

		/// <summary>
		/// Instead of receiving various parameters and returning strings with various page settings, 
		/// this function now returns the PageSettings object.
		/// <pre>
		/// //Here are some examples that demonstrate how we can access the PrinterSetting
		/// //object to get printing information
		/// 
		/// //Specifies if the default page settings are landscape
		/// bool orientation = pd.PrinterSettings.DefaultPageSettings.Landscape;
		/// 
		/// //Get the height, width and Paper from the PaperSize object
		/// int h = pd.PrinterSettings.DefaultPageSettings.PaperSize.Height;
		/// int w = pd.PrinterSettings.DefaultPageSettings.PaperSize.Width;
		/// string pn = pd.PrinterSettings.DefaultPageSettings.PaperSize.PaperName;
		/// 
		/// //Source of the paper (tray)
		/// string src = pd.PrinterSettings.DefaultPageSettings.PaperSource.SourceName;
		/// 
		/// //Indicates if paper is being printed in color
		/// bool lcolor = pd.PrinterSettings.DefaultPageSettings.Color;
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static System.Drawing.Printing.PageSettings PrtInfo()
		{
			//A PrintDocument object has to be created to specify it to the PrintDialog object
			PrintDocument doc = new PrintDocument();
			PrintDialog pd = new PrintDialog();
			pd.Document = doc;

			return pd.PrinterSettings.DefaultPageSettings;
		}

		/// <summary>
		/// Receives a window caption as a parameter and returns true if a form with that caption 
		/// is the currently active window
		/// <pre>
		/// Example:
		/// VFPToolkit.common.WOnTop("MyForm");	//return a logical value
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cWindowCaption"></param>
		/// <returns></returns>
		public static bool WOnTop(string cWindowCaption)
		{
			//Checks to see if a window is the current top level window
			return (cWindowCaption.ToLower() == Form.ActiveForm.Text.ToLower());
		}

		/// <summary>
		/// Returns the parent of the currently active window.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static string WParent()
		{
			return WParent(Form.ActiveForm);
		}

		/// <summary>
		/// Returns the parent of the Form object passed as a parameter.
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="toForm"></param>
		/// <returns></returns>
		public static string WParent(Form toForm)
		{
			string lcRetVal = "";

			//Check if the form has a parent
			if (toForm.IsMdiChild == true)
			{
				lcRetVal = toForm.MdiParent.Text;
			}
			return lcRetVal;
		}

		/// <summary>
		/// Returns a logical value indicating if a window is minimized or not. 
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool WMinimum(System.Windows.Forms.Form toForm)
		{
			//1 is minimized, 0 is normal, 2 is maximized
			return ((int)(toForm.WindowState) == 1);
		}

		/// <summary>
		/// Returns a logical value indicating if a window is minimized or not. 
		/// When no parameter is specified this method returns WMinimum() for
		/// the currently active form.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool WMinimum()
		{
			return WMinimum(Form.ActiveForm);
		}

		/// <summary>
		/// Returns a logical value indicating if a window is maximized or not. 
		/// When no parameter is specified this method returns WMaximum() for
		/// the currently active form.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool WMaximum()
		{
			return WMaximum(Form.ActiveForm);
		}

		/// <summary>
		/// Returns a logical value indicating if a window is maximized or not. 
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="toForm"></param>
		/// <returns></returns>
		public static bool WMaximum(Form toForm)
		{
			//1 is minimized, 0 is normal, 2 is maximized
			return ((int)(toForm.WindowState) == 2);
		}

		/// <summary>
		/// Returns a logical value indicating if a window has a border or not.
		/// When no parameter is specified this method returns WBorder() for
		/// the currently active form.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool WBorder()
		{
			return WBorder(Form.ActiveForm);
		}

		/// <summary>
		/// Returns a logical value indicating if a window has a border or not.
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="toForm"></param>
		/// <returns></returns>
		public static bool WBorder(Form toForm)
		{
			return !(toForm.FormBorderStyle == FormBorderStyle.None);
		}

		/// <summary>
		/// Returns a logical value indicating if a form is dockable or not.
		/// When no parameter is specified this method returns WDockable() for
		/// the currently active form.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool WDockable()
		{
			return WDockable(Form.ActiveForm);
		}

		/// <summary>
		/// Returns a logical value indicating if a form is dockable or not.
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="toForm"></param>
		/// <returns></returns>
		public static bool WDockable(Form toForm)
		{
			//Specifying the BorderStyle to SizableToolWindow allows us to define dockable windows
			//toForm.BorderStyle = FormBorderStyle.SizableToolWindow;
			//toForm.Dock = System.WinForms.DockStyle.Top;
			return (toForm.FormBorderStyle == FormBorderStyle.SizableToolWindow);
		}

		/// <summary>
		/// Returns a font object being used by the currently active window.
		/// <pre>
		/// Example:
		/// Font oFont = VFPToolkit.common.WFont();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static System.Drawing.Font WFont()
		{
			//Instead of receiving parameters 1,2,3 for font name, size and type
			//We return the font object itself which is more usable
			return WFont(Form.ActiveForm);
		}

		/// <summary>
		/// Returns a font object being used by the currently active window.
		/// Instead of receiving a form caption as a parameter this method
		/// receives a form object as a parameter to make the determination.
		/// </summary>
		/// <param name="toForm"></param>
		/// <returns></returns>
		public static System.Drawing.Font WFont(Form toForm)
		{
			//Instead of receiving parameters 1,2,3 for font name, size and type
			//We return the font object itself which is more usable
			return (toForm.Font);
		}


		/// <summary>
		/// Toggles the value of the CapsLock
		/// </summary>
		/// <returns></returns>
		public static bool CapsLock()
		{
			bool llRetVal = true;
			try 
			{
				System.Windows.Forms.SendKeys.Send("{CAPSLOCK}");
			}
			catch
			{
				//Do not throw an exception simply return a false
				llRetVal = false;
			}
			return llRetVal;

		}
		/// <summary>
		/// Toggles the value of the Insert Key
		/// </summary>
		/// <returns></returns>
		public static bool InsMode()
		{
			common.KeyBoard("{INSERT}");
			return true;
		}
		/// <summary>
		/// Toggles the status of the NumLock Key
		/// </summary>
		/// <returns></returns>
		public static bool NumLock()
		{
			common.KeyBoard("{NUMLOCK}");
			return true;
		}

		/// <summary>
		/// Returns the current version of this Visual FoxPro Toolkit for .NET.
		/// </summary>
		/// <example>
		/// string lcVersion = VFPToolkit.environment.Version();
		/// </example>
		/// <returns></returns>
		public static string Version()
		{
			return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
		}


		/// <summary>
		/// Implementation of the _ClipText Property that allows to get and set data on the clipboard.
		/// <pre>		/// Example:
		/// //Updates the Windows clipboard with string "My Name". You can now use Windows "Paste" 
		/// feature to retrieve the contents or use Ctrl+V
		/// VFPToolkit.environmanet._ClipText = "My Name";			
		/// myVar = VFPToolkit.environmanet._ClipText //Updates the contents of myVar with data from clipboard
		/// 
		/// Tip: Get the clipboard contents through the Clipboard object
		///	MyLabel.Text = (string)Clipboard.GetDataObject().GetData(DataFormats.Text);
		/// </pre>		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static string _ClipText
		{
			//Returns the value in the _ClipText Property
			get 
			{ 
				return (string)Clipboard.GetDataObject().GetData(DataFormats.Text);
			}
			
			//Updates the value of the property with contents of the clipboard
			set 
			{
				//In this case update the clipboard contents
				Clipboard.SetDataObject(value);
			}
		}

		/// <summary>
		/// Specifies the time interval between double and triple mouse clicks. 
		/// Returns the number of milliseconds.
		/// </summary>
		/// <example>
		/// int nInterval ;
		/// nInterval = _DblClick;
		/// </example>
		public int _DblClick
		{
			get { return System.Windows.Forms.SystemInformation.DoubleClickTime; }
		}


		/// <summary>
		/// Returns the current value of the OS environment variable. This method forwards the call to the
		/// private method _GetEnv()
		/// </summary>
		/// <param name="cEnvironmentVariable"></param>
		/// <returns></returns>
		public static string GetEnv(string cEnvironmentVariable)
		{
			return __GetEnv(cEnvironmentVariable);
		}

		/// Private method which is only used internally to return environment variables. Receives a string
		/// as a parameter and returns the environment variable.
		/// <example>		///		//Here is a small  piece of code which creates an array of all the environement variables
		///			
		///		//Get all the environment variables into a collection
		///		System.Collections.ICollection id = System.Environment.GetEnvironmentVariables();
		///			
		///		//Get the Enumerator from the collection
		///		System.Collections.IEnumerator ie = id.GetEnumerator();
		///			
		///		//Create the working defaults. The object returned by the Enumerator is a 
		///		//DictionaryEntry so we create a default one
		///		int i = 0;
		///		System.Collections.DictionaryEntry de ;
		///		string[,] strkeys = new string[id.Count,2];
		///
		///		//Loop through the collection
		///		for (i=0; i .lt. id.Count; i++)
		///		{
		///			//string s = ie.Current.ToString();
		///			ie.MoveNext();				
		///					
		///			//Get the dictionary entry and update the contents of the array
		///			de = (System.Collections.DictionaryEntry)ie.Current;
		///			strkeys[i,0] = de.Key.ToString();
		///			strkeys[i,1] = de.Value.ToString();
		///		}		
		/// </example>
		private static string __GetEnv(string lcEnvironmentVariable)
		{
			//Call the GetEnvironmentVariable() method to get the value in a string format
			string lcRetVal =  System.Environment.GetEnvironmentVariable(lcEnvironmentVariable);
			return lcRetVal;
		}

		/// <summary>
		/// Returns the name of the machine and the user name
		/// <pre>
		/// Example:
		/// VFPToolkit.environment.ID();			//returns "\\Xanadu#KamalP"
		/// </pre>
		/// </summary>
		/// <returns></returns>
		public static string ID()
		{
			return sys(0);
			//return __GetEnv("COMPUTERNAME") + "#" + _GetEnv("USERNAME");

		}

		/// <summary>
		/// Returns a bool specifying if a mouse hardware is present or not
		/// <pre>
		/// Tip: Use the SystemInformation object to get more detailed information about the system
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static bool IsMouse()
		{
			//Return the SystemInformation object's proeprty. This object is available in System.Windows.Forms
			return SystemInformation.MousePresent;
		}

		/// <summary>
		/// Returns a string containing the current Operating System name
		/// </summary>
		/// <returns></returns>
		public static string OS()
		{
			return System.Environment.OSVersion.ToString();
		}
		
		/// <summary>
		/// Visual FoxPro Sys() function receives an int as a parameter and returns a string containing
		/// the requested contents. (Please note that all the sys parameters are not implemented.)
		/// <pre>
		/// Example:
		/// VFPToolkit.environment.sys(5);			//returns the default drive
		/// VFPToolkit.environment.sys(1037);			//displays the page setup dialog
		/// </pre>
		/// </summary>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static string sys(int nValue)
		{
			switch (nValue)
			{
				case 0:
					//Returns the name of the machine and the user name
				{return __GetEnv("LOGONSERVER") + "#" + __GetEnv("USERNAME");}
				case 5:
					//Return the default drive
				{return __GetEnv("SystemDrive");}
				case 1037:
					//Displays the Page Setup Dialog box. Always returns a blank
				{
					dialogs.GetPrinter();
					return "";
				}
				case 2003:
					//Return the current directory
				{return files.CurDir();}
				case 2023:
				{return __GetEnv("TEMP");}
				default:
				{return "";}
			}
		}

		/// <summary>
		/// Returns the size, height, width etc. of window elements. Receives an integer nWindowElement as a parameter and returns an integer with the size/presence of that element.
		/// Please note that currently 30 items are implemented and 4 are outstanding.
		/// <pre>
		/// Example:
		/// VFPToolkit.environment.SysMetric(5);		//returns width of scroll arrows on vertical scroll bar 
		/// VFPToolkit.environment.SysMetric(9);		//returns height of window title 
		/// VFPToolkit.environment.SysMetric(17);		//returns minimized window icon height 
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="nValue"></param>
		/// <returns></returns>
		public static int SysMetric(int nValue)
		{

			switch (nValue)
			{ 
				case 1:
				{
					//1 Screen width 
					return SystemInformation.PrimaryMonitorMaximizedWindowSize.Width;
				}
				case 2:
				{
					//2 Screen height. 
					return SystemInformation.PrimaryMonitorMaximizedWindowSize.Height;
				}

				case 3:
				{
					//3 Width of sizable window frame 
					return SystemInformation.MinimizedWindowSpacingSize.Width;
				}
 
				case 4:
				{
					//4 Height of sizable window frame 
					return SystemInformation.MinimizedWindowSpacingSize.Height;
				}

				case 5:
				{
					//5 Width of scroll arrows on vertical scroll bar 
					//return SystemInformation.VerticalScrollBarArrowWidth;
					return SystemInformation.VerticalScrollBarWidth;
				}

				case 6:
				{
					//6 Height of scroll arrows on vertical scroll bar 
					return SystemInformation.VerticalScrollBarArrowHeight;
				}

				case 7:
				{
					//7 Width of scroll arrows on horizontal scroll bar 
					return SystemInformation.HorizontalScrollBarArrowWidth;
				}

				case 8:
				{
					//8 Height of scroll arrows on horizontal scroll bar 
					return SystemInformation.HorizontalScrollBarHeight;
				}

				case 9:
				{
					//9 Height of window title 
					return SystemInformation.CaptionHeight;
				}

				case 10:
				{
					//10 Width of non-sizable window frame 
					return SystemInformation.FixedFrameBorderSize.Width;
				}

				case 11:
				{
					//11 Height of non-sizable window frame 
					return SystemInformation.FixedFrameBorderSize.Height;
				}

				case 12:
				{
					//12 Width of DOUBLE or PANEL window frame 
					return SystemInformation.FrameBorderSize.Width;
				}

				case 13:
				{
					//13 Height of DOUBLE or PANEL window frame 
					return SystemInformation.FrameBorderSize.Height;
				}

				case 14:
				{
					//14 Scroll box width on horizontal scroll bar in text editing windows 
					//return SystemInformation.HorizontalScrollBoxThumbWidth;
					return SystemInformation.HorizontalScrollBarThumbWidth;
				}

				case 15:
				{
					//15 Scroll box height on vertical scroll bar in text editing windows 
					//return SystemInformation.VerticalScrollBoxThumbWidth;
					return SystemInformation.VerticalScrollBarWidth;
				}

				case 16:
				{
					//16 Minimized window icon width 
					return SystemInformation.IconSize.Width;
				}

				case 17:
				{
					//17 Minimized window icon height 
					return SystemInformation.IconSize.Height;
				}

				case 20:
				{
					//20 Single-line menu bar height 
					return SystemInformation.MenuHeight;
				}

				case 21:
				{
					//21 Maximized window width 
					return SystemInformation.MaxWindowTrackSize.Width;
				}

				case 22:
				{
					//22 Maximized window height 
					return SystemInformation.MaxWindowTrackSize.Height;
				}

				case 23:
				{
					//23 Kanji window height  
					return SystemInformation.KanjiWindowHeight;
				}

				case 24:
				{
					//24 Minimum sizable window width 
					return SystemInformation.MinWindowTrackSize.Width;
				}

				case 25:
				{
					//25 Minimum sizable window height 
					return SystemInformation.MinWindowTrackSize.Height;
				}

				case 26:
				{
					//26 Minimum window width 
					//return SystemInformation.MinumumWindowSize.Width;
					return SystemInformation.MinimumWindowSize.Width;
				}

				case 27:
				{
					//27 Minimum window height 
					return SystemInformation.MinimumWindowSize.Height;
				}

				case 30:
				{
					//30 1 if mouse hardware present; otherwise 0 
					if (SystemInformation.MousePresent == true)  {return 1;} else {return 0;}
				}

				case 31:
				{
					//31 1 for Microsoft Windows debugging version; otherwise 0 
					if (SystemInformation.DebugOS == true) {return 1;} else {return 0;}
				}

				case 32:
				{
					//32 1 if mouse buttons swapped; otherwise 0 
					if(SystemInformation.MouseButtonsSwapped == true) {return 1;} else {return 0;}
				}

				case 33:
				{
					//33 Width of a button in a half-caption window's caption or title bar 
					return SystemInformation.ToolWindowCaptionButtonSize.Width;
				}

				case 34:
				{
					//34 Height of half-caption window caption area 
					return SystemInformation.ToolWindowCaptionHeight;
				}
				default:
					return 0;

			}


		}		

		/// <summary>
		/// Receives a drive as a parameter and returns the diskspace available on that drive
		/// <p/>
		/// <pre>
		/// Example:
		/// Console.WriteLine(DiskSpace("c:"));
		/// </pre>
		/// </summary>
		/// <param name="tcDriveLetter"></param>
		/// <returns></returns>
		public static long DiskSpace(string tcDrive, int tnType)
		{
			long lnRetVal = -1;
			bool llFoundDrive = false;
			string lcSize = "-1", lcFreeSpace = "-1";

			//Extract the drive letter only
			tcDrive = VFPToolkit.files.JustDrive(tcDrive.Trim()).ToUpper();

			ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
			ManagementObjectCollection disks = diskClass.GetInstances(); 

			//Enumerate through the items to get data for each drive.
			foreach (ManagementObject disk in disks) 
			{ 
				//If the user has not specified a drive type then use the first fixed drive
				llFoundDrive = ((tcDrive.Trim().Length == 0) && (disk["DriveType"].ToString() == "3"));

				//If the user has specified a drive then compare the enumerated drives
				//with the one specified. 
				if(!llFoundDrive)
					llFoundDrive = (disk["Name"].ToString() == tcDrive);


				//We have a hit
				if(llFoundDrive)
				{
					//We need to enumerate through the properties to get the size
					PropertyDataCollection diskProperties = disk.Properties;
					foreach (PropertyData diskProperty in diskProperties) 
					{
						if(diskProperty.Name == "Size")
							lcSize = disk[diskProperty.Name].ToString();

						if(diskProperty.Name == "FreeSpace")
							lcFreeSpace = disk[diskProperty.Name].ToString();
					}
					if(tnType == 1)
						lnRetVal = long.Parse(lcSize);
					else
						lnRetVal = long.Parse(lcFreeSpace);
					break;
				}
			}
			return lnRetVal;
		}

		public static long DiskSpace()
		{
			return DiskSpace("", 2);
		}

		public static long DiskSpace(string tcDrive)
		{
			return DiskSpace(tcDrive, 2);
		}
		
		
		/// <summary>
		/// Receives a drive letter as a parameter and returns a numeric value
		/// that indicates the type of drive. 
		/// </summary>
		/// Console.WriteLine(DriveType("C:"));	//returns 3
		/// <returns></returns>
		public static int DriveType(string tcDrive)
		{
			int nRetVal = -1;

			//Extract the drive letter only
			tcDrive = VFPToolkit.files.JustDrive(tcDrive.Trim()).ToUpper();

			//Build the query to get the drive info
			SelectQuery query = new SelectQuery("SELECT Name, DriveType, FreeSpace FROM Win32_LogicalDisk where Name = \"" + tcDrive + "\"");
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
			
			//Enumerate through the items to get data for each drive.
			//In this case we only have one. Left this as an example so you
			//can cut and paste to get other properties.
			foreach(ManagementBaseObject drive in searcher.Get())
			{
				//got to be only one
				//This is actually a uint, but for simplicity kept it as int
				nRetVal = int.Parse(drive["DriveType"].ToString());
			}
			return nRetVal;
		}

		///<summary>
		///</summary>
			
		//End of environment class
	}

}
