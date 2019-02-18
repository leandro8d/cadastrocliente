<h3> Client Master Project </h3>
<p> Project developed in ASP.NET MVC 2.0 core, sql server 2017 and Angular 6. </p>
<p> <h3> Folder Structure </h3> </p>
<pre>
<b> Source / Application.Web </b> - Angular front-end files 6
<b> Source / Application.WebService </b> - .net core project with controllers
<b> Source / Domain </b> --Project with Domain Files (Entities and Dtos)
<b> Source / Repository </b> --Project with repositories of each entity and connection context.
<b> Source / Repository / ModelMapper </b> --Place where you find the connection context
<b> Bank </b> - Contains a .bkp from the database and an .sql from the application database.
</pre>
<p> <h3> Design Patterns Used </h3> </p>
<pre>
DTO - Used to only traffic information required for interface.
Singleton - Unique creation of an object, impossible to be instantiated more than 1 time.
"DDD" - Project structuring, with application layer and repository.
</pre>
<p> <h3> Important Points </h3> </p>
<pre>
<b> Source / Repository / DomainBase.cs </b> - Abstract class where repositories should necessarily
inherit because the class DomainBase.cs contains generic methods that are used by all
repositories, such as CRUD operations, without the need for each repository to create
again, leaving only the specific queries of each repository.

<b>Repository</b> - These are classes that each entity has, to make specific queries to the database.

<b>Entities</b> - Mirror of DB entities, but with special methods and operations of aid and etc.
Consistency of the data.

<b>CadastroUsuarioContext.cs</b> --Connection database with database, entities mapping and etc.
The concept of singleton was used so that any project that needs to use the BD,
create another connection, which takes the active project connection.

</pre>

<p> <h3>Database Diagram</h3> </p>
https://github.com/leandro8d/cadastrocliente/blob/master/bd-diagram.jpg?raw=true
