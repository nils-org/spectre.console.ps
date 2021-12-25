using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Spectre.Console.PS
{
    [Cmdlet(VerbsCommunications.Write,"Markup")]
    public class WriteMarkupCmdlet : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Markup { get; set; }

        [Parameter]
        public SwitchParameter NoNewline { get; set; }

        protected override void BeginProcessing()
        {
            if (NoNewline.IsPresent)
            {
                AnsiConsole.Markup(Markup);    
            }
            else
            {
                AnsiConsole.MarkupLine(Markup);
            }
        }
    }
}
