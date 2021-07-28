import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { LogoService } from '../../../core/services/logo.service';
import { Game } from '../../../shared/models/game.model';
import { Event } from '../../../shared/models/event.model';
import { GamePlayer } from '../../../shared/models/game-player.model';
// import { html2canvas } from '../../../../../node_modules/html2canvas';

declare let html2canvas: any;

@Component({
  selector: 'fws-game-poster',
  templateUrl: './game-poster.component.html',
  styleUrls: ['./game-poster.component.scss'],
})
export class GamePosterComponent implements OnInit {
  public nextgame: Game;
  public nextgames: Game[];
  public lastgame: Game;
  public errorMessage: string;
  goals: Event[];
  players: GamePlayer[];
  game: Game;

  @ViewChild('lastGameDiv', { static: false }) lastGameDiv: ElementRef;
  @ViewChild('nextGameDiv', { static: false }) nextGameDiv: ElementRef;
  @ViewChild('scheduleDiv', { static: false }) scheduleDiv: ElementRef;
  @ViewChild('groupeDiv', { static: false }) groupeDiv: ElementRef;

  // @ViewChild('canvas') canvas: ElementRef;
  // @ViewChild('downloadLink') downloadLink: ElementRef;

  constructor(
    private gamesService: GamesService,
    private logoService: LogoService
  ) {}

  public ngOnInit() {
    this.getNextGame();
    this.getLastGame();
    this.getNextGames();

    this.getGame('0c0d815c-e690-4602-8425-9842161827b1');
  }

  public downloadScheduleImage() {
    const matchDate = new Date(this.lastgame.matchDate);
    const name =
      matchDate.getFullYear() +
      '' +
      ('0' + matchDate.getMonth()).slice(-2) +
      '' +
      ('0' + matchDate.getDate()).slice(-2) +
      '_Resulat';
    this.downloadImage(this.scheduleDiv, name);
  }

  public downloadPreviousGameImage() {
    const matchDate = new Date(this.lastgame.matchDate);
    const name =
      matchDate.getFullYear() +
      '' +
      ('0' + matchDate.getMonth()).slice(-2) +
      '' +
      ('0' + matchDate.getDate()).slice(-2) +
      '_Resulat';

    this.downloadImage(this.lastGameDiv, name);
  }
  public downloadNextGameImage() {
    const matchDate = new Date(this.nextgame.matchDate);
    const name =
      matchDate.getFullYear() +
      '' +
      ('0' + matchDate.getMonth()).slice(-2) +
      '' +
      ('0' + matchDate.getDate()).slice(-2);

    this.downloadImage(this.nextGameDiv, name);
  }

  public downloadGroupImage() {
    const matchDate = new Date(this.nextgame.matchDate);
    const name =
      matchDate.getFullYear() +
      '' +
      ('0' + matchDate.getMonth()).slice(-2) +
      '' +
      ('0' + matchDate.getDate()).slice(-2);

    this.downloadImage(this.groupeDiv, name);
  }

  public downloadImage(elementRef: ElementRef, fileName: string) {
    html2canvas(elementRef.nativeElement).then(function (canvas) {
      // document.body.appendChild(canvas);

      // Works only with chrome
      canvas.toBlob(function (blob) {
        // To download directly on browser default 'downloads' location
        const link = document.createElement('a');
        link.download = fileName + '.png';
        link.href = URL.createObjectURL(blob);
        link.click();
      }, 'image/png');
    });
  }

  //   let element = document.querySelector("#capture");
  //   html2canvas(document).then(function(canvas) {
  //       // Convert the canvas to blob
  //       canvas.toBlob(function(blob){
  //           // To download directly on browser default 'downloads' location
  //           let link = document.createElement("a");
  //           link.download = "image.png";
  //           link.href = URL.createObjectURL(blob);
  //           link.click();

  //           // To save manually somewhere in file explorer
  //           window.saveAs(blob, 'image.png');

  //       },'image/png');
  //   });

  // html2canvas(this.screen.nativeElement).then(canvas => {
  //   this.canvas.nativeElement.src = canvas.toDataURL();
  //   this.downloadLink.nativeElement.href = canvas.toDataURL('image/png');
  //   this.downloadLink.nativeElement.download = 'marble-diagram.png';
  //   this.downloadLink.nativeElement.click();
  // });
  //

  //   pdfDownload() {
  //     let self = this; // use this variable to access your class members inside then().
  //     html2canvas(document.body).then(canvas => {
  //         var imgData = canvas.toDataURL("image/png");
  //         self.AddImagesResource(imgData);
  //         document.body.appendChild(canvas);
  //    });
  // }

  public getLastGame() {
    this.gamesService.getLastGame().subscribe(
      (game) => {
        this.lastgame = game;
        this.lastgame.awayTeamLogoUrl = this.logoService.getLogoPath(
          this.lastgame.awayTeam,
          100
        );
        this.lastgame.homeTeamLogoUrl = this.logoService.getLogoPath(
          this.lastgame.homeTeam,
          100
        );
        this.gamesService.getGameEvents(game.id).subscribe((events) => {
          this.goals = events
            .filter((o) => o.eventTypeId === 0)
            .sort((a, b) => {
              return a.time - b.time;
            });
        });
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  public getNextGames() {
    this.gamesService.getNextGames().subscribe((games) => {
      this.nextgames = games;
      // this.nextgames.push(games[0]);
    });
  }

  private getGame(gameId: string) {
    this.gamesService.getGame(gameId).subscribe(
      (game) => {
        this.game = game;
        if (this.game != null) {
          this.game.awayTeamLogoUrl = this.logoService.getLogoPath(
            this.game.awayTeam,
            100
          );
          this.game.homeTeamLogoUrl = this.logoService.getLogoPath(
            this.game.homeTeam,
            100
          );
        }
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  private getNextGame() {
    this.gamesService.getNextGame().subscribe(
      (game) => {
        this.nextgame = game;
        if (this.nextgame != null) {
          this.nextgame.awayTeamLogoUrl = this.logoService.getLogoPath(
            this.nextgame.awayTeam,
            100
          );
          this.nextgame.homeTeamLogoUrl = this.logoService.getLogoPath(
            this.nextgame.homeTeam,
            100
          );
        }

        this.gamesService.getGamePlayers(this.nextgame.id).subscribe(
          (players) => {
            this.players = players;
          },
          (error) => (this.errorMessage = <any>error)
        );
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
}
