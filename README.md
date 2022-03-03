# Tutorial Market API
Vamos ao passo-a-passo para executar o **Market API**.
### Instalações Necessárias:
- [.Net Core 3.1.100](https://download.visualstudio.microsoft.com/download/pr/9065e596-b3fa-4255-b4ba-aab624ace4ba/634172a4677a39aff1f761b4c728d01d/dotnet-sdk-3.1.110-win-x64.exe) (Se for a primeira instalação, é necessário reiniciar a máquina, depois pode-se seguir o restante).
- Se estiver utilizando o **Visual Studio Code**, deve-se instalar uma **extensão C#**, uma sugestão [clique aqui](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
- [Postman](https://www.postman.com/downloads/) **(Opcional)**.

### Execução:
- Abra o projeto, como foi feito no **Visual Studio Code**, os procedimentos vão ser com base nessa **IDE**.
- Após abrir, execute os comandos na sequência:
``` dotnet restore ```
``` dotnet build ```
``` dotnet run ```
- Em seguida, pode-se usar o Postman ou Navegador para consultar API pela URL:
``` http://localhost:5001/api/categories ``` ou ``` http://localhost:5000/api/categories ```
``` http://localhost:5001/api/products ``` ou ``` http://localhost:5000/api/products ```
> **Nota:** Caso esteja usando o Postman, é necessário desativar a configurações **Enable SSL certificate verification**.
- Para executar testes melhores, também é possível usar o **Swagger**, acessando https://localhost:5001/swagger/index.html.

### Heroku:
- https://marketapi1.herokuapp.com/swagger/index.html
- https://marketapi1.herokuapp.com/api/products
- https://marketapi1.herokuapp.com/api/categories

### Pacotes Utilizados: 
- AutoMapper versão 11.0.1
- AutoMapper Dependency Injection 11.0.0
- EntityFrameworkCore 3.1.0
- EntityFrameworkCore In Memory 3.1.0
- EntityFrameworkCore Tools 3.1.0