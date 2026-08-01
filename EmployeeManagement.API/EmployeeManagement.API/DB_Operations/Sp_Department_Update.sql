USE EmployeeManagementDB;
GO







CREATE PROCEDURE dbo.Department_Update
(
    @DepartmentID      INT,
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

        ---------------------------------------------------------
        -- Check Department Exists
        ---------------------------------------------------------

        IF NOT EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentID = @DepartmentID
              AND ISNULL(IsDeleted,0) = 0
        )
        BEGIN
            SET @Output = 'DepartmentID not found.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Check Duplicate Department Code
        ---------------------------------------------------------

        IF EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentCode = @DepartmentCode
              AND DepartmentID <> @DepartmentID
              AND ISNULL(IsDeleted,0) = 0
        )
        BEGIN
            SET @Output = 'DepartmentCode "' + @DepartmentCode + '" already exists.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Check Duplicate Department Name
        ---------------------------------------------------------

        IF EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentName = @DepartmentName
              AND DepartmentID <> @DepartmentID
              AND ISNULL(IsDeleted,0) = 0
        )
        BEGIN
            SET @Output = 'DepartmentName "' + @DepartmentName + '" already exists.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Update Department
        ---------------------------------------------------------

        UPDATE Department
        SET
            DepartmentCode = @DepartmentCode,
            DepartmentName = @DepartmentName,
            DisplayOrder = @DisplayOrder,
            IsActive = @IsActive,
            ModifiedBy = @UserID,
            ModifiedOn = GETDATE(),
            IPAddress = @IPAddress
        WHERE DepartmentID = @DepartmentID
          AND ISNULL(IsDeleted,0) = 0;

        ---------------------------------------------------------
        -- Check Update
        ---------------------------------------------------------

        IF @@ROWCOUNT = 0
        BEGIN
            SET @Output = 'No record updated.';
            RETURN;
        END;

        SET @Output = 'Department updated successfully.';

    END TRY
    BEGIN CATCH
        SET @Output = ERROR_MESSAGE();
    END CATCH
END;
GO