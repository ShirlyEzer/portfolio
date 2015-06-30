package com.company.Ex08;

/**
 * The following application should delete the file its pathname it receives via the command line.
 * You should complete the missing code.
 */
import java.io.*;

public class FileDelete
{
    public static void main(String[] args)
    {
        String filePath = args[0];
        File fileObject = new File(filePath);
        boolean deleted = fileObject.delete();
        if(deleted)
        {
            System.out.println("The file " + filePath + " was successfully deleted.");
        }
        else
        {
            System.out.println("The file " + filePath + " couldn't be deleted.");
        }
    }
}
