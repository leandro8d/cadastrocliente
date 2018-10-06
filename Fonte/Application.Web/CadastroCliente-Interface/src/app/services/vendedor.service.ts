import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VendedorService {

  constructor(private http: HttpClient) { }

  public GetVendedor(id) {
    return this.http.get('http://localhost:51079/vendedor/' + id);
  }

  public Excluir(id) {
    return this.http.delete('http://localhost:51079/vendedor/' + id);
  }

  public GetVendedoSemClientes() {
    return this.http.get('http://localhost:51079/vendedor/vendedorsemcliente',
     {params: new HttpParams().set('foo', JSON.stringify(new Date()))});
  }

  public Listar() {
    return this.http.get('http://localhost:51079/vendedor/listar', {params: new HttpParams().set('foo', JSON.stringify(new Date()))});
  }

  public Inserir(vendedor: any) {
    return this.http.put('http://localhost:51079/vendedor', vendedor);
  }

  public Editar(vendedor: any) {
    return this.http.post('http://localhost:51079/vendedor', vendedor);
  }

  public ValidarCpf(cpf) {
    return this.http.get('http://geradorapp.com/api/v1/cpf/validate/' + cpf + '?token=6c82ec1d3850addc7fbbf14a1fd46071');
  }

}
