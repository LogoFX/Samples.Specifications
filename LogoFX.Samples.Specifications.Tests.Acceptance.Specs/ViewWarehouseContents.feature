Feature: ViewWarehouseContents
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Sanity
Scenario: Add two numbers
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	| PC   | 423.95 | 70       |	
	When I open the application
	Then I expect to see the following data on the screen:
	| Number | Kind | Price | Quanity | Total Cost |
	| 1      | Oven | 35    | 20      | 699.1      |
	| 2      | TV   | 347   | 50      | 17347.5    |
	| 3      | PC   | 424   | 70      | 29676.9    |
