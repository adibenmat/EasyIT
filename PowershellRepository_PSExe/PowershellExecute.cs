using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace PowershellRepository.PSInstance
{
    public class PowershellExecute
    {
        private Runspace shellrunspace;

        public Runspace  ShellRunspace
        {
            get { return shellrunspace; }            
        }

        public PowershellExecute()
        {
            shellrunspace = RunspaceFactory.CreateRunspace();
            {
                shellrunspace.Open();

            }
        }

        public PSResult InokePipeline(string command)
        {
            Pipeline pipeline = shellrunspace.CreatePipeline();
            PSResult result = new PSResult();
            try
            {
                pipeline.Commands.AddScript(command);
               result.Result =  pipeline.Invoke();
            }
            catch (Exception e)
            {
                result.Error = "Exception thrown running command: " + command + Environment.NewLine + "With the exception: " + e.Message;
            }

            return result;

        }
    }
}