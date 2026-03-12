🚀 Primeiros Passos - Sistema de Assinantes
Este projeto utiliza .NET com Entity Framework Core. Siga as instruções abaixo para configurar o ambiente e rodar a aplicação.

🛠️ Pré-requisitos
Antes de começar, você precisará escolher e instalar uma IDE para rodar o projeto:

Visual Studio 2022 (Recomendado para Windows)

VS Code (Com as extensões de C# instaladas)

JetBrains Rider

⚙️ 1. Configuração do Banco de Dados
Para que o sistema funcione, você precisa apontar para o seu banco de dados local (SQL Server).

No projeto principal, localize o arquivo appsettings.json.

Altere a ConnectionString no campo DefaultConnection.

JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SUA_INSTANCIA;Database=NomeDoSeuBanco;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
Nota: Substitua SUA_INSTANCIA pelo nome do seu servidor (ex: localhost ou .\SQLEXPRESS).

📂 2. Rodando as Migrations
Com a conexão configurada, você precisa criar as tabelas no banco de dados. Escolha o método dependendo da sua IDE:

Via Visual Studio (Console do Gerenciador de Pacotes)
Abra o console em Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes e digite:

PowerShell
Update-Database
Via Terminal (VS Code / CLI)
Abra o terminal na pasta raiz do projeto e digite:

Bash
dotnet ef database update
🏃 3. Executando a Aplicação
Certifique-se de que o projeto de inicialização (Startup Project) é o da camada de API ou Apresentation.

Pressione F5 ou use o comando:

Bash
dotnet run
O Swagger deverá abrir automaticamente no seu navegador.

💡 Dicas
Se encontrar erro de "comando não encontrado" ao rodar dotnet ef, instale a ferramenta globalmente com:

dotnet tool install --global dotnet-ef

Verifique se o serviço do SQL Server está rodando antes de aplicar as migrations.
