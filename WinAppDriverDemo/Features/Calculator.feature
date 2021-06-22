Feature: Calculator
	Simple calculator Operations


@mytag
Scenario: Add two numbers
	Given the first number is 5 
	Then Click Add Button
	Then the second number is 7	
	Then the result should be 12
	
Scenario: Substract two numbers
	Given the first number is 9
	Then Click Minus button
	Then the second number is 2
	Then the result should be 7


