using System;

namespace SharpKeys
{
    /// <summary>
    /// ListViewItemModel
    /// </summary>
    public class StringMapping
    {
        readonly StringMappings m_stringMappings;

        public StringMapping(StringMappings stringMappings, byte b0, byte b1, byte b2, byte b3)
        {
            m_stringMappings = stringMappings;
            m_registryScanCode = new byte[4] { b0, b1, b2, b3 };
        }

        public StringMapping(StringMappings stringMappings, int scanCodeFrom, int scanCodeTo)
        {
            byte b0 = (byte)((scanCodeFrom & 0xff00) >> 8);
            byte b1 = (byte)(scanCodeFrom & 0xff);
            byte b2 = (byte)((scanCodeTo & 0xff00) >> 8);
            byte b3 = (byte)(scanCodeTo & 0xff);

            m_stringMappings = stringMappings;
            m_registryScanCode = new byte[4] { b3, b2, b1, b0 };
        }

        byte[] m_registryScanCode;

        public string TextFrom => From.Text;

        public string TextTo => To.Text;

        public bool IsAssigned => ToScanCode == 0;

        public int ScanCode => (m_registryScanCode[3] << 24) | (m_registryScanCode[2] << 16) | (m_registryScanCode[1] << 8) | m_registryScanCode[0];

        public int FromScanCode => (m_registryScanCode[3] << 8) | m_registryScanCode[2];
        public int ToScanCode => (m_registryScanCode[1] << 8) | m_registryScanCode[0];

        public StringKey From => m_stringMappings[FromScanCode];
        public StringKey To => m_stringMappings[ToScanCode];

        public byte[] RegistryScanCode => m_registryScanCode;

        public void SetMappings(byte[] scanCode) => m_registryScanCode = scanCode;
    }
}