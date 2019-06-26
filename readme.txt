Miguel Salas.
Sustentación técnica:
- Uso de Postgresql: Debido a la limitacion de la libreria Pomelo.EntityFrameworkCore.MySql la cual no es compatible con .net Core 3.0 no fue posible usar el motor de bd de MySql para este trabajo. En su lugar, se uso Postgresql. Fuente: https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/740
- Con respecto al naming convention utilizado: Debido a que los namings conventions no son mas que acuerdos entre equipos, el que yo decidi usar fue el siguiente:
	names (identifiers): lower_case_with_underscores.
- HttpStatusCodes Responses: Para mantener simple y corta la cantidad de status codes a usar en todos los controllers, se usaron los siguientes:
	GET List: 200
	GET by Id: 200,404
	POST: 200
	PUT: 200,404
	DELETE: 200,404
 Otros escenarios mas complejos podrían requerir el uso de CreatedAtRoute, BadRequest, UnprocessableEntity, Conflict entre otros, dependiendo de la necesidad de cada endpoint.
- Identity para Net Core: Para proteger los endpoints se implemento Identity para net core y un controlador "Auth" encargado de la generacion de los tokens.
- Swagger: Con el fin de documentar los endpoints de manera automatica, se instaló la libreria de swashbuckle y configuró las convenciones de HttpStatusCodes correspondientes para cada verbo usando prefijos en los nombres de los endpoints.
