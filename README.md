[![](https://img.shields.io/nuget/v/soenneker.enumerables.commaseparated.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.enumerables.commaseparated/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enumerables.commaseparated/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.enumerables.commaseparated/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.enumerables.commaseparated.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.enumerables.commaseparated/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enumerables.commaseparated/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.enumerables.commaseparated/actions/workflows/codeql.yml)

# Soenneker.Enumerables.CommaSeparated

Enumerates simple comma-delimited text as trimmed `ReadOnlySpan<char>` tokens without allocating a string or array for each value.

## Install

```bash
dotnet add package Soenneker.Enumerables.CommaSeparated
```

## Enumerate values

```csharp
using Soenneker.Enumerables.CommaSeparated;

ReadOnlySpan<char> input = "alpha, beta, ,gamma";

foreach (ReadOnlySpan<char> token in new CommaSeparatedEnumerable(input))
{
    // token is "alpha", then "beta", then "gamma"
    Process(token);
}
```

Leading and trailing whitespace is trimmed from each token. Empty entries—including whitespace-only entries—are skipped. A null string constructor argument behaves like an empty input.

## Parse without intermediate strings

Many framework parsing APIs accept spans directly:

```csharp
var values = new CommaSeparatedEnumerable("10, 20, 30");
var total = 0;

foreach (ReadOnlySpan<char> value in values)
    total += int.Parse(value);

int count = values.Count(); // 3
```

`Count()` scans the input independently; it does not cache tokens. Calling it and then enumerating performs two passes.

## Boundaries

This is not a CSV parser. Commas always delimit values, and quoting, escaped commas, embedded records, and alternate separators are not supported. Use a CSV library when inputs can contain those features.

Both the enumerable and enumerator are `ref struct` types. They cannot be boxed, stored on the heap, used across `await` or `yield`, or exposed as `IEnumerable<T>`. Each `Current` span points into the original input; call `ToString()` if a token must outlive that input or the current synchronous scope.
