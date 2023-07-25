## **Assignment**

* Jira013: [FINAL] - API Testing with RestSharp (NUnit)

## **Overview**

+ Creating script to verify different endpoints in demoQA

+ Meet these criterias:


      - Each endpoint must verify status and body.  
      - For the 1st endpoint (Get user), need to verify the status code, userId, username and books (if any) are correct.
      - Include negative tests for each endpoint.  
      - For the last endpoint (replace a book), implement an additional step in the 'success test' to verify the JSON SCHEMA of the response body.

## **Verification Steps**

 1. Go to <b>to-doan-cao-ch-ng</b> folder using this command:
```shell
   cd to-doan-cao-ch-ng
   ```
2. Change to <b>ChuongTo-final-api-testing r </b> branch:
```shell
   git checkout ChuongTo-final-api-testing
   ```
3. Go to <b>RSharpPractice</b> folder:
```shell
   cd selenium-C#/api/final/ChuongTo/RSharpPractice
   ```
4. Trigger test runner by this command `dotnet test`