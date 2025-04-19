# IWantDadJoke

IWantDadJoke is an extension that gives you dad jokes in CmdPal. yeah, it's stupid

This extension uses `icanhazdadjoke.com` for the dad jokes. This is not affiliated with it in any way.

# Installation

**THIS IS NOT IN WINGET. I DO NOT HAVE A SIGNING CERTIFICATE. YOU WILL HAVE TO MANUALLY BUILD AND UPDATE THE EXTENSION.**
don't worry: i'll update you once i get one

0. You'll need:
   * **Visual Studio 2022**: Get it from [the visual studio website](https://visualstudio.microsoft.com/vs/). The community edition should work
   * **Git**: well, yeah. [Git SCM downloads here.](https://git-scm.com/downloads)
   * **Command Palette**: Install PowerToys, go to the Command Palette section, open settings, and turn it on.
     * ![image](https://github.com/user-attachments/assets/f91c48a0-0df6-4344-b067-2376087de23a)


2. Clone the repository
   If you're not a cool developer, `git clone https://github.com/josiauh/IWantDadjoke.git`.
3. Open the solution in Visual Studio 2022
4. Go to the Build section and select Deploy Solution.
5. you're done!
6. 

# Q&A

Q: Why did you even MAKE THIS?

A: it's a stupid test extension.

Q: What does the code do?

A: makes web request to `icanhazdadjoke.com` for a json, gets the id and actual joke, and displays it in the command palette list items.

   
