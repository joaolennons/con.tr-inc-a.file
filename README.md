# con.tr-inc-a.file

### Instruções

Execute o arquivo run.bat que está na raíz do repositório (assumi que está em um windows  ¯\_(ツ)_/¯): 
  - publica o *backend* e levanta o servidor no Kestrel na porta 5000; 
    - [Swagger da Api](http://localhost:5000/swagger "Swagger da Api")

- instala as dependências do *frontend* e levanta em um servidor local na porta 4200, essa compilação não é com as otimizações de *prod*.

### Arquitetura do backend
No *backend* foi adotada uma arquitetura baseada em eventos, as *controllers* recebem por injeção de dependência uma *ApplicationService*  que serve como uma fachada para o domínio. As interfaces de *ApplicationServices* estão em um assembly separado por servirem apenas de *proxy* para o domínio ainda que *by-the-book* elas façam parte dele. 

As *ApplicationServices*  concretas criam um *command* através de *builders* e "despacham" os eventos através de um *mediator*. Cada *command* é manipulado por um *commandHandler* que processa a lógica de domínio e pode ou não publicar uma notificação de que o *command* foi manipulado. Cada notificação publicada é manipulada por um *notificationHandler* que executa uma ação baseada na notificação.

A arquitetura também simula um *CQRS* ainda que com a mesma base para escrita e leitura. 
- O assembly *Write* possui repositórios que fazem a escrita do dados no banco através de repositórios usando o *EntityFramework Core*.
- O assembly *Read* possui repositórios de somente leitura que se conecta via ADO utilizando o *Dapper* . As *queries*  são executadas e os resultados são projetados em dtos.
