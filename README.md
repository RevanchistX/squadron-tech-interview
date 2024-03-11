# Squadron Interview
#### by Viktor Ivanovski

# Installation
1. Make sure you have .Net 8 installed
2. Clone the project:
   
       git clone https://github.com/RevanchistX/squadron-tech-interview.git
3. Start the project

        dotnet run

# Task 1
1. Navigate to Task1 Page
2. Upload a file
3. Preview the history of file uploads and the data inside each file.

Corners cut: 
1. The [Database](db/Task1/db.json) emulates MongoDB behaviour, saving and storing data to JSON.
2. Grid based preview not implemented.
3. No Frontend framework is used.
4. No Delete functionality. 
> Reset database as empty array ```[]``` to start from scratch.

# Task 2
1. Navigate to Task2 Page
2. Login as User
3. Answer questions

Corners cut:
1. No authentication.
2. [User Db](db/Task2/dbUsers.json) and [Equations Db](db/Task2/dbEquations.json) emulate MongoDB behaviour, saving and storing data to JSON.
3. No Frontend framework is used. 
4. No Delete functionality. 
> Refresh databases by copying [User Fresh Db](db/Task2/fresh/dbUsers.json) and [Equations Fresh Db](db/Task2/fresh/dbEquations.json)
5. No custom user input implemented.
6. No game rounds implemented.
7. Buttons refresh the page on each submit.