using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using IssueEngine.Client.Domain.Interfaces;
using IssueEngine.Client.Domain.Models;
using IssueEngine.Client.Domain.Resources;

namespace BackSimulator.IssueEngine.Solutions
{
    [Export("SolutionA", typeof(ISolution))]
    public class SolutionASolution : ISolution
    {
        public async Task<SolutionResult> Run(List<EventFact> eventFacts, List<EventFactsType> neededtypes)
        {
            return new SolutionResult(true,  string.Empty);
        }
    }
}
