--PRESENTACIONES PRECARGADAS

-- Variables para Presentations
DECLARE @PresentationId1 INT, @PresentationId2 INT, @PresentationId3 INT, @PresentationId4 INT, @PresentationId5 INT;

-- Insertar Presentations
INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('Introducción a Machine Learning', 1, GETDATE(), GETDATE(), NEWID());
SET @PresentationId1 = SCOPE_IDENTITY();

INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('Fundamentos de React', 1, GETDATE(), GETDATE(), NEWID());
SET @PresentationId2 = SCOPE_IDENTITY();

INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('Análisis de Datos con Python', 1, GETDATE(), GETDATE(), NEWID());
SET @PresentationId3 = SCOPE_IDENTITY();

INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('Arquitectura de Microservicios', 1, GETDATE(), GETDATE(), NEWID());
SET @PresentationId4 = SCOPE_IDENTITY();

INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('UX/UI Design Principles', 1, GETDATE(), GETDATE(), NEWID());
SET @PresentationId5 = SCOPE_IDENTITY();

-- Variables para Slides
DECLARE 
    @SlideId1 INT, @SlideId2 INT, @SlideId3 INT, @SlideId4 INT, @SlideId5 INT,
    @SlideId6 INT, @SlideId7 INT, @SlideId8 INT, @SlideId9 INT, @SlideId10 INT,
    @SlideId11 INT, @SlideId12 INT, @SlideId13 INT, @SlideId14 INT, @SlideId15 INT,
    @SlideId16 INT, @SlideId17 INT, @SlideId18 INT;

-- Insertar Slides Presentacion 1 (Machine Learning)
INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1506765515384-028b60a970df', '#1e3a8a', @PresentationId1, 'Qué es Machine Learning', 1, GETDATE(), GETDATE());
SET @SlideId1 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1554415707-6e8cfc93fe23', '#1e40af', @PresentationId1, 'Tipos de Algoritmos', 2, GETDATE(), GETDATE());
SET @SlideId2 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1519389950473-47ba0277781c', '#1e3a8a', @PresentationId1, 'Aplicaciones Prácticas', 3, GETDATE(), GETDATE());
SET @SlideId3 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1504384308090-c894fdcc538d', '#1e40af', @PresentationId1, 'Herramientas Populares', 4, GETDATE(), GETDATE());
SET @SlideId4 = SCOPE_IDENTITY();

-- Insertar Slides Presentacion 2 (React)
INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1517433456452-f9633a875f6f', '#059669', @PresentationId2, 'Introducción a React', 1, GETDATE(), GETDATE());
SET @SlideId5 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1498050108023-c5249f4df085', '#047857', @PresentationId2, 'Componentes y JSX', 2, GETDATE(), GETDATE());
SET @SlideId6 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1519125323398-675f0ddb6308', '#059669', @PresentationId2, 'Estado y Props', 3, GETDATE(), GETDATE());
SET @SlideId7 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1522071820081-009f0129c71c', '#047857', @PresentationId2, 'Hooks Básicos', 4, GETDATE(), GETDATE());
SET @SlideId8 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1537432376769-00a8e9367d2a', '#059669', @PresentationId2, 'Proyecto Práctico', 5, GETDATE(), GETDATE());
SET @SlideId9 = SCOPE_IDENTITY();

-- Insertar Slides Presentacion 3 (Python)
INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1518773553398-650c184e0bb3', '#7c2d12', @PresentationId3, 'Introducción al Análisis de Datos', 1, GETDATE(), GETDATE());
SET @SlideId10 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1504384308090-c894fdcc538d', '#991b1b', @PresentationId3, 'Pandas y NumPy', 2, GETDATE(), GETDATE());
SET @SlideId11 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1498050108023-c5249f4df085', '#7c2d12', @PresentationId3, 'Visualización con Matplotlib', 3, GETDATE(), GETDATE());
SET @SlideId12 = SCOPE_IDENTITY();

-- Insertar Slides Presentacion 4 (Microservicios)
INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1486312338219-ce68d2c6f44d', '#4338ca', @PresentationId4, 'Introducción a Microservicios', 1, GETDATE(), GETDATE());
SET @SlideId13 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1532074205216-94f4d68eac8c', '#5b21b6', @PresentationId4, 'Patrones de Diseño', 2, GETDATE(), GETDATE());
SET @SlideId14 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1497493292307-31c376b6e479', '#4338ca', @PresentationId4, 'Comunicación entre Servicios', 3, GETDATE(), GETDATE());
SET @SlideId15 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1504384308090-c894fdcc538d', '#5b21b6', @PresentationId4, 'Deployment y Monitoring', 4, GETDATE(), GETDATE());
SET @SlideId16 = SCOPE_IDENTITY();

-- Insertar Slides Presentacion 5 (UX/UI)
INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1504384308090-c894fdcc538d', '#be185d', @PresentationId5, 'Principios de UX', 1, GETDATE(), GETDATE());
SET @SlideId17 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, Position, CreateAt, ModifiedAt) VALUES
('https://images.unsplash.com/photo-1504384308090-c894fdcc538d', '#c2185b', @PresentationId5, 'Fundamentos de UI', 2, GETDATE(), GETDATE());
SET @SlideId18 = SCOPE_IDENTITY();

-- Preguntas para cada slide
DECLARE 
    @AskId1 INT, @AskId2 INT, @AskId3 INT, @AskId4 INT, @AskId5 INT,
    @AskId6 INT, @AskId7 INT, @AskId8 INT, @AskId9 INT, @AskId10 INT,
    @AskId11 INT, @AskId12 INT, @AskId13 INT, @AskId14 INT, @AskId15 INT,
    @AskId16 INT, @AskId17 INT, @AskId18 INT;

-- Insertar preguntas y guardar IDs

-- Slide 1
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta ML 1', 'Concepto básico', '¿Qué es el aprendizaje supervisado?', @SlideId1, GETDATE(), GETDATE());
SET @AskId1 = SCOPE_IDENTITY();

-- Slide 2
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta ML 2', 'Algoritmos', '¿Cuál es un ejemplo de algoritmo de clustering?', @SlideId2, GETDATE(), GETDATE());
SET @AskId2 = SCOPE_IDENTITY();

-- Slide 3
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta ML 3', 'Aplicaciones', 'Menciona una aplicación práctica del ML', @SlideId3, GETDATE(), GETDATE());
SET @AskId3 = SCOPE_IDENTITY();

-- Slide 4
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta ML 4', 'Herramientas', '¿Qué librería popular se usa para ML en Python?', @SlideId4, GETDATE(), GETDATE());
SET @AskId4 = SCOPE_IDENTITY();

-- Slide 5
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta React 1', 'Introducción', '¿Qué es React?', @SlideId5, GETDATE(), GETDATE());
SET @AskId5 = SCOPE_IDENTITY();

-- Slide 6
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta React 2', 'JSX', '¿Qué es JSX?', @SlideId6, GETDATE(), GETDATE());
SET @AskId6 = SCOPE_IDENTITY();

-- Slide 7
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta React 3', 'Estado y Props', '¿Para qué sirven los Props?', @SlideId7, GETDATE(), GETDATE());
SET @AskId7 = SCOPE_IDENTITY();

-- Slide 8
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta React 4', 'Hooks', '¿Qué hace useState?', @SlideId8, GETDATE(), GETDATE());
SET @AskId8 = SCOPE_IDENTITY();

-- Slide 9
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta React 5', 'Proyecto', '¿Qué es un componente funcional?', @SlideId9, GETDATE(), GETDATE());
SET @AskId9 = SCOPE_IDENTITY();

-- Slide 10
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Python 1', 'Introducción', '¿Qué es Pandas?', @SlideId10, GETDATE(), GETDATE());
SET @AskId10 = SCOPE_IDENTITY();

-- Slide 11
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Python 2', 'Librerías', '¿Para qué sirve NumPy?', @SlideId11, GETDATE(), GETDATE());
SET @AskId11 = SCOPE_IDENTITY();

-- Slide 12
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Python 3', 'Visualización', '¿Qué herramienta se usa para graficar?', @SlideId12, GETDATE(), GETDATE());
SET @AskId12 = SCOPE_IDENTITY();

-- Slide 13
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Micro 1', 'Introducción', '¿Qué es un microservicio?', @SlideId13, GETDATE(), GETDATE());
SET @AskId13 = SCOPE_IDENTITY();

-- Slide 14
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Micro 2', 'Patrones', '¿Qué patrón es común en microservicios?', @SlideId14, GETDATE(), GETDATE());
SET @AskId14 = SCOPE_IDENTITY();

-- Slide 15
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Micro 3', 'Comunicación', '¿Cómo se comunican los microservicios?', @SlideId15, GETDATE(), GETDATE());
SET @AskId15 = SCOPE_IDENTITY();

-- Slide 16
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta Micro 4', 'Deployment', '¿Qué es CI/CD?', @SlideId16, GETDATE(), GETDATE());
SET @AskId16 = SCOPE_IDENTITY();

-- Slide 17
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta UX/UI 1', 'UX', '¿Qué es UX?', @SlideId17, GETDATE(), GETDATE());
SET @AskId17 = SCOPE_IDENTITY();

-- Slide 18
INSERT INTO Asks (Name, Description, AskText, IdSlide, ModifiedAt, CreatedAt)
VALUES ('Pregunta UX/UI 2', 'UI', '¿Qué es UI?', @SlideId18, GETDATE(), GETDATE());
SET @AskId18 = SCOPE_IDENTITY();

-- Insertar Opciones para cada pregunta

-- Opciones Pregunta 1
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Es un método de aprendizaje con datos etiquetados', 1, @AskId1, GETDATE(), GETDATE()),
('Es un método sin etiquetas', 0, @AskId1, GETDATE(), GETDATE()),
('No usa datos', 0, @AskId1, GETDATE(), GETDATE());

-- Opciones Pregunta 2
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('K-means', 1, @AskId2, GETDATE(), GETDATE()),
('Regresión lineal', 0, @AskId2, GETDATE(), GETDATE()),
('Redes neuronales', 0, @AskId2, GETDATE(), GETDATE());

-- Opciones Pregunta 3
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Reconocimiento de voz', 1, @AskId3, GETDATE(), GETDATE()),
('Pintura', 0, @AskId3, GETDATE(), GETDATE()),
('Cocina', 0, @AskId3, GETDATE(), GETDATE());

-- Opciones Pregunta 4
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Scikit-learn', 1, @AskId4, GETDATE(), GETDATE()),
('Matplotlib', 0, @AskId4, GETDATE(), GETDATE()),
('Flask', 0, @AskId4, GETDATE(), GETDATE());

-- Opciones Pregunta 5
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Una librería para crear interfaces de usuario', 1, @AskId5, GETDATE(), GETDATE()),
('Un lenguaje de programación', 0, @AskId5, GETDATE(), GETDATE()),
('Un sistema operativo', 0, @AskId5, GETDATE(), GETDATE());

-- Opciones Pregunta 6
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Una sintaxis que mezcla JS y HTML', 1, @AskId6, GETDATE(), GETDATE()),
('Una base de datos', 0, @AskId6, GETDATE(), GETDATE()),
('Un framework backend', 0, @AskId6, GETDATE(), GETDATE());

-- Opciones Pregunta 7
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Para pasar datos a componentes', 1, @AskId7, GETDATE(), GETDATE()),
('Para manejar eventos', 0, @AskId7, GETDATE(), GETDATE()),
('Para definir estilos', 0, @AskId7, GETDATE(), GETDATE());

-- Opciones Pregunta 8
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Para manejar estado local', 1, @AskId8, GETDATE(), GETDATE()),
('Para hacer llamadas a APIs', 0, @AskId8, GETDATE(), GETDATE()),
('Para diseñar estilos', 0, @AskId8, GETDATE(), GETDATE());

-- Opciones Pregunta 9
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Funcional es una función que retorna JSX', 1, @AskId9, GETDATE(), GETDATE()),
('Funcional es una clase', 0, @AskId9, GETDATE(), GETDATE()),
('Funcional es una librería', 0, @AskId9, GETDATE(), GETDATE());

-- Opciones Pregunta 10
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Una librería para análisis de datos', 1, @AskId10, GETDATE(), GETDATE()),
('Un lenguaje', 0, @AskId10, GETDATE(), GETDATE()),
('Un framework web', 0, @AskId10, GETDATE(), GETDATE());

-- Opciones Pregunta 11
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Para operaciones numéricas rápidas', 1, @AskId11, GETDATE(), GETDATE()),
('Para diseño gráfico', 0, @AskId11, GETDATE(), GETDATE()),
('Para bases de datos', 0, @AskId11, GETDATE(), GETDATE());

-- Opciones Pregunta 12
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Matplotlib', 1, @AskId12, GETDATE(), GETDATE()),
('Flask', 0, @AskId12, GETDATE(), GETDATE()),
('Django', 0, @AskId12, GETDATE(), GETDATE());

-- Opciones Pregunta 13
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Un servicio independiente que realiza una función', 1, @AskId13, GETDATE(), GETDATE()),
('Una base de datos', 0, @AskId13, GETDATE(), GETDATE()),
('Un lenguaje de programación', 0, @AskId13, GETDATE(), GETDATE());

-- Opciones Pregunta 14
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Circuit breaker', 1, @AskId14, GETDATE(), GETDATE()),
('Modelo MVC', 0, @AskId14, GETDATE(), GETDATE()),
('Singleton', 0, @AskId14, GETDATE(), GETDATE());

-- Opciones Pregunta 15
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('A través de APIs REST o mensajería', 1, @AskId15, GETDATE(), GETDATE()),
('Mediante archivos planos', 0, @AskId15, GETDATE(), GETDATE()),
('Mediante acceso directo a memoria', 0, @AskId15, GETDATE(), GETDATE());

-- Opciones Pregunta 16
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Integración y despliegue continuo', 1, @AskId16, GETDATE(), GETDATE()),
('Un lenguaje de programación', 0, @AskId16, GETDATE(), GETDATE()),
('Un sistema operativo', 0, @AskId16, GETDATE(), GETDATE());

-- Opciones Pregunta 17
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Experiencia del usuario', 1, @AskId17, GETDATE(), GETDATE()),
('Interfaz de usuario', 0, @AskId17, GETDATE(), GETDATE()),
('Arquitectura de software', 0, @AskId17, GETDATE(), GETDATE());

-- Opciones Pregunta 18
INSERT INTO Options (OptionText, IsCorrect, IdAsk, ModifiedAt, CreatedAt)
VALUES
('Interfaz de usuario', 1, @AskId18, GETDATE(), GETDATE()),
('Experiencia de usuario', 0, @AskId18, GETDATE(), GETDATE()),
('Desarrollo backend', 0, @AskId18, GETDATE(), GETDATE());
