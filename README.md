# CoContra

Delegate-like classes for covariant and contravariant delegates and events.

## Installation

NuGet package listed on nuget.org at https://www.nuget.org/packages/CoContra/

[![NuGet Status](http://img.shields.io/nuget/v/CoContra.svg?style=flat)](https://www.nuget.org/packages/CoContra/)

## Usage

The following code demonstrates the broken implementation of delegates in .NET. The code will compile with no warnings, but will throw an exception at runtime when the second delegate is added.

```csharp
	Func<string> stringFactory = () => "hello";
	Func<object> objectFactory = () => new object();

	Func<object> multi1 = stringFactory;
	multi1 += objectFactory; // here

	Func<object> multi2 = objectFactory;
	multi2 += stringFactory; // here too
```

Replacing the multi-cast delegates with the classes in this library demonstrate the correct, expected behaviour.

```csharp
	Func<String> stringFactory = () => "hello";
	Func<Object> objectFactory = () => new object();

	CoContravariantFunc<object> multi1 = stringFactory;
	multi1 += objectFactory; // all good

	CoContravariantFunc<object> multi2 = objectFactory;
	multi2 += stringFactory; // yup
```

Events can be implemented like so...

```csharp
	private CovariantAction<String> covariantEventDelegates = new CovariantAction<String>();
	public event Action<String> Event { add { covariantEventDelegates += value; } remove { covariantEventDelegates -= value; } }

	// if you want to express that `covariantEventDelegates` be read-only, you must use `Add` and `Remove` since the operator overloading in the example immediately above requires write access to the field
	private readonly CovariantAction<String> covariantEventDelegates = new CovariantAction<String>();
	public event Action<String> Event { add { covariantEventDelegates.Add(value); } remove { covariantEventDelegates.Remove(value); } }
```

### Remarks

Covariant and contravariant multi-cast delegates are broken in .NET. They work correctly if there is only one delegate, but break at runtime if you try to add a covariant/contravariant delegate. This library contains a set of classes which match the API of the `Action<>` and `Func<>` delegates; `CovariantAction<>` and `CoContravariantFunc<>` respectively. They can be dropped in place with almost no changes to your code.

Missing/different elements of the API include:

- a lack of `()` invocation; you must use the `Invoke()` method
- `GetInvocationList()` returns an `ImmutableArray<TDelegate>` instead of `Delegate[]`
- `InvokeAsync()` was added to simplify the implementation of `BeginInvoke` and `EndInvoke`

## TODO

- Possibly expand this project to offer a single solution to delegates/events with respect to co-contra-variant vs invariant multi-cast delegates, thread-safety vs perf, weak vs strong

## Contributing

1. [Create an issue](https://github.com/NickStrupat/CoContra/issues/new)
2. Let's find some point of agreement on your suggestion.
3. Fork it!
4. Create your feature branch: `git checkout -b my-new-feature`
5. Commit your changes: `git commit -am 'Add some feature'`
6. Push to the branch: `git push origin my-new-feature`
7. Submit a pull request :D

## History

[Commit history](https://github.com/NickStrupat/CoContra/commits/master)

## License

MIT License