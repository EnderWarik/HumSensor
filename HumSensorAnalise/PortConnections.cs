using System.IO.Ports;
using Microsoft.AspNetCore.Mvc;
using HumSensorAnalise.Models;
using System.Text;
using System.Linq;

namespace HumSensorAnalise
{
    public class PortConnections : BackgroundService
    {
        private IConfiguration config;

        byte[] buffer = new byte[1024];
        int offset = 0;



        public PortConnections(IConfiguration config)
        {
            this.config = config;
        }

        SerialPort serialPort;
        private Queue<ushort> recievedData = new Queue<ushort>();


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            serialPort = new SerialPort(portName: config.GetValue<string>("Port"), baudRate: 115200);


            serialPort.Open();

            while (true)
            {
                serialPort.Write(new byte[] { 1 }, 0, 1);


                int readCount = 0;
                while (readCount < 2)
                {
                    readCount += serialPort.Read(buffer, readCount, buffer.Length - readCount);
                }

                var val = BitConverter.ToUInt16(buffer.AsSpan(0, readCount));
                //Console.WriteLine(val);

                await Task.Delay(100);

            }


        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           


           


            //while(true)
            //{
            //    var start = slice.IndexOf((byte)'\n');

            //    slice = buffer.AsSpan(start + 1, slice.Length - start);
            //    var end = slice.IndexOf((byte)'\n');
            //    if (end == -1)
            //    {

            //        slice.CopyTo(buffer.AsSpan(0, slice.Length));
            //        offset = slice.Length;
            //        break;
            //    }

            //    var slice1 = slice.Slice(0, end+1);
                
            //}




               

              


            
               
               

              

            //buffer.ToList().ForEach(b => recievedData.Enqueue(b));
            ////Console.WriteLine(serialPort.ReadLine());//?

            ////  Console.Write(Encoding.ASCII.GetString(data));

            ////FormatBytes(data);


            //if (recievedData.Count > 100)
            //{
            //    // string temp = "";
            //    byte[] packet = new byte[recievedData.Count];
            //    for (int i = 0; i < 100; i++)
            //    {
            //        //temp+= recievedData.Dequeue();
            //        packet[i] = recievedData.Dequeue();// + " ";

            //        //temp+= packet[i]+ " ";

            //    }
            //    for (int i = 0; i < 100; i += 2)
            //    {
            //        //temp+= recievedData.Dequeue();


            //        var span = packet.AsSpan().Slice(i, 2);

            //        Console.WriteLine(BitConverter.ToUInt16(span));

            //        //temp+= packet[i]+ " ";

            //    }


            //    int a = 0;
            //    // recievedData.Select(i => recievedData.Dequeue());              //Enumerable.Range(0, 1000).Select(i => recievedData.Dequeue());

            //    //Console.Write(Encoding.ASCII.GetString(packet));
            //    int maxHum = 600;
            //    int minHum = 200;
            //    string[] dataConvert = Encoding.ASCII.GetString(packet).Split(new char[] { '\n', '\r' });
            //    int[] dataConvertToInt = new int[dataConvert.Length];
            //    int l = 0;
            //    for (int i = 0; i < dataConvert.Length - 1; i++)
            //    {
            //        if (dataConvert[i] != "")
            //        {
            //            Console.WriteLine(Convert.ToInt32(dataConvert[i]));
            //            if (Convert.ToInt32(dataConvert[i]) > minHum && Convert.ToInt32(dataConvert[i]) < maxHum)
            //            {
            //                dataConvertToInt[l] = Convert.ToInt32(dataConvert[i]);

            //                Console.WriteLine(dataConvertToInt[l]);
            //                l++;
            //            }
            //        }
            //    }

            //    AddMidToBd(dataConvertToInt);
            //    double sum = 0;
            //    for (int i = 0; i < dataConvertToInt.Length; i++)
            //    {
            //        sum += dataConvertToInt[i];
            //    }

            //    sum = sum / dataConvertToInt.Length;
            //    sum = Math.Ceiling(sum);
            //    sum = sum / maxHum * 100;
            //    sum = Math.Round(sum, 2);
            //    //среднее мин макс и максимальнопоявл и диапазон времени
            //    using (ApplicationContext db = new ApplicationContext())
            //    {

            //        db.humSensor.Add(new HumSensor { result = sum, dtAdd = DateTime.Now.ToUniversalTime() });
            //        db.SaveChanges();
            //    };

            //}

        }



        private void AddMidToBd(int[] model) //асинхронный низя тк может быть накладка
        {

        }

    }
}
