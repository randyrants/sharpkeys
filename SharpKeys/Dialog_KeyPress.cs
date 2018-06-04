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
        // data handlers
        internal string m_strSelected = "";

        const string DISABLED_KEY = "Key is disabled\n(00_00)";
        Panel mainPanel;
        Button btnOK;
        Button btnCancel;
        Label lblKey;
        Label label1;
        Label label2;
        Label lblPressed;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        Container components;

        public Dialog_KeyPress()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // required to activate the message hook for this dialog
            Application.AddMessageFilter(this);
        }

        void Dialog_KeyPress_Closing(object sender, System.ComponentModel.CancelEventArgs e) =>
            // required to remove the message hook for this dialog
            Application.RemoveMessageFilter(this);

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_KeyPress));
            mainPanel = new System.Windows.Forms.Panel();
            lblPressed = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnOK = new Button();
            btnCancel = new Button();
            lblKey = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            //
            // mainPanel
            //
            mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mainPanel.Controls.Add(lblPressed);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(btnOK);
            mainPanel.Controls.Add(btnCancel);
            mainPanel.Controls.Add(lblKey);
            mainPanel.Controls.Add(label1);
            mainPanel.Location = new System.Drawing.Point(12, 12);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new System.Drawing.Size(329, 177);
            mainPanel.TabIndex = 12;
            mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(mainPanel_Paint);
            //
            // lblPressed
            //
            lblPressed.AutoSize = true;
            lblPressed.BackColor = System.Drawing.Color.Transparent;
            lblPressed.Location = new System.Drawing.Point(13, 38);
            lblPressed.Name = "lblPressed";
            lblPressed.Size = new System.Drawing.Size(0, 13);
            lblPressed.TabIndex = 17;
            //
            // label2
            //
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Location = new System.Drawing.Point(13, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(307, 3);
            label2.TabIndex = 16;
            //
            // btnOK
            //
            btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Enabled = false;
            btnOK.Location = new System.Drawing.Point(159, 140);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 14;
            btnOK.TabStop = false;
            btnOK.Text = "OK";
            btnOK.Click += new System.EventHandler(btnOK_Click);
            //
            // btnCancel
            //
            btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(240, 140);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 15;
            btnCancel.TabStop = false;
            btnCancel.Text = "Cancel";
            btnCancel.Click += new System.EventHandler(btnCancel_Click);
            //
            // lblKey
            //
            lblKey.BackColor = System.Drawing.Color.Transparent;
            lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblKey.Location = new System.Drawing.Point(14, 57);
            lblKey.Name = "lblKey";
            lblKey.Size = new System.Drawing.Size(299, 59);
            lblKey.TabIndex = 13;
            lblKey.Text = "(press a key)";
            lblKey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(13, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(163, 13);
            label1.TabIndex = 12;
            label1.Text = "Press a button on your keyboard.";
            //
            // Dialog_KeyPress
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(353, 201);
            Controls.Add(mainPanel);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Dialog_KeyPress";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Type Key";
            Paint += new System.Windows.Forms.PaintEventHandler(Dialog_KeyPress_Paint);
            Resize += new System.EventHandler(Dialog_KeyPress_Resize);
            Closing += new System.ComponentModel.CancelEventHandler(Dialog_KeyPress_Closing);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion Windows Form Designer generated code

        void ShowKeyCode(int nCode)
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
                lblKey.Text = DISABLED_KEY;
                btnOK.Enabled = false;
                return;
            }

            // get the code from LPARAM
            // if it's more than 256 then it's an extended key and mapped to 0xE0nn
            string strCode = "";
            if (nCode > 0x0100)
            {
                strCode = string.Format("E0_{0,2:X}", (nCode - 0x0100));
            }
            else
            {
                strCode = string.Format("00_{0,2:X}", nCode);
            }
            strCode = strCode.Replace(" ", "0");

            // Look up the scan code in the hashtable
            string strShow = "";
            if (StringKeys.Default[nCode] != null)
            {
                strShow = string.Format("{0}\n({1})", StringKeys.Default[nCode].Text, strCode);
            }
            else
            {
                strShow = "Scan code: " + strCode;
            }
            lblKey.Text = strShow;

            // UI to collect only valid scancodes
            btnOK.Enabled = true;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x100) //0x100 == WM_KEYDOWN
                ShowKeyCode((int)m.LParam);
            // always return false because we're just watching messages; not
            // trapping them - this message comes from IMessageFilter!
            return false;
        }

        // button handlers - don't have to worry about null b/c they can't get to it
        void btnOK_Click(object sender, EventArgs e)
        {
            AcceptButton = btnOK;
            m_strSelected = lblKey.Text.Replace("\n", " ");
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButton = btnCancel;
            m_strSelected = "";
        }

        void Dialog_KeyPress_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, Width, Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                           LinearGradientMode.ForwardDiagonal);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }

        void Dialog_KeyPress_Resize(object sender, EventArgs e) => Invalidate();

        void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), //Color.FromArgb(236, 241, 243),
                           LinearGradientMode.Vertical);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }
    }
}