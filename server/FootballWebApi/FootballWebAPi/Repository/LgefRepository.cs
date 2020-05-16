using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using HtmlAgilityPack;

namespace FootballWebSiteApi.Repository
{
    public class LgefRepository : ILgefRepository
    {
        public List<JGame> GetGames(string url, int clubId)
        {
            HtmlWeb web = new HtmlWeb();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var htmlDoc = web.Load(string.Format(url, clubId));
            List<JGame> games = new List<JGame>();
            var nodes = htmlDoc.DocumentNode.SelectNodes("//*[@class=\"confrontation\"]");
            if (nodes == null)
            {
                Console.WriteLine("Check proxy");


            }
            else
            {
                foreach (var item in nodes)
                {
                    JGame game = new JGame();
                    var date = item.SelectSingleNode("*/div[@class=\"date\"]");
                    game.Competition = date.ChildNodes[1].ChildNodes[0].InnerText;

                    if (!game.Competition.StartsWith("U11-"))
                    {
                        game.CompetitionShort = CleanCompetition(date.ChildNodes[1].ChildNodes[0].InnerText);
                        //game.Competitioni = GetGroup(date.ChildNodes[1].ChildNodes[2].InnerText);
                        CultureInfo culture = new CultureInfo("fr-FR");
                        var group = GetGroup(date.ChildNodes[1].ChildNodes[2].InnerText);

                        game.MatchDate = DateTime.ParseExact(date.ChildNodes.Last().InnerText.Trim(), "dddd dd MMMM yyyy - HH\\Hmm", culture);

                        var homeTeam = item.SelectSingleNode("*/div[@class=\"detail\"]/div[1]").InnerText.Trim();
                        game.HomeTeam = CleanTeam(homeTeam);


                        var awayTeam = item.SelectSingleNode("*/div[@class=\"detail\"]/div[3]").InnerText.Trim();
                        game.AwayTeam = CleanTeam(awayTeam);

                        try
                        {

                            // game.CompetitionId = ExtractId(item.SelectSingleNode("a").Attributes[0].Value);
                            var competitionId = ExtractId(item.SelectSingleNode("a").Attributes[0].Value);


                            string ranking = "https://lgef.fff.fr/recherche-clubs/?scl=9504&tab=resultats&subtab=ranking&competition={0}&stage=1&group={1}&label={2}";
                            var rankingdoc = web.Load(string.Format(ranking, game.CompetitionId, group, game.Competition).Replace(" ", "%20"));



                            var rankingList = GetRanking(rankingdoc);

                            game.HomeTeamScore = rankingList.Single(o => o.Team == homeTeam).Position;
                            game.AwayTeamScore = rankingList.Single(o => o.Team == awayTeam).Position;
                        }
                        catch (Exception)
                        {
                            game.HomeTeamScore = 0;
                            game.AwayTeamScore = 0;
                        }


                        games.Add(game);
                    }
                }
            }
            return games.OrderBy(o => GetOrder(o.CompetitionShort)).ToList();
        }

        //public static void DisplayGames(List<Game> games)
        //{
        //    foreach (var game in games.OrderBy(o => GetOrder(o.CleanedCompetition)))
        //    {
        //        Console.WriteLine(game.PositionTeam1 + " " + game.Team1 + " - " + game.Team2 + " " + game.PositionTeam2);
        //        Console.WriteLine(UpperCaseFirst(game.CleanedCompetition) + " - " + UpperCaseFirst(game.Date.ToString("dddd dd MMMM - HH\\Hmm", culture)));
        //        Console.WriteLine("");
        //    }
        //}

        public static string UpperCaseFirst(string s)
        {
            return s.First().ToString().ToUpper() + s.Substring(1).ToLower();
        }

        public static int GetOrder(string competition)
        {
            if (competition == "REGIONAL 2")
            {
                return 0;
            }
            if (competition == "REGIONAL 3")
            {
                return 1;
            }
            else if (competition == "DISTRICT 2")
            {
                return 2;
            }
            else if (competition == "DISTRICT 4")
            {
                return 3;
            }
            else if (competition == "U18 EXCELLENCE")
            {
                return 4;
            }
            else if (competition == "U18 PROMOTION")
            {
                return 5;
            }

            return 10;


        }

        private static int GetGroup(string innerText)
        {
            var split = innerText.Split(' ');
            if (split[0] == "GROUPE")
            {
                if (split[1] == "G")
                {
                    return 7;
                }
                else if (split[1] == "I")
                {
                    return 9;
                }
                else if (split[1] == "C")
                {
                    return 3;
                }
            }
            else if (split[0] == "POULE")
            {
                if (split[1] == "Q")
                {
                    return 6;
                }
            }

            return 1;
        }

        private static string ExtractId(string value)
        {
            var result = Regex.Match(value, "\\/competitions\\/\\?competition_id=([0-9]{6})");
            if (result.Success)
            {
                return result.Groups[1].Value;
            }

            return null;
        }

        public static List<JRanking> GetRanking(HtmlDocument htmlDoc)
        {
            List<JRanking> rankings = new List<JRanking>();

            foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//*[@id=\"competition-ranking\"]/div/div/div/table"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    JRanking ranking = new JRanking();

                    HtmlNodeCollection cells = row.SelectNodes("td");

                    if (cells == null)
                    {
                        continue;
                    }

                    ranking.Position = int.Parse(cells[0].InnerText);
                    ranking.Team = cells[1].InnerText.Trim();
                    ranking.Points = int.Parse(cells[2].InnerText);
                    ranking.MatchPlayed = int.Parse(cells[3].InnerText);
                    ranking.MatchWon = int.Parse(cells[4].InnerText);
                    ranking.MatchDraw = int.Parse(cells[5].InnerText);
                    ranking.MatchLost = int.Parse(cells[6].InnerText);
                    ranking.Withdaw = int.Parse(cells[7].InnerText);
                    ranking.GoalsScored = int.Parse(cells[8].InnerText);
                    ranking.GoalsAgainst = int.Parse(cells[9].InnerText);
                    ranking.Penality = int.Parse(cells[10].InnerText);
                    ranking.GoalDifference = int.Parse(cells[11].InnerText);


                    rankings.Add(ranking);
                }
            }

            return rankings;
        }

        private static string CleanTeam(string team)
        {
            var last = team.Last();
            string add = string.Empty;
            if (int.TryParse(last.ToString(), out int result))
            {
                add = ToRoman(result);
            }

            if (team.Contains("EJPS"))
            {
                team = "EJPS";
            }

            if (team.Contains("BARTENHEIM"))
            {
                team = "FCB";
            }

            if (team.Contains(" "))
            {

                return team.Remove(team.IndexOf(" "));
            }

            if (add != string.Empty)
            {
                team += " " + add;
            }

            return team;

        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        private static string CleanCompetition(string competition)
        {
            if (competition.Contains("ALSACE"))
            {
                return competition.Remove(competition.IndexOf("ALSACE") - 1);
            }

            if (competition.Contains("68"))
            {
                return competition.Remove(competition.IndexOf("68") - 1);
            }


            return competition;
        }
    }
}
