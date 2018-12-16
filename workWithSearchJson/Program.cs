using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace workWithSearchJson
{    
    class Program
    {
        static void Main(string[] args)
        {
         
            string json = File.ReadAllText(@"jsonRes.json");

            JsonParcer(json);
           

            Console.ReadKey();
        }

        static void JsonParcer(string json)
        {
            //json to xml
            XNode node = JsonConvert.DeserializeXNode(json, "Root");
          File.WriteAllText(@"sometest.xml", node.ToString());

            //
            string xmlFile = @"sometest.xml";
            int i = 0; string wordt = "";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlFile);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут tags_0,1..
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode tagAtr = xnode.Attributes.GetNamedItem("tags");
                    if (tagAtr != null)
                        Console.WriteLine(tagAtr.Value);
                }
                // обходим все дочерние узлы элемента tags
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел - actions...
                    if (childnode.Name == "actions")
                    {
                        foreach (XmlNode childAct in childnode.ChildNodes)
                        {
                            if (childAct.Name == "data")
                            {
                                foreach (XmlNode childData in childAct.ChildNodes)
                                {
                                    if (childData.Name == "value")
                                    {
                                        foreach (XmlNode childValue in childData.ChildNodes)
                                        {
                                            if (childValue.Name == "webSearchUrl")
                                            {
                                                //  Console.WriteLine("url: {0}\n", childValue.InnerText);
                                           //   File.WriteAllText(@"URLtest" + i.ToString() + ".xml", childValue.InnerText);

                                                File.AppendAllText(@"URLtest.xml", "\n\n\n"+ childValue.InnerText);

                                                i++;
                                            }
                                            else if (childValue.Name == "name")
                                            {
                                                ///Console.WriteLine("url: {0}\n", childValue.InnerText);
                                                wordt += childValue.InnerText + "\n\t";

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                // Console.WriteLine();

            }
            Console.WriteLine(i);
            File.WriteAllText(@"word.txt", wordt);

        }
    }
}
