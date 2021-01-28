Feature: Validate Login Functionality

@FirstRun
Scenario Outline: I Login to a URL using Credentials
Given I Enter URL
And I Enter <UserName> and <Password>
Then I Click Login Button
And I Validate Logout Button

Examples: 
| UserName | Password |
| Mastan   |  12345   |
| Hemanth  |  12345   |