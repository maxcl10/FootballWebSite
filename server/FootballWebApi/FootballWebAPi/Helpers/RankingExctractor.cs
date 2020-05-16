using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FootballWebSiteApi.Entities;
using HtmlAgilityPack;

namespace FootballWebSiteApi.Helpers
{
    public class RankingExctractor
    {
        public static IEnumerable<LazyRanking> GetRankigFromLgefUrl(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Console.WriteLine("Starting");
            var result = GetHtmlAsString(url);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result);
            Console.WriteLine("HTML loading OK");

            Console.WriteLine(htmlDoc.ToString());

            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Any())
            {
                foreach (var htmlDocParseError in htmlDoc.ParseErrors)
                {
                    Console.WriteLine(htmlDocParseError);
                }
            }
            else
            {
                Console.WriteLine("Parsing OK");
            }

            List<LazyRanking> rankings = new List<LazyRanking>();

            foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//table"))
            {
                Console.WriteLine("Found: " + table.Id);

                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    LazyRanking ranking = new LazyRanking();

                    HtmlNodeCollection cells = row.SelectNodes("td");

                    if (cells == null)
                    {
                        continue;
                    }

                    ranking.position = int.Parse(cells[0].InnerText);
                    ranking.team = Mapping.GetTeam(cells[1].InnerText);
                    ranking.points = int.Parse(cells[2].InnerText);
                    ranking.matchPlayed = int.Parse(cells[3].InnerText);
                    ranking.matchWon = int.Parse(cells[4].InnerText);
                    ranking.matchDraw = int.Parse(cells[5].InnerText);
                    ranking.matchLost = int.Parse(cells[6].InnerText);
                    ranking.withdaw = int.Parse(cells[7].InnerText);
                    ranking.goalsScored = int.Parse(cells[8].InnerText);
                    ranking.goalsAgainst = int.Parse(cells[9].InnerText);
                    ranking.penality = int.Parse(cells[10].InnerText);
                    ranking.goalDifference = int.Parse(cells[11].InnerText);


                    rankings.Add(ranking);
                }
            }

            return rankings;
        }


        public static List<LazyRanking> GetLazyRanking(string url)
        {
            // Get the HTML content as string
            var result = GetHtmlAsString(url);

            // Load the HTML file with HTMLAgility to be able to read it
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result);

            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Any())
            {
                foreach (var htmlDocParseError in htmlDoc.ParseErrors)
                {
                    StringBuilder sbBuilder = new StringBuilder();
                    sbBuilder.Append(htmlDocParseError.Reason).Append("\n");
                    throw new Exception(sbBuilder.ToString());
                }
            }

            //Generate the list of Ranking
            List<LazyRanking> rankings = new List<LazyRanking>();
            foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//table"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    LazyRanking ranking = new LazyRanking();

                    HtmlNodeCollection cells = row.SelectNodes("th|td");

                    if (cells == null)
                    {
                        continue;
                    }

                    ranking.position = int.Parse(cells[0].InnerText);
                    ranking.team = cells[1].InnerText;
                    ranking.points = int.Parse(cells[2].InnerText);
                    ranking.matchPlayed = int.Parse(cells[3].InnerText);
                    ranking.matchWon = int.Parse(cells[4].InnerText);
                    ranking.matchDraw = int.Parse(cells[5].InnerText);
                    ranking.matchLost = int.Parse(cells[6].InnerText);
                    ranking.withdaw = int.Parse(cells[7].InnerText);
                    ranking.goalsScored = int.Parse(cells[8].InnerText);
                    ranking.goalsAgainst = int.Parse(cells[9].InnerText);
                    ranking.penality = int.Parse(cells[10].InnerText);
                    ranking.goalDifference = int.Parse(cells[11].InnerText);


                    rankings.Add(ranking);
                }
            }

            return rankings;
        }

        public static string GetHtmlAsString(string url)
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString(url);

                //Get the ranking html table
                var index = result.IndexOf("<table class=\"ranking-tab\"");
                result = result.Substring(index);
                var endString = "</table>";
                index = result.IndexOf(endString);
                result = result.Substring(0, index + endString.Length);

                Console.WriteLine("Read HTML from URL OK");
                return result;
            }
        }
    }
}