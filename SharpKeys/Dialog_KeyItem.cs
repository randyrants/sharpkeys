using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

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
        private Label stFilterFrom;
        private TextBox edFilterFrom;
        private Label stFilterTo;
        private TextBox edFilterTo;

        private List<string> stringsFrom = new List<string>();
        private List<string> stringsTo = new List<string>();
        private string prevFilterFrom = "";
        private string prevFilterTo = "";


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
            this.stFilterFrom = new System.Windows.Forms.Label();
            this.edFilterFrom = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.stFilterTo = new System.Windows.Forms.Label();
            this.edFilterTo = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFrom
            // 
            this.lbFrom.IntegralHeight = false;
            this.lbFrom.ItemHeight = 24;
            this.lbFrom.Location = new System.Drawing.Point(17, 37);
            this.lbFrom.Margin = new System.Windows.Forms.Padding(6);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.ScrollAlwaysVisible = true;
            this.lbFrom.Size = new System.Drawing.Size(418, 506);
            this.lbFrom.TabIndex = 0;
            // 
            // btnFrom
            // 
            this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrom.BackColor = System.Drawing.SystemColors.Control;
            this.btnFrom.Location = new System.Drawing.Point(301, 574);
            this.btnFrom.Margin = new System.Windows.Forms.Padding(6);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(138, 42);
            this.btnFrom.TabIndex = 3;
            this.btnFrom.Text = "Type &Key";
            this.btnFrom.UseVisualStyleBackColor = false;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnTo
            // 
            this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTo.BackColor = System.Drawing.SystemColors.Control;
            this.btnTo.Location = new System.Drawing.Point(301, 574);
            this.btnTo.Margin = new System.Windows.Forms.Padding(6);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(138, 42);
            this.btnTo.TabIndex = 7;
            this.btnTo.Text = "Type K&ey";
            this.btnTo.UseVisualStyleBackColor = false;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // lbTo
            // 
            this.lbTo.IntegralHeight = false;
            this.lbTo.ItemHeight = 24;
            this.lbTo.Location = new System.Drawing.Point(17, 37);
            this.lbTo.Margin = new System.Windows.Forms.Padding(6);
            this.lbTo.Name = "lbTo";
            this.lbTo.ScrollAlwaysVisible = true;
            this.lbTo.Size = new System.Drawing.Size(418, 506);
            this.lbTo.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(673, 689);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 42);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edFilterTo);
            this.groupBox2.Controls.Add(this.stFilterTo);
            this.groupBox2.Controls.Add(this.btnTo);
            this.groupBox2.Controls.Add(this.lbTo);
            this.groupBox2.Location = new System.Drawing.Point(497, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(460, 641);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&To this key:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stFilterFrom);
            this.groupBox1.Controls.Add(this.edFilterFrom);
            this.groupBox1.Controls.Add(this.lbFrom);
            this.groupBox1.Controls.Add(this.btnFrom);
            this.groupBox1.Location = new System.Drawing.Point(26, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(460, 641);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Map this key:";
            // 
            // stFilterFrom
            // 
            this.stFilterFrom.AutoSize = true;
            this.stFilterFrom.Location = new System.Drawing.Point(12, 554);
            this.stFilterFrom.Name = "stFilterFrom";
            this.stFilterFrom.Size = new System.Drawing.Size(50, 13);
            this.stFilterFrom.TabIndex = 1;
            this.stFilterFrom.Text = "Filter:";
            // 
            // edFilterFrom
            // 
            this.edFilterFrom.Location = new System.Drawing.Point(18, 586);
            this.edFilterFrom.Name = "edFilterFrom";
            this.edFilterFrom.Size = new System.Drawing.Size(200, 20);
            this.edFilterFrom.TabIndex = 2;
            this.edFilterFrom.TextChanged += new System.EventHandler(this.edFilterFrom_TextChanged);
            this.edFilterFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edFilterFrom_KeyDown);
            this.edFilterFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edFilterFrom_KeyPress);
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
            this.mainPanel.Location = new System.Drawing.Point(22, 22);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(6);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(983, 755);
            this.mainPanel.TabIndex = 4;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(820, 689);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 42);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // stFilterTo
            // 
            this.stFilterTo.AutoSize = true;
            this.stFilterTo.Location = new System.Drawing.Point(12, 554);
            this.stFilterTo.Name = "stFilterTo";
            this.stFilterTo.Size = new System.Drawing.Size(50, 13);
            this.stFilterTo.TabIndex = 5;
            this.stFilterTo.Text = "Filter:";
            // 
            // edFilterTo
            // 
            this.edFilterTo.Location = new System.Drawing.Point(18, 586);
            this.edFilterTo.Name = "edFilterTo";
            this.edFilterTo.Size = new System.Drawing.Size(200, 20);
            this.edFilterTo.TabIndex = 6;
            this.edFilterTo.TextChanged += new System.EventHandler(this.edFilterTo_TextChanged);
            this.edFilterTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edFilterTo_KeyDown);
            this.edFilterTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edFilterTo_KeyPress);
            // 
            // Dialog_KeyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1029, 801);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_KeyItem";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.Dialog_KeyItem_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_KeyItem_Paint);
            this.Resize += new System.EventHandler(this.Dialog_KeyItem_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void btnFrom_Click(object sender, System.EventArgs e)
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            Dialog_KeyPress dlg = new Dialog_KeyPress();
            dlg.m_hashKeys = m_hashKeys;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (lbFrom.Items.Contains(dlg.m_strSelected))
                    lbFrom.SelectedItem = dlg.m_strSelected;
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
            dlg.m_hashKeys = m_hashKeys;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (lbTo.Items.Contains(dlg.m_strSelected))
                    lbTo.SelectedItem = dlg.m_strSelected;
                else
                {
                    // probably an international keyboard code
                    MessageBox.Show("You've entered a key that SharpKeys doesn't know about.\n\nPlease check the SharpKeys website for an updated release", "SharpKeys");
                }
            }
        }

        private void Dialog_KeyItem_Paint(object sender, PaintEventArgs e)
        {
            if (System.Windows.Forms.SystemInformation.HighContrast)
            {
                return;
            }
            
            Graphics graphics = e.Graphics;

            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                           LinearGradientMode.ForwardDiagonal);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (System.Windows.Forms.SystemInformation.HighContrast)
            {
                return;
            }
            
            Graphics graphics = e.Graphics;

            Rectangle rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), //Color.FromArgb(236, 241, 243), 
                           LinearGradientMode.Vertical);

            graphics.FillRectangle(linearGradientBrush, rectangle);

        }

        private void Dialog_KeyItem_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Dialog_KeyItem_Shown(object sender, EventArgs e)
        {
            foreach (var item in lbFrom.Items)
            {
                stringsFrom.Add(item.ToString());
            }

            foreach (var item in lbTo.Items)
            {
                stringsTo.Add(item.ToString());
            }
        }

        private void edFilterFrom_TextChanged(object sender, EventArgs e)
        {
            string filter = edFilterFrom.Text.ToUpper();
            if (filter == prevFilterFrom)
                return;

            prevFilterFrom = filter;
            lbFrom.Items.Clear();
            foreach (var item in stringsFrom)
            {
                if (item.ToUpper().Contains(filter))
                    lbFrom.Items.Add(item);
            }
        }

        private void edFilterFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && e.Control) // Ctrl+BackSpace
            {
                edFilterFrom.Text = "";
            }
        }

        private void edFilterFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x7F') // 0x7F corresponds to Ctrl+Backspace. Why? Ask Microsoft...
            {
                e.KeyChar = '\x00';
            }
        }

        private void edFilterTo_TextChanged(object sender, EventArgs e)
        {
            string filter = edFilterTo.Text.ToUpper();
            if (filter == prevFilterTo)
                return;

            prevFilterTo = filter;
            lbTo.Items.Clear();
            foreach (var item in stringsTo)
            {
                if (item.ToUpper().Contains(filter))
                    lbTo.Items.Add(item);
            }
        }

        private void edFilterTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && e.Control) // Ctrl+BackSpace
            {
                edFilterTo.Text = "";
            }
        }

        private void edFilterTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x7F') // 0x7F corresponds to Ctrl+Backspace. Why? Ask Microsoft...
            {
                e.KeyChar = '\x00';
            }
        }
    }
}
