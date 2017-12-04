using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharpKeys
{
	/// <summary>
	/// Summary description for Dialog_KeyPress.
	/// </summary>
	public class Dialog_KeyPress : System.Windows.Forms.Form, IMessageFilter
	{
    // passed in from the main form
    internal Hashtable m_hashKeys = null;

    // data handlers
    internal string m_strSelected = "";
    const string DISABLED_KEY = "Key is disabled\n(00_00)";
    private Panel mainPanel;
    private Button btnOK;
    private Button btnCancel;
    private Label lblKey;
    private Label label1;
    private Label label2;
    private Label lblPressed;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Dialog_KeyPress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      // required to activate the message hook for this dialog
      Application.AddMessageFilter(this);
		}

    private void Dialog_KeyPress_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      // required to remove the message hook for this dialog
      Application.RemoveMessageFilter(this);
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyPress));
      this.mainPanel = new System.Windows.Forms.Panel();
      this.lblPressed = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblKey = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.mainPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainPanel
      // 
      this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainPanel.Controls.Add(this.lblPressed);
      this.mainPanel.Controls.Add(this.label2);
      this.mainPanel.Controls.Add(this.btnOK);
      this.mainPanel.Controls.Add(this.btnCancel);
      this.mainPanel.Controls.Add(this.lblKey);
      this.mainPanel.Controls.Add(this.label1);
      this.mainPanel.Location = new System.Drawing.Point(12, 12);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(329, 177);
      this.mainPanel.TabIndex = 12;
      this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
      // 
      // lblPressed
      // 
      this.lblPressed.AutoSize = true;
      this.lblPressed.BackColor = System.Drawing.Color.Transparent;
      this.lblPressed.Location = new System.Drawing.Point(13, 38);
      this.lblPressed.Name = "lblPressed";
      this.lblPressed.Size = new System.Drawing.Size(0, 13);
      this.lblPressed.TabIndex = 17;
      // 
      // label2
      // 
      this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label2.Location = new System.Drawing.Point(13, 27);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(307, 3);
      this.label2.TabIndex = 16;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Enabled = false;
      this.btnOK.Location = new System.Drawing.Point(159, 140);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 14;
      this.btnOK.TabStop = false;
      this.btnOK.Text = "OK";
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(240, 140);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 15;
      this.btnCancel.TabStop = false;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // lblKey
      // 
      this.lblKey.BackColor = System.Drawing.Color.Transparent;
      this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblKey.Location = new System.Drawing.Point(14, 57);
      this.lblKey.Name = "lblKey";
      this.lblKey.Size = new System.Drawing.Size(299, 59);
      this.lblKey.TabIndex = 13;
      this.lblKey.Text = "(press a key)";
      this.lblKey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Location = new System.Drawing.Point(13, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(163, 13);
      this.label1.TabIndex = 12;
      this.label1.Text = "Press a button on your keyboard.";
      // 
      // Dialog_KeyPress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(353, 201);
      this.Controls.Add(this.mainPanel);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Dialog_KeyPress";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Type Key";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_KeyPress_Paint);
      this.Resize += new System.EventHandler(this.Dialog_KeyPress_Resize);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_KeyPress_Closing);
      this.mainPanel.ResumeLayout(false);
      this.mainPanel.PerformLayout();
      this.ResumeLayout(false);

    }
		#endregion

    private void ShowKeyCode(int nCode) {
      // set up UI label
      if (lblPressed.Text.Length == 0)
        lblPressed.Text = "You pressed: ";

      nCode = nCode >> 16;
	  
      // zeroed bit 30 from documentation 
      // https://msdn.microsoft.com/en-us/library/windows/desktop/ms646280%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396   
      nCode = nCode & 0xBFFF;
	  
      if (nCode == 0) {
        lblKey.Text = DISABLED_KEY;
        btnOK.Enabled = false;
        return;
      }

      // get the code from LPARAM
      // if it's more than 256 then it's an extended key and mapped to 0xE0nn
      string strCode = "";
      if (nCode > 0x0100) {
        strCode = string.Format("E0_{0,2:X}", (nCode - 0x0100));
      }
      else {
        strCode = string.Format("00_{0,2:X}", nCode);
      }
      strCode = strCode.Replace(" ", "0");

      // Look up the scan code in the hashtable
      string strShow = "";
      if (m_hashKeys != null) {
        strShow = string.Format("{0}\n({1})", m_hashKeys[strCode], strCode);
      }
      else {
        strShow = "Scan code: " + strCode;
      }
      lblKey.Text = strShow;

      // UI to collect only valid scancodes
      btnOK.Enabled = true;
    }

    public bool PreFilterMessage(ref Message m) {
      if (m.Msg == 0x100) //0x100 == WM_KEYDOWN
        ShowKeyCode((int)m.LParam);
      // always return false because we're just watching messages; not
      // trapping them - this message comes from IMessageFilter!
      return false;
    }

    // button handlers - don't have to worry about null b/c they can't get to it
    private void btnOK_Click(object sender, System.EventArgs e) {
      this.AcceptButton = btnOK;
      m_strSelected = lblKey.Text.Replace("\n", " ");
    }

    private void btnCancel_Click(object sender, System.EventArgs e) {
      this.CancelButton = btnCancel;
      m_strSelected = "";
    }

    private void Dialog_KeyPress_Paint(object sender, PaintEventArgs e) {
      Graphics graphics = e.Graphics;

      Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                     Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                     LinearGradientMode.ForwardDiagonal);

      graphics.FillRectangle(linearGradientBrush, rectangle);
    }

    private void Dialog_KeyPress_Resize(object sender, EventArgs e) {
      this.Invalidate();
    }

    private void mainPanel_Paint(object sender, PaintEventArgs e) {
      Graphics graphics = e.Graphics;

      Rectangle rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                     Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), //Color.FromArgb(236, 241, 243), 
                     LinearGradientMode.Vertical);

      graphics.FillRectangle(linearGradientBrush, rectangle);
    }
	}
}
