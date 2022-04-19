# WebImoveis

## Banco de dados:

```
CREATE TABLE [dbo].[Address] (
    [AddressId]    INT           IDENTITY (1, 1) NOT NULL,
    [Cep]          CHAR (8)      NOT NULL,
    [Street]       VARCHAR (100) NOT NULL,
    [Neighborhood] VARCHAR (100) NOT NULL,
    [Town]         VARCHAR (100) NOT NULL,
    [Uf]           CHAR (2)      NOT NULL
);

CREATE TABLE [dbo].[Property] (
    [PropertyId]  INT             IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100)   NOT NULL,
    [Description] VARCHAR (120)   NOT NULL,
    [Price]       DECIMAL (20, 2) NOT NULL,
    [AddressId]   INT             NOT NULL,
    [Number]      INT             NOT NULL
);
```

## Páginas acessíveis:

- /Properties/PropertyCreate: parte de criar do CRUD. Pega endereço pela API do Via CEP. Não permite cadastrar novos CEPs, nem casas com o mesmo número em determinado CEP;
- /Properties/PropertyList: lista todas as propriedades. Dá pra filtar pelo Nome e pelo CEP. Dá pra ordenar pelo Nome e pela Descrição. É possível acessar a página de edição e exclusão de itens por esta página também. As páginas de exclusão e edição recebem o Id da Propriedade via URL;
- /Properties/PropertyEdit: não permite alterar o número nem o CEP da casa para não ocorrer problemas com FK. Recebe o id via URL;
- /Properties/PropertyDelete: deleta propriedade. Não fiz nada para excluir o endereço para não criar bagunça nas propriedades.

## Coisas que fiz:

### WebImoveis.Application, WebImoveis.Domain e WebImoveis.Data

Tentativa de implantar DDD na aplicação. Tava vendo a vídeoaula do Eduardo Pires e travei na parte do AutoMapper, então decidi fazer sem os mapeamentos ou usar as classes de repositório. Chamo as Entidades direto nos Controles das páginas, além de chamar o Contexto do DB direto também.
Vai ver que tem umas classes de Repositório ali que não são usadas. Coloquei a chamada da API em "Services", mas creio que deveria ser um serviço de Address (classe de endereço). Mapeei as Entidades com o EF Core, ver Data.

## WebImoveis.WebApp:

Usei o Scaffolding do EF Core para fazer as páginas, então editei elas para fazer o que preciso. As páginas estão na pasta Pages/Property. O resto que está fora desta pasta é padrão do projetinho do ASP .NET Core.

## To-Do:

- Usar repositórios e ViewModels para não usar o Domínio diretamente;
- Otimizar consultas ao banco (talvez fazer uma lista estática quando abrir a página e manter ela aberta para não ter que ficar puxando do banco toda vez que aperta um botão);
- Imagens para as propriedades;
- Ordenação por preço (fiz por nome e descrição, mas por preço faria mais sentido);
- Adicionar filtro de ordenação para todos os atributos listados;
- Deixar a página mais bonita.

