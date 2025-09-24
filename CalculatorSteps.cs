using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowRepro;

[Binding]
public class CalculatorSteps
{
    private readonly List<int> _inputs = new();
    private int _result;

    [Given("I have entered (.*) into the calculator")]
    public void GivenIHaveEnteredNumber(int value)
    {
        _inputs.Add(value);
    }

    [When("I press add")]
    public void WhenIPressAdd()
    {
        _result = 0;
        foreach (var v in _inputs) _result += v;
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int expected)
    {
        Assert.That(_result, Is.EqualTo(expected));
    }
}
