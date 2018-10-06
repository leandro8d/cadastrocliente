import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  public GetCliente(id) {
    return this.http.get('http://localhost:51079/cliente/' + id);
  }

  public Excluir(id) {
    return this.http.delete('http://localhost:51079/cliente/' + id);
  }

  public Listar() {
    return this.http.get('http://localhost:51079/cliente/listar');
  }

  public Inserir(cliente: any) {
    return this.http.put('http://localhost:51079/cliente', cliente);
  }

  public Editar(cliente: any) {
    return this.http.post('http://localhost:51079/cliente', cliente);
  }

  public ValidarCnpj(cnpj) {
    return this.http.get('http://geradorapp.com/api/v1/cnpj/validate/' + cnpj + '?token=6c82ec1d3850addc7fbbf14a1fd46071');
  }


}
