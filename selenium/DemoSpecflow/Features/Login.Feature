@BDDlogin
Feature: Login
    As a user
    I want to login to the website

    @Demo @Debug
    Scenario Outline: Login successfully
        Given I open the Homepage
        And I navigate to Login page
        When I login with "<username>" and "<password>"
        Then I login successfully

        Examples:
        | Scenario             | username   | password |
        | Login successfully   | Admin2     | qp$#tGu^ |



    @Demo @DemoFailedScenario
    Scenario Outline: Login failed with invalid username and password
        Given I open the Homepage
        And I navigate to Login page
        When I login with "<username>" and "<password>"
        Then The error message "<message>" should be displayed when I enter invalid username and password

        Examples:
        | Scenario                             | username   | password      | message |
        | Invalid username and password        | Admin2     | wrongpassword | The Username or Password you entered is incorrect |
 
      
    @Demo @DemoFailedScenario
    Scenario Outline: Login failed with empty username
        Given I open the Homepage
        And I navigate to Login page
        When I login with password "<password>"
        Then The error message "<message>" should be displayed when I leave username empty

        Examples:
        | Scenario                             | username   | password    | message |
        | Missing username                     |            | qp$#tGu^    | This is a required field. |


    @Demo @DemoFailedScenario
    Scenario Outline: Login failed with empty password
        Given I open the Homepage
        And I navigate to Login page
        When I login with username "<username>"
        Then The error message "<message>" should be displayed when I leave password empty

        Examples:
        | Scenario                             | username   | password    | message |
        | Missing password                     | Admin2     |             | This is a required field. |


    @Demo @DemoFailedScenario
    Scenario Outline: Login failed with empty username and password
        Given I open the Homepage
        And I navigate to Login page
        When I click on Login button
        Then The error message "<message>" should be displayed when I leave username and password empty

        Examples:
        | Scenario                             | username   | password    | message |
        | Missing username and password        |            |             | This is a required field. |