# Perfmon (Windows Performance Monitor) Guide

This is a guide on how to monitor .NET CLR garbage collection percent in Windows Performance Monitor (`perfmon`).

</br>

## How to open Perfmon

1. Start the program you want to monitor, e.g., `StringConcatSpeed.exe`
2. In a terminal or in Windows Start enter `perfmon` and press [ENTER]
3. You should now see the `perfmon` application.

</br>

---

</br>

## Setup Perfmon to track Percent Time in GC

1. Expand `Monitoring Tools` (Overvågningsværktøjer) and click on `Performance Monitor` (Ydelsesmåler)
![Step1](perfmon/perfmon_1.png)
2. Click on the red cross to remove all monitored process.
![Step2](perfmon/perfmon_2.png)
3. Click on the green cross to add a new process to be monitored.
![Step3](perfmon/perfmon_3.png)
4. Click the expansion arrow under `.NET CLR Memory` (.NET CLR Hukommelse)
![Step4](perfmon/perfmon_4.png)
5. In the list find "`% Time in GC`" ("Tid til GC i procent") and select it.
![Step5](perfmon/perfmon_5.png)
6. In the instance selector, find `StringConcatSpeed` and select it.
![Step6](perfmon/perfmon_6.png)
7. Click the add button, and then the OK button.
![Step7](perfmon/perfmon_7.png)
8. `StringConcatSpeed` will now be monitored by the selected counter.
![Step8](perfmon/perfmon_8.png)

</br>

---
