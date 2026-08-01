USE EmployeeManagement;
GO




CREATE PROCEDURE dbo.Department_GetList
(
    @DepartmentCode NVARCHAR(20)=NULL,
    @DepartmentName NVARCHAR(100)=NULL,
    @IsActive INT=NULL,
    @PageNumber INT=1,
    @PageSize INT=10,

    @RowsCount INT OUTPUT,
    @Output VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        ---------------------------------------------------------
        -- Total Records
        ---------------------------------------------------------

        SELECT
            @RowsCount = COUNT(*)
        FROM Department
        WHERE ISNULL(IsDeleted,0)=0
        AND (@DepartmentCode IS NULL OR @DepartmentCode='' OR DepartmentCode LIKE '%' + @DepartmentCode + '%')
        AND (@DepartmentName IS NULL OR @DepartmentName='' OR DepartmentName LIKE '%' + @DepartmentName + '%')
        AND (@IsActive IS NULL OR IsActive=@IsActive);

        ---------------------------------------------------------
        -- No Records
        ---------------------------------------------------------

        IF @RowsCount=0
        BEGIN
            SET @Output='No records found.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Get Records
        ---------------------------------------------------------

        SELECT
            DepartmentID,
            DepartmentCode,
            DepartmentName,
            DisplayOrder,
            IsActive,
            CreatedOn,
            ModifiedOn
        FROM Department
        WHERE ISNULL(IsDeleted,0)=0
        AND (@DepartmentCode IS NULL OR @DepartmentCode='' OR DepartmentCode LIKE '%' + @DepartmentCode + '%')
        AND (@DepartmentName IS NULL OR @DepartmentName='' OR DepartmentName LIKE '%' + @DepartmentName + '%')
        AND (@IsActive IS NULL OR IsActive=@IsActive)
        ORDER BY DepartmentName
        OFFSET (@PageNumber-1)*@PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        SET @Output='Records fetched successfully.';

    END TRY
    BEGIN CATCH

        SET @RowsCount=0;
        SET @Output=ERROR_MESSAGE();

    END CATCH
END
GO