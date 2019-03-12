ActiveButtons is a .Net library which allows developers to very quickly and easily add additional buttons to the Windows title bar along-side the standard maximise, minimise and close buttons.

## Example
```csharp
IActiveMenu menu = ActiveMenu.GetInstance(form);

var button = menu.Items.CreateItem();
button.Text = "One";
button.Click += button_Click;

menu.Items.Add(button);
```
## Supported Platforms
- Windows 10
- Windows 8
- Windows 7 (including Aero)
- Windows Vista (including Aero)
- Windows 2000
- Windows XP

## Source repository

This repository is a fork of:  
https://github.com/leandrosimoes/ActiveButtons.Net
