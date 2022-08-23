using ProductImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductImportTestCases.MockData
{
    public static class MockLists
    {
        public static List<CapterraModel> MockCapterraData()
        {
            List<CapterraModel> data = new List<CapterraModel>();

            data.Add(new CapterraModel
            {
                Name = "GitGHub",
                Tags = "Bugs & Issue Tracking,Development Tools",
                Twitter = "github"
            });

            data.Add(new CapterraModel
            {
                Name = "Slack",
                Tags = "Instant Messaging & Chat,Web Collaboration,Productivity",
                Twitter = "slackhq"
            });

            data.Add(new CapterraModel
            {
                Name = "JIRA Software",
                Tags = "Project Management,Project Collaboration,Development Tools",
                Twitter = "jira"
            });

            return data;
        }

        public static List<SoftwareAdviceModel> MockSoftwareAdviceData()
        {
            List<SoftwareAdviceModel> data = new List<SoftwareAdviceModel>();

            data.Add(new SoftwareAdviceModel
            {
                Title = "Freshdesk",
                Categories = new List<string> { "Customer Service",
                "Call Center"},
                Twitter = "@freshdesk"
            });

            return data;
        }
    }
}
