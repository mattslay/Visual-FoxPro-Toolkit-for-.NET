using System;
using System.Drawing.Printing;


/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{

	/// <summary>
	/// <b>Visual FoxPro Helper Functions</b><br/>
	/// This class contains dummy helper functions that guides you in the right direction to achieve a desired functionality.
	/// For example, if you need to call DoDefault(), the function will contains a sample code showing how this can be 
	/// achieved using the .NET Framework. The function itself returns nothing.
	/// </summary>
	public class help
	{

		/// <summary>
		/// Use System.Windows.Forms.Application object to get a reference to the application
		/// </summary>
		public static void _Screen() {}

		/// <summary>
		/// The functionality of DoDefault() to call the parent class's default 
		/// behavior can be achieved by calling base.MethodName(). 
		/// </summary>
		/// <example>
		/// Here is an example:
		/// Example: base.MethodName(Parameters);
		/// </example>		public static void DoDefault()
		{
			//This method only provides help
		}
		
		/// <summary>
		/// The functionality of EditSource() can be achieved by writing a macro 
		/// for the IDE. A sample is included in example section.
		/// <example>
		///</summary>
		/// Here is an example that opens up a document for editing inside the IDE.
		/// 'Open a source code document for editing
		/// Dim Cmd As Command
		/// Dim Doc As Document
		/// Dim TxtDoc As TextDocument
		/// DTE.ItemOperations.OpenFile("FilePath\File Name")
		/// </example>		public static void EditSource()
		{
			//This method only provides help
		}

		/// <summary>
		/// The functionality of IIF() can be achieved by using the ? : syntax as follows
		/// </summary>
		/// </example>
		/// MyValue = IIF(x=y, .T., .F.) && VFP
		/// MyValue = x == y ? True : False	//C# .NET
		/// MyValue = Iif(x = y, True , False)	'VB .NET
		/// </example>
		/// </summary>
		public static void IIF()
		{
			//Dummy place holder method used for helping how an IIF can be achieved 
			//MyValue = IIF(x=y, .T., .F.) now becomes
			//MyValue = x == y ? True : False
		}

		/// <summary>
		/// An example of how the Do() functionality is achieved in .NET is included.
		/// </summary>
		/// <example>
		/// Do MyFile.exe can now be achieved using
		/// Process.Start("MyFile.exe");
		/// </example>
		public static void Do(){}

		/// <summary>
		/// There are couple of ways in which the functionality of NewObject()
		/// is achieved in the .NET Framework. Please check the example section 
		/// for further details. 
		/// </summary>
		/// <example>
		/// This functionality can be achieved couple of ways:
		/// The first method is to create the object: Both a and b do the same job
		/// a. MyCustomerForm oForm = new MyCustomerForm(); //Create a new object here
		/// b. Application.Load(new MyCustomerForm());
		/// c. Activator.CreateInstance() 
		/// Note: Please review GetInterface() to see how an Excel.Application can 
		/// be created in .NET
		/// </example>
		public static void NewObject(){}

		/// <summary>
		/// There are couple of ways in which the functionality of CreateObject()
		/// is achieved in the .NET Framework. Please check the example section 
		/// for further details. 
		/// </summary>
		/// <example>
		/// This functionality can be achieved couple of ways:
		/// The first method is to create the object: Both a and b do the same job
		/// a. MyCustomerForm oForm = new MyCustomerForm(); //Create a new object here
		/// b. Application.Load(new MyCustomerForm());
		/// c. Activator.CreateInstance() 
		/// Note: Please review GetInterface() to see how an Excel.Application can 
		/// be created in .NET
		/// </example>
		public static void CreateObject(){}

		/// <summary>
		/// Please refer further documentation in the .NET Framework on:
		/// Activator.CreateInstance() and Activator.CreateComInstance()
		/// Note: Please review GetInterface() to see how an Excel.Application can 
		/// be created in .NET
		/// </summary>
		public static void CreateObjectEx(){}

		/// <summary>
		/// Please refer further documentation in the .NET Framework on 
		/// Activator.GetObject()
		/// Note: Please review GetInterface() to see how an Excel.Application can 
		/// be created in .NET
		/// </summary>
		public static void GetObject(){}


		/// <summary>
		/// GetInterface() can be achieved by adding object references through
		/// the "Add References" tab to achieve early binding. An example of how
		/// an Excel object is accessed from .NET Framework is included in the example
		/// section.
		/// </summary>
		/// <example>
		/// A Type has to be specified for all the objects in .NET so in order to get
		/// early bound controls you could follow the following steps: The example 
		/// demonstrates how an Excel object is created in .NET
		/// 
		/// 1. Right click on References and select "Add Reference"
		/// 2. Select the "COM Components" tab
		/// 3. Locate the "Microsoft Excel Object Library" and select it
		/// 4. Add the following code
		///		private Excel.Application oExcel = null;
		///		oExcel = new Excel.Application();
		///		oExcel.Visible = true;
		/// </example>
		public static void GetInterface(){}


		///<summary>
		///</summary>


	
	}
}
