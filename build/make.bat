set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
%CSC% /t:winexe /out:CoordPicker.exe /win32manifest:..\CoordPicker\app.manifest ..\CoordPicker\Program.cs ..\CoordPicker\CoordPicker.cs ..\CoordPicker\CoordPicker.Designer.cs ..\CoordPicker\Properties\AssemblyInfo.cs
