//
// Copyright (c) 2010-2024 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using Antmicro.Renode.Core;
using Antmicro.Renode.UserInterface;
using ELFSharp.ELF;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Antmicro.Renode.Utilities.GDB.Commands
{
    internal class MonitorCommand : Command
    {
        public MonitorCommand(CommandsManager m) : base(m)
        {
            openOcdOverlay = new OpenOcdOverlay(m);
        }

        [Execute("qRcmd,")]
        public IEnumerable<PacketData> Run([Argument(Encoding = ArgumentAttribute.ArgumentEncoding.HexString)]string arg)
        {
            if(!openOcdOverlay.TryProcess(arg, out var result, out var ok))
            {
                var monitor = ObjectCreator.Instance.GetSurrogate<Monitor>();
                var eater = new CommandInteractionEater();
                monitor.Parse(arg, eater);
                result = eater.HasError
                    ? eater.GetError()
                    : eater.GetContents();
            }

            var consoleOutput = string.IsNullOrEmpty(result) ? null : string.Join(string.Empty, Encoding.UTF8.GetBytes(result).Select(x => x.ToString("X2")).Prepend("O"));
            var resultReply = ok ? PacketData.Success : PacketData.ErrorReply();
            if(consoleOutput != null)
            {
                return new [] { new PacketData(consoleOutput), resultReply };
            }
            return new [] { resultReply };
        }

        private readonly OpenOcdOverlay openOcdOverlay;

        private class OpenOcdOverlay
        {
            public OpenOcdOverlay(CommandsManager manager)
            {
                this.manager = manager;
            }

            /// <param name="output">The output generated by the command, if successful; otherwise null.</param>
            /// <param name="ok">Whether the command completed successfully.</param>
            /// <returns>true if the command exists; otherwise false.</returns>
            public bool TryProcess(string input, out string output, out bool ok)
            {
                output = null;
                ok = true;

                var argv = input.Split(new [] { ' ' });
                switch(argv.FirstOrDefault())
                {
                case "reset":
                    if(argv.ElementAtOrDefault(1) != "init")
                    {
                        ok = false;
                        return true;
                    }
                    manager.Machine.Pause();
                    manager.Machine.Reset();
                    break;
                case "halt":
                    manager.Machine.Pause();
                    break;
                case "reg":
                    var inputBuilder = new StringBuilder("=====\n");
                    foreach(var i in manager.Cpu.GetRegisters().Where(x => x.IsGeneral).Select(x => x.Index))
                    {
                        inputBuilder.AppendFormat("({0}) r{0} (/32): 0x", i);
                        var value = manager.Cpu.GetRegister(i);
                        // We always use big-endian GetBytes because we want 0x12345678 to become [0x12, 0x34, 0x56, 0x78]
                        // GetBytes also returns an array of the right length and appropriately padded with zeros.
                        foreach(var b in value.GetBytes(Endianess.BigEndian))
                        {
                            inputBuilder.AppendFormat("{0:x2}", b);
                        }
                        inputBuilder.Append("\n");
                    }
                    output = inputBuilder.ToString();
                    break;
                default:
                    return false;
                }
                return true;
            }

            private readonly CommandsManager manager;
        }
    }
}

