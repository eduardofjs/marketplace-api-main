# marketplace-api
O backend do marketpalce da Directto conte a API de integração e módulos de cadastro, produtos, compradores, etc

# Package
Para Windows 10 com o Visual Studio 2019 configurado.

- Baixar o codigo fonte do projeto e fazer Build/Publish via Visual Studio 2019 com os packages disponiveis no S3; ou
- Acessar o codigo fonte do projeto ebrir Powershell no modo admin na pasta raiz e rodar o script:

Obs.: Certifique-se de que os paths no script apontam para os caminhos corretos.
```
Package.ps1
```

O package será gerado e enviado para o AWS.

# Deploy

## Para deploy no ambiente de TEST

- Acessar a instancia Windows no AWS'
- Baixar o respositorio Git do projeto marketplace-api (se já não baixado)
- Abrir Powershell no modo admin e executar o script abaixo:

Obs.: Certifique-se de que os paths no script apontam para os caminhos corretos.
```
Deploy.ps1
```

## Para deploy no ambiente de PROD

Por ser uma tarefa mais critica, estamos adotando o deploy manual. 

Portanto, mover os arquivos do IIS ambiente TEST para o ambiente PROD, a excecao dos arquivos de configuracao "*.config" e os arquivos de template, a saber:

- Database.config
- Web.config
- log4net.config
- Secrets.config
