USE EmployeeManagement;
GO




CREATE PROCEDURE dbo.Department_GetById
(
    @DepartmentID INT,
    @Output VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        ---------------------------------------------------------
        -- Check Department Exists
        ---------------------------------------------------------

        IF NOT EXISTS
        (
            SELECT 1
            FROM Department
            WHERE DepartmentID=@DepartmentID
            AND ISNULL(IsDeleted,0)=0
        )
        BEGIN
            SET @Output='DepartmentID not found.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Get Department
        ---------------------------------------------------------

        SELECT
            DepartmentID,
            DepartmentCode,
            DepartmentName,
            DisplayOrder,
            IsActive,
            CreatedBy,
            CreatedOn,
            ModifiedBy,
            ModifiedOn
        FROM Department
        WHERE DepartmentID=@DepartmentID
        AND ISNULL(IsDeleted,0)=0;

        SET @Output='Record fetched successfully.';

    END TRY
    BEGIN CATCH
        SET @Output=ERROR_MESSAGE();
    END CATCH
END
GO