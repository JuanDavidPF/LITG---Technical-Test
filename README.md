# LITG-Technical Assesment

 Technical Assesment for Life is The Game's Senior Unity Developer position.
 
## How To Test

##### Build

You can find the released [___v1.0.0 build___](https://github.com/JuanDavidPF/LITG-Technical-Assesment/releases/tag/v.1.0.0).

##### In-Editor
You can clone the project from the ___main___ release branch or ___development___.
- Open project with **Unity 2022.3.22f1.**
- Open LITF - Technical Test Folder
- Open Scenes Folder
- Open Main Scene
- Play!

## Requirements
se desarrollará un juego basico en Unity3D haciendo uso del material adjunto, el juego se dividirá en dos instancias principales.

al iniciar, se desplegará una interfaz en canvas que nos mostrará el modelo, esta incluirá 4 botones, 3 de ellos al ser clickeados el personaje cambiara su animacion por la asignada a cada botón, mientras el ultimo determinara la aniamcion a seleccionar, al terminar este proceso se enviará al usuario a una segunda escena.

En esta segunda fase la vista será en primera persona, se podra ver al personaje reproduciendo la animacion asignada en una pequeña esquina en el ui. Por otro lado el usuario podra escoger entre 3 armas disintas en el suelo, cada una de ellas disparará de una forma distinta.

la primera realizará un disparo con trayectoria parabolica.La segunda generará un campo alrdedor donde atraerá objetos cercanos haciendolos orbitar alrededor del proyectil. La tercera será libre pero deberá incluir alguna propiedad fisica similar a las anteriores descritas.

Todas las armas tendran valores personalizables por medio de un scriptable object, que debera ser cargado al iniciar el juego.
