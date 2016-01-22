using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;


/*
 * Author: Brett Ratner, July 2015
 * This Application takes all the .resx files in the specified 
 * destination that is declared by the user. It will then promt
 * the user to pick a place to save the new file to. It will 
 * then merge all the files in that directory and then create a
 * new file that will display only the information within the 
 * data tags of those files. 
 * 
 */

namespace ReadXMLfromFile
{
    class Program
    {
        static void Main(string[] args)
        {

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


            XmlDocument xDoc = new XmlDocument();
            String DocType = "*.resx";
            String DocTypeSpa = "*.es.resx";
            // String Doctype2 = "*.xml" C:/Apps;
            String MergingFiles = @"";
            String Blank = @"";
            String Location = Blank + "";
            System.Console.WriteLine("Please Enter The full Directory of the Files:");
            MergingFiles = Console.ReadLine();
            System.Console.WriteLine("Please Enter location where you would like to save your file to:");
            Location = Console.ReadLine();
            String MergedFile = Location+ @"/TempMerge.xml";
            String FinalFile = Location+ @"/FinalMerge.resx";

 //           if (MergingFiles.ToString().Contains(".es.resx"))
   //        {
                var lines = from file in Directory.EnumerateFiles(MergingFiles, DocTypeSpa)
                            from line in File.ReadLines(file).Concat(new[] { Environment.NewLine })
                            select line;

                foreach (string line in Directory.EnumerateFiles(MergingFiles, DocTypeSpa))
                {
                    Console.WriteLine("\t" + line);
                }
//               Blank = Console.ReadLine();

                File.WriteAllLines(MergedFile, lines);


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
                    //  File.WriteAllLines(FinalFile, doc.GetElementsByTagName("data");
                }

                writer.Close();
                ostrm.Close();
                Console.WriteLine("Done");
//           }

        }
    }
}
