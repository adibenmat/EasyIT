using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowershellRepository.Interface
{
   public class CommandLoader
    {
       public string Command { get; set; }
       public List<Parameter> Parameters { get; set; }
        

        public CommandLoader()
        {
            Parameters = new List<Parameter>();
        }
        public CommandLoader(string command,List<Parameter> parameters)
        {
            Command = command;
            Parameters = parameters;
        }


       public Parameter GetParameterByName(string paramName)
        {
            if (this.Parameters != null)
            {
                return this.Parameters.Find(param => param.Name.Equals(paramName));
            }
            else
                return new Parameter(paramName);
        }

        public void AddParameter(Parameter parameter)
        {
            if (this.Parameters != null)
            {
                int paramIndex = this.Parameters.FindIndex(paramName => paramName.Name.Equals(parameter.Name));
                if (paramIndex != -1)
                {
                    if (this.Parameters[paramIndex].IsRequired == true)
                    {
                        parameter.IsRequired = true;
                    }
                    this.Parameters[paramIndex] = parameter;
                }
                else
                    this.Parameters.Add(parameter);
             }

            else
            {
                this.Parameters.Add(parameter);
            }
        }   

        

        public void ClearParameters()
        {
            this.Parameters.Clear();
        }


        public string GetCommandString()
        {
            return ParseCommandAndParametersToStringNoBrackets();
        }

        public string GetCommandStringWithBrackets()
        {
           return ParseCommandAndParametersToStringWithBrackets();
       }


        private string ParseCommandAndParametersToStringNoBrackets()
        {
            //keep one exit point
            StringBuilder command = new StringBuilder();
            command.Append(this.Command);

            // check if there is paramaters in the paramenters list
            //if there is check if theres paramaters that ned to be fullfilled
            if (this.Parameters != null)
            {
                if ((this.Parameters.Where(emptyParameters => emptyParameters.Value == null && emptyParameters.IsRequired == true)).ToList().Count > 0)
                    throw new ArgumentException("The Command Has at least one null parameter value which is Required");

                foreach (var item in this.Parameters)
                {
                    if (!String.IsNullOrEmpty(item.Value))
                        command.Append(" -" + item.Name + " " + item.Value);
                    else
                        command.Append(" -" + item.Name);

                }
            }
            return command.ToString();
        }

        private string ParseCommandAndParametersToStringWithBrackets()
        {
            //keep one exit point
            StringBuilder command = new StringBuilder();
            command.Append(this.Command);
            // check if there is paramaters in the paramenters list
            //if there is check if theres paramaters that ned to be fullfilled
            if (this.Parameters != null)
            {
                if ((this.Parameters.Where(emptyParameters => emptyParameters.Value == null && emptyParameters.IsRequired == true)).ToList().Count > 0)
                    throw new ArgumentException("The Command Has at least one null parameter value which is Required");

                foreach (var item in this.Parameters)
                {
                    if (!String.IsNullOrEmpty(item.Value))
                        command.Append(" -" + item.Name + " " + "'" + item.Value + "'");
                    else
                        command.Append(" -" + item.Name);
                }
            }
            return command.ToString();
        }

    }
}
