--View Exercise
-- If an operation fails write a brief explanation why. Do not just quote the error message genereated by the server!

USE [A01-School]
GO

--1.  Create a view of staff full names called StaffList.
IF OBJECT_ID('StaffList', 'V') IS NOT NULL
    DROP VIEW StaffList
GO
CREATE VIEW StaffList
AS
    SELECT  FirstName + ' ' + LastName AS 'StaffFullName'
    FROM    Staff
GO
-- SP_HELPTEXT StaffList    -- Gets the text of the View
-- SP_HELP StaffList        -- Gets schema info on the View

--2.  Create a view of staff ID's, full names, positionID's and datehired called StaffConfidential.

--3.  Create a view of student ID's, full names, courseId's, course names, and grades called StudentGrades.

--4.  Use the student grades view to create a grade report for studentID 199899200 that shows the students ID, full name, course names and marks.

--5.  Select the same information using the student grades view for studentID 199912010.

--6.  Using the student grades view  update the mark for studentID 199899200 in course dmit152 to be 90  and change the coursename to be 'basket weaving 101'.

--7.  Using the student grades view, update the  mark for studentID 199899200 in course dmit152 to be 90.

--8.  Using the student grades view, delete the same record from question 7.

--9.  Retrieve the code for the student grades view from the database.

