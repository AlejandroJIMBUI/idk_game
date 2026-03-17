<div style="text-align: center;">
    <h1>Proyecto POO - Juego ARPG</h1>
    <p>Andres David Quijano Alvarez</p>
    <p>Jherson Alejandro Buitrago Jimenez</p>
</div>

---

### *Diagrama Causa Efecto*
![Diagrama Causa Efecto](../../graphics/diagrama_causa_efecto.svg)
<br></br>


### *Diagrama de Objetivos*
![Diagrama de Objetivos](../../graphics/diagrama_objetivos.svg)

### *Tabla de objetivos*
| Nombre | Objetivo | Duración / Frecuencia | Cómo / Dónde | Problemas |
|------|------|------|------|------|
| P1 Diseñar mecánicas de combate | O1, R1 | Se realiza durante la fase de mecánicas core (semanas 4–6), con iteraciones continuas durante los sprints. | Implementación y pruebas dentro del motor Godot, utilizando scripts en C# y escenas de prueba para validar el combate. | SP1 (balance de daño), SP2 (bugs de colisión) |
| P2 Implementar sistema de progresión | O2, R2 | Se desarrolla durante las fases de mecánicas y contenido (semanas 5–8) con pruebas en cada sprint. | Programación del sistema de experiencia, niveles y estadísticas dentro del módulo de personaje. | SP3 (progresión desbalanceada), SP4 (errores en actualización de stats) |
| P3 Desarrollar niveles interactivos | O3, R3 | Se realiza durante la fase de contenido (semanas 7–10). Cada nivel puede tardar entre 4 y 8 horas de diseño y pruebas. | Construcción de niveles usando el editor de escenas de Godot, integrando plataformas, obstáculos y enemigos. | SP5 (niveles poco desafiantes), SP6 (problemas de navegación del jugador) |
| P4 Establecer interfaz de usuario | O4, R4 | Se desarrolla en paralelo con las mecánicas principales durante varias iteraciones de diseño. | Creación del HUD, menús y pantallas del juego utilizando el sistema de UI de Godot. | SP7 (falta de claridad visual), SP8 (problemas de usabilidad) |
| P5 Evaluar rendimiento del juego | O5, R5 | Se realiza continuamente durante todo el desarrollo y especialmente en la fase de pulido (semanas 11–14). | Pruebas de rendimiento dentro del motor, monitoreo de FPS, uso de memoria y optimización de scripts. | SP9 (bajo rendimiento), SP10 (consumo excesivo de recursos) |
| P6 Realizar pruebas de jugabilidad | O1, O2, O3, O4 | Se realizan sesiones periódicas de prueba durante el desarrollo, aproximadamente una vez por sprint. | Pruebas internas con desarrolladores y testers, evaluando mecánicas, dificultad y experiencia de usuario. | SP11 (bugs de gameplay), SP12 (curva de dificultad incorrecta) |
<br></br>

**Causa --> Categorias**
| Causa | Categoría del diagrama  |
| ----- | ----------------------- |
| C1    | Diseño del Juego        |
| C2    | Tecnología / Software   |
| C3    | Contenido y Arte        |
| C5    | Proceso de Desarrollo   |
| C6    | Experiencia del Jugador |

### *Diagrama Causa Efecto (Porcentajes)*
![Diagrama Causa Efecto](../../graphics/diagrama_causa_efecto_porcentajes.svg)

### *Tabla de porcentajes*
| Causa | Categoría | Valor | Porcentaje |
|------|------|------|------|
| C1 | Diseño del Juego | 12 | 21% |
| C2 | Tecnología / Software | 3 | 5% |
| C3 | Contenido y Arte | 12 | 22% |
| C5 | Proceso de Desarrollo | 15 | 27% |
| C6 | Experiencia del Jugador | 14 | 25% |
| **Total** | — | **56** | **100%** |

### *Tabla extendida*
| Causa | Valor | Porcentaje (%) |
|------|------|------|
| C1 | 12 | 21% |
| C2 | 3 | 5% |
| C3 | 12 | 22% |
| C5 | 15 | 27% |
| C6 | 14 | 25% |
| **Total** | **56** | **100%** |