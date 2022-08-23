# Product-Import

- To run the application 
  - Goto to Answwers > Publish and open command window and then run the following commands
  - ProductImport.exe import softwareadvice feed-products/softwareadvice.json
  - ProductImport.exe import capterra feed-products/capterra.yaml
  - Test Data is in the root of the publish folder

- To run the Tests
  - Open the solution file from the cloned repository and wait for project to load.
  - Right click on the solution in visual studio and select Run Tests.
  - View the test case code in the ProductImportTestCases project

- To view the Application code
  - Open the solution file from the cloned repository and wait for project to load.
  - View the code in the ProductImport project.
  - Starting point is program.cs file.

- Answers to the Sql Questions are in Answers > SQL Anwers

- Was it your first time writing a unit test, using a particular framework, etc?
  - No it wasn't my first time writing tests but wrote them after quite a while.

- What would you have done differently if you had had more time
  - Could have written better tests cases with mocking libraries etc.
  - A bit more decoupling of code in source provider classes.
  - Separate startup.cs 
