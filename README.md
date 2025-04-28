# PresentationService

Presentation Service

## Instalación de `dotnet-ef`

Si no tienes instalado `dotnet-ef`, ejecuta el siguiente comando:

```bash
dotnet tool install dotnet-ef
```

## Pasos para configurar el proyecto

1. Ejecuta el siguiente comando para agregar una migración inicial:
    ```bash
    dotnet ef migrations add presentacionInit --project Infrastructure --startup-project PresentationService --output-dir Migrations
    ```
2. Verifica que la conexión a tu base de datos sea correcta en el archivo `appsettings.json`.
3. Actualiza la base de datos ejecutando:
    ```bash
    dotnet ef database update --project Infrastructure --startup-project PresentationService
    ```
4. Construye el proyecto:
    ```bash
    dotnet build
    ```
5. Ejecuta la aplicación desde la ruta `/Template`:
    ```bash
    dotnet run
    ```

---

## Estructura del proyecto (Clean Architecture)

### Application

Contiene cuatro carpetas principales:

- **Request**: Aquí se colocan los DTOs para las solicitudes.
- **Response**: Aquí se colocan los DTOs para las respuestas.
- **UserCase**: Contiene las implementaciones de los servicios.
- **Interfaces**: Contiene las interfaces. En la raíz se ubican los servicios, y se organizan en dos carpetas:
  - **Commands**: Interfaces para los comandos.
  - **Queries**: Interfaces para las consultas.

### Domain

Contiene las entidades del dominio.

### Infrastructure

Contiene tres carpetas principales:

- **Commands**: Implementaciones de los comandos.
- **Queries**: Implementaciones de las consultas.
- **Migrations**: Migraciones creadas para la base de datos (estas se ignoran en Git).

### Template

- Contiene una carpeta `Controllers` donde se ubican los controladores.
- Incluye las configuraciones necesarias para levantar la aplicación.
- Recuerda configurar correctamente el archivo `appsettings.json` para usar la base de datos.

