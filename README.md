# SpecFlow Test Discovery Issue Reproduction

## Problem Description

This repository demonstrates an issue where **SpecFlow tests are not being discovered by certain VS Code extensions** that rely on test discovery mechanisms.

## Expected Behavior

The SpecFlow test should be discoverable and runnable through VS Code test extensions, just like regular unit tests.

## Actual Behavior

- **SpecFlow feature tests are not discovered** by VS Code test discovery extensions
- Only regular NUnit tests (like `PlainNUnitPasses`) are found and can be run
- The SpecFlow test `AddingTwoNumbers` exists but is invisible to extension-based test runners

## Test Discovery Results

When running `dotnet test --list-tests`, the following tests are found:

```
✅ AddingTwoNumbers          (SpecFlow scenario - from Calculator.feature)
✅ PlainNUnitPasses         (Regular NUnit test)
```

However, VS Code extensions that should discover and run these tests **only see the regular NUnit test**, missing the SpecFlow-generated test.

## Project Structure

```
├── Calculator.feature          # SpecFlow feature file
├── Calculator.feature.cs       # Auto-generated test code  
├── CalculatorSteps.cs          # Step definitions
├── SimpleTests.cs              # Regular NUnit test (for comparison)
├── SpecFlowRepro.Tests.csproj  # Project file with SpecFlow packages
└── specflow.json               # SpecFlow configuration
```

## Environment

- **.NET Framework:** 4.8
- **SpecFlow:** 3.9.74
- **NUnit:** 3.14.0
- **Test SDK:** Microsoft.NET.Test.Sdk 17.9.0

## Steps to Reproduce

1. Clone this repository
2. Open in VS Code
3. Try to discover/run tests through the extension
4. **Issue:** Only `PlainNUnitPasses` is discovered, `AddingTwoNumbers` (SpecFlow) is missing

## Expected Fix

The extension should discover and display both:
- ✅ `PlainNUnitPasses` (Regular NUnit)  
- ❌ `AddingTwoNumbers` (SpecFlow scenario) ← **Currently missing**

## Additional Notes

- The SpecFlow test runs perfectly via `dotnet test` command line
- The issue is specifically with **extension-based test discovery**, not with SpecFlow itself
- This affects the developer experience when using VS Code for SpecFlow BDD development

