package com.company.Ex10;

/**
 * The following application should change the time stamp of the file its pathname it receives via the command line.
 * The new time stamp should be the current time. You should complete the missing code.
 */
import java.io.*;

public class FileTimeStampModification
{
    public static void main(String[] args)
    {
        String filePath = args[0];
        File fileObject = new File(filePath);
        long newTimeStamp = System.currentTimeMillis();
        boolean changed = fileObject.setLastModified(newTimeStamp);
        if(changed)
        {
            System.out.println("The time stamp was successfully changed.");
        }
        else
        {
            System.out.println("The time stamp was not changed.");
        }
    }
}
