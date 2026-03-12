🚀 Como Rodar o Projeto
1. Escolha sua Ferramenta
Você precisará de uma IDE para rodar o código. Recomendo o Visual Studio 2022 ou o VS Code.

2. Configure seu Banco de Dados
Abra o arquivo appsettings.json e coloque o nome do seu servidor no campo DefaultConnection:

JSON
"DefaultConnection": "Server=COLOQUE_AQUI;Database=MeuBanco;Trusted_Connection=True;"
3. Crie as Tabelas (Migrations)
Com o projeto aberto, você precisa rodar o comando para o banco de dados ser criado automaticamente.

No Visual Studio: Abra o Console do Gerenciador de Pacotes e digite:

PowerShell
Update-Database
No VS Code / Terminal: Digite:

Bash
dotnet ef database update
4. Só dar o Play
Agora é só apertar F5 ou clicar no botão de "Play" da sua IDE. O navegador vai abrir com o Swagger para você testar os endpoints.

🛠️ O que foi usado:
Linguagem: C# (.NET)

Banco: SQL Server

ORM: Entity Framework Core
