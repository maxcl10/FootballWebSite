using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FootballWebSiteApi.Helpers
{
    public static class Mapper
    {
        public static IEnumerable<JGame> Map(IEnumerable<Game> games)
        {
            List<JGame> Jgames = new List<JGame>();
            foreach (Game game in games)
            {
                Jgames.Add(Map(game));
            }
            return Jgames;
        }

        public static IEnumerable<JCompetition> Map(IEnumerable<Competition> competitions)
        {
            List<JCompetition> Jcompetitions = new List<JCompetition>();
            foreach (Competition competition in competitions)
            {
                Jcompetitions.Add(Map(competition));
            }
            return Jcompetitions;
        }

        private static JCompetition Map(Competition competition)
        {
            return new JCompetition
            {
                competitionId = competition.competitionId,
                competitionType = competition.competitionType,
                name = competition.name,
                shortName = competition.shortName
            };
        }

        internal static JSponsor Map(Sponsor sponsor)
        {
            return new JSponsor
            {
                name = sponsor.name,
                logoUrl = sponsor.logoUrl,
                orderIndex = sponsor.orderIndex,
                siteUrl = sponsor.siteUrl,
                sponsorId = sponsor.sponsorId
            };
        }

        internal static List<JEvent> Map(IQueryable<GameEvent> events)
        {
            List<JEvent> retEvents = new List<JEvent>();
            foreach (var eventItem in events)
            {
                retEvents.Add(Map(eventItem));
            }
            return retEvents;
        }

        internal static JEvent Map(GameEvent gameEvent)
        {
            return new JEvent
            {
                eventId = gameEvent.GameEventId,
                eventType = gameEvent.EventType.EventName,
                eventTypeId = gameEvent.EventTypeId,
                gameId = gameEvent.PlayerGame.GameId,
                gamePlayerId = gameEvent.PlayeGameId,
                playerId = gameEvent.PlayerGame.PlayerId,
                time = gameEvent.Time,
                playerFirstName = gameEvent.PlayerGame.Player.firstName,
                playerLastName = gameEvent.PlayerGame.Player.lastName
            };
        }

        internal static List<JRanking> Map(IEnumerable<LazyRanking> lazyRanking)
        {
            List<JRanking> jrankings = new List<JRanking>();
            foreach (var lazyRankingitem in lazyRanking)
            {
                jrankings.Add(Map(lazyRankingitem));
            }

            return jrankings;
        }

      

        private static JRanking Map(LazyRanking lazyRankingitem)
        {
            return new JRanking
            {
                team = lazyRankingitem.team,
                matchPlayed = lazyRankingitem.matchPlayed,
                matchWon = lazyRankingitem.matchWon,
                matchDraw = lazyRankingitem.matchDraw,
                matchLost = lazyRankingitem.matchLost,
                position = lazyRankingitem.position,
                points = lazyRankingitem.points,
                goalDifference = lazyRankingitem.goalDifference,
                goalsAgainst = lazyRankingitem.goalsAgainst,
                goalsScored = lazyRankingitem.goalsScored,
                penality = lazyRankingitem.penality,
                withdaw = lazyRankingitem.withdaw

            };
        }

        internal static List<JStricker> Map(IQueryable<PlayerTeam> stats)
        {
            List<JStricker> jStrickers = new List<JStricker>();
            foreach (PlayerTeam stat in stats)
            {
                jStrickers.Add(Map(stat));
            }
            return jStrickers;
        }

        internal static JUser Map(User user)
        {
            return new JUser
            {
                userId = user.id,
                email = user.emailAddress.Trim(),
                alias = user.alias,
                firstName = user.firstName,
                lastName = user.lastName
            };
        }

        internal static IEnumerable<JCompetitionSeason> Map(IEnumerable<TeamCompetitionSeason> competitions)
        {
            var retCompetitions = new List<JCompetitionSeason>();
            foreach (var competition in competitions)
            {
                retCompetitions.Add(Map(competition));
            }

            return retCompetitions;
        }

        internal static JCompetitionSeason Map(TeamCompetitionSeason teamCompetitionSeason)
        {
            return new JCompetitionSeason
            {
                Name = teamCompetitionSeason.CompetitionSeason.Competition.name,
                Group = teamCompetitionSeason.competitionGroup,
                Season = teamCompetitionSeason.CompetitionSeason.Season.name,
                ShortName = teamCompetitionSeason.CompetitionSeason.Competition.shortName,
                CompetitionId = teamCompetitionSeason.CompetitionSeason.competitionId
            };
        }

        public static JStricker Map(PlayerTeam stat)
        {
            return new JStricker
            {
                playerName = stat.Player.firstName + " " + stat.Player.lastName,
                playerFirstName = stat.Player.firstName,
                playerLastName = stat.Player.lastName,
                playerId = stat.playerId,
                championshipGoals = stat.championshipGoals ?? 0,
                nationalCupGoals = stat.nationalCupGoals ?? 0,
                otherCupGoals = stat.otherCupGoals ?? 0,
                regionalCupGoals = stat.regionalCupGoals ?? 0,
                championshipAssists = stat.championshipAssists ?? 0,
                totalGoals = GetTotalGoals(stat.championshipGoals, stat.nationalCupGoals, stat.regionalCupGoals, stat.otherCupGoals)
            };
        }

        private static int? GetTotalGoals(params int?[] goals)
        {
            return goals.Sum();
        }

        internal static List<JSponsor> Map(IOrderedQueryable<Sponsor> sponsors)
        {
            List<JSponsor> jSponsors = new List<JSponsor>();
            foreach (var sponsor in sponsors)
            {
                jSponsors.Add(Map(sponsor));
            }
            return jSponsors;
        }

        internal static JOwner Map(Owner owner)
        {
            return new JOwner
            {
                address = owner.address,
                city = owner.city,
                emailAddress = owner.emailAddress,
                facebook = owner.facebook,
                history = owner.history,
                name = owner.name,
                longName = owner.longName,
                ownerId = owner.ownerId,
                phoneNumber = owner.phoneNumber,
                stadium = owner.stadium,
                youtube = owner.youtube,
                zipCode = owner.zipCode,
                googleMap = owner.googleMap,
                facebookLikeUrl = owner.facebookLikeUrl,
                logoUrl = owner.logoUrl,
                nickname = owner.nickname
            };
        }

        public static JGame Map(Entities.Game game)
        {
            return new JGame
            {
                Id = game.Id,
                AwayTeamId = game.AwayTeam,
                AwayTeam = game.Team1.name,
                HomeTeamId = game.HomeTeam,
                HomeTeam = game.Team.name,
                Championship = game.Championship,                
                CompetitionId = game.CompetitionId,
                Competition = game.Competition?.name,
                CompetitionShort = game.Competition?.shortName,
                MatchDate = game.MatchDate,
                SeasonId = game.SeasonId,
                HomeTeamScore = game.HomeTeamScore,
                AwayTeamScore = game.AwayTeamScore,

                HomeExtraTimeScore = game.ProlongHomeTeamScore,
                AwayExtraTimeScore = game.ProlongAwayTeamScore,

                HomePenaltyScore = game.PenaltyHomeTeamScore,
                AwayPenaltyScore = game.PenaltyAwayTeamScore,
            };
        }

        public static IEnumerable<JArticle> Map(IEnumerable<Article> articles)
        {
            List<JArticle> jArticles = new List<JArticle>();
            foreach (Article article in articles)
            {
                jArticles.Add(Map(article));
            }
            return jArticles;
        }

        public static JArticle Map(Article article)
        {
            return new JArticle
            {
                id = article.id,
                body = article.body,
                creationDate = article.creationDate,
                deletedDate = article.deletedDate,
                modifiedDate = article.modifiedDate,
                publishedDate = article.publishedDate,
                published = article.publishedDate.HasValue,
                publisher = article.User.lastName + " " + article.User.firstName,
                title = article.title,
                gameId = article.gameId
            };
        }

        internal static IEnumerable<JPlayer> Map(IOrderedEnumerable<Player> orderedEnumerable)
        {
            List<JPlayer> jPlayers = new List<JPlayer>();
            foreach (Player player in orderedEnumerable)
            {
                jPlayers.Add(Map(player));
            }
            return jPlayers;
        }

        internal static JPlayer Map(Entities.Player player)
        {
            return new JPlayer
            {
                id = player.id,
                position = player.position,
                dateOfBirth = player.dateOfBirth,
                firstName = player.firstName,
                height = player.height,
                lastName = player.lastName,
                nationality = player.nationality,
                previousClubs = player.previousClubs,
                weight = player.weight,
                favoriteNumber = player.favoriteNumber,
                favoritePlayer = player.favoritePlayer,
                favoriteTeam = player.favoriteTeam,
                nickname = player.nickname
            };
        }

        internal static JGamePlayer Map(PlayerGame playerGame)
        {
            return new JGamePlayer
            {
                id = playerGame.PlayerGameId,
                playerId = playerGame.PlayerId,
                playerFirstName = playerGame.Player.firstName,
                playerLastName = playerGame.Player.lastName,
                position = playerGame.Position,
                globalPosition = playerGame.Player.position
            };
        }

        internal static Team Map(JTeam jteam)
        {
            return new Team
            {
                id = jteam.id,
                name = jteam.name,
                shortName = jteam.shortName,
                displayName = jteam.displayName,
                displayOrder = jteam.displayOrder,
            };
        }

        public static IEnumerable<JTeam> Map(IEnumerable<Team> teams)
        {
            List<JTeam> JTeams = new List<JTeam>();
            foreach (var team in teams)
            {
                JTeams.Add(Map(team));
            }
            return JTeams;
        }

        public static JTeam Map(Team team)
        {
            return new JTeam
            {
                id = team.id,
                name = team.name,
                shortName = team.shortName,
                displayOrder = team.displayOrder,
                displayName = team.displayName,
                calendarUrl = team.calendarUrl,
                rankingUrl = team.rankingUrl
            };
        }
    }
}
