using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Ssepan.Application.WinForms;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle( "ThemeEditor" )]
[assembly: AssemblyDescription("\nTool to edit Visual Studio 2012 (and later) Themes, including Express Editions.\n\nBrian Chavez (http://twitter.com/bchavez) deserves credit for:\n~ all aspects of designing and coding in the original implementation (http://bchavez.bitarmory.com/archive/2012/08/27/modify-visual-studio-2012-dark-and-light-themes.aspx)\n\nSteve Sepan takes credit for:\n~ creating a fork of the original implementation and \n~ extending it to include selection of versions and editions\n~ adding handling for the Alpha channel\n~ all errors not present in the original version\n")]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany("The MIT License (MIT)")]
[assembly: AssemblyProduct("ThemeEditor")]
[assembly: AssemblyCopyright("Copyright (c) 2012 Brian Chavez;\nportions Copyright (c) 2013 Stephen J Sepan")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture( "" )]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access alpha type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid( "880076f8-ab01-4270-9b52-93405df4ec28" )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("2.1.*")]


#region " Helper class to get information for the About form. "
// This class uses the System.Reflection.Assembly class to
// access assembly meta-bytes
// This class is ! alpha normal feature of AssemblyInfo.cs
public class AssemblyInfo :
    AssemblyInfoBase
{
    // Used by Helper Functions to access information from Assembly Attributes
    public AssemblyInfo()
    {
        base.myType = typeof(ThemeEditor.ThemeEditorView);
    }
}
#endregion
