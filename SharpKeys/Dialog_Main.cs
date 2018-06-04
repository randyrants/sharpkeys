using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_Main.
    /// </summary>
    public class Dialog_Main : System.Windows.Forms.Form
    {
        // FormWindowState
        FormWindowState m_FormWindowState = FormWindowState.Normal;

        // Field for saving window position
        private Rectangle m_DesktopBounds = new Rectangle(10, 10, 750, 750);

        // Field for registy storage
        private string m_strRegKey = "Software\\RandyRants\\SharpKeys";

        // Dirty flag (to see track if mappings have been saved)
        private bool m_bDirty = false;

        int nWarning;

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
            this.lvKeys.Location = new System.Drawing.Point(14, 45);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.Size = new System.Drawing.Size(579, 282);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
            this.lvKeys.DoubleClick += new System.EventHandler(this.lvKeys_DoubleClick);
            //
            // lvcFrom
            //
            this.lvcFrom.Text = "From:";
            //
            // lvcTo
            //
            this.lvcTo.Text = "To:";
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
            this.btnSave.Location = new System.Drawing.Point(409, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Write to Registry";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(521, 339);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(14, 339);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(170, 339);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnEdit
            //
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(92, 339);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDeleteAll
            //
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(248, 339);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(72, 23);
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
            this.label11.Location = new System.Drawing.Point(9, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(588, 3);
            this.label11.TabIndex = 7;
            //
            // label1
            //
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "SharpKeys 3.6.0 - Copyright 2004 - 2018 RandyRants.com";
            //
            // label2
            //
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(15, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registry hack for remapping keys for Windows";
            //
            // urlMain
            //
            this.urlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.urlMain.AutoSize = true;
            this.urlMain.Location = new System.Drawing.Point(451, 403);
            this.urlMain.Name = "urlMain";
            this.urlMain.Size = new System.Drawing.Size(142, 13);
            this.urlMain.TabIndex = 11;
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
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(608, 430);
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
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(606, 29);
            this.headerPanel.TabIndex = 7;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
            //
            // displayProduct
            //
            this.displayProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayProduct.ForeColor = System.Drawing.Color.White;
            this.displayProduct.Location = new System.Drawing.Point(10, 2);
            this.displayProduct.Name = "displayProduct";
            this.displayProduct.Size = new System.Drawing.Size(586, 23);
            this.displayProduct.TabIndex = 1;
            this.displayProduct.Text = "SharpKeys";
            this.displayProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            //
            // urlCode
            //
            this.urlCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.urlCode.AutoSize = true;
            this.urlCode.Location = new System.Drawing.Point(386, 385);
            this.urlCode.Name = "urlCode";
            this.urlCode.Size = new System.Drawing.Size(207, 13);
            this.urlCode.TabIndex = 11;
            this.urlCode.TabStop = true;
            this.urlCode.Text = "https://github.com/randyrants/sharpkeys/";
            this.urlCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.urlCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlMain_LinkClicked);
            //
            // Dialog_Main
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 454);
            this.Controls.Add(this.mainPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
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

        #endregion Windows Form Designer generated code

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

                StringMappings.Instance.ReadRegistryBytes(bytes);

                regScanMapKey.Close();
            }
        }

        private void GetWindowState()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
            if (regKey != null)
            {
                // Load Window Pos
                m_FormWindowState = (FormWindowState)regKey.GetValue("MainWinState", (int)FormWindowState.Normal);
                m_DesktopBounds.X = (int)regKey.GetValue("MainX", 10);
                m_DesktopBounds.Y = (int)regKey.GetValue("MainY", 10);
                m_DesktopBounds.Width = (int)regKey.GetValue("MainCX", 750);
                m_DesktopBounds.Height = (int)regKey.GetValue("MainCY", 550);
                nWarning = (int)regKey.GetValue("ShowWarning", 0);
                regKey.Close();
            }
        }

        private void SetWindowState()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);
            if (regKey != null)
            {
                // Save Window Pos
                regKey.SetValue("MainWinState", (int)WindowState);
                regKey.SetValue("MainX", m_DesktopBounds.X);
                regKey.SetValue("MainY", m_DesktopBounds.Y);
                regKey.SetValue("MainCX", m_DesktopBounds.Width);
                regKey.SetValue("MainCY", m_DesktopBounds.Height);
                regKey.SetValue("ShowWarning", 1);
                regKey.Close();
            }
        }

        private void SaveMappingsToRegistry()
        {
            Cursor = Cursors.WaitCursor;

            // Open the key to save the scancodes
            RegistryKey regScanMapKey = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                byte[] registryScanCodes = StringMappings.Instance.WriteRegistryBytes();
                if (registryScanCodes.Length == 0)
                {
                    // the second param is required; this will throw an exception if the value isn't found,
                    // and it might not always be there (which is valid), so it's ok to ignore it
                    regScanMapKey.DeleteValue("Scancode Map", false);
                }
                else
                {
                    // dump to the registry
                    regScanMapKey.SetValue("Scancode Map", registryScanCodes);
                }
                regScanMapKey.Close();
            }
            m_bDirty = false;
            Cursor = Cursors.Default;

            MessageBox.Show("Key Mappings have been successfully stored to the registry.\n\nPlease logout or reboot for these changes to take effect!", "SharpKeys");
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

            foreach (var item in StringKeys.Default.Keys)
            {
                string str = item.Value.Text;
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
            foreach (var item in StringKeys.Default.Keys)
            {
                string str = item.Value.Text;
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

            // ...and then clean out the list
            m_bDirty = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
            lvKeys.Items.Clear();
        }

        // Dialog related events and overrides
        private void Dialog_Main_Load(object sender, System.EventArgs e)
        {
            // First load the window positions from registry
            GetWindowState();

            if (nWarning == 0)
            {
                MessageBox.Show("Welcome to SharpKeys!\n\nThis application will add one key to your registry that allows you\nto change how certain keys on your keyboard will work.\n\nYou must be running Windows 2000 through Windows 10 for this to be supported and\nyou'll be using SharpKeys at your own risk!\n\nEnjoy!\nRandyRants.com", "SharpKeys");
            }

            Cursor = Cursors.WaitCursor;

            // Set the WinPos
            DesktopBounds = m_DesktopBounds;
            WindowState = m_FormWindowState;

            // Set up the hashtable and load the registy settings
            LoadRegistrySettings();

            foreach (var keymap in StringMappings.Instance.Default)
            {
                ListViewItem lvI = lvKeys.Items.Add(keymap.TextFrom);
                lvI.SubItems.Add(keymap.TextTo);
            }
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

            // Only save the window position info on close; user is prompted to save mappings elsewhere
            SetWindowState();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            // save the current window position/size whenever moved
            if (WindowState == FormWindowState.Normal)
            {
                m_DesktopBounds = DesktopBounds;
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
                m_DesktopBounds = DesktopBounds;
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