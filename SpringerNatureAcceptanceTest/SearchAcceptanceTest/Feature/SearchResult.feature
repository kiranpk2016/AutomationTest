Feature: SearchResult
	As a researcher
	I want to be able to search for the documents from springer nature
	so that I can access documents 

Background: 
	Given I am on springer nature page

Scenario: Check for auto suggestion when enter for search
	When I enter 'medical' to search for 
	Then it gives me auto suggestion containing 'medical'
	And the entered search text is highlighted

Scenario: Error message when no search result found
	When I search for 'Springernaturepage' 
	Then it should give me error message

Scenario: Check for search result
	When I search for 'medical'
	Then it should give me search results containing 'medical'

Scenario: Clicking on new search, entered search text should be cleared
	When I search for 'medical'
	And I click on new search link
	Then previously entered search text gets cleared

Scenario: Navigate to the search result page when click from auto suggesstion link
	When I enter 'medical' to search for 
	And I click first auto suggested link
	Then it should navigate to search result page of containing auto suggested link

Scenario: Auto suggesstion should update
	When I enter 'medical' to search for 
	And I know the auto suggested search result for 'medical'
	When I update auto suggestion as 'chemical'
	Then it should update the auto suggestion containing 'chemical'
	






