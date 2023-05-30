﻿using System;
using System.Collections.Generic;
using ConsoleApp;
using System.Linq;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        bool relaunch = true;
        Console.WriteLine("\nBienvenue sur les statistques de vente de jeux vidéo.");
        while (relaunch)
        {
            Console.WriteLine("1 - Création du fichier de donnée (Json / Xml / Txt)");
            Console.WriteLine("2 - Recherche de donnée aux formats Json / Xml / Txt");
            Console.WriteLine("3 - Exit");
            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    TransformFormat transformformat = new TransformFormat();
                    transformformat.Create();
                    break;
                case "2":
                    Search search = new Search();
                    search.Start();
                    break;
                case "3":
                    relaunch = false;
                    break;
            }
        }
    }
}