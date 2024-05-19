# ProjetoWebStore

# Rotas e estrutura dde cada uma
GET /seller
retorno:
{
	"id": 0,
	"name": "string",
	"creationDate": "0000-00-00"
}
GET /seller/{id}
retorno:
{
	"id": 0,
	"name": "string",
	"creationDate": "0000-00-00"
}
GET /products
retorno:
{
	"id": 0,
	"sellerId": 0,
	"seller": "string",
	"name": "string",
	"price": 0,
	"description": ""
}
GET /products/{id}
retorno:
{
	"id": 0,
	"sellerId": 0,
	"name": "string",
	"price": 00.00,
	"description": "string"
}
POST /seller
entrada:
{
  "name": "string"
}
retorno:
{
	"id": 0,
	"name": "string",
	"creationDate": "0000-00-00"
}
POST /products
entrada:
{
  "sellerId": 0,
  "name": "string",
  "price": 0,
  "description": "string"
}
retorno:
{
	"id": 0,
	"sellerId": 0,
	"name": "string",
	"price": 00.00,
	"description": "string"
}
PUT /seller/{id}
entrada:
{
  "name": "string"
}
retorno:
204 No Content
PUT /products/{id}
entrada:
{
  "name": "string",
  "price": 0,
  "description": "string"
}
retorno:
204 No Content
DELETE /seller/{id}
retorno: 200 OK
DELETE /products/{id}
retorno: 200 OK
