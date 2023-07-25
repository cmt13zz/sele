@BDDCreateProject
Feature: Create New Project
    As an admin 
    I want to create a new project

@DemoCreateProject
    Scenario: Create a new project
    Given I login as an admin
    And I click on Projects dropdown menu
    And I click on Create Project button
    When I create new project with info below
        | Field             | Value                 |
        | ProjectName       | <ProjectName>         |
        | ProjectType       | <ProjectType>         |
        | ProjectStatus     | <ProjectStatus>       |
        | StartDate         | <StartDate>           |
        | EndDate           | <EndDate>             |
        | Size              | <Size>                |
        | Location          | <Location>            |
        | ProjectManager    | <ProjectManager>      |
        | DeliveryManager   | <DeliveryManager>     |
        | EngagementManager | <EngagementManager>   |
        | ShortDescription  | <ShortDescription>    |
        | LongDescription   | <LongDescription>     |
        | Technologies      | <Technologies>        |
        | ClientName        | <ClientName>          |
        | ClientIndustry    | <ClientIndustry>      |
        | ClientDescription | <ClientDescription>   |
    And I click on Create button
    Then I should see the detailed project

    Examples:
    | ProjectName           | ProjectType       | ProjectStatus     | StartDate             | EndDate               | Size              | Location          | ProjectManager    | DeliveryManager    | EngagementManager     | ShortDescription      | LongDescription       | Technologies      | ClientName        | ClientIndustry    | ClientDescription     |
    | Project013            | Fixed Price       | Running           | Mar 11, 2001          | Apr 20, 2021          | 10                | USA               | Ly Vo (ly_vo)     | SM_KN (kn_sm)      | SM_KN (kn_sm)         | Short Description 1   | Long Description 1    | Specflow, C#      | Client Name 1     | Technology        | Client Description 1  |


