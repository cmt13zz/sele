@BDDSearchProject
Feature: Search Project
    As an admin 
    I want to search project that the system has

@DemoSearchProject
Scenario Outline: Search Project with all fields
    Given I login as admin
    And I click on the Projects dropdown menu
    And I click on Search Project button 
    When I fill all three "<ProjectName>", "<Location>" and "<ProjectType>" fields
    And I click on Search button
    Then I should see the result of all three "<ProjectName>", "<Location>" and "<ProjectType>" match the one in the result table 

Examples:
    | ProjectName | Location                            | ProjectType |
    | jira        | Offshore Vietnam Ho Chi Minh city   | Fixed Price |

@DemoSearchProject
Scenario Outline: Search Project with Project Name
    Given I login as admin
    And I click on the Projects dropdown menu
    And I click on Search Project button 
    When I fill ProjectName "<ProjectName>" field
    And I click on Search button
    Then I should see the "<ProjectName>" contain in project name in the result table

Examples:
    | ProjectName   | Location  | ProjectType   |
    |jira           |           |               |

@DemoSearchProject
Scenario Outline: Search Project with Location
    Given I login as admin
    And I click on the Projects dropdown menu
    And I click on Search Project button 
    When I fill Location "<Location>" field
    And I click on Search button
    Then I should see the "<Location>" have same location in the result table

Examples:
    | ProjectName   | Location                          | ProjectType   |
    |               | Offshore Vietnam Ho Chi Minh city |               |

@DemoSearchProject
Scenario Outline: Search Project with Project Type
    Given I login as admin
    And I click on the Projects dropdown menu
    And I click on Search Project button 
    When I fill ProjectType "<ProjectType>" field
    And I click on Search button
    Then I should see the "<ProjectType>" have same project type in the result table

Examples:
    | ProjectName   | Location  | ProjectType   |
    |               |           | Fixed Price   |
