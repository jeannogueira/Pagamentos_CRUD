import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class PagamentoDataService {

  url : string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)  {
    this.url = baseUrl;

  }

  
  get() {
    return this.http.get(`${this.url}pagamentos`);
  }

  post(data: any):Observable<any> {
    return this.http.post(`${this.url}pagamentos`, data);
  }

  put(data: any) {
    return this.http.put(`${this.url}pagamentos`, data);
  }

  delete(codigo: any) {
    return this.http.delete(`${this.url}pagamentos/${codigo}`);
  }

}
