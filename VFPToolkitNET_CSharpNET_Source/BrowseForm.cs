using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
//using System.Windows.Forms;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)

// Removed the namespace for the BorwseForm class as we do not want it to show up in the Toolkit
//namespace VFPToolkit
//{
	/// <summary>
	/// Summary description for BrowseForm.
	/// </summary>
	/// <supported>WinForms</supported>
	public class BrowseForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid grdBrowse;
		internal System.Windows.Forms.Button cmdClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BrowseForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grdBrowse = new System.Windows.Forms.DataGrid();
			this.cmdClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdBrowse)).BeginInit();
			this.SuspendLayout();
			// 
			// grdBrowse
			// 
			this.grdBrowse.CaptionVisible = false;
			this.grdBrowse.DataMember = "";
			this.grdBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdBrowse.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdBrowse.Name = "grdBrowse";
			this.grdBrowse.ReadOnly = true;
			this.grdBrowse.Size = new System.Drawing.Size(488, 389);
			this.grdBrowse.TabIndex = 0;
			// 
			// cmdClose
			// 
			this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdClose.Location = new System.Drawing.Point(392, 272);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(24, 23);
			this.cmdClose.TabIndex = 3;
			this.cmdClose.Text = "Close";
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// BrowseForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdClose;
			this.ClientSize = new System.Drawing.Size(488, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grdBrowse,
																		  this.cmdClose});
			this.KeyPreview = true;
			this.Name = "BrowseForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VFP Toolkit for .NET - Browse";
			((System.ComponentModel.ISupportInitialize)(this.grdBrowse)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Sets the datasource of the grid
		/// </summary>
		/// <param name="toView"></param>
		public void SetData(System.Data.DataView toView)
		{
			this.grdBrowse.DataSource = toView;
			this.Text = toView.Table.TableName;
		}


		/// <summary>
		/// Close the form when done. This button is hidden behind the datagrid (Another trick <g> not in the books)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
//}
