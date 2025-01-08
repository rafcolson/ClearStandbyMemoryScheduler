# ClearStandbyMemoryScheduler

This little application clears *standby memory* every specified number of minutes, depending on a condition or not. If the threshold is set to _Available memory_, the operation is skipped when the available memory exceeds a certain amount of MB. The same goes for when the threshold is set to _Standby memory_, when the standby memory does not exceed a certain amount of MB. With _No threshold_ set, it will always clear after the specified number of minutes. PCs with less available RAM may benefit more from evaluating every minute if the available memory is less than a GB or so. It is better to clear only when absolutely necessary.

The process is started and stopped manually or run automatically at system startup and optionally hidden to the system tray with a context menu. This single instance application is automatically run as administrator. Settings are stored with changes made.

![ClearStandbyMemoryScheduler](https://github.com/user-attachments/assets/994496fb-9416-4a28-8f91-687b4f05471a)

License
-------
[BSD 3-Clause License](https://opensource.org/licenses/BSD-3-Clause).

Development
-----------
There are other solutions out there but I didn't find one that's complete. The [EmptyStandByList.exe by Wen Jia Liu](https://wj32.org/wp/software/empty-standby-list) can be scheduled with the *Windows Task Scheduler*. (See [video](https://www.youtube.com/watch?v=WnKDPLjbg_I)). There's also [@duducorvao/EmptyStandbyListTimer](https://github.com/duducorvao/EmptyStandbyListTimer) which schedules the execution of that executable programmatically.

In contrast *ClearStandbyMemoryScheduler* clears *standby memory* programmatically, based on the answers at a [stackoverflow thread about clearing standby memory programmatically](https://stackoverflow.com/questions/12841845/clear-the-windows-7-standby-memory-programmatically).

Note: If you are a developer and want to fork this project, you should run Visual Studio as administrator.

Download and Install
--------------------
You can find the latest release [here](https://github.com/rafcolson/ClearStandbyMemoryScheduler/releases). Download and run *ClearStandbyMemoryScheduler.msi*.
