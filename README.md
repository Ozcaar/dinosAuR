# DinoScale AR

DinoScale AR es una aplicación educativa para Android que utiliza Realidad Aumentada (RA) para mostrar dinosaurios a escala real junto a una figura humana. Permite comparar tamaños, consultar información paleontológica y vivir una experiencia inmersiva.

## Características principales
- Visualización en RA de dinosaurios a escala real.
- Figura humana de referencia con altura configurable.
- Selección de especies: Tyrannosaurus rex, Triceratops y Velociraptor.
- Ficha informativa con altura, longitud, dieta y periodo geológico.
- Controles para cambiar escala relativa, alternar entre modo día/noche y pausar animaciones.

## Tecnologías sugeridas
- **Unity 2021 LTS** + **AR Foundation** y **ARCore XR Plugin** para despliegue en Android.
- Modelos 3D optimizados (FBX/GLB) con texturas PBR.
- Scriptable Objects para gestionar catálogos de especies.
- Sistema de UI basado en Unity UI Toolkit o Canvas tradicional.

## Estructura del repositorio

```
/
├── README.md
├── docs/
│   └── arquitectura.md
└── unity/
    └── Assets/
        ├── Data/
        │   └── DinosaurCatalog.asset (referencia, generado en Unity)
        └── Scripts/
            ├── DinosaurCatalogue.cs
            ├── DinosaurSwitcher.cs
            ├── DinosaurInfoPanel.cs
            ├── HumanScaleController.cs
            └── UISceneController.cs
```

> **Nota**: Los archivos `.asset` se generan dentro del editor Unity. En este repositorio solo se incluyen scripts de ejemplo y documentación para iniciar el proyecto.

## Cómo empezar

1. **Configurar Unity**
   - Instala Unity 2021 LTS con soporte Android.
   - Añade los paquetes AR Foundation (>= 4.2) y ARCore XR Plugin desde el Package Manager.
2. **Importar modelos 3D**
   - Coloca los modelos de dinosaurios en `Assets/Models/`. Se recomiendan mallas optimizadas (<100k polígonos).
   - Configura escalas realistas (1 unidad = 1 metro).
3. **Crear la escena principal**
   - Añade un `ARSessionOrigin` y `ARSession`.
   - Asigna el script `DinosaurSwitcher` al objeto que contendrá los prefabs de dinosaurios.
   - Vincula `HumanScaleController` al prefab humano.
4. **Configurar UI**
   - Crea un Canvas con botones para cambiar de especie y paneles de información.
   - Asocia `DinosaurInfoPanel` y `UISceneController` con los elementos UI.
5. **Compilar para Android**
   - Activa ARCore en Player Settings > XR Plug-in Management.
   - Establece mínimo API Level 24 y target 33.
   - Genera un `keystore` para firma si se publicará.

## Datos de dinosaurios (ejemplo)

| Especie        | Altura (m) | Longitud (m) | Dieta        | Periodo           |
|----------------|------------|--------------|--------------|-------------------|
| T. rex         | 4.0        | 12.3         | Carnívoro    | Cretácico tardío  |
| Triceratops    | 3.0        | 9.0          | Herbívoro    | Cretácico tardío  |
| Velociraptor   | 0.5        | 2.0          | Carnívoro    | Cretácico tardío  |

## Experiencia educativa
- Narrativa guiada que describe hábitat, comportamiento y curiosidades.
- Comparaciones interactivas con objetos cotidianos (autobús, cancha de baloncesto).
- Modo "Preguntas rápidas" con trivias sobre dinosaurios.
- Integración opcional con logros y medallas.

## Próximos pasos
- Añadir más especies y animaciones.
- Implementar localización (es/en).
- Integrar captura de fotos con las criaturas superpuestas.
- Publicar beta cerrada para feedback educativo.
