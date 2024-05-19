# ProjetoWebStore

# Rotas e estrutura dde cada uma
GET /seller <br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"name": "string", <br>
	"creationDate": "0000-00-00" <br>
}<br>
GET /seller/{id}<br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"name": "string", <br>
	"creationDate": "0000-00-00" <br>
} <br>
GET /products <br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"sellerId": 0, <br>
	"seller": "string", <br>
	"name": "string", <br>
	"price": 0, <br>
	"description": "" <br>
} <br>
GET /products/{id} <br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"sellerId": 0, <br>
	"name": "string", <br>
	"price": 00.00, <br>
	"description": "string" <br>
} <br>
POST /seller <br>
entrada: <br>
{ <br>
  "name": "string" <br>
} <br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"name": "string", <br>
	"creationDate": "0000-00-00" <br>
} <br>
POST /products <br>
entrada: <br>
{ <br>
  "sellerId": 0, <br>
  "name": "string", <br>
  "price": 0, <br>
  "description": "string" <br>
} <br>
retorno: <br>
{ <br>
	"id": 0, <br>
	"sellerId": 0, <br>
	"name": "string", <br>
	"price": 00.00, <br>
	"description": "string" <br>
} <br>
PUT /seller/{id} <br>
entrada: <br>
{ <br>
  "name": "string" <br>
} <br>
retorno: <br>
204 No Content <br>
PUT /products/{id} <br>
entrada: <br>
{ <br>
  "name": "string", <br>
  "price": 0, <br>
  "description": "string" <br>
} <br>
retorno: <br>
204 No Content <br>
DELETE /seller/{id} <br>
retorno: 200 OK <br>
DELETE /products/{id} <br>
retorno: 200 OK <br>
