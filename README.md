# SampleNUnitTest
This is my sample NUnit test 

Instructions

Update Chrome browser
1. Install or update to the latest version of Chrome browser (76)

Install netcore 2.1
1. Download https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.1.801-windows-x64-installer
2. Run the dotnet-sdk-2.1.801-windows-x64-installer to install it on your machine
3. Follow through the wizard to complete the installation

Install Nunit console
1. Download https://github.com/nunit/nunit-console/releases/download/v3.10/NUnit.Console-3.10.0.msi
2. Run NUnit.Console-3.10.0.msi to install it
3. Follow through the wizard, select 'Typical' installation
4. Click install button

Download the test project
1. Click 'Clone or Download' and choose 'Download ZIP'
2. Save the zip file to your local drive.
3. Extract the 'SampleNUnitTest-master.zip'
4. Copy or move the 'SampleTest' folder inside 'SampleNUnitTest-master' folder to your 'C:/' drive
5. Structure should be exactly like this: 'C:\SampleTest'
6. Open command prompt and enter command: dotnet test "C:\SampleTest\SampleTest\SampleTest.csroj"
7. Test should be executed, and result is logged in the console
