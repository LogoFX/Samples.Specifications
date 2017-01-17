﻿Feature: GracefulShutdown
	In order to avoid losing data
	As a system user
	I want to have an option of saving changes before closing the application

Scenario: Display exit application options if there are unsaved changes 
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	| PC   | 423.95 | 70       |	
	And I am able to log in successfully with username 'Admin' and password 'pass'
	When I open the application
	And I set the username to "Admin"
	And I set the password to "pass"
	And I log in to the system
	And I set the Price for "TV" item to 350
	And I close the application
	Then the exit application options are displayed

Scenario: Don't display exit application options if there are no unsaved changes 
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	| PC   | 423.95 | 70       |	
	And I am able to log in successfully with username 'Admin' and password 'pass'
	When I open the application
	And I set the username to "Admin"
	And I set the password to "pass"
	And I log in to the system
	And I set the Price for "TV" item to 350
	And I discard the changes
	And I close the application
	Then the exit application options are not displayed

Scenario: Save changed item data if save with changes option is selected
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	| PC   | 423.95 | 70       |	
	And I am able to log in successfully with username 'Admin' and password 'pass'
	When I open the application
	And I set the username to "Admin"
	And I set the password to "pass"
	And I log in to the system
	And I set the Price for "TV" item to 350	
	And I close the application
	And I select save with changes option
	Then the Price for "TV" item is 350
	And the changes are saved
