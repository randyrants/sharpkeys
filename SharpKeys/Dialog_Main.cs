using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_Main.
    /// </summary>
    public class Dialog_Main : System.Windows.Forms.Form
    {
        // Field for saving window position
        private Rectangle m_rcWindow;

        // Field for registy storage
        private string m_strRegKey = "Software\\RandyRants\\SharpKeys";

        // Hashtable for tracking text to scan codes
        private Hashtable m_hashKeys = null;

        // Dirty flag (to see track if mappings have been saved)
        private bool m_bDirty = false;

        private System.Windows.Forms.ListView lvKeys;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader lvcFrom;
        private System.Windows.Forms.ColumnHeader lvcTo;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel urlMain;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.Windows.Forms.MenuItem mniDeleteAll;
        private System.Windows.Forms.ContextMenu mnuPop;
        private Panel mainPanel;
        private Panel headerPanel;
        private Label displayProduct;
        private LinkLabel urlCode;
        private Button btnLoadKeys;
        private Button btnSaveKeys;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Dialog_Main()
        {
            //
            // Required for Windows Form Designer support
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_Main));
            this.lvKeys = new System.Windows.Forms.ListView();
            this.lvcFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuPop = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mniDeleteAll = new System.Windows.Forms.MenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.urlMain = new System.Windows.Forms.LinkLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.displayProduct = new System.Windows.Forms.Label();
            this.urlCode = new System.Windows.Forms.LinkLabel();
            this.btnLoadKeys = new System.Windows.Forms.Button();
            this.btnSaveKeys = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvKeys
            // 
            this.lvKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcFrom,
            this.lvcTo});
            this.lvKeys.ContextMenu = this.mnuPop;
            this.lvKeys.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvKeys.FullRowSelect = true;
            this.lvKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvKeys.HideSelection = false;
            this.lvKeys.Location = new System.Drawing.Point(19, 55);
            this.lvKeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.Size = new System.Drawing.Size(771, 319);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
            this.lvKeys.DoubleClick += new System.EventHandler(this.lvKeys_DoubleClick);
            // 
            // lvcFrom
            // 
            this.lvcFrom.Text = "Map this key:";
            // 
            // lvcTo
            // 
            this.lvcTo.Text = "To this key:";
            // 
            // mnuPop
            // 
            this.mnuPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniDelete,
            this.menuItem5,
            this.mniDeleteAll});
            this.mnuPop.Popup += new System.EventHandler(this.mnuPop_Popup);
            // 
            // mniAdd
            // 
            this.mniAdd.Index = 0;
            this.mniAdd.Text = "Add";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "Edit";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 2;
            this.mniDelete.Text = "Delete";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // mniDeleteAll
            // 
            this.mniDeleteAll.Index = 4;
            this.mniDeleteAll.Text = "Delete All";
            this.mniDeleteAll.Click += new System.EventHandler(this.mniDeleteAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(545, 381);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Write to Registry";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(694, 381);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(18, 382);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(226, 381);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(122, 382);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(330, 381);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(96, 28);
            this.btnDeleteAll.TabIndex = 4;
            this.btnDeleteAll.Text = "De&lete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Location = new System.Drawing.Point(12, 459);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(784, 4);
            this.label11.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(20, 474);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "SharpKeys 3.9.0 - Copyright 2004 - 2019 RandyRants.com";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(20, 496);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registry hack for remapping keys for Windows";
            // 
            // urlMain
            // 
            this.urlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.urlMain.AutoSize = true;
            this.urlMain.Location = new System.Drawing.Point(601, 496);
            this.urlMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlMain.Name = "urlMain";
            this.urlMain.Size = new System.Drawing.Size(177, 17);
            this.urlMain.TabIndex = 12;
            this.urlMain.TabStop = true;
            this.urlMain.Text = "http://www.randyrants.com/";
            this.urlMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.urlMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlMain_LinkClicked);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.btnLoadKeys);
            this.mainPanel.Controls.Add(this.btnSaveKeys);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.urlCode);
            this.mainPanel.Controls.Add(this.urlMain);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.lvKeys);
            this.mainPanel.Controls.Add(this.btnAdd);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.btnEdit);
            this.mainPanel.Controls.Add(this.btnDelete);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.btnDeleteAll);
            this.mainPanel.Controls.Add(this.btnSave);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Location = new System.Drawing.Point(16, 15);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(810, 529);
            this.mainPanel.TabIndex = 12;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.displayProduct);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(808, 36);
            this.headerPanel.TabIndex = 7;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            // 
            // displayProduct
            // 
            this.displayProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayProduct.ForeColor = System.Drawing.Color.White;
            this.displayProduct.Location = new System.Drawing.Point(13, 2);
            this.displayProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayProduct.Name = "displayProduct";
            this.displayProduct.Size = new System.Drawing.Size(781, 28);
            this.displayProduct.TabIndex = 1;
            this.displayProduct.Text = "SharpKeys";
            this.displayProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // urlCode
            // 
            this.urlCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.urlCode.AutoSize = true;
            this.urlCode.Location = new System.Drawing.Point(515, 474);
            this.urlCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlCode.Name = "urlCode";
            this.urlCode.Size = new System.Drawing.Size(265, 17);
            this.urlCode.TabIndex = 11;
            this.urlCode.TabStop = true;
            this.urlCode.Text = "https://github.com/randyrants/sharpkeys/";
            this.urlCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.urlCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlMain_LinkClicked);
            // 
            // btnLoadKeys
            // 
            this.btnLoadKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadKeys.Location = new System.Drawing.Point(18, 418);
            this.btnLoadKeys.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadKeys.Name = "btnLoadKeys";
            this.btnLoadKeys.Size = new System.Drawing.Size(96, 28);
            this.btnLoadKeys.TabIndex = 7;
            this.btnLoadKeys.Text = "L&oad keys...";
            this.btnLoadKeys.Click += new System.EventHandler(this.btnLoadKeys_Click);
            // 
            // btnSaveKeys
            // 
            this.btnSaveKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveKeys.Location = new System.Drawing.Point(122, 418);
            this.btnSaveKeys.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveKeys.Name = "btnSaveKeys";
            this.btnSaveKeys.Size = new System.Drawing.Size(96, 28);
            this.btnSaveKeys.TabIndex = 8;
            this.btnSaveKeys.Text = "&Save keys...";
            this.btnSaveKeys.Click += new System.EventHandler(this.btnSaveKeys_Click);
            // 
            // Dialog_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 559);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(847, 580);
            this.Name = "Dialog_Main";
            this.Text = "SharpKeys";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Dialog_Main_Closing);
            this.Load += new System.EventHandler(this.Dialog_Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Dialog_Main_Paint);
            this.Resize += new System.EventHandler(this.Dialog_Main_Resize);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Dialog_Main());
        }

        private void LoadRegistrySettings()
        {
            // First load the window positions from registry
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
            Rectangle rc = new Rectangle(10, 10, 750, 550);
            int nWinState = 0, nWarning = 0;

            if (regKey != null)
            {
                // Load Window Pos
                nWinState = (int)regKey.GetValue("MainWinState", 0);
                rc.X = (int)regKey.GetValue("MainX", 10);
                rc.Y = (int)regKey.GetValue("MainY", 10);
                rc.Width = (int)regKey.GetValue("MainCX", 750);
                rc.Height = (int)regKey.GetValue("MainCY", 550);

                nWarning = (int)regKey.GetValue("ShowWarning", 0);
                regKey.Close();
            }

            if (nWarning == 0)
            {
                MessageBox.Show("Welcome to SharpKeys!\n\nThis application will add one key to your registry that allows you\nto change how certain keys on your keyboard will work.\n\nYou must be running Windows 2000 through Windows 10 for this to be supported and\nyou'll be using SharpKeys at your own risk!\n\nEnjoy!\nRandyRants.com", "SharpKeys");
            }

            // Set the WinPos
            m_rcWindow = rc;
            DesktopBounds = m_rcWindow;
            WindowState = (FormWindowState)nWinState;

            // now load the scan code map
            RegistryKey regScanMapKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                byte[] bytes = (byte[])regScanMapKey.GetValue("Scancode Map");
                if (bytes == null)
                {
                    regScanMapKey.Close();
                    return;
                }

                LoadListWithKeys(bytes);

                regScanMapKey.Close();
            }
        }

        private void LoadListWithKeys(byte[] bytes)
        {
            // can skip the first 8 bytes as they are ALWAYS 0x00
            // the 9th byte is ALWAYS the total number of mappings (including the trailing null pointer)
            if (bytes.Length > 8)
            {
                int nTotal = Int32.Parse(bytes[8].ToString());
                for (int i = 0; i < nTotal - 1; i++)
                {
                    // scan codes are stored in ToHi ToLo FromHi FromLo
                    String strFrom, strFromCode, strTo, strToCode;
                    strFromCode = string.Format("{0,2:X}_{1,2:X}", bytes[(i * 4) + 12 + 3], bytes[(i * 4) + 12 + 2]);
                    strFromCode = strFromCode.Replace(" ", "0");
                    strFrom = string.Format("{0} ({1})", (string)m_hashKeys[strFromCode], strFromCode);

                    strToCode = string.Format("{0,2:X}_{1,2:X}", bytes[(i * 4) + 12 + 1], bytes[(i * 4) + 12 + 0]);
                    strToCode = strToCode.Replace(" ", "0");
                    strTo = string.Format("{0} ({1})", (string)m_hashKeys[strToCode], strToCode);

                    ListViewItem lvI = lvKeys.Items.Add(strFrom);
                    lvI.SubItems.Add(strTo);
                }
            }
        }

        private void SaveRegistrySettings()
        {
            // Only save the window position info on close; user is prompted to save mappings elsewhere
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);

            // Save Window Pos
            regKey.SetValue("MainWinState", (int)WindowState);
            regKey.SetValue("MainX", m_rcWindow.X);
            regKey.SetValue("MainY", m_rcWindow.Y);
            regKey.SetValue("MainCX", m_rcWindow.Width);
            regKey.SetValue("MainCY", m_rcWindow.Height);
            regKey.SetValue("ShowWarning", 1);
        }

        private void SaveMappingsToRegistry()
        {
            Cursor = Cursors.WaitCursor;

            // Open the key to save the scancodes
            RegistryKey regScanMapKey = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                if (lvKeys.Items.Count <= 0)
                {
                    // the second param is required; this will throw an exception if the value isn't found,
                    // and it might not always be there (which is valid), so it's ok to ignore it
                    regScanMapKey.DeleteValue("Scancode Map", false);
                }
                else
                {
                    byte[] bytes = DefineScancodeMap();

                    // dump to the registry
                    regScanMapKey.SetValue("Scancode Map", bytes);
                }
                regScanMapKey.Close();
            }
            m_bDirty = false;
            Cursor = Cursors.Default;

            MessageBox.Show("Key Mappings have been successfully stored to the registry.\n\nPlease logout or reboot for these changes to take effect!", "SharpKeys");
        }

        private byte[] DefineScancodeMap()
        {
            int nCount = lvKeys.Items.Count;

            // create a new byte array that is:
            //   8 bytes that are always 00 00 00 00 00 00 00 00 (as is required)
            // + 4 bytes that are used for the count nn 00 00 00 (as is required)
            // + 4 bytes per mapping
            // + 4 bytes for the last mapping (required)
            byte[] bytes = new byte[8 + 4 + (4 * nCount) + 4];

            // skip first 8 (0-7)

            // set 8 to the count, plus the trailing null
            bytes[8] = Convert.ToByte(nCount + 1);

            // skip 9, 10, 11

            // add up the list
            for (int i = 0; i < nCount; i++)
            {
                String str = lvKeys.Items[i].SubItems[1].Text; //Example: (E0_0020)
                int BinaryStartIndex = str.LastIndexOf("_") + 1;
                int BinaryLength = str.LastIndexOf(")") - str.LastIndexOf("_") - 1;
                String Binary = str.Substring(BinaryStartIndex, BinaryLength); //Example: 0020
                String Reg = str.Substring(str.LastIndexOf("(") + 1, 2); //Example: E0
                if (Binary.Length > 2)
                {
                    Binary = Binary.Substring(2);
                }

                bytes[(i * 4) + 12 + 0] = Convert.ToByte(Binary, 16);
                bytes[(i * 4) + 12 + 1] = Convert.ToByte(Reg, 16);

                str = lvKeys.Items[i].Text; //Example: (E0_0020)
                BinaryStartIndex = str.LastIndexOf("_") + 1;
                BinaryLength = str.LastIndexOf(")") - str.LastIndexOf("_") - 1;
                Binary = str.Substring(BinaryStartIndex, BinaryLength); //Example: 0020
                Reg = str.Substring(str.LastIndexOf("(") + 1, 2); //Example: E0
                if (Binary.Length > 2)
                {
                    Binary = Binary.Substring(2);
                }

                bytes[(i * 4) + 12 + 2] = Convert.ToByte(Binary, 16);
                bytes[(i * 4) + 12 + 3] = Convert.ToByte(Reg, 16);
            }

            // last 4 are 0's

            return bytes;
        }

        private void AddMapping()
        {
            // max out the mapping at 104
            if (lvKeys.Items.Count >= 104)
            {
                MessageBox.Show("The maximum number of mappings SharpKeys supports is 16.\n\nPlease delete an existing mapping before adding a new one!", "SharpKeys");
                return;
            }

            // adding a new mapping, so prep the add dialog with all of the scancodes
            Dialog_KeyItem dlg = new Dialog_KeyItem();
            dlg.m_hashKeys = m_hashKeys; // passed into this dialog so it can go out to the next
            IDictionaryEnumerator iDic = m_hashKeys.GetEnumerator();
            while (iDic.MoveNext() == true)
            {
                string str = string.Format("{0} ({1})", iDic.Value, iDic.Key);
                dlg.lbFrom.Items.Add(str);
                dlg.lbTo.Items.Add(str);
            }

            // remove the null setting for "From" since you can never have a null key to map
            int nPos = 0;
            nPos = dlg.lbFrom.FindString("-- Turn Key Off (00_00)");
            if (nPos > -1)
                dlg.lbFrom.Items.RemoveAt(nPos);

            // Now remove any of the keys that have already been mapped in the list (can't double up on from's)
            for (int i = 0; i < lvKeys.Items.Count; i++)
            {
                nPos = dlg.lbFrom.FindString(lvKeys.Items[i].Text);
                if (nPos > -1)
                    dlg.lbFrom.Items.RemoveAt(nPos);
            }

            // let C# sort the lists
            dlg.lbFrom.Sorted = true;
            dlg.lbTo.Sorted = true;

            // UI stuff
            dlg.Text = "SharpKeys: Add New Key Mapping";
            dlg.lbFrom.SelectedIndex = 0;
            dlg.lbTo.SelectedIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_bDirty = true;

                // Add the list, as it's past inspection.
                ListViewItem lvI = lvKeys.Items.Add(dlg.lbFrom.Text);
                lvI.SubItems.Add(dlg.lbTo.Text);
                lvI.Selected = true;
            }
            lvKeys.Focus();
        }

        private void EditMapping()
        {
            // make sure something was selecting
            if (lvKeys.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a mapping to edit!", "SharpKeys");
                return;
            }

            // built the drop down lists no matter what
            Dialog_KeyItem dlg = new Dialog_KeyItem();
            dlg.m_hashKeys = m_hashKeys; // passed into this dialog so it can go out to the next
            IDictionaryEnumerator iDic = m_hashKeys.GetEnumerator();
            while (iDic.MoveNext() == true)
            {
                string str = string.Format("{0} ({1})", iDic.Value, iDic.Key);
                dlg.lbFrom.Items.Add(str);
                dlg.lbTo.Items.Add(str);
            }

            // remove the null setting for "From" since you can never have a null key to map
            int nPos = 0;
            nPos = dlg.lbFrom.FindString("-- Turn Key Off (00_00)");
            if (nPos > -1)
                dlg.lbFrom.Items.RemoveAt(nPos);

            // remove any of the existing from key mappings however, leave in the one that has currently
            // been selected!
            for (int i = 0; i < lvKeys.Items.Count; i++)
            {
                nPos = dlg.lbFrom.FindString(lvKeys.Items[i].Text);
                if ((nPos > -1) && (lvKeys.Items[i].Text != lvKeys.SelectedItems[0].Text))
                {
                    dlg.lbFrom.Items.RemoveAt(nPos);
                }
            }

            // Let C# sort the lists
            dlg.lbFrom.Sorted = true;
            dlg.lbTo.Sorted = true;

            // as it's an edit, set the drop down lists to the current From value
            nPos = dlg.lbFrom.FindString(lvKeys.SelectedItems[0].Text);
            if (nPos > -1)
                dlg.lbFrom.SelectedIndex = nPos;
            else
                dlg.lbFrom.SelectedIndex = 0;

            // as it's an edit, set the drop down lists to the current To value
            nPos = dlg.lbTo.FindString(lvKeys.SelectedItems[0].SubItems[1].Text);
            if (nPos > -1)
                dlg.lbTo.SelectedIndex = nPos;
            else
                dlg.lbTo.SelectedIndex = 0;

            dlg.Text = "SharpKeys: Edit Key Mapping";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_bDirty = true;

                // update the select mapping item in the list view
                lvKeys.SelectedItems[0].Text = dlg.lbFrom.Text;
                lvKeys.SelectedItems[0].SubItems[1].Text = dlg.lbTo.Text;
            }
            lvKeys.Focus();
        }

        private void DeleteMapping()
        {
            // Pop a mapping out of the list view
            if (lvKeys.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a mapping to remove!", "SharpKeys");
                return;
            }

            lvKeys.Items.Remove(lvKeys.SelectedItems[0]);

            m_bDirty = true;
        }

        private void DeleteAllMapping()
        {
            // Since removing all is a big step, get a confirmation
            DialogResult dlgRes = MessageBox.Show("Deleting all will clear this list of key mapping but your registry will not be updated until you click \"Write to Registry\".\n\nDo you want to clear this list of key mappings?", "SharpKeys", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (dlgRes == DialogResult.No)
            {
                return;
            }

            CleanOutTheList();
        }

        private void CleanOutTheList()
        {
            // ...and then clean out the list
            m_bDirty = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
            lvKeys.Items.Clear();
        }

        private void btnLoadKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SharpKeys key list (*.skl)|*.SKL";
            openFileDialog.Title = "Open SharpKey Key List";
            openFileDialog.DefaultExt = "skl";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.CheckPathExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowHelp = false;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filename = openFileDialog.FileName;
            byte[] bytes = File.ReadAllBytes(filename);

            if (bytes.Length > 0)
            {
                try
                {
                    CleanOutTheList();
                    LoadListWithKeys(bytes);
                    m_bDirty = true;
                }
                catch
                {
                    MessageBox.Show("The file you are trying to load is not a valid SKL file!", "SharpKeys");
                }
            }
            else
            {
                MessageBox.Show("You've tried to open a file that is empty!", "SharpKeys");
            }
        }

        private void btnSaveKeys_Click(object sender, EventArgs e)
        {
            if (lvKeys.Items.Count <= 0)
            {
                MessageBox.Show("There are no remapped keys to save to a file!", "SharpKeys");
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "SharpKeys key list (*.skl)|*.SKL";
            saveDialog.Title = "Save SharpKeys Key List";
            saveDialog.DefaultExt = "skl";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.CheckPathExists = true;
            saveDialog.RestoreDirectory = true;
            saveDialog.AddExtension = true;
            saveDialog.ShowHelp = false;
            saveDialog.FileName = "My Keys.skl";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Grab the current bytes in the list
                byte[] bytes = DefineScancodeMap();
                string filename = saveDialog.FileName;
                using (FileStream writer = File.Create(filename))
                {
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void BuildParseTables()
        {
            if (m_hashKeys != null)
                return;

            // the hash table uses a string in the form of Hi_Lo scan code (in Hex values) 
            // that most sources say are scan codes.  The 00_00 will disable a key - everything else 
            // is pretty obvious.  There is a bit of a reverse lookup however, so labels changed here
            // need to be changed in a couple of other places
            m_hashKeys = new Hashtable();
            m_hashKeys.Add("00_00", "-- Turn Key Off");
            m_hashKeys.Add("00_01", "Special: Escape");
            m_hashKeys.Add("00_02", "Key: 1 !");
            m_hashKeys.Add("00_03", "Key: 2 @");
            m_hashKeys.Add("00_04", "Key: 3 #");
            m_hashKeys.Add("00_05", "Key: 4 $");
            m_hashKeys.Add("00_06", "Key: 5 %");
            m_hashKeys.Add("00_07", "Key: 6 ^");
            m_hashKeys.Add("00_08", "Key: 7 &");
            m_hashKeys.Add("00_09", "Key: 8 *");
            m_hashKeys.Add("00_0A", "Key: 9 (");
            m_hashKeys.Add("00_0B", "Key: 0 )");
            m_hashKeys.Add("00_0C", "Key: - _");
            m_hashKeys.Add("00_0D", "Key: = +");
            m_hashKeys.Add("00_0E", "Special: Backspace");
            m_hashKeys.Add("00_0F", "Special: Tab");

            m_hashKeys.Add("00_10", "Key: Q");
            m_hashKeys.Add("00_11", "Key: W");
            m_hashKeys.Add("00_12", "Key: E");
            m_hashKeys.Add("00_13", "Key: R");
            m_hashKeys.Add("00_14", "Key: T");
            m_hashKeys.Add("00_15", "Key: Y");
            m_hashKeys.Add("00_16", "Key: U");
            m_hashKeys.Add("00_17", "Key: I");
            m_hashKeys.Add("00_18", "Key: O");
            m_hashKeys.Add("00_19", "Key: P");
            m_hashKeys.Add("00_1A", "Key: [ {");
            m_hashKeys.Add("00_1B", "Key: ] }");
            m_hashKeys.Add("00_1C", "Special: Enter");
            m_hashKeys.Add("00_1D", "Special: Left Ctrl");
            m_hashKeys.Add("00_1E", "Key: A");
            m_hashKeys.Add("00_1F", "Key: S");

            m_hashKeys.Add("00_20", "Key: D");
            m_hashKeys.Add("00_21", "Key: F");
            m_hashKeys.Add("00_22", "Key: G");
            m_hashKeys.Add("00_23", "Key: H");
            m_hashKeys.Add("00_24", "Key: J");
            m_hashKeys.Add("00_25", "Key: K");
            m_hashKeys.Add("00_26", "Key: L");
            m_hashKeys.Add("00_27", "Key: ; :");
            m_hashKeys.Add("00_28", "Key: ' \"");
            m_hashKeys.Add("00_29", "Key: ` ~");
            m_hashKeys.Add("00_2A", "Special: Left Shift");
            m_hashKeys.Add("00_2B", "Key: \\ |");
            m_hashKeys.Add("00_2C", "Key: Z");
            m_hashKeys.Add("00_2D", "Key: X");
            m_hashKeys.Add("00_2E", "Key: C");
            m_hashKeys.Add("00_2F", "Key: V");

            m_hashKeys.Add("00_30", "Key: B");
            m_hashKeys.Add("00_31", "Key: N");
            m_hashKeys.Add("00_32", "Key: M");
            m_hashKeys.Add("00_33", "Key: , <");
            m_hashKeys.Add("00_34", "Key: . >");
            m_hashKeys.Add("00_35", "Key: / ?");
            m_hashKeys.Add("00_36", "Special: Right Shift");
            m_hashKeys.Add("00_37", "Num: *");
            m_hashKeys.Add("00_38", "Special: Left Alt");
            m_hashKeys.Add("00_39", "Special: Space");
            m_hashKeys.Add("00_3A", "Special: Caps Lock");
            m_hashKeys.Add("00_3B", "Function: F1");
            m_hashKeys.Add("00_3C", "Function: F2");
            m_hashKeys.Add("00_3D", "Function: F3");
            m_hashKeys.Add("00_3E", "Function: F4");
            m_hashKeys.Add("00_3F", "Function: F5");

            m_hashKeys.Add("00_40", "Function: F6");
            m_hashKeys.Add("00_41", "Function: F7");
            m_hashKeys.Add("00_42", "Function: F8");
            m_hashKeys.Add("00_43", "Function: F9");
            m_hashKeys.Add("00_44", "Function: F10");
            m_hashKeys.Add("00_45", "Special: Num Lock");
            m_hashKeys.Add("00_46", "Special: Scroll Lock");
            m_hashKeys.Add("00_47", "Num: 7");
            m_hashKeys.Add("00_48", "Num: 8");
            m_hashKeys.Add("00_49", "Num: 9");
            m_hashKeys.Add("00_4A", "Num: -");
            m_hashKeys.Add("00_4B", "Num: 4");
            m_hashKeys.Add("00_4C", "Num: 5");
            m_hashKeys.Add("00_4D", "Num: 6");
            m_hashKeys.Add("00_4E", "Num: +");
            m_hashKeys.Add("00_4F", "Num: 1");

            m_hashKeys.Add("00_50", "Num: 2");
            m_hashKeys.Add("00_51", "Num: 3");
            m_hashKeys.Add("00_52", "Num: 0");
            m_hashKeys.Add("00_53", "Num: .");
            m_hashKeys.Add("00_54", "Unknown: 0x0054");
            m_hashKeys.Add("00_55", "Unknown: 0x0055");
            m_hashKeys.Add("00_56", "Special: ISO extra key");
            m_hashKeys.Add("00_57", "Function: F11");
            m_hashKeys.Add("00_58", "Function: F12");
            m_hashKeys.Add("00_59", "Unknown: 0x0059");
            m_hashKeys.Add("00_5A", "Unknown: 0x005A");
            m_hashKeys.Add("00_5B", "Unknown: 0x005B");
            m_hashKeys.Add("00_5C", "Unknown: 0x005C");
            m_hashKeys.Add("00_5D", "Unknown: 0x005D");
            m_hashKeys.Add("00_5E", "Unknown: 0x005E");
            m_hashKeys.Add("00_5F", "Unknown: 0x005F");

            m_hashKeys.Add("00_60", "Unknown: 0x0060");
            m_hashKeys.Add("00_61", "Unknown: 0x0061");
            m_hashKeys.Add("00_62", "Unknown: 0x0062");
            m_hashKeys.Add("00_63", "Unknown: 0x0063");
            m_hashKeys.Add("00_64", "Function: F13");
            m_hashKeys.Add("00_65", "Function: F14");
            m_hashKeys.Add("00_66", "Function: F15");
            m_hashKeys.Add("00_67", "Function: F16");   // Mac keyboard 
            m_hashKeys.Add("00_68", "Function: F17");   // Mac keyboard
            m_hashKeys.Add("00_69", "Function: F18");   // Mac keyboard
            m_hashKeys.Add("00_6A", "Function: F19");   // Mac keyboard
            m_hashKeys.Add("00_6B", "Function: F20");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6C", "Function: F21");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6D", "Function: F22");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6E", "Function: F23");   // IBM Model F 122-keys
            m_hashKeys.Add("00_6F", "Function: F24");   // IBM Model F 122-keys

            m_hashKeys.Add("00_70", "Unknown: 0x0070");
            m_hashKeys.Add("00_71", "Unknown: 0x0071");
            m_hashKeys.Add("00_72", "Unknown: 0x0072");
            m_hashKeys.Add("00_73", "Unknown: 0x0073");
            m_hashKeys.Add("00_74", "Unknown: 0x0074");
            m_hashKeys.Add("00_75", "Unknown: 0x0075");
            m_hashKeys.Add("00_76", "Unknown: 0x0076");
            m_hashKeys.Add("00_77", "Unknown: 0x0077");
            m_hashKeys.Add("00_78", "Unknown: 0x0078");
            m_hashKeys.Add("00_79", "Unknown: 0x0079");
            m_hashKeys.Add("00_7A", "Unknown: 0x007A");
            m_hashKeys.Add("00_7B", "Unknown: 0x007B");
            m_hashKeys.Add("00_7C", "Unknown: 0x007C");
            m_hashKeys.Add("00_7D", "Special: ¥ -");
            m_hashKeys.Add("00_7E", "Unknown: 0x007E");
            m_hashKeys.Add("00_7F", "Unknown: 0x007F");

            m_hashKeys.Add("E0_01", "Unknown: 0xE001");
            m_hashKeys.Add("E0_02", "Unknown: 0xE002");
            m_hashKeys.Add("E0_03", "Unknown: 0xE003");
            m_hashKeys.Add("E0_04", "Unknown: 0xE004");
            m_hashKeys.Add("E0_05", "Unknown: 0xE005");
            m_hashKeys.Add("E0_06", "Unknown: 0xE006");
            m_hashKeys.Add("E0_07", "F-Lock: Redo");
            m_hashKeys.Add("E0_08", "F-Lock: Undo");
            m_hashKeys.Add("E0_09", "Unknown: 0xE009");
            m_hashKeys.Add("E0_0A", "Unknown: 0xE00A");
            m_hashKeys.Add("E0_0B", "Unknown: 0xE00B");
            m_hashKeys.Add("E0_0C", "Unknown: 0xE00C");
            m_hashKeys.Add("E0_0D", "Unknown: 0xE00D");
            m_hashKeys.Add("E0_0E", "Unknown: 0xE00E");
            m_hashKeys.Add("E0_0F", "Unknown: 0xE00F");

            m_hashKeys.Add("E0_10", "Media: Prev Track");
            m_hashKeys.Add("E0_11", "App: Messenger");
            m_hashKeys.Add("E0_12", "Logitech: Webcam");
            m_hashKeys.Add("E0_13", "Logitech: iTouch");
            m_hashKeys.Add("E0_14", "Logitech: Shopping");
            m_hashKeys.Add("E0_15", "Unknown: 0xE015");
            m_hashKeys.Add("E0_16", "Unknown: 0xE016");
            m_hashKeys.Add("E0_17", "Unknown: 0xE017");
            m_hashKeys.Add("E0_18", "Unknown: 0xE018");
            m_hashKeys.Add("E0_19", "Media: Next Track");
            m_hashKeys.Add("E0_1A", "Unknown: 0xE01A");
            m_hashKeys.Add("E0_1B", "Unknown: 0xE01B");
            m_hashKeys.Add("E0_1C", "Num: Enter");
            m_hashKeys.Add("E0_1D", "Special: Right Ctrl");
            m_hashKeys.Add("E0_1E", "Unknown: 0xE01E");
            m_hashKeys.Add("E0_1F", "Unknown: 0xE01F");

            m_hashKeys.Add("E0_20", "Media: Mute");
            m_hashKeys.Add("E0_21", "App: Calculator");
            m_hashKeys.Add("E0_22", "Media: Play/Pause");
            m_hashKeys.Add("E0_23", "F-Lock: Spell");
            m_hashKeys.Add("E0_24", "Media: Stop");
            m_hashKeys.Add("E0_25", "Unknown: 0xE025");
            m_hashKeys.Add("E0_26", "Unknown: 0xE026");
            m_hashKeys.Add("E0_27", "Unknown: 0xE027");
            m_hashKeys.Add("E0_28", "Unknown: 0xE028");
            m_hashKeys.Add("E0_29", "Unknown: 0xE029");
            m_hashKeys.Add("E0_2A", "Unknown: 0xE02A");
            m_hashKeys.Add("E0_2B", "Unknown: 0xE02B");
            m_hashKeys.Add("E0_2C", "Unknown: 0xE02C");
            m_hashKeys.Add("E0_2D", "Unknown: 0xE02D");
            m_hashKeys.Add("E0_2E", "Media: Volume Down");
            m_hashKeys.Add("E0_2F", "Unknown: 0xE02F");

            m_hashKeys.Add("E0_30", "Media: Volume Up");
            m_hashKeys.Add("E0_31", "Unknown: 0xE031");
            m_hashKeys.Add("E0_32", "Web: Home");
            m_hashKeys.Add("E0_33", "Unknown: 0xE033");
            m_hashKeys.Add("E0_34", "Unknown: 0xE034");
            m_hashKeys.Add("E0_35", "Num: /");
            m_hashKeys.Add("E0_36", "Unknown: 0xE036");
            m_hashKeys.Add("E0_37", "Special: PrtSc");
            m_hashKeys.Add("E0_38", "Special: Right Alt");
            m_hashKeys.Add("E0_2038", "Special: Alt Gr");
            m_hashKeys.Add("E0_39", "Unknown: 0xE039");
            m_hashKeys.Add("E0_3A", "Unknown: 0xE03A");
            m_hashKeys.Add("E0_3B", "F-Lock: Help");        
            m_hashKeys.Add("E0_3C", "F-Lock: Office Home"); 
            m_hashKeys.Add("E0_3D", "F-Lock: Task Pane");   
            m_hashKeys.Add("E0_3E", "F-Lock: New");         
            m_hashKeys.Add("E0_3F", "F-Lock: Open");        

            m_hashKeys.Add("E0_40", "F-Lock: Close");       
            m_hashKeys.Add("E0_41", "F-Lock: Reply");       
            m_hashKeys.Add("E0_42", "F-Lock: Fwd");         
            m_hashKeys.Add("E0_43", "F-Lock: Send");        
            m_hashKeys.Add("E0_44", "Unknown: 0xE044");
            m_hashKeys.Add("E0_45", "Special: €"); 
            m_hashKeys.Add("E0_46", "Special: Break");
            m_hashKeys.Add("E0_47", "Special: Home");
            m_hashKeys.Add("E0_48", "Arrow: Up");
            m_hashKeys.Add("E0_49", "Special: Page Up");
            m_hashKeys.Add("E0_4A", "Unknown: 0xE04A");
            m_hashKeys.Add("E0_4B", "Arrow: Left");
            m_hashKeys.Add("E0_4C", "Unknown: 0xE04C");
            m_hashKeys.Add("E0_4D", "Arrow: Right");
            m_hashKeys.Add("E0_4E", "Unknown: 0xE04E");
            m_hashKeys.Add("E0_4F", "Special: End");

            m_hashKeys.Add("E0_50", "Arrow: Down");
            m_hashKeys.Add("E0_51", "Special: Page Down");
            m_hashKeys.Add("E0_52", "Special: Insert");
            m_hashKeys.Add("E0_53", "Special: Delete");
            m_hashKeys.Add("E0_54", "Unknown: 0xE054");
            m_hashKeys.Add("E0_55", "Unknown: 0xE055");
            m_hashKeys.Add("E0_56", "Special: < > |");
            m_hashKeys.Add("E0_57", "F-Lock: Save");
            m_hashKeys.Add("E0_58", "F-Lock: Print");
            m_hashKeys.Add("E0_59", "Unknown: 0xE059");
            m_hashKeys.Add("E0_5A", "Unknown: 0xE05A");
            m_hashKeys.Add("E0_5B", "Special: Left Windows");
            m_hashKeys.Add("E0_5C", "Special: Right Windows");
            m_hashKeys.Add("E0_5D", "Special: Application");
            m_hashKeys.Add("E0_5E", "Special: Power");
            m_hashKeys.Add("E0_5F", "Special: Sleep");

            m_hashKeys.Add("E0_60", "Unknown: 0xE060");
            m_hashKeys.Add("E0_61", "Unknown: 0xE061");
            m_hashKeys.Add("E0_62", "Unknown: 0xE062");
            m_hashKeys.Add("E0_63", "Special: Wake (or Fn)");
            m_hashKeys.Add("E0_64", "Unknown: 0xE064");
            m_hashKeys.Add("E0_65", "Web: Search");
            m_hashKeys.Add("E0_66", "Web: Favorites");
            m_hashKeys.Add("E0_67", "Web: Refresh");
            m_hashKeys.Add("E0_68", "Web: Stop");
            m_hashKeys.Add("E0_69", "Web: Forward");
            m_hashKeys.Add("E0_6A", "Web: Back");
            m_hashKeys.Add("E0_6B", "App: My Computer");
            m_hashKeys.Add("E0_6C", "App: E-Mail");
            m_hashKeys.Add("E0_6D", "App: Media Select");
            m_hashKeys.Add("E0_6E", "Unknown: 0xE06E");
            m_hashKeys.Add("E0_6F", "Unknown: 0xE06F");
            
            m_hashKeys.Add("E0_70", "Unknown: 0xE070");
            m_hashKeys.Add("E0_71", "Unknown: 0xE071");
            m_hashKeys.Add("E0_72", "Unknown: 0xE072");
            m_hashKeys.Add("E0_73", "Unknown: 0xE073");
            m_hashKeys.Add("E0_74", "Unknown: 0xE074");
            m_hashKeys.Add("E0_75", "Unknown: 0xE075");
            m_hashKeys.Add("E0_76", "Unknown: 0xE076");
            m_hashKeys.Add("E0_77", "Unknown: 0xE077");
            m_hashKeys.Add("E0_78", "Unknown: 0xE078");
            m_hashKeys.Add("E0_79", "Unknown: 0xE079");
            m_hashKeys.Add("E0_7A", "Unknown: 0xE07A");
            m_hashKeys.Add("E0_7B", "Unknown: 0xE07B");
            m_hashKeys.Add("E0_7C", "Unknown: 0xE07C");
            m_hashKeys.Add("E0_7D", "Unknown: 0xE07D");
            m_hashKeys.Add("E0_7E", "Unknown: 0xE07E");
            m_hashKeys.Add("E0_7F", "Unknown: 0xE07F");
            
            m_hashKeys.Add("E0_F1", "Special: Hanja Key");
            m_hashKeys.Add("E0_F2", "Special: Hangul Key");
        }


        // Dialog related events and overrides
        private void Dialog_Main_Load(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Set up the hashtable and load the registy settings
            BuildParseTables();
            LoadRegistrySettings();

            // UI tweaking
            if (lvKeys.Items.Count > 0)
            {
                lvKeys.Items[0].Selected = true;
            }
            Cursor = Cursors.Default;
        }

        private void Dialog_Main_Closing(object sender, CancelEventArgs e)
        {
            // if anything has been added, edit'd or delete'd, ask if a save to the registry should be performed
            if (m_bDirty)
            {
                DialogResult dlgRes = MessageBox.Show("You have made changes to the list of key mappings.\n\nDo you want to update the registry now?", "SharpKeys", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3);
                if (dlgRes == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (dlgRes == DialogResult.Yes)
                {
                    // update the registry
                    SaveMappingsToRegistry();
                }
            }
            SaveRegistrySettings();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            // save the current window position/size whenever moved
            if (WindowState == FormWindowState.Normal)
            {
                m_rcWindow = DesktopBounds;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // resize the listview columns whenever sizeds
            lvcFrom.Width = lvKeys.Width / 2 - 2;
            lvcTo.Width = lvcFrom.Width - 2;

            // save the current window position/size whenever moved
            if (WindowState == FormWindowState.Normal)
            {
                m_rcWindow = DesktopBounds;
            }
        }


        // Other Events
        private void lvKeys_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // UI stuff (to prevent editing or deleting a non-item
            if (lvKeys.SelectedItems.Count <= 0)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void mnuPop_Popup(object sender, System.EventArgs e)
        {
            // UI stuff (to prevent editing or deleting a non-item
            if (lvKeys.SelectedItems.Count <= 0)
            {
                mniEdit.Enabled = false;
                mniDelete.Enabled = false;
            }
            else
            {
                mniEdit.Enabled = true;
                mniDelete.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddMapping();
        }

        private void mniAdd_Click(object sender, System.EventArgs e)
        {
            AddMapping();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void mniEdit_Click(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void lvKeys_DoubleClick(object sender, System.EventArgs e)
        {
            EditMapping();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteMapping();
        }

        private void mniDelete_Click(object sender, System.EventArgs e)
        {
            DeleteMapping();
        }

        private void btnDeleteAll_Click(object sender, System.EventArgs e)
        {
            DeleteAllMapping();
        }

        private void mniDeleteAll_Click(object sender, System.EventArgs e)
        {
            DeleteAllMapping();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveMappingsToRegistry();
        }

        private void urlMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // open the home page
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void Dialog_Main_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Dialog_Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                           LinearGradientMode.ForwardDiagonal);

            graphics.FillRectangle(linearGradientBrush, rectangle);
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

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Rectangle topRectangle = new Rectangle(0, 0, headerPanel.Width, headerPanel.Height / 2);
            Rectangle bottomRectangle = new Rectangle(0, topRectangle.Height, headerPanel.Width, headerPanel.Height - topRectangle.Height);
            LinearGradientBrush topGradientBrush = new LinearGradientBrush(topRectangle,
                           Color.FromArgb(165, 182, 206), Color.FromArgb(37, 81, 142),
                           LinearGradientMode.Vertical);

            LinearGradientBrush bottomGradientBrush = new LinearGradientBrush(bottomRectangle,
                           Color.FromArgb(13, 37, 90), Color.FromArgb(39, 37, 160),
                           LinearGradientMode.Vertical);

            graphics.FillRectangle(topGradientBrush, topRectangle);
            graphics.FillRectangle(bottomGradientBrush, bottomRectangle);

        }
    }
}
