export class StrickerStat {
  public totalGoals: number;

  constructor(
    public player: string,
    public championshipGoals: number,
    public nationalCupGoals: number,
    public regionalCupGoals: number,
    public otherCupGoals: number
  ) {
    this.totalGoals =
      championshipGoals + nationalCupGoals + regionalCupGoals + otherCupGoals;
  }
}
