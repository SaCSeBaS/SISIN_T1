# SISIN T1

Examen T1 del curso Sistemas Inteligentes.

## Integrantes

* Arribasplata Chávarri, Luis Sebastián - N00048640
* Cornejo Chunga, Daniel Badinho - N00070150

### Enunciado

La cuadricula que se muestra en el grafico 1 es una cuadricula de 30 x 30, en la cual se muestra un laberinto y donde se debe considerar:

* Existen 4 caminos por donde el carro puede llegar a la meta.
* El recorrido o la iteración del carro es de cuadro por cuadro.
* El carro puede moverse a cualquiera de las 4 direcciones (izquierda, derecha, arriba y abajo).
* Se inicia en la posición (1,1) y se llega a la meta en la posición (30, 30).
* Se debe preguntar si en la siguiente iteración propuesta esta bloqueada o libre (negro bloqueado y blanco libre) y decidir si se avanza o no.

Se pide:

* Representar el espacio de problemas.
* Desarrollar un programa de software que encuentre las posibles soluciones y determine cual es la ruta más optima. La ruta mas optima es la que use menos cuadriculas para legar a la meta.
* El programa debe ser desarrollado basado en lógica y no código en duro
* Debe existir una representación gráfica de las soluciones (espacio de problemas). Esta representación no tiene que ser necesariamente con un icono de un carrito, si es en consola se puede representar el movimiento con una X, o un color tipo serpiente.

### Laberinto

![alt text](https://user-images.githubusercontent.com/29410332/80855055-43e39400-8c03-11ea-8d8e-1cde496cbc9c.png "Laberinto")

### Solución

Para la presente solución se procedió a utilizar el algoritmo de búsqueda en anchura (Breadth First Search), el cual permite realizar una búsqueda desinformada de un punto final dado un punto incial, en este caso la coordenada (0,0) es el punto inicial y la coordenada (29,29) es el punto final. Conforme se va recorriendo las posibles alternativas y caminos (validando siempre y cuando que el carro pueda realizar dicho movimiento) se va generando un árbol, el cual por cada nivel significa un paso (coordenada) a seguir. 
Puesto que este algoritmo trabaja por niveles y de manera uniforme en cada nivel, la primera solución que halle será la que menos pasos tendrá, sin necesidad de encontrar el resto de caminos posibles.

### Imágenes

#### Estado Inicial
![alt text](https://user-images.githubusercontent.com/29410332/80855226-07b13300-8c05-11ea-925c-a4746385021b.png "Estado Inicial")

#### Estado X
![alt text](https://user-images.githubusercontent.com/29410332/80855227-0aac2380-8c05-11ea-9dec-54a955416a17.png "Estado X")

#### Estado Final
![alt text](https://user-images.githubusercontent.com/29410332/80855229-0bdd5080-8c05-11ea-8824-93920e861953.png "Estado Final")
