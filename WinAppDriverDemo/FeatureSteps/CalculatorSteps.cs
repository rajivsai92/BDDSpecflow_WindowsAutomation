using System;
using TechTalk.SpecFlow;
using WinAppDriverDemo.ObjectRepository.CalculatorObjs;

namespace WinAppDriverDemo.FeatureSteps
{
    [Binding]
    public class CalculatorSteps
    {
        private CalculatorActions _calculatorActions;
        public CalculatorSteps(CalculatorActions calculatorActions)
        {
            _calculatorActions = calculatorActions;
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num)
        {

            _calculatorActions.SelectNumber(num);

        }

        [Then(@"the second number is (.*)")]
        public void ThenTheSecondNumberIs(int num)
        {
            _calculatorActions.SelectNumber(num);

        }
        [Then(@"Click Add Button")]
        public void ThenClickAddButton()
        {
            _calculatorActions.ClickAddButton();

        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _calculatorActions.ClickEqualToButton();
            _calculatorActions.VerifyResult(result);
        }
        [Then(@"Click Minus button")]
        public void ThenClickMinusButton()
        {
            _calculatorActions.ClickMinusButton();
        }

       

    }
}

