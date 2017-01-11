Feature: ViewWarehouseContents
	In order to view and manage warehouse contents
	As an entitled user
	I want to be able to edit the displayed items

Scenario: Display warehouse items
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
	Then I expect to see the following data on the screen:
	| Kind | Price	| Quantity	| Total Cost	|
	| Oven | 34.95	| 20		| 699			|
	| TV   | 346.95	| 50		| 17347.5		|
	| PC   | 423.95	| 70		| 29676.5		|

Scenario: Edit item price
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	And I am able to log in successfully with username 'Admin' and password 'pass'
	When I open the application
	And I set the username to "Admin"
	And I set the password to "pass"
	And I log in to the system	
	And I set the Price for "TV" item to 350
	Then Total cost of "TV" item is 17500

Scenario: Delete warehouse item
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
	And I delete "TV" item
	Then I expect to see the following data on the screen:
	| Kind | Price	| Quantity	| Total Cost	|
	| Oven | 34.95	| 20		| 699			|
	| PC   | 423.95	| 70		| 29676.5		|

Scenario: Create new warehouse item
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	And I am able to log in successfully with username 'Admin' and password 'pass'
	When I open the application
	And I set the username to "Admin"
	And I set the password to "pass"
	And I log in to the system	
	And I create a new warehouse item with the following data:
	| Kind | Price  | Quantity |
	| PC   | 423.95 | 70       |	
	Then I expect to see the following data on the screen:
	| Kind | Price	| Quantity	| Total Cost	|
	| Oven | 34.95	| 20		| 699			|
	| TV   | 346.95	| 50		| 17347.5		|
	| PC   | 423.95	| 70		| 29676.5		|

Scenario: Display error for incorrect Price value
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
	And I set the Price for "TV" item to -10
	Then Error message is displayed with the following text "Price must be positive."

Scenario: Display error for incorrect Quantity value
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
	And I set the Quantity for "TV" item to -10
	Then Error message is displayed with the following text "Quantity must be positive."

Scenario: Display error for incorrect Kind value
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
	And I set the Kind for "TV" item to ""
	Then Error message is displayed with the following text "Kind should not be empty."