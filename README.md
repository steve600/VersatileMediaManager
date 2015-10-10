## Welcome to Versatile Media Manager ##

I've started to implement an universal media manager based on [Prism-Library](https://github.com/PrismLibrary) and the [MahApps.Metro](https://github.com/MahApps/MahApps.Metro). Here are some ideas on the planned features:

- Support for popular media players (it should be possible to manage the media library of Kodi media players, ...)
- Management of local media files (for example MP3: support for metadata (ID3), renaming, Cover, data import from freedb, amazon, batch editing, ...)
- Management for a PVR like VU+ or Dreambox (Bouquets, Timers, RemoteControl, EPG, ...)
- possibly an interface for smartphones (Windows Phone, ...) to manage media files directly on the device
- Support for common movie databases like TMDb, OMDb, ...
- ...

The application uses the following libraries:

- [Prism-Library](https://github.com/PrismLibrary) for modular application development (MVVM-Base, EventAggregator, ...)
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro) for the UI
- [Unity](https://github.com/unitycontainer/unity) as DI-Container
- [WPFLocalizationExtension](https://github.com/SeriousM/WPFLocalizationExtension) for the localization
- [Microsoft EnterpriseLibrary](https://entlib.codeplex.com/) for the crosscutting-concerns (at the moment only the Logging Application Block is used)
- [Newtonsoft Json.NET](http://www.newtonsoft.com/json) for the JSON serialization

Some will now be wondering: Why all these components for a simple media manager?

Quite simply: Especially with some components (like Prism or the Microsoft Enterprise Library) I've only found examples that describes enterprise applications. Enterprise software is normally intended to solve an enterprise-wide problem like an Accounting-Software or Trading-Systems. In these kind of software you often has recurring problems like reusability, exchangeability, loosely coupled components, communication between loosely coupled components, logging, localization and so on. For these problems you can then use Prism or the Microsoft Enterprise Library.

Exactly the same problems you now have with the supposed simple Media Manager. For example you have different "backend" systems like a Kodi Media Player, a PVR like VU+ or the local hard disk to communicate with. Then you might want to retrieve additional media information from various sources like the TMDb, OMDb and this functionality should be available application-wide for the different modules. If an error occurs the error should be logged (possibly in different logging targets) and so on.

Using these components can save you a lot of work and I just wanted to do something which I do not do every day at work ;-)

Currently the application is at a very early development stage but the following features are already implemented:

- General project structure and technical basis (more information: [WIKI](https://github.com/steve600/VersatileMediaManager/wiki/General-project-structure))
- UI based on MahApps.Metro with different Prism-Regions (more information: [WIKI](https://github.com/steve600/VersatileMediaManager/wiki/Prism-Regions))
- Localization as an application wide service so it's possible to localize in XAML and in the ViewModel
- Logging based on the Logging Application Block of the Microsoft Enterprise Library
- Connection management (for the different types of connections like JsonRpc, Database, ...)
- Technical basis for the management of Kodi media players

So far the UI looks like this:

Main-Window
![Main Window](http://csharp-blog.de/wp-content/uploads/2015/10/VersatileMediaManager_01.png)

Kodi-Management
![Main Window](http://csharp-blog.de/wp-content/uploads/2015/10/VersatileMediaManager_03.png)

Kodie-MovieManagement
![Main Window](http://csharp-blog.de/wp-content/uploads/2015/10/VersatileMediaManager_04.png)
