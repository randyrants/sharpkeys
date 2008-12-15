using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharpKeys
{
	/// <summary>
	/// Summary description for Dialog_KeyItem.
	/// </summary>
	public class Dialog_KeyItem : System.Windows.Forms.Form
	{
    // passed into here so it can be pushed through to type key
    internal Hashtable m_hashKeys = null;
    internal System.Windows.Forms.ListBox lbFrom;
    internal System.Windows.Forms.ListBox lbTo;
    private System.Windows.Forms.Button btnFrom;
    private System.Windows.Forms.Button btnTo;
    private Button btnOK;
    private GroupBox groupBox2;
    private GroupBox groupBox1;
    private Panel mainPanel;
    private Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Dialog_KeyItem()
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyItem));
      this.lbFrom = new System.Windows.Forms.ListBox();
      this.btnFrom = new System.Windows.Forms.Button();
      this.btnTo = new System.Windows.Forms.Button();
      this.lbTo = new System.Windows.Forms.ListBox();
      this.btnOK = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbFrom
      // 
      this.lbFrom.IntegralHeight = false;
      this.lbFrom.Location = new System.Drawing.Point(9, 20);
      this.lbFrom.Name = "lbFrom";
      this.lbFrom.ScrollAlwaysVisible = true;
      this.lbFrom.Size = new System.Drawing.Size(230, 276);
      this.lbFrom.TabIndex = 0;
      // 
      // btnFrom
      // 
      this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFrom.Location = new System.Drawing.Point(164, 311);
      this.btnFrom.Name = "btnFrom";
      this.btnFrom.Size = new System.Drawing.Size(75, 23);
      this.btnFrom.TabIndex = 1;
      this.btnFrom.Text = "Type &Key";
      this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
      // 
      // btnTo
      // 
      this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTo.Location = new System.Drawing.Point(164, 311);
      this.btnTo.Name = "btnTo";
      this.btnTo.Size = new System.Drawing.Size(75, 23);
      this.btnTo.TabIndex = 0;
      this.btnTo.Text = "Type K&ey";
      this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
      // 
      // lbTo
      // 
      this.lbTo.IntegralHeight = false;
      this.lbTo.Location = new System.Drawing.Point(9, 20);
      this.lbTo.Name = "lbTo";
      this.lbTo.ScrollAlwaysVisible = true;
      this.lbTo.Size = new System.Drawing.Size(230, 276);
      this.lbTo.TabIndex = 1;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(367, 373);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "OK";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.btnTo);
      this.groupBox2.Controls.Add(this.lbTo);
      this.groupBox2.Location = new System.Drawing.Point(271, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(251, 347);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "To this key (&To key):";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lbFrom);
      this.groupBox1.Controls.Add(this.btnFrom);
      this.groupBox1.Location = new System.Drawing.Point(14, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(251, 347);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Map this key (&From key):";
      // 
      // mainPanel
      // 
      this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.mainPanel.BackColor = System.Drawing.Color.Transparent;
      this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainPanel.Controls.Add(this.groupBox1);
      this.mainPanel.Controls.Add(this.btnOK);
      this.mainPanel.Controls.Add(this.groupBox2);
      this.mainPanel.Controls.Add(this.btnCancel);
      this.mainPanel.Location = new System.Drawing.Point(12, 12);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(537, 410);
      this.mainPanel.TabIndex = 4;
      this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(447, 373);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Cancel";
      // 
      // Dialog_KeyItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(561, 434);
      this.Controls.Add(this.mainPanel);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Dialog_KeyItem";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_KeyItem_Paint);
      this.Resize += new System.EventHandler(this.Dialog_KeyItem_Resize);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.mainPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void btnFrom_Click(object sender, System.EventArgs e) {
      // Pop open the "typing" form to collect keyboard input to get a valid code
      Dialog_KeyPress dlg = new Dialog_KeyPress();
      dlg.m_hashKeys = m_hashKeys;
      if (dlg.ShowDialog() == DialogResult.OK) {
        if (lbFrom.Items.Contains(dlg.m_strSelected))
          lbFrom.SelectedItem = dlg.m_strSelected;
        else {
          // probably an international keyboard code
          MessageBox.Show("You've entered a key that SharpKeys doesn't know about.\n\nPlease check the SharpKeys website for an updated release", "SharpKeys");
        }
      }
    }

    private void btnTo_Click(object sender, System.EventArgs e) {
      // Pop open the "typing" form to collect keyboard input to get a valid code
      Dialog_KeyPress dlg = new Dialog_KeyPress();
      dlg.m_hashKeys = m_hashKeys;
      if (dlg.ShowDialog() == DialogResult.OK) {
        if (lbTo.Items.Contains(dlg.m_strSelected))
          lbTo.SelectedItem = dlg.m_strSelected;
        else {
          // probably an international keyboard code
          MessageBox.Show("You've entered a key that SharpKeys doesn't know about.\n\nPlease check the SharpKeys website for an updated release", "SharpKeys");
        }
      }
    }

    private void Dialog_KeyItem_Paint(object sender, PaintEventArgs e) {
      Graphics graphics = e.Graphics;

      Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                     Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                     LinearGradientMode.ForwardDiagonal);

      graphics.FillRectangle(linearGradientBrush, rectangle);
    }

    private void Dialog_KeyItem_Resize(object sender, EventArgs e) {
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
