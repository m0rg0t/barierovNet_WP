# Portable source regressions

## Scope
Title now emits its missing notification and accepts null; Create_date notifies its own property rather than ApprovalDate; Images notifies the actual OutImages property; the text visibility converter collapses null/empty values. Tests exercise event names, quoted/null titles and converter output.

## Run
From repository root, with .NET SDK 10.0.x:

```sh
dotnet run --project tests/Portable.Tests/Portable.Tests.csproj --configuration Release
```

No NuGet packages are restored: tests/NuGet.Config clears package sources. The SDK targets only this harness; original application project files, package references and framework targets are unchanged. C# 5 syntax is enforced. CI uses commit-pinned checkout/setup-dotnet, a read-only token, no persisted credentials and a ten-minute timeout. setup-dotnet installs only the official .NET 10 SDK for the isolated harness; it does not install legacy/native SDKs.

## What is (and is not) verified
The project links actual production source files directly; it does not copy their logic. MVVM is a small INotifyPropertyChanged event adapter; Visibility/IValueConverter are minimal interfaces. Location access throws, and a synthetic empty category locator supplies only the model shape. Tests do not call location, network, image resolution, the UI or external data loading.

The unchanged original source at `35f4ae266ce9e2abd5b9b913dfedb869c10c57be` failed the new synthetic regression harness before the fix; the final source passes. Additional reversal tests independently fail for each corrected notification/null path and for the asynchronous duplicate guard where applicable.

## Dependency upgrade boundary
Phone 8, Coding4Fun, BCL/HTTP, Newtonsoft.Json 5.0.7 and installed MVVM/Telerik references need reconciliation and an original-target build. A portable source test does not establish compatibility of modern replacement assemblies.

Microsoft documents [historical Windows/Phone toolchain requirements](https://learn.microsoft.com/en-us/visualstudio/releases/2022/port-migrate-and-upgrade-visual-studio-projects). [Newtonsoft.Json 13.0.4 package assets](https://www.nuget.org/packages/Newtonsoft.Json/13.0.4) must be evaluated against each original target; computed compatibility is not a native Phone assembly or an app validation. No full application build, native runtime/device test or exhaustive dependency vulnerability audit is claimed. The next decision is whether to recover the matching historical toolchain for compatible dependency work, or separately scope a supported-platform migration.
