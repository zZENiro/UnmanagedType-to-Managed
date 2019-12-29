using System;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace u4us__1
{

    unsafe class Program
    {
        // Для неуправляемого типа Person наследуется интерфейс IDisposable
        // Реализуются методы Dispose(bool) / Dispose()
        // в методе Dispose() вызывается статический метод GC.SupressFinalize() - где 
        // указывается указатель на наш тип Perosn

        public unsafe class Person : IDisposable
        {
            public unsafe int Age { get; set; }

            public unsafe string Name { get; set; }

            private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

            private bool _disposed = false;

            ~Person()
            {
                Console.WriteLine("Person disposed");
            }

            public void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                if (disposing)
                {
                    _safeHandle.Dispose();

                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
