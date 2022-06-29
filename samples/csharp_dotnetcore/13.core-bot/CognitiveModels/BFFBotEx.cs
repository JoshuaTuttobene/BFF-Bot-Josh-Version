using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luis
{
    public partial class BFFBot
    {

        //Y'ALL THIS PROBABLY DOESN'T DO WHAT IT IS SUPPOSED TO
        //I'M NOT ENTIRELY SURE WHAT IT IS, BUT I JUST SORTA COPIED THINGS UNTIL ERRORS WENT AWAY
        
        public string GetPullRequestEntities()
        {
        
            var PullRequestValue = Entities?._instance?.PullRequest?.FirstOrDefault()?.Text;
            return (PullRequestValue);
        
        }

        public string GetRepositoryEntities()
        {
            var RepositoryValue = Entities?._instance?.Repository?.FirstOrDefault()?.Text;
            return (RepositoryValue);
        }

         public string GetStateEntities()
        {
            var StateValue = Entities?._instance?.Repository?.FirstOrDefault()?.Text;
            return (StateValue);
        }


    }
}