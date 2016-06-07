using PowershellRepository.Interface;
using ParseAndReflectionMethods;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace PowershellRepository.Interface.Models
{
    public class PSService : ReflectionBase,IPowershellItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
                
        public PSService(string name, string displayName, string status)                        
        {            
            Name = name;
            DisplayName = displayName;
            Status = status;
        }

        public PSService()
        {
        }

        public string IdentifierProperty
        {
            get
            {
                return "Name";
            }
            set
            {
                if (value != null)
                    IdentifierProperty = value;
            }
        }


        public CommandLoader UpdateCommand
        {
            get
            {
                CommandLoader updateCommand = new CommandLoader();
                updateCommand.Command = "Set-Service";
                updateCommand.AddParameter(new Parameter("Name", true));
                return updateCommand;
            }
            set
            {
                UpdateCommand = value;
            }
        }
        
        public CommandLoader DeleteCommand
        {
            get
            {
                CommandLoader deleteCommand = new CommandLoader();
                deleteCommand.Command = "Delete-Service";
                deleteCommand.AddParameter(new Parameter("Name", true));
                return deleteCommand;
            }
            set
            {
                DeleteCommand = value;
            }
        }

        public CommandLoader CreateCommand
        {
            get
            {
                CommandLoader createCommand = new CommandLoader();
                createCommand.Command = "New-Service";
                createCommand.AddParameter(new Parameter("Name",true));
                createCommand.AddParameter(new Parameter("BinaryPathName", true));
                return createCommand;
            }
            set
            {
                CreateCommand = value;
            }
        }

        public CommandLoader GetCommand
        {
            get
            {
                CommandLoader getCommand = new CommandLoader();
                getCommand.Command = "Get-Service";
                getCommand.AddParameter(new Parameter("Name", true));
                return getCommand;
            }
            set
            {
                GetCommand = value;
            }
        }


        public CommandLoader GetItemsCommand
        {
            get
            {
                CommandLoader getCommand = new CommandLoader();
                getCommand.Command = "Get-Service";             
                return getCommand;
            }
            set
            {
                GetCommand = value;
            }
        }
    }
}
