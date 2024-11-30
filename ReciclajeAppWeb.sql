
CREATE DATABASE ReciclajeApp
GO

USE ReciclajeApp
GO

/*
	Universidad Dr. Andres Bello, Regional Sonsonate. 
		Faculta de tecnologia e innovacion. 

SITIO WEB QUE INCENTIVA E INTRODUCE LAS BUENAS PRÁCTICAS 
EMPRESARIALES DEL RECICLAJE DE DESECHOS ELECTRÓNICOS.

Grupo:
	+ Garcia Carias, Bryan Saúl, gc0089022022.
	+ Jime Urias, Gabriela Batseba, ju1037022022.
	+ Linares Marroquín, Alejandro De Jesus, lm0378022006.
	+ Osorio Gutierrez, Damarys Elena, og0456022022.
	+ Mendoza Rivas, José Rigoberto mr0279022022.
	+ Viscarra Izaguirre, Brenda Marisela,  vi0858022022.

Docente: 
	+ 

Catedra:
	+

Fecha:
	´+ 
*/

--PRIMERA PANTALLA DEL SITIO WEB CON SUS TABLAS E INSERSIONES⬇️

-- Crear la tabla de Testimonios
CREATE TABLE Testimonios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Empresa NVARCHAR(100) NOT NULL,
    Mensaje NVARCHAR(500) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1
)
GO

-- Insertar datos de ejemplo
INSERT INTO Testimonios (Empresa, Mensaje, FechaCreacion, Activo)
VALUES 
    ('TechRecycle S.A.', 'Hemos reducido nuestra huella de carbono en un 30% gracias a las prácticas de reciclaje.', GETDATE(), 1),
    ('EcoTech Solutions', 'El reciclaje de componentes electrónicos nos ha permitido ahorrar costos y contribuir al medio ambiente.', GETDATE(), 1),
    ('Green IT Corp', 'Implementamos un programa de reciclaje que ha sido muy bien recibido por nuestros empleados.', GETDATE(), 1)
GO

-- Crear procedimiento almacenado
CREATE PROCEDURE sp_ObtenerTestimoniosActivos
AS
BEGIN
    SELECT Id, Empresa, Mensaje, FechaCreacion, Activo
    FROM Testimonios
    WHERE Activo = 1
    ORDER BY FechaCreacion DESC
END
GO

select * from Testimonios
Go

--SEGUNDA PANTALLA DEL SITIO WEB CON SUS TABLAS E INSERSIONES⬇️

-- Tabla PreguntasFrecuentes
CREATE TABLE PreguntasFrecuentes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pregunta NVARCHAR(200) NOT NULL,
    Respuesta NVARCHAR(MAX) NOT NULL
)
GO


-- Tabla Documentos
CREATE TABLE Documentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(200) NOT NULL,
    Url NVARCHAR(300) NOT NULL
)
GO

-- Datos en PreguntasFrecuentes
INSERT INTO PreguntasFrecuentes (Pregunta, Respuesta)
VALUES ('¿Cómo puedo reciclar mis dispositivos electrónicos?', 'Llévalos a centros de reciclaje especializados.'),
       ('¿Qué materiales se pueden recuperar?', 'Metales preciosos como oro, plata y cobre.')
GO

select * from PreguntasFrecuentes
GO

--TERCERA PANTALLA DEL SITIO WEB CON SUS TABLAS E INSERSIONES⬇️

-- Crear la tabla BuenasPracticas
CREATE TABLE BuenasPracticas (
	PracticaID INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único
	Titulo NVARCHAR(200) NOT NULL,            -- Título descriptivo
	Descripcion NVARCHAR(MAX) NOT NULL,       -- Descripción detallada
	ClasificacionDesecho NVARCHAR(100) NULL,  -- Clasificación del tipo de desecho
	FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de creación
	FechaActualizacion DATETIME NULL                     -- Fecha de última actualización
	)
	GO

	-- Insertar datos de ejemplo sobre desechos electrónicos
INSERT INTO BuenasPracticas (Titulo, Descripcion, ClasificacionDesecho, FechaCreacion, FechaActualizacion)
	VALUES 
		('Reciclaje Responsable de Computadoras', 'Proceso detallado sobre cómo reciclar computadoras de manera adecuada.', 'Peligroso', GETDATE(), NULL),
		('Eliminación Segura de Baterías de Litio', 'Guía para recolectar y desechar baterías de litio usadas de forma segura.', 'Muy Peligroso', GETDATE(), NULL),
		('Recuperación de Metales en Placas de Circuito', 'Procesos para extraer metales preciosos de placas madre y componentes electrónicos.', 'Muy Peligroso', GETDATE(), NULL),
		('Desmontaje Seguro de Monitores CRT', 'Técnicas para manejar y desmontar monitores CRT, minimizando riesgos.', 'Muy Peligroso', GETDATE(), NULL),
		('Reutilización de Componentes Electrónicos', 'Estrategias para reutilizar chips y módulos electrónicos funcionales.', 'De Menor Riesgo', GETDATE(), NULL),
		('Gestión de Desechos de Teléfonos Móviles', 'Guía para recolectar y reciclar partes de teléfonos móviles.', 'Peligroso', GETDATE(), NULL),
		('Disposición Segura de Transformadores de Alta Tensión', 'Cómo manejar y desechar transformadores con materiales peligrosos.', 'Muy Peligroso', GETDATE(), NULL),
		('Eliminación Controlada de Residuos de Impresoras', 'Cómo reciclar cartuchos de tóner y partes electrónicas de impresoras.', 'Peligroso', GETDATE(), NULL),
		('Reciclaje de Electrodomésticos Pequeños', 'Métodos seguros para recolectar y procesar electrodomésticos pequeños como licuadoras y microondas.', 'Peligroso', GETDATE(), NULL),
		('Manejo de Desechos de Paneles Solares', 'Prácticas para gestionar residuos de paneles solares al final de su vida útil.', 'Peligroso', GETDATE(), NULL),
		('Recuperación de Plásticos de Carcasas Electrónicas', 'Proceso para extraer plásticos y reciclarlos de forma eficiente.', 'De Menor Riesgo', GETDATE(), NULL),
		('Gestión de Desechos de Centros de Datos', 'Cómo manejar servidores y dispositivos de almacenamiento obsoletos.', 'Peligroso', GETDATE(), NULL),
		('Procesamiento Seguro de Residuos de Televisores LED y OLED', 'Guía para reciclar pantallas planas sin liberar contaminantes.', 'Muy Peligroso', GETDATE(), NULL),
		('Recuperación de Metales Tóxicos de Baterías de Autos Eléctricos', 'Estrategias para extraer y manejar metales peligrosos de baterías grandes.', 'Muy Peligroso', GETDATE(), NULL),
		('Manejo Seguro de Desechos de Drones y Cámaras', 'Métodos para recolectar y desmontar partes electrónicas de drones y cámaras usadas.', 'Peligroso', GETDATE(), NULL);
	GO

	-- Crear procedimiento almacenado para obtener buenas prácticas por clasificación de desecho
CREATE PROCEDURE sp_ObtenerBuenasPracticasPorTipoDesecho
		@ClasificacionDesecho NVARCHAR(100) = NULL -- Parámetro opcional para filtrar por clasificación de desecho
	AS
	BEGIN
		SELECT PracticaID, Titulo, Descripcion, ClasificacionDesecho, FechaCreacion, FechaActualizacion
		FROM BuenasPracticas
		WHERE (@ClasificacionDesecho IS NULL OR ClasificacionDesecho = @ClasificacionDesecho)
		ORDER BY FechaCreacion DESC;
	END
	GO


	-- Consultar todas las buenas prácticas
SELECT * FROM BuenasPracticas
GO

--CUARTA PANTALLA DEL SITIO WEB CON SUS TABLAS E INSERSIONES⬇️

CREATE TABLE EmpresaReciclaje ( --es la tabla que se utiliza de formulario en la pantalla 4, para obtener infromacion a cerca de la empresa que se desea brindar su experiencia
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreEmpresa NVARCHAR(100) NOT NULL,
    TipoDesechos NVARCHAR(100) NOT NULL,
    CantidadDesechos INT NOT NULL,
    NombreResponsable NVARCHAR(100),
    CorreoElectronico NVARCHAR(100),
    Telefono NVARCHAR(50),
    TieneProgramaReciclaje BIT NOT NULL,
    TipoResiduos NVARCHAR(500),
    ObjetivoReciclaje NVARCHAR(500),
    UsaCertificadoReciclaje BIT NOT NULL,
    FechaInicioPrograma DATE NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE()
);

DELETE FROM EmpresaReciclaje;

select * from EmpresaReciclaje
GO





