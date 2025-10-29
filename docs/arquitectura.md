# Arquitectura de DinoScale AR

## Visión general
DinoScale AR es una aplicación móvil educativa que combina Realidad Aumentada con contenido paleontológico para ofrecer comparaciones de escala entre humanos y dinosaurios. El objetivo es presentar modelos 3D a escala real, acompañados de fichas informativas y dinámicas interactivas.

La solución se implementará con Unity y AR Foundation para garantizar compatibilidad con dispositivos Android que soporten ARCore.

## Componentes principales

### 1. Núcleo de RA
- **ARSession / ARSessionOrigin**: gestionan la sesión de RA, la detección del plano y la escala mundial.
- **ARRaycastManager**: permite ubicar dinosaurios en superficies reales detectadas.
- **ARPlaneManager**: opcional para mostrar planos detectados.

### 2. Gestión de dinosaurios
- **DinosaurCatalogue (ScriptableObject)**: almacena metadatos e instancias de prefabs.
- **DinosaurSwitcher**: controla qué dinosaurio se visualiza, maneja la carga/descarga de prefabs y asegura que la escala sea 1:1.
- **HumanScaleController**: ajusta la altura del avatar humano de referencia.

### 3. Interfaz de usuario
- **UISceneController**: sincroniza botones, paneles de información y eventos de RA.
- **DinosaurInfoPanel**: actualiza textos con datos de altura, longitud, dieta, periodo.
- **TriviaManager (opcional)**: módulo para preguntas y respuestas rápidas.

### 4. Datos
- `Assets/Data/DinosaurCatalogue.asset`: catálogo editable desde Unity con referencias a prefabs y fichas de datos.
- **Localización**: archivos `JSON` o `CSV` con traducciones.

## Flujo de usuario
1. El usuario abre la app y concede permisos de cámara.
2. Se detectan planos; el usuario toca una superficie para colocar el dinosaurio.
3. Aparece el dinosaurio seleccionado y un avatar humano.
4. La interfaz muestra datos; el usuario puede cambiar de especie o ajustar la escala del humano.
5. El usuario explora, toma fotos o responde trivias.

## Escalabilidad
- La arquitectura admite añadir nuevas especies creando prefabs y entradas en el catálogo.
- El módulo de datos permite persistir información en formato JSON para actualizaciones OTA.

## Métricas y analítica
- Eventos como "especie seleccionada", "foto tomada", "trivia completada" se pueden enviar a servicios analíticos (Firebase Analytics).

## Consideraciones de rendimiento
- Reducir polígonos y texturas (2K máx) para mantener el frame rate >30 FPS.
- Utilizar LODs cuando sea posible.
- Evitar sombras en tiempo real si el dispositivo es de gama media; usar iluminación horneada.

## Roadmap técnico
- [ ] Implementar colocación inicial con `ARRaycastManager`.
- [ ] Añadir interpolaciones suaves al cambiar dinosaurios.
- [ ] Crear panel de configuración para altura de avatar.
- [ ] Integrar módulo de trivias y logros.
