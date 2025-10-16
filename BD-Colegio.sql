CREATE TABLE Colegio (
    IdColegio INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    RUC VARCHAR(20) NOT NULL,
    Direccion VARCHAR(150) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(80),
    Director VARCHAR(100),
    Estado BIT NOT NULL DEFAULT 1
);
go

CREATE PROCEDURE sp_Colegio_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        IdColegio,
        Nombre,
        RUC,
        Direccion,
        Telefono,
        Email,
        Director,
        Estado
    FROM Colegio;
END;
GO
CREATE PROCEDURE sp_Colegio_GetById
    @IdColegio INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdColegio,
        Nombre,
        RUC,
        Direccion,
        Telefono,
        Email,
        Director,
        Estado
    FROM Colegio
    WHERE IdColegio = @IdColegio;
END;
GO
CREATE PROCEDURE sp_Colegio_Insert
    @Nombre VARCHAR(100),
    @RUC VARCHAR(20),
    @Direccion VARCHAR(150),
    @Telefono VARCHAR(20),
    @Email VARCHAR(80),
    @Director VARCHAR(100),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Colegio (Nombre, RUC, Direccion, Telefono, Email, Director, Estado)
    VALUES (@Nombre, @RUC, @Direccion, @Telefono, @Email, @Director, @Estado);

    -- Retorna el ID generado
    SELECT SCOPE_IDENTITY() AS NuevoIdColegio;
END;
GO
CREATE PROCEDURE sp_Colegio_Update
    @IdColegio INT,
    @Nombre VARCHAR(100),
    @RUC VARCHAR(20),
    @Direccion VARCHAR(150),
    @Telefono VARCHAR(20),
    @Email VARCHAR(80),
    @Director VARCHAR(100),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Colegio
    SET 
        Nombre = @Nombre,
        RUC = @RUC,
        Direccion = @Direccion,
        Telefono = @Telefono,
        Email = @Email,
        Director = @Director,
        Estado = @Estado
    WHERE IdColegio = @IdColegio;
END;
GO
CREATE PROCEDURE sp_Colegio_Delete
    @IdColegio INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Colegio
    WHERE IdColegio = @IdColegio;
END;
GO



