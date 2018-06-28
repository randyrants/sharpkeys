using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace SharpKeys
{
	/// <summary>
	/// Summary description for Dialog_Main.
	/// </summary>
	public class Dialog_Main : System.Windows.Forms.Form
	{
		private Rectangle currentWindowPosition;

		// Dirty flag (to see track if mappings have been saved)
		// if anything has been added, edit'd or delete'd, ask if a save to the registry should be performed
		private bool shouldAskToSaveMappingChangesToRegistry = false;

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
			this.saveChangesButton.Text = "&Save Changes";
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
			KeyboardMappingService keyboardMappingService = new KeyboardMappingService();

			keyboardMappingService.LoadUserStoredMappings(ref remappedKeysListView);
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

			KeyboardMappingService keyboardMappingService = new KeyboardMappingService();

			keyboardMappingService.SaveUserMappings(remappedKeysListView);

			shouldAskToSaveMappingChangesToRegistry = false;
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
			dlg.AddMapping(remappedKeysListView);
			
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				shouldAskToSaveMappingChangesToRegistry = true;

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
			dlg.EditMapping(remappedKeysListView);

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				shouldAskToSaveMappingChangesToRegistry = true;

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

			shouldAskToSaveMappingChangesToRegistry = true;
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
			shouldAskToSaveMappingChangesToRegistry = true;
			editButton.Enabled = true;
			deleteButton.Enabled = false;
			remappedKeysListView.Items.Clear();
		}
		
		// Dialog related events and overrides
		private void Dialog_Main_Load(object sender, System.EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			// Load the registy settings
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
			if (shouldAskToSaveMappingChangesToRegistry)
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
