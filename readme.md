__Overview__
This repository contains my solution to the Dye & Durham Coding Assessment, as described in the .pdf file provided to me. The problem itself is to read a list of names from a text file, sort them surname (or rather by the last word of the string provided), then by any forenames. Finally, the results are written out to a second text file.

__Implementation notes__

The task description places an emphasis on the importance of SOLID principles. As such, this solution is deliberately over-engineered in order to attempt to demonstrate these - at least to the extent to which this is possible for a relatively trivial problem. The code has been liberally commented - where I have made assumptions or taken design decisions, the reasoning behind these is hopefully clear.

Unit tests have been included for some components, though comprehensive unit and integration testing has not been implemented for reasons of time and practicality.

This exercise was also a good opportunity to revisit some of the [falsehoods programmers believe about names](https://shinesolutions.com/2018/01/08/falsehoods-programmers-believe-about-names-with-examples/).


__Installation__

This code was written against version 9.0 of the dotnet runtime. Installation is OS-dependent, however on Fedora it may be installed as follows -

```bash
sudo dnf install dotnet-runtime-9.0 dotnet-host dotnet-sdk-9.0
```

Test dependencies:

```bash
dotnet add package Xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Newtonsoft.JSON
```



Linters and analyzers (optional):

```bash
dotnet tool install -g dotnet-format
dotnet add package Microsoft.CodeAnalysis.NetAnalyzers
dotnet add package StyleCop.Analyzers
```

__Running the tool__

```bash
dotnet run ./unsorted-names-list.txt
```

or

```bash
/path/to/exe/name-sorter ./unsorted-names-list.txt
```

__Running the unit tests__

```bash
dotnet test
```


__Opportunities for future development__

- A variety of I/O errors aren't currently explicitly trapped or handled.
- Additional unit and integration tests.
- Testing of non-latin character sets, RTL or mixed RTL and RTL text, non-Unicode text encodings...