using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;

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
		private Button confirmationButton;
		private Button cancelationButton;
		private Label keyPressedInformation;
		private Label panelDescription;
		private Label lineDivisor;
		private Label youPressedLabel;

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

		private void Dialog_KeyPress_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// required to remove the message hook for this dialog
			Application.RemoveMessageFilter(this);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyPress));
			this.mainPanel = new System.Windows.Forms.Panel();
			this.youPressedLabel = new System.Windows.Forms.Label();
			this.lineDivisor = new System.Windows.Forms.Label();
			this.confirmationButton = new System.Windows.Forms.Button();
			this.cancelationButton = new System.Windows.Forms.Button();
			this.keyPressedInformation = new System.Windows.Forms.Label();
			this.panelDescription = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.youPressedLabel);
			this.mainPanel.Controls.Add(this.lineDivisor);
			this.mainPanel.Controls.Add(this.confirmationButton);
			this.mainPanel.Controls.Add(this.cancelationButton);
			this.mainPanel.Controls.Add(this.keyPressedInformation);
			this.mainPanel.Controls.Add(this.panelDescription);
			this.mainPanel.Location = new System.Drawing.Point(12, 12);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(329, 177);
			this.mainPanel.TabIndex = 12;
			this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
			// 
			// youPressedLabel
			// 
			this.youPressedLabel.AutoSize = true;
			this.youPressedLabel.BackColor = System.Drawing.Color.Transparent;
			this.youPressedLabel.Location = new System.Drawing.Point(13, 38);
			this.youPressedLabel.Name = "youPressedLabel";
			this.youPressedLabel.Size = new System.Drawing.Size(72, 13);
			this.youPressedLabel.TabIndex = 17;
			// 
			// lineDivisor
			// 
			this.lineDivisor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lineDivisor.Location = new System.Drawing.Point(13, 31);
			this.lineDivisor.Name = "lineDivisor";
			this.lineDivisor.Size = new System.Drawing.Size(307, 3);
			this.lineDivisor.TabIndex = 16;
			// 
			// confirmationButton
			// 
			this.confirmationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.confirmationButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.confirmationButton.Enabled = false;
			this.confirmationButton.Location = new System.Drawing.Point(159, 140);
			this.confirmationButton.Name = "confirmationButton";
			this.confirmationButton.Size = new System.Drawing.Size(75, 23);
			this.confirmationButton.TabIndex = 14;
			this.confirmationButton.TabStop = false;
			this.confirmationButton.Text = "OK";
			this.confirmationButton.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// cancelationButton
			// 
			this.cancelationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelationButton.Location = new System.Drawing.Point(240, 140);
			this.cancelationButton.Name = "cancelationButton";
			this.cancelationButton.Size = new System.Drawing.Size(75, 23);
			this.cancelationButton.TabIndex = 15;
			this.cancelationButton.TabStop = false;
			this.cancelationButton.Text = "Cancel";
			this.cancelationButton.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// keyPressedInformation
			// 
			this.keyPressedInformation.BackColor = System.Drawing.Color.Transparent;
			this.keyPressedInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyPressedInformation.Location = new System.Drawing.Point(14, 57);
			this.keyPressedInformation.Name = "keyPressedInformation";
			this.keyPressedInformation.Size = new System.Drawing.Size(299, 59);
			this.keyPressedInformation.TabIndex = 13;
			this.keyPressedInformation.Text = "(Press a Key)";
			this.keyPressedInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelDescription
			// 
			this.panelDescription.AutoSize = true;
			this.panelDescription.BackColor = System.Drawing.Color.Transparent;
			this.panelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panelDescription.Location = new System.Drawing.Point(13, 9);
			this.panelDescription.Name = "panelDescription";
			this.panelDescription.Size = new System.Drawing.Size(219, 20);
			this.panelDescription.TabIndex = 12;
			this.panelDescription.Text = "Press a key on your keyboard.";
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
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_KeyPress_Closing);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_KeyPress_Paint);
			this.Resize += new System.EventHandler(this.Dialog_KeyPress_Resize);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void ShowKeyCode(int nCode)
		{
			// set up UI label
			if (lblPressed.Text.Length == 0)
				lblPressed.Text = "You pressed: ";

			nCode = nCode >> 16;

			// zeroed bit 30 from documentation 
			// https://msdn.microsoft.com/en-us/library/windows/desktop/ms646280%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396   
			nCode = nCode & 0xBFFF;

			if (nCode == 0)
			{
				keyPressedInformation.Text = DISABLED_KEY;
				confirmationButton.Enabled = false;
				return;
			}

			// get the code from LPARAM
			// if it's more than 256 then it's an extended key and mapped to 0xE0nn
			string keyCode = "";
			if (nCode > 0x0100)
			{
				keyCode = string.Format("E0_{0,2:X}", (nCode - 0x0100));
			}
			else
			{
				keyCode = string.Format("00_{0,2:X}", nCode);
			}
			keyCode = keyCode.Replace(" ", "0");

			// Look up the scan code in the hashtable
			if (m_hashKeys != null)
			{
				keyPressedInformation.Text = string.Format($"{m_hashKeys[keyCode]}\n({keyCode})");
			}
			else
			{
				keyPressedInformation.Text = "Scan code: " + keyCode;
			}

			// UI to collect only valid scancodes
			confirmationButton.Enabled = true;
		}

		public bool PreFilterMessage(ref Message m)
		{
			const int WM_KEYDOWN = 0x100; // https://autohotkey.com/docs/misc/SendMessageList.htm

			if (m.Msg == WM_KEYDOWN)
				ShowKeyCode((int)m.LParam);

			// always return false because we're just watching messages; not
			// trapping them - this message comes from IMessageFilter!
			return false;
		}

		// button handlers - don't have to worry about null b/c they can't get to it
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.AcceptButton = confirmationButton;
			m_strSelected = keyPressedInformation.Text.Replace("\n", " ");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.CancelButton = cancelationButton;
			m_strSelected = "";
		}

		private void Dialog_KeyPress_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
				       Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
				       LinearGradientMode.ForwardDiagonal);

			graphics.FillRectangle(linearGradientBrush, rectangle);
		}

		private void Dialog_KeyPress_Resize(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		private void mainPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			Rectangle rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
				       Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), //Color.FromArgb(236, 241, 243), 
				       LinearGradientMode.Vertical);

			graphics.FillRectangle(linearGradientBrush, rectangle);
		}
	}
}
