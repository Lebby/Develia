using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;

namespace DeveliaGameEngine
{
    public class StorageManager
    {
        StorageDevice _storageDevice;
        StorageContainer _storageContainer;
        IAsyncResult _asyncResult;

        //SavingState savingState = SavingState.NotSaving;        
        //PlayerIndex playerIndex = PlayerIndex.One;

        public StorageManager()
        {
            //_storageDevice = new StorageDevice();
            //IsolatedStorageFile turi;
        }

        public static StorageContainer Open(string containerName, PlayerIndex player, AsyncCallback cb, object state)
        {
            IAsyncResult result = StorageDevice.BeginShowSelector(player, cb, state);
            result.AsyncWaitHandle.WaitOne();
            StorageDevice device = StorageDevice.EndShowSelector(result);

            // Open a storage container.
            result = device.BeginOpenContainer(containerName, null, null);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            StorageContainer container = device.EndOpenContainer(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();
            return container;
        }

        public static StorageContainer Open(string containerName, PlayerIndex player)
        {
            return Open(containerName, player, null,null);
        }

        public static StorageContainer Open(string containerName)
        {
            return Open(containerName, PlayerIndex.One);                        
        }

        public static void Close(StorageContainer container)
        {
            container.Dispose();
        }

        public static void Save<T>(StorageContainer container, string filename, T data)
        {
            if (container.FileExists(filename))
                // Delete it so that we can create one fresh.
                container.DeleteFile(filename);            
            Stream stream = container.CreateFile(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, data);
            stream.Close();            
        }

        public static T Load<T>(StorageContainer container, string filename)
        {
            if (!container.FileExists(filename))
                // Delete it so that we can create one fresh.
                return default(T);
            // Open the file.
            Stream stream = container.OpenFile(filename, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T data = (T)serializer.Deserialize(stream);
            stream.Close();
            return data;
        }

        
        public static void Save<T>(string filename,T data)
        {
            Stream stream = File.Create(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, data);                        
            stream.Close();
        }

        public static T Load<T>(string filename)
        {
            Stream stream = File.OpenRead(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T data = (T)serializer.Deserialize(stream);
            stream.Close();
            return data;
        }
        
    }
}
