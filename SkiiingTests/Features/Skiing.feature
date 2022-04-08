Feature: Skiing

A short summary of the feature

@tag1
Scenario: Read Tree Map
	Given a file path TreeMap.txt
	When we read it in
	Then string array is not null

Scenario Outline: Loop Tree Map
	Given the skier is at the end of the map of width 20
	And a slope of <Slope>:1
	When they advance
	Then their new position is <newPosition>
	Examples: 
	| Slope | newPosition |
	| 1     | 0           |
	| 3     | 2           |


Scenario: Ski a Slope
	Given a slope of 1:1
	When the skier reaches the bottom
	Then they hit 2 trees
