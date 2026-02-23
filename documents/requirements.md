# Requerimientos 
 
### *Requerimientos funcionales*:

#### Módulo de Personaje Principal

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RF-01 | Movimiento básico | El personaje debe poder moverse horizontalmente (izquierda/derecha) con fluidez | Alta |
| RF-02 | Salto | El personaje debe poder saltar y realizar doble salto (característica ARPG) | Alta |
| RF-03 | Correr | El personaje debe poder correr (movimiento más rápido) | Media |
| RF-04 | Salud | El personaje debe tener una barra de vida que se reduzca al recibir daño | Alta |
| RF-05 | Muerte | Al llegar a 0 de vida, el personaje debe morir y mostrar pantalla de Game Over | Alta |
| RF-06 | Estadísticas | El personaje debe tener stats (fuerza, defensa, velocidad) que afecten gameplay | Media |
| RF-07 | Nivel | El personaje debe poder subir de nivel al ganar experiencia | Baja (si hay tiempo) |

#### Módulo de Combate

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RF-08 | Ataque básico | El personaje debe poder realizar un ataque cuerpo a cuerpo (ej. espada) | Alta |
| RF-09 | Daño a enemigos | Los ataques deben reducir la vida de los enemigos | Alta |
| RF-10 | Habilidad especial | El personaje debe tener al menos una habilidad especial (ej. dash, proyectil) | Media |
| RF-11 | Enfriamiento | Las habilidades especiales deben tener tiempo de reutilización (cooldown) | Media |
| RF-12 | Mana/Energía | Las habilidades deben consumir un recurso (mana, stamina) | Baja |

#### Módulo de Enemigos

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RF-13 | Enemigo básico | Debe existir al menos un tipo de enemigo con movimiento simple | Alta |
| RF-14 | Patrullaje | El enemigo debe moverse entre puntos definidos | Media |
| RF-15 | Detección | El enemigo debe detectar al jugador en un rango | Alta |
| RF-16 | Persecución | Al detectar al jugador, debe moverse hacia él | Alta |
| RF-17 | Ataque enemigo | El enemigo debe atacar al jugador al estar cerca | Alta |
| RF-18 | Drop de items | Al morir, los enemigos deben soltar experiencia/vida | Media |

#### Módulo de Niveles

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RF-19 | Plataformas | El nivel debe contener plataformas para saltar | Alta |
| RF-20 | Obstáculos | Debe haber obstáculos (espinas, vacío) que dañen al jugador | Alta |
| RF-21 | Checkpoints | El jugador debe reaparecer en puntos específicos al morir | Media |
| RF-22 | Puertas/Salidas | Debe haber una forma de avanzar al siguiente nivel | Alta |
| RF-23 | Items recolectables | Debe haber items para recuperar vida/mana | Media |

#### Módulo de Interfaz (UI)

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RF-24 | HUD básico | Mostrar barra de vida del jugador | Alta |
| RF-25 | Contador | Mostrar experiencia/puntuación actual | Media |
| RF-26 | Menú pausa | Poder pausar el juego con opción de continuar/salir | Alta |
| RF-27 | Pantalla inicio | Menú principal con opción "Comenzar juego" | Alta |
| RF-28 | Tutorial | Breve explicación de controles al inicio | Baja |
<br></br>


### *Requerimientos no funcionales*:

#### Rendimiento

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RNF-01 | FPS estables | El juego debe mantener 60 FPS en hardware de gama media | Alta |
| RNF-02 | Tiempo de carga | Los niveles deben cargar en menos de 3 segundos | Media |
| RNF-03 | Optimización | El juego no debe consumir más de 500MB de RAM | Media |
| RNF-04 | Respuesta inputs | Los controles deben responder en menos de 0.1 segundos | Alta |

#### Usabilidad

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RNF-05 | Controles intuitivos | Los controles deben ser fáciles de aprender (ej. flechas/ WASD) | Alta |
| RNF-06 | Feedback visual | El jugador debe ver claramente cuando recibe/hace daño | Alta |
| RNF-07 | Consistencia | Elementos similares deben comportarse igual en todo el juego | Alta |
| RNF-08 | Accesibilidad | Opción de reasignar teclas (si hay tiempo) | Baja |

#### Confiabilidad

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RNF-09 | Sin crashes | El juego no debe cerrarse inesperadamente | Alta |
| RNF-10 | Guardado | El progreso debe persistir entre sesiones (si hay tiempo) | Media |
| RNF-11 | Manejo de errores | Si algo falla, debe mostrar mensaje amigable | Media |

#### Código y Mantenibilidad

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RNF-12 | Modularidad | El código debe estar organizado por módulos (Personaje, Enemigos, Niveles) | Alta |
| RNF-13 | Documentación | Las clases y métodos complejos deben tener comentarios | Alta |
| RNF-14 | Convenciones POO | Debe demostrar herencia, polimorfismo, encapsulamiento | Alta |
| RNF-15 | Estilo consistente | Todo el código debe seguir el mismo formato | Media |

#### Portabilidad

| ID | Requerimiento | Descripción | Prioridad |
|----|--------------|-------------|-----------|
| RNF-16 | Multiplataforma | El juego debe funcionar en Windows y al menos otro SO (Linux/Mac) | Media |
| RNF-17 | Resoluciones | Debe adaptarse a diferentes tamaños de pantalla | Media |
