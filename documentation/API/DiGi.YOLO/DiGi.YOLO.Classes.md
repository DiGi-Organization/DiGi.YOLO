#### [DiGi\.YOLO](DiGi.YOLO.Overview.md 'DiGi\.YOLO\.Overview')

## DiGi\.YOLO\.Classes Namespace
### Classes

<a name='DiGi.YOLO.Classes.BoundingBox'></a>

## BoundingBox Class

Represents a rectangular bounding box used to define the location and size of an object within an image\.

```csharp
public class BoundingBox : DiGi.YOLO.Interfaces.IBoundingBox
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BoundingBox

Derived  
↳ [BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')

Implements [IBoundingBox](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox 'DiGi\.YOLO\.Interfaces\.IBoundingBox')
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double)'></a>

## BoundingBox\(double, double, double, double\) Constructor

Initializes a new instance of the [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') class\.

```csharp
public BoundingBox(double x, double y, double width, double height);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The x\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The y\-coordinate of the top\-left corner of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBox.BoundingBox(double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.
### Properties

<a name='DiGi.YOLO.Classes.BoundingBox.Height'></a>

## BoundingBox\.Height Property

Gets the height of the bounding box\.

```csharp
public double Height { get; }
```

Implements [Height](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Height 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Height')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.Width'></a>

## BoundingBox\.Width Property

Gets the width of the bounding box\.

```csharp
public double Width { get; }
```

Implements [Width](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Width 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Width')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.X'></a>

## BoundingBox\.X Property

Gets the x\-coordinate of the top\-left corner of the bounding box\.

```csharp
public double X { get; }
```

Implements [X](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.X 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.X')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBox.Y'></a>

## BoundingBox\.Y Property

Gets the y\-coordinate of the top\-left corner of the bounding box\.

```csharp
public double Y { get; }
```

Implements [Y](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox.Y 'DiGi\.YOLO\.Interfaces\.IBoundingBox\.Y')

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')
### Methods

<a name='DiGi.YOLO.Classes.BoundingBox.Equals(object)'></a>

## BoundingBox\.Equals\(object\) Method

Determines whether the specified object is equal to the current bounding box based on its coordinates and dimensions\.

```csharp
public override bool Equals(object? @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBox.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current bounding box\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the objects are equal; otherwise, false\.

<a name='DiGi.YOLO.Classes.BoundingBox.GetHashCode()'></a>

## BoundingBox\.GetHashCode\(\) Method

Returns a hash code for the current bounding box based on its coordinates and dimensions\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A hash code for the current object\.

<a name='DiGi.YOLO.Classes.BoundingBox.ToString()'></a>

## BoundingBox\.ToString\(\) Method

Returns a string that represents the current bounding box in the format "x y width height"\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string representation of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult'></a>

## BoundingBoxResult Class

Represents the result of a bounding box detection, containing spatial coordinates, label information, and confidence score\.

```csharp
public class BoundingBoxResult : DiGi.YOLO.Classes.BoundingBox
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') → BoundingBoxResult
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double)'></a>

## BoundingBoxResult\(string, int, double, double, double, double, double\) Constructor

Initializes a new instance of the [BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult') class\.

```csharp
public BoundingBoxResult(string? name, int labelIndex, double x, double y, double width, double height, double confidence);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the detected object\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label associated with the detection\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X coordinate of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y coordinate of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the bounding box\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.BoundingBoxResult(string,int,double,double,double,double,double).confidence'></a>

`confidence` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence score of the detection\.
### Properties

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Confidence'></a>

## BoundingBoxResult\.Confidence Property

Gets the confidence score of the detected object\.

```csharp
public double Confidence { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.BoundingBoxResult.LabelIndex'></a>

## BoundingBoxResult\.LabelIndex Property

Gets the index of the label for the detected object\.

```csharp
public int LabelIndex { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Name'></a>

## BoundingBoxResult\.Name Property

Gets the name of the detected object\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Equals(object)'></a>

## BoundingBoxResult\.Equals\(object\) Method

Determines whether the specified object is equal to the current bounding box result based on its properties\.

```csharp
public override bool Equals(object? @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.BoundingBoxResult.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current object\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the objects are equal; otherwise, `false`\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.GetHashCode()'></a>

## BoundingBoxResult\.GetHashCode\(\) Method

Gets the hash code for the current bounding box result\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer hash code\.

<a name='DiGi.YOLO.Classes.BoundingBoxResult.ToString()'></a>

## BoundingBoxResult\.ToString\(\) Method

Returns a string representation of the bounding box result, including name, label index, coordinates, dimensions, and confidence\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A tab\-separated string containing the detection details\.

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile'></a>

## BoundingBoxResultFile Class

Represents a collection of bounding box results typically associated with a result file\.

```csharp
public class BoundingBoxResultFile : System.Collections.Generic.List<DiGi.YOLO.Classes.BoundingBoxResult>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[BoundingBoxResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResult 'DiGi\.YOLO\.Classes\.BoundingBoxResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1') → BoundingBoxResultFile
### Constructors

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile.BoundingBoxResultFile()'></a>

## BoundingBoxResultFile\(\) Constructor

Initializes a new instance of the [BoundingBoxResultFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBoxResultFile 'DiGi\.YOLO\.Classes\.BoundingBoxResultFile') class\.

```csharp
public BoundingBoxResultFile();
```
### Methods

<a name='DiGi.YOLO.Classes.BoundingBoxResultFile.ToString()'></a>

## BoundingBoxResultFile\.ToString\(\) Method

Returns a string representation of the bounding box results contained in the file,
with each result on a new line\.

```csharp
public override string? ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the concatenated string representations of all valid bounding box results\.

<a name='DiGi.YOLO.Classes.ConfigurationFile'></a>

## ConfigurationFile Class

Represents the configuration settings for a YOLO project, including directory paths and labels\.

```csharp
public class ConfigurationFile
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ConfigurationFile
### Constructors

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile()'></a>

## ConfigurationFile\(\) Constructor

Initializes a new instance of the [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') class\.

```csharp
public ConfigurationFile();
```

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_)'></a>

## ConfigurationFile\(string, string, string, string, IEnumerable\<Label\>\) Constructor

Initializes a new instance of the [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') class with specified directory paths and labels\.

```csharp
public ConfigurationFile(string? directory, string? trainDirectoryName, string? validateDirectoryName, string? testDirectoryName, System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label>? labels);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base root directory path\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).trainDirectoryName'></a>

`trainDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the training directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).validateDirectoryName'></a>

`validateDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the validation directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).testDirectoryName'></a>

`testDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the test directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_).labels'></a>

`labels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of labels to be associated with this configuration\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_)'></a>

## ConfigurationFile\(string, string, string, string, IEnumerable\<Label\>, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') class with specified directory paths, labels and the messages reading the file produced\.

```csharp
public ConfigurationFile(string? directory, string? trainDirectoryName, string? validateDirectoryName, string? testDirectoryName, System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label>? labels, System.Collections.Generic.IEnumerable<string>? messages);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base root directory path\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).trainDirectoryName'></a>

`trainDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the training directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).validateDirectoryName'></a>

`validateDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the validation directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).testDirectoryName'></a>

`testDirectoryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The relative name of the test directory\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).labels'></a>

`labels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of labels to be associated with this configuration\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ConfigurationFile(string,string,string,string,System.Collections.Generic.IEnumerable_DiGi.YOLO.Classes.Label_,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The messages reading the file produced, such as a fall\-back of the base directory, or `null` when there were none\.
### Properties

<a name='DiGi.YOLO.Classes.ConfigurationFile.Directory'></a>

## ConfigurationFile\.Directory Property

Gets the base root directory path\.

```csharp
public string? Directory { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.ConfigurationFile.Labels'></a>

## ConfigurationFile\.Labels Property

Gets the collection of labels associated with this configuration\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label> Labels { get; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.YOLO.Classes.ConfigurationFile.Messages'></a>

## ConfigurationFile\.Messages Property

Gets the messages reading the file produced, such as a base directory that did not exist and was replaced by the directory of the file, or `null` when there were none\.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')
### Methods

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetCategories()'></a>

## ConfigurationFile\.GetCategories\(\) Method

Retrieves all categories defined within the configuration\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category> GetCategories();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') values\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectory(DiGi.YOLO.Enums.Category)'></a>

## ConfigurationFile\.GetDirectory\(Category\) Method

Gets the full combined path for a specific category\.

```csharp
public string? GetDirectory(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectory(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the full directory path\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute path combining the base directory and the category folder, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if not found or empty\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectoryNames(DiGi.YOLO.Enums.Category)'></a>

## ConfigurationFile\.GetDirectoryNames\(Category\) Method

Gets the relative directory name for a specific category\.

```csharp
public string? GetDirectoryNames(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.ConfigurationFile.GetDirectoryNames(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category for which to retrieve the folder name\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The relative directory name, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if not found or empty\.

<a name='DiGi.YOLO.Classes.ConfigurationFile.ToString()'></a>

## ConfigurationFile\.ToString\(\) Method

Returns a string representation of the configuration file, formatted for output or storage\.

```csharp
public override string? ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A formatted string containing the base path, category paths, and label names\.

<a name='DiGi.YOLO.Classes.Image'></a>

## Image Class

Represents an image associated with a collection of [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') instances\.

```csharp
public class Image : DiGi.YOLO.Classes.Image<DiGi.YOLO.Classes.BoundingBox>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.YOLO\.Classes\.Image&lt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>') → Image
### Constructors

<a name='DiGi.YOLO.Classes.Image.Image(string)'></a>

## Image\(string\) Constructor

Initializes a new instance of the [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') class\.

```csharp
public Image(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image.Image(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path to the image\.
### Methods

<a name='DiGi.YOLO.Classes.Image.GetLabelFile()'></a>

## Image\.GetLabelFile\(\) Method

Creates and populates a [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') containing all bounding boxes associated with this image\.

```csharp
public DiGi.YOLO.Classes.LabelFile GetLabelFile();
```

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
A [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') instance populated with the image's bounding box data\.

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_'></a>

## Image\<TBoundingBox\> Class

Represents an image associated with a collection of bounding boxes categorized by label indices\.

```csharp
public class Image<TBoundingBox>
    where TBoundingBox : DiGi.YOLO.Interfaces.IBoundingBox
```
#### Type parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox'></a>

`TBoundingBox`

The type of the bounding box, which must implement [IBoundingBox](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IBoundingBox 'DiGi\.YOLO\.Interfaces\.IBoundingBox')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Image\<TBoundingBox\>

Derived  
↳ [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')
### Constructors

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Image(string)'></a>

## Image\(string\) Constructor

Initializes a new instance of the [Image&lt;TBoundingBox&gt;](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_ 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>') class\.

```csharp
public Image(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Image(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path to the image\.
### Fields

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.boundingBoxes'></a>

## Image\<TBoundingBox\>\.boundingBoxes Field

The dictionary containing bounding boxes grouped by label indices\.

```csharp
protected Dictionary<int,HashSet<TBoundingBox>> boundingBoxes;
```

#### Field Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.path'></a>

## Image\<TBoundingBox\>\.path Field

The file path to the image\.

```csharp
protected string? path;
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Properties

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.LabelIndexes'></a>

## Image\<TBoundingBox\>\.LabelIndexes Property

Gets the collection of label indices that have associated bounding boxes in this image\.

```csharp
public System.Collections.Generic.IEnumerable<int> LabelIndexes { get; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Path'></a>

## Image\<TBoundingBox\>\.Path Property

Gets the file path of the image\.

```csharp
public string? Path { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.this[int]'></a>

## Image\<TBoundingBox\>\.this\[int\] Property

Gets the set of bounding boxes associated with the specified label index\.

```csharp
public System.Collections.Generic.IEnumerable<TBoundingBox>? this[int labelIndex] { get; }
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.this[int].labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label to retrieve bounding boxes for\.

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')
### Methods

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox)'></a>

## Image\<TBoundingBox\>\.Add\(int, TBoundingBox\) Method

Adds a bounding box to the image for the specified label index\.

```csharp
public bool Add(int labelIndex, TBoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label\.

<a name='DiGi.YOLO.Classes.Image_TBoundingBox_.Add(int,TBoundingBox).boundingBox'></a>

`boundingBox` [TBoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image_TBoundingBox_.TBoundingBox 'DiGi\.YOLO\.Classes\.Image\<TBoundingBox\>\.TBoundingBox')

The bounding box instance to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the bounding box was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.Label'></a>

## Label Class

Represents a label associated with an object detection class in YOLO\.

```csharp
public class Label
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Label
### Constructors

<a name='DiGi.YOLO.Classes.Label.Label(int,string)'></a>

## Label\(int, string\) Constructor

Initializes a new instance of the [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') class\.

```csharp
public Label(int index, string? name);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Label.Label(int,string).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The numerical index for the label\.

<a name='DiGi.YOLO.Classes.Label.Label(int,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The descriptive name for the label\.
### Fields

<a name='DiGi.YOLO.Classes.Label.index'></a>

## Label\.index Field

The numerical index of the label\.

```csharp
public int index;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.Label.name'></a>

## Label\.name Field

The descriptive name of the label\.

```csharp
public string? name;
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Properties

<a name='DiGi.YOLO.Classes.Label.Index'></a>

## Label\.Index Property

Gets the numerical index of the label\.

```csharp
public int Index { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.Label.Name'></a>

## Label\.Name Property

Gets the descriptive name of the label\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.YOLO.Classes.Label.Equals(object)'></a>

## Label\.Equals\(object\) Method

Determines whether the specified object is equal to the current label based on its string representation\.

```csharp
public override bool Equals(object @object);
```
#### Parameters

<a name='DiGi.YOLO.Classes.Label.Equals(object).object'></a>

`object` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare with the current label\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the objects are equal; otherwise, false\.

<a name='DiGi.YOLO.Classes.Label.GetHashCode()'></a>

## Label\.GetHashCode\(\) Method

Returns a hash code for the current label based on its string representation\.

```csharp
public override int GetHashCode();
```

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
A 32\-bit signed integer hash code\.

<a name='DiGi.YOLO.Classes.Label.ToString()'></a>

## Label\.ToString\(\) Method

Returns a string that represents the current label\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the index and name of the label\.

<a name='DiGi.YOLO.Classes.LabelFile'></a>

## LabelFile Class

Represents a label file containing associations between class indices and bounding boxes for an image\.

```csharp
public class LabelFile
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → LabelFile
### Constructors

<a name='DiGi.YOLO.Classes.LabelFile.LabelFile()'></a>

## LabelFile\(\) Constructor

Initializes a new instance of the [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') class\.

```csharp
public LabelFile();
```
### Fields

<a name='DiGi.YOLO.Classes.LabelFile.tuples'></a>

## LabelFile\.tuples Field

The collection of tuples pairing label indices with their corresponding bounding boxes\.

```csharp
public List<Tuple<int,BoundingBox>> tuples;
```

#### Field Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Tuple&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')
### Properties

<a name='DiGi.YOLO.Classes.LabelFile.Count'></a>

## LabelFile\.Count Property

Gets the total number of entries in the label file\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox)'></a>

## LabelFile\.Add\(int, BoundingBox\) Method

Adds a label index and its associated bounding box to the collection\.

```csharp
public bool Add(int labelIndex, DiGi.YOLO.Classes.BoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer index of the label\.

<a name='DiGi.YOLO.Classes.LabelFile.Add(int,DiGi.YOLO.Classes.BoundingBox).boundingBox'></a>

`boundingBox` [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')

The bounding box associated with the label\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the pair was successfully added; otherwise, false if the bounding box is null or the index is negative\.

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBox(int)'></a>

## LabelFile\.GetBoundingBox\(int\) Method

Retrieves the bounding box at the specified position\.

```csharp
public DiGi.YOLO.Classes.BoundingBox GetBoundingBox(int index);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBox(int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based index of the entry to retrieve\.

#### Returns
[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')  
The [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') associated with the given position\.

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBoxes(int)'></a>

## LabelFile\.GetBoundingBoxes\(int\) Method

Retrieves all bounding boxes associated with a specific label index\.

```csharp
public System.Collections.Generic.List<DiGi.YOLO.Classes.BoundingBox> GetBoundingBoxes(int labelIndex);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetBoundingBoxes(int).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The label index to filter by\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox') objects matching the specified label index\.

<a name='DiGi.YOLO.Classes.LabelFile.GetLabelIndex(int)'></a>

## LabelFile\.GetLabelIndex\(int\) Method

Retrieves the label index at the specified position\.

```csharp
public int GetLabelIndex(int index);
```
#### Parameters

<a name='DiGi.YOLO.Classes.LabelFile.GetLabelIndex(int).index'></a>

`index` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The zero\-based index of the entry to retrieve\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The label index associated with the given position\.

<a name='DiGi.YOLO.Classes.LabelFile.GetTagIndexes()'></a>

## LabelFile\.GetTagIndexes\(\) Method

Retrieves a set of all unique tag indices present in the label file\.

```csharp
public System.Collections.Generic.HashSet<int> GetTagIndexes();
```

#### Returns
[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')  
A [System\.Collections\.Generic\.HashSet&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1') containing the unique label indices\.

<a name='DiGi.YOLO.Classes.LabelFile.ToString()'></a>

## LabelFile\.ToString\(\) Method

Returns a string representation of the label file, formatted as space\-separated values per line\.

```csharp
public override string ToString();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
A string containing the labels and bounding boxes separated by new lines\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation'></a>

## YOLOCheckpointInformation Class

Describes an ultralytics training checkpoint read by [YOLOCheckpointInformation\(string, string, string, CancellationToken\)](DiGi.YOLO.md#DiGi.YOLO.Query.YOLOCheckpointInformation(string,string,string,System.Threading.CancellationToken) 'DiGi\.YOLO\.Query\.YOLOCheckpointInformation\(string, string, string, System\.Threading\.CancellationToken\)'): the epoch it completed, whether it can still be resumed, the dataset and run folder it records, and the raw arguments it was trained with\.

[Epoch](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Epoch 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Epoch') is reported 1-based - the number of epochs completed - although ultralytics stores the 0-based index of the last one. A checkpoint whose run finished, or that ultralytics wrote without optimizer state, reports [Finished](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Finished 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Finished'); a resumed run enters the epoch after [Epoch](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Epoch 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Epoch') and cannot change [Epochs](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Epochs 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Epochs'), the ceiling restored from the checkpoint.

```csharp
public class YOLOCheckpointInformation : DiGi.Core.Classes.SerializableObject, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → YOLOCheckpointInformation

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(DiGi.YOLO.Classes.YOLOCheckpointInformation)'></a>

## YOLOCheckpointInformation\(YOLOCheckpointInformation\) Constructor

Initializes a new instance of the [YOLOCheckpointInformation](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation') class by copying an existing information instance\.

```csharp
public YOLOCheckpointInformation(DiGi.YOLO.Classes.YOLOCheckpointInformation? yOLOCheckpointInformation);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(DiGi.YOLO.Classes.YOLOCheckpointInformation).yOLOCheckpointInformation'></a>

`yOLOCheckpointInformation` [YOLOCheckpointInformation](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation')

The source information instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string)'></a>

## YOLOCheckpointInformation\(Nullable\<double\>, string, Nullable\<int\>, Nullable\<int\>, bool, string, string, string\) Constructor

Initializes a new instance of the [YOLOCheckpointInformation](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation') class with the specified values\.

```csharp
public YOLOCheckpointInformation(System.Nullable<double> bestFitness, string? dataPath, System.Nullable<int> epoch, System.Nullable<int> epochs, bool finished, string? name, string? project, string? trainArguments);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).bestFitness'></a>

`bestFitness` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The best validation fitness the checkpoint records, or `null` when unreadable\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).dataPath'></a>

`dataPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The dataset configuration file path the checkpoint records, or `null` when it records none\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).epoch'></a>

`epoch` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of completed epochs \(1\-based\), or `null` when the checkpoint records no epoch\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).epochs'></a>

`epochs` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The epoch ceiling the checkpoint records, or `null` when it records none\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).finished'></a>

`finished` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the checkpoint cannot be resumed: ultralytics stamped it finished or dropped its optimizer state\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The run directory name the checkpoint records, or `null` when it records none\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).project'></a>

`project` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The run directory parent path the checkpoint records, or `null` when it records none\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Nullable_double_,string,System.Nullable_int_,System.Nullable_int_,bool,string,string,string).trainArguments'></a>

`trainArguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The raw training arguments the checkpoint carries as a JSON object, serialized as text, or `null` when it carries none\.

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOCheckpointInformation\(JsonObject\) Constructor

Initializes a new instance of the [YOLOCheckpointInformation](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation') class using a JSON object\.

```csharp
public YOLOCheckpointInformation(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.YOLOCheckpointInformation(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the checkpoint information\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.BestFitness'></a>

## YOLOCheckpointInformation\.BestFitness Property

Gets the best validation fitness the checkpoint records, or `null` when unreadable\.

```csharp
public System.Nullable<double> BestFitness { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.DataPath'></a>

## YOLOCheckpointInformation\.DataPath Property

Gets the dataset configuration file path the checkpoint records, or `null` when it records none\.

A resume is refused when this file no longer exists.

```csharp
public string? DataPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.Epoch'></a>

## YOLOCheckpointInformation\.Epoch Property

Gets the number of epochs completed \(1\-based\), or `null` when the checkpoint records no epoch\.

A resumed run enters the next epoch and the consumers name it "epoch [Epoch](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Epoch 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Epoch') + 1 of [Epochs](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOCheckpointInformation.Epochs 'DiGi\.YOLO\.Classes\.YOLOCheckpointInformation\.Epochs')".

```csharp
public System.Nullable<int> Epoch { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.Epochs'></a>

## YOLOCheckpointInformation\.Epochs Property

Gets the epoch ceiling the checkpoint records, or `null` when it records none\.

The ceiling is fixed by the checkpoint; a different one is a new run, not a resume.

```csharp
public System.Nullable<int> Epochs { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.Finished'></a>

## YOLOCheckpointInformation\.Finished Property

Gets a value indicating whether the checkpoint cannot be resumed: ultralytics stamped its epoch finished or dropped its optimizer state\.

```csharp
public bool Finished { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.Name'></a>

## YOLOCheckpointInformation\.Name Property

Gets the run directory name the checkpoint records, or `null` when it records none\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.Project'></a>

## YOLOCheckpointInformation\.Project Property

Gets the run directory parent path the checkpoint records, or `null` when it records none\.

A resume whose project lies inside a YOLO\models folder is refused, as a fresh run is.

```csharp
public string? Project { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOCheckpointInformation.TrainArguments'></a>

## YOLOCheckpointInformation\.TrainArguments Property

Gets the raw training arguments the checkpoint carries as a JSON object, or `null` when it carries none or they cannot be read\.

Stored as JSON text so the object survives the serialization of this class; ultralytics restores every one of them on resume, so the runner passes none of them back.

```csharp
public System.Text.Json.Nodes.JsonObject? TrainArguments { get; }
```

#### Property Value
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult'></a>

## YOLOEnvironmentResult Class

Represents the preflight check result of probing the CPython environment and YOLO dependencies on a machine\.

Reports whether the interpreter can run YOLO, its version, installed dependency versions, CUDA availability, model compatibility, and any diagnostic messages explaining why the environment is not runnable. Non-fatal findings, such as a model whose header could not be read, are reported in [Warnings](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Warnings 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Warnings') and do not affect [Runnable](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Runnable').

```csharp
public class YOLOEnvironmentResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOEnvironmentResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_)'></a>

## YOLOEnvironmentResult\(bool, string, string, string, string, Nullable\<bool\>, string, string, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class\.

```csharp
public YOLOEnvironmentResult(bool runnable, string? pythonPath, string? pythonVersion, string? ultralyticsVersion, string? torchVersion, System.Nullable<bool> cudaAvailable, string? modelPath, string? modelUltralyticsVersion, System.Collections.Generic.IEnumerable<string>? messages, System.Collections.Generic.IEnumerable<string>? warnings, System.Nullable<System.DateTimeOffset> checkedTime);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the probed Python interpreter can execute YOLO prediction workloads\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the Python interpreter that was probed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).pythonVersion'></a>

`pythonVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The Python version reported by the interpreter\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).ultralyticsVersion'></a>

`ultralyticsVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The installed version of the ultralytics package, or `null` when import failed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).torchVersion'></a>

`torchVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The installed version of PyTorch, or `null` when import failed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).cudaAvailable'></a>

`cudaAvailable` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

A value indicating whether PyTorch reports CUDA acceleration available\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the model checkpoint probed, or `null` when none was provided\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).modelUltralyticsVersion'></a>

`modelUltralyticsVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ultralytics version recorded inside the model checkpoint, or `null` when unreadable\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostic messages detailing why the environment is not runnable\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).warnings'></a>

`warnings` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostic messages that do not prevent the environment from running, such as a model whose header could not be read\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(bool,string,string,string,string,System.Nullable_bool_,string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_).checkedTime'></a>

`checkedTime` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the preflight probe completed\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult)'></a>

## YOLOEnvironmentResult\(YOLOEnvironmentResult\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class by copying an existing result\.

```csharp
public YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult? yOLOEnvironmentResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(DiGi.YOLO.Classes.YOLOEnvironmentResult).yOLOEnvironmentResult'></a>

`yOLOEnvironmentResult` [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult')

The source result instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOEnvironmentResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOEnvironmentResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult') class using a JSON object\.

```csharp
public YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.YOLOEnvironmentResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Checked'></a>

## YOLOEnvironmentResult\.Checked Property

Gets the moment the preflight probe completed\.

```csharp
public System.Nullable<System.DateTimeOffset> Checked { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.CudaAvailable'></a>

## YOLOEnvironmentResult\.CudaAvailable Property

Gets a value indicating whether PyTorch reports CUDA GPU hardware acceleration available\.

```csharp
public System.Nullable<bool> CudaAvailable { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Messages'></a>

## YOLOEnvironmentResult\.Messages Property

Gets the diagnostic messages detailing why the environment is not runnable\.

Non-fatal findings are reported in [Warnings](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOEnvironmentResult.Warnings 'DiGi\.YOLO\.Classes\.YOLOEnvironmentResult\.Warnings') instead.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.ModelPath'></a>

## YOLOEnvironmentResult\.ModelPath Property

Gets the path of the model checkpoint probed, or `null` when no model path was supplied\.

```csharp
public string? ModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.ModelUltralyticsVersion'></a>

## YOLOEnvironmentResult\.ModelUltralyticsVersion Property

Gets the ultralytics version recorded inside the model checkpoint file, or `null` when unreadable\.

```csharp
public string? ModelUltralyticsVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.PythonPath'></a>

## YOLOEnvironmentResult\.PythonPath Property

Gets the full path of the CPython interpreter that was probed\.

```csharp
public string? PythonPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.PythonVersion'></a>

## YOLOEnvironmentResult\.PythonVersion Property

Gets the Python version string reported by the interpreter\.

```csharp
public string? PythonVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Runnable'></a>

## YOLOEnvironmentResult\.Runnable Property

Gets a value indicating whether the probed Python interpreter can execute YOLO prediction workloads\.

```csharp
public bool Runnable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.TorchVersion'></a>

## YOLOEnvironmentResult\.TorchVersion Property

Gets the installed version of PyTorch, or `null` when import failed\.

```csharp
public string? TorchVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.UltralyticsVersion'></a>

## YOLOEnvironmentResult\.UltralyticsVersion Property

Gets the installed version of the ultralytics package, or `null` when import failed\.

```csharp
public string? UltralyticsVersion { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOEnvironmentResult.Warnings'></a>

## YOLOEnvironmentResult\.Warnings Property

Gets the diagnostic messages that do not prevent the environment from running, such as a model whose header could not be read\.

```csharp
public System.Collections.Generic.List<string>? Warnings { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOModel'></a>

## YOLOModel Class

Represents a YOLO model structure that manages images, labels, and their associated categories and bounding boxes\.

```csharp
public class YOLOModel
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YOLOModel
### Constructors

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel()'></a>

## YOLOModel\(\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class and sets up default directory paths for train, validate, and test categories\.

```csharp
public YOLOModel();
```

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(DiGi.YOLO.Classes.ConfigurationFile)'></a>

## YOLOModel\(ConfigurationFile\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class using the provided configuration file\.

```csharp
public YOLOModel(DiGi.YOLO.Classes.ConfigurationFile? configurationFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(DiGi.YOLO.Classes.ConfigurationFile).configurationFile'></a>

`configurationFile` [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')

The configuration file to initialize the model with\.

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(string)'></a>

## YOLOModel\(string\) Constructor

Initializes a new instance of the [YOLOModel](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOModel 'DiGi\.YOLO\.Classes\.YOLOModel') class with a specified root directory and sets up default category paths\.

```csharp
public YOLOModel(string? directory);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.YOLOModel(string).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base directory path for the model\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOModel.Directory'></a>

## YOLOModel\.Directory Property

Gets or sets the base directory path for the model data\.

```csharp
public string? Directory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOModel.Messages'></a>

## YOLOModel\.Messages Property

Gets the messages collected from the configuration files added to the model, such as a dataset directory that did not exist and was replaced by the directory of the file, or `null` when there were none\.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')
### Methods

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.ConfigurationFile)'></a>

## YOLOModel\.Add\(ConfigurationFile\) Method

Adds the specified configuration file settings to the YOLO model\.

```csharp
public bool Add(DiGi.YOLO.Classes.ConfigurationFile? configurationFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.ConfigurationFile).configurationFile'></a>

`configurationFile` [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')

The configuration file containing directory and label information\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the configuration was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.Label)'></a>

## YOLOModel\.Add\(Label\) Method

Adds a specific [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') object to the model's labels collection\.

```csharp
public bool Add(DiGi.YOLO.Classes.Label? label);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(DiGi.YOLO.Classes.Label).label'></a>

`label` [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')

The label object to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the label was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string)'></a>

## YOLOModel\.Add\(string\) Method

Adds a new label name to the model's labels collection if it does not already exist\.

```csharp
public bool Add(string? labelName);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the label was added; false if the label already exists or is invalid\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile)'></a>

## YOLOModel\.Add\(string, LabelFile\) Method

Adds all labels and bounding boxes contained within a label file to an image at the given path\.

```csharp
public bool Add(string? path, DiGi.YOLO.Classes.LabelFile? labelFile);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Classes.LabelFile).labelFile'></a>

`labelFile` [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')

The label file containing annotation data\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if at least one bounding box was successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[])'></a>

## YOLOModel\.Add\(string, Category\[\]\) Method

Associates an image at the specified path with one or more categories\.

```csharp
public bool Add(string? path, params DiGi.YOLO.Enums.Category[]? categories);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[]).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,DiGi.YOLO.Enums.Category[]).categories'></a>

`categories` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

An array of categories to assign to the image\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the image and categories were successfully added; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox)'></a>

## YOLOModel\.Add\(string, string, BoundingBox\) Method

Adds a bounding box for a specific label to an image at the given path\.

```csharp
public bool Add(string? path, string? labelName, DiGi.YOLO.Classes.BoundingBox? boundingBox);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label associated with the bounding box\.

<a name='DiGi.YOLO.Classes.YOLOModel.Add(string,string,DiGi.YOLO.Classes.BoundingBox).boundingBox'></a>

`boundingBox` [BoundingBox](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.BoundingBox 'DiGi\.YOLO\.Classes\.BoundingBox')

The bounding box coordinates and dimensions\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the bounding box was successfully added to the image; otherwise, false\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories()'></a>

## YOLOModel\.GetCategories\(\) Method

Retrieves a collection of all unique categories currently stored in the model\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category>? GetCategories();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable containing all registered [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') values\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories(string)'></a>

## YOLOModel\.GetCategories\(string\) Method

Retrieves the collection of categories associated with the specified path\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Enums.Category>? GetCategories(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetCategories(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path to look up categories for\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable of [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category') if found; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetConfigurationFile()'></a>

## YOLOModel\.GetConfigurationFile\(\) Method

Creates and returns a [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') instance based on the current model configuration\.

```csharp
public DiGi.YOLO.Classes.ConfigurationFile? GetConfigurationFile();
```

#### Returns
[ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile')  
A [ConfigurationFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.ConfigurationFile 'DiGi\.YOLO\.Classes\.ConfigurationFile') object representing the current settings\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images()'></a>

## YOLOModel\.GetDirectory\_Images\(\) Method

Retrieves the full path to the base images directory\.

```csharp
public string? GetDirectory_Images();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if the base directory is set; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Images\(Category\) Method

Retrieves the full path to the images directory for the specified category using the model's current base directory\.

```csharp
public string? GetDirectory_Images(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category \(e\.g\., Train, Validate, Test\) to locate\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if successful; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Images\(string, Category\) Method

Retrieves the full path to the images directory for a specific category within a provided root directory\.

```csharp
public string? GetDirectory_Images(string? directory, DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The root directory path\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Images(string,DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category \(e\.g\., Train, Validate, Test\) to locate\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string if the root directory is valid; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels()'></a>

## YOLOModel\.GetDirectory\_Labels\(\) Method

Retrieves the full path to the labels directory by deriving it from the images directory path\.

```csharp
public string? GetDirectory_Labels();
```

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The combined path string for labels if successful; otherwise, null\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Labels\(Category\) Method

Retrieves the labels directory path for a specific category using the model's internal directory state\.

```csharp
public string? GetDirectory_Labels(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category associated with the directories\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The calculated path to the labels directory, or `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetDirectory\_Labels\(string, Category\) Method

Retrieves the labels directory path based on a provided image directory and category\.

```csharp
public string? GetDirectory_Labels(string? directory, DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base directory path to evaluate\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetDirectory_Labels(string,DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category associated with the directories\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The calculated path to the labels directory, or `null` if the provided directory is null or whitespace\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetImage(string)'></a>

## YOLOModel\.GetImage\(string\) Method

Retrieves an image object associated with the specified file path\.

```csharp
public DiGi.YOLO.Classes.Image? GetImage(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetImage(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')  
The [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') object if found in the model; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetImages(DiGi.YOLO.Enums.Category)'></a>

## YOLOModel\.GetImages\(Category\) Method

Retrieves all images that belong to a specific category\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Image> GetImages(DiGi.YOLO.Enums.Category category);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetImages(DiGi.YOLO.Enums.Category).category'></a>

`category` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The category used to filter the images\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Image](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Image 'DiGi\.YOLO\.Classes\.Image') objects belonging to the specified category\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabel(int)'></a>

## YOLOModel\.GetLabel\(int\) Method

Retrieves a label based on its unique integer index\.

```csharp
public DiGi.YOLO.Classes.Label? GetLabel(int labelIndex);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabel(int).labelIndex'></a>

`labelIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index of the label to retrieve\.

#### Returns
[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')  
The [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') object if found; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabelFile(string)'></a>

## YOLOModel\.GetLabelFile\(string\) Method

Retrieves the label file associated with the image at the specified path\.

```csharp
public DiGi.YOLO.Classes.LabelFile? GetLabelFile(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabelFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile')  
The [LabelFile](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.LabelFile 'DiGi\.YOLO\.Classes\.LabelFile') object if found; otherwise, `null`\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels()'></a>

## YOLOModel\.GetLabels\(\) Method

Retrieves all labels defined within the model\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label> GetLabels();
```

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of all available [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') objects\.

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels(string)'></a>

## YOLOModel\.GetLabels\(string\) Method

Retrieves all labels associated with the image at the specified path\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.YOLO.Classes.Label>? GetLabels(string? path);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.GetLabels(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path of the image\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An enumerable collection of [Label](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.Label 'DiGi\.YOLO\.Classes\.Label') objects associated with the image, or `null` if no labels are found\.

<a name='DiGi.YOLO.Classes.YOLOModel.LabelIndex(string)'></a>

## YOLOModel\.LabelIndex\(string\) Method

Retrieves the index of a label based on its name\.

```csharp
public int LabelIndex(string? labelName);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOModel.LabelIndex(string).labelName'></a>

`labelName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the label to search for\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The integer index of the label if found; otherwise, \-1\.

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions'></a>

## YOLOPredictionOptions Class

Provides the settings one run of the YOLO prediction script needs: which interpreter runs it, which weights it scores with, which images it reads, and where it writes its results\.

The constructors only assign. Use [YOLOPredictionOptions\(string, string, string, string, string, double, int\)](DiGi.YOLO.md#DiGi.YOLO.Create.YOLOPredictionOptions(string,string,string,string,string,double,int) 'DiGi\.YOLO\.Create\.YOLOPredictionOptions\(string, string, string, string, string, double, int\)') to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.

```csharp
public class YOLOPredictionOptions : DiGi.Core.Classes.SerializableOptions, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → YOLOPredictionOptions

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions()'></a>

## YOLOPredictionOptions\(\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class with default values\.

```csharp
public YOLOPredictionOptions();
```

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions)'></a>

## YOLOPredictionOptions\(YOLOPredictionOptions\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class by copying an existing options instance\.

```csharp
public YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions? yOLOPredictionOptions);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(DiGi.YOLO.Classes.YOLOPredictionOptions).yOLOPredictionOptions'></a>

`yOLOPredictionOptions` [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions')

The source options instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOPredictionOptions\(JsonObject\) Constructor

Initializes a new instance of the [YOLOPredictionOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionOptions 'DiGi\.YOLO\.Classes\.YOLOPredictionOptions') class using a JSON object\.

```csharp
public YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.YOLOPredictionOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration settings\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.BatchSize'></a>

## YOLOPredictionOptions\.BatchSize Property

Gets or sets the number of images passed to the prediction model in a single inference batch, passed to predict\.py as \-\-batch\.

Batching amortizes Python call overhead and GPU kernel launches over multiple images. The default is 32. Turning it down reduces GPU memory usage.

```csharp
public int BatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.Confidence'></a>

## YOLOPredictionOptions\.Confidence Property

Gets or sets the confidence threshold a detection has to reach to be reported, passed to predict\.py as \-\-conf\.

The default matches the script's own default. Lowering it returns more boxes and more false positives; the weights are frozen, so this is the only knob over how much the detector reports.

```csharp
public double Confidence { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.HalfPrecision'></a>

## YOLOPredictionOptions\.HalfPrecision Property

Gets or sets whether the model runs in half precision \(FP16\), passed to predict\.py as \-\-half\.

Off by default. FP16 moves confidences in the last digits, which can drop or add a detection near the confidence threshold and change the first year a building is detected with confidence 0.5 or more, so the detections are not those of a full precision run (DiGi-Organization/DiGi.YOLO#24).

```csharp
public bool HalfPrecision { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.ImageSize'></a>

## YOLOPredictionOptions\.ImageSize Property

Gets or sets the size the images are scaled to for inference, passed to predict\.py as \-\-imgsz\.

Null passes nothing, and ultralytics then uses its default of 640 - the size the shipped weights were trained at, from 320 pixel tiles scaled up twice. Another value shows the model buildings at a scale it was not trained on and changes the detections (DiGi-Organization/DiGi.YOLO#24). A value that is not a positive multiple of 32 is not passed.

```csharp
public System.Nullable<int> ImageSize { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.ModelPath'></a>

## YOLOPredictionOptions\.ModelPath Property

Gets or sets the path of the trained weights file the prediction scores with, passed to predict\.py as \-\-model\.

Left null the script falls back to its own search, which picks whichever training run is newest on disk. Name the file, so a run is reproducible.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.OutputPath'></a>

## YOLOPredictionOptions\.OutputPath Property

Gets or sets the path of the bounding box result file the prediction writes, passed to predict\.py as \-\-output\.

The script opens it for writing rather than appending, so re-running a source directory replaces the previous answer instead of doubling it.

```csharp
public string? OutputPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.PythonPath'></a>

## YOLOPredictionOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter that runs the prediction script, or the name of one on PATH\.

This has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.SourceDirectory'></a>

## YOLOPredictionOptions\.SourceDirectory Property

Gets or sets the directory holding the images to score, passed to predict\.py as \-\-source\.

The script reads the .jpg, .jpeg and .png files directly in the directory and does not descend into it.

```csharp
public string? SourceDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.Workers'></a>

## YOLOPredictionOptions\.Workers Property

Gets or sets the number of threads that decode the next batch of images while the model detects the current one, passed to predict\.py as \-\-workers\.

The default of 2 matches the script's own. Zero lets ultralytics read the files itself, batch after batch, so the GPU waits while the images are decoded. Above zero the images are decoded with the function ultralytics reads files with, so the detections are byte for byte the same; only the time they take changes. On 50 000 images on an RTX 5090, one to three threads ran at 164-168 images/s against 155 with none, and four or more lost the gain to contention for the Python interpreter lock (DiGi-Organization/DiGi.YOLO#24). A negative value is treated as zero.

```csharp
public int Workers { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionOptions.WorkingDirectory'></a>

## YOLOPredictionOptions\.WorkingDirectory Property

Gets or sets the directory the prediction process runs in, which is also where the runner keeps the Python scripts\.

predict.py imports utils.py, and Python resolves that import against the directory the script itself sits in, so the two files have to stay together. The runner puts them there with [WriteScripts\(string\)](DiGi.YOLO.md#DiGi.YOLO.Modify.WriteScripts(string) 'DiGi\.YOLO\.Modify\.WriteScripts\(string\)') on every run, so an older script left there is replaced. Ultralytics also writes its own caches here.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult'></a>

## YOLOPredictionResult Class

Represents what one run of the YOLO prediction script did: how it ended, what it said, and the result lines it produced\.

The detections are kept as the raw lines of the bounding box result file rather than as parsed objects, so that a result read back from JSON is the same result that was written. Parse them with [BoundingBoxResultFile\(this YOLOPredictionResult\)](DiGi.YOLO.md#DiGi.YOLO.Create.BoundingBoxResultFile(thisDiGi.YOLO.Classes.YOLOPredictionResult) 'DiGi\.YOLO\.Create\.BoundingBoxResultFile\(this DiGi\.YOLO\.Classes\.YOLOPredictionResult\)').

```csharp
public class YOLOPredictionResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOPredictionResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult)'></a>

## YOLOPredictionResult\(YOLOPredictionResult\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class by copying an existing result\.

```csharp
public YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult? yOLOPredictionResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(DiGi.YOLO.Classes.YOLOPredictionResult).yOLOPredictionResult'></a>

`yOLOPredictionResult` [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult')

The source result to copy from\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_)'></a>

## YOLOPredictionResult\(int, int, string, IEnumerable\<string\>, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class\.

```csharp
public YOLOPredictionResult(int exitCode, int imageCount, string? outputPath, System.Collections.Generic.IEnumerable<string>? values, System.Collections.Generic.IEnumerable<string>? standardOutput, System.Collections.Generic.IEnumerable<string>? standardError, System.Nullable<System.DateTimeOffset> start, System.Nullable<System.DateTimeOffset> end);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The code the prediction process ended with, or \-1 when the runner never got one\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).imageCount'></a>

`imageCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of images found in the source directory\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the bounding box result file the run was told to write\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).values'></a>

`values` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The lines of the bounding box result file the run produced\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The trailing lines the process wrote to its standard output stream\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardError'></a>

`standardError` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The trailing lines the process wrote to its standard error stream\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).start'></a>

`start` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the run began\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(int,int,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).end'></a>

`end` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the run ended\.

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOPredictionResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOPredictionResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult 'DiGi\.YOLO\.Classes\.YOLOPredictionResult') class using a JSON object\.

```csharp
public YOLOPredictionResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.YOLOPredictionResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Duration'></a>

## YOLOPredictionResult\.Duration Property

Gets how long the run took, or `null` when either end of it is unknown\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.End'></a>

## YOLOPredictionResult\.End Property

Gets the moment the run ended\.

```csharp
public System.Nullable<System.DateTimeOffset> End { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.ExitCode'></a>

## YOLOPredictionResult\.ExitCode Property

Gets the code the prediction process ended with\. Zero means it ran to completion\.

-1 is the runner's own code for a run it never handed to the interpreter or took back from it - the process could not be started, the source directory was gone, or the run was cancelled. [StandardError](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOPredictionResult.StandardError 'DiGi\.YOLO\.Classes\.YOLOPredictionResult\.StandardError') carries the reason in the first two cases; a caller that cancelled already knows about the third.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.ImageCount'></a>

## YOLOPredictionResult\.ImageCount Property

Gets the number of images found in the source directory\.

Zero here with an exit code of zero is a run that had nothing to do, which is worth telling apart from a run that scored images and found nothing on them.

```csharp
public int ImageCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.OutputPath'></a>

## YOLOPredictionResult\.OutputPath Property

Gets the path of the bounding box result file the run was told to write\.

```csharp
public string? OutputPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.StandardError'></a>

## YOLOPredictionResult\.StandardError Property

Gets the trailing lines the process wrote to its standard error stream, at most [OutputLines](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Count.OutputLines 'DiGi\.YOLO\.Constants\.Count\.OutputLines') of them\.

```csharp
public System.Collections.Generic.List<string>? StandardError { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.StandardOutput'></a>

## YOLOPredictionResult\.StandardOutput Property

Gets the trailing lines the process wrote to its standard output stream, at most [OutputLines](DiGi.YOLO.Constants.md#DiGi.YOLO.Constants.Count.OutputLines 'DiGi\.YOLO\.Constants\.Count\.OutputLines') of them\.

```csharp
public System.Collections.Generic.List<string>? StandardOutput { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Start'></a>

## YOLOPredictionResult\.Start Property

Gets the moment the run began\.

```csharp
public System.Nullable<System.DateTimeOffset> Start { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Succeeded'></a>

## YOLOPredictionResult\.Succeeded Property

Gets a value indicating whether the run completed and produced its result file\.

```csharp
public bool Succeeded { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOPredictionResult.Values'></a>

## YOLOPredictionResult\.Values Property

Gets the lines of the bounding box result file the run produced, or `null` when it produced none\.

An empty list is a run that scored images and detected nothing; `null` is a run that wrote no file at all.

```csharp
public System.Collections.Generic.List<string>? Values { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions'></a>

## YOLOTrainingOptions Class

Provides the settings one run of the YOLO training script needs: which interpreter runs it, which start weights and dataset it trains from, the training hyperparameters, and where the run directory is created\.

The constructors only assign. Use [YOLOTrainingOptions\(string, string, string, string\)](DiGi.YOLO.md#DiGi.YOLO.Create.YOLOTrainingOptions(string,string,string,string) 'DiGi\.YOLO\.Create\.YOLOTrainingOptions\(string, string, string, string\)') to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.

```csharp
public class YOLOTrainingOptions : DiGi.Core.Classes.SerializableOptions, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → YOLOTrainingOptions

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.YOLOTrainingOptions()'></a>

## YOLOTrainingOptions\(\) Constructor

Initializes a new instance of the [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions') class with default values\.

```csharp
public YOLOTrainingOptions();
```

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.YOLOTrainingOptions(DiGi.YOLO.Classes.YOLOTrainingOptions)'></a>

## YOLOTrainingOptions\(YOLOTrainingOptions\) Constructor

Initializes a new instance of the [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions') class by copying an existing options instance\.

```csharp
public YOLOTrainingOptions(DiGi.YOLO.Classes.YOLOTrainingOptions? yOLOTrainingOptions);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.YOLOTrainingOptions(DiGi.YOLO.Classes.YOLOTrainingOptions).yOLOTrainingOptions'></a>

`yOLOTrainingOptions` [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions')

The source options instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.YOLOTrainingOptions(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOTrainingOptions\(JsonObject\) Constructor

Initializes a new instance of the [YOLOTrainingOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions') class using a JSON object\.

```csharp
public YOLOTrainingOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.YOLOTrainingOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration settings\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Amp'></a>

## YOLOTrainingOptions\.Amp Property

Gets or sets whether automatic mixed precision is requested, passed to train\.py as \-\-amp or \-\-no\-amp\.

The default is on. ultralytics checks AMP before training by downloading yolo26n.pt into the "weights" folder of the working directory; when that fails - offline - it silently trains in full precision. [Amp](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult.Amp 'DiGi\.YOLO\.Classes\.YOLOTrainingResult\.Amp') reports what was actually used.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores it from the checkpoint.

```csharp
public bool Amp { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Batch'></a>

## YOLOTrainingOptions\.Batch Property

Gets or sets the training batch size, passed to train\.py as \-\-batch\. The default is 16, the batch train8 used\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores it from the checkpoint (ultralytics accepts a different batch on resume, but this runner does not send one).

```csharp
public int Batch { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.ConfigurationFilePath'></a>

## YOLOTrainingOptions\.ConfigurationFilePath Property

Gets or sets the absolute path of the dataset configuration file \(conf\.yaml\), passed to train\.py as \-\-data\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume takes the dataset from the checkpoint and is refused when that file no longer exists.

```csharp
public string? ConfigurationFilePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Device'></a>

## YOLOTrainingOptions\.Device Property

Gets or sets the device to train on, such as "0", "0,1" or "cpu", passed to train\.py as \-\-device\. Null lets ultralytics choose\.

```csharp
public string? Device { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Epochs'></a>

## YOLOTrainingOptions\.Epochs Property

Gets or sets the upper bound of training epochs, passed to train\.py as \-\-epochs\. With [Patience](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Patience 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Patience') the run stops earlier when validation stops improving\. The default is 150\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores the ceiling from the checkpoint, and a different ceiling is a new run, not a resume.

```csharp
public int Epochs { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.ImageSize'></a>

## YOLOTrainingOptions\.ImageSize Property

Gets or sets the square training image size, passed to train\.py as \-\-imgsz\. The default is 640, the size inference and the ONNX export use\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores it from the checkpoint (ultralytics accepts a different imgsz on resume, but this runner does not send one).

```csharp
public int ImageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.InactivityTimeout'></a>

## YOLOTrainingOptions\.InactivityTimeout Property

Gets or sets the span without a line on either output stream after which the training process is ended, or `null` for no limit\. The default is 15 minutes\.

A training that deadlocks - its torch data loader workers and its main process each waiting on a message the other never sent - produces no output for hours while holding the GPU. A piped run, measured on train9_continue (ultralytics 8.4.165, 165 041 images, ~30 min epochs): the progress bar writes one carriage-return-terminated update per batch (~6 per second), each of which arrives as a line, during epochs, during validation, at the epoch-end save and while the dataset label cache is built; the longest silent stretch of a healthy run is the interpreter and torch import before the first banner line, well under a minute. When the limit is reached the interpreter and its worker processes are ended together and the run is reported through [Stalled](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult.Stalled 'DiGi\.YOLO\.Classes\.YOLOTrainingResult\.Stalled'). A value that is not positive disables the limit.

Unlike the hyperparameters this is a property of the runner rather than of the training, so it also applies to a resumed run.

```csharp
public System.Nullable<System.TimeSpan> InactivityTimeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.ModelPath'></a>

## YOLOTrainingOptions\.ModelPath Property

Gets or sets the absolute path of the start weights, passed to train\.py as \-\-model: a checkpoint \(\.pt\) \- model\.pt to continue train8, or a base checkpoint such as yolo26x\.pt \- or an architecture definition \(\.yaml\) for random initialisation\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume continues the checkpoint named there and passes no --model.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Name'></a>

## YOLOTrainingOptions\.Name Property

Gets or sets the name of the run directory, passed to train\.py as \-\-name, such as "train9\_fresh"\. Null uses the ultralytics default \("train", numbered when taken\)\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores the run directory from the checkpoint and writes into the same folder.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Patience'></a>

## YOLOTrainingOptions\.Patience Property

Gets or sets the number of epochs without validation improvement after which training stops, passed to train\.py as \-\-patience\. The default is 50\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores the patience counter from the checkpoint (ultralytics accepts a different patience on resume, but this runner does not send one).

```csharp
public int Patience { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Project'></a>

## YOLOTrainingOptions\.Project Property

Gets or sets the absolute path of the directory the run directory is created in, passed to train\.py as \-\-project\.

Always passed explicitly: an interpreter from a virtual environment can resolve the ultralytics default runs directory against the repository its package sits in rather than against the working directory.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores the run directory from the checkpoint and writes into the same folder.

```csharp
public string? Project { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.PythonPath'></a>

## YOLOTrainingOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter that runs the script\.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath'></a>

## YOLOTrainingOptions\.ResumePath Property

Gets or sets the path of a checkpoint \(a run's weights\\last\.pt\) to resume instead of training from [ModelPath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ModelPath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ModelPath'), passed to train\.py as \-\-resume\.

When set, the run continues the interrupted training at the next epoch, and [ModelPath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ModelPath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ModelPath'), [ConfigurationFilePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ConfigurationFilePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ConfigurationFilePath'), [Epochs](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Epochs 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Epochs'), [Patience](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Patience 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Patience'), [ImageSize](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ImageSize 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ImageSize'), [Batch](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Batch 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Batch'), [Seed](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Seed 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Seed'), [Project](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Project 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Project'), [Name](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Name 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Name') and [Amp](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Amp 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Amp') are not sent - ultralytics restores every one of them from the checkpoint. Only [Device](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.Device 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.Device'), alongside [PythonPath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.PythonPath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.PythonPath') and [WorkingDirectory](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.WorkingDirectory 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.WorkingDirectory'), still applies. The epoch ceiling is fixed by the checkpoint.

```csharp
public string? ResumePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.Seed'></a>

## YOLOTrainingOptions\.Seed Property

Gets or sets the random seed, passed to train\.py as \-\-seed\. The default is 0, the seed train8 used; both candidates of a comparison use the same one\.

Ignored when [ResumePath](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.ResumePath 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.ResumePath') is set: a resume restores it from the checkpoint.

```csharp
public int Seed { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingOptions.WorkingDirectory'></a>

## YOLOTrainingOptions\.WorkingDirectory Property

Gets or sets the directory the process runs in and the scripts are kept in\.

train.py imports utils.py, and Python resolves that import against the directory the script itself sits in, so the two files have to stay together. The ultralytics settings of the run are isolated in its .yolo-config folder.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult'></a>

## YOLOTrainingResult Class

Describes how one run of the YOLO training script went: its exit code and output, the identity of the weights it started from and of the weights it wrote, and when it ran\.

The start weights are identified by the runner itself, before the process starts, rather than read back from the script's output: the output keeps only its tail, which a long run fills with training progress. The written weights are read from the success block train.py prints last and checked against the file on disk.

```csharp
public class YOLOTrainingResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOTrainingResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(DiGi.YOLO.Classes.YOLOTrainingResult)'></a>

## YOLOTrainingResult\(YOLOTrainingResult\) Constructor

Initializes a new instance of the [YOLOTrainingResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult 'DiGi\.YOLO\.Classes\.YOLOTrainingResult') class by copying an existing result\.

```csharp
public YOLOTrainingResult(DiGi.YOLO.Classes.YOLOTrainingResult? yOLOTrainingResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(DiGi.YOLO.Classes.YOLOTrainingResult).yOLOTrainingResult'></a>

`yOLOTrainingResult` [YOLOTrainingResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult 'DiGi\.YOLO\.Classes\.YOLOTrainingResult')

The source result to copy from\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool)'></a>

## YOLOTrainingResult\(int, string, string, ModelKind, string, Nullable\<long\>, string, Nullable\<bool\>, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>, bool, Nullable\<int\>, bool\) Constructor

Initializes a new instance of the [YOLOTrainingResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult 'DiGi\.YOLO\.Classes\.YOLOTrainingResult') class with the specified values\.

```csharp
public YOLOTrainingResult(int exitCode, string? startModelPath, string? startModelSHA256, DiGi.YOLO.Enums.ModelKind startModelKind, string? weightsPath, System.Nullable<long> bytes, string? sHA256, System.Nullable<bool> amp, System.Collections.Generic.IEnumerable<string>? standardOutput, System.Collections.Generic.IEnumerable<string>? standardError, System.Nullable<System.DateTimeOffset> start, System.Nullable<System.DateTimeOffset> end, bool resumed=false, System.Nullable<int> resumedFromEpoch=null, bool stalled=false);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of the interpreter; \-1 when it could not be started, was cancelled, or the runner refused the run\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).startModelPath'></a>

`startModelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The absolute path of the start weights\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).startModelSHA256'></a>

`startModelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The lowercase hexadecimal SHA\-256 digest of the start weights\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).startModelKind'></a>

`startModelKind` [ModelKind](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.ModelKind 'DiGi\.YOLO\.Enums\.ModelKind')

Whether the start weights are a checkpoint or an architecture definition\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).weightsPath'></a>

`weightsPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The absolute path of the best weights the run wrote\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).bytes'></a>

`bytes` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The size of the best weights in bytes\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).sHA256'></a>

`sHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The lowercase hexadecimal SHA\-256 digest of the best weights\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).amp'></a>

`amp` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The automatic mixed precision the run actually used\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tail of the lines the script wrote to standard output\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).standardError'></a>

`standardError` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tail of the lines the script wrote to standard error, followed by any message of the runner\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).start'></a>

`start` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run started\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).end'></a>

`end` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run ended\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).resumed'></a>

`resumed` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the run continued an interrupted training instead of starting from the beginning\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).resumedFromEpoch'></a>

`resumedFromEpoch` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The 1\-based epoch the resumed run entered, restored from the checkpoint; `null` for a run that was not resumed or whose resume line was not read\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(int,string,string,DiGi.YOLO.Enums.ModelKind,string,System.Nullable_long_,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_,bool,System.Nullable_int_,bool).stalled'></a>

`stalled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the runner ended the process because neither output stream produced a line within the inactivity limit\.

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOTrainingResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOTrainingResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingResult 'DiGi\.YOLO\.Classes\.YOLOTrainingResult') class using a JSON object\.

```csharp
public YOLOTrainingResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.YOLOTrainingResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Amp'></a>

## YOLOTrainingResult\.Amp Property

Gets the automatic mixed precision the run actually used, or `null` when the script did not report it\. False although AMP was requested means the AMP check failed, typically offline\.

```csharp
public System.Nullable<bool> Amp { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Bytes'></a>

## YOLOTrainingResult\.Bytes Property

Gets the size of the best weights in bytes, or `null` when the run wrote none\.

```csharp
public System.Nullable<long> Bytes { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Duration'></a>

## YOLOTrainingResult\.Duration Property

Gets how long the run took, or `null` when either end of it is unknown\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.End'></a>

## YOLOTrainingResult\.End Property

Gets when the run ended\.

```csharp
public System.Nullable<System.DateTimeOffset> End { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.ExitCode'></a>

## YOLOTrainingResult\.ExitCode Property

Gets the exit code of the interpreter; \-1 when it could not be started, was cancelled, or the runner refused the run\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Resumed'></a>

## YOLOTrainingResult\.Resumed Property

Gets a value indicating whether the run continued an interrupted training instead of starting from the beginning\.

True whenever the runner was given a resume checkpoint, including a run that then failed; a resume is not bit-identical to an uninterrupted run, because the data loader's random state restarts.

```csharp
public bool Resumed { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.ResumedFromEpoch'></a>

## YOLOTrainingResult\.ResumedFromEpoch Property

Gets the 1\-based epoch the resumed run entered, or `null` for a run that was not resumed or whose resume line could not be read\.

The epoch after the last completed one the checkpoint records: a checkpoint with one completed epoch resumed into epoch 2.

```csharp
public System.Nullable<int> ResumedFromEpoch { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.SHA256'></a>

## YOLOTrainingResult\.SHA256 Property

Gets the lowercase hexadecimal SHA\-256 digest of the best weights, or `null` when the run wrote none or the digest the script printed does not match the file\.

```csharp
public string? SHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Stalled'></a>

## YOLOTrainingResult\.Stalled Property

Gets a value indicating whether the runner ended the process because neither output stream produced a line within [InactivityTimeout](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOTrainingOptions.InactivityTimeout 'DiGi\.YOLO\.Classes\.YOLOTrainingOptions\.InactivityTimeout'), instead of the run finishing by itself\.

A stalled run is a failure like any other: a non-zero exit code and no confirmed weights. The interpreter and its worker processes are ended together, and the standard-error tail names the limit and the last output time. Resuming such a run automatically is the task of the runner above this library, not of the training itself.

```csharp
public bool Stalled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.StandardError'></a>

## YOLOTrainingResult\.StandardError Property

Gets the tail of the lines the script wrote to standard error, followed by any message of the runner\.

```csharp
public System.Collections.Generic.List<string>? StandardError { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.StandardOutput'></a>

## YOLOTrainingResult\.StandardOutput Property

Gets the tail of the lines the script wrote to standard output\.

```csharp
public System.Collections.Generic.List<string>? StandardOutput { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Start'></a>

## YOLOTrainingResult\.Start Property

Gets when the run started\.

```csharp
public System.Nullable<System.DateTimeOffset> Start { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.StartModelKind'></a>

## YOLOTrainingResult\.StartModelKind Property

Gets whether the start weights were a checkpoint or an architecture definition\.

```csharp
public DiGi.YOLO.Enums.ModelKind StartModelKind { get; }
```

#### Property Value
[ModelKind](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.ModelKind 'DiGi\.YOLO\.Enums\.ModelKind')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.StartModelPath'></a>

## YOLOTrainingResult\.StartModelPath Property

Gets the absolute path of the start weights\.

```csharp
public string? StartModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.StartModelSHA256'></a>

## YOLOTrainingResult\.StartModelSHA256 Property

Gets the lowercase hexadecimal SHA\-256 digest of the start weights \- what a provenance table records as "started from"\.

```csharp
public string? StartModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.Succeeded'></a>

## YOLOTrainingResult\.Succeeded Property

Gets whether the run completed and wrote weights whose identity was confirmed: a zero exit code, a weights path and a digest that matches the file\.

```csharp
public bool Succeeded { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.YOLO.Classes.YOLOTrainingResult.WeightsPath'></a>

## YOLOTrainingResult\.WeightsPath Property

Gets the absolute path of the best weights the run wrote, or `null` when it wrote none\.

```csharp
public string? WeightsPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions'></a>

## YOLOValidationOptions Class

Provides the settings one run of the YOLO validation script needs: which interpreter runs it, which weights it validates, and on which split of which dataset\.

The constructors only assign. Use [YOLOValidationOptions\(string, string, string, string\)](DiGi.YOLO.md#DiGi.YOLO.Create.YOLOValidationOptions(string,string,string,string) 'DiGi\.YOLO\.Create\.YOLOValidationOptions\(string, string, string, string\)') to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.

```csharp
public class YOLOValidationOptions : DiGi.Core.Classes.SerializableOptions, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → YOLOValidationOptions

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.YOLOValidationOptions()'></a>

## YOLOValidationOptions\(\) Constructor

Initializes a new instance of the [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions') class with default values\.

```csharp
public YOLOValidationOptions();
```

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.YOLOValidationOptions(DiGi.YOLO.Classes.YOLOValidationOptions)'></a>

## YOLOValidationOptions\(YOLOValidationOptions\) Constructor

Initializes a new instance of the [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions') class by copying an existing options instance\.

```csharp
public YOLOValidationOptions(DiGi.YOLO.Classes.YOLOValidationOptions? yOLOValidationOptions);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.YOLOValidationOptions(DiGi.YOLO.Classes.YOLOValidationOptions).yOLOValidationOptions'></a>

`yOLOValidationOptions` [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions')

The source options instance to copy from\.

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.YOLOValidationOptions(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOValidationOptions\(JsonObject\) Constructor

Initializes a new instance of the [YOLOValidationOptions](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationOptions 'DiGi\.YOLO\.Classes\.YOLOValidationOptions') class using a JSON object\.

```csharp
public YOLOValidationOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.YOLOValidationOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the configuration settings\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.Batch'></a>

## YOLOValidationOptions\.Batch Property

Gets or sets the validation batch size, passed to val\.py as \-\-batch\. The default is 16\.

```csharp
public int Batch { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.Confidence'></a>

## YOLOValidationOptions\.Confidence Property

Gets or sets the confidence threshold, passed to val\.py as \-\-conf\. Null uses the ultralytics validation default, which is what mAP is normally reported at\.

```csharp
public System.Nullable<double> Confidence { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.ConfigurationFilePath'></a>

## YOLOValidationOptions\.ConfigurationFilePath Property

Gets or sets the absolute path of the dataset configuration file \(conf\.yaml\), passed to val\.py as \-\-data\.

```csharp
public string? ConfigurationFilePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.Device'></a>

## YOLOValidationOptions\.Device Property

Gets or sets the device to validate on, such as "0" or "cpu", passed to val\.py as \-\-device\. Null lets ultralytics choose\.

```csharp
public string? Device { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.ImageSize'></a>

## YOLOValidationOptions\.ImageSize Property

Gets or sets the square validation image size, passed to val\.py as \-\-imgsz\. The default is 640\.

```csharp
public int ImageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.ModelPath'></a>

## YOLOValidationOptions\.ModelPath Property

Gets or sets the absolute path of the weights file to validate, passed to val\.py as \-\-model\.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.PythonPath'></a>

## YOLOValidationOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter that runs the script\.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.Split'></a>

## YOLOValidationOptions\.Split Property

Gets or sets the dataset split to validate on, passed to val\.py as \-\-split\. [Test](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category.Test 'DiGi\.YOLO\.Enums\.Category\.Test') by default; [Train](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category.Train 'DiGi\.YOLO\.Enums\.Category\.Train') is not a validation split and is rejected by the factory\.

```csharp
public DiGi.YOLO.Enums.Category Split { get; set; }
```

#### Property Value
[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

<a name='DiGi.YOLO.Classes.YOLOValidationOptions.WorkingDirectory'></a>

## YOLOValidationOptions\.WorkingDirectory Property

Gets or sets the directory the process runs in and the scripts are kept in\. The ultralytics settings of the run are isolated in its \.yolo\-config folder\.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationResult'></a>

## YOLOValidationResult Class

Describes how one run of the YOLO validation script went: its exit code and output, the weights and split it validated, the box mAP it measured, and when it ran\.

```csharp
public class YOLOValidationResult : DiGi.Core.Classes.SerializableResult, DiGi.YOLO.Interfaces.IYOLOSerializableObject, DiGi.YOLO.Interfaces.IYOLOObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YOLOValidationResult

Implements [IYOLOSerializableObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOSerializableObject 'DiGi\.YOLO\.Interfaces\.IYOLOSerializableObject'), [IYOLOObject](DiGi.YOLO.Interfaces.md#DiGi.YOLO.Interfaces.IYOLOObject 'DiGi\.YOLO\.Interfaces\.IYOLOObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(DiGi.YOLO.Classes.YOLOValidationResult)'></a>

## YOLOValidationResult\(YOLOValidationResult\) Constructor

Initializes a new instance of the [YOLOValidationResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationResult 'DiGi\.YOLO\.Classes\.YOLOValidationResult') class by copying an existing result\.

```csharp
public YOLOValidationResult(DiGi.YOLO.Classes.YOLOValidationResult? yOLOValidationResult);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(DiGi.YOLO.Classes.YOLOValidationResult).yOLOValidationResult'></a>

`yOLOValidationResult` [YOLOValidationResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationResult 'DiGi\.YOLO\.Classes\.YOLOValidationResult')

The source result to copy from\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_)'></a>

## YOLOValidationResult\(int, string, string, Category, Nullable\<double\>, Nullable\<double\>, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>, Nullable\<DateTimeOffset\>\) Constructor

Initializes a new instance of the [YOLOValidationResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationResult 'DiGi\.YOLO\.Classes\.YOLOValidationResult') class with the specified values\.

```csharp
public YOLOValidationResult(int exitCode, string? modelPath, string? modelSHA256, DiGi.YOLO.Enums.Category split, System.Nullable<double> mAP50, System.Nullable<double> mAP50_95, System.Collections.Generic.IEnumerable<string>? standardOutput, System.Collections.Generic.IEnumerable<string>? standardError, System.Nullable<System.DateTimeOffset> start, System.Nullable<System.DateTimeOffset> end);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of the interpreter; \-1 when it could not be started, was cancelled, or the runner refused the run\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The absolute path of the validated weights\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The lowercase hexadecimal SHA\-256 digest of the validated weights\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).split'></a>

`split` [Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

The dataset split validated on\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).mAP50'></a>

`mAP50` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The box mAP at IoU 0\.5\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).mAP50_95'></a>

`mAP50_95` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The box mAP averaged over IoU 0\.5 to 0\.95\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardOutput'></a>

`standardOutput` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tail of the lines the script wrote to standard output\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).standardError'></a>

`standardError` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The tail of the lines the script wrote to standard error, followed by any message of the runner\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).start'></a>

`start` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run started\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(int,string,string,DiGi.YOLO.Enums.Category,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,System.Nullable_System.DateTimeOffset_).end'></a>

`end` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

When the run ended\.

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(System.Text.Json.Nodes.JsonObject)'></a>

## YOLOValidationResult\(JsonObject\) Constructor

Initializes a new instance of the [YOLOValidationResult](DiGi.YOLO.Classes.md#DiGi.YOLO.Classes.YOLOValidationResult 'DiGi\.YOLO\.Classes\.YOLOValidationResult') class using a JSON object\.

```csharp
public YOLOValidationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.YOLO.Classes.YOLOValidationResult.YOLOValidationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result\.
### Properties

<a name='DiGi.YOLO.Classes.YOLOValidationResult.Duration'></a>

## YOLOValidationResult\.Duration Property

Gets how long the run took, or `null` when either end of it is unknown\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.End'></a>

## YOLOValidationResult\.End Property

Gets when the run ended\.

```csharp
public System.Nullable<System.DateTimeOffset> End { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.ExitCode'></a>

## YOLOValidationResult\.ExitCode Property

Gets the exit code of the interpreter; \-1 when it could not be started, was cancelled, or the runner refused the run\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.MAP50'></a>

## YOLOValidationResult\.MAP50 Property

Gets the box mAP at IoU 0\.5, or `null` when the script did not report it\.

```csharp
public System.Nullable<double> MAP50 { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.MAP50_95'></a>

## YOLOValidationResult\.MAP50\_95 Property

Gets the box mAP averaged over IoU 0\.5 to 0\.95, or `null` when the script did not report it\.

```csharp
public System.Nullable<double> MAP50_95 { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.ModelPath'></a>

## YOLOValidationResult\.ModelPath Property

Gets the absolute path of the validated weights\.

```csharp
public string? ModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.ModelSHA256'></a>

## YOLOValidationResult\.ModelSHA256 Property

Gets the lowercase hexadecimal SHA\-256 digest of the validated weights, so a gate table can name exactly which file each row measured\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.Split'></a>

## YOLOValidationResult\.Split Property

Gets the dataset split validated on\.

```csharp
public DiGi.YOLO.Enums.Category Split { get; }
```

#### Property Value
[Category](DiGi.YOLO.Enums.md#DiGi.YOLO.Enums.Category 'DiGi\.YOLO\.Enums\.Category')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.StandardError'></a>

## YOLOValidationResult\.StandardError Property

Gets the tail of the lines the script wrote to standard error, followed by any message of the runner\.

```csharp
public System.Collections.Generic.List<string>? StandardError { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.StandardOutput'></a>

## YOLOValidationResult\.StandardOutput Property

Gets the tail of the lines the script wrote to standard output\.

```csharp
public System.Collections.Generic.List<string>? StandardOutput { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.Start'></a>

## YOLOValidationResult\.Start Property

Gets when the run started\.

```csharp
public System.Nullable<System.DateTimeOffset> Start { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.YOLO.Classes.YOLOValidationResult.Succeeded'></a>

## YOLOValidationResult\.Succeeded Property

Gets whether the run completed and reported both mAP values\.

```csharp
public bool Succeeded { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')