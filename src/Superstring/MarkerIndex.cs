using System;
using System.Collections.Generic;
using System.Text;
using WebAssembly;
using WebAssembly.Runtime;

namespace Superstring
{
    public abstract class MarkerIndex
    {
        private static InstanceCreator<MarkerIndex> _instanceCreator;
        private static object _lockSync = new { };
 
        public static MarkerIndex Make(uint seed = 0u)
        {
            if (_instanceCreator == null)
            {
                lock (_lockSync)
                {
                    if (_instanceCreator == null)
                    {
                        _instanceCreator = Compile.FromBinary<MarkerIndex>("superstring.wasm");
                    }
                }
            }

            using (var instance = _instanceCreator(new ImportDictionary()))
            {
                return instance.Exports;
                var e = new Export();
            }
        }
    }
}
