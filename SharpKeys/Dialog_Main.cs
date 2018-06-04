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
        Rectangle m_DesktopBounds = new Rectangle(10, 10, 750, 750);

        // Field for registy storage
        readonly string m_strRegKey = "Software\\RandyRants\\SharpKeys";

        // Dirty flag (to see track if mappings have been saved)
        bool m_bDirty;

        int nWarning;

        System.Windows.Forms.ListView lvKeys;
        Button btnSave;
        Button btnClose;
        Button btnAdd;
        Button btnDelete;
        Button btnEdit;
        System.Windows.Forms.ColumnHeader lvcFrom;
        System.Windows.Forms.ColumnHeader lvcTo;
        Button btnDeleteAll;
        System.Windows.Forms.Label label11;
        System.Windows.Forms.Label label1;
        System.Windows.Forms.Label label2;
        System.Windows.Forms.LinkLabel urlMain;
        System.Windows.Forms.MenuItem menuItem5;
        System.Windows.Forms.MenuItem mniAdd;
        System.Windows.Forms.MenuItem mniEdit;
        System.Windows.Forms.MenuItem mniDelete;
        System.Windows.Forms.MenuItem mniDeleteAll;
        System.Windows.Forms.ContextMenu mnuPop;
        Panel mainPanel;
        Panel headerPanel;
        Label displayProduct;
        LinkLabel urlCode;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        Container components;

        public Dialog_Main() => InitializeComponent();

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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_Main));
            lvKeys = new System.Windows.Forms.ListView();
            lvcFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            lvcTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            mnuPop = new System.Windows.Forms.ContextMenu();
            mniAdd = new System.Windows.Forms.MenuItem();
            mniEdit = new System.Windows.Forms.MenuItem();
            mniDelete = new System.Windows.Forms.MenuItem();
            menuItem5 = new System.Windows.Forms.MenuItem();
            mniDeleteAll = new System.Windows.Forms.MenuItem();
            btnSave = new Button();
            btnClose = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnDeleteAll = new Button();
            label11 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            urlMain = new System.Windows.Forms.LinkLabel();
            mainPanel = new System.Windows.Forms.Panel();
            headerPanel = new System.Windows.Forms.Panel();
            displayProduct = new System.Windows.Forms.Label();
            urlCode = new System.Windows.Forms.LinkLabel();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            //
            // lvKeys
            //
            lvKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            lvcFrom,
            lvcTo});
            lvKeys.ContextMenu = mnuPop;
            lvKeys.ForeColor = System.Drawing.SystemColors.WindowText;
            lvKeys.FullRowSelect = true;
            lvKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvKeys.HideSelection = false;
            lvKeys.Location = new System.Drawing.Point(14, 45);
            lvKeys.MultiSelect = false;
            lvKeys.Name = "lvKeys";
            lvKeys.Size = new System.Drawing.Size(579, 282);
            lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lvKeys.TabIndex = 0;
            lvKeys.UseCompatibleStateImageBehavior = false;
            lvKeys.View = System.Windows.Forms.View.Details;
            lvKeys.SelectedIndexChanged += new System.EventHandler(lvKeys_SelectedIndexChanged);
            lvKeys.DoubleClick += new System.EventHandler(lvKeys_DoubleClick);
            //
            // lvcFrom
            //
            lvcFrom.Text = "From:";
            //
            // lvcTo
            //
            lvcTo.Text = "To:";
            //
            // mnuPop
            //
            mnuPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            mniAdd,
            mniEdit,
            mniDelete,
            menuItem5,
            mniDeleteAll});
            mnuPop.Popup += new System.EventHandler(mnuPop_Popup);
            //
            // mniAdd
            //
            mniAdd.Index = 0;
            mniAdd.Text = "Add";
            mniAdd.Click += new System.EventHandler(mniAdd_Click);
            //
            // mniEdit
            //
            mniEdit.Index = 1;
            mniEdit.Text = "Edit";
            mniEdit.Click += new System.EventHandler(mniEdit_Click);
            //
            // mniDelete
            //
            mniDelete.Index = 2;
            mniDelete.Text = "Delete";
            mniDelete.Click += new System.EventHandler(mniDelete_Click);
            //
            // menuItem5
            //
            menuItem5.Index = 3;
            menuItem5.Text = "-";
            //
            // mniDeleteAll
            //
            mniDeleteAll.Index = 4;
            mniDeleteAll.Text = "Delete All";
            mniDeleteAll.Click += new System.EventHandler(mniDeleteAll_Click);
            //
            // btnSave
            //
            btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnSave.Location = new System.Drawing.Point(409, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(106, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Write to Registry";
            btnSave.Click += new System.EventHandler(btnSave_Click);
            //
            // btnClose
            //
            btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnClose.Location = new System.Drawing.Point(521, 339);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(72, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "&Close";
            btnClose.Click += new System.EventHandler(btnClose_Click);
            //
            // btnAdd
            //
            btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnAdd.Location = new System.Drawing.Point(14, 339);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(72, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.Click += new System.EventHandler(btnAdd_Click);
            //
            // btnDelete
            //
            btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnDelete.Location = new System.Drawing.Point(170, 339);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(72, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "&Delete";
            btnDelete.Click += new System.EventHandler(btnDelete_Click);
            //
            // btnEdit
            //
            btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnEdit.Location = new System.Drawing.Point(92, 339);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(72, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "&Edit";
            btnEdit.Click += new System.EventHandler(btnEdit_Click);
            //
            // btnDeleteAll
            //
            btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnDeleteAll.Location = new System.Drawing.Point(248, 339);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new System.Drawing.Size(72, 23);
            btnDeleteAll.TabIndex = 4;
            btnDeleteAll.Text = "De&lete All";
            btnDeleteAll.Click += new System.EventHandler(btnDeleteAll_Click);
            //
            // label11
            //
            label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            label11.Location = new System.Drawing.Point(9, 373);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(588, 3);
            label11.TabIndex = 7;
            //
            // label1
            //
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new System.Drawing.Point(15, 385);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(283, 13);
            label1.TabIndex = 8;
            label1.Text = "SharpKeys 3.6.0 - Copyright 2004 - 2018 RandyRants.com";
            //
            // label2
            //
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new System.Drawing.Point(15, 403);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(226, 13);
            label2.TabIndex = 10;
            label2.Text = "Registry hack for remapping keys for Windows";
            //
            // urlMain
            //
            urlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            urlMain.AutoSize = true;
            urlMain.Location = new System.Drawing.Point(451, 403);
            urlMain.Name = "urlMain";
            urlMain.Size = new System.Drawing.Size(142, 13);
            urlMain.TabIndex = 11;
            urlMain.TabStop = true;
            urlMain.Text = "http://www.randyrants.com/";
            urlMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
            urlMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(urlMain_LinkClicked);
            //
            // mainPanel
            //
            mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            mainPanel.BackColor = System.Drawing.Color.Transparent;
            mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(urlCode);
            mainPanel.Controls.Add(urlMain);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(lvKeys);
            mainPanel.Controls.Add(btnAdd);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(btnEdit);
            mainPanel.Controls.Add(btnDelete);
            mainPanel.Controls.Add(label11);
            mainPanel.Controls.Add(btnDeleteAll);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(btnClose);
            mainPanel.Location = new System.Drawing.Point(12, 12);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new System.Drawing.Size(608, 430);
            mainPanel.TabIndex = 12;
            mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(mainPanel_Paint);
            //
            // headerPanel
            //
            headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            headerPanel.BackColor = System.Drawing.Color.Transparent;
            headerPanel.Controls.Add(displayProduct);
            headerPanel.Location = new System.Drawing.Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new System.Drawing.Size(606, 29);
            headerPanel.TabIndex = 7;
            headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(headerPanel_Paint);
            //
            // displayProduct
            //
            displayProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            displayProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            displayProduct.ForeColor = System.Drawing.Color.White;
            displayProduct.Location = new System.Drawing.Point(10, 2);
            displayProduct.Name = "displayProduct";
            displayProduct.Size = new System.Drawing.Size(586, 23);
            displayProduct.TabIndex = 1;
            displayProduct.Text = "SharpKeys";
            displayProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            //
            // urlCode
            //
            urlCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            urlCode.AutoSize = true;
            urlCode.Location = new System.Drawing.Point(386, 385);
            urlCode.Name = "urlCode";
            urlCode.Size = new System.Drawing.Size(207, 13);
            urlCode.TabIndex = 11;
            urlCode.TabStop = true;
            urlCode.Text = "https://github.com/randyrants/sharpkeys/";
            urlCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            urlCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(urlMain_LinkClicked);
            //
            // Dialog_Main
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(632, 454);
            Controls.Add(mainPanel);
            DoubleBuffered = true;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            MinimumSize = new System.Drawing.Size(640, 480);
            Name = "Dialog_Main";
            Text = "SharpKeys";
            Closing += new System.ComponentModel.CancelEventHandler(Dialog_Main_Closing);
            Load += new System.EventHandler(Dialog_Main_Load);
            Paint += new System.Windows.Forms.PaintEventHandler(Dialog_Main_Paint);
            Resize += new System.EventHandler(Dialog_Main_Resize);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
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

        static void LoadRegistrySettings(Dialog_Main instance)
        {
            // now load the scan code map
            var regScanMapKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                var bytes = (byte[])regScanMapKey.GetValue("Scancode Map");
                if (bytes == null)
                {
                    regScanMapKey.Close();
                    return;
                }

                StringMappings.ReadRegistryBytes(bytes);

                regScanMapKey.Close();
            }
        }

        void GetWindowState()
        {
            var regKey = Registry.CurrentUser.OpenSubKey(m_strRegKey);
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

        void SetWindowState()
        {
            var regKey = Registry.CurrentUser.CreateSubKey(m_strRegKey);
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

        void SaveMappingsToRegistry()
        {
            Cursor = Cursors.WaitCursor;

            // Open the key to save the scancodes
            var regScanMapKey = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
            if (regScanMapKey != null)
            {
                var registryScanCodes = StringMappings.WriteRegistryBytes();
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

        void AddMapping()
        {
            // max out the mapping at 104
            if (lvKeys.Items.Count >= 104)
            {
                MessageBox.Show("The maximum number of mappings SharpKeys supports is 16.\n\nPlease delete an existing mapping before adding a new one!", "SharpKeys");
                return;
            }

            // adding a new mapping, so prep the add dialog with all of the scancodes
            var dlg = new Dialog_KeyItem();

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
                var lvI = lvKeys.Items.Add(dlg.lbFrom.Text);
                lvI.SubItems.Add(dlg.lbTo.Text);
                lvI.Selected = true;
            }
            lvKeys.Focus();
        }

        void EditMapping()
        {
            // make sure something was selecting
            if (lvKeys.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select a mapping to edit!", "SharpKeys");
                return;
            }

            // built the drop down lists no matter what
            var dlg = new Dialog_KeyItem();
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

        void DeleteMapping()
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

        void DeleteAllMapping()
        {
            // Since removing all is a big step, get a confirmation
            var dlgRes = MessageBox.Show("Deleting all will clear this list of key mapping but your registry will not be updated until you click \"Write to Registry\".\n\nDo you want to clear this list of key mappings?", "SharpKeys", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
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
        void Dialog_Main_Load(object sender, EventArgs e)
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
            Dialog_Main.LoadRegistrySettings(this);

            foreach (var keymap in StringMappings.Instance.Default)
            {
                var lvI = lvKeys.Items.Add(keymap.TextFrom);
                lvI.SubItems.Add(keymap.TextTo);
            }
            // UI tweaking
            if (lvKeys.Items.Count > 0)
            {
                lvKeys.Items[0].Selected = true;
            }
            Cursor = Cursors.Default;
        }

        void Dialog_Main_Closing(object sender, CancelEventArgs e)
        {
            // if anything has been added, edit'd or delete'd, ask if a save to the registry should be performed
            if (m_bDirty)
            {
                var dlgRes = MessageBox.Show("You have made changes to the list of key mappings.\n\nDo you want to update the registry now?", "SharpKeys", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button3);
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
        void lvKeys_SelectedIndexChanged(object sender, EventArgs e)
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

        void mnuPop_Popup(object sender, EventArgs e)
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

        void btnClose_Click(object sender, EventArgs e) => Close();

        void btnAdd_Click(object sender, EventArgs e) => AddMapping();

        void mniAdd_Click(object sender, EventArgs e) => AddMapping();

        void btnEdit_Click(object sender, EventArgs e) => EditMapping();

        void mniEdit_Click(object sender, EventArgs e) => EditMapping();

        void lvKeys_DoubleClick(object sender, EventArgs e) => EditMapping();

        void btnDelete_Click(object sender, EventArgs e) => DeleteMapping();

        void mniDelete_Click(object sender, EventArgs e) => DeleteMapping();

        void btnDeleteAll_Click(object sender, EventArgs e) => DeleteAllMapping();

        void mniDeleteAll_Click(object sender, EventArgs e) => DeleteAllMapping();

        void btnSave_Click(object sender, EventArgs e) => SaveMappingsToRegistry();

        void urlMain_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) =>
            // open the home page
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);

        void Dialog_Main_Resize(object sender, EventArgs e) => Invalidate();

        void Dialog_Main_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, Width, Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(188, 188, 188), Color.FromArgb(225, 225, 225),
                           LinearGradientMode.ForwardDiagonal);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }

        void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var rectangle = new Rectangle(0, 0, mainPanel.Width, mainPanel.Height);
            var linearGradientBrush = new LinearGradientBrush(rectangle,
                           Color.FromArgb(209, 221, 228), Color.FromArgb(237, 239, 247), //Color.FromArgb(236, 241, 243),
                           LinearGradientMode.Vertical);

            graphics.FillRectangle(linearGradientBrush, rectangle);
        }

        void headerPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var topRectangle = new Rectangle(0, 0, headerPanel.Width, headerPanel.Height / 2);
            var bottomRectangle = new Rectangle(0, topRectangle.Height, headerPanel.Width, headerPanel.Height - topRectangle.Height);
            var topGradientBrush = new LinearGradientBrush(topRectangle,
                           Color.FromArgb(165, 182, 206), Color.FromArgb(37, 81, 142),
                           LinearGradientMode.Vertical);

            var bottomGradientBrush = new LinearGradientBrush(bottomRectangle,
                           Color.FromArgb(13, 37, 90), Color.FromArgb(39, 37, 160),
                           LinearGradientMode.Vertical);

            graphics.FillRectangle(topGradientBrush, topRectangle);
            graphics.FillRectangle(bottomGradientBrush, bottomRectangle);
        }
    }
}