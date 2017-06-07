# The Process

1. Write exactly one new test. It should be the smallest test which seems to point in the direction of a solution.
2. Run the test to make sure it fails
3. Make the test from (1) pass by writing the least amount of implementation code you can IN THE TEST METHOD.
4. Refactor to remove duplication or otherwise as required to improve the design. Be strict about the refactorings. Only introduce new abstractions (methods, classes, etc) when they will help to improve the design of the code. Specifically:  
    4a. ONLY Extract a new method if there is sufficient code duplication in the test methods. When extracting a method, initially extract it to the test class (don't create a new class yet).  
    4b. ONLY create a new class when a clear grouping of methods emerges and when the test class starts to feel crowded or too large.  
5. Repeat the process by writing another test (go back to step #1).
