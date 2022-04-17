# [BlurHash](http://blurha.sh)

BlurHash is a compact representation of a placeholder for an image.

## Why would you want this?

Does your designer cry every time you load their beautifully designed screen, and it is full of empty boxes because all the
images have not loaded yet? Does your database engineer cry when you want to solve this by trying to cram little thumbnail
images into your data to show as placeholders?

BlurHash will solve your problems! How? Like this:

<img src="https://github.com/woltapp/blurhash/blob/master/Media/WhyBlurHash.png" width="600">

You can also see nice examples and try it out yourself at [blurha.sh](http://blurha.sh/)!

## How does it work?

In short, BlurHash takes an image, and gives you a short string (only 20-30 characters!) that represents the placeholder for this
image. You do this on the backend of your service, and store the string along with the image. When you send data to your
client, you send both the URL to the image, and the BlurHash string. Your client then takes the string, and decodes it into an
image that it shows while the real image is loading over the network. The string is short enough that it comfortably fits into
whatever data format you use. For instance, it can easily be added as a field in a JSON object.

In summary:

<img src="https://github.com/woltapp/blurhash/blob/master/Media/HowItWorks1.jpg" width="250">&nbsp;&nbsp;&nbsp;<img src="https://github.com/woltapp/blurhash/blob/master/Media/HowItWorks2.jpg" width="250">

## More Information
More information can be found in the [base repository](https://github.com/woltapp/blurhash).
Go there if you want to see the details on how BlurHash works or how to contribute your own port.

## Usage

### Using a supported image manipulation library

1) Install the NuGet-Package for your image manipulation library
   - Install `Blurhash.System.Drawing.Common` if you're using the `System.Drawing.Common`-NuGet package.
   - Install `Blurhash.ImageSharp` if you're using `SixLabors.ImageSharp`
   - Install `Blurhash.Core` if you want to manually convert your image type for the algorithm (see below)

1) Call `Blurhasher.Encode` or `Blurhasher.Decode`

### Using a Blurhash.NET with the IServiceCollection

1) Install the NuGet-Package for your image manipulation library
   - Install `Blurhash.Microsoft.Extensions.System.Drawing` if you're using the `System.Drawing.Common`-NuGet package.
   - Install `Blurhash.Microsoft.Extensions.ImageSharp` if you're using the `SixLabors.ImageSharp`
   - Install `Blurhash.Microsoft.Extensions.Core` if you want to manually convert your image type for the algorithm  (see below) 

### Using an unsupported image manipulation library
Install the NuGet-Package `Blurhash.Core` (add `Blurhash.Microsoft.Extensions.Core` if you want to use dependency injection)

#### Encoding an image to a Blurhash string

1) Write a method to convert an image from your library to a two-dimensional array of `Blurhash.Pixel` where the first dimension is the X-Axis and the second dimension is the Y-Axis
2) Call `Blurhash.Core.Encode` with your array
3) Encapsulate this in a static `Encode` method in a Library specific `Blurhasher` class and share your implementation by creating a PullRequest

#### Decoding a Blurhash string into an image

1) Write a method to convert a two-dimensional array of `Blurhash.Pixel` to an image your library supports
2) Create a two-dimensional `Pixel` array where the first dimension is the desired witdh of the image and the second dimension is the desired height of the image
3) Call `Blurhash.Core.Decode` with this array and the input string.
4) Call your converter-method with the `Pixel` array filled by `Blurhash.Core.Decode`
3) Encapsulate this in a static `Decode` method in a Library specific `Blurhasher` class and share your implementation by creating a PullRequest

#### Sharing your code 

Think about sharing your implementation, so others can use it too. \
Calling it `Blurhash.<Name of your image manipulation library>` would help others to quickly find it on NuGet.org.

## Versioning

Blurhash.NET uses Semantic Versioning (as explained https://semver.org)

## Projects in this solution
This list does not contain the projects with names ending in `.Test` as they are the test projects for the ones listed here.

- `Blurhash.Core`\
  The core algorithm of blurhash. For maximum compatibility this is a .NET-Standard project.
- `Blurhash.System.Drawing.Common`\
  Bridge-Library to use Blurhash with the System.Drawing.Common NuGet-Library in DotNetStandard
- `Blurhash.ImageSharp`\
  Bridge-Library to use Blurhash with ImageSharp
- `Blurhash.Microsoft.Extensions.*`\
  The respective libraries that enable usage of the blurhash algorithm with an `IServiceCollection`
- `Benchmarks`\
  Used for benchmarking implementations during optimization runs
