﻿using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Robotmaster.CollectionRecommendation.Helpers;
using Robotmaster.CollectionRecommendation.Helpers.Collections;

namespace Robotmaster.CollectionRecommendation.Collections
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DoNotUseToArrayIfNotArrayAnalyzer : DiagnosticAnalyzer
    {
        /// <summary>
        ///     This is the complete ID of the rule for this analyzer.
        /// </summary>
        public static readonly string DiagnosticId = AnalyzerHelper.GetCompleteAnalyzerId(IdNumber);

        /// <summary>
        ///     This is the format of the analyzer's rule.
        /// </summary>
        internal const string MessageFormat = "This non-Array IEnumerable is calling the ToArray() method.";

        /// <summary>
        ///     This is the description of the analyzer's rule.
        /// </summary>
        private const string Description = "This is used to indicate that a non-Array IEnumerable is calling the ToArray() method; this should be avoided for lazily constructed collections or enumerations.";

        /// <summary>
        ///     The category of the analyzer's rule.
        /// </summary>
        private const string Category = "Collections";

        /// <summary>
        ///     The number portion of the above <see cref="DiagnosticId"/>.
        /// </summary>
        private const int IdNumber = 14;

#pragma warning disable RS1017 // DiagnosticId for analyzers must be a non-null constant.
        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, AnalyzerHelper.AnalyzerTitle, MessageFormat, Category, DiagnosticSeverity.Warning, true, Description);
#pragma warning restore RS1017 // DiagnosticId for analyzers must be a non-null constant.

        /// <summary>
        ///     This is the name of the <see cref="Enumerable.ToArray{TSource}"/> extension method.
        /// </summary>
        private static readonly string ToArrayMethodName = nameof(Enumerable.ToArray);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.InvocationExpression);
        }

        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            // If this corresponds to an IList invoking the ToList() method.
            if (CollectionHelper.IsNonArrayInvokingRedundantLinqMethod(context, ToArrayMethodName))
            {
                // Report a diagnostic for this invocations expression.
                context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
            }
        }
    }
}
