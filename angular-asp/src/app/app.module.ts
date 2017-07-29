import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { TimerComponent } from './timer/timer.component';
import { GameComponent } from './game/game.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GameResultsComponent } from './game/game-results/game-results.component';

import { WordService } from './services/words.service';
import { GameRunComponent } from './game/game-run/game-run.component';
import { CapitalizationPipe } from './capitalization.pipe';

@NgModule({
  declarations: [
    AppComponent,
    TimerComponent,
    GameComponent,
    GameResultsComponent,
    DashboardComponent,
    NavbarComponent,
    GameRunComponent,
    CapitalizationPipe
  ],
  imports: [
    BrowserModule,
    HttpModule,
    RouterModule.forRoot([
      {
        path: 'playboard',
        component: GameComponent 
      },
      {
        path: 'view-results',
        component: GameResultsComponent
      },
      {
        path: 'game-run',
        component: GameRunComponent
      }
    ])
  ],
  providers: [WordService],
  bootstrap: [AppComponent]
})
export class AppModule { }
