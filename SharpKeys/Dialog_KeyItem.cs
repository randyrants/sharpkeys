using System;
using System.Collections;
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
        internal ListBox lbFrom;
        internal ListBox lbTo;
        Button btnFrom;
        Button btnTo;
        Button btnOK;
        GroupBox groupBox2;
        GroupBox groupBox1;
        Panel mainPanel;
        Button btnCancel;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        System.ComponentModel.Container components;

        public Dialog_KeyItem() => InitializeComponent();

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
        void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyItem));
            lbFrom = new ListBox();
            btnFrom = new Button();
            btnTo = new Button();
            lbTo = new ListBox();
            btnOK = new Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            mainPanel = new System.Windows.Forms.Panel();
            btnCancel = new Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            //
            // lbFrom
            //
            lbFrom.IntegralHeight = false;
            lbFrom.Location = new System.Drawing.Point(9, 20);
            lbFrom.Name = "lbFrom";
            lbFrom.ScrollAlwaysVisible = true;
            lbFrom.Size = new System.Drawing.Size(230, 276);
            lbFrom.TabIndex = 0;
            //
            // btnFrom
            //
            btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnFrom.Location = new System.Drawing.Point(164, 311);
            btnFrom.Name = "btnFrom";
            btnFrom.Size = new System.Drawing.Size(75, 23);
            btnFrom.TabIndex = 1;
            btnFrom.Text = "Type &Key";
            btnFrom.Click += new System.EventHandler(btnFrom_Click);
            //
            // btnTo
            //
            btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTo.Location = new System.Drawing.Point(164, 311);
            btnTo.Name = "btnTo";
            btnTo.Size = new System.Drawing.Size(75, 23);
            btnTo.TabIndex = 0;
            btnTo.Text = "Type K&ey";
            btnTo.Click += new System.EventHandler(btnTo_Click);
            //
            // lbTo
            //
            lbTo.IntegralHeight = false;
            lbTo.Location = new System.Drawing.Point(9, 20);
            lbTo.Name = "lbTo";
            lbTo.ScrollAlwaysVisible = true;
            lbTo.Size = new System.Drawing.Size(230, 276);
            lbTo.TabIndex = 1;
            //
            // btnOK
            //
            btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(367, 373);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            //
            // groupBox2
            //
            groupBox2.Controls.Add(btnTo);
            groupBox2.Controls.Add(lbTo);
            groupBox2.Location = new System.Drawing.Point(271, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(251, 347);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "To this key (&To key):";
            //
            // groupBox1
            //
            groupBox1.Controls.Add(lbFrom);
            groupBox1.Controls.Add(btnFrom);
            groupBox1.Location = new System.Drawing.Point(14, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(251, 347);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Map this key (&From key):";
            //
            // mainPanel
            //
            mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            mainPanel.BackColor = System.Drawing.Color.Transparent;
            mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mainPanel.Controls.Add(groupBox1);
            mainPanel.Controls.Add(btnOK);
            mainPanel.Controls.Add(groupBox2);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Location = new System.Drawing.Point(12, 12);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new System.Drawing.Size(537, 410);
            mainPanel.TabIndex = 4;
            mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(mainPanel_Paint);
            //
            // btnCancel
            //
            btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(447, 373);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            //
            // Dialog_KeyItem
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(561, 434);
            Controls.Add(mainPanel);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Dialog_KeyItem";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Paint += new System.Windows.Forms.PaintEventHandler(Dialog_KeyItem_Paint);
            Resize += new System.EventHandler(Dialog_KeyItem_Resize);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

        void btnFrom_Click(object sender, EventArgs e)
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            var dlg = new Dialog_KeyPress();
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

        void btnTo_Click(object sender, EventArgs e)
        {
            // Pop open the "typing" form to collect keyboard input to get a valid code
            var dlg = new Dialog_KeyPress();
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

        void Dialog_KeyItem_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, Width, Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225), LinearGradientMode.ForwardDiagonal);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }

        void Dialog_KeyItem_Resize(object sender, EventArgs e) => Invalidate();

        void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), LinearGradientMode.Vertical);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }
    }
}