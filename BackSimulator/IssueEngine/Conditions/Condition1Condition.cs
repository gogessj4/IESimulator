using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using IssueEngine.Client.Domain.Enums;
using IssueEngine.Client.Domain.Interfaces;
using IssueEngine.Client.Domain.Models;
using IssueEngine.Client.Domain.Resources;

namespace BackSimulator.IssueEngine.Conditions
{
    [Export("Condition1", typeof(ICondition))]
    public class Condition1Condition : ICondition
    {
        public async Task<ConditionResult> DoCheck(List<EventFact> eventFacts, List<EventFactsType> neededEventFactsTypes, string sourceOutputText)
        {
            await Task.Delay(1000);
            var result = new ConditionResult();
            result.Type = ConditionResultType.CompletedWithIssue;
            result.OutputText = "Issue found!";
            return result;
        }
    }
}
