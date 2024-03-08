# Lottery


The program was written using c# netcore version 7. The purpose of the program is to implement a process class that has a unique identifier, multiple tickets. With a constructor that initilizes both. 
The scheduler class uses round robin that takes a quantum cycles in fixed times. A queue readyQueue is created of processes. 
Processes are added in the scheduler class and add them to the queue. The round robin continues until there is no more processes. The process that runs out of ticket first wins the lottery first. 
The program  creates a new scheduler with different number of tickets. then the roundrobin is called and a ticket is picked. 