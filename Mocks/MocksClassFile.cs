using RazorPageNewTest.Data;
using RazorPageNewTest.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageNewTest.Mocks
{
    public class MocksClassFile : INterfaceClassFile
    {
        
        public IEnumerable<ClassFile> AllFiles
        {
            get
            {
                List<ClassFile> allFiles = new List<ClassFile>();
                DirectoryInfo di = new DirectoryInfo(@"Ответ на обращение");
                FileInfo[] array = di.GetFiles();
                for (int i = 0; i < array.Length; i++)
                {
                    FileInfo temp = (FileInfo)array[i];
                    ClassFile file = new ClassFile
                    {
                        Id = i + 1,
                        Name = temp.Name,
                        FullName = temp.FullName,
                        Agree = false
                    };
                    allFiles.Add(file);
                }
                return allFiles;
            }
        }

        
    }
}
