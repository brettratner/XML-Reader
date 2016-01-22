using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXMLfromFile
{  /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class Class1
    {
        public static void Main()
        {
            /*Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load("ucContest.ascx.resx");
             * 
            XmlNodeList elemList = doc.GetElementsByTagName("data");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
            }
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", data);*/



           /* XmlDocument xDoc = new XmlDocument();
        string path = Directory.GetCurrentDirectory();
        foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
        {
          xDoc.Load(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), file));
          string strpath = xDoc.BaseURI;
        }*/

//       string[] lines = System.IO.File.ReadAllLines(@"C:\Apps\BossWeb\wwwroot\debit\2.0\Boss\Modules\App_LocalResources\ucContest.ascx.resx");
       /* XmlDocument xDoc = new XmlDocument();
            string[] filePaths = Directory.GetFiles(@"C:\Apps\BossWeb\wwwroot\debit\2.0\Boss\Modules\App_LocalResources\");
        

            foreach (string line in Directory.EnumerateFiles(@"C:\Apps\BossWeb\wwwroot\debit\2.0\Boss\Modules\App_LocalResources\", "*.resx"))
            {
                xDoc.Load(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), line));
                Console.WriteLine("\t" + line);
            }*/

            
                Console.WriteLine("Enter input:"); // Prompt
                string line = Console.ReadLine(); // Get string from user
               
              
                Console.Write("You typed "); // Report output
                Console.Write(line);
                Console.WriteLine(" character(s)");
            

            XmlDocument xDoc = new XmlDocument();
            String DocType = "*.resx";
           // String Doctype2 = "*.xml";
            String MergingFiles = @"C:\Apps\BossWeb\wwwroot\debit\2.0\bossrevolution\retailers\account\App_LocalResources";
            String MergedFile = @"C:\test2.xml";
            String FinalFile = @"C:\final2.resx";
            System.Console.WriteLine("Please Enter The full Directory of the Files");
            MergingFiles = Console.ReadLine();
            System.Console.WriteLine("You have chosen to mere files from " + MergingFiles + "Location.\n");
            /*var lines = from file in Directory.EnumerateFiles(MergingFiles, DocType)
                        from line in File.ReadLines(file).Concat(new[] { Environment.NewLine })
                        select line;
            foreach (string line in Directory.EnumerateFiles(MergingFiles, DocType))
           {
               xDoc.Load(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), line));
               Console.WriteLine("\t" + line);
           }
            File.WriteAllLines(MergedFile, lines);
           */
            
            var fileContents = System.IO.File.ReadAllText(MergedFile);

            fileContents = fileContents.Replace("<root>", "");
            fileContents = fileContents.Replace("</root>", "");
            fileContents = fileContents.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
            //                                   <?xml version=\"1.0\" encoding=\"utf-8\"?>
            System.IO.File.WriteAllText(MergedFile, "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<root>\n");
            File.AppendAllText(MergedFile, fileContents);
            File.AppendAllText(MergedFile, "</root>");
            
           // Create the XmlDocument.
          //  XmlDocument doc = new XmlDocument();
            var doc = new XmlDocument();
           // doc.PreserveWhitespace = false;
            doc.Load(MergedFile);
            XmlNodeList elemList = doc.GetElementsByTagName("data");
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            ostrm = new FileStream(FinalFile, FileMode.OpenOrCreate, FileAccess.Write);
            writer = new StreamWriter(ostrm);
            
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.SetOut(writer);
                Console.WriteLine(elemList[i].OuterXml);
                Console.SetOut(oldOut);
               // File.WriteAllLines(FinalFile, doc[i].OuterXml);
            }

            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");

        }
    }
}
