-- Delete Examples
USE [A01-School]
GO

-- 1. A scandal has rocked the CSS club. The president has run off with all the
--    club's money. As such, the club is disbanded. Remove all the members of the
--    CSS club.
-- SELECT * FROM Activity order by ClubID
DELETE FROM Activity
WHERE  ClubID = 'CSS'

-- 2. Assume that the DBA has archived all the Payment and Registration data.
--    Write the statement to delete ALL the rows from these tables.
--    Make a note of how many rows are deleted for both of these tables.
DELETE FROM Payment

DELETE Registration -- Notice how the FROM keyword is optional

-- ** As a general rule of thumb, you shoule NOT be using a DELETE statement without a WHERE clause.
