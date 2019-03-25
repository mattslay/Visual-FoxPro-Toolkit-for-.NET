Compressed file: VFPToolkitNET.ZIP
Application: Visual FoxPro Toolkit for .NET
Author: Kamal Patel (kppatel@yahoo.com)
Copyright: None (Public Domain)
Date: April 23rd, 2002
Version 1.00
 
All source code and documentation contained in Visual FoxPro Toolkit for .NET 
(VFPToolkitNET.ZIP) has been placed into the public domain.  You may use, modify,
copy, distribute, and demonstrate any source code, example programs, or 
documentation contained in VFPToolkitNET.ZIP freely without copyright protection.
All files contained in VFPToolkitNET.ZIP are provided 'as is' without warranty of
any kind.  In no event shall its authors, contributors, or distributors be liable
for any damages.
 
Visual FoxPro Toolkit for .NET Team:
    - Kamal Patel (Lead Developer, Creator)
    - Cathi Gero (Program Manager)
    - Rick Hodder (Help)
    - Nancy Folsom (Reviewer, Evangelist)
    - Ken Levy (Advisor, Communications)

Installing and using the VFP Toolkit for .NET
---------------------------------------------

The Visual FoxPro Toolkit for .NET ("Toolkit") is a class library that implements Visual FoxPro 
function names for use in Visual Basic .NET and C# .NET projects. In order to use the Toolkit in 
Visual Studio .NET projects, first install the Toolkit and then add the Toolkit as a reference 
to your .NET projects.


Install the VFP Toolkit for .NET
-----------------------------------

1. Extract the files contained in this zip file to C:\VFPToolkitNET directory.
2. From File Explorer, double-click on the Setup.BAT file.  


Add a reference to the VFPToolkitNET assembly to your Visual Studio .NET project
--------------------------------------------------------------------------------

1. Create a new project in Visual Studio .Net.
2. In Solution Explorer, right click on References and select "Add Reference".
3. Under the .Net tab, select "Visual FoxPro Toolkit for .NET" from the list by double-clicking 
   on it. Then click on the Select button. If you do not see the file in the list then click on the 
   Browse button and pick the VFPToolkitNET.dll file from C:\VFPToolkitNET.
4. Click on the OK button. This will add a reference to the Toolkit to your project.

The Toolkit is a class library with methods that correspond to FoxPro functions. How you use them differs depending on the .NET language you are using.
   
   In Visual Basic .NET
   --------------------	
   1. In the Solution Explorer, right-click on your project and select "Properties."
   2. Select Common Properties / Imports from the listing on the left.
   3. In the Namespace textbox, type each line below. After each entry click on the Add Import
      button:

		VFPToolkit.arrays
		VFPToolkit.dates
		VFPToolkit.dialogs
		VFPToolkit.common
		VFPToolkit.environment
		VFPToolkit.files
		VFPToolkit.help
 		VFPToolkit.math
		VFPToolkit.strings
		VFPToolkit.vfpData
   
   4. Click on OK to save your changes.
   
   Alternatively, you can paste the following code into the top of your class module
   (“Module1.vb,” for example):
  
		Imports VFPToolkit.arrays
		Imports VFPToolkit.dates
		Imports VFPToolkit.dialogs
		Imports VFPToolkit.common
		Imports VFPToolkit.environment
		Imports VFPToolkit.files
		Imports VFPToolkit.help
		Imports VFPToolkit.math
		Imports VFPToolkit.strings
		Imports VFPToolkit.vfpData

   5. Use the commands in the same you would in Visual FoxPro.
      For example:

		dim lcContents as String
		lcContents = GetFile()


   In C# .NET
   ----------
   1. Add the following using statement to the top of your class module
      (“Class1.cs,” for example):

		using VFPToolkit;

      Or, you can specify aliases to each of the Toolkit's class wrappers (see below, 
      "About the VFPToolkitNET.dll").
   
      For example:

		using VfpDialogs = VFPToolkit.dialogs;
		using VfpArrays = VFPToolkit.arrays;
		using VfpDates = VFPToolkit.dates;
		using VfpDialogs = VFPToolkit.dialogs;
		using VfpCommon = VFPToolkit.common;
		using VfpEnvironment = VFPToolkit.environment;
		using VfpFiles = VFPToolkit.files;
		using VfpHelp = VFPToolkit.help;
		using VfpMath = VFPToolkit.math;
		using VfpStrings = VFPToolkit.strings;
		using VfpData = VFPToolkit.vfpData;

   2. Using the commands in C# is different than in VB .NET or in Visual FoxPro.

      Reference the namespace followed by the class name followed by the function name.
      For example:

		string lcContents;
		lcContents = VFPToolkit.dialogs.GetFile();

      Or, reference the the class name followed by the function name, if there isn't a namespace conflict.
      For example:

		string lcContents;
		lcContents = dialogs.GetFile();

      Alternately, if you specified an alias in the using command, you can abbreviate the call.
      For example:

		using VfpDialogs = VFPToolkit.dialogs;
		...
	        string lcContents;
		lcContents = VfpDialogs.GetFile();


About the VFPToolkitNET.dll
---------------------------
The VFPToolkitNET.dll is a library of class that "wrap" FoxPro-like functions. They are:

. arrays
. dates
. dialogs
. common
. environment
. files
. help
. math
. strings
. vfpData

Each of these classes has methods that correspond to FoxPro functions.