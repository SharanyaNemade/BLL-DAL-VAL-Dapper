USE EmployeeManagement;
GO



CREATE PROCEDURE dbo.Department_Delete
(
    @DepartmentID    INT,
    @UserID          INT = NULL,
    @IPAddress       VARCHAR(50) = NULL,
    @Output          VARCHAR(500) OUTPUT
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
            SET @Output='DepartmentID not found.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Soft Delete
        ---------------------------------------------------------

        UPDATE Department
        SET
            IsDeleted = 1,
            ModifiedBy = @UserID,
            ModifiedOn = GETDATE(),
            IPAddress = @IPAddress
        WHERE DepartmentID = @DepartmentID;

        IF @@ROWCOUNT = 0
        BEGIN
            SET @Output='No record deleted.';
            RETURN;
        END;

        SET @Output='Department deleted successfully.';

    END TRY
    BEGIN CATCH
        SET @Output = ERROR_MESSAGE();
    END CATCH
END
GO