CREATE DATABASE CompanyDB;
GO
USE CompanyDB;
GO --closes the batch 
-- ------------------------------------------------------------
-- DEPARTMENT (created WITHOUT the Mgr_ssn FK constraint first)
-- ------------------------------------------------------------
CREATE TABLE Department (
                            Dnumber INT NOT NULL ,
                            Dname VARCHAR(50) NOT NULL ,
                            Mgr_ssn CHAR(9) NULL, --maybe a department may not have assigned manager yet
                            Mgr_start_date DATE NULL,
                            NumberOfEmployees INT NOT NULL DEFAULT 0,
                            CONSTRAINT PK_Department PRIMARY KEY (Dnumber),
                            CONSTRAINT UQ_Department_Name UNIQUE (Dname) --alternative key, no duplicates



);
GO