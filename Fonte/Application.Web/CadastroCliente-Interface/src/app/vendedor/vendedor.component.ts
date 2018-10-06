import { Component, OnInit } from '@angular/core';
import {VendedorService} from '../services/vendedor.service';
import {MatSnackBar} from '@angular/material';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-vendedor',
  templateUrl: './vendedor.component.html',
  styleUrls: ['./vendedor.component.css']
})
export class VendedorComponent implements OnInit {

  constructor(public vendedorService: VendedorService, public toast: MatSnackBar,
     public route: ActivatedRoute,public router: Router) { }

  private cpfValido: any = {status: '0', data: {message: 'CPF Invalido!'} };
  public vendedor: any = {};
  public inclusao = true;

  // faz uma requisiçao a cada letra digitada para verificar o cpf.
  public validarCpf(cpf: object) {
    if (cpf && cpf.toString().length === 11) {
    this.vendedorService.ValidarCpf(cpf).subscribe(data => {
        this.cpfValido = data;
      } );
    } else {
      this.cpfValido = {status: '0', data: {message: 'CPF Invalido!'} };
    }

  }

  public adicionarEditar(vendedor) {
    if (this.inclusao) {
      this.vendedorService.Inserir(vendedor).subscribe((data: string) => {
       this. toast.open(data, null, {duration: 3000})});
       this.router.navigate(['/editarcliente']);
      } else {
      this.vendedorService.Editar(vendedor).subscribe((data: string) => {
        this. toast.open(data, null, {duration: 3000});
        this.router.navigate(['/editarcliente']);
      },
      erro => {
        this. toast.open(erro.error, null, {duration: 3000})});
      }
  }

  ngOnInit() {
// pega parametro enviado via url.
    this.route.params.subscribe(params => {
      if (params['id']) {
         this.vendedorService.GetVendedor(params['id']).subscribe(data => {
           this.vendedor = data;
           // caso haja um parametro na url, significa que e uma ediçao. 
           this.inclusao = false;
           this.validarCpf(this.vendedor.cpf);
         });
      }
   });
  }

}
