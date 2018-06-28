using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpKeys
{
	/// <summary>
	/// Summary description for Dialog_KeyItem.
	/// </summary>
	public class Dialog_KeyItem : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ListBox mapFromKeyListView;
		internal System.Windows.Forms.ListBox mapToKeyListView;
		private System.Windows.Forms.Button typeOriginalKeyButton;
		private System.Windows.Forms.Button typeReplacementKeyButton;
		private Button confirmationButton;
		private GroupBox mapToKeyGroupBox;
		private GroupBox mapFromKeyGroupBox;
		private Panel mainPanel;
		private Button cancelationButton;
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

		public void AddMapping(ListView remappedKeysList)
		{
			MappingListHelper mappingListHelper = new MappingListHelper();
			mappingListHelper.GetAddMappingList(remappedKeysList, ref mapFromKeyListView, ref mapToKeyListView);

			// UI stuff
			this.Text = "SharpKeys: Add New Key Mapping";
			mapFromKeyListView.SelectedIndex = 0;
			mapToKeyListView.SelectedIndex = 0;
		}

		private void SetDropdownSelectedIndex(ref ListBox mapKeyListView, string SelectedItemtext)
		{
			int nPos = 0;
			nPos = mapKeyListView.FindString(SelectedItemtext);
			if (nPos > -1)
				mapKeyListView.SelectedIndex = nPos;
			else
				mapKeyListView.SelectedIndex = 0;
		}

		public void EditMapping(ListView remappedKeysList)
		{
			MappingListHelper mappingListHelper = new MappingListHelper();
			mappingListHelper.GetEditMappingList(remappedKeysList, ref mapFromKeyListView, ref mapToKeyListView);

			// as it's an edit, set the drop down lists to the current From value
			this.SetDropdownSelectedIndex(ref mapFromKeyListView, remappedKeysList.SelectedItems[0].Text);

			// as it's an edit, set the drop down lists to the current To value
			this.SetDropdownSelectedIndex(ref mapToKeyListView, remappedKeysList.SelectedItems[0].SubItems[1].Text);

			this.Text = "SharpKeys: Edit Key Mapping";
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyItem));
			this.mapFromKeyListView = new System.Windows.Forms.ListBox();
			this.typeOriginalKeyButton = new System.Windows.Forms.Button();
			this.typeReplacementKeyButton = new System.Windows.Forms.Button();
			this.mapToKeyListView = new System.Windows.Forms.ListBox();
			this.confirmationButton = new System.Windows.Forms.Button();
			this.mapToKeyGroupBox = new System.Windows.Forms.GroupBox();
			this.mapFromKeyGroupBox = new System.Windows.Forms.GroupBox();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.cancelationButton = new System.Windows.Forms.Button();
			this.mapToKeyGroupBox.SuspendLayout();
			this.mapFromKeyGroupBox.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapFromKeyListView
			// 
			this.mapFromKeyListView.IntegralHeight = false;
			this.mapFromKeyListView.Location = new System.Drawing.Point(9, 20);
			this.mapFromKeyListView.Name = "mapFromKeyListView";
			this.mapFromKeyListView.ScrollAlwaysVisible = true;
			this.mapFromKeyListView.Size = new System.Drawing.Size(230, 276);
			this.mapFromKeyListView.TabIndex = 0;
			// 
			// typeOriginalKeyButton
			// 
			this.typeOriginalKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.typeOriginalKeyButton.Location = new System.Drawing.Point(164, 311);
			this.typeOriginalKeyButton.Name = "typeOriginalKeyButton";
			this.typeOriginalKeyButton.Size = new System.Drawing.Size(75, 23);
			this.typeOriginalKeyButton.TabIndex = 1;
			this.typeOriginalKeyButton.Text = "Type &Key";
			this.typeOriginalKeyButton.Click += new System.EventHandler(this.btnFrom_Click);
			// 
			// typeReplacementKeyButton
			// 
			this.typeReplacementKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.typeReplacementKeyButton.Location = new System.Drawing.Point(164, 311);
			this.typeReplacementKeyButton.Name = "typeReplacementKeyButton";
			this.typeReplacementKeyButton.Size = new System.Drawing.Size(75, 23);
			this.typeReplacementKeyButton.TabIndex = 0;
			this.typeReplacementKeyButton.Text = "Type K&ey";
			this.typeReplacementKeyButton.Click += new System.EventHandler(this.btnTo_Click);
			// 
			// mapToKeyListView
			// 
			this.mapToKeyListView.IntegralHeight = false;
			this.mapToKeyListView.Location = new System.Drawing.Point(9, 20);
			this.mapToKeyListView.Name = "mapToKeyListView";
			this.mapToKeyListView.ScrollAlwaysVisible = true;
			this.mapToKeyListView.Size = new System.Drawing.Size(230, 276);
			this.mapToKeyListView.TabIndex = 1;
			// 
			// confirmationButton
			// 
			this.confirmationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.confirmationButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.confirmationButton.Location = new System.Drawing.Point(367, 373);
			this.confirmationButton.Name = "confirmationButton";
			this.confirmationButton.Size = new System.Drawing.Size(75, 23);
			this.confirmationButton.TabIndex = 2;
			this.confirmationButton.Text = "OK";
			// 
			// mapToKeyGroupBox
			// 
			this.mapToKeyGroupBox.Controls.Add(this.typeReplacementKeyButton);
			this.mapToKeyGroupBox.Controls.Add(this.mapToKeyListView);
			this.mapToKeyGroupBox.Location = new System.Drawing.Point(271, 12);
			this.mapToKeyGroupBox.Name = "mapToKeyGroupBox";
			this.mapToKeyGroupBox.Size = new System.Drawing.Size(251, 347);
			this.mapToKeyGroupBox.TabIndex = 1;
			this.mapToKeyGroupBox.TabStop = false;
			this.mapToKeyGroupBox.Text = "To this key (&To key):";
			// 
			// mapFromKeyGroupBox
			// 
			this.mapFromKeyGroupBox.Controls.Add(this.mapFromKeyListView);
			this.mapFromKeyGroupBox.Controls.Add(this.typeOriginalKeyButton);
			this.mapFromKeyGroupBox.Location = new System.Drawing.Point(14, 12);
			this.mapFromKeyGroupBox.Name = "mapFromKeyGroupBox";
			this.mapFromKeyGroupBox.Size = new System.Drawing.Size(251, 347);
			this.mapFromKeyGroupBox.TabIndex = 0;
			this.mapFromKeyGroupBox.TabStop = false;
			this.mapFromKeyGroupBox.Text = "Map this key (&From key):";
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.BackColor = System.Drawing.Color.Transparent;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.mapFromKeyGroupBox);
			this.mainPanel.Controls.Add(this.confirmationButton);
			this.mainPanel.Controls.Add(this.mapToKeyGroupBox);
			this.mainPanel.Controls.Add(this.cancelationButton);
			this.mainPanel.Location = new System.Drawing.Point(12, 12);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(537, 410);
			this.mainPanel.TabIndex = 4;
			this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
			// 
			// cancelationButton
			// 
			this.cancelationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelationButton.Location = new System.Drawing.Point(447, 373);
			this.cancelationButton.Name = "cancelationButton";
			this.cancelationButton.Size = new System.Drawing.Size(75, 23);
			this.cancelationButton.TabIndex = 3;
			this.cancelationButton.Text = "Cancel";
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
			this.mapToKeyGroupBox.ResumeLayout(false);
			this.mapFromKeyGroupBox.ResumeLayout(false);
			this.mainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnFrom_Click(object sender, System.EventArgs e)
		{
			// Pop open the "typing" form to collect keyboard input to get a valid code
			Dialog_KeyPress dlg = new Dialog_KeyPress();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (mapFromKeyListView.Items.Contains(dlg.m_strSelected))
					mapFromKeyListView.SelectedItem = dlg.m_strSelected;
				else
				{
					// probably an international keyboard code
					MessageBox.Show("You've entered a key that SharpKeys doesn't know about.\n\nPlease check the SharpKeys website for an updated release", "SharpKeys");
				}
			}
		}

		private void btnTo_Click(object sender, System.EventArgs e)
		{
			// Pop open the "typing" form to collect keyboard input to get a valid code
			Dialog_KeyPress dlg = new Dialog_KeyPress();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (mapToKeyListView.Items.Contains(dlg.m_strSelected))
					mapToKeyListView.SelectedItem = dlg.m_strSelected;
				else
				{
					// probably an international keyboard code
					MessageBox.Show("You've entered a key that SharpKeys doesn't know about.\n\nPlease check the SharpKeys website for an updated release", "SharpKeys");
				}
			}
		}

		private void Dialog_KeyItem_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;

			Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
				       Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
				       LinearGradientMode.ForwardDiagonal);

			graphics.FillRectangle(linearGradientBrush, rectangle);
		}

		private void Dialog_KeyItem_Resize(object sender, EventArgs e)
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
