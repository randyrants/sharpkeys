using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpKeys
{
    public class StringMappings
    {
        readonly StringKeys m_hashKeys = StringKeys.Default;

        static readonly StringMappings stringMappings = new StringMappings();

        StringMappings()
        {
        }

        public static StringMappings Instance => stringMappings;

        readonly Dictionary<StringKey, StringKey> m_stringMappings = new Dictionary<StringKey, StringKey>();

        public StringKey this[int scancode] => m_hashKeys[scancode] ?? m_hashKeys.Get(scancode, string.Format("Unknown: 0x{0:4,X}", scancode));

        /// <summary>
        /// Adds a string mappings from registry
        /// </summary>
        /// <param name="b0">ToLow</param>
        /// <param name="b1">ToHi</param>
        /// <param name="b2">FromLo</param>
        /// <param name="b3">FromHi</param>
        void AddRegistryStringMapping(byte b0, byte b1, byte b2, byte b3)
        {
            var sm = new StringMapping(this, b0, b1, b2, b3);
            m_stringMappings.Add(sm.From, sm.To);
        }

        public IEnumerable<StringMapping> Default => stringMappings.m_stringMappings.Select(p => new StringMapping(this, p.Key.ScanCode, p.Value.ScanCode));

        public static byte[] WriteRegistryBytes()
        {
            int nCount = stringMappings.m_stringMappings.Count;

            if (nCount == 0)
                return new byte[0];

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
            int i = 0;
            foreach (var keymap in stringMappings.Default)
            {
                byte[] registryScanCode = keymap.GetRegistryScanCode();
                bytes[(i * 4) + 12 + 0] = registryScanCode[0];
                bytes[(i * 4) + 12 + 1] = registryScanCode[1];
                bytes[(i * 4) + 12 + 2] = registryScanCode[2];
                bytes[(i * 4) + 12 + 3] = registryScanCode[3];
                i++;
            }

            // last 4 are 0's
            return bytes;
        }

        public static void ReadRegistryBytes(byte[] bytes)
        {
            // can skip the first 8 bytes as they are ALWAYS 0x00
            // the 9th byte is ALWAYS the total number of mappings (including the trailing null pointer)
            if (bytes.Length > 8)
            {
                var nTotal = int.Parse(bytes[8].ToString());
                for (int i = 0; i < nTotal - 1; i++)
                {
                    stringMappings.AddRegistryStringMapping(bytes[(i * 4) + 12 + 0], bytes[(i * 4) + 12 + 1], bytes[(i * 4) + 12 + 2], bytes[(i * 4) + 12 + 3]);
                }
            }
        }
    }
}