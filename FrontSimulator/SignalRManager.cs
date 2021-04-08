using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using System.Threading.Tasks;
using IssueEngine.Client.Domain.Models;
using IssueEngine.Client.Domain.SignalRMessages;
using Microsoft.AspNet.SignalR.Client;

namespace FrontSimulator
{
    [Export(typeof(ISignalRManager)), Shared]
    public class SignalRManager : ISignalRManager
    {
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _issueEngineHubProxy;
        private readonly List<string> _allowedTenants = new List<string>
        {
            "TestCase",
            "Test",
            "Client For Test",
            "NewTest",
            "New Test Client"
        };

        [ImportingConstructor]
        public SignalRManager()
        {
            _hubConnection = new HubConnection("http://issueenginedev.tmd.belgrid.net/issueengine.dev.iishost");
            _issueEngineHubProxy = _hubConnection.CreateHubProxy("IssueEngineHub");
            _hubConnection.EnsureReconnecting();
            _hubConnection.Closed += ConnectionOnClosed;
        }

        public async Task ConnectHubs()
        {
            _issueEngineHubProxy.On<NewIssueMessage>("IssueCreated", (newIssueMessage) =>
            {
                if (_allowedTenants.Contains(newIssueMessage.Tenant))
                {
                    Console.WriteLine($"{newIssueMessage.IssueId} is created");
                }
            });

            _issueEngineHubProxy.On<ResolveIssueMessage>("IssueResolved", (resolveIssueMessage) =>
            {
                if (_allowedTenants.Contains(resolveIssueMessage.Tenant))
                {
                    Console.WriteLine($"{resolveIssueMessage.IssueId} is resolved");
                }
            });

            _issueEngineHubProxy.On<BlockIssueMessage>("IssueBlocked", (blockIssueMessage) =>
            {
                if (_allowedTenants.Contains(blockIssueMessage.Tenant))
                {
                    Console.WriteLine($"{blockIssueMessage.IssueId} is blocked");
                }
            });

            _issueEngineHubProxy.On<UnblockIssueMessage>("IssueUnblocked", (unblockIssueMessage) =>
            {
                if (_allowedTenants.Contains(unblockIssueMessage.Tenant))
                {
                    Console.WriteLine($"{unblockIssueMessage.IssueId} is unblocked");
                }
            });

            _issueEngineHubProxy.On<UpdateIssueMessage>("IssueChanged", (updateIssueMessage) =>
            {
                if (_allowedTenants.Contains(updateIssueMessage.Tenant))
                {
                    Console.WriteLine($"{updateIssueMessage.IssueId} was updated");
                }
            });

            _issueEngineHubProxy.On<SolutionResultMessage>("SolutionRan", (solutionResultMessage) =>
            {
                if (_allowedTenants.Contains(solutionResultMessage.Tenant))
                {
                    Console.WriteLine($"{solutionResultMessage.SolutionId} ran with result: {solutionResultMessage.SolutionRanSuccessfully}");
                }
            });

            await _hubConnection.Start();
        }

        private void ConnectionOnClosed()
        {
            _hubConnection.Start();
        }
    }
}
