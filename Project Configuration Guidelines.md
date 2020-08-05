# Project Configuration Guidelines (Step by Step):

### Step 1. Clone the repo
There are two ways to download the project to the system. You can use any one of them.
#### •	Option 1
Open Github project repository that you want to download, at the right hand there will be a button “Code”. Click on that button. It will show the option to copy the repo’s URL. Copy that. After that open Git bash in the destination location where you want to download the project and run the following commands:

git clone <Github repo URL>
For example git clone https://github.com/ayeshatahirme/CS311S20PID30.git

#### •	Option 2
Open Github project repository that you want to download, at the right hand there will be a button “Code”. Click on that button. It will show the option to download zip. Click on the “Download Zip” option to download it on your system.

### Step 2. Open in Code Editor
To run the project, you need to open it in Visual Studio Community. Open the project folder, there will be another folder named “TimetableGenerator”. This folder contains the files that you will need to set up the project.
Open TimetableGenerator.sln file to run it on visual studio.

### Step 3. Open and connect Database
In the same folder “TimetableGenerator” there will be an SQL file named as “AutoTimeTable”. Open that file to set up the database. It will ask to connect to the database engine. Connect it. And run the queries in the file on your system to set up the database.

### Step 4. Integrate Database
Now you have to make the connection of database with visual studio. For making the connection, go to visual studio and click on project > Add new data source. Select database and move next. Then select dataset. Next, you need to make a new connection. In the server name add your systems server name. in case you do not know from where to copy server name, go to Microsoft SQL server, in the left-most side from object explorer, click on connect button. It will show multiple options. Select the database engine and copy the server name. Paste the copied server name in the visual studio “add connection” server name textbox. From the “Select or enter a database name” dropbox select the database you want to connect which in this case is AutoTimeTable. Test the connection by clicking on the “Test Connection” button. And click OK.
After connecting the database with the project. In visual studio from server explorer > Data Connections; right click on the database you added and select its properties. Now from the connection properties copy its connection string and paste this string where ever the connections are made. Replace my connection string with yours. The connection string will be like: 
Data Source=DESKTOP-6FG9FQD;Initial Catalog=AutoTimeTable;Integrated Security=True

### Step 5. Run the project.
Now you are all set to run the project. To run the project, click on the “Start” button on the visual studio.
