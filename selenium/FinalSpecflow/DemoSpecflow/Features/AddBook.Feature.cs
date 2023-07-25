﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DemoSpecflow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Add Book")]
    [NUnit.Framework.CategoryAttribute("BDDAddBook")]
    public partial class AddBookFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "BDDAddBook"};
        
#line 1 "AddBook.Feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Add Book", "    As a user\r\n    I want to add a book to my collection", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add a book to my collection")]
        [NUnit.Framework.CategoryAttribute("DemoAddBook")]
        [NUnit.Framework.TestCaseAttribute("d5298eac-065e-4f61-b675-221c1a9a040c", "cmtchuong", "G@con123", "9781449325862", "Git Pocket Guide", null)]
        public void AddABookToMyCollection(string userId, string username, string password, string isbn, string bookName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "DemoAddBook"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("userId", userId);
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("password", password);
            argumentsOfScenario.Add("isbn", isbn);
            argumentsOfScenario.Add("BookName", bookName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a book to my collection", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1.AddRow(new string[] {
                            "username",
                            string.Format("{0}", username)});
                table1.AddRow(new string[] {
                            "password",
                            string.Format("{0}", password)});
                table1.AddRow(new string[] {
                            "userId",
                            string.Format("{0}", userId)});
#line 11
        testRunner.Given("I delete all books from my collection using API", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "username",
                            string.Format("{0}", username)});
                table2.AddRow(new string[] {
                            "password",
                            string.Format("{0}", password)});
                table2.AddRow(new string[] {
                            "userId",
                            string.Format("{0}", userId)});
                table2.AddRow(new string[] {
                            "isbn",
                            string.Format("{0}", isbn)});
#line 17
        testRunner.When("I add a book using API", ((string)(null)), table2, "When ");
#line hidden
#line 24
        testRunner.And("I navigate to the Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
        testRunner.And(string.Format("I login with valid username \"{0}\" and password \"{1}\"", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
        testRunner.And("I navigate to the Profile Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
        testRunner.Then(string.Format("I see the book with the book name \"{0}\" in my collection", bookName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
