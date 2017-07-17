import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TimerComponent } from './timer/timer.component';
import { GameComponent } from './game/game.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GameResultsComponent } from './game/game-results.component';

import { WordService } from './services/words.service';

@NgModule({
  declarations: [
    AppComponent,
    TimerComponent,
    GameComponent,
    GameResultsComponent,
    DashboardComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {
        path: 'playboard',
        component: GameComponent 
      },
      {
        path: 'view-results',
        component: GameResultsComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
