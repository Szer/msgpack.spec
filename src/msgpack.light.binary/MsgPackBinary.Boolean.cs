using System;
using System.Runtime.CompilerServices;

using static ProGaudi.MsgPack.Light.DataCodes;

namespace ProGaudi.MsgPack.Light
{
    /// <summary>
    /// Methods for working with boolean
    /// </summary>
    public static partial class MsgPackBinary
    {
        /// <summary>
        /// Writes boolean value to buffer.
        /// </summary>
        /// <returns>Count of bytes, written to <paramref name="buffer"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteBoolean(Span<byte> buffer, bool value)
        {
            buffer[0] = value ? True : False;
            return 1;
        }

        /// <summary>
        /// Tries to write boolean value into <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer to write.</param>
        /// <param name="value">Value to write</param>
        /// <param name="wroteSize">Count of bytes, written to <paramref name="buffer"/>. If return value is <c>false</c>, value is unspecified.</param>
        /// <returns><c>true</c>, if everything is ok, <c>false</c> if <paramref name="buffer"/> is too small.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryWriteBoolean(Span<byte> buffer, bool value, out int wroteSize)
        {
            wroteSize = 1;
            if (buffer.Length < wroteSize) return false;
            buffer[0] = value ? True : False;
            return true;
        }

        /// <summary>
        /// Read boolean value from buffer.
        /// </summary>
        /// <param name="buffer">Buffer to read from</param>
        /// <param name="readSize">Count of bytes, read from <paramref name="buffer"/>.</param>
        /// <returns>Boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ReadBoolean(ReadOnlySpan<byte> buffer, out int readSize)
        {
            readSize = 1;
            var result = buffer[0];
            if (result != True && result != False) throw WrongCode(result, True, False);
            return result == True;
        }

        /// <summary>
        /// Tries to write boolean value into <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer to read form.</param>
        /// <param name="value">Result. If return false is <c>false</c>, value is unspecified.</param>
        /// <param name="readSize">Count of bytes, read from <paramref name="buffer"/>. If return value is <c>false</c>, value is unspecified.</param>
        /// <returns><c>true</c>, if everything is ok, <c>false</c> if <paramref name="buffer"/> is too small or <paramref name="buffer"/>[0] is not <see cref="True"/> or <see cref="DataCodes.False"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadBoolean(ReadOnlySpan<byte> buffer, out bool value, out int readSize)
        {
            readSize = 1;
            value = false;
            if (buffer.Length < readSize) return false;
            value = buffer[0] == True;
            return value || buffer[0] == False;
        }
    }
}
