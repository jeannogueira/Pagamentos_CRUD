import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagamentoDataService } from '../_data-services/pagamento.data-service';

@Component({
  selector: 'app-home',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.css']
})


export class PagamentoComponent implements OnInit {

  pagamentos: any = [];
  pagamento: any = {};
  codigo: any;
  tipo_template = 1;

  constructor(private pagamentoDataService: PagamentoDataService) { }

  ngOnInit() {
   
  }

  changeTipoPagamento(tipo: string) {
    if (tipo === 'Boleto') {
      this.tipo_template = 1;
    }
    else {
      this.tipo_template = 2;
    }
    
  }

  listar() {
    this.pagamentoDataService.get().subscribe(data => {
      this.pagamentos = data;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  save() {
    this.pagamentoDataService.post(this.pagamento).subscribe(data => {
      if (data) {
        alert('Pagamento cadastrado com sucesso');
        this.pagamento = {};
      } else {
        alert('Por favor, realizar o preenchimento de todos os campos!');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  edit(pagamento: any) {
    this.pagamentoDataService.put(pagamento).subscribe(codigo => {
      if (codigo) {
        alert('Pagamento atualizado com sucesso');
        this.listar();
        this.pagamento = {};
      } else {
        alert('Erro ao atualizar Pagamento');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  delete(codigo: any) {
    this.pagamentoDataService.delete(codigo).subscribe(codigo => {
      if (codigo) {
        alert('Pagamento excluído com sucesso');
        this.listar();
      } else {
        alert('Erro ao excluir Pagamento');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

}
