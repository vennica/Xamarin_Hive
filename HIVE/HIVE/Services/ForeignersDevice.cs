using System;
using System.Text;
using Microsoft.Azure.Devices.Client;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HIVE
{
    class ForeignersDevice
    {
        static string DeviceConnectionString = "HostName=ForeignersHub.azure-devices.net;DeviceId={0};SharedAccessKey=n2bXo6rZL5rzqN0KMmn5UStEtmYdgWWMnEnGIuTYEig=";
        public DeviceClient DeviceClientHttp;
        public DeviceClient DeviceClientMqtt;

        public ForeignersDevice(string DeviceName)
        {
            //IoTHubConnectionString are hard coded, we can assign the device name upon initiation of the class Object
            //Connect to the Device upon instantiation of the object
            DeviceConnectionString = String.Format(DeviceConnectionString, DeviceName);
            try
            {
                DeviceClientHttp = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Http1);
                //DeviceClientMqtt = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Mqtt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error CONNECTING to Hub " + ex.Message);
                return;
            }
        }
        /*
        public async Task<string> ReceiveCloudToDeviceMessages()
        {
            Message receivedMessage = await DeviceClientMqtt.ReceiveAsync();
            byte[] data = receivedMessage.GetBytes();
            string message = Encoding.UTF8.GetString(data, 0, data.Length);
            await DeviceClientMqtt.CompleteAsync(receivedMessage);
            return message;
        }
        */
        public void SendDevicetoCloudMessageAsync(string message)
        {
            //For PCL to send commands to be later used for running methods remotely on the Pi
            //For Pi to send telemetry
            if (DeviceClientHttp != null)
            {
                try
                {
                    var eventMessage = new Message(Encoding.UTF8.GetBytes(message));
                    DeviceClientHttp.SendEventAsync(eventMessage);
                    //DeviceClientMqtt.SendEventAsync(eventMessage);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error SENDING MESSAGE to Hub " + ex.Message);
                    return;
                }
            }
        }

    }
}
