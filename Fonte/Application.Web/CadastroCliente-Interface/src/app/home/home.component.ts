import { Component, OnInit } from '@angular/core';
import {VendedorService} from '../services/vendedor.service';
import {ClienteService} from '../services/cliente.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public serviceVendedor: VendedorService, public serviceCliente: ClienteService,
     public route: Router, public toast: MatSnackBar) { }

  public vendedores: any;
  public clientes: any;
  displayedColumns: string[] = ['nome', 'cpf', 'buttons'];
  displayColumnsCliente: string[] = ['nome', 'cnpj', 'nascimento', 'vendedor', 'buttons'];
  public selectedRowVendedor: any;
  public selectedRowCliente: any;

  editarCliente(cliente) {
    this.route.navigate(['/editarcliente/' + cliente.idCliente]);
  }
  editarVendedor(vendedor) {
    this.route.navigate(['/editarvendedor/' + vendedor.idVendedor]);
  }

  excluirCliente(cliente) {
    this.serviceCliente.Excluir(cliente.idCliente).subscribe((data: string) => {
        // mensagem com a resposta da requisiçao.
      this.toast.open(data, null, {duration: 3000});
       // recarrega a lista principal ao fazer alguma modificacao nos registros
      this.serviceCliente.Listar().subscribe(datacliente => {
        this.clientes = datacliente;
      }, error => console.log(error));
    },
    erro => {
      this. toast.open(erro.error, null, {duration: 3000})});
  }
  excluirVendedor(vendedor) {
    this.serviceVendedor.Excluir(vendedor.idVendedor).subscribe((data: string) => {
      // mensagem com a resposta da requisiçao.
      this.toast.open(data, null, {duration: 3000});
      // recarrega a lista principal ao fazer alguma modificacao nos registros
      this.serviceVendedor.Listar().subscribe(dataVend => {
        this.vendedores = dataVend;
      }, error => console.log(error));
    },
    erro => {
      this. toast.open(erro.error, null, {duration: 3000})});
  }

  ngOnInit() {
    // busca os clientes e vendedores.
    this.serviceVendedor.Listar().subscribe(data => {
      this.vendedores = data;
      this.serviceCliente.Listar().subscribe(datacliente => {
        this.clientes = datacliente;
      }, error => console.log(error));
    }, error => console.log(error));

  }

}
