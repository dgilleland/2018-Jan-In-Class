-- Stored Procedures (Sprocs)
-- File: C - Stored Procedures.sql

USE [A01-School]
GO

-- Take the following queries and turn them into stored procedures.

-- 1.   Selects the studentID's, CourseID and mark where the Mark is between 70 and 80
--      Place this in a stored procedure that has two parameters,
--      one for the upper value and one for the lower value.
--      Call the stored procedure ListStudentMarksByRange
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'ListStudentMarksByRange')
    DROP PROCEDURE ListStudentMarksByRange
GO
CREATE PROCEDURE ListStudentMarksByRange
    -- Parameters here
    @Lower    int,
    @Upper    int
AS
    -- Body of procedure here
    IF (@Lower IS NULL OR @Upper IS NULL)
    BEGIN
        RAISERROR('The Lower and Upper values are required', 16, 1)
    END
    ELSE
    BEGIN
        IF (@Lower > @Upper)
        BEGIN
            RAISERROR('The Lower value cannot be greater than the upper value', 16, 1)
        END
        ELSE
        BEGIN
            SELECT  StudentID, CourseId, Mark
            FROM    Registration
            WHERE   Mark BETWEEN @Lower AND @Upper -- BETWEEN is inclusive
        END
    END
RETURN
GO


/* ----------------------------------------------------- */

-- 2.	Selects the Staff full names and the Course ID's they teach.
--      Place this in a stored procedure called CourseInstructors.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'CourseInstructors')
    DROP PROCEDURE CourseInstructors
GO
CREATE PROCEDURE CourseInstructors
    -- Parameters here
AS
    -- Body of procedure here
    SELECT  DISTINCT -- The DISTINCT keyword will remove duplate rows from the results
            FirstName + ' ' + LastName AS 'Staff Full Name',
            CourseId
    FROM    Staff S
        INNER JOIN Registration R
            ON S.StaffID = R.StaffID
    ORDER BY 'Staff Full Name', CourseId
RETURN
GO


/* ----------------------------------------------------- */

-- 3.   Selects the students first and last names who have last names starting with S.
--      Place this in a stored procedure called FindStudentByLastName.
--      The parameter should be called @PartialName.
--      Do NOT assume that the '%' is part of the value in the parameter variable;
--      Your solution should concatenate the @PartialName with the wildcard.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'FindStudentByLastName')
    DROP PROCEDURE FindStudentByLastName
GO
CREATE PROCEDURE FindStudentByLastName
    -- Parameters here
    @PartialName    varchar(35)
AS
    -- Body of procedure here
    IF @PartialName IS NULL
    BEGIN
        RAISERROR('Partial name value is required', 16, 1)
    END
    ELSE
    BEGIN
        SELECT  FirstName, LastName
        FROM    Student
        WHERE   LastName LIKE @PartialName + '%'
    END
RETURN
GO


/* ----------------------------------------------------- */

-- 4.   Selects the CourseID's and Coursenames where the CourseName contains the word 'programming'.
--      Place this in a stored procedure called FindCourse.
--      The parameter should be called @PartialName.
--      Do NOT assume that the '%' is part of the value in the parameter variable.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'FindCourse')
    DROP PROCEDURE FindCourse
GO
CREATE PROCEDURE FindCourse
    -- Parameters here
    @PartialName    varchar(40)
AS
    -- Body of procedure here
    IF @PartialName IS NULL
    BEGIN
        RAISERROR('Partial name value is required', 16, 1)
    END
    ELSE
    BEGIN
        SELECT  CourseId, CourseName
        FROM    Course
        WHERE   CourseName LIKE '%' + @PartialName + '%'
    END
RETURN
GO


/* ----------------------------------------------------- */

-- 5.   Selects the Payment Type Description(s) that have the highest number of Payments made.
--      Place this in a stored procedure called MostFrequentPaymentTypes.
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'MostFrequentPaymentTypes')
    DROP PROCEDURE MostFrequentPaymentTypes
GO
CREATE PROCEDURE MostFrequentPaymentTypes
    -- Parameters here
AS
    -- Body of procedure here
    SELECT PaymentTypeDescription
    FROM   Payment 
        INNER JOIN PaymentType 
            ON Payment.PaymentTypeID = PaymentType.PaymentTypeID
    GROUP BY PaymentType.PaymentTypeID, PaymentTypeDescription 
    HAVING COUNT(PaymentType.PaymentTypeID) >= ALL (SELECT COUNT(PaymentTypeID)
                                                    FROM Payment 
                                                    GROUP BY PaymentTypeID)
RETURN
GO
