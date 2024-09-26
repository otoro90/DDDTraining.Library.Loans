### Tecnologías

* C# - Net 6.0
    * Microsoft.DependencyInjection
    * AutoMapper
    * Swashbuckle (swagger)
    * MediatR
    * Xunit (testing)
    * Moq (Mocking services)
    * FluentAssetions (fluent test framework)
* Docker
    * Dockerfile
    * docker-compose

### Diseño guiado por el dominio (DDD)

En este proyecto, hemos adoptado la metodología de Diseño guiado por el dominio (DDD) para estructurar y organizar nuestra arquitectura de software. DDD nos ha permitido enfocarnos en el núcleo del problema y crear un modelo de dominio que refleje fielmente el lenguaje y las reglas de negocio. Además, hemos identificado y aislado conceptos clave del dominio como entidades, agregados, servicios y eventos para mantener una arquitectura altamente cohesiva y desacoplada.

### Clean Arquitecture

En este proyecto, hemos implementado el principio de Clean Architecture para construir una arquitectura de software limpia y bien estructurada. La arquitectura sigue un enfoque de capas, donde las dependencias se definen en una sola dirección, asegurando una separación clara entre las distintas capas del sistema.

La capa más interna de la arquitectura es el dominio, que contiene la lógica de negocio y las entidades principales del problema. Esta capa es completamente independiente de cualquier marco o tecnología externa, lo que la hace altamente portable y reutilizable.

Encima del dominio, encontramos la capa de aplicación, que actúa como intermediaria entre el dominio y las capas externas, como la de infraestructura y la presentación(api). Aquí, se definen los casos de uso y se orquestan las operaciones del negocio utilizando los agregados y servicios del dominio.

La capa de infraestructura, por otro lado, contiene implementaciones concretas de los servicios externos, como bases de datos, servicios web y almacenamiento en caché. Para este caso usamos únicamente un repositorio con guardado en memoria mediante inyección de dependencia usando el patrón Singlenton para toda la aplicación y también ubicamos un diccionario de datos que probablemente a futuro si se extiende pueda ser migrado a un servicio externo o una base de datos.

El enfoque de Arquitecturas limpias nos ha permitido crear un sistema altamente flexible y mantenible. Además, al mantener una clara separación de preocupaciones, podemos realizar cambios y mejoras en una capa sin afectar otras partes del sistema, lo que promueve la escalabilidad y la evolución continua del proyecto.
