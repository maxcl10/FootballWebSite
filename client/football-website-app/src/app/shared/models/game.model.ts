export class Game {
  public id: string;
  public homeTeamId: string;
  public awayTeamId: string;
  public matchDate: Date;
  public seasonId: string;
  public championship: string;
  public competitionId: string;
  public competition: string;
  public competitionShort: string;
  public homeTeam: string;
  public awayTeam: string;
  public homeTeamScore: number;
  public awayTeamScore: number;
  public homeExtraTimeScore: number;
  public awayExtraTimeScore: number;
  public homePenaltyScore: number;
  public awayPenaltyScore: number;
  public homeTeamLogoUrl: string;
  public awayTeamLogoUrl: string;
  public result: string;
  public ownerTeam: string;
  public postponed: boolean;
}
