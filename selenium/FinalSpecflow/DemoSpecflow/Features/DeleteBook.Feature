@bddDeleteBook
Feature: Delete a book
    As a user
    I want to delete a book from my collection

    Scenario: Delete a book successfully
        Given I add the book to my collection using API if it is not
            | Field    | Value      |
            | username | <username> |
            | password | <password> |
            | userId   | <userId>   |
            | isbn     | <isbn>     |

        And I navigate to the Login Page
        And I login with valid username "<username>" and password "<password>"

        And I navigate to the Profile Page
        And I see the book with the book name "<bookname>" is in my collection

        When I delete the book from my collection using API
            | Field    | Value      |
            | username | <username> |
            | password | <password> |
            | userId   | <userId>   |
            | isbn     | <isbn>     |

        And I navigate to the Login Page
        And I click on Logout button
        And I login with valid username "<username>" and password "<password>"
        Then I see the book is deleted from my collection

        Examples:
            | username  | password | bookname         | isbn          | userId                               |
            | cmtchuong | G@con123 | Git Pocket Guide | 9781449325862 | d5298eac-065e-4f61-b675-221c1a9a040c |

