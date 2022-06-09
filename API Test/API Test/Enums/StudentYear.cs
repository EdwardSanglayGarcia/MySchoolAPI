using System.ComponentModel;

namespace API_Test.Enums
{
    public enum StudentYear
    {
        [Description("1st Year - Freshmen")]
        Freshmen = 1,
        [Description("2nd Year - Sophomore")]
        Sophomore = 2,
        [Description("3rd Year - Junior")]
        Junior = 3,
        [Description("4th Year - Senior")]
        Senior = 4
    }
}
