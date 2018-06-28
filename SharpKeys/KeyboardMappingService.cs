using System;
using System.Collections;
using System.Windows.Forms;

namespace SharpKeys
{
	public class KeyboardMappingService
	{
		private UserStoredMappings userStoredMappings = new UserStoredMappings();

		private const int MAPPINGS_COUNT_POSITION = 8; // the 9th byte is ALWAYS the total number of mappings (including the trailing null pointer)
		private const string REG_BINARY_SEPARATOR = "_";
		private const string KEY_CODE_CONTAINER_BEGINNING_CHARACTER = "(";
		private const string KEY_CODE_CONTAINER_ENDING_CHARACTER = ")";
				
		private bool UserHasStoredMappings(byte[] bytes)
		{
			return bytes != null && bytes.Length > 8; // can skip the first 8 bytes as they are ALWAYS 0x00
		}

		private int GetTotalUserMappings(byte[] bytes)
		{
			return Int32.Parse(bytes[MAPPINGS_COUNT_POSITION].ToString());
		}

		private string GetOriginalKeyCode(byte[] bytes, int currentPosition)
		{
			// scan codes are stored in ToHi ToLo FromHi FromLo
			string originalKeyCode = string.Format("{0,2:X}_{1,2:X}", bytes[(currentPosition * 4) + 12 + 3], bytes[(currentPosition * 4) + 12 + 2]);
			return originalKeyCode.Replace(" ", "0");
		}

		private string GetReplacementKeyCode(byte[] bytes, int currentPosition)
		{
			// scan codes are stored in ToHi ToLo FromHi FromLo
			string replacementKeyCode = string.Format("{0,2:X}_{1,2:X}", bytes[(currentPosition * 4) + 12 + 1], bytes[(currentPosition * 4) + 12 + 0]);
			return replacementKeyCode.Replace(" ", "0");
		}
		
		private string GetRegSubstring(string fullKeyCodeText)
		{
			return fullKeyCodeText.Substring(fullKeyCodeText.LastIndexOf(KEY_CODE_CONTAINER_BEGINNING_CHARACTER) + 1, 2); //Example: E0
		}

		private string GetBinarySubstring(string fullKeyCodeText)
		{
			int binaryStartIndex = fullKeyCodeText.LastIndexOf(REG_BINARY_SEPARATOR) + 1;
			int binaryLength = fullKeyCodeText.LastIndexOf(KEY_CODE_CONTAINER_ENDING_CHARACTER) - fullKeyCodeText.LastIndexOf(REG_BINARY_SEPARATOR) - 1;

			string binarySubstring = fullKeyCodeText.Substring(binaryStartIndex, binaryLength); //Example: 0020

			if (binarySubstring.Length > 2)
			{
				binarySubstring = binarySubstring.Substring(2);
			}

			return binarySubstring;
		}
		
		public void LoadUserStoredMappings(ref ListView userStoredMappingsList)
		{
			byte[] userMappingInBytes = userStoredMappings.GetUserStoredMappings();
			
			if (this.UserHasStoredMappings(userMappingInBytes) == true)
			{
				Hashtable keyboardScanCodeMap = this.GetFullMapping();

				int totalUserMappings = new KeyboardMappingService().GetTotalUserMappings(userMappingInBytes);
				for (int i = 0; i < totalUserMappings - 1; i++)
				{
					string originalKeyCode = new KeyboardMappingService().GetOriginalKeyCode(userMappingInBytes, i);
					string originalKeyListItem = $"{(string)keyboardScanCodeMap[originalKeyCode]} ({originalKeyCode})";

					string replacementKeyCode = new KeyboardMappingService().GetReplacementKeyCode(userMappingInBytes, i);
					string replacementKeyListItem = $"{(string)keyboardScanCodeMap[replacementKeyCode]} ({replacementKeyCode})";

					ListViewItem userStoredMappingsItems = userStoredMappingsList.Items.Add(originalKeyListItem);
					userStoredMappingsItems.SubItems.Add(replacementKeyListItem);
				}
			}
		}

		public void SaveUserMappings(ListView userRemappedKeys)
		{
			int totalUserMappings = userRemappedKeys.Items.Count;
			if (totalUserMappings <= 0)
			{
				userStoredMappings.DeleteUserMappings();
				return;
			}

			// create a new byte array that is:
			//   8 bytes that are always 00 00 00 00 00 00 00 00 (as is required)
			// + 4 bytes that are used for the count nn 00 00 00 (as is required)
			// + 4 bytes per mapping
			// + 4 bytes for the last mapping (required)
			byte[] userRemappedKeysInBytes = new byte[8 + 4 + (4 * totalUserMappings) + 4];

			// skip first 8 (0-7)

			// set 8 to the count, plus the trailing null
			userRemappedKeysInBytes[MAPPINGS_COUNT_POSITION] = Convert.ToByte(totalUserMappings + 1);

			// skip 9, 10, 11

			// add up the list
			for (int i = 0; i < totalUserMappings; i++)
			{
				string fullKeyCode = userRemappedKeys.Items[i].SubItems[1].Text; //Example: (E0_0020)
				string reg = this.GetRegSubstring(fullKeyCode); //Example: E0
				string binary = this.GetBinarySubstring(fullKeyCode); //Example: 0020

				userRemappedKeysInBytes[(i * 4) + 12 + 0] = Convert.ToByte(binary, 16);
				userRemappedKeysInBytes[(i * 4) + 12 + 1] = Convert.ToByte(reg, 16);
				
				fullKeyCode = userRemappedKeys.Items[i].Text; //Example: (E0_0020)
				reg = this.GetRegSubstring(fullKeyCode); //Example: E0
				binary = this.GetBinarySubstring(fullKeyCode); //Example: 0020

				userRemappedKeysInBytes[(i * 4) + 12 + 2] = Convert.ToByte(binary, 16);
				userRemappedKeysInBytes[(i * 4) + 12 + 3] = Convert.ToByte(reg, 16);
			}
			// last 4 are 0's

			userStoredMappings.SetUserMappings(userRemappedKeysInBytes);
		}
		
		public bool ShowDelKeyWarning(string keycode)
		{
			// Main Delete or Numpad Del
			return keycode == "E0_53" || keycode == "00_53";
		}

		public Hashtable GetFullMapping()
		{

			// the hash table uses a string in the form of Hi_Lo scan code (in Hex values) 
			// that most sources say are scan codes.  
			// 
			// The 00_00 will disable a key - everything else is pretty obvious.  
			// 
			// There is a bit of a reverse lookup however, so labels changed here
			// need to be changed in a couple of other places
			// Example: "00_00", "-- Turn Key Off"

			Hashtable hashtable = new Hashtable();

			hashtable.Add("00_00", "-- Turn Key Off");
			hashtable.Add("00_01", "Special: Escape");
			hashtable.Add("00_02", "Key: 1 !");
			hashtable.Add("00_03", "Key: 2 @");
			hashtable.Add("00_04", "Key: 3 #");
			hashtable.Add("00_05", "Key: 4 $");
			hashtable.Add("00_06", "Key: 5 %");
			hashtable.Add("00_07", "Key: 6 ^");
			hashtable.Add("00_08", "Key: 7 &");
			hashtable.Add("00_09", "Key: 8 *");
			hashtable.Add("00_0A", "Key: 9 (");
			hashtable.Add("00_0B", "Key: 0 )");
			hashtable.Add("00_0C", "Key: - _");
			hashtable.Add("00_0D", "Key: = +");
			hashtable.Add("00_0E", "Special: Backspace");
			hashtable.Add("00_0F", "Special: Tab");

			hashtable.Add("00_10", "Key: Q");
			hashtable.Add("00_11", "Key: W");
			hashtable.Add("00_12", "Key: E");
			hashtable.Add("00_13", "Key: R");
			hashtable.Add("00_14", "Key: T");
			hashtable.Add("00_15", "Key: Y");
			hashtable.Add("00_16", "Key: U");
			hashtable.Add("00_17", "Key: I");
			hashtable.Add("00_18", "Key: O");
			hashtable.Add("00_19", "Key: P");
			hashtable.Add("00_1A", "Key: [ {");
			hashtable.Add("00_1B", "Key: ] }");
			hashtable.Add("00_1C", "Special: Enter");
			hashtable.Add("00_1D", "Special: Left Ctrl");
			hashtable.Add("00_1E", "Key: A");
			hashtable.Add("00_1F", "Key: S");

			hashtable.Add("00_20", "Key: D");
			hashtable.Add("00_21", "Key: F");
			hashtable.Add("00_22", "Key: G");
			hashtable.Add("00_23", "Key: H");
			hashtable.Add("00_24", "Key: J");
			hashtable.Add("00_25", "Key: K");
			hashtable.Add("00_26", "Key: L");
			hashtable.Add("00_27", "Key: ; :");
			hashtable.Add("00_28", "Key: ' \"");
			hashtable.Add("00_29", "Key: ` ~");
			hashtable.Add("00_2A", "Special: Left Shift");
			hashtable.Add("00_2B", "Key: \\ |");
			hashtable.Add("00_2C", "Key: Z");
			hashtable.Add("00_2D", "Key: X");
			hashtable.Add("00_2E", "Key: C");
			hashtable.Add("00_2F", "Key: V");

			hashtable.Add("00_30", "Key: B");
			hashtable.Add("00_31", "Key: N");
			hashtable.Add("00_32", "Key: M");
			hashtable.Add("00_33", "Key: , <");
			hashtable.Add("00_34", "Key: . >");
			hashtable.Add("00_35", "Key: / ?");
			hashtable.Add("00_36", "Special: Right Shift");
			hashtable.Add("00_37", "Num: *");
			hashtable.Add("00_38", "Special: Left Alt");
			hashtable.Add("00_39", "Special: Space");
			hashtable.Add("00_3A", "Special: Caps Lock");
			hashtable.Add("00_3B", "Function: F1");
			hashtable.Add("00_3C", "Function: F2");
			hashtable.Add("00_3D", "Function: F3");
			hashtable.Add("00_3E", "Function: F4");
			hashtable.Add("00_3F", "Function: F5");

			hashtable.Add("00_40", "Function: F6");
			hashtable.Add("00_41", "Function: F7");
			hashtable.Add("00_42", "Function: F8");
			hashtable.Add("00_43", "Function: F9");
			hashtable.Add("00_44", "Function: F10");
			hashtable.Add("00_45", "Special: Num Lock");
			hashtable.Add("00_46", "Special: Scroll Lock");
			hashtable.Add("00_47", "Num: 7");
			hashtable.Add("00_48", "Num: 8");
			hashtable.Add("00_49", "Num: 9");
			hashtable.Add("00_4A", "Num: -");
			hashtable.Add("00_4B", "Num: 4");
			hashtable.Add("00_4C", "Num: 5");
			hashtable.Add("00_4D", "Num: 6");
			hashtable.Add("00_4E", "Num: +");
			hashtable.Add("00_4F", "Num: 1");

			hashtable.Add("00_50", "Num: 2");
			hashtable.Add("00_51", "Num: 3");
			hashtable.Add("00_52", "Num: 0");
			hashtable.Add("00_53", "Num: .");
			hashtable.Add("00_54", "Unknown: 0x0054");
			hashtable.Add("00_55", "Unknown: 0x0055");
			hashtable.Add("00_56", "Special: ISO extra key");
			hashtable.Add("00_57", "Function: F11");
			hashtable.Add("00_58", "Function: F12");
			hashtable.Add("00_59", "Unknown: 0x0059");
			hashtable.Add("00_5A", "Unknown: 0x005A");
			hashtable.Add("00_5B", "Unknown: 0x005B");
			hashtable.Add("00_5C", "Unknown: 0x005C");
			hashtable.Add("00_5D", "Unknown: 0x005D");
			hashtable.Add("00_5E", "Unknown: 0x005E");
			hashtable.Add("00_5F", "Unknown: 0x005F");

			hashtable.Add("00_60", "Unknown: 0x0060");
			hashtable.Add("00_61", "Unknown: 0x0061");
			hashtable.Add("00_62", "Unknown: 0x0062");
			hashtable.Add("00_63", "Unknown: 0x0063");
			hashtable.Add("00_64", "Function: F13");
			hashtable.Add("00_65", "Function: F14");
			hashtable.Add("00_66", "Function: F15");
			hashtable.Add("00_67", "Function: F16");	// Mac keyboard
			hashtable.Add("00_68", "Function: F17");	// Mac keyboard
			hashtable.Add("00_69", "Function: F18");	// Mac keyboard
			hashtable.Add("00_6A", "Function: F19");	// Mac keyboard
			hashtable.Add("00_6B", "Function: F20");	// IBM Model F 122-keys
			hashtable.Add("00_6C", "Function: F21");	// IBM Model F 122-keys
			hashtable.Add("00_6D", "Function: F22");	// IBM Model F 122-keys
			hashtable.Add("00_6E", "Function: F23");	// IBM Model F 122-keys
			hashtable.Add("00_6F", "Function: F24");	// IBM Model F 122-keys

			hashtable.Add("00_70", "Unknown: 0x0070");
			hashtable.Add("00_71", "Unknown: 0x0071");
			hashtable.Add("00_72", "Unknown: 0x0072");
			hashtable.Add("00_73", "Unknown: 0x0073");
			hashtable.Add("00_74", "Unknown: 0x0074");
			hashtable.Add("00_75", "Unknown: 0x0075");
			hashtable.Add("00_76", "Unknown: 0x0076");
			hashtable.Add("00_77", "Unknown: 0x0077");
			hashtable.Add("00_78", "Unknown: 0x0078");
			hashtable.Add("00_79", "Unknown: 0x0079");
			hashtable.Add("00_7A", "Unknown: 0x007A");
			hashtable.Add("00_7B", "Unknown: 0x007B");
			hashtable.Add("00_7C", "Unknown: 0x007C");
			hashtable.Add("00_7D", "Special: ¥ -");
			hashtable.Add("00_7E", "Unknown: 0x007E");
			hashtable.Add("00_7F", "Unknown: 0x007F");

			hashtable.Add("E0_01", "Unknown: 0xE001");
			hashtable.Add("E0_02", "Unknown: 0xE002");
			hashtable.Add("E0_03", "Unknown: 0xE003");
			hashtable.Add("E0_04", "Unknown: 0xE004");
			hashtable.Add("E0_05", "Unknown: 0xE005");
			hashtable.Add("E0_06", "Unknown: 0xE006");
			hashtable.Add("E0_07", "F-Lock: Redo");		//   F3 - Redo
			hashtable.Add("E0_08", "F-Lock: Undo");		//   F2 - Undo
			hashtable.Add("E0_09", "Unknown: 0xE009");
			hashtable.Add("E0_0A", "Unknown: 0xE00A");
			hashtable.Add("E0_0B", "Unknown: 0xE00B");
			hashtable.Add("E0_0C", "Unknown: 0xE00C");
			hashtable.Add("E0_0D", "Unknown: 0xE00D");
			hashtable.Add("E0_0E", "Unknown: 0xE00E");
			hashtable.Add("E0_0F", "Unknown: 0xE00F");

			hashtable.Add("E0_10", "Media: Prev Track");
			hashtable.Add("E0_11", "App: Messenger");
			hashtable.Add("E0_12", "Logitech: Webcam");
			hashtable.Add("E0_13", "Logitech: iTouch");
			hashtable.Add("E0_14", "Logitech: Shopping");
			hashtable.Add("E0_15", "Unknown: 0xE015");
			hashtable.Add("E0_16", "Unknown: 0xE016");
			hashtable.Add("E0_17", "Unknown: 0xE017");
			hashtable.Add("E0_18", "Unknown: 0xE018");
			hashtable.Add("E0_19", "Media: Next Track");
			hashtable.Add("E0_1A", "Unknown: 0xE01A");
			hashtable.Add("E0_1B", "Unknown: 0xE01B");
			hashtable.Add("E0_1C", "Num: Enter");
			hashtable.Add("E0_1D", "Special: Right Ctrl");
			hashtable.Add("E0_1E", "Unknown: 0xE01E");
			hashtable.Add("E0_1F", "Unknown: 0xE01F");

			hashtable.Add("E0_20", "Media: Mute");
			hashtable.Add("E0_21", "App: Calculator");
			hashtable.Add("E0_22", "Media: Play/Pause");
			hashtable.Add("E0_23", "F-Lock: Spell");	//   F10
			hashtable.Add("E0_24", "Media: Stop");
			hashtable.Add("E0_25", "Unknown: 0xE025");
			hashtable.Add("E0_26", "Unknown: 0xE026");
			hashtable.Add("E0_27", "Unknown: 0xE027");
			hashtable.Add("E0_28", "Unknown: 0xE028");
			hashtable.Add("E0_29", "Unknown: 0xE029");
			// hashtable.Add("E0_2A", "Special: PrtSc");	// removed due to conflict
			hashtable.Add("E0_2B", "Unknown: 0xE02B");
			hashtable.Add("E0_2C", "Unknown: 0xE02C");
			hashtable.Add("E0_2D", "Unknown: 0xE02D");
			hashtable.Add("E0_2E", "Media: Volume Down");
			hashtable.Add("E0_2F", "Unknown: 0xE02F");

			hashtable.Add("E0_30", "Media: Volume Up");
			hashtable.Add("E0_31", "Unknown: 0xE031");
			hashtable.Add("E0_32", "Web: Home");
			hashtable.Add("E0_33", "Unknown: 0xE033");
			hashtable.Add("E0_34", "Unknown: 0xE034");
			hashtable.Add("E0_35", "Num: /");
			hashtable.Add("E0_36", "Unknown: 0xE036");
			hashtable.Add("E0_37", "Special: PrtSc");
			hashtable.Add("E0_38", "Special: Right Alt");
			hashtable.Add("E0_2038", "Special: Alt Gr");
			hashtable.Add("E0_39", "Unknown: 0xE039");
			hashtable.Add("E0_3A", "Unknown: 0xE03A");
			hashtable.Add("E0_3B", "F-Lock: Help");		//   F1
			hashtable.Add("E0_3C", "F-Lock: Office Home");	//   F2 - Office Home
			hashtable.Add("E0_3D", "F-Lock: Task Pane");	//   F3 - Task pane
			hashtable.Add("E0_3E", "F-Lock: New");		//   F4
			hashtable.Add("E0_3F", "F-Lock: Open");		//   F5

			hashtable.Add("E0_40", "F-Lock: Close");	//   F6
			hashtable.Add("E0_41", "F-Lock: Reply");	//   F7
			hashtable.Add("E0_42", "F-Lock: Fwd");		//   F8
			hashtable.Add("E0_43", "F-Lock: Send");		//   F9
			hashtable.Add("E0_44", "Unknown: 0xE044");
			hashtable.Add("E0_45", "Special: €");		//   Euro
			hashtable.Add("E0_46", "Unknown: 0xE046");
			hashtable.Add("E0_47", "Special: Home");
			hashtable.Add("E0_48", "Arrow: Up");
			hashtable.Add("E0_49", "Special: Page Up");
			hashtable.Add("E0_4A", "Unknown: 0xE04A");
			hashtable.Add("E0_4B", "Arrow: Left");
			hashtable.Add("E0_4C", "Unknown: 0xE04C");
			hashtable.Add("E0_4D", "Arrow: Right");
			hashtable.Add("E0_4E", "Unknown: 0xE04E");
			hashtable.Add("E0_4F", "Special: End");

			hashtable.Add("E0_50", "Arrow: Down");
			hashtable.Add("E0_51", "Special: Page Down");
			hashtable.Add("E0_52", "Special: Insert");
			hashtable.Add("E0_53", "Special: Delete");
			hashtable.Add("E0_54", "Unknown: 0xE054");
			hashtable.Add("E0_55", "Unknown: 0xE055");
			hashtable.Add("E0_56", "Special: < > |");
			hashtable.Add("E0_57", "F-Lock: Save");		//   F11
			hashtable.Add("E0_58", "F-Lock: Print");	//   F12
			hashtable.Add("E0_59", "Unknown: 0xE059");
			hashtable.Add("E0_5A", "Unknown: 0xE05A");
			hashtable.Add("E0_5B", "Special: Left Windows");
			hashtable.Add("E0_5C", "Special: Right Windows");
			hashtable.Add("E0_5D", "Special: Application");
			hashtable.Add("E0_5E", "Special: Power");
			hashtable.Add("E0_5F", "Special: Sleep");

			hashtable.Add("E0_61", "Unknown: 0xE061");
			hashtable.Add("E0_62", "Unknown: 0xE062");
			hashtable.Add("E0_63", "Special: Wake (or Fn)");
			hashtable.Add("E0_64", "Unknown: 0xE064");
			hashtable.Add("E0_65", "Web: Search");
			hashtable.Add("E0_66", "Web: Favorites");
			hashtable.Add("E0_67", "Web: Refresh");
			hashtable.Add("E0_68", "Web: Stop");
			hashtable.Add("E0_69", "Web: Forward");
			hashtable.Add("E0_6A", "Web: Back");
			hashtable.Add("E0_6B", "App: My Computer");
			hashtable.Add("E0_6C", "App: E-Mail");
			hashtable.Add("E0_6D", "App: Media Select");
			hashtable.Add("E0_6E", "Unknown: 0xE06E");
			hashtable.Add("E0_6F", "Unknown: 0xE06F");

			return hashtable;
		}
	}
}
