USE EmployeeManagement;
GO



CREATE PROCEDURE dbo.Department_Create
(
    @DepartmentCode    NVARCHAR(20),
    @DepartmentName    NVARCHAR(100),
    @DisplayOrder      SMALLINT = 100,
    @IsActive          BIT = 1,
    @UserID            INT = NULL,
    @IPAddress         VARCHAR(50) = NULL,
    @Output            VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY

        -------------------------------------------------------
        -- Check Duplicate Department Code
        -------------------------------------------------------

        IF EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentCode = @DepartmentCode
              AND ISNULL(IsDeleted,0) = 0
        )
        BEGIN
            SET @Output = 'DepartmentCode "' + @DepartmentCode + '" already exists.';
            RETURN;
        END;

        -------------------------------------------------------
        -- Check Duplicate Department Name
        -------------------------------------------------------

        IF EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentName = @DepartmentName
              AND ISNULL(IsDeleted,0) = 0
        )
        BEGIN
            SET @Output = 'DepartmentName "' + @DepartmentName + '" already exists.';
            RETURN;
        END;

        -------------------------------------------------------
        -- Insert Department
        -------------------------------------------------------

        INSERT INTO Department
        (
            DepartmentCode,
            DepartmentName,
            DisplayOrder,
            IsActive,
            CreatedBy,
            CreatedOn,
            IPAddress,
            IsDeleted
        )
        VALUES
        (
            @DepartmentCode,
            @DepartmentName,
            @DisplayOrder,
            @IsActive,
            @UserID,
            GETDATE(),
            @IPAddress,
            0
        );

        SET @Output = 'Department created successfully.';

    END TRY
    BEGIN CATCH
        SET @Output = ERROR_MESSAGE();
    END CATCH
END;
GO