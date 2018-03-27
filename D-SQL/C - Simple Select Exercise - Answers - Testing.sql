-- Stored Procedures (Sprocs)
-- File: C - Stored Procedures.sql

USE [A01-School]
GO

-- Testing with good data
EXEC ListStudentMarksByRange 75, 80

-- Testing for errors
EXEC ListStudentMarksByRange null, null
EXEC ListStudentMarksByRange 75, null
EXEC ListStudentMarksByRange null, 80
EXEC ListStudentMarksByRange 75, 50
