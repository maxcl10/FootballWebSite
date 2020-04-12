import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchPipe } from './pipes/search.pipe';
import { FrDatePipe } from './pipes/fr-date-pipe';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { GameComponent } from './components/game/game.component';
import { GameScoreComponent } from './components/game-score/game-score.component';
import { GuideComponent } from './components/guide/guide.component';
import { CompetitionComponent } from './components/competition/competition.component';
import { TeamNamePipe } from './pipes/team-name';
import { PitchComponent } from '../shared/components/pitch/pitch.component';
import { WidgetComponent } from './components/widget/widget.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [CommonModule, FormsModule, HttpClientModule, ReactiveFormsModule],
  declarations: [
    SearchPipe,
    FrDatePipe,
    TeamNamePipe,
    LoadingSpinnerComponent,
    GameComponent,
    GameScoreComponent,
    GuideComponent,
    CompetitionComponent,
    PitchComponent,
    WidgetComponent,
  ],
  exports: [
    SearchPipe,
    FrDatePipe,
    TeamNamePipe,
    GameComponent,
    GameScoreComponent,
    CompetitionComponent,
    PitchComponent,
    WidgetComponent,
  ],
})

// Contains components, directives and pipes that are shared accross the modules
export class SharedModule {}
