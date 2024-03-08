using System;
using System.Collections.Generic;

public class Process
{
    public int ProcessId { get; private set; }
    public int NumberOfTickets { get; set; } // Make set accessor public

    public Process(int processId, int numberOfTickets)
    {
        ProcessId = processId;
        NumberOfTickets = numberOfTickets;
    }
}


public class Scheduler
{
    private Queue<Process> readyQueue;
    private int currentTime;
    private int timeQuantum;
    private Random random;

    public Scheduler(int timeQuantum)
    {
        readyQueue = new Queue<Process>();
        currentTime = 0;
        this.timeQuantum = timeQuantum;
        random = new Random();
    }

    public void AddProcess(int processId, int numberOfTickets)
    {
        readyQueue.Enqueue(new Process(processId, numberOfTickets));
    }

    public void RunRoundRobin()
    {
        while (readyQueue.Count > 0)
        {
            Process currentProcess = readyQueue.Dequeue();
            int executionTime = Math.Min(timeQuantum, currentProcess.NumberOfTickets);
            currentProcess.NumberOfTickets -= executionTime;
            currentTime += executionTime;

            if (currentProcess.NumberOfTickets > 0)
            {
                readyQueue.Enqueue(currentProcess); // Add back to the queue if tickets remaining
            }
            else
            {
                Console.WriteLine($"Process {currentProcess.ProcessId} wins the lottery!");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scheduler scheduler = new Scheduler(2); // Time quantum is set to 2

        // Adding processes with different numbers of tickets
        scheduler.AddProcess(1, 5);
        scheduler.AddProcess(2, 3);
        scheduler.AddProcess(3, 10);

        // Run Round Robin scheduling
        scheduler.RunRoundRobin();
    }
}
