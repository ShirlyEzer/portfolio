package com.company.Ex07;

/**
 * The following application should print out the length of the file you pass its name via the command line.
 * You should complete the missing code.
 */
import java.io.*;

public class FileLength
{
    public static void main(String[] args)
    {
        String filePath = args[0];
        File fileObject = new File(filePath);
        long fileSize = fileObject.length();
        System.out.println("The size of the file is " + fileSize + " bytes.");
    }
}
