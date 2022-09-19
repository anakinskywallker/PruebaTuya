Prueba Tecnica TUYA: en este repositorio se encuentra la prueba para aplicar al cargo de desarrrollador Backend para la compañia TUYA.

Arquitectura: 

Ha pesar de la envergadura de la prueba se consideró la implementación de una arquitectura de microservicios ya que es una de las arquitecturas más escalables y mantenibles a corto y largo plazo adicionalmente fomenta el trabajo en equipo y facilita el despliegue y el testing.

La solución cuenta con tres APIs una centralizada para gestionar los procesos denominada en este caso API Gateway, de ahí se desprenden las dos peticiones solicitadas a los servicios de logística y facturación.

Servicios:

A continuación, se presentan los endPoints de los servicios desarrollados, adicionalmente en el repositorio se encuentra una colección Postman denominado (Prueba Tuya.postman_collection) con las funciones principales de la solución.

EndPoints servicios 

API Gateway:   http://localhost:52270/

API Facturas:  http://localhost:33278

API Logistica:  http://localhost:9634

Base de datos:

Ya que se trata de arquitectura de microservicios se hicieron dos bases de datos una para el servicio de Facturas y otra para el de Logística, los scripts se encuentran en el repositorio mencionado con los nombres: 

BD FACTURAS
BD PEDIOS


Descripción del Funcionamiento:  

Se construyo un controlador en Api Gateway el cual permite recibir la información necesaria, en este caso como no se especificó el tipo de comercio, se asumió como si se tratara de una tienda de ropa teniendo en cuenta que es una factura se debe tener información tanto de la fecha la cantidad de producto etc,

Después de que esta Api recibe la información la envía a a los dos servicios que están dispuestos el uno para almacenar y dar información de las facturas y su valor, y el otro que esta diseñado para indicar los pedidos y en que estado se encuentran, por ejemplo, si el pedido esta pendiente o listo para ser enviado 



Los enpoints están desarrollados para que la respuesta sea síncrona ya que no se vio necesario implementar algún bus de mensajería, adicionalmente se utilizó inyección de dependencias que se registraron en startup de Api Gateway para trabajar con ellas a la hora de orquestar los dos servicios que se utilizaron.

¡ A quien corresponda , muchas gracias por su tiempo al revisar este trabajo ¡ cordialmente, Andres Rodrigo Lopez Realpe 
