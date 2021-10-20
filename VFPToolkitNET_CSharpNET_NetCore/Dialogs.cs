using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text;
using System.Windows.Forms.Design;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// <b>Visual FoxPro Dialogs</b><br/>
	/// This class contains all the functions that call windows dialog boxes. Some examples
	/// include GetFont(), GetFile(), GetDir() etc.
	/// </summary>
	/// <RequiredNamespaces>WinForms</RequiredNamespaces>
	public class dialogs
	{
		
		/// <summary>
		/// Displays the Color Dialog box and instead of returning a color code this
		/// function returns the actual color object. It receives a color object as a 
		/// parameter and opens the dialog with that color selected
		/// <pre>
		/// Example:
		///	MyLabel.ForeColor = VFPToolkit.dialogs.GetColor(MyLabel.ForeColor);
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="oColor"> </param>
		public static System.Drawing.Color GetColor(System.Drawing.Color oColor)
		{
			//Create a new ColorDialog object
			ColorDialog cd = new ColorDialog();
			
			//Just in case you do not want customers to create their own colors
			//cd.AllowFullOpen = false ;
			cd.ShowHelp = true ;
			
			//Specify the default color to be selected
			cd.Color = oColor ;

			//Show the dialog and return the color
			if(cd.ShowDialog() == DialogResult.Cancel)
			{
				//Visual FoxPro returns the White color when the Cancel button is selected
				cd.Color = Color.White; 
			}
			return  cd.Color;
		}

		/// <summary>
		/// Displays the Color Dialog box and instead of returning a color code this
		/// function returns the actual color object
		/// <pre>
		/// Example:
		/// MyLabel.ForeColor = VFPToolkit.dialogs.GetColor();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static System.Drawing.Color GetColor()
		{
			//Create a new default color object 
			System.Drawing.Color oColor = new Color();

			//Call the overloaded method above and pass the color object to it
			return GetColor(oColor);
		}

		/// <summary>
		/// Displays a dialog box that allows to select a directory. Please note that this is not fully implemented as currently it asks the user to select a file and then extracts the directory part from it.
		/// <pre>
		/// string MyDir = VFPToolkit.dialogs.GetDir();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <returns></returns>
		public static string GetDir()
		{
			return GetDir("");
		}	
		public static string GetDir(string tcTitle)
		{
			//GetDirBrowser is not a built in .NET Framework class
			//It is built in Visual FoxPro Toolkit for .NET and is available
			//in the source code
			GetDirBrowser gd = new GetDirBrowser();
			return gd.ShowIt(tcTitle);
		}	

		/// <summary>
		/// Displays the File Open dialog box and returns the name of the file you select
		/// as a string along with path.
		/// <pre>
		/// Example:
		/// string lcMyFile;
		/// lcMyFile = VFPToolkit.dialogs.GetFile();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static string GetFile()
		{
			return VFPToolkit.dialogs.__GetFile("", 0, "");
		}

		public static string GetFile(string tcFileExtension)
		{
			return VFPToolkit.dialogs.__GetFile(tcFileExtension.Trim(), 3, "");
		}

		public static string GetFile(string tcFileExtension, string tcTitle)
		{
			return VFPToolkit.dialogs.__GetFile(tcFileExtension.Trim(), 3, tcTitle);
		}

		private static string __GetFile(string tcFilter, int tnFilterIndex, string tcTitle)
		{
			string lcFile = "";
			string lcFilter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			int lnFilterIndex = 2;
			string lcTitle = "Open";

			//If a filter condition has been specified then update the text, filter 
			//and default condition to display
			if(tcFilter.Length > 0)
			{
				lcFilter += VFPToolkit.dialogs.__GetExtenstion(tcFilter);
				lnFilterIndex = tnFilterIndex;
			}


			//Check if a title has been specified and if so then get it
			if(tcTitle.Length >0)
			{
				lcTitle = tcTitle;
			}


			//Create the OpenFileDialog (note that the FileDialog class is an abstract and cannot be used directly)
			OpenFileDialog ofd = new OpenFileDialog();
			
			//Specify the default filter to use for displaying files
			ofd.Filter = lcFilter;

			//FilterIndex specifies the default one to select from the above filters
			//In this case All Files
			ofd.FilterIndex = lnFilterIndex;

			//Sepcify the title
			ofd.Title = lcTitle;

			//Specify the default settings for the FileDialog
			ofd.RestoreDirectory = true;
			ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

			//Show the dialog and if the user selects a file return the file name
			if(ofd.ShowDialog() != DialogResult.Cancel)
			{
				//Get the name of the file
				lcFile = ofd.FileName;
			}

			//Return the name of the file
			return lcFile;
		}


		/// <summary>
		/// Calls the windows font dialog box. In this case instead of returning a font
		/// in the form of a string such as "Arial,10,N", a font object is returned. The 
		/// font object exposes properties such as name, size, style, bold, font-family, 
		/// strikeout etc. which we can use to perform better font related manipulations.
		/// <pre>
		/// Example:
		/// //This example demonstrates how all the font attributes can be updated with 
		/// //a single line. Note how the current font object is passed as a parameter
		/// MyLabel.Font = VFPToolkit.dialogs.GetFont(MyLabel.Font);
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="oFont"> </param>
		public static System.Drawing.Font GetFont(Font oFont)
		{
			//Create the FontDialog
			FontDialog fd = new FontDialog();
			
			//Specify a default font for the font dialog
			fd.Font = oFont;

			//These are the VFP defaults which we will ignore and instead of returning a font string 
			//we return a system.Drawing.Font object which has all the font properties exposed
			//fd.AllowScriptChange = false;
			//fd.ShowEffects = true;
			//fd.ShowColor = true;
			
			//Call the Dialog using fd.ShowDialog() which returns a value of type DialogResult
			if(fd.ShowDialog() != DialogResult.Cancel)
			{
				//If the user has selected ok then update our default font object
				oFont = fd.Font;
			}

			//return the font object
			return oFont;
		}
		/// <summary>
		/// Calls the windows font dialog box. This method receives a font name and 
		/// a font size as parameters and calls the windows font dialog.
		/// <pre>
		/// Example:
		/// MyLabel.Font = VFPToolkit.dialogs.GetFont("Arial", 10);
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cFontName"> </param>
		/// <param name="nFontSize"> </param>
		public static System.Drawing.Font GetFont(string cFontName, long nFontSize)
		{
			//In this case we create a font object with the parameters
			Font f = new Font(cFontName, nFontSize);

			//Now we call the method that receives the font object as a parameter and
			//displays the dialog box (the method above this one)
			return GetFont(f);
		}

		/// <summary>
		/// Calls the windows font dialog box. 
		/// <pre>
		/// Example:
		/// MyLabel.Font = VFPToolkit.dialogs.GetFont();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static System.Drawing.Font GetFont()
		{
			//Specify the default one
			return GetFont("Arial",8);
		}

		/// <summary>
		/// Displays the file open dialog box with specific file types for pictures.
		/// <pre>
		/// Example:
		/// string MyPictFile;
		/// MyPictFile = VFPToolkit.dialogs.GetPict();
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static string GetPict()
		{
			string lcFile = "";

			//Create the OpenFileDialog (note that the FileDialog class is an abstract and cannot be used directly)
			OpenFileDialog ofd = new OpenFileDialog();
			
			//Specify the default filter to use for displaying files
			ofd.Filter = "All Files (*.*)|*.*|All Graphic Files (*.bmp;*.dib;*.jpg;*.cur;ani;*.ico;*.gif)|*.bmp;*.dib;*.jpg;*.cur;*.ani;*.ico;*.gif|Bitmap (*.bmp;*.dib)|*.bmp;*.dib|Cursor (*.cur)|*.cur|Animated Cursor (*.ani)|*.ani|Icon (*.ico)|*.ico|JPEG (*.jpg)|*.jpg|GIF (*.gif)|*.gif";
			ofd.FilterIndex = 2;

			//Show the dialog and if the user selects a file return the file name
			if(ofd.ShowDialog() != DialogResult.Cancel)
			{
				//get the name of the file
				lcFile = ofd.FileName;
			}
			//return the file name
			return lcFile;
		}

		/// <summary>
		/// Displays the Print dialog box and returns a string with the name of the 
		/// selected printer 
		/// <pre>
		/// Example:
		/// string lcMyPrinter = GetPrinter();
		/// 
		/// Tip: This is how we can get the orientation from the DefaultPageSettings
		///      bool orientation = pd.PrinterSettings.DefaultPageSettings.Landscape;
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		public static string GetPrinter()
		{
			string lcPrinterName = "";

			//A PrintDocument object has to be created to specify it to the PrintDialog object
			PrintDocument doc = new PrintDocument();
			
			//Create the PrintDialog and specify the default document
			PrintDialog pd = new PrintDialog();
			pd.Document = doc;

			//Specify the defaults
			pd.ShowNetwork = true;
			pd.AllowPrintToFile = true;
			pd.AllowSelection = true;
			pd.AllowSomePages = true;

			//Show the dialog
			if(pd.ShowDialog() != DialogResult.Cancel)
			{
				//Get the name of the printer
				lcPrinterName = pd.PrinterSettings.PrinterName;
			}

			//Return the selected printer
			return lcPrinterName;

		}

		/// <summary>
		/// Receives a file name as a parameter and searches for that file. If the file 
		/// is found then the file name with full path is returned otherwise the GetFile()
		/// dialog box is invoked. (Please note that not all parameters are implemented.)
		/// <pre>
		/// Example:
		/// string SelectedFile;
		/// SelectedFile = VFPToolkit.dialogs.LocFile("MyFile.txt");	//returns c:\Path\MyFile.txt
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cFileName"> </param>
		public static string LocFile(string cFileName)
		{
			string lcFile = "";

			try
			{
				//The first step is to check if this file exists as it could be specified with path
				if (System.IO.File.Exists(cFileName))
					lcFile = files.FullPath(cFileName);
				else if (System.IO.File.Exists(files.AddBS(files.CurDir()) + cFileName))
					lcFile = files.AddBS(files.CurDir()) + cFileName;
				else
					lcFile = dialogs.GetFile();
			}
			catch
			{
				//in case of an error 
				dialogs.MessageBox("An error occured while locating the file.", 16+1, "LocFile error");
			}

			//Return the file now
			return lcFile;
		}

		/// <summary>
		/// Receives a message, title and format number as parameters and displays a MessageBox
		/// <pre>
		/// Example:
		/// MessageBox("My Message", 0, "My Title");
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cMessage"> </param>
		/// <param name="nFormat"> </param>
		/// <param name="cTitle"> </param>
		public static int MessageBox(string cMessage, int nFormat, string cTitle)
		{
			//Specify the default settings
			MessageBoxButtons oButton = (MessageBoxButtons)0;
			int nIconType  = -1;
			MessageBoxIcon oIcon = (MessageBoxIcon)0;

			//If the number is not between 0, 5 then the buttons will be different
			if(VFPToolkit.common.Between(nFormat, 0, 5))
			{
				oButton = (MessageBoxButtons)nFormat;
			}
			else
			{
				if(nFormat >= 16)
				{
					//Extract the button type first
					int nButtonType = nFormat % 16;
					oButton = (MessageBoxButtons)nButtonType;

					//Now get the icon
					nIconType = (nFormat - nButtonType)/16;
					if(nIconType == 1)
						oIcon = MessageBoxIcon.Stop;
					else if(nIconType == 2)
						oIcon = MessageBoxIcon.Question;
					else if(nIconType == 3)
						oIcon = MessageBoxIcon.Exclamation;
					else if(nIconType == 4)
						oIcon = MessageBoxIcon.Information;
					else
					{
						nIconType = -1;
						oButton = (MessageBoxButtons)0;
					}
				}
			}

			//The MessageBox now returns a DialogResult enum object which we convert to integer
			try
			{
				if(nIconType <= 0)
					return (int)System.Windows.Forms.MessageBox.Show(cMessage,cTitle, oButton);
				else
					return (int)System.Windows.Forms.MessageBox.Show(cMessage,cTitle, oButton, oIcon);
			}
			catch
			{
				return (int)System.Windows.Forms.MessageBox.Show(cMessage,cTitle);
			}
		}

		/// <summary>
		/// Receives a message and format number as parameters and displays a MessageBox. Default title is "Message".
		/// <pre>
		/// Example:
		/// MessageBox("My Message", 0);
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cMessage"> </param>
		/// <param name="nFormat"> </param>
		public static int MessageBox(string cMessage, int nFormat)
		{
			return MessageBox(cMessage,nFormat,"Message");
		}		


		/// <summary>
		/// Receives a message as a parameter and displays a MessageBox. Default title is "Message".
		/// <pre>
		/// Example:
		/// MessageBox("My Message");
		/// </pre>
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cMessage"> </param>
		public static int MessageBox(string cMessage)
		{
			return MessageBox(cMessage,0,"Message");
		}

		/// <summary>
		/// Calls the Save As dialog box and returns the file name you specify. (Please note that not all the parameters are implemented.)
		/// </summary>
		/// <example>
		/// VFPToolkit.dialogs.PutFile("Save Custom File As", "MyCustomFile", "abc;def;kam");
		/// </example>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <param name="cFileName"> </param>
		public static string PutFile(string tcTitle, string tcFileName, string tcExtension)
		{
			//Initialize the return file name
			string lcFileName = "";
			string lcFilter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

			//Open the save as dialog for the user to select a file
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.RestoreDirectory = true;
			sfd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			sfd.FileName = tcFileName;
			
			//Specify the default filter to use for displaying files
			if(tcExtension.Trim().Length == 0)
			{
				sfd.Filter = lcFilter ;
				sfd.FilterIndex = 2;
			}
			else
			{
				try
				{
					sfd.Filter = lcFilter + VFPToolkit.dialogs.__GetExtenstion(tcExtension);
					sfd.FilterIndex = 3;
				}
				catch
				{
					sfd.Filter = lcFilter ;
				}
			}

			//check if a title is specified
			if(tcTitle.Trim().Length > 0)
			{
				sfd.Title = tcTitle;
			}

			//Show the dialog and if the user selects a file return the file name
			if(sfd.ShowDialog() != DialogResult.Cancel)
			{
				lcFileName = sfd.FileName;
			}

			//return the file name
			return lcFileName;
		}	

		/// <example>
		/// VFPToolkit.dialogs.PutFile();
		/// </example>
		/// <returns></returns>
		public static string PutFile()
		{
			return PutFile("", "", ""); 
		}
		/// <example>
		/// VFPToolkit.dialogs.PutFile("Save Custom File As");
		/// </example>
		/// <returns></returns>
		public static string PutFile(string tcTitle)
		{
			return PutFile(tcTitle, "", ""); 
		}
		/// <example>
		/// VFPToolkit.dialogs.PutFile("Save Custom File As", "MyCustomFile");
		/// </example>
		/// <returns></returns>
		public static string PutFile(string tcTitle, string tcFileName)
		{
			return PutFile(tcTitle, tcFileName, ""); 
		}

		private static string __GetExtenstion(string lcExtension)
		{
			char[] laSeperators = {';','|'};
			string[] laExtensions = lcExtension.Split(laSeperators);
			StringBuilder sb = new StringBuilder();
			string lcCurrent ;
			string lcPrevious = "";
			for(int i=0; i< laExtensions.Length; i++)
			{
				//Check if the extension has a period and if so then do not add a *
				lcCurrent = laExtensions[i].Trim();

				// Check if there is an open parenthesis in this line and if so then
				// simply store then one and pick up the next one
				if((lcCurrent.IndexOf("(") >= 0) && (lcPrevious.Length == 0))
				{
					lcPrevious = lcCurrent;
					continue;
				}

				if(lcCurrent.Length == 0)
					lcCurrent = "*";

				//If there is no period in this extension then add one
				if(lcCurrent.IndexOf(".") < 0)
					lcCurrent = "*." + lcCurrent;

				//Create the extension
				if(lcPrevious.Length == 0)
				{
					sb.Append("|" + lcCurrent);
					sb.Append("|" + lcCurrent);	//append it twice
				}
				else
				{
					sb.Append("|" + lcPrevious);
					sb.Append("|" + lcCurrent);	
				}

				//reset the previous string
				lcPrevious = "";
			}
			return sb.ToString();
		}

		/// <summary>
		/// A special treatement for the GetDir() as it was not a built in 
		/// .NET Framework class
		/// </summary>
		private class GetDirBrowser : FolderNameEditor 
		{ 
			// inherit the FolderNameEditor class
			FolderNameEditor.FolderBrowser fBrowser;
    	
			public GetDirBrowser()
			{ 
				// contructor
				// create an instance of FolderBrowser
				fBrowser = new System.Windows.Forms.Design.FolderNameEditor.FolderBrowser(); 
			}
    	
			public string ShowIt(string textdescription)
			{
				// set the Description label		
				fBrowser.Description = textdescription;
				fBrowser.ShowDialog(); // show the Windows
				return fBrowser.DirectoryPath;// return whatever path choosen
			}
			~GetDirBrowser()
			{
				// destructor
				fBrowser.Dispose(); 
			}
		}

		///<summary>
		///</summary>
		
		//End of Dialogs class
	}


}
