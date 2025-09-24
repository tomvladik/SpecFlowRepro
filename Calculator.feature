Feature: Calculator
  Simple arithmetic

  Scenario: Adding two numbers
    Given I have entered 40 into the calculator
    And I have entered 2 into the calculator
    When I press add
    Then the result should be 42
