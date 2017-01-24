# FileAplication

Delete what is not included in the list of files.C#.

You must use these libraries
```C#
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
```
#Example
```C#
var pList = ScanFile.GetFileName(@"C:\Users\admin\Desktop");//First you need to create a list of file

ScanFile.Serialize(pList, "Name");// and folders names that must be stored in this path.

                                                                    //Then you only use this method, 
ScanFile.RemoveUnnecessary(@"C: \Users\admin\Desktop\temp1","Name");//all add then he removes.
```
