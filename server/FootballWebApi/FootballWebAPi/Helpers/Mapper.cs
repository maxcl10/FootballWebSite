using System.Collections.Generic;
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

        private static JCompetition Map(Competition competition)
        {
            return new JCompetition
            {
                CompetitionId = competition.competitionId,
                CompetitionType = competition.competitionType,
                Name = competition.name,
                ShortName = competition.shortName
            };
        }

        internal static JSponsor Map(Sponsor sponsor)
        {
            return new JSponsor
            {
                Name = sponsor.name,
                LogoUrl = sponsor.logoUrl,
                OrderIndex = sponsor.orderIndex,
                SiteUrl = sponsor.siteUrl,
                SponsorId = sponsor.sponsorId
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
                EventId = gameEvent.GameEventId,
                EventType = gameEvent.EventType.EventName,
                EventTypeId = gameEvent.EventTypeId,
                GameId = gameEvent.PlayerGame.GameId,
                GamePlayerId = gameEvent.PlayeGameId,
                PlayerId = gameEvent.PlayerGame.PlayerId,
                Time = gameEvent.Time,
                PlayerFirstName = gameEvent.PlayerGame.Player.firstName,
                PlayerLastName = gameEvent.PlayerGame.Player.lastName
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
                Team = lazyRankingitem.team,
                MatchPlayed = lazyRankingitem.matchPlayed,
                MatchWon = lazyRankingitem.matchWon,
                MatchDraw = lazyRankingitem.matchDraw,
                MatchLost = lazyRankingitem.matchLost,
                Position = lazyRankingitem.position,
                Points = lazyRankingitem.points,
                GoalDifference = lazyRankingitem.goalDifference,
                GoalsAgainst = lazyRankingitem.goalsAgainst,
                GoalsScored = lazyRankingitem.goalsScored,
                Penality = lazyRankingitem.penality,
                Withdaw = lazyRankingitem.withdaw

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
                UserId = user.id,
                Email = user.emailAddress.Trim(),
                Alias = user.alias,
                FirstName = user.firstName,
                LastName = user.lastName
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
                PlayerName = stat.Player.firstName + " " + stat.Player.lastName,
                PlayerFirstName = stat.Player.firstName,
                PlayerLastName = stat.Player.lastName,
                PlayerId = stat.playerId,
                ChampionshipGoals = stat.championshipGoals ?? 0,
                NationalCupGoals = stat.nationalCupGoals ?? 0,
                OtherCupGoals = stat.otherCupGoals ?? 0,
                RegionalCupGoals = stat.regionalCupGoals ?? 0,
                ChampionshipAssists = stat.championshipAssists ?? 0,
                TotalGoals = GetTotalGoals(stat.championshipGoals, stat.nationalCupGoals, stat.regionalCupGoals, stat.otherCupGoals)
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
                Address = owner.address,
                City = owner.city,
                EmailAddress = owner.emailAddress,
                Facebook = owner.facebook,
                History = owner.history,
                Name = owner.name,
                LongName = owner.longName,
                OwnerId = owner.ownerId,
                PhoneNumber = owner.phoneNumber,
                Stadium = owner.stadium,
                Youtube = owner.youtube,
                ZipCode = owner.zipCode,
                GoogleMap = owner.googleMap,
                FacebookLikeUrl = owner.facebookLikeUrl,
                LogoUrl = owner.logoUrl,
                Nickname = owner.nickname
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
                Id = article.id,
                Body = article.body,
                CreationDate = article.creationDate,
                DeletedDate = article.deletedDate,
                ModifiedDate = article.modifiedDate,
                PublishedDate = article.publishedDate,
                Published = article.publishedDate.HasValue,
                Publisher = article.User.lastName + " " + article.User.firstName,
                Title = article.title,
                GameId = article.gameId
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
                Id = player.id,
                Position = player.position,
                DateOfBirth = player.dateOfBirth,
                FirstName = player.firstName,
                Height = player.height,
                LastName = player.lastName,
                Nationality = player.nationality,
                PreviousClubs = player.previousClubs,
                Weight = player.weight,
                FavoriteNumber = player.favoriteNumber,
                FavoritePlayer = player.favoritePlayer,
                FavoriteTeam = player.favoriteTeam,
                Nickname = player.nickname
            };
        }

        internal static JGamePlayer Map(PlayerGame playerGame)
        {
            return new JGamePlayer
            {
                Id = playerGame.PlayerGameId,
                PlayerId = playerGame.PlayerId,
                PlayerFirstName = playerGame.Player.firstName,
                PlayerLastName = playerGame.Player.lastName,
                Position = playerGame.Position,
                GlobalPosition = playerGame.Player.position
            };
        }

        internal static Team Map(JTeam jteam)
        {
            return new Team
            {
                id = jteam.Id,
                name = jteam.Name,
                shortName = jteam.ShortName,
                displayName = jteam.DisplayName,
                displayOrder = jteam.DisplayOrder,
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
                Id = team.id,
                Name = team.name,
                ShortName = team.shortName,
                DisplayOrder = team.displayOrder,
                DisplayName = team.displayName,
                CalendarUrl = team.calendarUrl,
                RankingUrl = team.rankingUrl
            };
        }
    }
}
