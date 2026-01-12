using System;
using System.Runtime.CompilerServices;

namespace Soenneker.Enumerables.CommaSeparated;

/// <summary>
/// Allocation-free enumeration of comma-separated values using <see cref="ReadOnlySpan{char}"/>.
/// Tokens are trimmed and empty entries are skipped.
/// Intended for lightweight CSV-style inputs (no quoting/escaping).
/// </summary>
public readonly ref struct CommaSeparatedEnumerable
{
    private readonly ReadOnlySpan<char> _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CommaSeparatedEnumerable(ReadOnlySpan<char> value) => _value = value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CommaSeparatedEnumerable(string? value) => _value = value.AsSpan();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CommaSeparatedEnumerator GetEnumerator() => new(_value);
}