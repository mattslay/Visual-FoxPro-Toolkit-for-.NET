using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace VFPToolkitNET_CSharpNET_NetCore
//{
public class BrowseForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.DataGridView grdBrowse;
    internal System.Windows.Forms.Button cmdClose;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public BrowseForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.grdBrowse = new System.Windows.Forms.DataGridView();
        this.cmdClose = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.grdBrowse)).BeginInit();
        this.SuspendLayout();
        // 
        // grdBrowse
        //                 
        this.grdBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grdBrowse.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
        this.grdBrowse.Location = new System.Drawing.Point(0, 0);
        this.grdBrowse.Name = "grdBrowse";
        this.grdBrowse.ReadOnly = true;
        this.grdBrowse.Size = new System.Drawing.Size(488, 389);
        this.grdBrowse.TabIndex = 0;
        // 
        // cmdClose
        // 
        this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdClose.Location = new System.Drawing.Point(428, 344);
        this.cmdClose.Name = "cmdClose";
        this.cmdClose.Size = new System.Drawing.Size(48, 33);
        this.cmdClose.TabIndex = 3;
        this.cmdClose.Text = "Close";
        this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
        // 
        // BrowseForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this.cmdClose;
        this.ClientSize = new System.Drawing.Size(488, 389);
        this.Controls.Add(this.grdBrowse);
        this.Controls.Add(this.cmdClose);
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
