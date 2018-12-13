// <copyright file="PexAssemblyInfo.cs">Copyright ? 2017</copyright>
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Moles;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Using;
//using Microsoft.Pex.Linq;
using Microsoft.Pex.Framework.Explorable;
using Microsoft.Pex.Framework;
using ReportParserLearning;
using QuickGraph;
using System;
using Microsoft.Pex.Framework.Suppression;

[assembly: PexAssemblyUnderTest("QuickGraph")]

/*[assembly: PexAllowedExceptionFromAssembly(
    typeof(ArgumentException),
    "QuickGraph",
    AcceptExceptionSubtypes = true)]*/

//[assembly: PexGenericArguments(typeof(int), typeof(Edge<int>))]
//[assembly: PexGenericArguments(typeof(int), typeof(SEdge<int>))]
[assembly: ReportParserExecution]




// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("QuickGraph")]
[assembly: PexInstrumentAssembly("System.Core")]


// Microsoft.Pex.Framework.Coverage

[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexUseTypeAttribute(typeof(UndirectedGraphEqualityComparer))]
[assembly: PexUseTypeAttribute(typeof(UndirectedGraph<int, Edge<int>>))]

//[assembly: PexCoverageFilterType(PexCoverageDomain.UserOrTestCode, typeof(Microsoft.Pex.Framework.PexObserve))]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]
// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Moles
[assembly: PexAssumeContractEnsuresFailureAtBehavedSurface]
[assembly: PexChooseAsBehavedCurrentBehavior]

[assembly: PexInstrumentAssembly("Microsoft.VisualBasic", InstrumentationLevel = PexInstrumentationLevel.Excluded)]



//[assembly: PexLinqPackage]
