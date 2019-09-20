using System;
using System.IO;
using WasmerSharp;
using WebAssembly.Runtime;

namespace SuperstringSample
{
    public abstract class SuperstringWasmExports
    {
        public abstract IntPtr _ZN12PointWrapper15construct_pointEv(IntPtr p1);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var module = WebAssembly.Module.ReadFromBinary(@"C:\Code\superstring-net-standard\superstring.wasm");
            foreach (var e in module.Exports)
            {
                Console.WriteLine(e.ToString());
            }

            //module.Memories.Add(new WebAssembly.Memory(2, null));

            var importDictionary = new ImportDictionary();
            //Action<int> t0d = p1 => { };
            //importDictionary.Add("env", "_ZN5PointC1Ev", new FunctionImport(t0d));
            //var memory = new UnmanagedMemory(2, null);
            //importDictionary.Add("env", "memory", new MemoryImport(() => memory));


            var _instanceCreator = module.Compile<SuperstringWasmExports>();
            using (var instance = _instanceCreator(importDictionary))
            {
                IntPtr rNum = instance.Exports._ZN12PointWrapper15construct_pointEv(new IntPtr());
            }
        }



        //static void Main(string[] args)
        //{
        //    var _instanceCreator = Compile.FromBinary<dynamic>(@"C:\Code\superstring-net-standard\superstring.wasm");
        //    var importDictionary = new ImportDictionary();
        //    Action<int> t0d = p1 => { };
        //    importDictionary.Add("env", "_ZN5PointC1Ev", new FunctionImport(t0d));

        //    using (var instance = _instanceCreator(importDictionary))
        //    {
        //        instance.Exports._ZN11MarkerIndexC2Ej();
        //    }
        //}

        //delegate void type0Delegate(InstanceContext ctx, int p1);

        //static void Main(string[] args)
        //{
        //    var wasm = File.ReadAllBytes(@"C:\Code\superstring-net-standard\superstring.wasm");

        //    var x = Module.Create(wasm);
        //    Console.WriteLine("The loaded target.wasm has the following imports listed:");
        //    foreach (var import in x.ImportDescriptors)
        //    {
        //        Console.WriteLine($"import: {import.Kind} {import.ModuleName}::{import.Name} ");
        //    }

        //    Console.WriteLine("The loaded target.wasm has the following exports listed:");
        //    //foreach (var export in x.ExportDescriptors)
        //    //{
        //    //    Console.WriteLine($"export: {export.Kind} {export.Name} ");
        //    //}

        //    type0Delegate _ZN5PointC1EvFn = (ctx, p1) => { };

        //    var _ZN5PointC1EvImport = new Import("env", "_ZN5PointC1Ev", new ImportFunction(_ZN5PointC1EvFn));
        //    var memory = new Import("env", "memory", Memory.Create(minPages: 256, maxPages: 2056));

        //    var instance = new Instance(wasm, memory);

        //    var result = instance.Call("_ZN11MarkerIndex22generate_random_numberEv");
        //    Console.WriteLine(result.Length);
        //}
    }
}
