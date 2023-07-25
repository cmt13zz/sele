@BDDSearchBook
Feature: Search Book with results
    As a user
    I want to search for a book with fulfill results

    @DemoSearchBook
    Scenario: Search Book with results
        Given I navigate to the Book Page
        When I input a keyword "<keyword>" in the search box
        Then I see the correct amount of books "<Count>" results that contain the keyword "<keyword>"

        Examples:
            | keyword          | Count |
            | Git Pocket Guide | 1     |
            | Java             | 4     |  
            | Selenium         | 0     |
