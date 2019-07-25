using System.Runtime.InteropServices;

namespace Superstring.CoreWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    internal class Point {
        internal ushort row;
        internal ushort column;
    };
}