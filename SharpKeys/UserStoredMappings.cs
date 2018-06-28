using Microsoft.Win32;

namespace SharpKeys
{
	public class UserStoredMappings
	{
		private const string KEYBOARD_MAPPING_REGISTRY_KEY_LOCATION = "System\\CurrentControlSet\\Control\\Keyboard Layout";

		private RegistryKey GetRegistryKeyReadOnlyAccess()
		{
			return Registry.LocalMachine.OpenSubKey(KEYBOARD_MAPPING_REGISTRY_KEY_LOCATION);
		}

		private RegistryKey GetRegistryKeyWriteAccess()
		{
			return Registry.LocalMachine.CreateSubKey(KEYBOARD_MAPPING_REGISTRY_KEY_LOCATION);
		}

		public byte[] GetUserStoredMappings()
		{
			RegistryKey registryKey = this.GetRegistryKeyReadOnlyAccess();

			if (registryKey == null)
				return null;

			byte[] userMappingInBytes = (byte[])registryKey.GetValue("Scancode Map");

			registryKey.Close();

			return userMappingInBytes;
		}

		public void DeleteUserMappings()
		{
			RegistryKey registryKey = this.GetRegistryKeyWriteAccess();

			if (registryKey == null)
				return;

			// the second param is required; this will throw an exception if the value isn't found,
			// and it might not always be there (which is valid), so it's ok to ignore it
			registryKey.DeleteValue("Scancode Map", false);

			registryKey.Close();
		}

		public void SetUserMappings(byte[] userRemappedKeysInBytes)
		{
			RegistryKey registryKey = this.GetRegistryKeyWriteAccess();

			if (registryKey == null)
				return;

			registryKey.SetValue("Scancode Map", userRemappedKeysInBytes);

			registryKey.Close();
		}
	}
}
