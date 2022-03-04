﻿namespace Narumikazuchi.Serialization.Bytes;

partial class IntegratedSerializationStrategies
{
    /// <summary>
    /// Handles serialization of <see cref="UInt64"/> values from and into <see cref="Byte"/>[].
    /// </summary>
    public readonly partial struct UInt64 : ISerializationDeserializationStrategy<System.Byte[], System.UInt64>
    {
        /// <summary>
        /// The statically allocated reference of this struct.
        /// </summary>
        public static ref UInt64 Reference =>
            ref s_Reference;

    }

    partial struct UInt64
    {
        private static UInt64 s_Reference = new();
        private static IDeserializationStrategy<System.Byte[], System.UInt64> s_DeserializationStrategy = s_Reference;
        private static ISerializationStrategy<System.Byte[], System.UInt64> s_SerializationStrategy = s_Reference;
    }

    partial struct UInt64 : IDeserializationStrategy<System.Byte[]>
    {
        Object? IDeserializationStrategy<System.Byte[]>.Deserialize(System.Byte[] input) =>
            s_DeserializationStrategy.Deserialize(input);
    }

    partial struct UInt64 : IDeserializationStrategy<System.Byte[], System.UInt64>
    {
        System.UInt64 IDeserializationStrategy<System.Byte[], System.UInt64>.Deserialize(System.Byte[] input) =>
            BitConverter.ToUInt64(input);
    }

    partial struct UInt64 : ISerializationStrategy<System.Byte[]>
    {
        System.Byte[] ISerializationStrategy<System.Byte[]>.Serialize(Object? input)
        {
            if (input is not UInt64 value)
            {
                throw new InvalidCastException();
            }
            return s_SerializationStrategy.Serialize(value);
        }
    }

    partial struct UInt64 : ISerializationStrategy<System.Byte[], System.UInt64>
    {
        System.Byte[] ISerializationStrategy<System.Byte[], System.UInt64>.Serialize(System.UInt64 input) =>
            BitConverter.GetBytes(input);
    }
}