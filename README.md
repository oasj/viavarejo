# viavarejo

O projeto foi escrito em Visual Studio 2010. A solução consiste em 4 projetos distintos:

1) Backend.Models - armazena os modelos de dados e métodos de extensão utilizados com o Entity Framework e para shallow copy de objetos.
2) Backend.Services - WEBAPI contendo controllers para CRUD de amigos e pesquisa de amigos próximos
3) Backend.Tests - testes unitários do WEBAPI
4) Frontend.Client - cliente em Windows Forms que exibe os amigos e, a cada seleção, exibe os amigos mais próximos

Para efeitos de performance, a cada inserção de um novo amigo, o sistema cria um cache das distâncias entre ele e os demais amigos previamente cadastrados, calculando a distância em quilometros. Quando a coordenada geográfica de um amigo é alterada, o cache para esse amigo é recalculado.

Três tabelas são utilizadas para armazenar os dados:

1) [ViaVarejo].[Amigos] - armazena o nome, o local e a coordenada geográfica dos amigos
2) [ViaVarejo].[Cache] - armazena o cache de distância entre amigos
3) [ViaVarejo].[Log] - armazena o log de cálculo do cache de distâncias (latitude de origem e destino em radianos, theta da longitude, seno, coseno, ângulo, e distância em milhas e kilometros)

O token de acesso é armazenado na seção [appSettings] com o nome [AccessToken] dos respectivos App.Config (testes unitários e cliente) e Web.Config (backend WEBAPI). Já o string de conexão é armazena na seção [connectionStrings] com o nome [DadosAmigos] dos respectivos arquivos de configuração.

O backend WEBAPI contém três controladores:

1) AmigosController - contém as APIS de amigos
2) IdController - contém APIS utilitárias utilizadas pricipalmente para o ASSERT dos testes
3) ProximosControler - contém as APIS para encontrar os amigos próximos

O token de acesso é enviado como JSON no corpo da requisição HTTP (poderia ser no cabeçalho e criptografado). Os parâmetros das APIs são enviadas como querystring. Existem métodos HTTP POST, PUT e DELETE para o AmigosController que representam o CRUD dos amigps. Para os demais controllers só existe método POST. É utilizado POST para enviar o token de acesso no corpo da requisição HTTP.




