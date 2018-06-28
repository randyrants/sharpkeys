
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace SharpKeys
{
	public class SoftwareProperties
	{
		private const string SOFTWARE_REGISTRY_KEY_LOCATION = "Software\\RandyRants\\SharpKeys";
		private readonly Rectangle defaultWindowPosition = new Rectangle(10, 10, 750, 550);

		private RegistryKey GetRegistryKeyReadOnlyAccess()
		{
			return Registry.CurrentUser.OpenSubKey(SOFTWARE_REGISTRY_KEY_LOCATION);
		}

		private RegistryKey GetRegistryKeyWriteAccess()
		{
			return Registry.CurrentUser.CreateSubKey(SOFTWARE_REGISTRY_KEY_LOCATION);
		}

		public Rectangle LoadWindowPosition()
		{
			RegistryKey registryKey = this.GetRegistryKeyReadOnlyAccess();

			if (registryKey == null)
			{
				return defaultWindowPosition;
			}
				

			int x = (int)registryKey.GetValue("MainX", 10);
			int y = (int)registryKey.GetValue("MainY", 10);
			int width = (int)registryKey.GetValue("MainCX", 750);
			int height = (int)registryKey.GetValue("MainCY", 550);

			registryKey.Close();

			return new Rectangle(x, y, width, height);
		}

		public void SaveWindowPosition(Rectangle currentWindowPosition)
		{
			RegistryKey registryKey = this.GetRegistryKeyWriteAccess();

			registryKey.SetValue("MainX", currentWindowPosition.X);
			registryKey.SetValue("MainY", currentWindowPosition.Y);
			registryKey.SetValue("MainCX", currentWindowPosition.Width);
			registryKey.SetValue("MainCY", currentWindowPosition.Height);

			registryKey.Close();
		}

		public FormWindowState LoadWindowState()
		{
			RegistryKey registryKey = this.GetRegistryKeyReadOnlyAccess();

			if (registryKey == null)
			{
				return FormWindowState.Normal;
			}

			FormWindowState windowState = (FormWindowState)registryKey.GetValue("MainWinState", FormWindowState.Normal);

			registryKey.Close();

			return windowState;
		}

		public void SaveWindowState(FormWindowState currentWindowState)
		{
			RegistryKey registryKey = this.GetRegistryKeyWriteAccess();

			registryKey.SetValue("MainWinState", (int)currentWindowState);

			registryKey.Close();
		}

		public void DisableFirstUsageWarning()
		{
			RegistryKey registryKey = this.GetRegistryKeyWriteAccess();

			registryKey.SetValue("ShowWarning", 1);

			registryKey.Close();
		}

		public bool ShowFirstUsageWarning()
		{
			RegistryKey registryKey = this.GetRegistryKeyReadOnlyAccess();

			if (registryKey == null)
			{
				return true;
			}

			int showWarning = (int)registryKey.GetValue("ShowWarning", 0);

			registryKey.Close();

			return showWarning == 0 ? true : false;
		}
	}
}
