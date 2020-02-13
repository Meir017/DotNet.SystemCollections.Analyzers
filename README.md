# Robotmaster.CollectionRecommendation

# About the project

## What Is Roslyn
Roslyn is the compiler platform for .NET. It consists of the compiler itself and a powerful set of APIs to interact with the compiler. The Roslyn platform is hosted at github.com/dotnet/roslyn.

## What are DotNet.SystemCollections.Analyzers?
An analyzer library for C# and VB.NET empowered by Roslyn to help .NET developers to harness the full capabilities and performance of the CLR. The set of analyzers will analyze your code for quality, performance and maintainability.
Disclaimer: This project was developed as an internal hackathon project. It’s still a prototype so using it could give you false positives. It can provide useful insights to the things we should avoid doing as developers. You can either consult the project’s roadmap to know when the project will move outside of its prototype phase or subscribe on the project’s notifications to made aware of releases and project updates.

## Goals
The goal of this library is to analyze the code and pinpoint both quality and performance pitfalls concerning the usage of types found in System.Collections such IEnumerable<T> or extensions methods found in System.Linq. This tool is here to help developers make better performance decisions through a set of micro-optimizations. The tool will not try to rewrite your LINQ expressions, but it’ll be able of 
[] Suggesting, for instance, using an HashSet<T> whenever a developer is doing a heavy Contains check on their List<T>.
[] Suggesting using a for-loop when iterating on a collection that allows random access such as IList<T>.
[] Suggesting using a separate method to yield values lazily instead of taking the time to create a temporary list.

## Documentation
You can find more about the current and planned list of rules here: (insert link to file inside the repository)
Selecting your data structure: (Link to file)

## Installation
Requirements to use	
-	Recommended version of Visual Studio: Visual Studio 2015
-	.Minimal NET Framework supported: 4.6+
-	Minimal .NET Core : 1.0
Requirements to build the solution:
-	Recommended version of Visual Studio: Visual Studio 2017 version 15.3
-	.Minimal NET Framework supported: 4.6+
-	Minimal .NET Core : 1.0

Installing the package from the Package Manager: 
	Install-Package DotNet.SystemCollections.Analyzers

Each project in Visual Studio has a "treat warnings as errors" option. Go through each of your projects and change that setting:
1.	Right-click on your project, select "Properties".
2.	Click "Build".
3.	Switch "Treat warnings as errors" from "All" to "Specific warnings" or "None".
