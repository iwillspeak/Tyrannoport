   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

#nullable disable
#pragma warning disable CS1591

namespace Tyrannoport.Trx.Models
{
	[XmlRoot(ElementName="Times", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Times {
		[XmlAttribute(AttributeName="creation")]
		public string Creation { get; set; }
		[XmlAttribute(AttributeName="queuing")]
		public string Queuing { get; set; }
		[XmlAttribute(AttributeName="start")]
		public string Start { get; set; }
		[XmlAttribute(AttributeName="finish")]
		public string Finish { get; set; }
	}

	[XmlRoot(ElementName="Deployment", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Deployment {
		[XmlAttribute(AttributeName="runDeploymentRoot")]
		public string RunDeploymentRoot { get; set; }
	}

	[XmlRoot(ElementName="TestSettings", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestSettings {
		[XmlElement(ElementName="Deployment", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Deployment Deployment { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="UnitTestResult", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class UnitTestResult {
		[XmlAttribute(AttributeName="executionId")]
		public string ExecutionId { get; set; }
		[XmlAttribute(AttributeName="testId")]
		public string TestId { get; set; }
		[XmlAttribute(AttributeName="testName")]
		public string TestName { get; set; }
		[XmlAttribute(AttributeName="computerName")]
		public string ComputerName { get; set; }
		[XmlAttribute(AttributeName="duration")]
		public string Duration { get; set; }
		[XmlAttribute(AttributeName="startTime")]
		public string StartTime { get; set; }
		[XmlAttribute(AttributeName="endTime")]
		public string EndTime { get; set; }
		[XmlAttribute(AttributeName="testType")]
		public string TestType { get; set; }
		[XmlAttribute(AttributeName="outcome")]
		public string Outcome { get; set; }
		[XmlAttribute(AttributeName="testListId")]
		public string TestListId { get; set; }
		[XmlAttribute(AttributeName="relativeResultsDirectory")]
		public string RelativeResultsDirectory { get; set; }
		[XmlElement(ElementName="Output", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Output Output { get; set; }
	}

	[XmlRoot(ElementName="ErrorInfo", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class ErrorInfo {
		[XmlElement(ElementName="Message", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public string Message { get; set; }
		[XmlElement(ElementName="StackTrace", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public string StackTrace { get; set; }
	}

	[XmlRoot(ElementName="Output", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Output {
		[XmlElement(ElementName="ErrorInfo", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public ErrorInfo ErrorInfo { get; set; }
		[XmlElement(ElementName="StdOut", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public string StdOut { get; set; }
	}

	[XmlRoot(ElementName="Results", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Results {
		[XmlElement(ElementName="UnitTestResult", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public List<UnitTestResult> UnitTestResult { get; set; }
	}

	[XmlRoot(ElementName="Execution", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Execution {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="TestMethod", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestMethod {
		[XmlAttribute(AttributeName="codeBase")]
		public string CodeBase { get; set; }
		[XmlAttribute(AttributeName="adapterTypeName")]
		public string AdapterTypeName { get; set; }
		[XmlAttribute(AttributeName="className")]
		public string ClassName { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="UnitTest", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class UnitTest {
		[XmlElement(ElementName="Execution", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Execution Execution { get; set; }
		[XmlElement(ElementName="TestMethod", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public TestMethod TestMethod { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="storage")]
		public string Storage { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="TestDefinitions", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestDefinitions {
		[XmlElement(ElementName="UnitTest", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public List<UnitTest> UnitTest { get; set; }
	}

	[XmlRoot(ElementName="TestEntry", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestEntry {
		[XmlAttribute(AttributeName="testId")]
		public string TestId { get; set; }
		[XmlAttribute(AttributeName="executionId")]
		public string ExecutionId { get; set; }
		[XmlAttribute(AttributeName="testListId")]
		public string TestListId { get; set; }
	}

	[XmlRoot(ElementName="TestEntries", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestEntries {
		[XmlElement(ElementName="TestEntry", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public List<TestEntry> TestEntry { get; set; }
	}

	[XmlRoot(ElementName="TestList", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestList {
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName="TestLists", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestLists {
		[XmlElement(ElementName="TestList", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public List<TestList> TestList { get; set; }
	}

	[XmlRoot(ElementName="Counters", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class Counters {
		[XmlAttribute(AttributeName="total")]
		public int Total { get; set; }
		[XmlAttribute(AttributeName="executed")]
		public int Executed { get; set; }
		[XmlAttribute(AttributeName="passed")]
		public int Passed { get; set; }
		[XmlAttribute(AttributeName="failed")]
		public int Failed { get; set; }
		[XmlAttribute(AttributeName="error")]
		public int Error { get; set; }
		[XmlAttribute(AttributeName="timeout")]
		public int Timeout { get; set; }
		[XmlAttribute(AttributeName="aborted")]
		public int Aborted { get; set; }
		[XmlAttribute(AttributeName="inconclusive")]
		public int Inconclusive { get; set; }
		[XmlAttribute(AttributeName="passedButRunAborted")]
		public int PassedButRunAborted { get; set; }
		[XmlAttribute(AttributeName="notRunnable")]
		public int NotRunnable { get; set; }
		[XmlAttribute(AttributeName="notExecuted")]
		public int NotExecuted { get; set; }
		[XmlAttribute(AttributeName="disconnected")]
		public int Disconnected { get; set; }
		[XmlAttribute(AttributeName="warning")]
		public int Warning { get; set; }
		[XmlAttribute(AttributeName="completed")]
		public int Completed { get; set; }
		[XmlAttribute(AttributeName="inProgress")]
		public int InProgress { get; set; }
		[XmlAttribute(AttributeName="pending")]
		public int Pending { get; set; }
	}

	[XmlRoot(ElementName="RunInfo", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class RunInfo {
		[XmlElement(ElementName="Text", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public string Text { get; set; }
		[XmlAttribute(AttributeName="computerName")]
		public string ComputerName { get; set; }
		[XmlAttribute(AttributeName="outcome")]
		public string Outcome { get; set; }
		[XmlAttribute(AttributeName="timestamp")]
		public string Timestamp { get; set; }
	}

	[XmlRoot(ElementName="RunInfos", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class RunInfos {
		[XmlElement(ElementName="RunInfo", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public RunInfo RunInfo { get; set; }
	}

	[XmlRoot(ElementName="ResultSummary", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class ResultSummary {
		[XmlElement(ElementName="Counters", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Counters Counters { get; set; }
		[XmlElement(ElementName="Output", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Output Output { get; set; }
		[XmlElement(ElementName="RunInfos", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public RunInfos RunInfos { get; set; }
		[XmlAttribute(AttributeName="outcome")]
		public string Outcome { get; set; }
	}

	[XmlRoot(ElementName="TestRun", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestRun {
		[XmlElement(ElementName="Times", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Times Times { get; set; }
		[XmlElement(ElementName="TestSettings", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public TestSettings TestSettings { get; set; }
		[XmlElement(ElementName="Results", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public Results Results { get; set; }
		[XmlElement(ElementName="TestDefinitions", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public TestDefinitions TestDefinitions { get; set; }
		[XmlElement(ElementName="TestEntries", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public TestEntries TestEntries { get; set; }
		[XmlElement(ElementName="TestLists", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public TestLists TestLists { get; set; }
		[XmlElement(ElementName="ResultSummary", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
		public ResultSummary ResultSummary { get; set; }
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

}
