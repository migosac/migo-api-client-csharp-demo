## Migo API C# Demo
Aplicación consola de ejemplo para consumir servicio de validación de datos [Migo API](https://api.migo.pe/)

Requiere .NET Core 5.0 o superior, código compatible con .NET Framework

## Uso

<ol>
<li>Clonar repositorio</li>

<li>Abrir o crear el archivo appsettings.json </li>

<li>Copiar o editar el siguiente contenido ingresando su token en la propiedad "token". (Es necesario crear una cuenta gratuita en [Migo API](https://api.migo.pe/)).</li>

```json
{
    "token": "Copiar token aquí"
}
```

<li>Ejecuta los siguientes comandos</li>

```bash
dotnet restore
```

```bash
dotnet run
```
</ol>
