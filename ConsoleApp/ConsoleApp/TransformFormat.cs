using System;
// using DataSources;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using PopularVideoGames.DataSource;

namespace ConsoleApp

{
    class TransformFormat
    {
        public void Create()
        {
            GameSale gameSale = new GameSale();
            var gameSaleData = gameSale.GetGameSaleData();


            Console.WriteLine("En quoi voulez-vous transformer votre src de données ?");
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - TXT");

            string reponse = Console.ReadLine();

            switch (reponse)
            {
                case "1":
                    PrintJson(gameSaleData);
                    break;
                case "2":
                    PrintXml(gameSaleData);
                    break;
                case "3":
                    PrintTxt(gameSaleData);
                    break;
            }
        }

        static void PrintTxt(List<Game> gameSaleData)
        {
            Console.WriteLine("Création du fichier en cours...");

            var gameSaleTxT = from data in gameSaleData
                select
                    $"Rank: {data.Rank} | Name: {data.Name} | Platform: {data.Name} | Year: {data.Year} | Genre: {data.Genre} | Publisher: {data.Publisher} | NA_Sales: {data.NA_Sales} | EU_Sales: {data.EU_Sales} | JP_Sales: {data.JP_Sales} | Other_Sales: {data.Other_Sales} | Global_Sales: {data.Global_Sales}";
            string allData = "";
            foreach (var game in gameSaleTxT)
            {
                allData += game + "\n";
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Txt", "gameSale.txt");
            File.WriteAllText(filePath, allData);
            Console.WriteLine(allData);
            Console.WriteLine("\nLe fichier gameSale.txt a été créé dans le dossier Txt");
        }

        static void PrintXml(List<Game> gameSaleData)
        {
            var XML = new XElement("gameSaleData", from data in gameSaleData
                select new XElement("GameSale",
                    new XElement("Rank", data.Rank),
                    new XElement("Name", data.Name),
                    new XElement("Platform", data.Platform),
                    new XElement("Year", data.Year),
                    new XElement("Genre", data.Genre),
                    new XElement("Publisher", data.Publisher),
                    new XElement("NA_Sales", data.NA_Sales),
                    new XElement("EU_Sales", data.EU_Sales),
                    new XElement("JP_Sales", data.JP_Sales),
                    new XElement("Other_Sales", data.Other_Sales),
                    new XElement("Global_Sales", data.Global_Sales)
                )
            );
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Xml", "gameSale.xml");
            File.WriteAllText(filePath, XML.ToString());
            Console.Write(XML.ToString());
            Console.WriteLine("\nLe fichier gameSale.xml a été créé dans le dossier Xml");
        }

        static void PrintJson(List<Game> gameSaleData)
        {
            var Json = new JObject(new JProperty("gameSaleData",
                from data in gameSaleData
                select new JObject(
                    new JProperty("Rank", data.Rank),
                    new JProperty("Name", data.Name),
                    new JProperty("Platform", data.Platform),
                    new JProperty("Year", data.Year),
                    new JProperty("Genre", data.Genre),
                    new JProperty("Publisher", data.Publisher),
                    new JProperty("NA_Sales", data.NA_Sales),
                    new JProperty("EU_Sales", data.EU_Sales),
                    new JProperty("JP_Sales", data.JP_Sales),
                    new JProperty("Other_Sales", data.Other_Sales),
                    new JProperty("Global_Sales", data.Global_Sales)
                )
            ));
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Json", "gameSale.json");
            File.WriteAllText(filePath, Json.ToString());
            Console.Write(Json.ToString());
            Console.WriteLine("\nLe fichier gameSale.json a été créé dans le dossier Json");
        }
    }
}