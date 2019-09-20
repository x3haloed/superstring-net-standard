using System;
using System.Collections.Generic;
using System.Text;
using WebAssembly;
using WebAssembly.Runtime;

namespace Superstring
{
    static class WasmManager
    {
        private static readonly object _syncRoot = new { };
        private static Instance<SuperstringCoreExports> _wasmInstance;
        public static SuperstringCoreExports Exports
        {
            get
            {
                if (_wasmInstance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_wasmInstance == null)
                        {
                            var module = WebAssembly.Module.ReadFromBinary(@"C:\Code\superstring-net-standard\superstring.wasm");

                            var importDictionary = new ImportDictionary();
                            var _instanceCreator = module.Compile<SuperstringCoreExports>();
                            _wasmInstance = _instanceCreator(importDictionary);
                        }
                    }
                }

                return _wasmInstance.Exports;
            }
        }
    }
}
