# QRCodeGenerator-Xamarin.Forms

## Info
This is a simple QR Code Generator using [**codebude**](https://github.com/codebude)'s [**QRCoder**](https://github.com/codebude/QRCoder) library in Xamarin.Forms. This is meant to be used as a guide as I have seen countless examples that use the ZXING library to create QR codes and I wanted to show an even easier way to do that.

## Screenshots
![Screenshot1](https://i.imgur.com/LcJ9dec.png)  ![Screenshot1](https://i.imgur.com/sbtx4cV.png)

## Installation
See [**QRCoder**](https://github.com/codebude/QRCoder)'s readme. Also check the [**wiki**](https://github.com/codebude/QRCoder) page for advanced usage.

## Usage
You only need these few lines of code to generate your own QR code in Xamarin.Forms
```csharp
QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, SelectedECCLevel);
PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
byte[] qrCodeBytes = qRCode.GetGraphic(20);
QrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
```

I have tested the other renderers aside from PngByteQRCode but only this along with BitmapByteQRCode and AsciiQRCode work.
