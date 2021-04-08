using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueEngine.Client.Domain.Interfaces;
using IssueEngine.Client.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackSimulator.Controllers
{
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMessageSA issueEngineSA;
        public TestController(IMessageSA issueEngineSa)
        {
            issueEngineSA = issueEngineSa;
        }

        [HttpPut("sendbusinessevent")]
        public async Task<IActionResult> SendBusinessEvent()
        {
            await issueEngineSA.SendNewBusinessEvent("Condition1", new List<NewEventFact>());
            return Ok();
        }
    }
}
