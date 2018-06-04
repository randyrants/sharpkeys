using System.Collections.Generic;

namespace SharpKeys
{
    public class StringKeys
    {
        // Dictionary for tracking text to scan codes
        readonly Dictionary<int, StringKey> m_hashKeys = new Dictionary<int, StringKey>();

        public IEnumerable<KeyValuePair<int, StringKey>> Keys => m_hashKeys;

        public static readonly StringKeys Default = new StringKeys();

        public StringKey Get(int scancode, string description)
        {
            if (!m_hashKeys.ContainsKey(scancode))
            {
                Add(scancode, description);
            }
            return m_hashKeys[scancode];
        }

        public void Add(int scancode, string description)
        {
            if (!m_hashKeys.ContainsKey(scancode))
            {
                m_hashKeys.Add(scancode, new StringKey(scancode, description));
            }
        }

        public StringKey this[int scancode] => m_hashKeys.ContainsKey(scancode) ? m_hashKeys[scancode] : null;

        StringKeys()
        {
            // the hash table uses a string in the form of Hi_Lo scan code (in Hex values)
            // that most sources say are scan codes.  The 00_00 will disable a key - everything else
            // is pretty obvious.  There is a bit of a reverse lookup however, so labels changed here
            // need to be changed in a couple of other places
            Add(0x00_00, "-- Turn Key Off");
            Add(0x00_01, "Special: Escape");
            Add(0x00_02, "Key: 1 !");
            Add(0x00_03, "Key: 2 @");
            Add(0x00_04, "Key: 3 #");
            Add(0x00_05, "Key: 4 $");
            Add(0x00_06, "Key: 5 %");
            Add(0x00_07, "Key: 6 ^");
            Add(0x00_08, "Key: 7 &");
            Add(0x00_09, "Key: 8 *");
            Add(0x00_0A, "Key: 9 (");
            Add(0x00_0B, "Key: 0 )");
            Add(0x00_0C, "Key: - _");
            Add(0x00_0D, "Key: = +");
            Add(0x00_0E, "Special: Backspace");
            Add(0x00_0F, "Special: Tab");

            Add(0x00_10, "Key: Q");
            Add(0x00_11, "Key: W");
            Add(0x00_12, "Key: E");
            Add(0x00_13, "Key: R");
            Add(0x00_14, "Key: T");
            Add(0x00_15, "Key: Y");
            Add(0x00_16, "Key: U");
            Add(0x00_17, "Key: I");
            Add(0x00_18, "Key: O");
            Add(0x00_19, "Key: P");
            Add(0x00_1A, "Key: [ {");
            Add(0x00_1B, "Key: ] }");
            Add(0x00_1C, "Special: Enter");
            Add(0x00_1D, "Special: Left Ctrl");
            Add(0x00_1E, "Key: A");
            Add(0x00_1F, "Key: S");

            Add(0x00_20, "Key: D");
            Add(0x00_21, "Key: F");
            Add(0x00_22, "Key: G");
            Add(0x00_23, "Key: H");
            Add(0x00_24, "Key: J");
            Add(0x00_25, "Key: K");
            Add(0x00_26, "Key: L");
            Add(0x00_27, "Key: ; :");
            Add(0x00_28, "Key: ' \"");
            Add(0x00_29, "Key: ` ~");
            Add(0x00_2A, "Special: Left Shift");
            Add(0x00_2B, "Key: \\ |");
            Add(0x00_2C, "Key: Z");
            Add(0x00_2D, "Key: X");
            Add(0x00_2E, "Key: C");
            Add(0x00_2F, "Key: V");

            Add(0x00_30, "Key: B");
            Add(0x00_31, "Key: N");
            Add(0x00_32, "Key: M");
            Add(0x00_33, "Key: , <");
            Add(0x00_34, "Key: . >");
            Add(0x00_35, "Key: / ?");
            Add(0x00_36, "Special: Right Shift");
            Add(0x00_37, "Num: *");
            Add(0x00_38, "Special: Left Alt");
            Add(0x00_39, "Special: Space");
            Add(0x00_3A, "Special: Caps Lock");
            Add(0x00_3B, "Function: F1");
            Add(0x00_3C, "Function: F2");
            Add(0x00_3D, "Function: F3");
            Add(0x00_3E, "Function: F4");
            Add(0x00_3F, "Function: F5");

            Add(0x00_40, "Function: F6");
            Add(0x00_41, "Function: F7");
            Add(0x00_42, "Function: F8");
            Add(0x00_43, "Function: F9");
            Add(0x00_44, "Function: F10");
            Add(0x00_45, "Special: Num Lock");
            Add(0x00_46, "Special: Scroll Lock");
            Add(0x00_47, "Num: 7");
            Add(0x00_48, "Num: 8");
            Add(0x00_49, "Num: 9");
            Add(0x00_4A, "Num: -");
            Add(0x00_4B, "Num: 4");
            Add(0x00_4C, "Num: 5");
            Add(0x00_4D, "Num: 6");
            Add(0x00_4E, "Num: +");
            Add(0x00_4F, "Num: 1");
            Add(0x00_50, "Num: 2");
            Add(0x00_51, "Num: 3");
            Add(0x00_52, "Num: 0");
            Add(0x00_53, "Num: .");
            Add(0x00_56, "Special: ISO extra key");
            Add(0x00_57, "Function: F11");
            Add(0x00_58, "Function: F12");
            Add(0x00_64, "Function: F13");
            Add(0x00_65, "Function: F14");
            Add(0x00_66, "Function: F15");
            Add(0x00_67, "Function: F16"); // Mac keyboard
            Add(0x00_68, "Function: F17"); // Mac keyboard
            Add(0x00_69, "Function: F18"); // Mac keyboard
            Add(0x00_6A, "Function: F19"); // Mac keyboard
            Add(0x00_6B, "Function: F20"); // IBM Model F 122-keys
            Add(0x00_6C, "Function: F21"); // IBM Model F 122-keys
            Add(0x00_6D, "Function: F22"); // IBM Model F 122-keys
            Add(0x00_6E, "Function: F23"); // IBM Model F 122-keys
            Add(0x00_6F, "Function: F24"); // IBM Model F 122-keys
            Add(0x00_7D, "Special: ¥ -");
            Add(0xE0_07, "F-Lock: Redo");        //   F3 - Redo
            Add(0xE0_08, "F-Lock: Undo"); //   F2 - Undo
            Add(0xE0_10, "Media: Prev Track");
            Add(0xE0_11, "App: Messenger");
            Add(0xE0_12, "Logitech: Webcam");
            Add(0xE0_13, "Logitech: iTouch");
            Add(0xE0_14, "Logitech: Shopping");
            Add(0xE0_19, "Media: Next Track");
            Add(0xE0_1C, "Num: Enter");
            Add(0xE0_1D, "Special: Right Ctrl");
            Add(0xE0_20, "Media: Mute");
            Add(0xE0_21, "App: Calculator");
            Add(0xE0_22, "Media: Play/Pause");
            Add(0xE0_23, "F-Lock: Spell");       //   F10
            Add(0xE0_24, "Media: Stop");
            Add(0xE0_2E, "Media: Volume Down");
            Add(0xE0_30, "Media: Volume Up");
            Add(0xE0_32, "Web: Home");
            Add(0xE0_35, "Num: /");
            Add(0xE0_37, "Special: PrtSc");
            Add(0xE0_38, "Special: Right Alt");
            Add(0xE0_3B, "F-Lock: Help");        //   F1
            Add(0xE0_3C, "F-Lock: Office Home"); //   F2 - Office Home
            Add(0xE0_3D, "F-Lock: Task Pane");   //   F3 - Task pane
            Add(0xE0_3E, "F-Lock: New");         //   F4
            Add(0xE0_3F, "F-Lock: Open");        //   F5
            Add(0xE0_40, "F-Lock: Close");       //   F6
            Add(0xE0_41, "F-Lock: Reply");       //   F7
            Add(0xE0_42, "F-Lock: Fwd");         //   F8
            Add(0xE0_43, "F-Lock: Send");        //   F9
            Add(0xE0_45, "Special: €");        //   Euro
            Add(0xE0_47, "Special: Home");
            Add(0xE0_48, "Arrow: Up");
            Add(0xE0_49, "Special: Page Up");
            Add(0xE0_4B, "Arrow: Left");
            Add(0xE0_4D, "Arrow: Right");
            Add(0xE0_4F, "Special: End");
            Add(0xE0_50, "Arrow: Down");
            Add(0xE0_51, "Special: Page Down");
            Add(0xE0_52, "Special: Insert");
            Add(0xE0_53, "Special: Delete");
            Add(0xE0_56, "Special: < > |");
            Add(0xE0_57, "F-Lock: Save");        //   F11
            Add(0xE0_58, "F-Lock: Print");       //   F12
            Add(0xE0_5B, "Special: Left Windows");
            Add(0xE0_5C, "Special: Right Windows");
            Add(0xE0_5D, "Special: Application");
            Add(0xE0_5E, "Special: Power");
            Add(0xE0_5F, "Special: Sleep");
            Add(0xE0_63, "Special: Wake (or Fn)");
            Add(0xE0_65, "Web: Search");
            Add(0xE0_66, "Web: Favorites");
            Add(0xE0_67, "Web: Refresh");
            Add(0xE0_68, "Web: Stop");
            Add(0xE0_69, "Web: Forward");
            Add(0xE0_6A, "Web: Back");
            Add(0xE0_6B, "App: My Computer");
            Add(0xE0_6C, "App: E-Mail");
            Add(0xE0_6D, "App: Media Select");
        }
    }
}