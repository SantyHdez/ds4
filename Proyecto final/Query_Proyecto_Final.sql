-- =============================================
-- SISTEMA DE ADOPCIÓN DE MASCOTAS
-- Base de datos: AdopcionMascotas
-- =============================================

-- Crear la base de datos
CREATE DATABASE AdopcionMascotas;
GO

-- Usar la base de datos
USE AdopcionMascotas;
GO

-- =============================================
-- TABLA: SO_Usuarios
-- =============================================
CREATE TABLE SO_Usuarios
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL DEFAULT 'Usuario', -- 'Usuario' o 'Admin'
    Telefono NVARCHAR(20),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLA: SO_Refugios
-- =============================================
CREATE TABLE SO_Refugios
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TABLA: SO_Mascotas
-- =============================================
CREATE TABLE SO_Mascotas
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Especie NVARCHAR(20) NOT NULL, -- 'Perro', 'Gato', 'Otro'
    Raza NVARCHAR(50),
    Edad INT, -- Edad en años
    Sexo NVARCHAR(10), -- 'Macho', 'Hembra'
    Tamanio NVARCHAR(20), -- 'Pequeño', 'Mediano', 'Grande'
    Descripcion NVARCHAR(500),
    FotoUrl NVARCHAR(500),
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Disponible', -- 'Disponible', 'En Proceso', 'Adoptado'
    IdRefugio INT,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdRefugio) REFERENCES SO_Refugios(Id)
);
GO

-- =============================================
-- TABLA: SO_Solicitudes
-- =============================================
CREATE TABLE SO_Solicitudes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdMascota INT NOT NULL,
    IdUsuario INT NOT NULL,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Pendiente', -- 'Pendiente', 'Aprobada', 'Rechazada'
    Comentarios NVARCHAR(500),
    MotivoRechazo NVARCHAR(500),
    FechaRespuesta DATETIME,
    FOREIGN KEY (IdMascota) REFERENCES SO_Mascotas(Id),
    FOREIGN KEY (IdUsuario) REFERENCES SO_Usuarios(Id)
);
GO

-- =============================================
-- INSERTAR DATOS DE PRUEBA
-- =============================================

-- Usuarios (Admin y usuarios regulares)
INSERT INTO SO_Usuarios (NombreCompleto, Email, Password, Rol, Telefono)
VALUES 
('Admin Principal', 'admin@refugio.com', 'admin123', 'Admin', '555-0001'),
('Santiago Ospina', 'santiago@email.com', 'user123', 'Usuario', '555-0100'),
('María González', 'maria@email.com', 'user123', 'Usuario', '555-0101'),
('Carlos Mendoza', 'carlos@email.com', 'user123', 'Usuario', '555-0102'),
('Ana Silva', 'ana@email.com', 'user123', 'Usuario', '555-0103');
GO

-- Refugios
INSERT INTO SO_Refugios (Nombre, Direccion, Telefono, Email)
VALUES 
('Refugio Esperanza Animal', 'Calle 50 #20-30, Panamá', '555-1000', 'info@esperanza.com'),
('Hogar de Patitas', 'Av. Central #15-40, Panamá', '555-2000', 'contacto@patitas.com'),
('Adopta un Amigo', 'Calle 3ra #10-20, Panamá', '555-3000', 'adopta@amigo.com');
GO

-- Mascotas (variedad de perros, gatos y otros)
INSERT INTO SO_Mascotas (Nombre, Especie, Raza, Edad, Sexo, Tamanio, Descripcion, FotoUrl, Estado, IdRefugio)
VALUES 
-- PERROS
('Max', 'Perro', 'Labrador', 3, 'Macho', 'Grande', 'Perro muy cariñoso y activo, ideal para familias con niños. Le encanta jugar y correr.', 'https://images.unsplash.com/photo-1587300003388-59208cc962cb?w=500', 'Disponible', 1),
('Luna', 'Perro', 'Golden Retriever', 2, 'Hembra', 'Grande', 'Perra dulce y obediente. Perfecta compañera, ama los paseos al aire libre.', 'https://images.unsplash.com/photo-1633722715463-d30f4f325e24?w=500', 'Disponible', 1),
('Rocky', 'Perro', 'Pastor Alemán', 4, 'Macho', 'Grande', 'Perro guardián leal y protector. Bien entrenado y muy inteligente.', 'https://images.unsplash.com/photo-1568572933382-74d440642117?w=500', 'Disponible', 2),
('Bella', 'Perro', 'Beagle', 1, 'Hembra', 'Mediano', 'Cachorra juguetona y curiosa. Necesita un hogar con espacio para explorar.', 'https://images.unsplash.com/photo-1505628346881-b72b27e84530?w=500', 'Disponible', 2),
('Toby', 'Perro', 'Mestizo', 5, 'Macho', 'Mediano', 'Perro adulto tranquilo y cariñoso. Ideal para personas que buscan compañía.', 'https://images.unsplash.com/photo-1534361960057-19889db9621e?w=500', 'En Proceso', 3),
('Coco', 'Perro', 'Chihuahua', 2, 'Hembra', 'Pequeño', 'Perrita pequeña y valiente. Perfecta para apartamentos, muy protectora.', 'https://images.unsplash.com/photo-1541364983171-a8ba01e95cfc?w=500', 'Disponible', 3),

-- GATOS
('Michi', 'Gato', 'Siamés', 2, 'Macho', 'Mediano', 'Gato elegante y vocal. Le gusta la atención y es muy sociable.', 'https://images.unsplash.com/photo-1513245543132-31f507417b26?w=500', 'Disponible', 1),
('Nala', 'Gato', 'Persa', 3, 'Hembra', 'Mediano', 'Gata tranquila y mimosa. Necesita cepillado regular por su pelaje largo.', 'https://images.unsplash.com/photo-1518791841217-8f162f1e1131?w=500', 'Disponible', 1),
('Simba', 'Gato', 'Maine Coon', 1, 'Macho', 'Grande', 'Gato joven y juguetón de raza grande. Muy amigable con niños.', 'https://images.unsplash.com/photo-1574158622682-e40e69881006?w=500', 'Disponible', 2),
('Pelusa', 'Gato', 'Mestizo', 4, 'Hembra', 'Pequeño', 'Gata independiente pero cariñosa. Perfecta para hogares tranquilos.', 'https://images.unsplash.com/photo-1495360010541-f48722b34f7d?w=500', 'Adoptado', 2),
('Bigotes', 'Gato', 'Angora', 2, 'Macho', 'Mediano', 'Gato elegante de pelo blanco. Necesita familia que aprecie su belleza.', 'https://images.unsplash.com/photo-1529778873920-4da4926a72c2?w=500', 'Disponible', 3),

-- OTROS
('Bugs', 'Conejo', 'Mini Lop', 1, 'Macho', 'Pequeño', 'Conejito adorable y suave. Perfecto para niños, muy dócil.', 'https://images.unsplash.com/photo-1585110396000-c9ffd4e4b308?w=500', 'Disponible', 1),
('Plumas', 'Ave', 'Ninfa', 2, 'Hembra', 'Pequeño', 'Ave cantarina y sociable. Puede aprender a silbar melodías.', 'https://images.unsplash.com/photo-1552728089-57bdde30beb3?w=500', 'Disponible', 3);
GO

-- Solicitudes de adopción (variadas)
INSERT INTO SO_Solicitudes (IdMascota, IdUsuario, Estado, Comentarios, FechaSolicitud)
VALUES 
(1, 2, 'Pendiente', 'Tengo un jardín grande y experiencia con perros grandes.', DATEADD(day, -5, GETDATE())),
(2, 3, 'Aprobada', 'Buscamos una compañera para nuestros hijos. Tenemos patio cerrado.', DATEADD(day, -10, GETDATE())),
(5, 4, 'Pendiente', 'Vivo solo y busco compañía. Trabajo desde casa.', DATEADD(day, -2, GETDATE())),
(7, 2, 'Rechazada', 'Me encantan los gatos siameses.', DATEADD(day, -15, GETDATE())),
(10, 5, 'Aprobada', 'Ya tuve gatos antes, conozco sus cuidados.', DATEADD(day, -20, GETDATE())),
(12, 3, 'Pendiente', 'Mi hija quiere un conejito como mascota.', DATEADD(day, -1, GETDATE()));
GO

-- =============================================
-- VISTAS ÚTILES PARA REPORTES
-- =============================================

-- Vista: Mascotas con información completa
CREATE VIEW VW_MascotasCompletas AS
SELECT 
    m.Id,
    m.Nombre,
    m.Especie,
    m.Raza,
    m.Edad,
    m.Sexo,
    m.Tamanio,
    m.Descripcion,
    m.FotoUrl,
    m.Estado,
    r.Nombre AS NombreRefugio,
    m.FechaRegistro
FROM SO_Mascotas m
LEFT JOIN SO_Refugios r ON m.IdRefugio = r.Id;
GO

-- Vista: Solicitudes con información completa
CREATE VIEW VW_SolicitudesCompletas AS
SELECT 
    s.Id,
    m.Nombre AS NombreMascota,
    m.Especie,
    m.Raza,
    u.NombreCompleto AS NombreSolicitante,
    u.Email AS EmailSolicitante,
    u.Telefono AS TelefonoSolicitante,
    s.FechaSolicitud,
    s.Estado,
    s.Comentarios,
    s.MotivoRechazo,
    s.FechaRespuesta
FROM SO_Solicitudes s
INNER JOIN SO_Mascotas m ON s.IdMascota = m.Id
INNER JOIN SO_Usuarios u ON s.IdUsuario = u.Id;
GO

-- =============================================
-- CONSULTAS DE VERIFICACIÓN
-- =============================================

-- Ver todos los usuarios
SELECT * FROM SO_Usuarios;

-- Ver todos los refugios
SELECT * FROM SO_Refugios;

-- Ver todas las mascotas
SELECT * FROM SO_Mascotas ORDER BY FechaRegistro DESC;

-- Ver todas las solicitudes
SELECT * FROM SO_Solicitudes ORDER BY FechaSolicitud DESC;

-- Ver mascotas disponibles
SELECT * FROM VW_MascotasCompletas WHERE Estado = 'Disponible';

-- Ver solicitudes pendientes
SELECT * FROM VW_SolicitudesCompletas WHERE Estado = 'Pendiente';

-- Contar mascotas por estado
SELECT Estado, COUNT(*) AS Cantidad
FROM SO_Mascotas
GROUP BY Estado;

-- Contar mascotas por especie
SELECT Especie, COUNT(*) AS Cantidad
FROM SO_Mascotas
GROUP BY Especie;

GO

SELECT Especie, COUNT(*) as Cantidad 
FROM SO_Mascotas 
WHERE Estado = 'Disponible'
GROUP BY Especie;