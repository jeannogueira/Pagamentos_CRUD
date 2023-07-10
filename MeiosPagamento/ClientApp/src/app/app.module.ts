import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PagamentoComponent } from './pagamento/pagamento.component';
import { PagamentoDataService } from './_data-services/pagamento.data-service';

@NgModule({
  declarations: [
    AppComponent,
    PagamentoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PagamentoComponent, pathMatch: 'full' },
    ])
  ],
  providers: [PagamentoDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
