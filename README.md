[![](https://img.shields.io/nuget/v/soenneker.enumerables.commaseparated.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.enumerables.commaseparated/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enumerables.commaseparated/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.enumerables.commaseparated/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.enumerables.commaseparated.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.enumerables.commaseparated/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enumerables.commaseparated/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.enumerables.commaseparated/actions/workflows/codeql.yml)

# Soenneker.Enumerables.CommaSeparated

Allocation-free enumeration of comma-separated values using `ReadOnlySpan<char>`. Tokens are trimmed and empty entries are skipped. Intended for lightweight CSV-style inputs (no quoting/escaping).

## Install

```bash
dotnet add package Soenneker.Enumerables.CommaSeparated
```

## What you get

- `CommaSeparatedEnumerable` — Allocation-free enumeration of comma-separated values using `ReadOnlySpan<char>`. Tokens are trimmed and empty entries are skipped. Intended for lightweight CSV-style inputs (no quoting/escaping).
- `CommaSeparatedEnumerator` — Stack-only enumerator that yields trimmed comma-separated tokens without allocations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `CommaSeparatedEnumerable.Count()` | Counts non-empty, trimmed comma-separated tokens without allocations. | The resulting value. |
| `CommaSeparatedEnumerator.Current` | The current token (trimmed, non-empty). | The current token (trimmed, non-empty). |
| `CommaSeparatedEnumerator.MoveNext()` | Advances to the next token. | true if advances to the next token; otherwise, false. |
