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
4. No Delete functionality. Reset database as ```[]``` to start from scratch.