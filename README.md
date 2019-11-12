
# Art Project

This is the code repository for the Gemstone team ART of class 2020 Augmented Reality application.


  
## Purpose
Our research investigated if we could develop an augmented reality application that could aid dyslexic children in spelling. This application reads words and attempts to help correct them. 
  

## Building the Project

Clone the repository


Open the project Using Unity 2018.4 LTS. Potentially newer versions will also work.

Install MRTK version 2.0 from the git page [here](https://github.com/microsoft/MixedRealityToolkit-Unity/releases)

  

Player settings should have mixed reality supported.

Update API key with your own in Assets/VisionTwoHelper.cs

  

To build select Universal Windows Platform, Target Device Hololense, x86 Architecture, D3D Build Type, 10.0.10240.0 Minimum Platform Version, as well as have Unity C# projects checked.

Build to App folder.

Open Visual Studio Sln.

  

Install Nuget Packages
	-Windows UWP
	-Azure.CognitiveServices.Vision
  

Build to your Hololens. Find the IPv4 address and enter it when prompted after selecting remote device under build.

To install a debug version select Release or Debug build, otherwise select Master Build to install a regualr version.

## Acknowledgements
Thanks to the [Gemstone Staff, and Dr. Kristen Skendall](http://gemstone.umd.edu/), our mentor [Dr. Mathias Zwicker](https://www.cs.umd.edu/~zwicker/), Yu Lu, Matthew Chung, all of the experts that lent us their invaluable insight, The XR club, all of our launch donors, and all of our study participants.
## Contact
Contact team members about this project at teamartgemstone AT gmail or on our [facebook page]([https://www.facebook.com/UMDGemstoneTeamART/](https://www.facebook.com/UMDGemstoneTeamART/))