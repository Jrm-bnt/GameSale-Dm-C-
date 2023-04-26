using System;
using System.Collections.Generic;
using ConsoleApp;
using System.Linq;
using System.IO;


class Program
{
    static void Main(string[] args)
    {

        // TransformFormat transformformat = new TransformFormat();
        // transformformat.Create();

        Search search = new Search();
        // search.SearchJson();
        // search.SearchTxt();
        // search.SearchXml();
         search.Start();
    }
}