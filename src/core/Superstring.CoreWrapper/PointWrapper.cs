using System;
using System.Runtime.InteropServices;

namespace Superstring.CoreWrapper
{
    public class PointWrapper
    {
        private PointWrapper(Point point) {

        }

        static string row_string;
        static string column_string;
        
        public static void init(){
            row_string = "row";
            column_string = "column";

            Local<FunctionTemplate> constructor_template = Nan::New<FunctionTemplate>(construct);
            constructor_template->SetClassName(Nan::New<String>("Point").ToLocalChecked());
            constructor_template->InstanceTemplate()->SetInternalFieldCount(1);
            Nan::SetAccessor(constructor_template->InstanceTemplate(), Nan::New(row_string), get_row);
            Nan::SetAccessor(constructor_template->InstanceTemplate(), Nan::New(column_string), get_column);
            constructor.Reset(Nan::GetFunction(constructor_template).ToLocalChecked());
        }

        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern v8::Local<v8::Value> from_point(Point point);

        [DllImport(@"../cpp/libhello-cpp.so")]
        public static extern optional<Point> point_from_js(v8::Local<v8::Value>);

        [DllImport(@"../cpp/libhello-cpp.so")]
        extern Point point;
    }
}
