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
-- ------------------------------------------------------------
-- EMPLOYEE
-- ------------------------------------------------------------
CREATE TABLE Employee (
    --
                          Ssn CHAR(9) NOT NULL,
                          Fname VARCHAR(20) NOT NULL,
                          Minit CHAR(1) NULL,
                          Lname VARCHAR(20) NOT NULL,
                          Address VARCHAR(100) NULL,
                          Sex CHAR(1) NULL,
                          Bdate DATE NULL,
                          Salary DECIMAL(10,2) NOT NULL,
                          Super_ssn CHAR(9) NULL,
                          Dno  INT NOT NULL,
                          CONSTRAINT PK_Employee PRIMARY KEY (Ssn),
                          CONSTRAINT CK_Employee_Sex CHECK (Sex IN ('M', 'F')), --CHECK constraint only the M and F are allowed and reject anything else
                          CONSTRAINT CK_Employee_Salary CHECK (Salary > 0),
                          CONSTRAINT FK_Employee_Supervisor FOREIGN KEY (Super_ssn)
                              REFERENCES Employee(Ssn),
                          CONSTRAINT FK_Employee_Department FOREIGN KEY (Dno)
                              REFERENCES Department(Dnumber)

);
GO