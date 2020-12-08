USE ContosoUniversity

ALTER TABLE Course
ADD IsDeleted bit NOT NULL DEFAULT(0) 

ALTER TABLE Department
ADD IsDeleted bit NOT NULL DEFAULT(0) 

ALTER TABLE Person 
ADD IsDeleted bit NOT NULL DEFAULT(0) 