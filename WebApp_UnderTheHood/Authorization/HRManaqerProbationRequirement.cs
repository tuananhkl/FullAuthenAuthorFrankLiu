using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApp_UnderTheHood.Authorization
{
    public class HRManaqerProbationRequirement : IAuthorizationRequirement
    {
        public int ProbationMonths { get; }

        public HRManaqerProbationRequirement(int probationMonths)
        {
            ProbationMonths = probationMonths;
        }
    }

    public class HRManaqerProbationRequirementHandler : AuthorizationHandler<HRManaqerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManaqerProbationRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
            {
                return Task.CompletedTask;
            }
            
            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var period = DateTime.Now - empDate;
            if(period.Days > 30 * requirement.ProbationMonths)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}