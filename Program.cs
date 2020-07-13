
CREATE PROC[dbo].[GenerateTimeTablesForAllSession] (@StartDate Date, @EndDate Date, @Message nvarchar(100) output)

AS

BEGIN

//-------------------- Here we are using Genetic Algorithem  ---------------------------------

//-- Get All Sujects -- All Subject here Chromosomes, and one subject is Gen

DECLARE @ALLSubjectSemesterTable Table(RowNo int, RepeatedRowNo int, ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))

DECLARE @SubjectSemesterTable Table(RowNo int, ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))
 

//-- Get All Practical Class

DECLARE @PracticalSubjectTable Table(ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))

DECLARE @PracticalRandomSubjectTable Table(RowNo int, ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))
 

//-- Get All Non Practical Class

DECLARE @NonPracticalSubjectTable Table(ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))

DECLARE @NonPracticalRandomSubjectTable Table(RowNo int, ProgramSemesterID int, CrHrs int, ProgramSemesterSubjectID int, SSTitle nvarchar(300),Title nvarchar(200),RoomTypeID int,LectureID int,SessionID int, SessionTitle NVARCHAR(200))

 
//-- Get All Avalibale Slots -- Room and Lab Population

DECLARE @ALLRoomsSlots Table(RowNo int, DayTimeSlotID int, SlotTitle nvarchar(200),StartTime Time, EndTime Time,DayID int,DayTitle nvarchar(100),RoomID int,RoomNo nvarchar(200),Capacity int)

DECLARE @ALLLabsSlots Table(RowNo int, DayTimeSlotID int, SlotTitle nvarchar(200),StartTime Time, EndTime Time,DayID int,DayTitle nvarchar(100),LabID int,LabNo nvarchar(200),Capacity int)
 

Insert into @SubjectSemesterTable(RowNo, ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle) select Row_Number() over(Order By(SELECT 1)) as RowNo, ProgramSemesterID,CrHrs,ProgramSemesterSubjectID,SSTitle,Title,RoomTypeID,LectureID,SessionID,SessionTitle From v_AllSemesterSectionSubjects Order By NewID();


DECLARE @IndexNo int = 1;

DECLARE @RowNo int = 1;

DECLARE @CountRecord int = (Select Count(*) From @SubjectSemesterTable);

                WHILE @IndexNo <= @CountRecord

                                BEGIN
                                                DECLARE @RepeatPrint AS INT = (SELECT CrHrs From @SubjectSemesterTable where RowNo = @IndexNo);
                                                DECLARE @CountCrHrs int = 1;

                                                               WHILE @CountCrHrs <=@RepeatPrint
                                                                               BEGIN
                                                                                                Insert into @ALLSubjectSemesterTable(RowNo, RepeatedRowNo, ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle) select @RowNo, RowNo, ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle From @SubjectSemesterTable WHERE RowNo = @IndexNo;

SET @CountCrHrs = @CountCrHrs + 1;

SET @RowNo = @RowNo + 1;

END

SET @IndexNo = @IndexNo + 1;

                                END

//-- Getting Practical Class

INSERT INTO @PracticalSubjectTable(ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle)

SELECT ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle From @ALLSubjectSemesterTable WHERE RoomTypeID = 4  Order By NewID();



INSERT INTO @PracticalRandomSubjectTable(RowNo, ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle)

SELECT ROW_NUMBER() over(Order By (Select 1)), ProgramSemesterID,CrHrs,ProgramSemesterSubjectID,SSTitle,Title,RoomTypeID,LectureID,SessionID,SessionTitle From @PracticalSubjectTable;

 

//-- Getting Non Practical Class

INSERT INTO @NonPracticalSubjectTable(ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle)

SELECT ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle From @ALLSubjectSemesterTable WHERE RoomTypeID = 3  Order By NewID();



INSERT INTO @NonPracticalRandomSubjectTable(RowNo, ProgramSemesterID, CrHrs, ProgramSemesterSubjectID, SSTitle, Title, RoomTypeID, LectureID, SessionID, SessionTitle)

SELECT ROW_NUMBER() over(Order By (Select 1)), ProgramSemesterID,CrHrs,ProgramSemesterSubjectID,SSTitle,Title,RoomTypeID,LectureID,SessionID,SessionTitle From @NonPracticalSubjectTable;

 

//-- Second Step(Here we are getting Population)

  //                              --             Population is All Time Slots in Time Table

 

//-- Getting All Rooms Time Slots  -- It's Room Slots Population

INSERT INTO @ALLRoomsSlots(RowNo, DayTimeSlotID, SlotTitle, StartTime, EndTime, DayID, DayTitle, RoomID, RoomNo, Capacity)

SELECT Row_Number() over(Order By(SELECT 1))as RowNo,DayTimeSlotID,SlotTitle,StartTime,EndTime,DayID,Name,RoomID,RoomNo,Capacity FROM v_AllActiveTimeSlots

CROSS JOIN(SELECT* FROM RoomTable where IsActive = 1) RT WHERE SlotStatus = 1

ORDER BY RT.RoomID

 

//-- Getting All Labs Time Slots   -- It's Lab Slots Population

Insert into @ALLLabsSlots(RowNo, DayTimeSlotID, SlotTitle, StartTime, EndTime, DayID, DayTitle, LabID, LabNo, Capacity)

SELECT Row_Number() over(Order By(SELECT 1))as RowNo,DayTimeSlotID,SlotTitle,StartTime,EndTime,DayID,Name,LabID,LabNo,Capacity FROM v_AllActiveTimeSlots

CROSS JOIN(SELECT* FROM LabTable where IsActive = 1) LT WHERE SlotStatus = 1

ORDER BY LT.LabID

 

//-- DECLARE Variables For Check Time Slots is Enough

DECLARE @AllPracticalClass int = (SELECT COUNT(*) FROM @PracticalRandomSubjectTable);

DECLARE @AllNonPracticalClass int = (SELECT COUNT(*) FROM @NonPracticalRandomSubjectTable);

DECLARE @TotalLabsTimeSlot int = (SELECT COUNT(*) FROM @ALLLabsSlots);

DECLARE @TotalRoomsTimeSlot int = (SELECT COUNT(*) FROM @ALLRoomsSlots);

DECLARE @RemainingSlotsLabs int =  @TotalLabsTimeSlot - @AllPracticalClass;

DECLARE @TotalNonPracticalTimeSlots int = @TotalRoomsTimeSlot + @RemainingSlotsLabs;

DECLARE @TotalTimeSlots int = @TotalRoomsTimeSlot + @TotalLabsTimeSlot

DECLARE @TotalClass int = @AllPracticalClass + @AllNonPracticalClass;

 

//-- DECLARE Lab's Break Duration Variables

DECLARE @LabDefference float = 0;

DECLARE @SetLabDefference float = 0;

DECLARE @LabBreak int = 0;

 

//-- DECLARE Room's Break Duration Variables

DECLARE @RoomDefference float = 0;

DECLARE @SetRoomDefference float = 0;

DECLARE @RoomBreak int = 0;

 

//-- Checking Slots and Subjects that's Enough or Not

                IF @AllNonPracticalClass > @TotalNonPracticalTimeSlots

                BEGIN

                                SET @Message = 'Please Add More Rooms Or Labs';

                return;

                END

                ELSE IF @AllPracticalClass > @TotalLabsTimeSlot

                BEGIN

                                SET @Message = 'Please Add More Labs';

                return;

                END

                ELSE

                BEGIN

                                SET @Message = 'Labs or Rooms is Enough';

                END

 

//-- Initilization Slots Break Duration Variables

   IF @TotalTimeSlots = @TotalClass

   BEGIN

                SET @RoomBreak = 0;

SET @LabBreak = 0;

END

ELSE IF @AllNonPracticalClass<@TotalRoomsTimeSlot OR @AllNonPracticalClass = @TotalRoomsTimeSlot

   BEGIN

  //   -- Set Room Break

                SET @RoomDefference = @TotalRoomsTimeSlot - @AllNonPracticalClass;

                SET @SetRoomDefference = @TotalRoomsTimeSlot / @RoomDefference;

                //--SET @RoomBreak = Cast(@SetRoomDefference as int) + 1;

                SET @RoomBreak = Cast(@SetRoomDefference as int);

               // -- Set Lab Break

                SET @LabDefference = @TotalLabsTimeSlot - @AllPracticalClass;

                SET @SetLabDefference = @TotalLabsTimeSlot / @LabDefference;

               // --SET @LabBreak = Cast(@SetLabDefference as int) + 1;

SET @LabBreak = Cast(@SetLabDefference as int);



SET @Message = 'Both Lab Slots and Room Slots Break Varaible Initilize';



END

ELSE IF @AllNonPracticalClass > @TotalRoomsTimeSlot

BEGIN

    // -- Set Room Break

                SET @RoomDefference = @TotalNonPracticalTimeSlots - @AllNonPracticalClass;

                SET @SetRoomDefference = @TotalNonPracticalTimeSlots / @RoomDefference;

SET @RoomBreak = Cast(@SetRoomDefference as int) + 1;

               

                // -- Set Lab Break

                SET @LabBreak = 0;

                  SET @Message = 'Only Room Slots Break Varaible Initilize';

END

 

//--============================================================================================================================

//-- Generate Time Table Header and Details Tables are Polulation Table

DECLARE @TimeTableHeader Table(TimeTableID int, SessionID int, SessionTitle NVARCHAR(500), ProgramSemesterID int,TimeTableTitle nvarchar(200), SemesterTitle nvarchar(200) ,StartDate Date, EndDate Date, IsActive bit);

DECLARE @TimeTableDetails Table(TimeTableID int, SessionID int, SessionTitle NVARCHAR(500), ProgramSemesterSubjectID int, SubjectTitle nvarchar(400), RoomID int, LabID int, DayTimeSlotID int, LectureID int, DayID int, IsActive bit);

 


 

//-- Declare Time Table Header Variables

DECLARE @TimeTableTitle nvarchar(400);

 

 

//-- Getting All Semester

DECLARE @AllSemesters Table(RowNo int, ProgramSemesterID int, Title nvarchar(300),SessionID int,SessionTitle NVARCHAR(500));

INSERT INTO @AllSemesters(RowNo, ProgramSemesterID, Title, SessionID, SessionTitle) (SELECT ROW_NUMBER() over(order by(Select 1)) ,ProgramSemesterID, Title, SessionID,SessionTitle FROM(SELECT ProgramSemesterID, Title, SessionID, SessionTitle FROM @ALLSubjectSemesterTable GROUP BY ProgramSemesterID, Title, SessionID, SessionTitle) ALFF)

 

//-- Create Time Table for one by one Semester

DECLARE @CAllSemester int = (Select Count(*) FROM @AllSemesters);

DECLARE @OneByOneSemester int = 1;

                WHILE @OneByOneSemester <= @CAllSemester

                BEGIN

  //                              -- Get SEMESTER HEADER

                                DECLARE @SessionTitle nvarchar(150) = (SELECT TOP 1 SessionTitle FROM @AllSemesters WHERE RowNo = @OneByOneSemester);

                                DECLARE @SessionID nvarchar(150) = (SELECT TOP 1 SessionID FROM @AllSemesters WHERE RowNo = @OneByOneSemester);

                                DECLARE @ProgramSemesterID int = (SELECT TOP 1 ProgramSemesterID FROM @AllSemesters WHERE RowNo = @OneByOneSemester);

                                DECLARE @Title nvarchar(200) = (SELECT TOP 1 Title FROM @AllSemesters WHERE RowNo = @OneByOneSemester);

                                SET @TimeTableTitle = (SELECT Title FROM @AllSemesters WHERE RowNo = @OneByOneSemester); -- + ' - '+@SessionTitle;

                                INSERT INTO @TimeTableHeader(TimeTableID, SessionID, SessionTitle, ProgramSemesterID, TimeTableTitle, SemesterTitle , StartDate, EndDate, IsActive)

                                VALUES(@OneByOneSemester, @SessionID, @SessionTitle, @ProgramSemesterID, @TimeTableTitle, @Title, @StartDate, @EndDate,1);

SET @OneByOneSemester = @OneByOneSemester + 1;

END



SET @Message = 'Time Table Header Intilize';

      //          -- DECLARE Time Slot Validation Variables

                DECLARE @LabTimeSlotNo int = 1;

                DECLARE @RoomTimeSlotNo int = 1;

        //        -- DECLARE Time Slot Marks as Empty

                DECLARE @RoomBreakDurationNo int = 1;

                DECLARE @LabBreakDurationNo int = 1;

 

          //      -- Assign First Practical Class

                DECLARE @OneByOnePracticalSubject int  = 1;

            //    -- SELECTION/CROSSOVER OPERATOR

                                WHILE @OneByOnePracticalSubject <= @AllPracticalClass

                                BEGIN

 

              //                                  --DECLARE @SessionTitle nvarchar(150) = (SELECT TOP 1 SessionTitle FROM @AllSemesters WHERE RowNo = @OneByOneSemester);

                                                DECLARE @SubjectSessionTitle nvarchar(350) = (SELECT TOP 1 SessionTitle FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @SubjectSessionID INT = (SELECT TOP 1 SessionID FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                SET @TimeTableTitle = (SELECT Title FROM @AllSemesters WHERE RowNo = @OneByOneSemester);-- + ' - '+@SessionTitle;

                                                DECLARE @LabDProgramSemesterID int = (SELECT TOP 1 ProgramSemesterID FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabSemesterTitle nvarchar(150) = (SELECT TOP 1 Title FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabTimeTableID int = (SELECT TOP 1 TimeTableID FROM @TimeTableHeader WHERE ProgramSemesterID = @LabDProgramSemesterID AND SemesterTitle = @LabSemesterTitle)

                                                DECLARE @LabProgramSemesterSubjectID int = (SELECT TOP 1 ProgramSemesterSubjectID FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabSubjectTitle nvarchar(300)=  (SELECT TOP 1 Title + ' ' + SSTitle FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabRoomTypeID int  =  (SELECT TOP 1 RoomTypeID FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabLectureID int = (SELECT TOP 1 LectureID FROM @PracticalRandomSubjectTable WHERE RowNo = @OneByOnePracticalSubject);

                                                DECLARE @LabID int = 0;

                                                DECLARE @LabRoomID int = 0;

                                                DECLARE @LabDayID int = 0;

                                                DECLARE @LabDayTimeSlotID int  = 0;

                                                DECLARE @LabIsActive bit = 1;

                                                                SET @LabID = (SELECT TOP 1 LabID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                SET @LabDayTimeSlotID = (SELECT TOP 1 DayTimeSlotID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                SET @LabDayID = (SELECT TOP 1 DayID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                                IF @LabBreakDurationNo = @LabBreak

                                                                                BEGIN

                                                                                                SET @LabTimeSlotNo = @LabTimeSlotNo + 2;

                                                                                                SET @LabBreakDurationNo = 1;

END

ELSE

                                                                                BEGIN

                                                                                                SET @LabTimeSlotNo = @LabTimeSlotNo + 1;

                                                                                                SET @LabBreakDurationNo = @LabBreakDurationNo + 1;

END



INSERT INTO @TimeTableDetails(TimeTableID, SessionTitle, SessionID, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID, DayTimeSlotID, LectureID, DayID, IsActive)

                                                                Values(@LabTimeTableID, @SubjectSessionTitle, @SubjectSessionID, @LabProgramSemesterSubjectID, @LabSubjectTitle,0, @LabID, @LabDayTimeSlotID, @LabLectureID, @LabDayID, @LabIsActive);

IF @LabBreakDurationNo = 1

                                                                BEGIN

                                                                                INSERT INTO @TimeTableDetails(TimeTableID, SessionTitle, SessionID, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID, DayTimeSlotID, LectureID, DayID, IsActive)

                                                                                Values(@LabTimeTableID,'',0,0,'Break',0, @LabID, @LabDayTimeSlotID,0, @LabDayID, @LabIsActive);

END

SET @OneByOnePracticalSubject = @OneByOnePracticalSubject + 1;

                                END

                                SET @Message = 'All Practical Time Table Details Intilize';

 

    //                            -- Assign Non Practical Class
    //
                                DECLARE @OneByOneNonPracticalSubject int  = 1;
    
      //                          -- SELECTION/CROSSOVER OPERATOR

                                WHILE @OneByOneNonPracticalSubject <= @AllNonPracticalClass

                                BEGIN




                                                SET @TimeTableTitle = (SELECT Title FROM @AllSemesters WHERE RowNo = @OneByOneSemester) + ' - '+@SessionTitle;

                                                DECLARE @RoomDProgramSemesterID int = (SELECT TOP 1 ProgramSemesterID FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomSemesterTitle nvarchar(150) = (SELECT TOP 1 Title FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomTimeTableID int = (SELECT TOP 1 TimeTableID FROM @TimeTableHeader WHERE ProgramSemesterID = @RoomDProgramSemesterID AND SemesterTitle = @RoomSemesterTitle)

                                                DECLARE @RoomProgramSemesterSubjectID int = (SELECT TOP 1 ProgramSemesterSubjectID FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomSubjectTitle nvarchar(300)=  (SELECT TOP 1 Title + ' ' + SSTitle FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomTypeID int  =  (SELECT TOP 1 RoomTypeID FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomLectureID int = (SELECT TOP 1 LectureID FROM @NonPracticalRandomSubjectTable WHERE RowNo = @OneByOneNonPracticalSubject);

                                                DECLARE @RoomLabID int = 0;

                                                DECLARE @RoomID int = 0;

                                                DECLARE @RoomDayID int = 0;

                                                DECLARE @RoomDayTimeSlotID int  = 0;

                                                DECLARE @RoomIsActive bit = 1;

 

                                                IF @RoomTimeSlotNo <= @TotalRoomsTimeSlot

                                                BEGIN

                                                                                SET @RoomID = (SELECT TOP 1 RoomID FROM @ALLRoomsSlots WHERE RowNo = @RoomTimeSlotNo);

                                                                                SET @RoomDayTimeSlotID = (SELECT TOP 1 DayTimeSlotID FROM @ALLRoomsSlots WHERE RowNo = @RoomTimeSlotNo);

                                                                                SET @RoomDayID = (SELECT TOP 1 DayID FROM @ALLRoomsSlots WHERE RowNo = @RoomTimeSlotNo);

                                                                               

                                                                                                IF @RoomBreakDurationNo = @RoomBreak

                                                                                                BEGIN

                                                                                                                SET @RoomTimeSlotNo = @RoomTimeSlotNo + 2;

                                                                                                                SET @RoomBreakDurationNo = 1;

END

ELSE

                                                                                                BEGIN

                                                                                                                SET @RoomTimeSlotNo = @RoomTimeSlotNo + 1;

                                                                                                                SET @RoomBreakDurationNo = @RoomBreakDurationNo + 1;

END

END

                                                ELSE

                                                BEGIN

                                                                                SET @RoomLabID = (SELECT TOP 1 LabID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                                SET @RoomDayTimeSlotID = (SELECT TOP 1 DayTimeSlotID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                                SET @RoomDayID = (SELECT TOP 1 DayID FROM @ALLLabsSlots WHERE RowNo = @LabTimeSlotNo);

                                                                                IF @RoomBreakDurationNo = @RoomBreak

                                                                                BEGIN

                                                                                                SET @LabTimeSlotNo = @LabTimeSlotNo + 2;

                                                                                                SET @RoomBreakDurationNo = 1;

END

ELSE

                                                                                BEGIN

                                                                                                SET @LabTimeSlotNo = @LabTimeSlotNo + 1;

                                                                                                SET @RoomBreakDurationNo = @RoomBreakDurationNo + 1;

END

END




                                    INSERT INTO @TimeTableDetails(TimeTableID, SessionTitle, SessionID, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID, DayTimeSlotID, LectureID, DayID, IsActive)

                                    Values(@RoomTimeTableID, @SubjectSessionTitle, @SubjectSessionID, @RoomProgramSemesterSubjectID, @RoomSubjectTitle, @RoomID, @RoomLabID, @RoomDayTimeSlotID, @RoomLectureID, @RoomDayID, @RoomIsActive);

IF @RoomBreakDurationNo = 1

                                    BEGIN

                                                INSERT INTO @TimeTableDetails(TimeTableID, SessionTitle, SessionID, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID, DayTimeSlotID, LectureID, DayID, IsActive)

                                                    Values(@RoomTimeTableID,'',0,0,'Break', @RoomID,0, @RoomDayTimeSlotID, @RoomLabID, @RoomDayID, @RoomIsActive);

END





SET @OneByOneNonPracticalSubject = @OneByOneNonPracticalSubject + 1;

                                END

                                SET @Message = 'All Non Practical Time Table Details Intilize';

 

               

                DELETE FROM TimeTableDetailsTable;

                DELETE FROM TimeTblTable;

               

 

                INSERT INTO TimeTblTable(TimeTableID , SessionID, SessionTitle, ProgramSemesterID , TimeTableTitle , SemesterTitle , StartDate , EndDate , IsActive )

                SELECT TimeTableID, SessionID, SessionTitle, ProgramSemesterID, TimeTableTitle, SemesterTitle, StartDate, EndDate, IsActive FROM @TimeTableHeader;

INSERT INTO TimeTableDetailsTable(TimeTableID, SessionID, SessionTitle, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID , DayTimeSlotID, LectureID, DayID , IsActive)

                SELECT TimeTableID, SessionID, SessionTitle, ProgramSemesterSubjectID, SubjectTitle, RoomID, LabID, DayTimeSlotID, LectureID, DayID, IsActive FROM @TimeTableDetails

                SET @Message = 'Time Table Created Successfully';



END
