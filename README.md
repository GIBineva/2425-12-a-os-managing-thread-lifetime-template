# Multi-Threaded Task Manager

A simple program that simulates a task manager using **multithreading**. This program allows users to create and manage multiple tasks running in separate threads.

## Features
- Start and monitor multiple tasks concurrently.
- List all running tasks.
- Resume/Suspend specific tasks gracefully.
- Exit the program safely, ensuring all threads are stopped.

## Usage
Upon running the program, you will see a menu allowing you to:
```
Task Manager:
1. Start a new task
2. List running tasks
3. Resume/Suspend task by PID
4. Exit
```
## Core Tasks:
Start a new task
```
Create a new thread for a task.
Assign a unique Process ID (PID).
Start task execution.
```

List running tasks
```
Display all currently running tasks.
Show each task’s PID and status (running/suspended).
```
Resume/Suspend task by PID
```
Find the task by PID.
Pause/resume task execution using thread synchronization mechanisms (e.g., Event in Python).
```

Monitor CPU Usage (NEW FEATURE)
```
Each task consumes a random percentage of CPU.
The total CPU usage of all tasks cannot exceed 100%.
If starting a new task would push usage over 100%, the program should prevent it or pause lower-priority tasks.
```

Exit the program
```
Gracefully terminate all running tasks before exiting.
```
