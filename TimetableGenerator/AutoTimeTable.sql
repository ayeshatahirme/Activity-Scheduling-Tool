
CREATE TABLE COURSE (
ID VARCHAR(25) NOT NULL PRIMARY KEY,
COUESECODE VARCHAR(50),
SEMESTER VARCHAR(25) NOT NULL,
ROOM VARCHAR(25) NOT NULL
);

CREATE TABLE SUBJECT1 ( 
SUBJ1 VARCHAR(25),
CHRS1 VARCHAR(30),
TEACHER1 VARCHAR(50),
SUBTYPE1 VARCHAR(50),
S_ID1 VARCHAR(25)
);

CREATE TABLE SUBJECT2 ( 
SUBJ2 VARCHAR(25),
CHRS2 VARCHAR(30),
TEACHER2 VARCHAR(50),
SUBTYPE2 VARCHAR(50),
S_ID2 VARCHAR(25)
);

CREATE TABLE SUBJECT3 ( 
SUBJ3 VARCHAR(25),
CHRS3 VARCHAR(30),
TEACHER3 VARCHAR(50),
SUBTYPE3 VARCHAR(50),
S_ID3 VARCHAR(25)
);

CREATE TABLE SUBJECT4 ( 
SUBJ4 VARCHAR(25),
CHRS4 VARCHAR(30),
TEACHER4 VARCHAR(50),
SUBTYPE4 VARCHAR(50),
S_ID4 VARCHAR(25)
);

CREATE TABLE SUBJECT5 ( 
SUBJ5 VARCHAR(25),
CHRS5 VARCHAR(30),
TEACHER5 VARCHAR(50),
SUBTYPE5 VARCHAR(50),
S_ID5 VARCHAR(25)
);

CREATE TABLE SUBJECT6 ( 
SUBJ6 VARCHAR(25),
CHRS6 VARCHAR(30),
TEACHER6 VARCHAR(50),
SUBTYPE6 VARCHAR(50),
S_ID6 VARCHAR(25)
);

CREATE TABLE SUBJECT7 ( 
SUBJ7 VARCHAR(25),
CHRS7 VARCHAR(30),
TEACHER7 VARCHAR(50),
SUBTYPE7 VARCHAR(50),
S_ID7 VARCHAR(25),
USID7 VARCHAR(25) FOREIGN KEY REFERENCES COURSE(ID) 
);

CREATE TABLE SUBJECT8 ( 
SUBJ8 VARCHAR(25),
CHRS8 VARCHAR(30),
TEACHER8 VARCHAR(50),
SUBTYPE8 VARCHAR(50),
S_ID8 VARCHAR(25)
);

CREATE TABLE WEEKDAYS ( 
W_D VARCHAR(50)
);

CREATE TABLE TIMETABLE (
T_ID VARCHAR(50) NOT NULL PRIMARY KEY,
LEC1 VARCHAR(50),
LEC2 VARCHAR(50),
LEC3 VARCHAR(50),
LEC4 VARCHAR(50),
TBREAK VARCHAR(50),
LEC5 VARCHAR(50),
LEC6 VARCHAR(50),
USID VARCHAR(25) FOREIGN KEY REFERENCES COURSE(ID) 
);

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [W_D]
  FROM [AutoTimeTable].[dbo].[WEEKDAYS]

SELECT TOP 100 [SUBJ1]
      ,[CHRS1]
      ,[TEACHER1]
      ,[SUBTYPE1]
      ,[S_ID1]
      ,[USID1]
  FROM [AutoTimeTable].[dbo].[SUBJECT1]
  
  /* ----------------------- 2 ------------------------- */
SELECT TOP 100 [SUBJ2]
      ,[CHRS2]
      ,[TEACHER2]
      ,[SUBTYPE2]
      ,[S_ID2]
      ,[USID2]
  FROM [AutoTimeTable].[dbo].[SUBJECT2]
  
  /* ----------------------- 3 ------------------------- */
SELECT TOP 100 [SUBJ3]
      ,[CHRS3]
      ,[TEACHER3]
      ,[SUBTYPE3]
      ,[S_ID3]
      ,[USID3]
  FROM [AutoTimeTable].[dbo].[SUBJECT3]

  /* ----------------------- 4 ------------------------- */  
SELECT TOP 100 [SUBJ4]
      ,[CHRS4]
      ,[TEACHER4]
      ,[SUBTYPE4]
      ,[S_ID4]
      ,[USID4]
  FROM [AutoTimeTable].[dbo].[SUBJECT4]
  
  /* ----------------------- 5 ------------------------- */
SELECT TOP 100 [SUBJ5]
      ,[CHRS5]
      ,[TEACHER5]
      ,[SUBTYPE5]
      ,[S_ID5]
      ,[USID5]
  FROM [AutoTimeTable].[dbo].[SUBJECT5]
  
  /* ----------------------- 6 ------------------------- */
SELECT TOP 100 [SUBJ6]
      ,[CHRS6]
      ,[TEACHER6]
      ,[SUBTYPE6]
      ,[S_ID6]
      ,[USID6]
  FROM [AutoTimeTable].[dbo].[SUBJECT6]
  
  /* ----------------------- 7 ------------------------- */
SELECT TOP 100 [SUBJ7]
      ,[CHRS7]
      ,[TEACHER7]
      ,[SUBTYPE7]
      ,[S_ID7]
      ,[USID7]
  FROM [AutoTimeTable].[dbo].[SUBJECT7]
  
  /* ----------------------- 8 ------------------------- */
SELECT TOP 100 [SUBJ8]
      ,[CHRS8]
      ,[TEACHER8]
      ,[SUBTYPE8]
      ,[S_ID8]
      ,[USID8]
  FROM [AutoTimeTable].[dbo].[SUBJECT8]
  
  /* ----------- Script for SelectTopNRows command from SSMS ------------- */
SELECT TOP 1000 [ID]
      ,[COUESECODE]
      ,[SEMESTER]
      ,[ROOM]
  FROM [AutoTimeTable].[dbo].[COURSE]

  /* ---------- Script for SelectTopNRows command from SSMS  ------------ */
SELECT TOP 100 [T_ID]
      ,[LEC1]
      ,[LEC2]
      ,[LEC3]
      ,[LEC4]
      ,[TBREAK]
      ,[LEC5]
      ,[LEC6]
      ,[USID]
	  ,[LEC7]
  FROM [AutoTimeTable].[dbo].[TIMETABLE]

  /* ------------------------- WEEKDAYS ------------------------ */
 
  SELECT TOP 1000 [W_D]
  FROM [AutoTimeTable].[dbo].[WEEKDAYS]

  /* ------------------------- USER TABLE ------------------------- */
  SELECT TOP 100 [UserID]
      ,[FirstName]
      ,[LastName]
      ,[Email]
      ,[Password]
  FROM [AutoTimeTable].[dbo].[UserTable]
  