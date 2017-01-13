﻿using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Workflows
{
    [Cmdlet(VerbsCommon.Remove, "PnPWorkflowDefinition")]
    [CmdletAlias("Remove-SPOWorkflowDefinition")]
    [CmdletHelp("Removes a workflow definition",
        Category = CmdletHelpCategory.Workflows)]

    public class RemoveWorkflowDefinition : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The definition to remove", Position = 0)]
        public WorkflowDefinitionPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            if (Identity.Definition != null)
            {
                Identity.Definition.Delete();
            }
            else if (Identity.Id != Guid.Empty)
            {
                var definition = SelectedWeb.GetWorkflowDefinition(Identity.Id);
                if (definition != null)
                    definition.Delete();
            }
            else if (!string.IsNullOrEmpty(Identity.Name))
            {
                var definition = SelectedWeb.GetWorkflowDefinition(Identity.Name);
                if (definition != null)
                    definition.Delete();
            }
        }
    }

}
