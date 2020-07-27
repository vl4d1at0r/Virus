using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virus
{
    public class Command
    {
        public Commands Type;
        public string Argument1;
        public string Argument2;

        public Command(string request)
        {
            string[] command = request.Split('|');
            switch (command[0])
            {
                case "create":
                    Type = Commands.Create;
                    Argument1 = command[1];
                    break;
                case "delete":
                    Type = Commands.Remove;
                    Argument1 = command[1];
                    break;
                case "rename":
                    Type = Commands.Rename;
                    Argument1 = command[1];
                    Argument2 = command[2];
                    break;
            }
        }

        public void Execute()
        {
            switch (Type)
            {
                case Commands.Create:
                    FileStream stream = File.Create(Argument1);
                    stream.Close();
                    break;
                case Commands.Remove:
                    File.Delete(Argument1);
                    break;
                case Commands.Rename:
                    File.Replace(Argument1, Argument2, "");
                    break;
            }
        }
    }
}
