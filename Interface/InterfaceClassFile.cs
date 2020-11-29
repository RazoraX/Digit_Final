using RazorPageNewTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageNewTest.Interface
{
    public interface INterfaceClassFile
    {
        public IEnumerable<ClassFile> AllFiles { get; }
    }
}
