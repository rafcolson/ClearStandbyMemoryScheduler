# ClearStandbyMemoryScheduler

With this small application *Stand-by Memory* is cleared every specified interval. The process is started and stopped manually or run automatically at system startup and optionally hidden to the system tray with a context menu. This single instance application is automatically run as administrator. Settings are stored with changes made.

![ClearStandbyMemoryScheduler](https://user-images.githubusercontent.com/10002909/138174063-bee5a9b5-1ada-4cf0-8acc-c2727ac66ff0.png)

License
-------
[BSD 3-Clause License](https://opensource.org/licenses/BSD-3-Clause).

Development
-----------
There are other solutions out there but I didn't find one that's complete. The [EmptyStandByList.exe by Wen Jia Liu](https://wj32.org/wp/software/empty-standby-list) can be scheduled with the *Windows Task Scheduler*. (See [video](https://www.youtube.com/watch?v=WnKDPLjbg_I)). There's also [@duducorvao/EmptyStandbyListTimer](https://github.com/duducorvao/EmptyStandbyListTimer) which schedules the execution of that executable programmatically.

In contrast *ClearStandbyMemoryScheduler* clears *Stand-by Memory* programmatically, based on the answers at a [stackoverflow thread about clearing Stand-by Memory programmatically](https://stackoverflow.com/questions/12841845/clear-the-windows-7-standby-memory-programmatically).

Note: If you are a developer and want to fork this project, you should run Visual Studio as administrator.

Download and Install
--------------------
You can find the latest release [here](https://github.com/rafcolson/ClearStandbyMemoryScheduler/releases). Download and run *ClearStandbyMemoryScheduler-x64.msi*.
