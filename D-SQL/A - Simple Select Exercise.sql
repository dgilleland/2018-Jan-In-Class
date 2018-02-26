--SIMPLE SELECT EXERCISE 1

USE [A01-School]
GO

-- Simple Select, without any other clauses
SELECT  'Dan', 'Gilleland'

-- Simple Select with expressions
SELECT  'Dan' + ' ' + 'Gilleland', 18 * 52

-- Specify a column name with some hard-code/calculated values
SELECT  'Dan' + ' ' + 'Gilleland' AS 'Instructor',
        18 * 52 AS 'Weeks at the job'

-- Let's use the SELECT statement with database tables

-- 1.   Select all the information from the Club table
SELECT  ClubId, ClubName
FROM    Club
  -- Pro-Tip: If you write the FROM clause before specifying the columns,
  --            you will get Intellisense help on the column names
  -- Pro-Tip: Press [ctrl] + [shift] + r to "refresh" intellisens

-- 2.   Select the FirstNames and LastNames of all the students
SELECT  FirstName, LastName
FROM    Student
-- 2.a. Repeat the above query, but using column aliases
SELECT  FirstName AS 'First Name', LastName AS 'Last Name'
FROM    Student
-- 2.b. Select the student id and full name of all the students
SELECT  StudentID, FirstName + ' ' + LastName AS 'Full Name'
FROM    Student

--3. Select all the CourseId and CourseName of all the courses. Use the column aliases of Course ID and Course Name
SELECT  CourseId AS 'Course ID', CourseName AS 'Course Name'
FROM    Course

--4. Select all the course information for courseID 'DMIT101'
-- I will mark the following as a ZERO
--SELECT  * -- All columns
--FROM    Course
SELECT CourseID, CourseName, CourseHours, MaxStudents, CourseCost
FROM   Course
WHERE  CourseID = 'DMIT101'

--5. Select the Staff names who have positionID of 3
SELECT FirstName, LastName
      --,PositionID -- Press [ctrl] + k, then [ctrl] + u to un-comment
FROM   Staff
WHERE  PositionID = 3

        -- BTW, what is PositionID of 3 referring to?
SELECT  PositionID, PositionDescription
FROM    Position

--6.    Select the Course Names whose course hours are less than 96
SELECT  C.CourseName
FROM    Course C -- I can have an alias to the table name
WHERE   C.CourseHours < 96

-- 7.   Select the studentID's, CourseID and mark where the Mark is between 70 and 80
SELECT  StudentID, CourseId, Mark
FROM    Registration
WHERE   Mark BETWEEN 70 AND 80 -- BETWEEN is inclusive
--WHERE   Mark >= 70 AND Mark <= 80

-- 7.a. Select the StudentIDs where the withdrawal status is null
SELECT  StudentID
        --, WithdrawYN
FROM    Registration
WHERE   WithdrawYN IS NULL -- we use IS NULL instead of = NULL, because = NULL won't work.

-- 7.b. Select the student ids of students who have withdrawn from a course
SELECT  StudentID
FROM    Registration
WHERE   WithdrawYN = 'Y'

--8.    Select the studentID's, CourseID and mark where the Mark is between 70 and 80
--      and the courseID is DMIT223 or DMIT168
SELECT  R.StudentID, R.CourseId, R.Mark
FROM    Registration R
WHERE   R.Mark BETWEEN 70 AND 80
  AND   (R.CourseId = 'DMIT223' OR R.CourseId = 'DMIT168')
-- alternate answer to #8
SELECT  R.StudentID, R.CourseId, R.Mark
FROM    Registration R
WHERE   R.Mark BETWEEN 70 AND 80
  AND   R.CourseId IN ('DMIT223', 'DMIT168')

--8.a. Select the studentIDs, CourseID and mark where the Mark is 80 and 85
SELECT  R.StudentID, R.CourseId, R.Mark
FROM    Registration R
WHERE   R.Mark = 80 OR R.Mark = 85
