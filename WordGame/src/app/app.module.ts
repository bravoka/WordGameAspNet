import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TimerComponent } from './timer/timer.component';
import { GameComponent } from './game/game.component';
import { TopNavbarComponent } from './top-navbar/top-navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GameResultsComponent } from './game/game-results/game-results.component';
import { GameRunComponent } from './game/game-run/game-run.component';
import { HomeComponent } from './home/home.component';

import { ResultService } from './services/results.service';
import { WordService } from './services/words.service';

import { CapitalizationPipe } from './capitalization.pipe';


@NgModule({
  declarations: [
    AppComponent,
    TimerComponent,
    GameComponent,
    GameResultsComponent,
    DashboardComponent,
    TopNavbarComponent,
    GameRunComponent,
    CapitalizationPipe,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: 'home',
        component: HomeComponent
      },
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
  providers: [
    WordService,
    ResultService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
