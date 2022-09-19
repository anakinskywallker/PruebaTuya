Prueba Tecnica TUYA: en este repositorio se encuentra la prueba para aplicar al cargo de desarrrollador Backend para la compa�ia TUYA.

Arquitectura: 

Ha pesar de la envergadura de la prueba se consider� la implementaci�n de una arquitectura de microservicios ya que es una de las arquitecturas m�s escalables y mantenibles a corto y largo plazo adicionalmente fomenta el trabajo en equipo y facilita el despliegue y el testing.

La soluci�n cuenta con tres APIs una centralizada para gestionar los procesos denominada en este caso API Gateway, de ah� se desprenden las dos peticiones solicitadas a los servicios de log�stica y facturaci�n.

Servicios:

A continuaci�n, se presentan los endPoints de los servicios desarrollados, adicionalmente en el repositorio se encuentra una colecci�n Postman denominado (Prueba Tuya.postman_collection) con las funciones principales de la soluci�n.

EndPoints servicios 

API Gateway:   http://localhost:52270/

API Facturas:  http://localhost:33278

API Logistica:  http://localhost:9634

Base de datos:

Ya que se trata de arquitectura de microservicios se hicieron dos bases de datos una para el servicio de Facturas y otra para el de Log�stica, los scripts se encuentran en el repositorio mencionado con los nombres: 

BD FACTURAS
BD PEDIOS


Descripci�n del Funcionamiento:  

Se construyo un controlador en Api Gateway el cual permite recibir la informaci�n necesaria, en este caso como no se especific� el tipo de comercio, se asumi� como si se tratara de una tienda de ropa teniendo en cuenta que es una factura se debe tener informaci�n tanto de la fecha la cantidad de producto etc,

Despu�s de que esta Api recibe la informaci�n la env�a a a los dos servicios que est�n dispuestos el uno para almacenar y dar informaci�n de las facturas y su valor, y el otro que esta dise�ado para indicar los pedidos y en que estado se encuentran, por ejemplo, si el pedido esta pendiente o listo para ser enviado 



Los enpoints est�n desarrollados para que la respuesta sea s�ncrona ya que no se vio necesario implementar alg�n bus de mensajer�a, adicionalmente se utiliz� inyecci�n de dependencias que se registraron en startup de Api Gateway para trabajar con ellas a la hora de orquestar los dos servicios que se utilizaron.

� A quien corresponda , muchas gracias por su tiempo al revisar este trabajo � cordialmente, Andres Rodrigo Lopez Realpe 
