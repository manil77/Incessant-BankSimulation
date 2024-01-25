
This is ASP.NET6 application. 

Steps to run this project:
1. Simply Build the solution, add migrations and update the database.
2. You need you run this script for Stored Procedure.

**********************************************************

USE [IncessantRainStudio_BankDB]
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionSummary]    Script Date: 2024-01-25 5:54:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTransactionSummary]
AS
BEGIN
    with cte as (
select 
ur.Id,
ur.Name,
tr.Amount,
tr.TransactionType,
tr.TransactedDate
,
CASE 
	WHEN DATEPART(QUARTER, tr.TransactedDate) = 1 THEN 'Q1'
	WHEN DATEPART(QUARTER, tr.TransactedDate) = 2 THEN 'Q2'
	WHEN DATEPART(QUARTER, tr.TransactedDate) = 3 THEN 'Q3'
	WHEN DATEPART(QUARTER, tr.TransactedDate) = 4 THEN 'Q4'
	End as Quarter
from Transactions tr
join AspNetUsers ur on tr.UserId = ur.Id
)
select 
Id,
Name,
Sum(Amount) as Amount,
TransactionType,
Quarter
from cte
group by Id,Name, TransactionType, Quarter
order by Quarter, TransactionType
END;


***************************************************


