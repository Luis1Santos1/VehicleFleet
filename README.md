# Vehicle Fleet Management API

A Vehicle Fleet Management API é uma aplicação de gerenciamento de frota de veículos que permite o registro de informações de veículos, seguros, proprietários e histórico de manutenção. Esta API fornece operações CRUD (Criar, Ler, Atualizar, Excluir) para cada uma dessas entidades, permitindo um controle eficiente de sua frota de veículos.


Funcionalidades Principais

Vehicle (Veículo):
Cadastrar um novo veículo com informações detalhadas, como marca, modelo, ano de fabricação, placa e cor.
Associar um veículo a um proprietário.
Registrar ou atualizar informações de seguro de veículo.
Manter um registro de histórico de manutenção para cada veículo.

Owner (Proprietário):
Registrar um novo proprietário com informações pessoais, como nome, CPF, endereço e telefone.
Associar veículos a um proprietário.
Visualizar a lista de veículos de um proprietário específico.

Vehicle Insurance (Seguro de Veículo):
Registrar informações de seguro de veículo, incluindo seguradora, número da apólice e datas de início e término.
Associar um seguro a um veículo específico.

Maintenance History (Histórico de Manutenção):
Registrar detalhes de manutenção, como data da manutenção, tipo de serviço e custo.
Associar um registro de manutenção a um veículo.


Tecnologias Utilizadas

ASP.NET Core: Framework utilizado para construir a API.
Entity Framework Core: Ferramenta de ORM (Object-Relational Mapping) para interação com o banco de dados.
SQL Server: Banco de dados utilizado para armazenar os dados da aplicação.


Configuração do Projeto

Pré-requisitos:
Certifique-se de ter o SDK do .NET Core instalado no seu ambiente de desenvolvimento.

Clonar o Repositório:
git clone https://github.com/seu-usuario/vehicle-fleet-api.git


Configuração do Banco de Dados:
Edite a string de conexão com o banco de dados no arquivo appsettings.json.

Executar as Migrações:
Execute o seguinte comando para aplicar as migrações ao banco de dados:
dotnet ef database update

Executar a Aplicação:
Execute a aplicação com o comando:
dotnet run

Documentação da API:
Acesse a documentação da API no endpoint /swagger para obter detalhes sobre os endpoints e como usá-los.

Uso da API
Acesse a documentação da API para obter informações detalhadas sobre como usar os endpoints disponíveis.
