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
-- ------------------------------------------------------------
-- Patching Department with the deferred FK
-- ------------------------------------------------------------
ALTER TABLE Department
    ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (Mgr_ssn)
        REFERENCES Employee(Ssn);
-- Mgr_ssn in Department must match a Ssn value in Employee.
GO

-- ------------------------------------------------------------
-- DEPT_LOCATIONS (multivalued attribute "Locations" -> its own table)
-- ------------------------------------------------------------
CREATE TABLE Dept_Locations (
                                Dnumber INT NOT NULL,
                                Dlocation VARCHAR(50)  NOT NULL,
                                CONSTRAINT PK_Dept_Locations PRIMARY KEY (Dnumber, Dlocation),
                                CONSTRAINT FK_DeptLocations_Department FOREIGN KEY (Dnumber)
                                    REFERENCES Department(Dnumber)
);
GO
-- ------------------------------------------------------------
-- PROJECT
-- ------------------------------------------------------------
CREATE TABLE Project (
                         Pnumber INT NOT NULL,
                         Pname VARCHAR(50)  NOT NULL,
                         Plocation VARCHAR(50)  NULL,
                         Dnum INT  NOT NULL,
                         CONSTRAINT PK_Project PRIMARY KEY (Pnumber),
                         CONSTRAINT UQ_Project_Name UNIQUE (Pname),
                         CONSTRAINT FK_Project_Department FOREIGN KEY (Dnum)
                             REFERENCES Department(Dnumber)
);
GO
-- ------------------------------------------------------------
-- WORKS_ON (M:N junction table between Employee and Project)
-- ------------------------------------------------------------
CREATE TABLE Works_On (
                          Essn CHAR(9) NOT NULL,
                          Pno INT NOT NULL,
                          Hours DECIMAL(4,1)  NOT NULL, --4 total digits, 1 after the decimal
                          CONSTRAINT PK_Works_On PRIMARY KEY (Essn, Pno), --composite PK
                          CONSTRAINT CK_WorksOn_Hours CHECK (Hours > 0),
                          CONSTRAINT FK_WorksOn_Employee FOREIGN KEY (Essn)
                              REFERENCES Employee(Ssn),
                          CONSTRAINT FK_WorksOn_Project FOREIGN KEY (Pno)
                              REFERENCES Project(Pnumber)
);
GO