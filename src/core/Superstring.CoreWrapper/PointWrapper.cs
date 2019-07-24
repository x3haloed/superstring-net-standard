using System;
using System.Runtime.InteropServices;

namespace Superstring.CoreWrapper
{
    public class PointWrapper
    {
        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern void init();

        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern v8::Local<v8::Value> from_point(Point point);

        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern optional<Point> point_from_js(v8::Local<v8::Value>);

        [DllImport(@"../cpp/libhello-cpp.so")]
        extern Point point;
    }
}
