📂 SystemVitals
A real-time hardware monitoring dashboard that bridges High-Performance C++ with a Modern C# WPF Interface

🏗️ Project Architecture
-This solution is split into two main parts to separate logic from design:

VitalsUI (C# / WPF)
-The Brain: Manages a DispatcherTimer that requests data every 1 second.
-The Face: A dark-themed XAML dashboard designed for high visibility.
-The Bridge: Uses P/Invoke (DllImport) to communicate with the C++ backend.

VitalsEngine (C++ / Win32)
-The Muscle: A Dynamic Link Library (DLL) that interacts directly with Windows system APIs.
-The Export: Uses extern "C" to provide a stable entry point for the C# UI to call.

🚀 Getting Started
1. Prerequisites
Visual Studio 2022 with the following workloads:
-.NET Desktop Development (for C#)
-Desktop Development with C++ (for the Engine)

2. Setup & Installation
-Clone the Repo: Download the project files from GitHub.
-Set Architecture: In the top toolbar of Visual Studio, change the Solution Platform from Any CPU to x64. (This is required for the C++ bridge to work).
-Build the Engine: Right-click the VitalsEngine project and select Build. This generates the VitalsEngine.dll.
-Link the UI: * Ensure VitalsEngine.dll is added to the VitalsUI project.
-In Properties, set Copy to Output Directory to "Copy if newer".
-Run: Set VitalsUI as the Startup Project and press F5.



🛠️ Development Workflow
Adding a New Metric (e.g., RAM Usage)

C++ Side: Create a new function in dllmain.cpp inside the extern "C" block.
C++
__declspec(dllexport) float GetRamUsage() { 
    return 15.5f; // Logic goes here
}

C# Side: Add the import line in MainWindow.xaml.cs.
C#
[DllImport("VitalsEngine.dll")]
public static extern float GetRamUsage();







