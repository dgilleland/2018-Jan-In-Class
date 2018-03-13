using DataEntities;                 // for CodeDemo class
using ServerSide.DAL;               // for DemoLibraryContext class
using System.Collections.Generic;   // for List<T> class
using System.Linq;                  // for .ToList() extension method

namespace ServerSide.BLL
{
    public class CodeDemoController
    {
        public List<CodeDemo> ListAllDemos()
        {
            using (var context = new DemoLibraryContext())
            {
                return context.CodeDemos.ToList();
            }
        }
    }
}
