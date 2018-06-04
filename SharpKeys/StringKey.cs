using System;

namespace SharpKeys
{
    public class StringKey
    {
        readonly byte[] m_byteScanCode;

        public StringKey(int scancode, string description)
        {
            ScanCode = scancode;
            Description = description;
            var b0 = (byte)(scancode & 0xff);
            var b1 = (byte)((scancode & 0xff00) >> 8);
            m_byteScanCode = new byte[2] { b1, b0 };
        }

        public int ScanCode { get; }

        public string Description { get; }

        public string Text => string.Format("{0} ({1})", Description, TextScanCode);

        public string TextScanCode => string.Format("{0,2:X}_{1,2:X}", m_byteScanCode[0], m_byteScanCode[1]).Replace(" ", "0");
    }
}