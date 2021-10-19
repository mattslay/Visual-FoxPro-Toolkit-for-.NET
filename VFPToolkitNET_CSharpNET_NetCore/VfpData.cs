using System;
using System.Data;
using System.Data.OleDb;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// Summary description for vfpData.
	/// </summary>
	public class vfpData
	{
		private static string _Order = "";
		private static bool _Found = false;
		private static string _Filter = "";

		//Create this one as a property so we can trap for errors in get
		public static System.Data.DataView oView ;

		/// <summary>
		/// Returns the number of records in the DataView. 
		/// If you have a filter condition on the DataView then the number of records returned is after 
		/// applying the filters.
		/// </summary>
		/// <example>
		/// vfpData.RecCount(oView);
		/// </example>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static int RecCount(System.Data.DataView toView)
		{
			return toView.Count;
		}
		public static int RecCount(){return RecCount(vfpData.oView);}

		/// <summary>
		/// Returns a string that specifies the current filter condition
		/// </summary>
		/// <example>
		/// vfpData.Filter(oView);
		/// </example>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static string Filter(System.Data.DataView toView)
		{
			return toView.RowFilter;
		}
		public static string Filter(){return Filter(vfpData.oView);}

		/// <summary>
		/// Receives a Field Position and DataView as parameters and returns the field name
		/// otherwise returns a blank
		/// </summary>
		/// <example>
		/// string MyField = vfpData.Field(5, oView);
		/// </example>
		/// <param name="nPosition"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static string Field(int nPosition, System.Data.DataView toView)
		{
			string lcRetVal = "";
			try
			{
				//Handle the position as the columns are zero based
				lcRetVal = toView.Table.Columns[nPosition - 1].ColumnName;
			}
			catch
			{
				//Ignore the catch so a blank string is returned
			}
			return lcRetVal;
		}
		public static string Field(int nPosition){return Field(nPosition, vfpData.oView);}

		/// <summary>
		/// Receives a DataView as a parameter and returns the number of columns in that view
		/// </summary>
		/// <example>
		/// int nTotalFields = vfpData.FCount(oView);
		/// </example>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static int FCount(System.Data.DataView toView)
		{
			//Note that this is NOT a zero based value in the Columns collection
			return toView.Table.Columns.Count;
		}
		public static int FCount(){return FCount(vfpData.oView);}


		/// <summary>
		/// Receives a field name and DataRow as parameters and returns the value in string format. 
		/// If you want to convert your values into specific datatypes then cast
		/// the return value. example: int iid = (int)oRow["iid"];
		/// </summary>
		/// <example>
		/// // You may also use oRow["cname"] directly
		/// string cCustomer = CurVal("cname", oRow);
		/// </example>
		/// <param name="tcField"></param>
		/// <param name="toRow"></param>
		/// <returns></returns>
		public static string CurVal(string tcField, System.Data.DataRow toRow)
		{
			return toRow[tcField].ToString();
		}

		/// <summary>
		/// Returns the current order used to perform searches on the DataView
		/// </summary>
		/// <example>
		/// string CurrentOrder = vfpData.Order(oView);
		/// </example>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static string Order(System.Data.DataView toView)
		{
			return toView.Sort;
		}
		public static string Order(){return Order(vfpData.oView);}

		/// <summary>
		/// Receives a string value and a DataView as parameters and searches the
		/// DataView for that string using the current sort order. Unlike VFP, 
		/// this function does not change the position of the record but returns
		/// the record number if a seek is successful. The function returns a -1 
		/// if the seek is unsuccessful
		/// </summary>
		/// <param name="tcString"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static int Seek(string tcString, System.Data.DataView toView)
		{
			int nFound = 0;
			nFound = toView.Find(tcString);
			
			//If we seek is successful, update the Found flag and return the position
			if(nFound != -1){vfpData._Found = true;}
			return nFound;
		}
		public static int Seek(string tcString){return Seek(tcString, vfpData.oView);}


		/// <summary>
		/// Receives a ReturnField, SearchExpression and field to be searched a as parameters. The function
		/// looks up a value and returns the value of the ReturnField on a successful
		/// search. The function maintains the last Order() of the view.
		/// Please note that unlike the VFP Lookup() command this one receives the ReturnField and SearchField as strings.
		/// </summary>
		/// <example>
		/// string cCustomer = vfpData.Lookup("cname", "60", "iid", oView)
		/// </example>
		/// <param name="tcReturnField"></param>
		/// <param name="tcSearchExpression"></param>
		/// <param name="tcSearchedField"></param>
		/// <returns></returns>
		public static string Lookup(string tcReturnField, string tcSearchExpression, string tcSearchedField, System.Data.DataView toView)
		{
			string cRetVal = "";

			//Capture the current order
			string cOrder = vfpData.Order(toView);

			try
			{
				//Set the order to the search order
				vfpData.SetOrderTo(tcSearchedField, toView);

				int nFoundRec = vfpData.Seek(tcSearchExpression, toView);

				//If we find a record then get the return value
				if(nFoundRec != -1)
				{
					cRetVal = toView.Table.Rows[nFoundRec][tcReturnField].ToString();
					vfpData._Found = true;
				}
			}
			finally
			{
				//Cleanup to reset the old order
				toView.Sort = cOrder;
			}
			return cRetVal;
		}
		public static string Lookup(string tcReturnField, string tcSearchExpression, string tcSearchedField){return vfpData.Lookup(tcReturnField, tcSearchExpression, tcSearchedField, vfpData.oView);}

		/// <summary>
		/// Receives the current position and DataView as parameters and returns a boolean specifying
		/// if it is the last record
		/// </summary>
		/// <example>
		/// bool lEnd = vfpData.EOF(nCounter, oView);
		/// </example>
		/// <param name="nRowNumber"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static bool EOF(int nRowNumber, System.Data.DataView toView)
		{
			//Handle zero based row position
			return (nRowNumber == toView.Count);
		}
		public static bool EOF(int nRowNumber){ return EOF(nRowNumber, vfpData.oView);}

		/// <summary>
		/// Receives the current position and DataView as parameters and returns a boolean specifying
		/// if it is the first record
		/// </summary>
		/// <example>
		/// bool lEnd = vfpData.EOF(nCounter, oView);
		/// </example>
		/// <param name="nRowNumber"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static bool BOF(int nRowNumber, System.Data.DataView toView)
		{
			return (nRowNumber == 0);
		}
		public static bool BOF(int nRowNumber){ return BOF(nRowNumber, vfpData.oView);}


		/// <summary>
		/// Returns the alias that is specified in vfpData.oView property
		/// </summary>
		/// <returns></returns>
		public static string Alias()
		{
			string cRetVal = "";

			if(vfpData.oView.GetType().ToString() == "System.Data.DataView")
			{
				cRetVal = vfpData.oView.Table.TableName;
			}

			return cRetVal;
		}

		/// <summary>
		/// Receives a DataView as a parameter and returns if the current order
		/// in the DataView is descending
		/// </summary>
		/// <example>
		/// bool IsDescending = vfpData.Descending(oView);
		/// </example>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static bool Descending(System.Data.DataView toView)
		{
			string cCurrentOrder = toView.Sort;
			return (cCurrentOrder.ToUpper().IndexOf(" DESC",0) > 0); 
		}
		public static bool Descending(){return vfpData.Descending(vfpData.oView);}

		/// <summary>
		/// As ADO.NET does not support current position of cursors. 
		/// This functions performs the same action as that of a seek
		/// </summary>
		/// <param name="tcExpression"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static int IndexSeek(string tcExpression, System.Data.DataView toView)
		{
			return vfpData.Seek(tcExpression, toView);
		}
		public static int IndexSeek(string tcExpression) {return vfpData.IndexSeek(tcExpression, vfpData.oView);}


		/// <summary>
		/// Receives a DataView as a parameter and specifies that for all the operations 
		/// that follow this will now be the default DataView
		/// </summary>
		/// <example>
		/// vfpData.Select(oView);
		/// </example>
		/// <param name="toView"></param>
		public static void Select(System.Data.DataView toView)
		{
			vfpData.oView = toView;
		}

		/// <summary>
		/// Receives a DataView as a parameter and specifies if it is in read-only mode or not
		/// </summary>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static bool IsReadOnly(System.Data.DataView toView)
		{
			return toView.Table.Rows.IsReadOnly;
		}
		public static bool IsReadOnly(){return IsReadOnly(vfpData.oView);}
		

		/// <summary>
		/// Receives a record number and DataView as parameters and specifies if that
		/// record is marked as deleted in the DataView
		/// </summary>
		/// <param name="nRecNo"></param>
		/// <param name="toView"></param>
		/// <returns></returns>
		public static bool Deleted(int nRecNo, System.Data.DataView toView)
		{
			bool llRetVal = false;

			//Store the current state of filter
			DataViewRowState loCurrentState = toView.RowStateFilter;

			toView.RowStateFilter = System.Data.DataViewRowState.Deleted;
			llRetVal = (toView.Table.Rows[nRecNo].RowState.ToString() == "Deleted");
			
			//reset to original state of filter
			toView.RowStateFilter = loCurrentState;
			return llRetVal;
		}
		public static bool Deleted(int nRecNo){return Deleted(nRecNo, vfpData.oView);}


		/// <summary>
		/// Receives a Filter expression and a DataView as parameters and applies that filter to the DataView
		/// </summary>
		/// <example>
		/// vfpData.SetFilterTo("cname like 'R%'", oView);
		/// </example>
		/// <param name="toView"></param>
		/// <param name="tcFilterExpression"></param>
		public static void SetFilterTo(string tcFilterExpression, System.Data.DataView toView)
		{
			toView.RowFilter = tcFilterExpression;
			vfpData._Filter = tcFilterExpression;
		}
		public static void SetFilterTo(string tcFilterExpression){ SetFilterTo(tcFilterExpression, vfpData.oView);}

		/// <summary>
		/// Receives a field name as a parameter and updates the order of sort in the DataView
		/// </summary>
		/// <param name="tcFieldName"></param>
		/// <param name="toView"></param>
		public static void SetOrderTo(string tcFieldName, System.Data.DataView toView)
		{
			toView.Sort = tcFieldName;
			vfpData._Order = tcFieldName;
		}
		public static void SetOrderTo(string tcFieldName){SetOrderTo(tcFieldName, vfpData.oView);}

		/// <summary>
		/// Returns the number of records in the DataView. If a filter condition is passed
		/// as a parameter, the function returns the  count for that condition
		/// </summary>
		/// <param name="FilterCondition"></param>
		/// <returns></returns>
		public static int Count(string tcFilterCondition, System.Data.DataView toView)
		{
			int nRetVal = 0;

			//Store the current filter condition
			string cCurrentFilter = toView.RowFilter;

			toView.RowFilter = tcFilterCondition;
			nRetVal = toView.Count;
			toView.RowFilter = cCurrentFilter;

			return nRetVal;
		}
		public static int Count(string tcFilterCondition){return Count(tcFilterCondition, vfpData.oView);}
		public static int Count(System.Data.DataView toView){return toView.Count;}
		public static int Count(){return vfpData.oView.Count;}


		/// <summary>
		/// Receives a DataView as a parameter and inserts an empty new record at the end
		/// </summary>
		/// <example>
		/// vfpData.AppendBlank(oView);
		/// </example>
		/// <param name="toView"></param>
		public static DataRow AppendBlank(System.Data.DataView toView)
		{
			DataRowView drv = toView.AddNew();
			return drv.Row;
		}
		public static DataRow AppendBlank(){return AppendBlank(vfpData.oView); }

		/// <summary>
		/// Receives a DataView as a parameter and displays it in a Browse Form 
		/// </summary>
		/// <RequiredNamespaces>WinForms</RequiredNamespaces>
		/// <example>
		/// vfpData.Browse(oView);
		/// </example>
		/// <param name="toView"></param>
		public static void Browse(System.Data.DataView toView)
		{
			//Create a new form
			BrowseForm oForm = new BrowseForm();
			oForm.SetData(toView);
			oForm.Show();
		}
		public static void Browse(){Browse(vfpData.oView);}


		/// <summary>
		/// Receives a record number and DataView as parameters and deletes that
		/// record
		/// </summary>
		/// <param name="nPosition"></param>
		/// <param name="toView"></param>
		public static void Delete(int nRecNo, System.Data.DataView toView)
		{
			toView.Delete(nRecNo);
		}
		public static void Delete(int nRecNo){Delete(nRecNo, vfpData.oView);}

		/// <summary>
		/// Recalls all the changes made to the data. If a record is deleted then it
		/// undeletes the record.
		/// </summary>
		/// <param name="nRecNo"></param>
		/// <param name="toView"></param>
		public static void Recall(int nRecNo, System.Data.DataView toView)
		{
			toView.Table.Rows[nRecNo].RejectChanges();
		}
		public static void Recall(int nRecNo){Recall(nRecNo, vfpData.oView);}

		/// <summary>
		/// Returns a bool indicating the status of the last search/seek operation
		/// </summary>
		/// <returns></returns>
		public static bool Found()
		{
			return vfpData._Found;
		}

		/// <summary>
		/// Receives a command type as a parameter and returns the current status
		/// of SetFilter(), SetOrder() etc 
		/// </summary>
		/// <param name="tcCommandType"></param>
		/// <returns></returns>
		public static string Set(string tcCommandType)
		{
			switch(tcCommandType.ToUpper())
			{
				case "ORDER":
					return vfpData._Order;
				case "FILTER":
					return vfpData._Filter;
			}
			return "";
		}

		/// <summary>
		/// Receives a filter expression as a parameter and deletes all the records
		/// for that filter condition
		/// </summary>
		/// <example>
		/// DeleteFor("cname like 'A*'");
		/// </example>
		/// <param name="cExpression"></param>
		/// <param name="toView"></param>
		public static void DeleteFor(string cExpression, System.Data.DataView toView)
		{
			string lcOldFilter = Set("Filter");

			//Update the Filter condition
			SetFilterTo(cExpression);

			//Loop through each record and delete it
			foreach(System.Data.DataRow r in toView.Table.Rows)
			{
				r.Delete();
			}
			
			//Reset the filter condition
			SetFilterTo(lcOldFilter);
		}
		public static void DeleteFor(string cExpression){DeleteFor(cExpression, vfpData.oView);}

		/// <summary>
		/// Deletes all the records in the DataView
		/// </summary>
		/// <example>
		/// DeleteAll(toView);
		/// </example>
		/// <param name="toView"></param>
		public static void DeleteAll(System.Data.DataView toView)
		{
			//Forward the call to delete for with a blank filter condition
			vfpData.DeleteFor("");
		}
		public static void DeleteAll()
		{
			DeleteAll(vfpData.oView);
		}

		/// <summary>
		/// Receives a DataSet and file name as a parameter and saves the xml of the
		/// DataSet to a file. Returns the number of bytes copied.
		/// </summary>
		/// <example>
		/// CursorToXML(ds, "c:\MyData.xml")
		/// </example>
		/// <param name="toDataSet"></param>
		/// <param name="tcFileName"></param>
		public static int CursorToXML(DataSet toDataSet, string tcFileName)
		{
			// The GetXml() method of the DataSet returns an XML string
			// Call the Toolkit StrToFile() method to save this as a file
			string lcXML = toDataSet.GetXml();
			VFPToolkit.strings.StrToFile(lcXML, tcFileName);
			return lcXML.Length;
		}

		/// <summary>
		/// Receives an XML file and DataSet name as parameters and creates a DataSet
		/// Instead of returning the number of records this one returns the DataSet 
		/// </summary>
		/// <example>
		/// XMLtoCursor("c:\MyData.xml", "MyDataSet")
		/// </example>
		/// <param name="toDataSet"></param>
		/// <param name="tcFileName"></param>
		public static DataSet XMLToCursor(string tcFileName, string tcDataSet)
		{
			DataSet ds = new DataSet(tcDataSet);
			ds.ReadXml(tcFileName);
			return ds;
		}

		/// <summary>
		/// Receives a connection string as a parameter and establishes a connection to
		/// the backend. Returns a connection object back
		/// </summary>
		/// <example>
		/// //Establish a connection and a command 
		/// string lcConnectionString;
		/// string lcSQL;
		/// OleDbConnection oConn;
		/// 
		/// //Get the connection string and sql statement
		/// lcConnectionString = "Provider=vfpoledb.1;Data Source='C:\\Program Files\\Microsoft Visual FoxPro 7\\Samples\\Data\\testdata.dbc';password='';user id=''";
		/// lcSQL = "Select * from customer";
		/// 
		/// //Connect to the Database, execute the query and disconnect
		/// //SqlConnect(), SqlExecute(), SqlDisconnect()
		/// oConn = SqlConnect(lcConnectionString);
		/// goView = SqlExecute(oConn, lcSQL, "CustomerList");
		/// SqlDisConnect(oConn);
		/// 
		/// //Select the default cursor and browse it
		/// VFPToolkit.vfpData.Select(goView);
		/// Browse();
		/// </example>
		/// <param name="tcConnectionString"></param>
		/// <returns></returns>
		public static OleDbConnection SqlConnect(string tcConnectionString)
		{
			return new OleDbConnection(tcConnectionString);
		}

		/// <summary>
		/// Receives a connection string as a parameter and establishes a connection to
		/// the backend. Returns a connection object back
		/// </summary>
		/// <example>
		/// //Establish a connection and a command 
		/// string lcConnectionString;
		/// string lcSQL;
		/// OleDbConnection oConn;
		/// 
		/// //Get the connection string and sql statement
		/// lcConnectionString = "Provider=vfpoledb.1;Data Source='C:\\Program Files\\Microsoft Visual FoxPro 7\\Samples\\Data\\testdata.dbc';password='';user id=''";
		/// lcSQL = "Select * from customer";
		/// 
		/// //Connect to the Database, execute the query and disconnect
		/// //SqlConnect(), SqlExecute(), SqlDisconnect()
		/// oConn = SqlConnect(lcConnectionString);
		/// goView = SqlExecute(oConn, lcSQL, "CustomerList");
		/// SqlDisConnect(oConn);
		/// 
		/// //Select the default cursor and browse it
		/// VFPToolkit.vfpData.Select(goView);
		/// Browse();
		/// </example>
		/// <param name="tcConnectionString"></param>
		/// <returns></returns>
		public static OleDbConnection SqlStringConnect(string tcConnectionString)
		{
			return SqlConnect(tcConnectionString);
		}

		/// <summary>
		/// Receives a OleDbConnection object as a parameter and closes it
		/// </summary>
		/// <example>
		/// //Establish a connection and a command 
		/// string lcConnectionString;
		/// string lcSQL;
		/// OleDbConnection oConn;
		/// 
		/// //Get the connection string and sql statement
		/// lcConnectionString = "Provider=vfpoledb.1;Data Source='C:\\Program Files\\Microsoft Visual FoxPro 7\\Samples\\Data\\testdata.dbc';password='';user id=''";
		/// lcSQL = "Select * from customer";
		/// 
		/// //Connect to the Database, execute the query and disconnect
		/// //SqlConnect(), SqlExecute(), SqlDisconnect()
		/// oConn = SqlConnect(lcConnectionString);
		/// goView = SqlExecute(oConn, lcSQL, "CustomerList");
		/// SqlDisConnect(oConn);
		/// 
		/// //Select the default cursor and browse it
		/// VFPToolkit.vfpData.Select(goView);
		/// Browse();
		/// </example>
		/// <param name="toConn"></param>
		public static void SqlDisConnect(OleDbConnection toConn)
		{	
			toConn.Close();
		}

		/// <summary>
		/// Receives an OleDbConnection and SQL string as parameters and executes the query
		/// </summary>
		/// <example>
		/// //Establish a connection and a command 
		/// string lcConnectionString;
		/// string lcSQL;
		/// OleDbConnection oConn;
		/// 
		/// //Get the connection string and sql statement
		/// lcConnectionString = "Provider=vfpoledb.1;Data Source='C:\\Program Files\\Microsoft Visual FoxPro 7\\Samples\\Data\\testdata.dbc';password='';user id=''";
		/// lcSQL = "Select * from customer";
		/// 
		/// //Connect to the Database, execute the query and disconnect
		/// //SqlConnect(), SqlExecute(), SqlDisconnect()
		/// oConn = SqlConnect(lcConnectionString);
		/// goView = SqlExecute(oConn, lcSQL, "CustomerList");
		/// SqlDisConnect(oConn);
		/// 
		/// //Select the default cursor and browse it
		/// VFPToolkit.vfpData.Select(goView);
		/// Browse();
		/// </example>
		/// <param name="toConn"></param>
		/// <param name="tcSQL"></param>
		/// <returns></returns>
		public static DataView SqlExecute(OleDbConnection toConn, String tcSQL)
		{
			return SqlExecute(toConn, tcSQL, "Query");
		}

		/// <summary>
		/// Receives an OleDbConnection, an OleDbCommand and default view's name as parameters and executes the sql
		/// </summary>
		/// <param name="toConn"></param>
		/// <param name="tcSQL"></param>
		/// <param name="tcAlias"></param>
		/// <returns></returns>
		public static DataView SqlExecute(OleDbConnection toConn, string tcSQL, string tcAlias)
		{
			OleDbCommand oCommand = new OleDbCommand(tcSQL, toConn);
			return SqlExecute(toConn, oCommand, tcAlias);
		}


		/// <summary>
		/// Receives an OleDbConnection and an OleDbCommand as parameters and executes the command
		/// </summary>
		/// <param name="toConn"></param>
		/// <param name="toCommand"></param>
		/// <returns></returns>
		public static DataView SqlExecute(OleDbConnection toConn, OleDbCommand toCommand)
		{
			return SqlExecute(toConn, toCommand, "Query");
		}

		/// <summary>
		/// Receives an OleDbConnection, an OleDbCommand and default view's name as parameters and executes the command
		/// </summary>
		/// <param name="toConn"></param>
		/// <param name="toCommand"></param>
		/// <param name="tcAlias"></param>
		/// <returns></returns>
		public static DataView SqlExecute(OleDbConnection toConn, OleDbCommand toCommand, string tcAlias)
		{
			///Open the connection and create a new DataAdapter
			toConn.Open();
			OleDbDataAdapter da = new OleDbDataAdapter(toCommand);
			
			//Create a blank DataSet and fill the DataSet with the data
			DataSet ds = new DataSet();
			da.Fill(ds, tcAlias);

			//Return the DataView
			return ds.Tables[0].DefaultView;
		}

		///<summary>
		///</summary>

	}
}
