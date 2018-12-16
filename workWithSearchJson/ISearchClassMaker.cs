using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithSearchJson
{
    interface ISearchClassMaker
    {
        string type { get; set; }
        Instrumentation instrumentation { get; set; }
        List<tagsEl> tags { get; set; }
        ImageR image { get; set; }

      

    }
     class Instrumentation { }
    class ImageR { }
    class tagsEl { }


}
