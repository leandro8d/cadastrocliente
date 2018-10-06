<h3>Projeto Cadastro de Clientes</h3>
<p> Projeto desenvolvido em asp.net core 2.0, sql server 2017 e Angular 6. </p>
<p><h3>Estrutura de Pastas</h3></p>
<pre>
<b>Fonte/Application.Web</b> --Arquivos do front-end em angular 6
<b>Fonte/Application.WebService</b> --Projeto .net core com os controllers
<b>Fonte/Domain</b> --Projeto com os arquivos de domínio(Entidades e Dtos)
<b>Fonte/Repository</b> --Projeto com repositorios de cada entidade e context de conexão.
<b>Fonte/Repository/ModelMapper</b> --Pasta onde encontra o context de conexão
<b>Banco</b> --Contem um .bkp do banco e um .sql do banco de dados da aplicação.
</pre>
<p><h3>Padrões de Projeto Utilizado</h3></p>
<pre>
DTO - Utilizado para trafegar somente a informação necessaria para interface.
Singleton - Criação unica ativa de um objeto, impossibilita ser instanciado mais de 1 vez.
"DDD" - Estruturação do projeto, com camada de aplicação e repositório.
</pre>
<p><h3>Pontos Importantes</h3></p>
<pre>
<b>Fonte/Repository/DomainBase.cs</b> --Classe abstrata onde os repositorios deverão obrigatoriamente 
herdar pois a classe DomainBase.cs contém metodos genericos que são utilizados por todos os
repositorios, como exemplo as operações de CRUD, sem a necessidade que cada repositório crie
novamente esses metodos, deixando somente as consultas específicas de cada repositório.

<b>Repositório</b> -- São classes que cada entidade possui, para fazer consultas específicas ao banco de dados.

<b>Entidades</b> --Espelho das entidades do BD, porém com metodos e operações especiais de auxílio e etc.
Consistência dos dados.

<b>CadastroUsuarioContext.cs</b> --Contexto de conexão com banco de dados, mapeamento das entidades e etc.
Foi utilizado o conceito de singleton para que qualquer projeto que necessite utilizar o BD, não
crie outra conexão, que pegue a conexão ativa do projeto.

</pre>

<p><h3>Diagrama do Banco de Dados</h3></p>
![Image](https://github.com/leandro8d/cadastrocliente/blob/master/bd-diagram.jpg?raw=true)
