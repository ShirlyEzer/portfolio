package com.samples;

/**
 * Created by User on 18/11/2014.
 */
import java.lang.Exception;
import java.net.*;
import java.io.*;
import java.util.*;

class TCPParallelServerImp implements Runnable
{
    private ServerSocket serverSocket;

    public void go() throws Exception
    {
        serverSocket = new ServerSocket(1300,5);
        Thread t1 = new Thread(this,"A");
        Thread t2 = new Thread(this,"B");
        Thread t3 = new Thread(this,"C");
        Thread t4 = new Thread(this,"D");

        t1.start();
        t2.start();
        t3.start();
        t4.start();
    }

    @Override
    public void run() {
        Socket soc = null;
        BufferedWriter bw = null;
        String myName = Thread.currentThread().getName();

        while (true)
        {
            try {
                System.out.println("thread " + myName + " is waiting...");
                serverSocket.setSoTimeout(4000);
                soc = serverSocket.accept();
                System.out.println("thread " + myName + " has accepted a connection");
                bw = new BufferedWriter(new OutputStreamWriter(soc.getOutputStream()));
                bw.write("The thread that in action now is: " + myName);
                bw.newLine();
                bw.write("The date is: " + new Date());
                bw.newLine();
                Thread.sleep(5000);
                bw.write("This is the last line to be recieved from" + myName);
                bw.close();
                System.out.println("thread " + myName + " has terminated the connection");
            }
            catch (InterruptedException e)
            {
                System.out.println("The accept method in " + myName + " stoped from waiting since a timeout was set");
            }
            catch (Exception e)
            {
                e.printStackTrace();
            }
        }
    }
}