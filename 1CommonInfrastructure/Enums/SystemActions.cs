using _1CommonInfrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Enums
{
    public enum SystemActions
    {       
     
        Administration = 1,

        [ActionGroupDescription("Person", "View")]        
        PersonView,

        [ActionGroupDescription("Person", "Create")]
        PersonCreate,

        [ActionGroupDescription("Person", "Update")]        
        PersonUpdate,

        [ActionGroupDescription("Person", "Delete")]        
        PersonDelete
    }
}



namespace _1CommonInfrastructure.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ActionGroupDescriptionAttribute : DescriptionAttribute
    {
        public string Group { get; set; }
        public string Action { get; set; }

        public ActionGroupDescriptionAttribute(string group, string action, string description = "")
        {
            this.Group = group;
            this.Action = action;
            this.DescriptionValue = string.IsNullOrEmpty(description) ? $"{group} - {action}" : description;
        }
    }
}