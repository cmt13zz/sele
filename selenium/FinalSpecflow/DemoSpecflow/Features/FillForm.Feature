@bddFillForm
Feature: Fill Application Form and Submit
    As a ramdom user
    I want to fill the fields in the application form

    @fill_all_fields_in_the_application_form
    Scenario Outline: Fill all fields in the application form

        And I navigate to the Application Page
        When I input text in all fields with info below
            | Field          | Value            |
            | FirstName      | <FirstName>      |
            | LastName       | <LastName>       |
            | Email          | <Email>          |
            | Gender         | <Gender>         |
            | Mobile         | <Mobile>         |
            | DateOfBirth    | <DateOfBirth>    |
            | Subjects       | <Subjects>       |
            | Hobbies        | <Hobbies>        |
            | Picture        | <Picture>        |
            | CurrentAddress | <CurrentAddress> |

        And I click on Submit button
        Then I see the detailed project popup
            | Field          | Value            |
            | FirstName      | <FirstName>      |
            | LastName       | <LastName>       |
            | Email          | <Email>          |
            | Gender         | <Gender>         |
            | Mobile         | <Mobile>         |
            | DateOfBirth    | <DateOfBirth>    |
            | Subjects       | <Subjects>       |
            | Hobbies        | <Hobbies>        |
            | Picture        | <Picture>        |
            | CurrentAddress | <CurrentAddress> |


        Examples:
            | FirstName | LastName | Email        | Gender | Mobile     | DateOfBirth      | Subjects | Hobbies | Picture  | CurrentAddress |
            | Chuong    | To       | ct@gmail.com | Female | 0123456789 | 08 December,2022 | Maths    | Sports  | rodi.png | 123 ABCD       |

    @fill_mandatory_fields_in_the_application_form
    Scenario Outline: Fill mandatory fields in the application form

        And I navigate to the Application Page
        When I input text in mandatory fields with info below
            | Field     | Value       |
            | FirstName | <FirstName> |
            | LastName  | <LastName>  |
            | Gender    | <Gender>    |
            | Mobile    | <Mobile>    |
        And I click on Submit button
        Then I see the detailed project popup with mandatory fields: "<FirstName>", "<LastName>", "<Gender>", "<Mobile>"


        Examples:
            | FirstName | LastName | Gender | Mobile     |
            | Chuong    | To       | Female | 0123456789 |
