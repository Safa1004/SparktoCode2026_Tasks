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
-- ------------------------------------------------------------
-- DEPENDENT (weak entity, identifying relationship DEPENDENTS_OF)
-- ------------------------------------------------------------
CREATE TABLE Dependent (
                           Essn CHAR(9) NOT NULL,
                           Dependent_name  VARCHAR(50)  NOT NULL,
                           Sex CHAR(1) NULL,
                           Bdate  DATE NULL,
                           Relationship VARCHAR(20) NULL,
                           CONSTRAINT PK_Dependent PRIMARY KEY (Essn, Dependent_name),
                           CONSTRAINT CK_Dependent_Sex CHECK (Sex IN ('M', 'F')),
                           CONSTRAINT FK_Dependent_Employee FOREIGN KEY (Essn)
                               REFERENCES Employee(Ssn)
);
GO
-- ------------------------------------------------------------
-- CRUD OPERATIONS
-- ------------------------------------------------------------
/* 5 INSERT statements — populate the database with realistic sample data 
  (must include at least one Employee who is a manager, 
  one who is a supervisor of another, 
  and at least one Dependent and one Works_On record) */
/* 5 UPDATE statements — each targeting a different table or a different kind of change 
   (e.g. give an employee a raise, reassign an employee to a new department, 
   change a project's location, update hours worked, correct a dependent's relationship)*/
/* 2 DELETE statements — demonstrate correct handling of referential integrity 
   (e.g. what happens when deleting an Employee who has Dependents or Works_On records —
   either cascade appropriately or delete child rows first, and be ready to explain your choice)*/
INSERT INTO Department (Dnumber, Dname, Mgr_ssn, Mgr_start_date, NumberOfEmployees)
VALUES
    (1, 'Research',   NULL, NULL, 0),
    (2, 'Administration', NULL, NULL, 0),
    (3, 'Headquarters', NULL, NULL, 0);
GO

INSERT INTO Employee (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Super_ssn, Dno)
VALUES
    ('111111111', 'Reham',  'S', 'AlKhamiasi', 'Muscat, Oman', 'F', '1999-11-11', 1200.00, NULL,        3),
    ('222222222', 'Haithem',   'K', 'AlKhamiasi',  'Sur, Oman',    'M', '1990-08-21', 850.00,  '111111111', 1),
    ('333333333', 'Safa',  'M', 'AlKhamiasi',  'Muscat, Oman', 'F', '2004-10-12', 700.00,  '222222222', 1),
    ('444444444', 'Marwa', 'H', 'AlBalushi', 'Salalah, Oman','F', '2000-08-30', 950.00,  '111111111', 2);
GO

UPDATE Department SET Mgr_ssn = '111111111', Mgr_start_date = '2020-01-01' WHERE Dnumber = 3;
UPDATE Department SET Mgr_ssn = '222222222', Mgr_start_date = '2021-03-15' WHERE Dnumber = 1;
UPDATE Department SET Mgr_ssn = '444444444', Mgr_start_date = '2022-07-01' WHERE Dnumber = 2;
GO

INSERT INTO Dept_Locations (Dnumber, Dlocation)
VALUES
    (1, 'Muscat'),
    (1, 'Sur'),
    (2, 'Salalah'),
    (3, 'Muscat');
GO

INSERT INTO Project (Pnumber, Pname, Plocation, Dnum)
VALUES
    (10, 'Database Migration', 'Muscat', 1),
    (20, 'Payroll System',     'Salalah', 2),
    (30, 'Company Website',    'Muscat', 3);
GO

INSERT INTO Works_On (Essn, Pno, Hours)
VALUES
    ('222222222', 10, 20.0),
    ('333333333', 10, 15.5),
    ('444444444', 20, 30.0);

INSERT INTO Dependent (Essn, Dependent_name, Sex, Bdate, Relationship)
VALUES
    ('222222222', 'Huda',  'F', '2015-05-10', 'Daughter'),
    ('444444444', 'Salim', 'M', '2018-11-02', 'Son');
GO