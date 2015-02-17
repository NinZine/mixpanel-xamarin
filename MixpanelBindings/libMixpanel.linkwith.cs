using System;
using ObjCRuntime;

[assembly: LinkWith ("libMixpanel.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator64, ForceLoad = true, LinkerFlags="-licucore")]
