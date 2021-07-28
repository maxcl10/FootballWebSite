using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;

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

        public static ClubEvent Map(JClubEvent jClubEvent)
        {
            return new ClubEvent
            {
                ClubEventId = jClubEvent.Id,
                Name = jClubEvent.Name,
                Description = jClubEvent.Description,
                StartDate = jClubEvent.StartDate,
                EndDate = jClubEvent.EndDate,
                Location = jClubEvent.Location,
                City = jClubEvent.City,
                ImageUrl = jClubEvent.ImageUrl,
                Canceled = jClubEvent.Canceled

            };
        }

        public static JClubEvent Map(ClubEvent clubEvent)
        {
            return new JClubEvent
            {
                Id = clubEvent.ClubEventId,
                Name = clubEvent.Name,
                City = clubEvent.City,
                Description = clubEvent.Description,
                EndDate = clubEvent.EndDate,
                Location = clubEvent.Location,
                StartDate = clubEvent.StartDate,
                ImageUrl = clubEvent.ImageUrl,
                Canceled = clubEvent.Canceled.GetValueOrDefault()
            };
        }

        public static IEnumerable<JClubEvent> Map(IEnumerable<ClubEvent> clubEvents)
        {
            return clubEvents.Select(o => Map(o));
        }

        private static JCompetition Map(Competition competition)
        {
            return new JCompetition
            {
                CompetitionId = competition.CompetitionId,
                CompetitionType = competition.CompetitionType,
                Name = competition.Name,
                ShortName = competition.ShortName
            };
        }

        internal static JSponsor Map(Sponsor sponsor)
        {
            return new JSponsor
            {
                Name = sponsor.Name,
                LogoUrl = sponsor.LogoUrl,
                OrderIndex = sponsor.OrderIndex,
                SiteUrl = sponsor.SiteUrl,
                SponsorId = sponsor.SponsorId
            };
        }

        internal static List<JGameEvent> Map(IQueryable<GameEvent> events)
        {
            List<JGameEvent> retEvents = new List<JGameEvent>();
            foreach (var eventItem in events)
            {
                retEvents.Add(Map(eventItem));
            }
            return retEvents;
        }

        internal static JGameEvent Map(GameEvent gameEvent)
        {
            return new JGameEvent
            {
                EventId = gameEvent.GameEventId,
                EventType = gameEvent.GameEventType.EventName,
                EventTypeId = gameEvent.EventTypeId,
                GameId = gameEvent.PlayerGame.GameId,
                GamePlayerId = gameEvent.PlayeGameId,
                PlayerId = gameEvent.PlayerGame.PlayerId,
                Time = gameEvent.Time,
                PlayerFirstName = gameEvent.PlayerGame.Player.FirstName,
                PlayerLastName = gameEvent.PlayerGame.Player.LastName
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
                Team = lazyRankingitem.Team,
                MatchPlayed = lazyRankingitem.MatchPlayed,
                MatchWon = lazyRankingitem.MatchWon,
                MatchDraw = lazyRankingitem.MatchDraw,
                MatchLost = lazyRankingitem.MatchLost,
                Position = lazyRankingitem.Position,
                Points = lazyRankingitem.Points,
                GoalDifference = lazyRankingitem.GoalDifference,
                GoalsAgainst = lazyRankingitem.GoalsAgainst,
                GoalsScored = lazyRankingitem.GoalsScored,
                Penality = lazyRankingitem.Penality,
                Withdaw = lazyRankingitem.Withdaw

            };
        }

        internal static List<JPlayerStats> Map(IQueryable<PlayerTeam> stats)
        {
            List<JPlayerStats> jStrickers = new List<JPlayerStats>();
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
                UserId = user.Id,
                Email = user.EmailAddress.Trim(),
                Alias = user.Alias,
                FirstName = user.FirstName,
                LastName = user.LastName
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
                Name = teamCompetitionSeason.CompetitionSeason.Competition.Name,
                Group = teamCompetitionSeason.CompetitionGroup,
                Season = teamCompetitionSeason.CompetitionSeason.Season.Name,
                ShortName = teamCompetitionSeason.CompetitionSeason.Competition.ShortName,
                CompetitionId = teamCompetitionSeason.CompetitionSeason.CompetitionId
            };
        }

        public static JPlayerStats Map(PlayerTeam stat)
        {
            return new JPlayerStats
            {
                PlayerName = stat.Player.FirstName + " " + stat.Player.LastName,
                PlayerFirstName = stat.Player.FirstName,
                PlayerLastName = stat.Player.LastName,
                PlayerId = stat.PlayerId,
                ChampionshipGoals = stat.ChampionshipGoals ?? 0,
                NationalCupGoals = stat.NationalCupGoals ?? 0,
                OtherCupGoals = stat.OtherCupGoals ?? 0,
                RegionalCupGoals = stat.RegionalCupGoals ?? 0,
                ChampionshipAssists = stat.ChampionshipAssists ?? 0,
                TotalGoals = GetTotalGoals(stat.ChampionshipGoals, stat.NationalCupGoals, stat.RegionalCupGoals, stat.OtherCupGoals)
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
                Address = owner.Address,
                City = owner.City,
                EmailAddress = owner.EmailAddress,
                Facebook = owner.Facebook,
                Instagram = owner.Instagram,
                History = owner.History,
                Name = owner.Name,
                LongName = owner.LongName,
                OwnerId = owner.OwnerId,
                PhoneNumber = owner.PhoneNumber,
                Stadium = owner.Stadium,
                Youtube = owner.Youtube,
                ZipCode = owner.ZipCode,
                GoogleMap = owner.GoogleMap,
                FacebookLikeUrl = owner.FacebookLikeUrl,
                LogoUrl = owner.LogoUrl,
                Nickname = owner.Nickname
            };
        }

        internal static IEnumerable<JEventType> Map(DbSet<GameEventType> eventTypes)
        {
            return eventTypes.Select(o => new JEventType
            {

                Id = o.GameEventTypeId,
                Name = o.EventName
            }).ToList();
        }

        public static JGame Map(Entities.Game game)
        {
            return new JGame
            {
                Id = game.GameId,
                AwayTeamId = game.AwayTeam,
                AwayTeam = game.Team1.Name,
                HomeTeamId = game.HomeTeam,
                HomeTeam = game.Team.Name,
                Championship = game.Championship,
                CompetitionId = game.CompetitionId,
                Competition = game.Competition?.Name,
                CompetitionShort = game.Competition?.ShortName,
                MatchDate = game.MatchDate,
                SeasonId = game.SeasonId,
                HomeTeamScore = game.HomeTeamScore,
                AwayTeamScore = game.AwayTeamScore,
                Postponed = game.Postponed.GetValueOrDefault(),
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
                Id = article.ArticleId,
                Body = article.Body,
                CreationDate = article.CreationDate,
                DeletedDate = article.DeletedDate,
                ModifiedDate = article.ModifiedDate,
                PublishedDate = article.PublishedDate,
                Published = article.PublishedDate.HasValue,
                Publisher = article.User.LastName + " " + article.User.FirstName,
                Title = article.Title,
                GameId = article.GameId,
                ImageUrl = article.ImageUrl,
                SubTitle = article.SubTitle,
                Type = article.ArticleTypeId,

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
                Id = player.PlayerId,
                Position = player.Position,
                DateOfBirth = player.DateOfBirth,
                FirstName = player.FirstName,
                Height = player.Height,
                LastName = player.LastName,
                Nationality = player.Nationality,
                PreviousClubs = player.PreviousClubs,
                Weight = player.Weight,
                FavoriteNumber = player.FavoriteNumber,
                FavoritePlayer = player.FavoritePlayer,
                FavoriteTeam = player.FavoriteTeam,
                Nickname = player.Nickname
            };
        }

        internal static JGamePlayer Map(PlayerGame playerGame)
        {
            return new JGamePlayer
            {
                Id = playerGame.PlayerGameId,
                PlayerId = playerGame.PlayerId,
                PlayerFirstName = playerGame.Player.FirstName,
                PlayerLastName = playerGame.Player.LastName,
                Position = playerGame.Position,
                GlobalPosition = playerGame.Player.Position
            };
        }

        internal static Team Map(JTeam jteam)
        {
            return new Team
            {
                TeamId = jteam.Id,
                Name = jteam.Name,
                ShortName = jteam.ShortName,
                DisplayName = jteam.DisplayName,
                DisplayOrder = jteam.DisplayOrder,
                OwnerId = jteam.OwnerId,
                AffiliationNumber = jteam.AffiliationNumber
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
                Id = team.TeamId,
                Name = team.Name,
                ShortName = team.ShortName,
                DisplayOrder = team.DisplayOrder,
                DisplayName = team.DisplayName,
                CalendarUrl = team.CalendarUrl,
                OwnerId = team.OwnerId,
                RankingUrl = team.RankingUrl,
                AffiliationNumber = team.AffiliationNumber
            };
        }
    }
}
