@BDDAddBook
Feature: Add Book
    As a user
    I want to add a book to my collection



    @DemoAddBook
    Scenario: Add a book to my collection

        Given I delete all books from my collection using API
            | Field    | Value      |
            | username | <username> |
            | password | <password> |
            | userId   | <userId>   |

        When I add a book using API
            | Field    | Value      |
            | username | <username> |
            | password | <password> |
            | userId   | <userId>   |
            | isbn     | <isbn>     |

        And I navigate to the Login Page
        And I login with valid username "<username>" and password "<password>"
        And I navigate to the Profile Page
        Then I see the book with the book name "<BookName>" in my collection

        Examples:
            | userId                               | username  | password | isbn          | BookName         |
            | d5298eac-065e-4f61-b675-221c1a9a040c | cmtchuong | G@con123 | 9781449325862 | Git Pocket Guide |



