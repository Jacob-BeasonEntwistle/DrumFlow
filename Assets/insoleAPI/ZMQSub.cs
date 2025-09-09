using System;
using System.Linq;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

public class ZMQSubscriber
{
    private SubscriberSocket socket;
    private Thread listenerThread;
    private bool running;

    public event Action<float[]> OnMessageReceived;

    public ZMQSubscriber(int port)
    {
        socket = new SubscriberSocket();
        socket.Connect($"tcp://localhost:{port}");
        socket.Subscribe("");

        running = true;
        listenerThread = new Thread(ListenLoop);
        listenerThread.Start();
    }

    private void ListenLoop()
    {
        while (running)
        {
            try
            {
                string msg = socket.ReceiveFrameString();
                float[] data = msg.Split('%')
                                  .Select(v => float.Parse(v))
                                  .ToArray();
                OnMessageReceived?.Invoke(data);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
            }
        }
    }

    public void Stop()
    {
        running = false;
        socket?.Dispose();
        listenerThread?.Join();
    }
}