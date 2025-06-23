-- Insertar presentación y guardar el ID
INSERT INTO Presentations (Title, ActivityStatus, ModifiedAt, CreatedAt, IdUserCreat)
VALUES ('Presentación de prueba completa', 1, GETDATE(), GETDATE(), NEWID());

DECLARE @PresentationId INT = SCOPE_IDENTITY();

-- Insertar slides uno por uno, guardar cada ID
DECLARE @SlideId1 INT, @SlideId2 INT, @SlideId3 INT;

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, CreateAt, ModifiedAt, Position)
VALUES ('https://ejemplo.com/slide1', '#FFFFFF', @PresentationId, 'Primer Slide', GETDATE(), GETDATE(), 1);
SET @SlideId1 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, CreateAt, ModifiedAt, Position)
VALUES ('https://ejemplo.com/slide2', '#FFEEAA', @PresentationId, 'Segundo Slide', GETDATE(), GETDATE(), 2);
SET @SlideId2 = SCOPE_IDENTITY();

INSERT INTO Slides (Url, BackgroundColor, IdPresentation, Title, CreateAt, ModifiedAt, Position)
VALUES ('https://ejemplo.com/slide3', '#DDEEFF', @PresentationId, 'Tercer Slide', GETDATE(), GETDATE(), 3);
SET @SlideId3 = SCOPE_IDENTITY();

-- Insertar preguntas y guardar IDs
DECLARE @AskId1 INT, @AskId2 INT, @AskId3 INT;

INSERT INTO Asks (Name, Description, AskText, SlideId, CreatedAt, ModifiedAt)
VALUES ('Pregunta Slide 1', 'Pregunta sencilla', '¿Cuál es la capital de Francia?', @SlideId1, GETDATE(), GETDATE());
SET @AskId1 = SCOPE_IDENTITY();

INSERT INTO Asks (Name, Description, AskText, SlideId, CreatedAt, ModifiedAt)
VALUES ('Pregunta Slide 2', 'Pregunta de geografía', '¿Cuál es el río más largo del mundo?', @SlideId2, GETDATE(), GETDATE());
SET @AskId2 = SCOPE_IDENTITY();

INSERT INTO Asks (Name, Description, AskText, SlideId, CreatedAt, ModifiedAt)
VALUES ('Pregunta Slide 3', 'Pregunta general', '¿Cuál es el planeta más grande?', @SlideId3, GETDATE(), GETDATE());
SET @AskId3 = SCOPE_IDENTITY();

-- Insertar opciones para preguntas usando variables de preguntas
INSERT INTO Options (OptionText, IsCorrect, IdAsk, CreatedAt, ModifiedAt)
VALUES
('París', 1, @AskId1, GETDATE(), GETDATE()),
('Londres', 0, @AskId1, GETDATE(), GETDATE()),
('Madrid', 0, @AskId1, GETDATE(), GETDATE());

INSERT INTO Options (OptionText, IsCorrect, IdAsk, CreatedAt, ModifiedAt)
VALUES
('Nilo', 0, @AskId2, GETDATE(), GETDATE()),
('Amazonas', 1, @AskId2, GETDATE(), GETDATE()),
('Yangtsé', 0, @AskId2, GETDATE(), GETDATE());

INSERT INTO Options (OptionText, IsCorrect, IdAsk, CreatedAt, ModifiedAt)
VALUES
('Júpiter', 1, @AskId3, GETDATE(), GETDATE()),
('Saturno', 0, @AskId3, GETDATE(), GETDATE()),
('Neptuno', 0, @AskId3, GETDATE(), GETDATE());
