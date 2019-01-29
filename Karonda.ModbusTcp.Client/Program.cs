﻿using DotNetty.Common.Internal.Logging;
using Karonda.ModbusTcp.Entity;
using Karonda.ModbusTcp.Entity.Function.Response;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Threading.Tasks;

namespace Karonda.ModbusTcp.Client
{
    class Program
    {
        static async Task RunClientAsync()
        {
            //InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));

            ModbusClient client = new ModbusClient("127.0.0.1", 502, 0x01);

            try
            {
                await client.Connect();

                while(true)
                {
                    Console.WriteLine(@"
<------------------------------------------------------->
1: Read Coils; 2: Read Discrete Inputs; 
3: Read Holding Registers; 4: Read Input Registers; 
5: Write Single Coil; 6: Write Single Register; 
15: Write Multiple Coils; 16: Write Multiple Registers;
<------------------------------------------------------->");
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) break;

                    Console.WriteLine("<------------------------------------------------------->");
                    var command = Convert.ToInt32(line);
                    ModbusFunction response = null;
                    switch(command)
                    {
                        case 1:
                            ushort registerQuantity = 0x000A;
                            response = client.ReadCoils(0x0000, registerQuantity);
                            var coils = (response as ReadCoilsResponse).Coils;
                            for(int i =0;i< registerQuantity; i++)
                            {
                                Console.WriteLine(coils[i]);
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            response = client.ReadHoldingRegisters(0x0000, 0x000A);
                            foreach(var register in (response as ReadHoldingRegistersResponse).Registers)
                            {
                                Console.WriteLine(register);
                            }
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 15:
                            break;
                        case 16:
                            break;
                    }

                }

                await client.Close();

                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void Main() => RunClientAsync().Wait();
    }
}
