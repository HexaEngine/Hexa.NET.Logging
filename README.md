# Hexa.NET.Logging

## Overview

Hexa.NET.Logging is a small, efficient logging framework for .NET applications. It provides a simple API for logging messages at various levels (e.g., error, warning, information). This framework is designed to be lightweight and easy to integrate into your existing .NET applications.

## Features

- Lightweight and efficient logging.
- Easy-to-use API.
- Support for multiple logging levels.
- Ability to cache loggers for improved performance.
- Exception logging support.
- Conditional logging support.
- Async logging support.

## Installation

To install Hexa.NET.Logging, add the following package to your project:

```bash
dotnet add package Hexa.NET.Logging
```

Usage

Here is a basic example of how to use Hexa.NET.Logging in your application:

1. Getting a Logger:
```csharp
using Hexa.NET.Logging;

// Retrieve a logger for a specific category
var logger = LoggerFactory.GetLogger(nameof(MyClass));

// Store the logger in a static field/property for better performance
private static readonly ILogger _logger = LoggerFactory.GetLogger(nameof(MyClass));
```

2. Logging Messages:
```csharp
// Log an error message
_logger.Error("Failed to create input layout, signature was null.");

// Log a warning message
_logger.Warning("This is a warning message.");

// Log an informational message
_logger.Info("This is an informational message.");
```

3. Logging Exceptions:
```csharp
try
{
    // Your code here
}
catch (Exception ex)
{
    _logger.Log(ex); // Log the exception
}
```

4. Conditional Logging:
```csharp
// Log a message only if a condition is met
_logger.WarnIf(foo == bar, "This is a warning message.");
```

5. Example in a Class:
```csharp
using Hexa.NET.Logging;

public class MyClass
{
    private static readonly ILogger _logger = LoggerFactory.GetLogger(nameof(MyClass));

    public void SomeMethod()
    {
        _logger.Info("This is an informational message.");
        try
        {
            // Your code here
        }
        catch (Exception ex)
        {
            _logger.Log(ex); // Log the exception
        }
    }
}
```

## Logging Levels

Hexa.NET.Logging supports the following logging levels:

- Critical: Use for logging critical messages that indicate a critical failure in the application.
- Error: Use for logging error messages that indicate a failure in the application.
- Warning: Use for logging warning messages that indicate a potential issue or important information.
- Info: Use for logging informational messages that highlight the progress of the application.
- Debug: Use for logging debug messages that provide detailed information for debugging purposes.
- Trace: Use for logging trace messages that provide detailed information for tracing purposes.

## Best Practices

- **Cache Loggers:** Store the ILogger instances in static fields or properties to avoid retrieving the logger multiple times, which can improve performance.
- **Use Appropriate Logging Levels:** Use the correct logging level to ensure that the log output is meaningful and easy to understand.
- **Log Exceptions:** Use the Log(Exception ex) method to log exceptions and capture stack trace information.
- **Conditional Logging:** Use conditional logging methods to log messages based on specific conditions.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes. Ensure that your code follows the project's coding standards and includes appropriate tests.

## License

Hexa.NET.Logging is licensed under the MIT License. See the [LICENSE](https://github.com/HexaEngine/Hexa.NET.Logging/blob/master/LICENSE.txt) file for more details.
