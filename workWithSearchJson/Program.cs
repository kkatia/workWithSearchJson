using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithSearchJson
{
     
    class human
    {
        public virtual string Said()
        {
            return "i am human";
        }
    }
    class child : human
    {
        public override string Said()
        {
            return "i am child"; 
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            human item1 = new human();
            human item2 = new child();
           
            Console.WriteLine(
            item1.Said()+
            "\n"+
            item2.Said());
            Console.ReadKey();
        }
    }
}
