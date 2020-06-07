import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { SearchPipe } from './pipes/search.pipe';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { GameComponent } from './components/game/game.component';
import { GameScoreComponent } from './components/game-score/game-score.component';
import { GuideComponent } from './components/guide/guide.component';
import { CompetitionComponent } from './components/competition/competition.component';
import { TeamNamePipe } from './pipes/team-name';
import { PitchComponent } from './components/pitch/pitch.component';
import { WidgetComponent } from './components/widget/widget.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GameWidgetComponent } from './components/game-widget/game-widget.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { ArticleComponent } from './components/article/article.component';

import { EventTypeComponent } from './components/event-type/event-type.component';
import { LogoComponent } from './components/logo/logo.component';
import { GameLetterPipe } from './pipes/game-letter.pipe';
import { PlayerDetailsComponent } from './components/player-details/player-details.component';

@NgModule({
  imports: [CommonModule, FormsModule, RouterModule, ReactiveFormsModule],
  declarations: [
    SearchPipe,
    TeamNamePipe,
    LoadingSpinnerComponent,
    GameComponent,
    GameScoreComponent,
    GuideComponent,
    CompetitionComponent,
    PitchComponent,
    WidgetComponent,
    GameWidgetComponent,
    PageHeaderComponent,
    ArticleComponent,
    EventTypeComponent,
    LogoComponent,
    PlayerDetailsComponent,
    GameLetterPipe,
  ],
  exports: [
    SearchPipe,
    TeamNamePipe,
    GameComponent,
    GameScoreComponent,
    CompetitionComponent,
    PitchComponent,
    PlayerDetailsComponent,
    WidgetComponent,
    GameWidgetComponent,
    PageHeaderComponent,
    ArticleComponent,
    EventTypeComponent,
    LogoComponent,
    GameLetterPipe,
  ],
})

// Contains components, directives and pipes that are shared accross the modules
export class SharedModule {}
