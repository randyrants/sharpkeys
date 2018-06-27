using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

namespace SharpKeys
{
	/// <summary>
	/// Summary description for Dialog_Main.
	/// </summary>
	public class Dialog_Main : System.Windows.Forms.Form
	{
		private Rectangle currentWindowPosition;

		// Hashtable for tracking text to scan codes
		private Hashtable m_hashKeys = null;

		// Dirty flag (to see track if mappings have been saved)
		private bool m_bDirty = false;

		private System.Windows.Forms.ListView remappedKeysListView;
		private System.Windows.Forms.Button saveChangesButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.ColumnHeader remappedFromKeyListView;
		private System.Windows.Forms.ColumnHeader remappedToKeyListView;
		private System.Windows.Forms.Button deleteAllButton;
		private System.Windows.Forms.Label lineDivisor;
		private System.Windows.Forms.Label legalShortInformation;
		private System.Windows.Forms.Label softwareShortDescription;
		private System.Windows.Forms.LinkLabel mainWebsite;
		private System.Windows.Forms.MenuItem contextMenuLineDivisor;
		private System.Windows.Forms.MenuItem contextMenuAddOption;
		private System.Windows.Forms.MenuItem contextMenuEditOption;
		private System.Windows.Forms.MenuItem contextMenuDeleteOption;
		private System.Windows.Forms.MenuItem contextMenuDeleteAllOption;
		private System.Windows.Forms.ContextMenu contextMenu;
		private Panel mainPanel;
		private Panel headerPanel;
		private Label displayProductName;
		private LinkLabel contributeUrlLink;
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
			this.remappedKeysListView = new System.Windows.Forms.ListView();
			this.remappedFromKeyListView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.remappedToKeyListView = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.contextMenuAddOption = new System.Windows.Forms.MenuItem();
			this.contextMenuEditOption = new System.Windows.Forms.MenuItem();
			this.contextMenuDeleteOption = new System.Windows.Forms.MenuItem();
			this.contextMenuLineDivisor = new System.Windows.Forms.MenuItem();
			this.contextMenuDeleteAllOption = new System.Windows.Forms.MenuItem();
			this.saveChangesButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.deleteAllButton = new System.Windows.Forms.Button();
			this.lineDivisor = new System.Windows.Forms.Label();
			this.legalShortInformation = new System.Windows.Forms.Label();
			this.softwareShortDescription = new System.Windows.Forms.Label();
			this.mainWebsite = new System.Windows.Forms.LinkLabel();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.displayProductName = new System.Windows.Forms.Label();
			this.contributeUrlLink = new System.Windows.Forms.LinkLabel();
			this.mainPanel.SuspendLayout();
			this.headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// remappedKeysListView
			// 
			this.remappedKeysListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.remappedKeysListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] 
			{
				this.remappedFromKeyListView,
				this.remappedToKeyListView
			});
			this.remappedKeysListView.ContextMenu = this.contextMenu;
			this.remappedKeysListView.ForeColor = System.Drawing.SystemColors.WindowText;
			this.remappedKeysListView.FullRowSelect = true;
			this.remappedKeysListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.remappedKeysListView.HideSelection = false;
			this.remappedKeysListView.Location = new System.Drawing.Point(14, 45);
			this.remappedKeysListView.MultiSelect = false;
			this.remappedKeysListView.Name = "remappedKeysListView";
			this.remappedKeysListView.Size = new System.Drawing.Size(579, 282);
			this.remappedKeysListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.remappedKeysListView.TabIndex = 0;
			this.remappedKeysListView.UseCompatibleStateImageBehavior = false;
			this.remappedKeysListView.View = System.Windows.Forms.View.Details;
			this.remappedKeysListView.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
			this.remappedKeysListView.DoubleClick += new System.EventHandler(this.lvKeys_DoubleClick);
			// 
			// remappedFromKeyListView
			// 
			this.remappedFromKeyListView.Text = "From:";
			// 
			// remappedToKeyListView
			// 
			this.remappedToKeyListView.Text = "To:";
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] 
			{
				this.contextMenuAddOption,
				this.contextMenuEditOption,
				this.contextMenuDeleteOption,
				this.contextMenuLineDivisor,
				this.contextMenuDeleteAllOption
			});
			this.contextMenu.Popup += new System.EventHandler(this.mnuPop_Popup);
			// 
			// contextMenuAddOption
			// 
			this.contextMenuAddOption.Index = 0;
			this.contextMenuAddOption.Text = "Add";
			this.contextMenuAddOption.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// contextMenuEditOption
			// 
			this.contextMenuEditOption.Index = 1;
			this.contextMenuEditOption.Text = "Edit";
			this.contextMenuEditOption.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// contextMenuDeleteOption
			// 
			this.contextMenuDeleteOption.Index = 2;
			this.contextMenuDeleteOption.Text = "Delete";
			this.contextMenuDeleteOption.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// contextMenuLineDivisor
			// 
			this.contextMenuLineDivisor.Index = 3;
			this.contextMenuLineDivisor.Text = "-";
			// 
			// contextMenuDeleteAllOption
			// 
			this.contextMenuDeleteAllOption.Index = 4;
			this.contextMenuDeleteAllOption.Text = "Delete All";
			this.contextMenuDeleteAllOption.Click += new System.EventHandler(this.mniDeleteAll_Click);
			// 
			// saveChangesButton
			// 
			this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveChangesButton.Location = new System.Drawing.Point(409, 339);
			this.saveChangesButton.Name = "saveChangesButton";
			this.saveChangesButton.Size = new System.Drawing.Size(106, 23);
			this.saveChangesButton.TabIndex = 5;
			this.saveChangesButton.Text = "&Write to Registry";
			this.saveChangesButton.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.Location = new System.Drawing.Point(521, 339);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(72, 23);
			this.closeButton.TabIndex = 6;
			this.closeButton.Text = "&Close";
			this.closeButton.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.Location = new System.Drawing.Point(14, 339);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(72, 23);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "&Add";
			this.addButton.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.Location = new System.Drawing.Point(170, 339);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(72, 23);
			this.deleteButton.TabIndex = 3;
			this.deleteButton.Text = "&Delete";
			this.deleteButton.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editButton.Location = new System.Drawing.Point(92, 339);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(72, 23);
			this.editButton.TabIndex = 2;
			this.editButton.Text = "&Edit";
			this.editButton.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// deleteAllButton
			// 
			this.deleteAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteAllButton.Location = new System.Drawing.Point(248, 339);
			this.deleteAllButton.Name = "deleteAllButton";
			this.deleteAllButton.Size = new System.Drawing.Size(72, 23);
			this.deleteAllButton.TabIndex = 4;
			this.deleteAllButton.Text = "De&lete All";
			this.deleteAllButton.Click += new System.EventHandler(this.btnDeleteAll_Click);
			// 
			// lineDivisor
			// 
			this.lineDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lineDivisor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lineDivisor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lineDivisor.Location = new System.Drawing.Point(9, 373);
			this.lineDivisor.Name = "lineDivisor";
			this.lineDivisor.Size = new System.Drawing.Size(588, 3);
			this.lineDivisor.TabIndex = 7;
			// 
			// legalShortInformation
			// 
			this.legalShortInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.legalShortInformation.AutoSize = true;
			this.legalShortInformation.Enabled = false;
			this.legalShortInformation.Location = new System.Drawing.Point(15, 385);
			this.legalShortInformation.Name = "legalShortInformation";
			this.legalShortInformation.Size = new System.Drawing.Size(283, 13);
			this.legalShortInformation.TabIndex = 8;
			this.legalShortInformation.Text = "SharpKeys 3.6.0 - Copyright 2004 - 2018 RandyRants.com";
			// 
			// softwareShortDescription
			// 
			this.softwareShortDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.softwareShortDescription.AutoSize = true;
			this.softwareShortDescription.Enabled = false;
			this.softwareShortDescription.Location = new System.Drawing.Point(15, 403);
			this.softwareShortDescription.Name = "softwareShortDescription";
			this.softwareShortDescription.Size = new System.Drawing.Size(226, 13);
			this.softwareShortDescription.TabIndex = 10;
			this.softwareShortDescription.Text = "Registry hack for remapping keys for Windows";
			// 
			// mainWebsite
			// 
			this.mainWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.mainWebsite.AutoSize = true;
			this.mainWebsite.Location = new System.Drawing.Point(451, 403);
			this.mainWebsite.Name = "mainWebsite";
			this.mainWebsite.Size = new System.Drawing.Size(142, 13);
			this.mainWebsite.TabIndex = 11;
			this.mainWebsite.TabStop = true;
			this.mainWebsite.Text = "http://www.randyrants.com/";
			this.mainWebsite.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.mainWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlMain_LinkClicked);
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.BackColor = System.Drawing.Color.Transparent;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.headerPanel);
			this.mainPanel.Controls.Add(this.contributeUrlLink);
			this.mainPanel.Controls.Add(this.mainWebsite);
			this.mainPanel.Controls.Add(this.softwareShortDescription);
			this.mainPanel.Controls.Add(this.remappedKeysListView);
			this.mainPanel.Controls.Add(this.addButton);
			this.mainPanel.Controls.Add(this.legalShortInformation);
			this.mainPanel.Controls.Add(this.editButton);
			this.mainPanel.Controls.Add(this.deleteButton);
			this.mainPanel.Controls.Add(this.lineDivisor);
			this.mainPanel.Controls.Add(this.deleteAllButton);
			this.mainPanel.Controls.Add(this.saveChangesButton);
			this.mainPanel.Controls.Add(this.closeButton);
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
			this.headerPanel.Controls.Add(this.displayProductName);
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(606, 29);
			this.headerPanel.TabIndex = 7;
			this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel_Paint);
			// 
			// displayProductName
			// 
			this.displayProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.displayProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayProductName.ForeColor = System.Drawing.Color.White;
			this.displayProductName.Location = new System.Drawing.Point(10, 2);
			this.displayProductName.Name = "displayProductName";
			this.displayProductName.Size = new System.Drawing.Size(586, 23);
			this.displayProductName.TabIndex = 1;
			this.displayProductName.Text = "SharpKeys";
			this.displayProductName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// contributeUrlLink
			// 
			this.contributeUrlLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.contributeUrlLink.AutoSize = true;
			this.contributeUrlLink.Location = new System.Drawing.Point(386, 385);
			this.contributeUrlLink.Name = "contributeUrlLink";
			this.contributeUrlLink.Size = new System.Drawing.Size(207, 13);
			this.contributeUrlLink.TabIndex = 11;
			this.contributeUrlLink.TabStop = true;
			this.contributeUrlLink.Text = "https://github.com/randyrants/sharpkeys/";
			this.contributeUrlLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.contributeUrlLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlMain_LinkClicked);
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
			SoftwareProperties softwareProperties = new SoftwareProperties();

			currentWindowPosition = softwareProperties.LoadWindowPosition();
			DesktopBounds = currentWindowPosition;
			WindowState = softwareProperties.LoadWindowState();

			if (softwareProperties.ShowFirstUsageWarning() == true)
			{
				MessageBox.Show("Welcome to SharpKeys!\n\nThis application will add one key to your registry that allows you\nto change how certain keys on your keyboard will work.\n\nYou must be running Windows 2000 through Windows 10 for this to be supported and\nyou'll be using SharpKeys at your own risk!\n\nEnjoy!\nRandyRants.com", "SharpKeys");
			}
						

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

						ListViewItem lvI = remappedKeysListView.Items.Add(strFrom);
						lvI.SubItems.Add(strTo);
					}
				}

				regScanMapKey.Close();
			}
		}

		private void SaveRegistrySettings()
		{
			// Only save the window position info on close; user is prompted to save mappings elsewhere
			SoftwareProperties softwareProperties = new SoftwareProperties();

			softwareProperties.SaveWindowState(WindowState);
			softwareProperties.SaveWindowPosition(currentWindowPosition);
			softwareProperties.DisableFirstUsageWarning();
		}

		private void SaveMappingsToRegistry()
		{
			Cursor = Cursors.WaitCursor;

			// Open the key to save the scancodes
			RegistryKey regScanMapKey = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout");
			if (regScanMapKey != null)
			{
				int nCount = remappedKeysListView.Items.Count;
				if (nCount <= 0)
				{
					// the second param is required; this will throw an exception if the value isn't found,
					// and it might not always be there (which is valid), so it's ok to ignore it
					regScanMapKey.DeleteValue("Scancode Map", false);
				}
				else
				{
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
						String str = remappedKeysListView.Items[i].SubItems[1].Text; //Example: (E0_0020)
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

						str = remappedKeysListView.Items[i].Text; //Example: (E0_0020)
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

					// dump to the registry
					regScanMapKey.SetValue("Scancode Map", bytes);
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
			if (remappedKeysListView.Items.Count >= 104)
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
				dlg.mapFromKeyListView.Items.Add(str);
				dlg.mapToKeyListView.Items.Add(str);
			}

			// remove the null setting for "From" since you can never have a null key to map
			int nPos = 0;
			nPos = dlg.mapFromKeyListView.FindString("-- Turn Key Off (00_00)");
			if (nPos > -1)
				dlg.mapFromKeyListView.Items.RemoveAt(nPos);

			// Now remove any of the keys that have already been mapped in the list (can't double up on from's)
			for (int i = 0; i < remappedKeysListView.Items.Count; i++)
			{
				nPos = dlg.mapFromKeyListView.FindString(remappedKeysListView.Items[i].Text);
				if (nPos > -1)
					dlg.mapFromKeyListView.Items.RemoveAt(nPos);
			}

			// let C# sort the lists
			dlg.mapFromKeyListView.Sorted = true;
			dlg.mapToKeyListView.Sorted = true;

			// UI stuff
			dlg.Text = "SharpKeys: Add New Key Mapping";
			dlg.mapFromKeyListView.SelectedIndex = 0;
			dlg.mapToKeyListView.SelectedIndex = 0;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_bDirty = true;

				// Add the list, as it's past inspection.
				ListViewItem lvI = remappedKeysListView.Items.Add(dlg.mapFromKeyListView.Text);
				lvI.SubItems.Add(dlg.mapToKeyListView.Text);
				lvI.Selected = true;
			}
			remappedKeysListView.Focus();
		}
		private void EditMapping()
		{
			// make sure something was selecting
			if (remappedKeysListView.SelectedItems.Count <= 0)
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
				dlg.mapFromKeyListView.Items.Add(str);
				dlg.mapToKeyListView.Items.Add(str);
			}

			// remove the null setting for "From" since you can never have a null key to map
			int nPos = 0;
			nPos = dlg.mapFromKeyListView.FindString("-- Turn Key Off (00_00)");
			if (nPos > -1)
				dlg.mapFromKeyListView.Items.RemoveAt(nPos);

			// remove any of the existing from key mappings however, leave in the one that has currently
			// been selected!
			for (int i = 0; i < remappedKeysListView.Items.Count; i++)
			{
				nPos = dlg.mapFromKeyListView.FindString(remappedKeysListView.Items[i].Text);
				if ((nPos > -1) && (remappedKeysListView.Items[i].Text != remappedKeysListView.SelectedItems[0].Text))
				{
					dlg.mapFromKeyListView.Items.RemoveAt(nPos);
				}
			}

			// Let C# sort the lists
			dlg.mapFromKeyListView.Sorted = true;
			dlg.mapToKeyListView.Sorted = true;

			// as it's an edit, set the drop down lists to the current From value
			nPos = dlg.mapFromKeyListView.FindString(remappedKeysListView.SelectedItems[0].Text);
			if (nPos > -1)
				dlg.mapFromKeyListView.SelectedIndex = nPos;
			else
				dlg.mapFromKeyListView.SelectedIndex = 0;

			// as it's an edit, set the drop down lists to the current To value
			nPos = dlg.mapToKeyListView.FindString(remappedKeysListView.SelectedItems[0].SubItems[1].Text);
			if (nPos > -1)
				dlg.mapToKeyListView.SelectedIndex = nPos;
			else
				dlg.mapToKeyListView.SelectedIndex = 0;

			dlg.Text = "SharpKeys: Edit Key Mapping";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_bDirty = true;

				// update the select mapping item in the list view
				remappedKeysListView.SelectedItems[0].Text = dlg.mapFromKeyListView.Text;
				remappedKeysListView.SelectedItems[0].SubItems[1].Text = dlg.mapToKeyListView.Text;
			}
			remappedKeysListView.Focus();
		}

		private void DeleteMapping()
		{
			// Pop a mapping out of the list view
			if (remappedKeysListView.SelectedItems.Count <= 0)
			{
				MessageBox.Show("Please select a mapping to remove!", "SharpKeys");
				return;
			}

			remappedKeysListView.Items.Remove(remappedKeysListView.SelectedItems[0]);

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
			editButton.Enabled = true;
			deleteButton.Enabled = false;
			remappedKeysListView.Items.Clear();
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
			m_hashKeys.Add("00_67", "Function: F16"); // Mac keyboard
			m_hashKeys.Add("00_68", "Function: F17"); // Mac keyboard
			m_hashKeys.Add("00_69", "Function: F18"); // Mac keyboard
			m_hashKeys.Add("00_6A", "Function: F19"); // Mac keyboard
			m_hashKeys.Add("00_6B", "Function: F20"); // IBM Model F 122-keys
			m_hashKeys.Add("00_6C", "Function: F21"); // IBM Model F 122-keys
			m_hashKeys.Add("00_6D", "Function: F22"); // IBM Model F 122-keys
			m_hashKeys.Add("00_6E", "Function: F23"); // IBM Model F 122-keys
			m_hashKeys.Add("00_6F", "Function: F24"); // IBM Model F 122-keys

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
			m_hashKeys.Add("E0_07", "F-Lock: Redo");        //   F3 - Redo
			m_hashKeys.Add("E0_08", "F-Lock: Undo"); //   F2 - Undo
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
			m_hashKeys.Add("E0_23", "F-Lock: Spell");       //   F10
			m_hashKeys.Add("E0_24", "Media: Stop");
			m_hashKeys.Add("E0_25", "Unknown: 0xE025");
			m_hashKeys.Add("E0_26", "Unknown: 0xE026");
			m_hashKeys.Add("E0_27", "Unknown: 0xE027");
			m_hashKeys.Add("E0_28", "Unknown: 0xE028");
			m_hashKeys.Add("E0_29", "Unknown: 0xE029");
			// m_hashKeys.Add("E0_2A", "Special: PrtSc");   // removed due to conflict
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
			m_hashKeys.Add("E0_3B", "F-Lock: Help");        //   F1
			m_hashKeys.Add("E0_3C", "F-Lock: Office Home"); //   F2 - Office Home
			m_hashKeys.Add("E0_3D", "F-Lock: Task Pane");   //   F3 - Task pane
			m_hashKeys.Add("E0_3E", "F-Lock: New");         //   F4
			m_hashKeys.Add("E0_3F", "F-Lock: Open");        //   F5

			m_hashKeys.Add("E0_40", "F-Lock: Close");       //   F6
			m_hashKeys.Add("E0_41", "F-Lock: Reply");       //   F7
			m_hashKeys.Add("E0_42", "F-Lock: Fwd");         //   F8
			m_hashKeys.Add("E0_43", "F-Lock: Send");        //   F9
			m_hashKeys.Add("E0_44", "Unknown: 0xE044");
			m_hashKeys.Add("E0_45", "Special: €");        //   Euro
			m_hashKeys.Add("E0_46", "Unknown: 0xE046");
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
			m_hashKeys.Add("E0_57", "F-Lock: Save");        //   F11
			m_hashKeys.Add("E0_58", "F-Lock: Print");       //   F12
			m_hashKeys.Add("E0_59", "Unknown: 0xE059");
			m_hashKeys.Add("E0_5A", "Unknown: 0xE05A");
			m_hashKeys.Add("E0_5B", "Special: Left Windows");
			m_hashKeys.Add("E0_5C", "Special: Right Windows");
			m_hashKeys.Add("E0_5D", "Special: Application");
			m_hashKeys.Add("E0_5E", "Special: Power");
			m_hashKeys.Add("E0_5F", "Special: Sleep");

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
		}


		// Dialog related events and overrides
		private void Dialog_Main_Load(object sender, System.EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			// Set up the hashtable and load the registy settings
			BuildParseTables();
			LoadRegistrySettings();

			// UI tweaking
			if (remappedKeysListView.Items.Count > 0)
			{
				remappedKeysListView.Items[0].Selected = true;
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
				currentWindowPosition = DesktopBounds;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			// resize the listview columns whenever sizeds
			remappedFromKeyListView.Width = remappedKeysListView.Width / 2 - 2;
			remappedToKeyListView.Width = remappedFromKeyListView.Width - 2;

			// save the current window position/size whenever moved
			if (WindowState == FormWindowState.Normal)
			{
				currentWindowPosition = DesktopBounds;
			}
		}


		// Other Events
		private void lvKeys_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// UI stuff (to prevent editing or deleting a non-item
			if (remappedKeysListView.SelectedItems.Count <= 0)
			{
				editButton.Enabled = false;
				deleteButton.Enabled = false;
			}
			else
			{
				editButton.Enabled = true;
				deleteButton.Enabled = true;
			}
		}

		private void mnuPop_Popup(object sender, System.EventArgs e)
		{
			// UI stuff (to prevent editing or deleting a non-item
			if (remappedKeysListView.SelectedItems.Count <= 0)
			{
				contextMenuEditOption.Enabled = false;
				contextMenuDeleteOption.Enabled = false;
			}
			else
			{
				contextMenuEditOption.Enabled = true;
				contextMenuDeleteOption.Enabled = true;
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
