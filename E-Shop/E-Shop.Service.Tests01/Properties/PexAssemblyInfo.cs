// <copyright file="PexAssemblyInfo.cs">Copyright ©  2019</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "NUnit3")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("E-Shop.Service")]
[assembly: PexInstrumentAssembly("E-Shop.Data")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("E-Shop.Model")]
[assembly: PexInstrumentAssembly("System.ComponentModel.DataAnnotations")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "E-Shop.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "E-Shop.Model")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.ComponentModel.DataAnnotations")]

