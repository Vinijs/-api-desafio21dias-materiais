# Comandos iniciais:
``` bash
  mkdir -api-desafio21dias-materiais
  cd -api-desafio21dias-materiais
  dotnet new webapi
```

# Comandos git:
``` bash
  code .gitignore 
```
#### Gerei o conteúdo para ignorar como (Windows, Linux, Mac, DotnetCore, VisualStudioCore) no link: https://www.toptal.com/developers/gitignore
- Criei o repositório e rodei os comandos

``` bash
  git init
  git add .
  git commit -m "Iniciando projeto"
  git remote add origin github.com/Vinijs/api-desafio-21dias.git
  git branch -M main
  git push -u origin main
```

# Componentes instalados:
``` bash
  dotnet add package Microsoft.EntityFrameworkCore --version 7.0.11
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.11
  dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.11
  dotnet add package Swashbuckle.AspNetCore --version 6.5.0
  dotnet add package EntityFrameworkPaginateCore --version 2.1.0
  dotnet add package EntityFrameworkCore.UseRowNumberForPaging --version 0.4.0
```

# Comandos para migração para criar:
``` bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add MateriaisAdd
dotnet ef database update
```

# Comandos para atualizar database
#### Caso você esteja usando essa aplicação com o código clonado, rodar o comando abaixo
``` bash
dotnet ef database update
```