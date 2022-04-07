Feature: Skiing

A short summary of the feature

@tag1
Scenario: Read Tree Map
	Given a file path TreeMap.txt
	When we read it in
	Then string array is not null

Scenario: Loop Tree Map
	Given the skier is at the end of the map
	When they advances one more
	Then they loop back to the front


Scenario: Ski a Slope
	Given a slope of 1:1
	When the skier reaches the bottom
	Then they hit 20 trees
