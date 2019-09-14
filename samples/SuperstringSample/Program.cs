using System;
using WebAssembly.Runtime;

namespace SuperstringSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var module = WebAssembly.Module.ReadFromBinary(@"C:\Code\superstring-net-standard\build\Release\superstring_core.a");
            //var _instanceCreator = Compile.FromBinary<MarkerIndex>("superstring.wasm");
            //using (var instance = _instanceCreator(new ImportDictionary()))
            //{
            //    return instance.Exports;
            //    var e = new Export();
            //}
            foreach (var e in module.Exports)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
