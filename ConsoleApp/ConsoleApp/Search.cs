using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using ConsoleApp;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    public class Search
    {
        private string attribute;
        private string orderBy;
        private string conditionLibre;
        private string resultatConditionLibre;

        public void Start()
        {
            Console.WriteLine("Sur quel champs voulez rechercher ?");
            Console.WriteLine("1 - Rank");
            Console.WriteLine("2 - Name");
            Console.WriteLine("3 - Platform");
            Console.WriteLine("4 - Year");
            Console.WriteLine("5 - Genre");
            Console.WriteLine("6 - Publisher");
            string reponseAttribute = Console.ReadLine();

            switch (reponseAttribute)
            {
                case "1":
                    attribute = "Rank";
                    break;
                case "2":
                    attribute = "Name";
                    break;
                case "3":
                    attribute = "Platform";
                    break;
                case "4":
                    attribute = "Year";
                    break;
                case "5":
                    attribute = "Genre";
                    break;
                case "6":
                    attribute = "Publisher";
                    break;
                default:
                    Start();
                    break;
            }

            Console.WriteLine("Sur quel champs trier la rechercher ?");
            Console.WriteLine("1 - Rank");
            Console.WriteLine("2 - Name");
            Console.WriteLine("3 - Platform");
            Console.WriteLine("4 - Year");
            Console.WriteLine("5 - Genre");
            Console.WriteLine("6 - Publisher");
            string reponseOrderBy = Console.ReadLine();
            switch (reponseOrderBy)
            {
                case "1":
                    orderBy = "Rank";
                    break;
                case "2":
                    orderBy = "Name";
                    break;
                case "3":
                    orderBy = "Platform";
                    break;
                case "4":
                    orderBy = "Year";
                    break;
                case "5":
                    orderBy = "Genre";
                    break;
                case "6":
                    orderBy = "Publisher";
                    break;
                default:
                    orderBy = "Name";
                    break;
            }

            Console.WriteLine("Format de la reponse pour votre recherche ?");
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - TXT");
            string reponseFormat = Console.ReadLine();

            switch (reponseFormat)
            {
                case "1":
                    SearchJson();
                    break;
                case "2":
                    SearchXml();
                    break;
                case "3":
                    SearchTxt();
                    break;
                default:
                    SearchJson();
                    break;
            }
        }

        public void SearchJson()
        {
            Console.WriteLine("Rechercher un jeu...");
            string recherche = Console.ReadLine();

            var myJsonGameSale =
                JObject.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}../../../../Json/gameSale.json"));
            var searchResult = from game in myJsonGameSale["gameSaleData"]
                where ((string)game[attribute]).Contains(recherche, StringComparison.CurrentCultureIgnoreCase)
                orderby game[orderBy]
                select game;

            foreach (var game in searchResult)
            {
                Console.WriteLine($"{game}");
            }
        }

        public void SearchTxt()
        {
            Console.WriteLine("Rechercher un jeu...");
            string input = Console.ReadLine();
            var myTxtGameSale =
                from line in File.ReadAllLines($@"{Directory.GetCurrentDirectory()}../../../../Txt/gameSale.txt")
                let containSearch = line.Contains(input, StringComparison.InvariantCultureIgnoreCase)
                where containSearch
                orderby line.Contains(orderBy)
                select line;

            foreach (var game in myTxtGameSale)
            {
                Console.WriteLine($"{game}");
            }
        }


        public void SearchXml()
        {
            Console.WriteLine("Rechercher un jeu...");
            string input = Console.ReadLine();

            var lines = XElement.Load($"{Directory.GetCurrentDirectory()}../../../../Xml/gameSale.xml");

            var myXmlGameSale =
                from element in lines.Descendants("GameSale")
                where element.Element(attribute).Value.Contains(input, StringComparison.CurrentCultureIgnoreCase)
                orderby element.Element(orderBy).Value
                select element;

            foreach (var game in myXmlGameSale)
            {
                Console.WriteLine($"Game : {game}");
            }
        }
    }
}