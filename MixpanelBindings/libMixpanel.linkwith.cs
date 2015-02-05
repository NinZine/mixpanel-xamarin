using System;
using ObjCRuntime;

[assembly: LinkWith ("libMixpanel.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, LinkerFlags="-licucore")]
