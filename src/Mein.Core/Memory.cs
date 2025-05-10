using System.Runtime.InteropServices;

namespace Mein.Core;

public static class Memory
{
	public unsafe struct OwnedRef<T> : IDisposable
		where T : unmanaged
	{
		internal T* Pointer;

		public void Dispose()
		{
			if (Pointer != null)
			{
				NativeMemory.Free(Pointer);
				Pointer = null;
			}
		}
	}

	public unsafe static void InitOwnedRef<T>(out OwnedRef<T> ownedRef) where T : unmanaged
	{
		ownedRef.Pointer = (T*)NativeMemory.Alloc((nuint)sizeof(T));
	}
}
