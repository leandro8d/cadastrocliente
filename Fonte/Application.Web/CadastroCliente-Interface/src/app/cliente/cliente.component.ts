import { Component, OnInit } from '@angular/core';
import {ClienteService} from '../services/cliente.service';
import {VendedorService} from '../services/vendedor.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  constructor(public clienteService: ClienteService, public vendedorService: VendedorService,
    public route: ActivatedRoute, public router: Router, public toast: MatSnackBar) { }

  public cliente: any = {};
  private cnpjValido: any = {status: '0', data: {message: 'CNPJ Invalido!'} };
  public vendedores: any = [];
  public inclusao = true;

    // faz uma requisiçao a cada letra digitada para verificar o cnpj.
  public validarCnpj(cnpj: object) {
    if (cnpj && cnpj.toString().length === 14) {
    this.clienteService.ValidarCnpj(cnpj).subscribe(data => {
        this.cnpjValido = data;
      } );
    } else {
      this.cnpjValido = {status: '0', data: {message: 'CNPJ Invalido!'} };
    }

  }

  public adicionarEditar(cliente) {
    if (this.inclusao) {
    this.clienteService.Inserir(cliente).subscribe((data: string) => {
     this. toast.open(data, null, {duration: 3000});
     this.router.navigate(['/editarcliente']);
    });

    } else {
    this.clienteService.Editar(cliente).subscribe((data: string) => {
      this.toast.open(data, null, {duration: 3000});
      this.router.navigate(['/editarcliente']);
    },
    erro => {
      this. toast.open(erro.error, null, {duration: 3000})});
    }
  }

  ngOnInit() {
    // lista vendedores sem clientes vinculados para carregar o dropdown. 
    // O relacionamento e 1 > n, porem para fazer um metodo mais especifico
    // para exemplificar o uso do repositorio foi usado isso.

    this.vendedorService.GetVendedoSemClientes().subscribe(data => this.vendedores = data);

    // pega parametro enviado via url.
    this.route.params.subscribe(params => {
       if (params['id']) {
          this.clienteService.GetCliente(params['id']).subscribe(data => {
            this.cliente = data;
            // caso haja um parametro, significa que e a ediçao de um registro.
            this.inclusao = false;
            this.validarCnpj(this.cliente.cnpj);
            this.vendedorService.GetVendedor(this.cliente.idVendedor).subscribe(dataVendedor => this.vendedores.push(dataVendedor));
          });
       }
    });
  }

}
