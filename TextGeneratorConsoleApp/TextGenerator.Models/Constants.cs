namespace TextGenerator.Models;

public static class Constants
{
    public static string template1 = "Hello {Name},\n\nWe will be glad to see you in our office in {Address.City} at {Address.Line1}.\n\nLooking forward to meeting with you!\n\n\nBest, Our company.";
    public static string template2 = "Welcome {Name} to Nix Technologies, We are writing you this email to confirm your selection in our {Department.Name} department and section will be {Department.Section.Name}.\nYou will be joining other {Department.Section.MemberCount} members.\nYour vast experience of {Experience} years will help us moving forward.\nHere is your Employee Id: {EmployeeId}.\n\nRegards.\nNix Technologies HR.";

    public static DataModel dataModel1 = new()
    {
        Name = "John Doe",
        Address = new Address
        {
            City = "Budapest",
            Line1 = "Main Street, 1"
        }
    };
    public static DataModel2 dataModel2 = new()
    {
        Name = "Alex Peter",
        EmployeeId = "123xyz",
        Experience = 8,
        Department = new Department
        {
            Name = "Software Developers",
            Section = new Section
            {
                Name = ".Net Developers",
                MemberCount = 5,
            },
        },
    };
}
