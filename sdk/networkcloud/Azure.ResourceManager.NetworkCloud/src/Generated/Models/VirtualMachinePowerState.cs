// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> The power state of the virtual machine. </summary>
    public readonly partial struct VirtualMachinePowerState : IEquatable<VirtualMachinePowerState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VirtualMachinePowerState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VirtualMachinePowerState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OnValue = "On";
        private const string OffValue = "Off";

        /// <summary> On. </summary>
        public static VirtualMachinePowerState On { get; } = new VirtualMachinePowerState(OnValue);
        /// <summary> Off. </summary>
        public static VirtualMachinePowerState Off { get; } = new VirtualMachinePowerState(OffValue);
        /// <summary> Determines if two <see cref="VirtualMachinePowerState"/> values are the same. </summary>
        public static bool operator ==(VirtualMachinePowerState left, VirtualMachinePowerState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VirtualMachinePowerState"/> values are not the same. </summary>
        public static bool operator !=(VirtualMachinePowerState left, VirtualMachinePowerState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VirtualMachinePowerState"/>. </summary>
        public static implicit operator VirtualMachinePowerState(string value) => new VirtualMachinePowerState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VirtualMachinePowerState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VirtualMachinePowerState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
