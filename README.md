# ReservaBibliotecaSolution (.NET 8 + NUnit)

Proyecto educativo y profesional de ejemplo para pruebas unitarias en C# usando NUnit, basado en el análisis de requisitos, clases de equivalencia y buenas prácticas de diseño de pruebas.

---

##  ¿Cómo ejecutar el proyecto?

###  1. Clona el repositorio

```bash
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo
```

> Asegúrate de tener instalado [.NET 8 SDK](https://dotnet.microsoft.com/download) y Visual Studio Code (opcional).

---

### 2. Restaura dependencias y compila

```bash
dotnet restore
dotnet build
```

---

### 3. Ejecuta las pruebas

```bash
dotnet test
```

Esto ejecutará todos los casos definidos con NUnit y mostrará resultados detallados.

---

##  Descripción del problema

> "Un usuario puede reservar un libro si tiene estado ‘Normal’, el libro es reservable, no ha sido reservado antes, y la solicitud se hace en día hábil."

---

## Diseño de pruebas

Se utilizaron técnicas de **clases de equivalencia** para definir casos representativos y asegurar cobertura completa de la lógica.

### Clases válidas:
- Usuario con estado `"Normal"`
- Libro marcadamente reservable
- Día hábil
- No reservado anteriormente

###  Clases inválidas:
- Usuario con estado `"Sancionado"`, `"Bloqueado"`, etc.
- Libro no reservable
- Día no hábil (fin de semana o festivo)
- Ya reservado previamente

---

## Casos de prueba implementados

| ID   | Descripción                                 | Datos simulados                                                      | Resultado esperado |
|------|---------------------------------------------|----------------------------------------------------------------------|--------------------|
| TC1  | Caso totalmente válido                      | `"U001"`, `"Normal"`, `true`, `false`, `día hábil`                  | ✅ `true`          |
| TC2  | Usuario sin código                          | `""`, `"Normal"`, `true`, `false`, `día hábil`                      | ❌ `false`         |
| TC3  | Usuario con estado inválido ("Sancionado")  | `"U001"`, `"Sancionado"`, `true`, `false`, `día hábil`              | ❌ `false`         |
| TC4  | Libro no reservable                         | `"U001"`, `"Normal"`, `false`, `false`, `día hábil`                 | ❌ `false`         |
| TC5  | Libro ya reservado                          | `"U001"`, `"Normal"`, `true`, `true`, `día hábil`                   | ❌ `false`         |
| TC6  | Día no hábil                                | `"U001"`, `"Normal"`, `true`, `false`, `día no hábil`              | ❌ `false`         |

 
---

##  ¿Por qué estos casos son suficientes?

- Cubren **cada regla de negocio individual** y su combinación crítica
- Aplican diseño por **caja negra** y reducción por clases de equivalencia
- Permiten detectar defectos sin necesidad de pruebas redundantes
- Se pueden extender fácilmente a pruebas de integración o UI

---

## Tecnologías usadas

-  [.NET 8 SDK](https://dotnet.microsoft.com/download)
-  [NUnit 3](https://nunit.org/)
-  `NUnit3TestAdapter` para integración con `dotnet test`
-  Compatible con Visual Studio Code o Visual Studio

---

##  Estructura del proyecto

```
ReservaBibliotecaSolution/
├── Biblioteca/             
│   └── Reservas/ReservaService.cs       # Lógica de negocio
├── Biblioteca.Tests/
│   └── Reservas/ReservaServiceTests.cs  # Pruebas unitarias
├── ReservaBibliotecaSolution.sln
└── README.md
```

---

## Siguientes pasos sugeridos

- Medir cobertura con `coverlet.collector`
- Agregar validaciones contra fechas festivas reales
- Incluir pruebas de integración o mock con dependencias
- Automatizar con GitHub Actions o Azure Pipelines

---
